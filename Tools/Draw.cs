using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Draw
    {
        public static Color GetColor(double v, int alpha = 255)
        {
            int s = Math.Sign(v);

            v = Math.Abs(2 / (1 + Math.Exp(-v*4)) - 1);

            if (v > 1)
                v = 1;

            if (s >= 0)
                return Color.FromArgb(alpha, (int)(255 * v), (int)(50 * v), (int)(50 * v));
            else
                return Color.FromArgb(alpha, (int)(50 * v), (int)(50 * v), (int)(255 * v));
        }

        public static Color GetColorDradient(Color from, Color to, int alpha, double fraction)
        {
            if (fraction > 1)
                fraction = 1;
            else if (fraction < 0)
                fraction = 0;

            return Color.FromArgb(alpha,
                                  (int)(from.R - fraction * (from.R - to.R)),
                                  (int)(from.G - fraction * (from.G - to.G)),
                                  (int)(from.B - fraction * (from.B - to.B)));
        }

        public static Color GetColorDradient(Color from, Color zero, Color to, int alpha, double fraction)
        {
            if (fraction < 0.5)
            {
                return GetColorDradient(from, zero, alpha, fraction * 2);
            }
            else
            {
                return GetColorDradient(zero, to, alpha, 2 * (fraction - 0.5));
            }
        }

        public static Brush GetBrush(double v)
        {
            return new SolidBrush(GetColor(v));
        }
        
        public static Pen GetPen(double v, float width = 1, int alpha = 255)
        {
            if (width == 0)
            {
                width = Math.Abs(v) <= 1 ? 1 : (float)Math.Abs(v);
                alpha = alpha == 255 ? (int)(alpha / (1 + (width - 1) / 2)) : alpha;
            }

            return new Pen(GetColor(v, alpha), width);
        }

        public static Pen GetPen(Color c, float width = 1)
        {
            return new Pen(c, width);
        }

        public static Color GetRandomColor(int offsetFromTop, Color? baseColor = null)
        {
            if (baseColor == null)
            {
                baseColor = Color.White;
            }

            var rand = Rand.Flat.Next(offsetFromTop);
            return Color.FromArgb(Math.Max(baseColor.Value.R - offsetFromTop, 0) + rand,
                                  Math.Max(baseColor.Value.G - offsetFromTop, 0) + rand,
                                  Math.Max(baseColor.Value.B - offsetFromTop, 0) + rand);
        }
    }
}
