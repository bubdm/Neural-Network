﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tools;

namespace NN.Controls
{
    public partial class NetworkControl : UserControl
    {
        public readonly long Id;
        public Config Config;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public InputLayerControl InputLayer
        {
            get;
            private set;
        }

        OutputLayerControl OutputLayer;

        readonly IntPtr __h;

        public NetworkControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            OnNetworkUIChanged = onNetworkUIChanged;                    
            
            //https://stackoverflow.com/questions/1532301/visual-studio-tabcontrol-tabpages-insert-not-working
            __h = CtlTabsLayers.Handle;

            Id = UniqId.GetId(id);
            Config = config.Extend(Id);

            LoadConfig();
            
            CtlTabsLayers.SelectedIndexChanged += CtlTabsLayers_SelectedIndexChanged;
            CtlRandomizerParamA.Changed += OnChanged;
            CtlRandomizer.SelectedValueChanged += CtlRandomizer_SelectedValueChanged;
            CtlLearningRate.Changed += OnChanged;
        }

        protected override void OnResize(EventArgs e)
        {
            CtlTabsLayers.SuspendLayout();
            base.OnResize(e);
            CtlTabsLayers.ResumeLayout();// .Visible = true;
        }

        public void ResizeBegin()
        {
            CtlTabsLayers.SuspendLayout();
        }

        public void ResizeEnd()
        {
            CtlTabsLayers.ResumeLayout();
        }

        private void OnChanged()
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlRandomizer_SelectedValueChanged(object sender, EventArgs e)
        {
            CtlLearningRateLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlTabsLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlMenuDeleteLayer.Enabled = CtlTabsLayers.SelectedIndex > 0 && CtlTabsLayers.SelectedIndex < CtlTabsLayers.TabCount - 1;
        }

        public void AddLayer()
        {
            AddLayer(Const.UnknownId);
        }

        private void AddLayer(long id)
        {
            var layer = new HiddenLayerControl(id, Config, OnNetworkUIChanged);
            var tab = new TabPage();
            tab.Controls.Add(layer);
            CtlTabsLayers.TabPages.Insert(CtlTabsLayers.TabCount - 1, tab);
            CtlTabsLayers.SelectedTab = tab;
            ResetLayersTabsNames();
            if (id == Const.UnknownId)
            {
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public void ResetLayersTabsNames()
        {
            var layers = GetLayersControls();
            for (int i = 0; i < layers.Count; ++i)
            {
                if (layers[i].IsInput)
                {
                    CtlTabsLayers.TabPages[i].Text = $"Input ({layers[i].NeuronsCount})";
                }
                else if (layers[i].IsOutput)
                {
                    CtlTabsLayers.TabPages[i].Text = $"Output ({layers[i].NeuronsCount})";
                }
                else
                {
                    CtlTabsLayers.TabPages[i].Text = $"L{i} ({layers[i].NeuronsCount})";
                }
            }

            Refresh();
        }

        private void CtlMenuAddLayer_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        public bool IsValid()
        {
            return CtlRandomizerParamA.IsValid() &&
                   CtlLearningRate.IsValid() &&
                   GetLayersControls().All(c => c.IsValid());
        }

        public void SaveConfig()
        {
            Config.Set(Const.Param.SelectedLayerIndex, CtlTabsLayers.SelectedIndex);
            Config.Set(Const.Param.RandomizeMode, Randomizer);
            Config.Set(Const.Param.Color, $"{CtlColor.BackColor.A},{CtlColor.BackColor.R},{CtlColor.BackColor.G},{CtlColor.BackColor.B}");

            CtlRandomizerParamA.Save(Config);
            CtlLearningRate.Save(Config);

            var layers = GetLayersControls();
            Range.ForEach(layers, l => l.SaveConfig());
            Config.Set(Const.Param.Layers, layers.Select(l => l.Id));

            //

            ResetLayersTabsNames();
        }

        public void VanishConfig()
        {
            Config.Remove(Const.Param.SelectedLayerIndex);
            Config.Remove(Const.Param.RandomizeMode);
            Config.Remove(Const.Param.Color);

            CtlRandomizerParamA.Vanish(Config);
            CtlLearningRate.Vanish(Config);

            var layers = GetLayersControls();
            Range.ForEach(layers, l => l.VanishConfig());
            Config.Remove(Const.Param.Layers);
        }

        public List<LayerBase> GetLayersControls()
        {
            var result = new List<LayerBase>();
            for (int i = 0; i < CtlTabsLayers.TabCount; ++i)
            {
                if (CtlTabsLayers.TabPages[i].Controls[0] is LayerBase layer)
                {
                    result.Add(layer);
                }
            }
            return result;
        }

        private void LoadConfig()
        {
            RandomizeMode.Helper.FillComboBox(CtlRandomizer, Config, Const.Param.RandomizeMode, nameof(RandomizeMode.Random));
            CtlRandomizerParamA.Load(Config);
            CtlLearningRate.Load(Config);
            var color = Config.GetArray(Const.Param.Color, "255,255,255,255");
            CtlColor.BackColor = Color.FromArgb((int)color[0], (int)color[1], (int)color[2], (int)color[3]);

            //

            CtlTabsLayers.SuspendLayout();
            var layers = Config.GetArray(Const.Param.Layers);

            var inputLayerId = layers.Length > 0 ? layers[0] : Const.UnknownId;
            var outputLayerId = layers.Length > 0 ? layers[layers.Length - 1] : Const.UnknownId;

            InputLayer = new InputLayerControl(inputLayerId, Config, OnNetworkUIChanged);
            CtlTabInput.Controls.Add(InputLayer);

            OutputLayer = new OutputLayerControl(outputLayerId, Config, OnNetworkUIChanged);
            CtlTabOutput.Controls.Add(OutputLayer);
           
            Range.ForEach(layers, l =>
            {
                if (l != layers.First() && l != layers.Last())
                    AddLayer(l);
            });

            CtlTabsLayers.SelectedIndex = Config.GetInt(Const.Param.SelectedLayerIndex, 0).Value;
            CtlTabsLayers.ResumeLayout();
        }

        public int[] GetLayersSize()
        {
            return GetLayersControls().Select(l => l.NeuronsCount).ToArray();
        }

        public int InputNeuronsCount => InputLayer.GetNeuronsControls().Where(c => !c.IsBias).Count();

        private string Randomizer => CtlRandomizer.SelectedItem.ToString();
        private double? RandomizerParamA => CtlRandomizerParamA.ValueOrNull;
        private double LearningRate => CtlLearningRate.Value;

        public LayerBase SelectedLayer => CtlTabsLayers.SelectedTab.Controls[0] as LayerBase;
        public Type SelectedLayerType => CtlTabsLayers.SelectedTab.Controls[0].GetType();
        public bool IsSelectedLayerHidden => SelectedLayerType == typeof(HiddenLayerControl);

        private void CtlMenuDeleteLayer_Click(object sender, EventArgs e)
        {
            DeleteLayer();
        }

        public void DeleteLayer()
        {
            if (MessageBox.Show($"Would you really like to delete layer L{CtlTabsLayers.SelectedIndex + 1}?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var layer = CtlTabsLayers.SelectedTab.Controls[0] as HiddenLayerControl;
                layer.VanishConfig();

                CtlTabsLayers.TabPages.Remove(CtlTabsLayers.SelectedTab);
                ResetLayersTabsNames();
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public NetworkDataModel CreateNetworkDataModel()
        {
            var model = new NetworkDataModel(Id, GetLayersSize())
            {
                Color = CtlColor.BackColor,
                //Statistic = new Statistic(true),
                //DynamicStatistic = new DynamicStatistic(),
                RandomizeMode = Randomizer,
                RandomizerParamA = RandomizerParamA,
                LearningRate = LearningRate,
                InputInitial0 = ActivationFunction.Helper.Invoke(InputLayer.ActivationFunc, InputLayer.Initial0),
                InputInitial1 = ActivationFunction.Helper.Invoke(InputLayer.ActivationFunc, InputLayer.Initial1)
            };

            model.Activate();

            var layers = GetLayersControls();
            for (int ln = 0; ln < layers.Count; ++ln)
            {
                model.Layers[ln].VisualId = layers[ln].Id;

                var neurons = layers[ln].GetNeuronsControls();
                for (int nn = 0; nn < neurons.Count; ++nn)
                {
                    var neuronModel = model.Layers[ln].Neurons[nn];
                    neuronModel.VisualId = neurons[nn].Id;
                    neuronModel.IsBias = neurons[nn].IsBias;
                    neuronModel.IsBiasConnected = neurons[nn].IsBiasConnected;

                    neuronModel.ActivationFunc = neurons[nn].ActivationFunc;
                    neuronModel.ActivationFuncParamA = neurons[nn].ActivationFuncParamA;

                    neuronModel.WeightsInitializer = neurons[nn].WeightsInitializer;
                    neuronModel.WeightsInitializerParamA = neurons[nn].WeightsInitializerParamA;
                    double initValue = InitializeMode.Helper.Invoke(neurons[nn].WeightsInitializer, neurons[nn].WeightsInitializerParamA);
                    if (!InitializeMode.Helper.IsSkipValue(initValue))
                    {
                        foreach (var weight in neuronModel.Weights)
                        {
                            weight.Weight = InitializeMode.Helper.Invoke(neurons[nn].WeightsInitializer, neurons[nn].WeightsInitializerParamA);
                        }
                    }

                    if (neuronModel.IsBias)
                    {
                        neuronModel.ActivationInitializer = neurons[nn].ActivationInitializer;
                        neuronModel.ActivationInitializerParamA = neurons[nn].ActivationInitializerParamA;
                        initValue = InitializeMode.Helper.Invoke(neurons[nn].ActivationInitializer, neurons[nn].ActivationInitializerParamA);
                        if (!InitializeMode.Helper.IsSkipValue(initValue))
                        {
                            neuronModel.Activation = initValue;
                        }
                    }
                }
            }

            model.Layers.Last().VisualId = Const.OutputLayerId;
            {
                var neurons = OutputLayer.GetNeuronsControls();
                for (int i = 0; i < neurons.Count; ++i)
                {
                    model.Layers.Last().Neurons[i].VisualId = neurons[i].Id;
                }
            }

            return model;
        }

        private void CtlRandomViewerButton_Click(object sender, EventArgs e)
        {
            var viewer = new RandomViewer(Randomizer, RandomizerParamA);
            viewer.Show();
        }

        private void CtlColor_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.Color = CtlColor.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    CtlColor.BackColor = colorDialog.Color;
                    OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
                }
            }
        }

        private void CtlContextMenu_Opening(object sender, CancelEventArgs e)
        {
            CtlMenuDeleteLayer.Enabled = IsSelectedLayerHidden;
        }
    }
}
