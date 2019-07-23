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
        public Config NetworkConfig;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public NetworkControl(string name, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;
            CtlTabsLayers.SelectedIndexChanged += CtlTabsLayers_SelectedIndexChanged;

            NetworkConfig = String.IsNullOrEmpty(name) ? CreateNewNetwork() : new Config(name);
            if (NetworkConfig != null)
            {
                var inputLayer = new InputLayerControl(NetworkConfig, onNetworkUIChanged);
                CtlTabInput.Controls.Add(inputLayer);

                var outputLayer = new OutputLayerControl(NetworkConfig, onNetworkUIChanged);
                CtlTabOutput.Controls.Add(outputLayer);

                LoadConfig();
            }

            CtlRandomizer.SelectedValueChanged += CtlRandomizer_SelectedValueChanged;
        }

        private InputLayerControl InputLayer => CtlTabInput.Controls[0] as InputLayerControl;
        private OutputLayerControl OutputLayer => CtlTabOutput.Controls[0] as OutputLayerControl;


        private void CtlRandomizer_SelectedValueChanged(object sender, EventArgs e)
        {
            ResetLayersNames();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlTabsLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlMenuDeleteLayer.Enabled = CtlTabsLayers.SelectedIndex > 0 && CtlTabsLayers.SelectedIndex < CtlTabsLayers.TabCount - 1;
        }

        private void AddLayer(long id)
        {
            id = id == Const.UnknownId ? DateTime.Now.Ticks : id;
            var layer = new LayerControl(id, NetworkConfig, OnNetworkUIChanged);
            var tab = new TabPage();
            tab.Controls.Add(layer);
            CtlTabsLayers.TabPages.Insert(CtlTabsLayers.TabCount - 1, tab);
            ResetLayersNames();
            CtlTabsLayers.SelectedTab = tab;
        }

        private void ResetLayersNames()
        {

            //CtlTabsLayers.TabPages[0].Text = $"Input ({InputLayer.input})";

            for (int i = 1; i < CtlTabsLayers.TabCount - 1; ++i)
            {
                CtlTabsLayers.TabPages[i].Text = "L" + i;
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
                config.Set(Const.Param.NetworkName, saveDialog.FileName);
                return config;
            }
 
            return null;
         }

        public Config SaveConfig()
        {
            NetworkConfig.Set(Const.Param.Randomizer, Randomizer);
            NetworkConfig.Set(Const.Param.RandomizerParamA, CtlRandomizerParamA.Text);

            InputLayer.SaveConfig();
            OutputLayer.SaveConfig();

            var layers = GetHiddenLayersControls();
            Range.ForEach(layers, layer => layer.SaveConfig());
            NetworkConfig.Set(Const.Param.HiddenLayers, layers.Select(l => l.Id));

            return NetworkConfig;
        }

        private List<LayerControl> GetHiddenLayersControls()
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

            RandomizeMode.Helper.FillComboBox(CtlRandomizer, NetworkConfig);
            CtlRandomizerParamA.Text = NetworkConfig.GetString(Const.Param.RandomizerParamA, "1");

            //

            var layers = NetworkConfig.GetArray(Const.Param.HiddenLayers);
            Range.For(layers.Length, i => AddLayer(layers[i]));
        }

        private int[] GetLayersSize(bool includeEmptyLayers)
        {
            var result = new List<int>();
            var layers = NetworkConfig.GetArray(Const.Param.HiddenLayers);
            result.Add(NetworkConfig.Extend(Const.InputLayerId).GetInt(Const.Param.InputNeuronsCount));
            Range.For(layers.Length, n => result.Add(NetworkConfig.Extend(layers[n]).GetArray(Const.Param.Neurons).Length));
            result.Add(NetworkConfig.Extend(Const.OutputLayerId).GetArray(Const.Param.Neurons).Length);
            if (!includeEmptyLayers)
            {
                result.RemoveAll(r => r == 0);
            }
            return result.ToArray();
        }

        private int[] GetLayersSizeIncludeEmpty()
        {
            return GetLayersSize(true);
        }

        private int[] GetLayersSizeExcludeEmpty()
        {
            return GetLayersSize(false);
        }

        public int InputNeuronsCount => NetworkConfig.Extend(Const.InputLayerId).GetInt(Const.Param.InputNeuronsCount);

        public string Randomizer => CtlRandomizer.SelectedItem.ToString();
        public double RandomizerParamA => double.TryParse(CtlRandomizerParamA.Text, out double a) ? a : 0;

        private void CtlMenuDeleteLayer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you really like to delete the layer?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var layer = CtlTabsLayers.SelectedTab.Controls[0] as LayerControl;
                layer.VanishConfig();

                CtlTabsLayers.TabPages.Remove(CtlTabsLayers.SelectedTab);
                ResetLayersNames();
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public NetworkDataModel CreateNetworkDataModel()
        {
            var model = new NetworkDataModel(GetLayersSizeExcludeEmpty());

            model.Layers.First().VisualId = Const.InputLayerId;

            var layers = GetHiddenLayersControls();
            for (int ln = 0; ln < layers.Count; ++ln)
            {
                model.Layers[1 + ln].VisualId = layers[ln].Id;

                var neurons = layers[ln].GetNeuronsControls();
                for (int nn = 0; nn < neurons.Count; ++nn)
                {
                    model.Layers[1 + ln].Neurons[nn].VisualId = neurons[nn].Id;
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
