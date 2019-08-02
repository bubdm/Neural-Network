using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NN.Controls
{
    using PointFunc = Func<DynamicStatistic.PlotPoints, DynamicStatistic.PlotPoint, long, Point>;

    class PlotterPresenter : PresenterControl
    {
        int AxisOffset;

        public PlotterPresenter()
        {
            AxisOffset = Config.Main.GetInt(Const.Param.AxisOffset, 6).Value;
        }

        public void Draw(List<NetworkDataModel> models, NetworkDataModel selectedModel)
        {
            StartRender();
            Clear();

            foreach (var model in models)
            {
                Vanish(model.DynamicStatistic.PercentData, GetPointPercentData);
                Vanish(model.DynamicStatistic.CostData, GetPointPercentData);

                DrawPlotter();

                DrawData(model.DynamicStatistic.PercentData, model.Color, GetPointPercentData);
                DrawData(model.DynamicStatistic.CostData, Color.FromArgb(150, model.Color), GetPointCostData);
            }

            if (selectedModel != null)
            {
                DrawLabel(selectedModel.DynamicStatistic.PercentData, selectedModel.Color);
            }

            Invalidate();
        }

        public void DrawPlotter()
        {
            var pen = Pens.Black;

            G.DrawLine(pen, AxisOffset, 0, AxisOffset, Height);
            G.DrawLine(pen, 0, Height - AxisOffset, Width, Height - AxisOffset);

            double step = ((double)Width - AxisOffset) / 10;
            double y = Height - AxisOffset - AxisOffset / 2;
            double x = 0;
            for (x = 0; x < 11; ++x)
            {
                G.DrawLine(pen, (float)(AxisOffset + step * x), (float)y, (float)(AxisOffset + step * x), (float)(y + AxisOffset));
            }

            step = ((double)Height - AxisOffset) / 10;
            x = AxisOffset / 2;
            for (y = 0; y < 11; ++y)
            {
                G.DrawLine(pen, (float)x, (float)(Height - AxisOffset - step * y), (float)(x + AxisOffset), (float)(Height - AxisOffset - step * y));
            }
        }

        public void DrawData(DynamicStatistic.PlotPoints data, Color color, PointFunc func)
        {
            using (var pen = new Pen(color))
            using (var brush = new SolidBrush(color))
            {
                for (int n = 0; n < data.Count; ++n)
                {
                    var f = data.First();
                    var l = data.Last();

                    var d = l.Item2.Subtract(f.Item2).Ticks;

                    var prev = f;
                    foreach (var p in data)
                    {
                        var pp = func(data, p, d);
                        G.DrawLine(pen, func(data, prev, d), pp);
                        G.FillEllipse(brush, pp.X - 7 / 2, pp.Y - 7 / 2, 7, 7);

                        prev = p;
                    }
                }
            }
        }

        public void DrawLabel(DynamicStatistic.PlotPoints data, Color color)
        {
            var font = new Font("Tahoma", 6.5f, FontStyle.Bold);
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            using (var brush = new SolidBrush(color))
            {
                G.DrawString(new DateTime(data.Last().Item2.Subtract(data.First().Item2).Ticks).ToString("HH:mm:ss") + " / " + Converter.DoubleToText(data.Last().Item1, "N4") + " %", font, brush, AxisOffset * 3, Height - AxisOffset - 20);
            }
        }

        private Point GetPointPercentData(DynamicStatistic.PlotPoints data, DynamicStatistic.PlotPoint point, long d)
        {
            var p0 = data.First();
            var px = d == 0 ? AxisOffset : AxisOffset + (Width - AxisOffset) * point.Item2.Subtract(p0.Item2).Ticks / d;
            var py = (Height - AxisOffset) * (1 - (point.Item1 / 100));

            return new Point((int)px, (int)py);
        }

        private Point GetPointCostData(DynamicStatistic.PlotPoints data, DynamicStatistic.PlotPoint point, long d)
        {
            var p0 = data.First();
            var px = d == 0 ? AxisOffset : AxisOffset + (Width - AxisOffset) * point.Item2.Subtract(p0.Item2).Ticks / d;
            var py = (Height - AxisOffset) * (1 - Math.Min(1, point.Item1));

            return new Point((int)px, (int)py);
        }

        private void Vanish(DynamicStatistic.PlotPoints data, PointFunc func)
        {
            int vanishArea = 16;

            if (data.Count > 10)
            {
                var pointsToRemove = new List<DynamicStatistic.PlotPoint>();
                var time = data.Last().Item2.Subtract(data.First().Item2);

                for (int i = 0; i < data.Count * 0.8; i += 2)
                {
                    var d = data.Last().Item2.Subtract(data.First().Item2).Ticks;
                    var p0 = func(data, data[i], d);
                    var p2 = func(data, data[i + 2], d);

                    if ((Math.Abs(p0.X - p2.X) < vanishArea && Math.Abs(p0.Y - p2.Y) < vanishArea))
                    {
                        pointsToRemove.Add(data[i + 1]);
                        ++i;
                    }
                    else
                    {
                        var p1 = func(data, data[i + 2], d);
                        if ((p0.X == p1.X && p1.X == p2.X) || (p0.Y == p1.Y && p1.Y == p2.Y))
                        {
                            pointsToRemove.Add(data[i + 1]);
                            ++i;
                        }
                    }
                }

                foreach (var p in pointsToRemove)
                {
                    data.Remove(p);
                }
            }
        }
    }
}
