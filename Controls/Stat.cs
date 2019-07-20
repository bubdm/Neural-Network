using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dots.Controls
{
    class Stat : DrawBox
    {
        public Stat()
        {
            Font = new Font("Tahoma", 7, FontStyle.Bold);
        }

        public void DrawStat(Dictionary<string, string> stat)
        {
            StartRender();
            Clear();

            G.TextRenderingHint = TextRenderingHint.AntiAlias;

            int y = 0;
            foreach (var pair in stat)
            {
                G.DrawString(pair.Key + ": " + pair.Value, Font, Brushes.Black, 10, y);
                y += Font.Height;
            };

            Invalidate();
        }
    }
}
