using NN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace Dots.Controls
{
    class DataControl : PresenterControl
    {
        int PointSize;
        int PointsRearrangeSnap;
        int PointsCount;
        double[] Data;

        public DataControl() 
        {
            PointSize = Config.Main.GetInt(Const.Param.PointSize, 7);
            PointsRearrangeSnap = Config.Main.GetInt(Const.Param.PointsArrangeSnap, 10);
        }

        public void SetPointsCount(int count)
        {
            if (PointsCount != count)
            {
                Rearrange(Width, PointsCount);
            }
        }
   
        private void DrawPoint(int x, int y, bool isOn)
        {
            G.FillRectangle(isOn ? Brushes.Black : Brushes.White, x * PointSize, y * PointSize, PointSize, PointSize);
            G.DrawRectangle(Pens.Black, x * PointSize, y * PointSize, PointSize, PointSize);
        }

        private void TogglePoint(int c, bool isOn)
        {
            var pos = GetPointPosition(c);
            DrawPoint(pos.Item1, pos.Item2, isOn);
        }

        public void SetInputData(LayerDataModel layer)
        {
            Data = new double[layer.Neurons.Count];
            Range.ForEach(layer.Neurons, neuron => Data[neuron.Id] = neuron.Activation);    
            Rearrange(Width, PointsCount);
            Invalidate();
        }

        public void RearrangeWithNewWidth(int width)
        {
            Rearrange(width, Const.CurrentValue);
        }

        public void RearrangeWithNewPointsCount(int pointsCount)
        {
            Rearrange(Const.CurrentValue, pointsCount);
        }

        private void Rearrange(int width, int pointsCount)
        {
            if (pointsCount == Const.CurrentValue)
            {
                pointsCount = PointsCount;
            }
            else 
            {
                PointsCount = pointsCount;
            }

            if (width == Const.CurrentValue)
            {
                width = Width;
            }
            else
            {
                width = Math.Max(width, PointsRearrangeSnap * PointSize);
            }

            int snaps = width / (PointsRearrangeSnap * PointSize);

            Width = width;
            Height = 1 + PointSize * (int)Math.Ceiling(1 + (double)(PointsCount / (snaps * PointsRearrangeSnap)));

            StartRender();

            Range.For(PointsCount, p =>
            {
                var pos = GetPointPosition(p);
                DrawPoint(pos.Item1, pos.Item2, false);
            });

            if (Data != null)
            {
                Range.For(Data.Length, y => TogglePoint(y, Data[y] == 1));
            }
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
