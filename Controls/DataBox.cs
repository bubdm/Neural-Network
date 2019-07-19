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
    class DataBox : DrawBox
    {
        int PointSize;
        int PointsReaarrangeSnap;
        int PointsCount;
        double[] Data;

        public DataBox() 
        {
            PointSize = (int)Config.GetNumber(Config.POINT_SIZE, 7);
            PointsReaarrangeSnap = (int)Config.GetNumber(Config.POINT_ARRANGE_SNAP, 10);

            Size = new Size(PointsReaarrangeSnap * PointSize + 1, PointSize + 1);
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

        public void TogglePoint(int c, bool isOn)
        {
            var pos = GetPointPosition(c);
            DrawPoint(pos.Item1, pos.Item2, isOn);
        }

        public void SetInputState(double[] data)
        {
            Data = new double[data.Length];
            data.CopyTo(Data, 0);
            DrawData();
            Invalidate();
        }

        private void DrawData()
        {
            if (Data != null)
            {
                Range.For(Data.Length, y => TogglePoint(y, Data[y] == 1));
            }
        }

        public void Rearrange(int width, int pointsCount)
        {
            PointsCount = pointsCount;
            width = Math.Max(width, PointsReaarrangeSnap * PointSize);

            int snaps = width / (PointsReaarrangeSnap * PointSize);

            Width = width;
            Height = 1 + PointSize * (int)Math.Ceiling(1 + (double)(PointsCount / (snaps * PointsReaarrangeSnap)));

            Range.For(PointsCount, p =>
            {
                var pos = GetPointPosition(p);
                DrawPoint(pos.Item1, pos.Item2, false);
            });

            DrawData();
        }

        private Tuple<int, int> GetPointPosition(int pointNumber)
        {
            int width = Math.Max(Width, PointsReaarrangeSnap * PointSize);

            int snaps = width / (PointsReaarrangeSnap * PointSize);
            int y = (int)Math.Ceiling((double)(pointNumber / (snaps * PointsReaarrangeSnap)));
            int x = pointNumber - (y * snaps * PointsReaarrangeSnap);

            return new Tuple<int, int>(x, y);
        }
    }
}
