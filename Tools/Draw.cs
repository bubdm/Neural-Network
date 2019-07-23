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
        public static Color GetColor(double v)
        {
            int s = Math.Sign(v);

            v = Math.Abs(v);

            if (v > 1)
                v = 1;

            if (s >= 0)
                return Color.FromArgb((int)(255 * v), (int)(50 * v), (int)(50 * v));
            else
                return Color.FromArgb((int)(50 * v), (int)(50 * v), (int)(255 * v));
        }

        public static Brush GetBrush(double v)
        {
            return new SolidBrush(GetColor(v));
        }

        public static Pen GetPen(double v, float width = 1)
        {
            return new Pen(new SolidBrush(GetColor(v)), width);
        }

        public static Pen GetPen(Color c, float width = 1)
        {
            return new Pen(new SolidBrush(c), width);
        }

        public static Color GetRandomColor(int offsetFromTop)
        {
            return Color.FromArgb(255 - offsetFromTop + Rand.Flat.Next(offsetFromTop),
                                  255 - offsetFromTop + Rand.Flat.Next(offsetFromTop),
                                  255 - offsetFromTop + Rand.Flat.Next(offsetFromTop));
        }
    }
}
