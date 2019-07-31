using NN;
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

        NetworkDataModel NetworkModel;
        DateTime StartTime;
        long Round;

        // Visual controls

        DataControl InputDataPresenter;
        NetworkPresenter NetworkPresenter;
        PlotterPresenter PlotPresenter;
        StatisticsPresenter StatisticsPresenter;
        MatrixPresenter MatrixPresenter;

        public Main()
        {
            InitializeComponent();

            CtlDataPanel.AutoScroll = false;
            CtlDataPanel.HorizontalScroll.Maximum = 0;
            CtlDataPanel.HorizontalScroll.Enabled = false;
            CtlDataPanel.HorizontalScroll.Visible = false;
            CtlDataPanel.AutoScroll = true;

            Load += Main_Load; 
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Config.Main.Clear();
            CreateDirectories();

            InputDataPresenter = new DataControl();
            InputDataPresenter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            CtlDataPanel.Controls.Add(InputDataPresenter);

            NetworkPresenter = new NetworkPresenter();
            NetworkPresenter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            CtlNetPanel.Controls.Add(NetworkPresenter);

            PlotPresenter = new PlotterPresenter();
            PlotPresenter.Height = 200;
            PlotPresenter.Width = 200;
            PlotPresenter.Left = 0;
            PlotPresenter.Top = NetworkPresenter.Height - PlotPresenter.Height;
            CtlNetPanel.Controls.Add(PlotPresenter);
            PlotPresenter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PlotPresenter.BringToFront();

            StatisticsPresenter = new StatisticsPresenter();
            StatisticsPresenter.Height = 200;
            StatisticsPresenter.Width = 300;
            StatisticsPresenter.Left = PlotPresenter.Left + PlotPresenter.Width;
            StatisticsPresenter.Top = NetworkPresenter.Height - StatisticsPresenter.Height;
            CtlNetPanel.Controls.Add(StatisticsPresenter);
            StatisticsPresenter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StatisticsPresenter.BringToFront();

            MatrixPresenter = new MatrixPresenter();
            MatrixPresenter.Height = 200;
            MatrixPresenter.Width = 200;
            MatrixPresenter.Left = StatisticsPresenter.Left + StatisticsPresenter.Width;
            MatrixPresenter.Top = NetworkPresenter.Height - MatrixPresenter.Height;
            CtlNetPanel.Controls.Add(MatrixPresenter);
            MatrixPresenter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            MatrixPresenter.BringToFront();

            CtlTime.BringToFront();

            LoadConfig();
        }

        private void LoadConfig()
        {
            var networkName = Config.Main.GetString(Const.Param.NetworkName, null);
            LoadNetwork(networkName);
            LoadSettings();
        }

        private void LoadSettings()
        {
            CtlSettings.Load(Config.Main);
        }

        private bool SaveSettings()
        {
            if (!CtlSettings.IsValid())
            {
                MessageBox.Show("Settings parameter is invalid.", "Error");
                return false;
            }
            CtlSettings.Save(Config.Main);
            return true;
        }

        private Settings Settings => CtlSettings.Settings;

        private void LoadNetwork(string name)
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
                var network = new NetworkControl(name, OnNetworkUIChanged);
                Config.Main.Set(Const.Param.NetworkName, name);
                ReplaceNetworkControl(network);
                if (network.IsValid())
                {
                    ApplyChangesToStandingNetwork();
                }
                else
                {
                    MessageBox.Show("Network parameter is not valid.", "Error");
                }
            }
            else
            {
                MessageBox.Show($"Network '{name}' is not found!", "Error", MessageBoxButtons.OK);
            }
        }

        private bool SaveConfig()
        {
            if (!SaveSettings())
            {
                return false;
            }

            if (NetworkUI == null || !NetworkUI.IsValid())
            {
                MessageBox.Show("Network parameter is invalid", "Error");
                return false;
            }

            NetworkUI.SaveConfig();
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

            if (param == Notification.ParameterChanged.NeuronsCount)
            {
                if (NetworkUI != null)
                {
                    NetworkUI.ResetLayersTabsNames();
                }
            }
        }

        private void ApplyChangesToRunningNetwork()
        {
            lock (ApplyChangesLocker)
            {
                InputDataPresenter.RearrangeWithNewPointsCount(NetworkUI.InputNeuronsCount);
                var model = NetworkUI.CreateNetworkDataModel();
                NetworkModel = NetworkModel.Merge(model);
                NetworkPresenter.UpdateNetwork(NetworkModel);
                ToggleApplyChanges(Const.Toggle.Off);
            }
        }

        private void ApplyChangesToStandingNetwork()
        {
            lock (ApplyChangesLocker)
            {
                InputDataPresenter.RearrangeWithNewPointsCount(NetworkUI.InputNeuronsCount);
                NetworkModel = NetworkUI.CreateNetworkDataModel();
                NetworkPresenter.SetNetwork(NetworkModel);
                ToggleApplyChanges(Const.Toggle.Off);
            }
        }

        private bool IsRunning => CtlStop.Enabled;

        private void CtlStart_Click(object sender, EventArgs e)
        {
            if (SaveConfig())
            {
                ApplyChangesToStandingNetwork();

                CancellationTokenSource = new CancellationTokenSource();
                CancellationToken = CancellationTokenSource.Token;

                CtlStart.Enabled = false;
                CtlReset.Enabled = false;
                CtlStop.Enabled = true;
                CtlMenuDeleteNetwork.Enabled = false;
                NetworkPresenter.IsNetworkRunning = true;

                NetworkModel.InitState();
                PlotPresenter.ClearData();
                MatrixPresenter.ClearData();

                NetworkModel.SetInputData();
                InputDataPresenter.SetInputDataAndDraw(NetworkModel.Layers.First(), NetworkModel.InputThreshold);
                NetworkModel.FeedForward(); // initialize state

                Round = 0;
                StartTime = DateTime.Now;

                Draw(new DrawData(true));

                WorkThread = new Thread(new ThreadStart(Work));
                WorkThread.Priority = ThreadPriority.Highest;
                WorkThread.Start();
            }
        }

        private void RunNetwork()
        {
            long total = 0;
            long correct = 0;

            DateTime startTime = DateTime.Now;
            DateTime prevTime = DateTime.Now;

            ////MatrixPresenter.ClearData();
            var data = new DrawData(true);

            while (!CancellationToken.IsCancellationRequested)
            {
                lock (ApplyChangesLocker)
                {
                    NetworkModel.SetInputData();
                    NetworkModel.FeedForward();

                    var output = NetworkModel.GetMaxActivatedOutputNeuron();
                    var input = NetworkModel.GetNumberOfFirstLayerActiveNeurons();
                    var cost = NetworkModel.Cost(input);
                    if (input == output.Id)
                    {
                        ++correct;

                        data.LastGoodInput = input;
                        data.LastGoodOutput = output.Id;
                        data.LastGoodOutputActivation = output.Activation;
                        data.LastGoodCost = cost;
                    }
                    else
                    {
                        data.LastBadInput = input;
                        data.LastBadOutput = output.Id;
                        data.LastBadOutputActivation = output.Activation;
                        data.LastBadCost = cost;
                    }

                    MatrixPresenter.AddData(input, output.Id);

                    ++total;
                    ++Round;

                    NetworkModel.BackPropagation(input);

                    
                    if (total == 1)
                    {
                        data.AverageCost = cost;
                    }
                    else
                    {
                        data.AverageCost = (data.AverageCost * (total - 1) + cost) / total;
                    }
                }

                if (MatrixPresenter.Count % Settings.SkipRoundsToDrawErrorMatrix == 0)
                {
                    using (var ev = new AutoResetEvent(false))
                    {
                        BeginInvoke((Action)(() =>
                        {
                            MatrixPresenter.Draw();
                            MatrixPresenter.ClearData();
                            ev.Set();
                        }));
                        ev.WaitOne();
                    };
                }
                
                if (total == 10000 || DateTime.Now.Subtract(startTime).TotalSeconds >= 10)
                {
                    break;
                }
                
                if ((long)DateTime.Now.Subtract(prevTime).TotalSeconds >= 1)
                {
                    prevTime = DateTime.Now;
                    BeginInvoke((Action)(() => CtlTime.Text = "Time: " + DateTime.Now.Subtract(StartTime).ToString(@"hh\:mm\:ss")));
                }
            }

            if (CancellationToken.IsCancellationRequested)
            {
                return;
            }

            data.Percent = 100 * (double)correct / (double)total;

            using (var ev = new AutoResetEvent(false))
            {
                BeginInvoke((Action)(() =>
                {
                    try
                    {
                        lock (ApplyChangesLocker)
                        {
                            Draw(data);
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

        private void Draw(DrawData data)
        {
            var renderStart = DateTime.Now;

            NetworkPresenter.Render();          
            PlotPresenter.AddPointPercentData(data.Percent);
            PlotPresenter.AddPointCostData(data.AverageCost);
            PlotPresenter.Draw();
            ///MatrixPresenter.Draw();

            InputDataPresenter.SetInputDataAndDraw(NetworkModel.Layers.First(), NetworkModel.InputThreshold);

            var stat = new Dictionary<string, string>();
            var span = DateTime.Now.Subtract(StartTime);
            stat.Add("Time", new DateTime(span.Ticks).ToString(@"HH\:mm\:ss"));

            if (data.Percent > 0)
            {
                var remains = new DateTime((long)(span.Ticks * 100 / data.Percent) - span.Ticks);
                stat.Add("Time remaining", new DateTime(remains.Ticks).ToString(@"HH\:mm\:ss"));
            }
            else
            {
                stat.Add("Time remaining", "N/A");
            }

            if (data.LastGoodOutput > -1)
            {
                stat.Add("Last good output", $"{data.LastGoodInput}={data.LastGoodOutput} ({Converter.DoubleToText(100 * data.LastGoodOutputActivation, "N6")}%)");
                stat.Add("Last good cost", Converter.DoubleToText(data.LastGoodCost, "N6"));

            }
            else
            {
                stat.Add("Last good output", "none");
                stat.Add("Last good cost", "none");
            }

            if (data.LastBadOutput > -1)
            {
                stat.Add("Last bad output", $"{data.LastBadInput}={data.LastBadOutput} ({Converter.DoubleToText(100 * data.LastBadOutputActivation, "N6")}%)");
                stat.Add("Last bad cost", Converter.DoubleToText(data.LastBadCost, "N6"));
            }
            else
            {
                stat.Add("Last bad output", "none");
                stat.Add("Last bad cost", "none");
            }

            stat.Add("Average cost", Converter.DoubleToText(data.AverageCost, "N6"));
            stat.Add("Percent", Converter.DoubleToText(data.Percent, "N6") + " %");
            stat.Add("Learning rate", Converter.DoubleToText(NetworkModel.LearningRate));
            stat.Add("Rounds", Round.ToString());
            stat.Add("Rounds/sec", ((int)((double)Round / DateTime.Now.Subtract(StartTime).TotalSeconds)).ToString());

            var renderStop = DateTime.Now;

            stat.Add("Render time, msec", ((int)(renderStop.Subtract(renderStart).TotalMilliseconds)).ToString());
            StatisticsPresenter.DrawStat(stat);
        }

        private void Work()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                RunNetwork();
            }
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

        private void CtlDataPanel_SizeChanged(object sender, EventArgs e)
        {
            InputDataPresenter.RearrangeWithNewWidth(CtlDataPanel.Width);
        }

        private void CtlMenuNewNetwork_Click(object sender, EventArgs e)
        {
            CreateNetwork();
        }

        private void CtlMenuLoadNetwork_Click(object sender, EventArgs e)
        {
            LoadNetwork();
            //ToggleApplyChanges(Const.Toggle.Off);
        }

        private void CtlMenuDeleteNetwork_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you really like to delete the network?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DeleteNetwork();
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

        private void CreateNetwork()
        {
            if (!StopRequest())
            {
                return;
            }

            var network = new NetworkControl(null, OnNetworkUIChanged);
            if (network.Config != null)
            {
                ReplaceNetworkControl(network);
                //Config.Main.Set(Const.Param.NetworkName, network.Config.GetString(Const.Param.NetworkName));

                if (network.IsValid())
                {
                    ApplyChangesToStandingNetwork();
                }
                else
                {
                    MessageBox.Show("Network parameter is not valid.", "Error");
                }
            }
        }

        private void LoadNetwork()
        {
            if (!StopRequest())
            {
                return;
            }

            var loadDialog = new OpenFileDialog
            {
                InitialDirectory = Path.GetFullPath("Networks\\"),
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (loadDialog.ShowDialog() == DialogResult.OK)
            {
                LoadNetwork(loadDialog.FileName);
            }
        }

        private void DeleteNetwork()
        {
            var name = Config.Main.GetString(Const.Param.NetworkName);
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

                ReplaceNetworkControl(null);
            }
        }

        private void ReplaceNetworkControl(NetworkControl network)
        {   
            if (NetworkUI != null)
            {
                CtlTabNetwork.Controls.Remove(NetworkUI);
            }

            if (network == null)
            {
                Text = "Neural Network";
                CtlStart.Enabled = false;
                CtlMenuDeleteNetwork.Enabled = false;
                CtlMainMenuDeleteNetwork.Enabled = false;
                CtlMainMenuDeleteLayer.Enabled = false;
                CtlMainMenuAddLayer.Enabled = false;
                CtlMainMenuNewNeuron.Enabled = false;
                CtlMainMenuSaveAs.Enabled = false;
                CtlReset.Enabled = false;
            }
            else
            {
                CtlTabNetwork.Controls.Add(network);
                CtlTabs.SelectedTab = CtlTabNetwork;
                Text = "Neural Network | " + Path.GetFileNameWithoutExtension(Config.Main.GetString(Const.Param.NetworkName));
                CtlStart.Enabled = true;
                CtlReset.Enabled = true;
                CtlMenuDeleteNetwork.Enabled = true;
                CtlMainMenuDeleteNetwork.Enabled = true;
                CtlMainMenuDeleteLayer.Enabled = network.ActiveLayerType == typeof(HiddenLayerControl);
                CtlMainMenuAddLayer.Enabled = true;
                CtlMainMenuNewNeuron.Enabled = network.ActiveLayerType != typeof(InputLayerControl);
                CtlMainMenuSaveAs.Enabled = true;
            }

            OnNetworkUIChanged(Notification.ParameterChanged.Structure);
        }

        private NetworkControl NetworkUI => CtlTabNetwork.Controls.Count > 0 ? CtlTabNetwork.Controls[0] as NetworkControl : null;

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

            CtlStart.Enabled = true;
            CtlStop.Enabled = false;
            CtlReset.Enabled = true;
            CtlMenuDeleteNetwork.Enabled = true;
        }

        private void CtlReset_Click(object sender, EventArgs e)
        {
            ApplyChangesToStandingNetwork();
        }

        private void CtlApplyChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfig();
                //LoadConfig(); need to create input neurons 
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
                    ApplyChangesToRunningNetwork();
                }
            }
            else
            {
                if (MessageBox.Show("Would you like network to apply changes?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LoadConfig(); 
                }
            }
        }

        private void CtlMainMenuSaveAs_Click(object sender, EventArgs e)
        {
            if (SaveConfig())
            {
                NetworkUI.SaveAs();
            }
        }

        private void CtlMainMenuAddLayer_Click(object sender, EventArgs e)
        {

        }

        private void CtlMainMenuDeleteLayer_Click(object sender, EventArgs e)
        {

        }
    }
}
