using System;
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
        public Config Config;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        readonly InputLayerControl InputLayer;
        readonly OutputLayerControl OutputLayer;

        readonly IntPtr __h;

        public NetworkControl(string name, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;

            //https://stackoverflow.com/questions/1532301/visual-studio-tabcontrol-tabpages-insert-not-working
            __h = CtlTabsLayers.Handle;

            Config = String.IsNullOrEmpty(name) ? CreateNewNetwork() : new Config(name);
            if (Config != null)
            {
                InputLayer = new InputLayerControl(Config, onNetworkUIChanged);
                CtlTabInput.Controls.Add(InputLayer);

                OutputLayer = new OutputLayerControl(Config, onNetworkUIChanged);
                CtlTabOutput.Controls.Add(OutputLayer);

                LoadConfig();
            }

            CtlTabsLayers.SelectedIndex = 0;

            CtlTabsLayers.SelectedIndexChanged += CtlTabsLayers_SelectedIndexChanged;
            CtlRandomizerParamA.TextChanged += CtlRandomizerParamA_TextChanged;
            CtlRandomizer.SelectedValueChanged += CtlRandomizer_SelectedValueChanged;
            CtlLearningRate.TextChanged += CtlLearningRate_TextChanged;
        }

        private void CtlLearningRate_TextChanged(object sender, EventArgs e)
        {
            CtlLearningRate.BackColor = IsValidLearningRate() ? Color.White : Color.Tomato;
        }

        private void CtlRandomizer_SelectedValueChanged(object sender, EventArgs e)
        {
            CtlRandomizerLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlRandomizerParamA_TextChanged(object sender, EventArgs e)
        {
            CtlRandomizerParamA.BackColor = IsValidRandomizeParamA() ? Color.White : Color.Tomato;
        }

        private void CtlTabsLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlMenuDeleteLayer.Enabled = CtlTabsLayers.SelectedIndex > 0 && CtlTabsLayers.SelectedIndex < CtlTabsLayers.TabCount - 1;
        }

        private void AddLayer(long id)
        {
            var layer = new HiddenLayerControl(id == Const.UnknownId ? DateTime.Now.Ticks : id, Config, OnNetworkUIChanged);
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

        private void ResetLayersTabsNames()
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
        }

        private void CtlMenuAddLayer_Click(object sender, EventArgs e)
        {
            AddLayer(Const.UnknownId);
        }

        public Config CreateNewNetwork()
        {
            var saveDialog = new SaveFileDialog
            {
                InitialDirectory = Path.GetFullPath("Networks\\"),
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveDialog.FileName))
                {
                    File.Delete(saveDialog.FileName);
                }

                var name = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                var config = new Config(saveDialog.FileName);
                Config.Main.Set(Const.Param.NetworkName, saveDialog.FileName);
                return config;
            }
 
            return null;
         }

        public Config SaveAs()
        {
            var saveDialog = new SaveFileDialog
            {
                InitialDirectory = Path.GetFullPath("Networks\\"),
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveDialog.FileName))
                {
                    File.Delete(saveDialog.FileName);
                }

                var name = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                Config = new Config(saveDialog.FileName);
                Config.Main.Set(Const.Param.NetworkName, saveDialog.FileName);
                return Config;
            }

            return null;
        }

        private bool IsValidRandomizeParamA()
        {
            return Converter.TryTextToDouble(CtlRandomizerParamA.Text, out double? d);
        }

        private bool IsValidLearningRate()
        {
            if (Converter.TryTextToDouble(CtlLearningRate.Text, out double? d))
            {
                return d.HasValue && 0 < d && d <= 1;
            }

            return false;
        }

        public bool IsValid()
        {
            bool result = true;
            result &= IsValidRandomizeParamA();
            result &= IsValidLearningRate();

            var layers = GetLayersControls();
            Range.ForEach(layers, l => result &= l.IsValid());
            return result;
        }

        public void SaveConfig()
        {
            Config.Set(Const.Param.Randomizer, Randomizer);
            Config.Set(Const.Param.RandomizerParamA, CtlRandomizerParamA.Text);
            Config.Set(Const.Param.LearningRate, CtlLearningRate.Text);

            var layers = GetLayersControls();
            Range.ForEach(layers, l => l.SaveConfig());
            Config.Set(Const.Param.HiddenLayers, layers.Where(l => l.IsHidden).Select(l => l.Id));

            //

            ResetLayersTabsNames();
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
            RandomizeMode.Helper.FillComboBox(CtlRandomizer, Config);
            CtlRandomizerParamA.Text = Config.GetString(Const.Param.RandomizerParamA);
            CtlLearningRate.Text = Config.GetString(Const.Param.LearningRate, "0.05");

            //

            var layers = Config.GetArray(Const.Param.HiddenLayers);
            Range.For(layers.Length, i => AddLayer(layers[i]));
        }

        public int[] GetLayersSize()
        {
            var result = new List<int>();
            Range.ForEach(GetLayersControls(), l => result.Add(l.NeuronsCount));
            return result.ToArray();
        }

        public int InputNeuronsCount => InputLayer.Config.GetInt(Const.Param.InputNeuronsCount);

        private string Randomizer => CtlRandomizer.SelectedItem.ToString();
        private double? RandomizerParamA => Converter.TextToDouble(CtlRandomizerParamA.Text);
        private double? LearningRate => Converter.TextToDouble(CtlLearningRate.Text);

        public Type ActiveLayerType => CtlTabsLayers.SelectedTab.Controls[0].GetType();

        private void CtlMenuDeleteLayer_Click(object sender, EventArgs e)
        {
            var layerIndex = CtlTabsLayers.TabPages.IndexOf(CtlTabsLayers.SelectedTab);

            if (MessageBox.Show($"Would you really like to delete layer L{layerIndex}?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
            var model = new NetworkDataModel(this)
            {
                Randomizer = Randomizer,
                RandomizerParamA = RandomizerParamA,
                LearningRate = LearningRate.Value
            };

            RandomizeMode.Helper.Invoke(Randomizer, model, RandomizerParamA);

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
    }
}
