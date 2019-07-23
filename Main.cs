using Dots;
using Dots.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        object ApplyChangesLocker = new object();

        NetworkDataModel NetworkModel;
        DateTime StartTime;
        long Round;

        // Visual controls

        DataControl InputDataPresenter;
        NetworkPresenter NetworkPresenter;
        PlotterPresenter PlotPresenter;
        StatisticsPresenter StatisticsPresenter;

        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Config.Main.Clear();
            CreateDirectories();

            InputDataPresenter = new DataControl();
            InputDataPresenter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            CtlDataPanel.Controls.Add(InputDataPresenter);

            NetworkPresenter = new NetworkPresenter();
            NetworkPresenter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            CtlNetPanel.Controls.Add(NetworkPresenter);
            CtlTime.SizeChanged += CtlTime_SizeChanged;

            PlotPresenter = new PlotterPresenter();
            PlotPresenter.Height = 200;
            PlotPresenter.Width = 200;
            PlotPresenter.Left = 0;
            PlotPresenter.Top = NetworkPresenter.Height - PlotPresenter.Height;
            CtlNetPanel.Controls.Add(PlotPresenter);
            PlotPresenter.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            PlotPresenter.BringToFront();

            StatisticsPresenter = new StatisticsPresenter();
            StatisticsPresenter.Height = 200;
            StatisticsPresenter.Width = 250;
            StatisticsPresenter.Left = PlotPresenter.Left + PlotPresenter.Width;
            StatisticsPresenter.Top = NetworkPresenter.Height - StatisticsPresenter.Top;
            CtlNetPanel.Controls.Add(StatisticsPresenter);
            StatisticsPresenter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StatisticsPresenter.BringToFront();

            LoadConfig();
        }

        private void LoadConfig()
        {
            var networkName = Config.Main.GetString(Const.Param.NetworkName, null);
            LoadNetwork(networkName);
        }

        private void LoadNetwork(string name)
        {
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
                ReplaceNetworkControl(network);
            }
            else
            {
                MessageBox.Show($"Network '{name}' is not found!", "Error", MessageBoxButtons.OK);
            }
        }

        private void SaveConfig()
        {
            if (NetworkUI != null)
            {
                NetworkUI.SaveConfig();
            }
        }

        private void CreateDirectories()
        {
            if (!Directory.Exists("Networks"))
            {
                Directory.CreateDirectory("Networks");
            }
        }

        private void CtlTime_SizeChanged(object sender, EventArgs e)
        {
            CtlTime.Left = CtlNetPanel.Width - CtlTime.Width;
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
            SaveConfig();

            if (param == Notification.ParameterChanged.Structure)
            {
                ToggleApplyChanges(Const.Toggle.On);
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
            }
        }

        private void ApplyChangesToStandingNetwork()
        {
            lock (ApplyChangesLocker)
            {
                InputDataPresenter.RearrangeWithNewPointsCount(NetworkUI.InputNeuronsCount);
                NetworkModel = NetworkUI.CreateNetworkDataModel();
                NetworkModel.RandomizeWeights(NetworkUI.Randomizer, NetworkUI.RandomizerParamA);
                NetworkPresenter.SetNetwork(NetworkModel);
            }
        }

        private bool IsRunning => CtlStop.Enabled;

        private void RunNetwork()
        {
            long total = 0;
            long correct = 0;

            DateTime startTime = DateTime.Now;
            DateTime prevTime = DateTime.Now;

            while (!CancellationToken.IsCancellationRequested)
            {
                lock (ApplyChangesLocker)
                {
                    NetworkModel.FeedForward();

                    var max = NetworkModel.GetMaxActivatedNeuron();
                    var number = NetworkModel.Layers.First().Neurons.Sum(neuron => neuron.Activation);
                    if (number == max.Id)
                    {
                        ++correct;
                    }
                    ++total;
                    ++Round;

                    NetworkModel.BackPropagation();
                }

                if (DateTime.Now.Subtract(startTime).TotalSeconds >= 10)
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

            var ev = new AutoResetEvent(false);

            BeginInvoke((Action)(() =>
            {
                try
                {
                    lock (ApplyChangesLocker)
                    {
                        Draw(100 * (double)correct / total);
                    }
                }
                catch (Exception ex)
                {
                    int a =1;
                }

                ev.Set();
            }));

            ev.WaitOne();
        }

        private void CtlStart_Click(object sender, EventArgs e)
        {
            NetworkUI.SaveConfig();

            CtlStart.Enabled = false;
            CtlReset.Enabled = false;
            CtlStop.Enabled = true;
            CtlMenuDeleteNetwork.Enabled = false;
            NetworkPresenter.IsNetworkRunning = true;

            NetworkModel.RandomizeWeights(NetworkUI.Randomizer, NetworkUI.RandomizerParamA);
            NetworkModel.FeedForward(); // initialize state

            Round = 0;
            StartTime = DateTime.Now;

            Draw(0);

            CancellationToken = CancellationTokenSource.Token;

            var ts = new ThreadStart(Work);
            WorkThread = new Thread(ts);
            WorkThread.Start();
        }

        private void Draw(double percent)
        {
            InputDataPresenter.SetInputData(NetworkModel.Layers.First());

            var renderStart = DateTime.Now;
            NetworkPresenter.Render();
            var renderStop = DateTime.Now;
            PlotPresenter.AddPoint(percent);

            var number = NetworkModel.Layers.First().Neurons.Sum(neuron => neuron.Activation);

            var stat = new Dictionary<string, string>();
            var span = DateTime.Now.Subtract(StartTime);
            stat.Add("Time", new DateTime(span.Ticks).ToString(@"HH\:mm\:ss"));

            if (percent > 0)
            {
                var remains = new DateTime((long)(span.Ticks * 100 / percent) - span.Ticks);
                stat.Add("Time remaining", new DateTime(remains.Ticks).ToString(@"HH\:mm\:ss"));
            }
            else
            {
                stat.Add("Time remaining", "N/A");
            }

            stat.Add("Input", number.ToString());
            var max = NetworkModel.GetMaxActivatedNeuron();
            stat.Add("Output", max.Id.ToString() + $" ({(100 * max.Activation).ToString("N4")}%)");
            stat.Add("Cost", NetworkModel.Cost((int)number).ToString("G"));
            stat.Add("Percent", percent.ToString("G") + " %");
            stat.Add("Learning rate", NetworkModel.LearningRate.ToString("G"));
            stat.Add("Rounds", Round.ToString());
            stat.Add("Rounds/sec", ((int)((double)Round / DateTime.Now.Subtract(StartTime).TotalSeconds)).ToString());
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
            StopRunning();
            SaveConfig();
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
        }

        private void CtlMenuDeleteNetwork_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you really like to delete the network?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DeleteNetwork();
            }
        }

        private void CreateNetwork()
        {
            var network = new NetworkControl(null, OnNetworkUIChanged);
            if (network.NetworkConfig != null)
            {
                ReplaceNetworkControl(network);
                Config.Main.Set(Const.Param.NetworkName, network.NetworkConfig.GetString(Const.Param.NetworkName));
            }
        }

        private void LoadNetwork()
        {
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
                CtlReset.Enabled = false;
            }
            else
            {
                CtlTabNetwork.Controls.Add(network);
                CtlTabs.SelectedTab = CtlTabNetwork;
                Text = "Neural Network | " + Path.GetFileNameWithoutExtension(network.NetworkConfig.GetString(Const.Param.NetworkName));
                CtlStart.Enabled = true;
                CtlReset.Enabled = true;
                CtlMenuDeleteNetwork.Enabled = true;
            }

            OnNetworkUIChanged(Notification.ParameterChanged.Structure);
        }

        private NetworkControl NetworkUI
        {
            get
            {
                return CtlTabNetwork.Controls.Count > 0 ? CtlTabNetwork.Controls[0] as NetworkControl : null;
            }
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
            }

            CtlStart.Enabled = true;
            CtlStop.Enabled = false;
            CtlReset.Enabled = true;
            CtlMenuDeleteNetwork.Enabled = true;
        }

        private void CtlReset_Click(object sender, EventArgs e)
        {
            NetworkPresenter.IsNetworkRunning = false;
        }

        private void CtlApplyChanges_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                if (MessageBox.Show("Configuration saved. Would you like running network to apply changes?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ApplyChangesToRunningNetwork();
                    ToggleApplyChanges(Const.Toggle.Off);
                }
            }
            else
            {
                if (MessageBox.Show("Configuration saved. Would you like network to apply changes?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ApplyChangesToStandingNetwork();
                    ToggleApplyChanges(Const.Toggle.Off);
                }
            }
        }
    }
}
