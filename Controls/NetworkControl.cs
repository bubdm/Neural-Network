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
        public Config Config;

        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public NetworkControl(string name, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;
            Dock = DockStyle.Fill;

            Config = String.IsNullOrEmpty(name) ? SaveConfig() : new Config(name);
            if (Config != null)
            {
                var inputLayer = new InputLayerControl(Config);
                CtlTabInput.Controls.Add(inputLayer);
                LoadConfig();
            }
        }

        private void AddLayer()
        {
            int id = CtlTabsLayers.TabCount - 1;
            var name = "L" + id;
            var layer = new LayerControl(id, Config, OnNetworkUIChanged);
            var page = new TabPage(name);
            page.Controls.Add(layer);
            CtlTabsLayers.TabPages.Insert(CtlTabsLayers.TabCount - 1, page);
            CtlTabsLayers.SelectedTab = page;
        }

        private void CtlMenuAddLayer_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        public Config SaveConfig()
        {
            if (Config == null)
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
                    var name = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                    Config = new Config(saveDialog.FileName);
                    Config.Set(Config.Param.NetworkName, saveDialog.FileName);
                    LoadConfig(); // initialize all values
                }
                else
                {
                    return null;
                }
            }

            Config.Set(Config.Param.Randomizer, CtlRandomizer.SelectedItem.ToString());
            Config.Set(Config.Param.HiddenLayersCount, CtlTabsLayers.TabCount - 2);
            for (int i = 1; i < CtlTabsLayers.TabCount - 1; ++i)
            {
                if (CtlTabsLayers.TabPages[i].Controls[0] is LayerControl layer)
                {
                    layer.SaveConfig();
                }
            }

            return Config;
        }

        public void LoadConfig()
        {
            // randomizer

            CtlRandomizer.Items.Clear();
            var randomizers = Randomize.Helper.GetRandomizers();
            foreach (var rand in randomizers)
            {
                CtlRandomizer.Items.Add(rand.Name);
            }
            var randomizer = Config.GetString(Config.Param.Randomizer, Config.Main.GetString(Config.Param.Randomizer, randomizers.Any() ? randomizers[0].Name : null));
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

            //

            //CtlInputLayerControl.LoadConfig(Config);

            //

            int layersCount = Config.GetInt(Config.Param.HiddenLayersCount, 0);
            for (int i = 0; i < layersCount; ++i)
            {
                AddLayer();
            }
        }

        public int[] GetLayersSize()
        {
            int layersCount = Config.GetInt(Config.Param.HiddenLayersCount, 0);
            var result = new int[layersCount + 2]; // +2 = input + output
            result[0] = (CtlTabInput.Controls[0] as InputLayerControl).NeuronsCount;
            result[result.Length - 1] = Config.GetInt(Config.Param.OutputNeuronsCount, Config.Main.GetInt(Config.Param.OutputNeuronsCount, 10));

            for (int i = 1; i < layersCount - 1; ++i)
            {
                result[i] = Config.Extend(i.ToString()).GetInt(Config.Param.NeuronsCount, 0);
            }

            return result;
        }

        public string Randomizer
        {
            get
            {
                return CtlRandomizer.SelectedItem.ToString();
            }
        }
    }


}
