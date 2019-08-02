﻿using NN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    class DataPresenter : PresenterControl
    {
        int PointSize;
        int PointsRearrangeSnap;
        int PointsCount;
        double Threshold;
        double[] Data;

        public DataPresenter() 
        {
            PointSize = Config.Main.GetInt(Const.Param.PointSize, 7).Value;
            PointsRearrangeSnap = Config.Main.GetInt(Const.Param.PointsArrangeSnap, 10).Value;
        }

        private void DrawPoint(int x, int y, double value)
        {
            var brush = value == 0 ? Brushes.White : Draw.GetBrush(value);
            G.FillRectangle(brush, x * PointSize, y * PointSize, PointSize, PointSize);
            G.DrawRectangle(Pens.Black, x * PointSize, y * PointSize, PointSize, PointSize);
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
            Rearrange(Width, PointsCount);
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
                DrawPoint(pos.Item1, pos.Item2, 0);
            });

            if (Data != null)
            {
                Range.For(Data.Length, y => TogglePoint(y, Data[y] > Threshold ? Data[y] : 0));
            }

            Invalidate();
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