using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    public class NetworksManager
    {
        public readonly Config Config;
        public List<NetworkDataModel> Models = new List<NetworkDataModel>();

        List<NetworkControl> Networks = new List<NetworkControl>();
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        readonly TabControl Tabs;

        public NetworksManager(TabControl tabs, string name, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            OnNetworkUIChanged = onNetworkUIChanged;
            Tabs = tabs;

            Config = String.IsNullOrEmpty(name) ? CreateNewManager() : new Config(name);
            if (Config != null)
            {
                LoadConfig();
            }
        }

        public int InputNeuronsCount => Networks.First().InputLayer.GetNeuronsControls().Where(c => !c.IsBias).Count();

        public NetworkDataModel GetSelectedNetworkModel(TabControl tab)
        {
            if (tab.SelectedIndex > 0) // not Settings
            {
                var network = tab.SelectedTab.Controls[0] as NetworkControl;
                if (Networks.IndexOf(network) > -1)
                {
                    return Models[Networks.IndexOf(network)];
                }
            }
            return null; // new unsaved network
        }

        public Config CreateNewManager()
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
                Config.Main.Set(Const.Param.NetworksManagerName, saveDialog.FileName);
                return config;
            }

            return null;
        }

        public void InitNetworkTabs()
        {
            while (Tabs.TabCount > 1)
            {
                Tabs.TabPages.RemoveAt(1);
            }

            foreach (var network in Networks)
            {
                var tab = new TabPage($"Network {Tabs.TabCount}");
                tab.Controls.Add(network);
                Tabs.TabPages.Add(tab);
            }
            Tabs.SelectedIndex = Config.GetInt(Const.Param.SelectedNetworkIndex, 0).Value + 1;
        }

        private void LoadConfig()
        {
            var networks = Config.GetArray(Const.Param.Networks);
            if (networks.Length == 0)
            {
                networks = new long[] { Const.UnknownId };
            }
            Range.For(networks.Length, i => AddNetwork(networks[i]));
        }

        public void AddNetwork()
        {
            AddNetwork(Const.UnknownId);
        }

        private void AddNetwork(long id)
        {
            var network = new NetworkControl(id, Config, OnNetworkUIChanged);
            Networks.Add(network);
            //Models.Add(network.CreateNetworkDataModel());

            var tab = new TabPage($"Network {Tabs.TabCount}");
            tab.Controls.Add(network);
            Tabs.TabPages.Add(tab);
        }

        public bool IsValid()
        {
            return !Networks.Any() || Networks.All(n => n.IsValid());
        }

        public void SaveConfig()
        {
            Config.Set(Const.Param.Networks, Networks.Select(l => l.Id));
            Config.Set(Const.Param.SelectedNetworkIndex, Tabs.SelectedIndex - 1);
            for (int i = 1; i < Tabs.TabCount; ++i)
            {
                var network = Tabs.TabPages[i].Controls[0] as NetworkControl;
                network.SaveConfig();
                //Range.ForEach(Networks, n => n.SaveConfig());
            }
        }

        public void ResetLayersTabsNames()
        {
            Range.ForEach(Networks, n => n.ResetLayersTabsNames());
        }

        public void SaveAs()
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

                File.Copy(Config.Main.GetString(Const.Param.NetworksManagerName), saveDialog.FileName);
            }
        }

        public List<NetworkDataModel> CreateNetworksDataModels()
        {
            Models.Clear();
            Range.ForEach(Networks, n => Models.Add(n.CreateNetworkDataModel()));
            return Models;
        }

        public void MergeModels(List<NetworkDataModel> models)
        {
            var newModels = new List<NetworkDataModel>();

            foreach (var newModel in models)
            {
                var model = Models.Find(m => m.VisualId == newModel.VisualId);
                if (model != null)
                {
                    newModels.Add(model.Merge(newModel));
                }
                else
                {
                    newModels.Add(newModel);
                }
            }

            Models = newModels;
        }

        public void PrepareModelsForRun()
        {
            Range.ForEach(Models, m => m.InitState());
            ResetModelsDynamicStatistic();
            ResetModelsStatistic();
        }

        public void PrepareModelsForRound()
        {
            foreach (var model in Models)
            {
                Range.ForEach(model.Layers.First().Neurons.Where(n => !n.IsBias), n => n.Activation = model.InputInitial0);
                if (model == Models.First())
                {
                    Range.For(Rand.Flat.Next(11), i => model.Layers.First().Neurons.RandomElementTrimEnd(model.Layers.First().BiasCount).Activation = model.InputInitial1);
                }
            }

            foreach (var model in Models)
            {
                if (model != Models.First())
                {
                    foreach (var neuron in model.Layers.First().Neurons.Where(n => !n.IsBias))
                    {
                        neuron.Activation = Models.First().Layers.First().Neurons[neuron.Id].Activation;
                    }
                }
            }
        }

        public void FeedForward()
        {
            Range.ForEach(Models, m => m.FeedForward());
        }

        public void ResetModelsStatistic()
        {
            Range.ForEach(Models, m => m.Statistic = new Statistic(true));
        }

        private void ResetModelsDynamicStatistic()
        {
            Range.ForEach(Models, m => m.DynamicStatistic = new DynamicStatistic());
        }
    }
}
