using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dots.Controls
{
    class DrawBox : PictureBox
    {
        public Graphics G;

        Bitmap DrawArea;
        bool RenderNeeded = true;

        public DrawBox() 
        {
            Disposed += DrawBox_Disposed;
            SizeChanged += DrawBox_SizeChanged;
            BackColor = Color.White;
        }

        private void DrawBox_SizeChanged(object sender, EventArgs e)
        {
            RenderNeeded = true;
        }

        public void StartRender()
        {
            if (RenderNeeded && Width > 0 && Height > 0)
            {
                RenderNeeded = false;

                DrawArea = new Bitmap(Width, Height);
                Image = DrawArea;
                if (G != null)
                {
                    G.Dispose();
                }
                G = Graphics.FromImage(DrawArea);
            }
        }

        public void Clear()
        {
            G.Clear(BackColor);
        }

        private void DrawBox_Disposed(object sender, EventArgs e)
        {
            if (G != null)
            {
                G.Dispose();
            }
        }
    }
}
