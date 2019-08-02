using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.Controls
{
    class StatisticsPresenter : PresenterControl
    {
        public StatisticsPresenter()
        {
            Font = new Font("Tahoma", 6.5f, FontStyle.Bold);
        }

        public void Draw(Dictionary<string, string> stat)
        {
            StartRender();
            Clear();

            if (stat == null)
            {
                Invalidate();
                return;
            }

            G.TextRenderingHint = TextRenderingHint.AntiAlias;

            int y = 0;
            foreach (var pair in stat)
            {
                G.DrawString(pair.Key + ": " + pair.Value, Font, Brushes.Black, 10, y);
                y += Font.Height;
            };

            CtlBox.Invalidate();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.CtlBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StatisticsPresenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Name = "StatisticsPresenter";
            ((System.ComponentModel.ISupportInitialize)(this.CtlBox)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
