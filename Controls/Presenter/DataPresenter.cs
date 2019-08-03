using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    public partial class DataPresenter : UserControl
    {
        public Action<int> ValueChanged = delegate { };

        int PointSize;
        int PointsRearrangeSnap;
        int PointsCount;
        double Threshold;
        double[] Data;

        public INetworkTask Task; 

        public DataPresenter()
        {
            InitializeComponent();

            PointSize = Config.Main.GetInt(Const.Param.PointSize, 7).Value;
            PointsRearrangeSnap = Config.Main.GetInt(Const.Param.PointsArrangeSnap, 10).Value;

            CtlInputCount.ValueChanged += CtlInputCount_ValueChanged;
            SizeChanged += DataPresenter_SizeChanged;
            CtlTask.SelectedIndexChanged += CtlTask_SelectedIndexChanged;
        }

        private void CtlTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task = NetworkTask.Helper.GetInstance(CtlTask.SelectedItem.ToString());
        }

        private void DataPresenter_SizeChanged(object sender, EventArgs e)
        {
            Rearrange(Const.CurrentValue);
        }

        public int InputCount => (int)CtlInputCount.Value;

        public void LoadConfig(Config config, Action<int> onValueChanged)
        {
            CtlInputCount.Minimum = Config.Main.GetInt(Const.Param.InputNeuronsMinCount, 10).Value;
            CtlInputCount.Maximum = Config.Main.GetInt(Const.Param.InputNeuronsMaxCount, 10000).Value;

            NetworkTask.Helper.FillComboBox(CtlTask, config, Const.Param.Task, null);

            ValueChanged = onValueChanged;
            CtlInputCount.Value = config.GetInt(Const.Param.InputNeuronsCount, Const.DefaultInputNeuronsCount).Value; 
        }

        public void SaveConfig(Config config)
        {
            config.Set(Const.Param.InputNeuronsCount, (int)CtlInputCount.Value);
            config.Set(Const.Param.Task, CtlTask.SelectedItem.ToString());
        }

        private void CtlInputCount_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged((int)CtlInputCount.Value);
        }

        private void DrawPoint(int x, int y, double value)
        {
            var brush = value == 0 ? Brushes.White : Draw.GetBrush(value);
            CtlPresenter.G.FillRectangle(brush, x * PointSize, y * PointSize, PointSize, PointSize);
            CtlPresenter.G.DrawRectangle(Pens.Black, x * PointSize, y * PointSize, PointSize, PointSize);
            if (brush != Brushes.White)
            {
                brush.Dispose();
            }
        }

        private void TogglePoint(int c, double value)
        {
            var pos = GetPointPosition(c);
            DrawPoint(pos.Item1, pos.Item2, value);
        }

        public void SetInputDataAndDraw(NetworkDataModel model)
        {
            Threshold = model.InputThreshold;
            Data = new double[model.Layers.First().Neurons.Where(n => !n.IsBias).Count()];
            Range.ForEach(model.Layers.First().Neurons.Where(n => !n.IsBias), neuron => Data[neuron.Id] = neuron.Activation);
            Rearrange(PointsCount);
        }

        public void RearrangeWithNewPointsCount()
        {
            Rearrange((int)CtlInputCount.Value);
        }

        private void Rearrange(int pointsCount)
        {
            if (pointsCount == Const.CurrentValue)
            {
                pointsCount = PointsCount;
            }
            else
            {
                PointsCount = pointsCount;
            }

            var width = Math.Max(Width, PointsRearrangeSnap * PointSize);

            int snaps = width / (PointsRearrangeSnap * PointSize);

            CtlPresenter.Height = 1 + PointSize * (int)Math.Ceiling(1 + (double)(PointsCount / (snaps * PointsRearrangeSnap)));

            CtlPresenter.StartRender();

            Range.For(PointsCount, p =>
            {
                var pos = GetPointPosition(p);
                DrawPoint(pos.Item1, pos.Item2, 0);
            });

            if (Data != null)
            {
                Range.For(Data.Length, y => TogglePoint(y, Data[y] > Threshold ? Data[y] : 0));
            }

            CtlPresenter.CtlBox.Invalidate();
        }

        private Tuple<int, int> GetPointPosition(int pointNumber)
        {
            int width = Math.Max(Width, PointsRearrangeSnap * PointSize);

            int snaps = width / (PointsRearrangeSnap * PointSize);
            int y = (int)Math.Ceiling((double)(pointNumber / (snaps * PointsRearrangeSnap)));
            int x = pointNumber - (y * snaps * PointsRearrangeSnap);

            return new Tuple<int, int>(x, y);
        }
    }
}
