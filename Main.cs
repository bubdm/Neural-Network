using Dots;
using Dots.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        Network N;
        DateTime StartTime;

        // Visual controls

        DataBox DataBox;
        NetBox NetBox;
        Plot Plot;
        Stat Stat;

        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Config.Clear();

            DataBox = new DataBox();
            DataBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            CtlDataPanel.Controls.Add(DataBox);

            NetBox = new NetBox();
            NetBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            CtlNetPanel.Controls.Add(NetBox);

            CtlPointsCount.ValueChanged += CtlPointsCount_ValueChanged;
            CtlPointsCount.Value = (int)Config.GetNumber(Config.POINTS_COUNT, 1000);
            CtlPointsCount_ValueChanged(null, null);

            N = new Network(Config.GetArray(Config.LAYERS_SIZE, $"{(int)CtlPointsCount.Value} , 22, 22, 11"));
            NetBox.SetNetwork(N);
            CtlNetPanel.Width = NetBox.Width;

            Plot = new Plot();
            Plot.Height = 200;
            Plot.Width = 200;
            Plot.Left = 0;
            Plot.Top = NetBox.Height;
            CtlNetPanel.Controls.Add(Plot);
            Plot.BringToFront();

            Stat = new Stat();
            Stat.Height = 200;
            Stat.Width = 250;
            Stat.Left = Plot.Left + Plot.Width;
            Stat.Top = NetBox.Height;
            CtlNetPanel.Controls.Add(Stat);
            Stat.BringToFront();
        }

        private void Log(Dictionary<string, string> data)
        {
            BeginInvoke((Action)(() =>
            {
                foreach (var pair in data)
                {
                    CtlLog.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + pair.Key + ": " + pair.Value + "\r\n";
                }
            }));
        }

        private void Recalc()
        {
            long total = 0;
            long correct = 0;

            DateTime startTime = DateTime.Now;
            DateTime prevTime = DateTime.Now;

            while (!CancellationToken.IsCancellationRequested)
            {
                N.FeedForward();

                var max = N.GetOutValue();
                var number = N.L[0].A.Sum();
                if (number == max.Item1)
                {
                    ++correct;
                }
                ++total;

                N.BackPropagation();

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
                Draw(100 * (double)correct / total);
                ev.Set();
            }));

            ev.WaitOne();
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            CtlLog.Clear();

            N.RandomizeWeights();

            Draw(0);

            CancellationToken = CancellationTokenSource.Token;

            var ts = new ThreadStart(Work);
            WorkThread = new Thread(ts);
            WorkThread.Start();

            StartTime = DateTime.Now;
        }

        private void Draw(double percent)
        {
            DataBox.SetInputState(N.L[0].A);
            NetBox.Draw();
            Plot.AddPoint(percent);

            var number = N.L[0].A.Sum();

            var stat = new Dictionary<string, string>();
            stat.Add("Time", DateTime.Now.Subtract(StartTime).ToString(@"hh\:mm\:ss"));
            stat.Add("Number", number.ToString());
            var max = N.GetOutValue();
            stat.Add("Answer", max.Item1.ToString());
            stat.Add("Cost", N.Cost((int)number).ToString("G"));
            stat.Add("Percent", percent.ToString("G") + " %");
            stat.Add("Rate", N.LearningRate.ToString("G"));
            Stat.DrawStat(stat);
            Log(stat);
        }

        private void Work()
        {
            StartTime = DateTime.Now;

            while (!CancellationToken.IsCancellationRequested)
            {
                Recalc();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancellationTokenSource.Cancel();
            if (WorkThread != null)
            {
                WorkThread.Join();
            }
        }

        private void CtlPointsCount_ValueChanged(object sender, EventArgs e)
        {
            DataBox.Rearrange(CtlDataPanel.Width, (int)CtlPointsCount.Value);
        }

        private void CtlDataPanel_SizeChanged(object sender, EventArgs e)
        {
            DataBox.Rearrange(CtlDataPanel.Width, (int)CtlPointsCount.Value);
        }
    }
}
