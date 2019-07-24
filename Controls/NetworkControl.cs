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

namespace Dots.Controls
{
    public partial class NetworkControl : UserControl
    {
        public Config Config;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        readonly InputLayerControl InputLayer;
        readonly OutputLayerControl OutputLayer;

        public NetworkControl(string name, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;
            CtlTabsLayers.SelectedIndexChanged += CtlTabsLayers_SelectedIndexChanged;
            CtlRandomizerParamA.TextChanged += CtlRandomizerParamA_TextChanged;

            Config = String.IsNullOrEmpty(name) ? CreateNewNetwork() : new Config(name);
            if (Config != null)
            {
                InputLayer = new InputLayerControl(Config, onNetworkUIChanged);
                CtlTabInput.Controls.Add(InputLayer);

                OutputLayer = new OutputLayerControl(Config, onNetworkUIChanged);
                CtlTabOutput.Controls.Add(OutputLayer);

                LoadConfig();
            }

            CtlRandomizer.SelectedValueChanged += CtlRandomizer_SelectedValueChanged;
        }

        private void CtlRandomizer_SelectedValueChanged(object sender, EventArgs e)
        {
            CtlRandomizerLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlRandomizerParamA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateRandomizeParamA();
                CtlRandomizerParamA.BackColor = Color.White;
            }
            catch
            {
                CtlRandomizerParamA.BackColor = Color.Red;
                return;
            }
        }

        private void CtlTabsLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlMenuDeleteLayer.Enabled = CtlTabsLayers.SelectedIndex > 0 && CtlTabsLayers.SelectedIndex < CtlTabsLayers.TabCount - 1;
        }

        private void AddLayer(long id)
        {
            id = id == Const.UnknownId ? DateTime.Now.Ticks : id;
            var layer = new LayerControl(id, Config, OnNetworkUIChanged);
            var tab = new TabPage();
            tab.Controls.Add(layer);
            CtlTabsLayers.TabPages.Insert(CtlTabsLayers.TabCount - 1, tab);
            CtlTabsLayers.SelectedTab = tab;
        }

        private void ResetLayersTabsNames()
        {
            CtlTabsLayers.TabPages[0].Text = $"Input ({InputLayer.NeuronsCount})";
            CtlTabsLayers.TabPages[CtlTabsLayers.TabCount - 1].Text = $"Output ({OutputLayer.NeuronsCount})";

            var layers = GetHiddenLayersControls();
            for (int i = 1; i < CtlTabsLayers.TabCount - 1; ++i)
            {
                CtlTabsLayers.TabPages[i].Text = $"L{i} ({layers[i - 1].NeuronsCount})";
            }
        }

        private void CtlMenuAddLayer_Click(object sender, EventArgs e)
        {
            AddLayer(Const.UnknownId);
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
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

        private void ValidateParameters()
        {
            ValidateRandomizeParamA();
        }

        private void ValidateRandomizeParamA()
        {
            if (CtlRandomizerParamA.Text.Length != 0)
            {
                if (!double.TryParse(CtlRandomizerParamA.Text, out double result))
                {
                    throw new Exception($"Invalid network randomize parameter a value '{CtlRandomizerParamA.Text}'.");
                }
            }
        }

        public void SaveConfig()
        {
            ValidateParameters();

            Config.Set(Const.Param.Randomizer, Randomizer);
            Config.Set(Const.Param.RandomizerParamA, CtlRandomizerParamA.Text);

            InputLayer.SaveConfig();
            OutputLayer.SaveConfig();

            var layers = GetHiddenLayersControls();
            Range.ForEach(layers, l => l.SaveConfig());
            Config.Set(Const.Param.HiddenLayers, layers.Select(l => l.Id));

            //

            ResetLayersTabsNames();
        }

        public List<LayerControl> GetHiddenLayersControls()
        {
            var result = new List<LayerControl>();
            for (int i = 1; i < CtlTabsLayers.TabCount - 1; ++i)
            {
                if (CtlTabsLayers.TabPages[i].Controls[0] is LayerControl layer)
                {
                    result.Add(layer);
                }
            }
            return result;
        }

        private void LoadConfig()
        {
            // randomizer

            RandomizeMode.Helper.FillComboBox(CtlRandomizer, Config);
            CtlRandomizerParamA.Text = Config.GetString(Const.Param.RandomizerParamA);

            //

            var layers = Config.GetArray(Const.Param.HiddenLayers);
            Range.For(layers.Length, i => AddLayer(layers[i]));
        }

        public int[] GetLayersSize()
        {
            var result = new List<int>();
            var layers = GetHiddenLayersControls();
            result.Add(InputLayer.NeuronsCount);
            Range.ForEach(layers, l => result.Add(l.NeuronsCount));
            result.Add(OutputLayer.NeuronsCount);
            return result.ToArray();
        }

        public int InputNeuronsCount => InputLayer.Config.GetInt(Const.Param.InputNeuronsCount);

        private string Randomizer => CtlRandomizer.SelectedItem.ToString();
        private double? RandomizerParamA => Converter.TextToDouble(CtlRandomizerParamA.Text);

        public Type ActiveLayerType => CtlTabsLayers.SelectedTab.Controls[0].GetType();

        private void CtlMenuDeleteLayer_Click(object sender, EventArgs e)
        {
            var layerIndex = CtlTabsLayers.TabPages.IndexOf(CtlTabsLayers.SelectedTab);

            if (MessageBox.Show($"Would you really like to delete layer L{layerIndex}?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var layer = CtlTabsLayers.SelectedTab.Controls[0] as LayerControl;
                layer.VanishConfig();

                CtlTabsLayers.TabPages.Remove(CtlTabsLayers.SelectedTab);
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public NetworkDataModel CreateNetworkDataModel()
        {
            var model = new NetworkDataModel(this)
            {
                Randomizer = Randomizer,
                RandomizerParamA = RandomizerParamA
            };

            RandomizeMode.Helper.Invoke(Randomizer, model, RandomizerParamA);

            model.Layers.First().VisualId = Const.InputLayerId;

            var layers = GetHiddenLayersControls();
            for (int ln = 0; ln < layers.Count; ++ln)
            {
                model.Layers[1 + ln].VisualId = layers[ln].Id;

                var neurons = layers[ln].GetNeuronsControls();
                for (int nn = 0; nn < neurons.Count; ++nn)
                {
                    var neuronModel = model.Layers[1 + ln].Neurons[nn];
                    neuronModel.VisualId = neurons[nn].Id;
                    neuronModel.WeightsInitializer = neurons[nn].WeightsInitializer;
                    neuronModel.WeightsInitializerParamA = neurons[nn].WeightsInitializerParamA;

                    double initValue = InitializeMode.Helper.Invoke(neurons[nn].WeightsInitializer, neurons[nn].WeightsInitializerParamA);
                    if (initValue != Const.InitializerSkipValue)
                    {
                        foreach (var weight in neuronModel.Weights)
                        {
                            weight.Weight = InitializeMode.Helper.Invoke(neurons[nn].WeightsInitializer, neurons[nn].WeightsInitializerParamA);
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
