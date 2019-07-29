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
    using PlotPoints = List<Tuple<double, DateTime>>;
    using PlotPoint = Tuple<double, DateTime>;

    class PlotterPresenter : PresenterControl
    {
        PlotPoints PercentData = new PlotPoints();
        PlotPoints CostData = new PlotPoints();

        int AxisOffset;

        public PlotterPresenter()
        {
            AxisOffset = Config.Main.GetInt(Const.Param.AxisOffset, 6);
        }

        public void Draw()
        {
            StartRender();
            Clear();

            DrawPlotter();
            DrawPercentData();
            DrawCostData();
            DrawPercentLabel();

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

        public void DrawPercentData()
        {
            for (int n = 0; n < PercentData.Count; ++n)
            {
                var f = PercentData.First();
                var l = PercentData.Last();

                var d = l.Item2.Subtract(f.Item2).Ticks;

                var prev = f;
                foreach (var p in PercentData)
                {
                    var pp = GetPointPercentData(p, d);
                    G.DrawLine(Pens.Orange, GetPointPercentData(prev, d), pp);
                    G.FillEllipse(Brushes.Orange, pp.X - 7 / 2, pp.Y - 7 / 2, 7, 7);

                    prev = p;
                }
            }
        }

        public void DrawPercentLabel()
        {
            var font = new Font("Tahoma", 6.5f, FontStyle.Bold);
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.DrawString(new DateTime(PercentData.Last().Item2.Subtract(PercentData.First().Item2).Ticks).ToString("HH:mm:ss") + " / " + Converter.DoubleToText(PercentData.Last().Item1, "N4") + " %", font, Brushes.Black, AxisOffset * 3, Height - AxisOffset - 20);
        }

        public void DrawCostData()
        {
            for (int n = 0; n < CostData.Count; ++n)
            {
                var f = CostData.First();
                var l = CostData.Last();

                var d = l.Item2.Subtract(f.Item2).Ticks;

                var prev = f;
                foreach (var p in CostData)
                {
                    using (var pen = Tools.Draw.GetPen(Tools.Draw.GetColorDradient(Color.Green, Color.Yellow, Color.Red, 255, p.Item1), 1))
                    { 
                        var pp = GetPointCostData(p, d);
                        G.DrawLine(pen, GetPointCostData(prev, d), pp);
                        
                        using (var brush = new SolidBrush(pen.Color))
                        {
                            G.FillEllipse(brush, pp.X - 7 / 2, pp.Y - 7 / 2, 7, 7);
                        }
                        
                        prev = p;
                    }
                }
            }
        }

        private Point GetPointPercentData(PlotPoint p1, long d)
        {
            var p0 = PercentData.First();
            var px = d == 0 ? AxisOffset : AxisOffset + (Width - AxisOffset) * p1.Item2.Subtract(p0.Item2).Ticks / d;
            var py = (Height - AxisOffset) * (1 - (p1.Item1 / 100));

            return new Point((int)px, (int)py);
        }

        private Point GetPointCostData(PlotPoint p1, long d)
        {
            var p0 = CostData.First();
            var px = d == 0 ? AxisOffset : AxisOffset + (Width - AxisOffset) * p1.Item2.Subtract(p0.Item2).Ticks / d;
            var py = (Height - AxisOffset) * (1 - Math.Min(1, p1.Item1));

            return new Point((int)px, (int)py);
        }

        public void ClearData()
        {
            PercentData.Clear();
            CostData.Clear();
        }

        public void AddPointPercentData(double percent)
        {
            Vanish(PercentData);
            PercentData.Add(new PlotPoint(percent, DateTime.Now));
        }

        private void Vanish(PlotPoints data)
        {
            int vanishArea = 16;

            if (data.Count > 2)
            {
                var pointsToRemove = new List<PlotPoint>();
                var time = data.Last().Item2.Subtract(data.First().Item2);

                for (int i = 0; i < data.Count - 2; i += 2)
                {
                    var d = data == PercentData
                                    ? PercentData.Last().Item2.Subtract(PercentData.First().Item2).Ticks
                                    : CostData.Last().Item2.Subtract(CostData.First().Item2).Ticks;

                    var p0 = data == PercentData
                                     ? GetPointPercentData(data[i], d)
                                     : GetPointCostData(data[i], d);

                    var p2 = data == PercentData
                                     ? GetPointPercentData(data[i + 2], d)
                                     : GetPointCostData(data[i + 2], d);

                    if ((Math.Abs(p0.X - p2.X) < vanishArea && Math.Abs(p0.Y - p2.Y) < vanishArea))
                    {
                        pointsToRemove.Add(data[i + 1]);
                        ++i;
                    }
                    else
                    {
                        var p1 = data == PercentData
                                         ? GetPointPercentData(data[i + 2], d)
                                         : GetPointCostData(data[i + 2], d);

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

        public void AddPointCostData(double cost)
        {
            Vanish(CostData);
            CostData.Add(new PlotPoint(cost, DateTime.Now));
        }
    }
}
