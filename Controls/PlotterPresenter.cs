using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dots.Controls
{
    class PlotterPresenter : PresenterControl
    {
        List<Tuple<double, DateTime>> PercentData = new List<Tuple<double, DateTime>>();

        int AxisOffset;

        public PlotterPresenter()
        {
            AxisOffset = Config.Main.GetInt(Config.Param.AxisOffset, 6);
        }

        public void Draw()
        {
            StartRender();
            Clear();

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

            for (int n = 1; n <= PercentData.Count; ++n)
            {
                var data = PercentData.Take(n);

                var f = data.First();
                var l = data.Last();

                var d = l.Item2.Subtract(f.Item2).Ticks;

                using (pen = Tools.Draw.GetPen(Color.FromArgb(10, Color.Orange), 2))
                {
                    if (n == PercentData.Count)
                    {
                        pen.Width = 1;
                        pen.Color = Color.Orange;
                    }

                    var prev = f;
                    foreach (var p in data)
                    {
                        var pp = GetPoint(p, d);
                        G.DrawLine(pen, GetPoint(prev, d), pp);

                        if (n == PercentData.Count)
                        {
                            G.FillEllipse(Brushes.Orange, pp.X - 7 / 2, pp.Y - 7 / 2, 7, 7);
                        }
                        prev = p;
                    }
                }
            }
            
            var font = new Font("Tahoma", 7, FontStyle.Bold);
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.DrawString(new DateTime(PercentData.Last().Item2.Subtract(PercentData.First().Item2).Ticks).ToString("HH:mm:ss") + " / " + PercentData.Last().Item1.ToString("N4") + " %", font, Brushes.Black, AxisOffset * 3, Height - AxisOffset - 20);
            
            Invalidate();
        }

        private Point GetPoint(Tuple<double, DateTime> p1, long d)
        {
            var p0 = PercentData.First();
            var px = d == 0 ? AxisOffset : AxisOffset + (Width - AxisOffset) * p1.Item2.Subtract(p0.Item2).Ticks / d;
            var py = (Height - AxisOffset) - (Height - AxisOffset) * (p1.Item1 / 100);

            return new Point((int)px, (int)py);
        }

        public void ClearData()
        {
            PercentData.Clear();
        }

        public void AddPoint(double percent)
        {
            PercentData.Add(new Tuple<double, DateTime>(percent, DateTime.Now));
            Draw();
        }
    }
}
