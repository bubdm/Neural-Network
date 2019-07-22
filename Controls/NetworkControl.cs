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
        }

        private void CtlTabsLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlMenuDeleteLayer.Enabled = CtlTabsLayers.SelectedIndex > 0 && CtlTabsLayers.SelectedIndex < CtlTabsLayers.TabCount - 2;
        }

        private void AddLayer(long id)
        {
            id = id == -1 ? DateTime.Now.Ticks : id;
            var layer = new LayerControl(id, NetworkConfig, OnNetworkUIChanged);
            var tab = new TabPage();
            tab.Controls.Add(layer);
            CtlTabsLayers.TabPages.Insert(CtlTabsLayers.TabCount - 1, tab);
            ResetLayersNames();
            CtlTabsLayers.SelectedTab = tab;
        }

        private void ResetLayersNames()
        {
            for (int i = 1; i < CtlTabsLayers.TabCount - 1; ++i)
            {
                CtlTabsLayers.TabPages[i].Text = "L" + i;
            }
        }

        private void CtlMenuAddLayer_Click(object sender, EventArgs e)
        {
            AddLayer(-1);
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
                config.Set(Config.Param.NetworkName, saveDialog.FileName);
                return config;
            }
 
            return null;
         }

        public Config SaveConfig()
        {
            NetworkConfig.Set(Config.Param.Randomizer, CtlRandomizer.SelectedItem.ToString());

            (CtlTabsLayers.TabPages[0].Controls[0] as InputLayerControl).SaveConfig();
            (CtlTabsLayers.TabPages[CtlTabsLayers.TabCount - 1].Controls[0] as OutputLayerControl).SaveConfig();

            var layers = GetHiddenLayersControls();
            Range.ForEach(layers, layer => layer.SaveConfig());
            NetworkConfig.Set(Config.Param.HiddenLayers, String.Join(",", layers.Select(l => l.Id)));

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

            CtlRandomizer.Items.Clear();
            var randomizers = Randomize.Helper.GetRandomizers();
            foreach (var rand in randomizers)
            {
                CtlRandomizer.Items.Add(rand.Name);
            }
            var randomizer = NetworkConfig.GetString(Config.Param.Randomizer, Config.Main.GetString(Config.Param.Randomizer, randomizers.Any() ? randomizers[0].Name : null));
            if (randomizers.Any())
            {
                if (!randomizers.Any(r => r.Name == randomizer))
                {
                    randomizer = randomizers[0].Name;
                }
            }
            else
            {
                randomizer = null;
            }

            if (!String.IsNullOrEmpty(randomizer))
            {
                CtlRandomizer.SelectedItem = randomizer;
            }

            var layers = NetworkConfig.GetArray(Config.Param.HiddenLayers);
            Range.For(layers.Length, i => AddLayer(layers[i]));
        }

        public int[] GetLayersSize()
        {
            var result = new List<int>();

            var layers = NetworkConfig.GetArray(Config.Param.HiddenLayers);
            result.Add(NetworkConfig.Extend(0).GetInt(Config.Param.NeuronsCount));
            Range.For(layers.Length, n => result.Add(NetworkConfig.Extend(layers[n]).GetInt(Config.Param.NeuronsCount)));
            result.Add(NetworkConfig.Extend(1).GetInt(Config.Param.OutputNeuronsCount));
            result.RemoveAll(r => r == 0);
            return result.ToArray();
        }

        public string Randomizer
        {
            get
            {
                return CtlRandomizer.SelectedItem.ToString();
            }
        }

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
    }
}
