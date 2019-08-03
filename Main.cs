﻿using NN;
using NN.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN
{
    public partial class Main : Form
    {
        Thread WorkThread;
        CancellationToken CancellationToken;
        CancellationTokenSource CancellationTokenSource;
        public static object ApplyChangesLocker = new object();

        NetworksManager NetworksManager;

        DateTime StartTime;
        long Round;

        //Label CtlAutoSize;

        public Main()
        {
            InitializeComponent();
            Load += Main_Load;

            Resize += Main_Resize;
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //Update();

            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Config.Main.Clear();
            CreateDirectories();

            CtlNetworkPresenter.SizeChanged += NetworkPresenter_SizeChanged;

            LoadConfig();
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            if (NetworksManager != null)
            {
                //NetworksManager.SelectedNetwork.ResizeBegin();
            }

            //CtlManagerPanel.SuspendLayout();
            //CtlBottomPanel.SuspendLayout();
            CtlInputDataPresenter.SuspendLayout();
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            if (NetworksManager != null)
            {
                //NetworksManager.SelectedNetwork.ResizeEnd();
            }

            //CtlManagerPanel.ResumeLayout();
            //CtlBottomPanel.ResumeLayout();
            CtlInputDataPresenter.ResumeLayout();
            base.OnResizeEnd(e);

            Width = 16 * Height / 9;
        }

        private void NetworkPresenter_SizeChanged(object sender, EventArgs e)
        {
            CtlNetworkPresenter.Height = Math.Max(CtlNetworkPresenter.Height, 400);

            if (NetworksManager != null)
            {
                CtlNetworkPresenter.Dispatch(() =>
                {
                    if (IsRunning)
                        CtlNetworkPresenter.RenderRunning(NetworksManager.SelectedNetworkModel);
                    else
                        CtlNetworkPresenter.RenderStanding(NetworksManager.SelectedNetworkModel);
                });
            }
        }

        private void LoadConfig()
        {
            var name = Config.Main.GetString(Const.Param.NetworksManagerName, null);
            LoadNetworksManager(name);
            LoadSettings();
        }

        private void LoadSettings()
        {
            CtlSettings.Load(Config.Main);
            CtlSettings.Changed -= OnSettingsChanged;
            CtlSettings.Changed += OnSettingsChanged;
            CtlApplySettingsButton.Enabled = false;
            CtlCancelSettingsButton.Enabled = false;
        }

        private void OnSettingsChanged()
        {
            CtlApplySettingsButton.Enabled = true;
            CtlCancelSettingsButton.Enabled = true;
        }

        private bool SaveSettings()
        {
            if (!CtlSettings.IsValid())
            {
                MessageBox.Show("Settings parameter is invalid.", "Error");
                return false;
            }
            CtlSettings.Save(Config.Main);
            CtlApplySettingsButton.Enabled = false;
            CtlCancelSettingsButton.Enabled = false;
            return true;
        }

        private Settings Settings => CtlSettings.Settings;

        private void LoadNetworksManager(string name)
        {
            if (!StopRequest())
            {
                return;
            }

            if (String.IsNullOrEmpty(name))
            {
                return;
            }

            if (!File.Exists(name))
            {
                name = "\\Networks\\" + Path.GetFileName(name);
            }

            if (File.Exists(name))
            { 
                var manager = new NetworksManager(CtlInputDataPresenter, CtlTabs, name, OnNetworkUIChanged);
                Config.Main.Set(Const.Param.NetworksManagerName, name);
                ReplaceNetworksManagerControl(manager);
                if (manager.IsValid())
                {
                    ApplyChangesToStandingNetworks();
                }
                else
                {
                    MessageBox.Show("Network parameter is not valid.", "Error");
                }
            }
            else
            {
                MessageBox.Show($"Network '{name}' is not found!", "Error", MessageBoxButtons.OK);
                Config.Main.Set(Const.Param.NetworksManagerName, "");
            }
        }

        private bool SaveConfig()
        {
            if (!SaveSettings())
            {
                return false;
            }

            if (NetworksManager != null) 
            {
                if (!NetworksManager.IsValid())
                {
                    MessageBox.Show("Network parameter is invalid", "Error");
                    return false;
                }
                else
                {
                    NetworksManager.SaveConfig();
                }
            }
            
            return true;
        }

        private void CreateDirectories()
        {
            if (!Directory.Exists("Networks"))
            {
                Directory.CreateDirectory("Networks");
            }
        }

        private void ToggleApplyChanges(Const.Toggle state)
        {
            if (state == Const.Toggle.On)
            {
                CtlApplyChanges.BackColor = Color.Yellow;
                CtlApplyChanges.Enabled = true;
            }
            else
            {
                CtlApplyChanges.BackColor = Color.FromKnownColor(KnownColor.Control);
                CtlApplyChanges.Enabled = false;
            }
        }

        private void OnNetworkUIChanged(Notification.ParameterChanged param, object newValue = null) 
        {
            ToggleApplyChanges(Const.Toggle.On);
            CtlMenuStart.Enabled = false;

            if (param == Notification.ParameterChanged.NeuronsCount)
            {
                if (NetworksManager != null)
                {
                    NetworksManager.ResetLayersTabsNames();
                }
            }
        }

        private void ApplyChangesToRunningNetworks()
        {
            lock (ApplyChangesLocker)
            {
                CtlInputDataPresenter.RearrangeWithNewPointsCount();
                var newModels = NetworksManager.CreateNetworksDataModels();
                NetworksManager.MergeModels(newModels);
                CtlNetworkPresenter.RenderRunning(NetworksManager.SelectedNetworkModel);
                ToggleApplyChanges(Const.Toggle.Off);
            }
        }

        private void ApplyChangesToStandingNetworks()
        {
            lock (ApplyChangesLocker)
            {
                CtlInputDataPresenter.RearrangeWithNewPointsCount();
                NetworksManager.RefreshNetworksDataModels();
                CtlNetworkPresenter.RenderStanding(NetworksManager.SelectedNetworkModel);
                ToggleApplyChanges(Const.Toggle.Off);
                CtlMenuStart.Enabled = true;
            }
        }

        private bool IsRunning => CtlMenuStop.Enabled;

        private void CtlStart_Click(object sender, EventArgs e)
        {
            if (SaveConfig())
            {
                ApplyChangesToStandingNetworks();

                CancellationTokenSource = new CancellationTokenSource();
                CancellationToken = CancellationTokenSource.Token;

                CtlMenuStart.Enabled = false;
                CtlMenuReset.Enabled = false;
                CtlMenuStop.Enabled = true;
                CtlMenuDeleteNetwork.Enabled = false;
                
                NetworksManager.PrepareModelsForRun();

                NetworksManager.PrepareModelsForRound();
                CtlInputDataPresenter.SetInputDataAndDraw(NetworksManager.Models.First());
                NetworksManager.FeedForward(); // initialize state

                Round = 0;
                StartTime = DateTime.Now;

                DrawModels(NetworksManager.Models);

                WorkThread = new Thread(new ThreadStart(RunNetwork));
                WorkThread.Priority = ThreadPriority.Highest;
                WorkThread.Start();
            }
        }

        private void RunNetwork()
        {
            DateTime prevTime = DateTime.Now;

            while (!CancellationToken.IsCancellationRequested)
            {
                lock (ApplyChangesLocker)
                {
                    NetworksManager.PrepareModelsForRound();

                    foreach (var model in NetworksManager.Models)
                    {
                        model.FeedForward();

                        var output = model.GetMaxActivatedOutputNeuron();
                        var input = model.GetNumberOfFirstLayerActiveNeurons();
                        var cost = model.Cost(input);
                        if (input == output.Id)
                        {
                            ++model.Statistic.CorrectRounds;

                            model.Statistic.LastGoodInput = input;
                            model.Statistic.LastGoodOutput = output.Id;
                            model.Statistic.LastGoodOutputActivation = output.Activation;
                            model.Statistic.LastGoodCost = cost;
                        }
                        else
                        {
                            model.Statistic.LastBadInput = input;
                            model.Statistic.LastBadOutput = output.Id;
                            model.Statistic.LastBadOutputActivation = output.Activation;
                            model.Statistic.LastBadCost = cost;
                        }

                        model.ErrorMatrix.AddData(input, output.Id);

                        ++model.Statistic.Rounds;

                        model.BackPropagation(input);

                        if (model.Statistic.Rounds == 1)
                        {
                            model.Statistic.AverageCost = cost;
                        }
                        else
                        {
                            model.Statistic.AverageCost = (model.Statistic.AverageCost * (model.Statistic.Rounds - 1) + cost) / model.Statistic.Rounds;
                        }
                    }

                    ++Round;
                }

                if (NetworksManager.Models[0].ErrorMatrix.Count % Settings.SkipRoundsToDrawErrorMatrix == 0)
                {
                    using (var ev = new AutoResetEvent(false))
                    {
                        BeginInvoke((Action)(() =>
                        {
                            CtlMatrixPresenter.Draw(NetworksManager.Models, NetworksManager.SelectedNetworkModel);
                            NetworksManager.ResetErrorMatrix();
                            ev.Set();
                        }));
                        ev.WaitOne();
                    };
                }
                
                if (Round % Settings.SkipRoundsToDrawNetworks == 0)// || DateTime.Now.Subtract(startTime).TotalSeconds >= 10)
                {
                    using (var ev = new AutoResetEvent(false))
                    {
                        BeginInvoke((Action)(() =>
                        {
                            try
                            {
                                lock (ApplyChangesLocker)
                                {
                                    DrawModels(NetworksManager.Models);
                                }
                            }
                            catch (Exception ex)
                            {
                                int hha = 1;
                            }

                            ev.Set();
                        }));

                        ev.WaitOne();
                    };
                }
                
                if ((long)DateTime.Now.Subtract(prevTime).TotalSeconds >= 1)
                {
                    prevTime = DateTime.Now;
                    BeginInvoke((Action)(() => CtlTime.Text = "Time: " + DateTime.Now.Subtract(StartTime).ToString(@"hh\:mm\:ss")));
                }
            }
        }

        private void DrawModels(List<NetworkDataModel> models)
        {
            var renderStart = DateTime.Now;

            CtlNetworkPresenter.RenderRunning(NetworksManager.SelectedNetworkModel);
            CtlInputDataPresenter.SetInputDataAndDraw(NetworksManager.Models.First());

            foreach (var model in models)
            {
                model.DynamicStatistic.Add(model.Statistic.Percent, model.Statistic.AverageCost);
            }

            CtlPlotPresenter.Draw(models, NetworksManager.SelectedNetworkModel);

            var selected = NetworksManager.SelectedNetworkModel;

            if (selected == null)
            {
                CtlStatisticsPresenter.Draw(null);
            }
            else
            {
                var stat = new Dictionary<string, string>();
                var span = DateTime.Now.Subtract(StartTime);
                stat.Add("Time", new DateTime(span.Ticks).ToString(@"HH\:mm\:ss"));

                if (selected.Statistic.Percent > 0)
                {
                    var remains = new DateTime((long)(span.Ticks * 100 / selected.Statistic.Percent) - span.Ticks);
                    stat.Add("Time remaining", new DateTime(remains.Ticks).ToString(@"HH\:mm\:ss"));
                }
                else
                {
                    stat.Add("Time remaining", "N/A");
                }

                if (selected.Statistic.LastGoodOutput > -1)
                {
                    stat.Add("Last good output", $"{selected.Statistic.LastGoodInput}={selected.Statistic.LastGoodOutput} ({Converter.DoubleToText(100 * selected.Statistic.LastGoodOutputActivation, "N6")}%)");
                    stat.Add("Last good cost", Converter.DoubleToText(selected.Statistic.LastGoodCost, "N6"));

                }
                else
                {
                    stat.Add("Last good output", "none");
                    stat.Add("Last good cost", "none");
                }

                if (selected.Statistic.LastBadOutput > -1)
                {
                    stat.Add("Last bad output", $"{selected.Statistic.LastBadInput}={selected.Statistic.LastBadOutput} ({Converter.DoubleToText(100 * selected.Statistic.LastBadOutputActivation, "N6")}%)");
                    stat.Add("Last bad cost", Converter.DoubleToText(selected.Statistic.LastBadCost, "N6"));
                }
                else
                {
                    stat.Add("Last bad output", "none");
                    stat.Add("Last bad cost", "none");
                }

                stat.Add("Average cost", Converter.DoubleToText(selected.Statistic.AverageCost, "N6"));
                stat.Add("Percent", Converter.DoubleToText(selected.Statistic.Percent, "N6") + " %");
                stat.Add("Learning rate", Converter.DoubleToText(selected.LearningRate));
                stat.Add("Rounds", Round.ToString());
                stat.Add("Rounds/sec", ((int)((double)Round / DateTime.Now.Subtract(StartTime).TotalSeconds)).ToString());

                var renderStop = DateTime.Now;

                stat.Add("Render time, msec", ((int)(renderStop.Subtract(renderStart).TotalMilliseconds)).ToString());
                CtlStatisticsPresenter.Draw(stat);
            }
            
            NetworksManager.ResetModelsStatistic();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StopRequest())
            {
                try
                {
                    SaveConfig();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void CtlMenuNew_Click(object sender, EventArgs e)
        {
            CreateNetworksManager();
        }

        private void CtlMenuLoad_Click(object sender, EventArgs e)
        {
            LoadNetworksManager();
        }

        private void CtlMenuDeleteNetwork_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you really like to delete the network?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DeleteNetworksManager();
            }
        }

        private bool StopRequest()
        {
            if (!IsRunning)
            {
                return true;
            }

            WorkThread.Priority = ThreadPriority.Lowest;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            if (MessageBox.Show("Would you like to stop the network?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                StopRunning();
                return true;
            }

            return false;
        }

        private void CreateNetworksManager()
        {
            if (!StopRequest())
            {
                return;
            }

            var network = new NetworksManager(CtlInputDataPresenter, CtlTabs, null, OnNetworkUIChanged);
            if (network.Config != null)
            {
                ReplaceNetworksManagerControl(network);
                if (network.IsValid())
                {
                    ApplyChangesToStandingNetworks();
                }
                else
                {
                    MessageBox.Show("Network parameter is not valid.", "Error");
                }
            }
        }

        private void LoadNetworksManager()
        {
            if (!StopRequest())
            {
                return;
            }

            using (var loadDialog = new OpenFileDialog
            {
                InitialDirectory = Path.GetFullPath("Networks\\"),
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            })
            {
                if (loadDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadNetworksManager(loadDialog.FileName);
                }
            }
        }

        private void DeleteNetworksManager()
        {
            var name = Config.Main.GetString(Const.Param.NetworksManagerName);
            if (!String.IsNullOrEmpty(name))
            {
                if (!File.Exists(name))
                {
                    name = "\\Networks\\" + Path.GetFileName(name);
                }

                if (File.Exists(name))
                {
                    File.Delete(name);
                }

                ReplaceNetworksManagerControl(null);
            }
        }

        private void ReplaceNetworksManagerControl(NetworksManager manager)
        {
            NetworksManager = manager;

            if (manager == null)
            {               
                Text = "Neural Network";

                CtlMenuStart.Enabled = false;
                CtlMenuReset.Enabled = false;
                CtlMainMenuSaveAs.Enabled = false;
                CtlMenuNetwork.Enabled = false;
                CtlNetworkContextMenu.Enabled = false;  
            }
            else
            {
                Text = "Neural Network | " + Path.GetFileNameWithoutExtension(Config.Main.GetString(Const.Param.NetworksManagerName));

                CtlMenuStart.Enabled = true;
                CtlMenuReset.Enabled = true;
                CtlMainMenuSaveAs.Enabled = true;
                CtlMenuNetwork.Enabled = true;
                CtlNetworkContextMenu.Enabled = true;
            }

            OnNetworkUIChanged(Notification.ParameterChanged.Structure);
        }

        private void CtlStop_Click(object sender, EventArgs e)
        {
            StopRunning();
        }

        private void StopRunning()
        {
            CancellationTokenSource.Cancel();
            if (WorkThread != null)
            {
                WorkThread.Join();
                WorkThread = null;
            }

            CtlMenuStart.Enabled = true;
            CtlMenuStop.Enabled = false;
            CtlMenuReset.Enabled = true;
        }

        private void CtlReset_Click(object sender, EventArgs e)
        {
            ApplyChangesToStandingNetworks();
        }

        private void CtlApplyChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }

            if (IsRunning)
            {
                if (MessageBox.Show("Would you like running network to apply changes?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ApplyChangesToRunningNetworks();
                }
            }
            else
            {
                if (MessageBox.Show("Would you like network to apply changes?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ApplyChangesToStandingNetworks();
                    //LoadConfig(); 
                }
            }
        }

        private void CtlMainMenuSaveAs_Click(object sender, EventArgs e)
        {
            if (SaveConfig())
            {
                NetworksManager.SaveAs();
            }
        }

        private void CtlApplySettingsButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void CtlCancelSettingsButton_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void CtlTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // newly selected network must not affect NetworksManager until it saved

            if (NetworksManager != null)
            {
                if (IsRunning)
                {
                    lock (ApplyChangesLocker)
                    {
                        CtlInputDataPresenter.SetInputDataAndDraw(NetworksManager.Models.First());
                        CtlNetworkPresenter.RenderRunning(NetworksManager.SelectedNetworkModel);
                        CtlPlotPresenter.Draw(NetworksManager.Models, NetworksManager.SelectedNetworkModel);
                        CtlStatisticsPresenter.Draw(null);
                    }
                }
                else
                {
                    CtlNetworkPresenter.RenderStanding(NetworksManager.SelectedNetworkModel);
                }
            }
        }

        private void CtlMainMenuAddNetwork_Click(object sender, EventArgs e)
        {
            NetworksManager.AddNetwork();
            ApplyChangesToStandingNetworks();
        }

        private void CtlMainMenuDeleteNetwork_Click(object sender, EventArgs e)
        {
            NetworksManager.DeleteNetwork();
        }

        private void CtlMainMenuAddLayer_Click(object sender, EventArgs e)
        {
            NetworksManager.SelectedNetwork.AddLayer();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlMainMenuDeleteLayer_Click(object sender, EventArgs e)
        {
            NetworksManager.SelectedNetwork.DeleteLayer();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void CtlMainMenuAddNeuron_Click(object sender, EventArgs e)
        {
            NetworksManager.SelectedNetwork.SelectedLayer.AddNeuron();
        }

        private void CtlMenuNetwork_Click(object sender, EventArgs e)
        {
            CtlMainMenuDeleteNetwork.Enabled = CtlTabs.SelectedIndex > 0;
            CtlMainMenuAddLayer.Enabled = CtlTabs.SelectedIndex > 0;
            CtlMainMenuDeleteLayer.Enabled = CtlTabs.SelectedIndex > 0 && (CtlTabs.SelectedTab.Controls[0] as NetworkControl).IsSelectedLayerHidden;
            CtlMainMenuAddNeuron.Enabled = CtlTabs.SelectedIndex > 0;    
        }

        private void CtlNetworkContextMenu_Opening(object sender, CancelEventArgs e)
        {
            CtlMenuDeleteNetwork.Enabled = CtlTabs.SelectedIndex > 0;
        }
    }
}
