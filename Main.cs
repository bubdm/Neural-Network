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
        long Round;

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
            NetBox.Dock = DockStyle.Fill;
            CtlNetPanel.Controls.Add(NetBox);
            CtlTime.SizeChanged += CtlTime_SizeChanged;

            CtlPointsCount.ValueChanged += CtlPointsCount_ValueChanged;
            CtlPointsCount.Value = Config.GetInt(Config.Param.PointsCount, 1000);
            CtlPointsCount_ValueChanged(null, null);

            N = new Network(Config.GetArray(Config.Param.LayersSize, $"{(int)CtlPointsCount.Value} , 22, 22, 11"));
            NetBox.SetNetwork(N);
            CtlNetPanel.Width = NetBox.Width;

            Plot = new Plot();
            Plot.Height = 200;
            Plot.Width = 200;
            Plot.Left = 0;
            Plot.Top = NetBox.Height - Plot.Height;
            CtlNetPanel.Controls.Add(Plot);
            Plot.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            Plot.BringToFront();

            Stat = new Stat();
            Stat.Height = 200;
            Stat.Width = 250;
            Stat.Left = Plot.Left + Plot.Width;
            Stat.Top = NetBox.Height - Stat.Top;
            CtlNetPanel.Controls.Add(Stat);
            Stat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Stat.BringToFront();
        }

        private void CtlTime_SizeChanged(object sender, EventArgs e)
        {
            CtlTime.Left = CtlNetPanel.Width - CtlTime.Width;
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
                ++Round;

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
                try
                {
                    Draw(100 * (double)correct / total);
                }
                catch (Exception ex)
                {
                    int a =1;
                }

                ev.Set();
            }));

            ev.WaitOne();
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            CtlLog.Clear();

            N.RandomizeWeights();
            N.FeedForward(); // initialize state

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
            DataBox.SetInputState(N.L[0].A);
            var renderStart = DateTime.Now;
            NetBox.Draw();
            var renderStop = DateTime.Now;
            Plot.AddPoint(percent);

            var number = N.L[0].A.Sum();

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
            var max = N.GetOutValue();
            stat.Add("Output", max.Item1.ToString() + $" ({(100 * N.L.Last().A[max.Item1]).ToString("N4")}%)");
            stat.Add("Cost", N.Cost((int)number).ToString("G"));
            stat.Add("Percent", percent.ToString("G") + " %");
            stat.Add("Learning rate", N.LearningRate.ToString("G"));
            stat.Add("Rounds", Round.ToString());
            stat.Add("Rounds/sec", ((int)((double)Round / DateTime.Now.Subtract(StartTime).TotalSeconds)).ToString());
            stat.Add("Render time, msec", ((int)(renderStop.Subtract(renderStart).TotalMilliseconds)).ToString());
            Stat.DrawStat(stat);
            Log(stat);
        }

        private void Work()
        {
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
