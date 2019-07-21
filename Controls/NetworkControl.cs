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

namespace Dots.Controls
{
    public partial class NetworkControl : UserControl
    {
        public Config Config;

        public NetworkControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void AddLayer()
        {
            int id = CtlTabsLayers.TabCount - 1;
            var name = "L1" + id;
            var layer = new LayerControl(id, Config) { Dock = DockStyle.Fill };
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
                var saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = Path.GetFullPath("Networks\\");
                saveDialog.DefaultExt = "txt";
                saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                saveDialog.RestoreDirectory = true;

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

            Config.Set(Config.Param.Randomizer, CtlRandomizer.SelectedValue.ToString());
            Config.Set(Config.Param.LayersCount, CtlTabsLayers.TabCount - 2);
            for (int i = 1; i < CtlTabsLayers.TabCount - 1; ++i)
            {
                var layer = CtlTabsLayers.TabPages[i].Controls[0] as LayerControl;
                if (layer != null)
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
            var randomizers = typeof(RandomizeMode).GetMethods().Where(r => r.IsStatic).ToArray();
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
                CtlRandomizer.SelectedValue = randomizer;
            }

            //

            CtlInputLayerControl.LoadConfig(Config);

            //

            int layersCount = Config.GetInt(Config.Param.LayersCount, 0);
            for (int i = 0; i < layersCount; ++i)
            {
                AddLayer();
            }
        }
    }


}
