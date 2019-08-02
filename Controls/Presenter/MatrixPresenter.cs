using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.Controls
{
    class MatrixPresenter : PresenterControl
    {
        long[] Input = new long[11];
        long[] Output = new long[11];
        long[,] Matrix = new long[11, 11];

        public long Count
        {
            get;
            private set;
        }

        public MatrixPresenter()
        {
            Font = new Font("Tahoma", 6.5f, FontStyle.Bold);
        }

        public void ClearData()
        {        
            Array.Clear(Input, 0, Input.Length);
            Array.Clear(Output, 0, Output.Length);
            for (int y = 0; y < Input.Length; ++y)
            {
                for (int x = 0; x < Output.Length; ++x)
                {
                    Matrix[x, y] = 0;
                }
            }
            Count = 0;
        }

        public void AddData(int input, int output)
        {
            ++Input[input];
            ++Output[output];
            ++Matrix[input, output];
            ++Count;
        }

        public void Draw()
        {
            int size = 9;

            StartRender();
            Clear();

            long goodMax = 1;
            long badMax = 1;
            long axisOffset = 12;
            long bound = 60;

            for (int y = 0; y < Output.Length; ++y)
            {
                for (int x = 0; x < Input.Length; ++x)
                {
                    if (x == y)
                    {
                        goodMax = Math.Max(goodMax, Matrix[x, y]);
                    }
                    else
                    {
                        badMax = Math.Max(badMax, Matrix[x, y]);
                    }
                }
            }
            
            for (int y = 0; y < Output.Length; ++y)
            {
                for (int x = 0; x < Input.Length; ++x)
                {
                    var value = (double)Matrix[y, x] / (double)(x == y ? goodMax : badMax);
                    using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.LightGray, x == y ? Color.Green : Color.Red, 255, value)))
                    {
                        G.FillRectangle(brush, axisOffset + x * size, axisOffset + y * size, size, size);
                        G.DrawRectangle(Pens.Silver, axisOffset + x * size, axisOffset + y * size, size, size);
                    }
                }
            }
            
            long outputMax = Math.Max(Output.Max(), 1);
            for (int x = 0; x < Output.Length; ++x)
            {
                using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.White, Output[x] > Input[x] ? Color.Red : Output[x] < Input[x] ? Color.Blue : Color.Green, 100, (double)Output[x] / (double)outputMax)))
                {
                    G.FillRectangle(brush, axisOffset + x * size, 2 + axisOffset + (Input.Length) * size, size, (int)(bound * (double)Output[x] / (double)outputMax));
                    G.DrawRectangle(Pens.Silver, axisOffset + x * size, 2 + axisOffset + (Input.Length) * size, size, (int)(bound * (double)Output[x] / (double)outputMax));
                }        
            }

            long inputMax = Math.Max(Input.Max(), 1);
            for (int y = 0; y < Input.Length; ++y)
            {
                using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.White, Color.Green, 100, (double)Input[y] / (double)inputMax)))
                {
                    G.FillRectangle(brush, 2 + axisOffset + (Output.Length) * size, axisOffset + y * size, (int)(bound * (double)Input[y] / (double)inputMax), size);
                    G.DrawRectangle(Pens.Silver, 2 + axisOffset + (Output.Length) * size, axisOffset + y * size, (int)(bound * (double)Input[y] / (double)inputMax), size);
                }
            }

            G.DrawString("Output", Font, Brushes.Black, axisOffset, axisOffset - Font.Height - 1);
            G.RotateTransform(-90);
            G.DrawString("Input", Font, Brushes.Black, - axisOffset - (Output.Length) * size, axisOffset - Font.Height - 1);
            G.RotateTransform(90);

            G.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            CtlBox.Invalidate();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.CtlBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MatrixPresenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Name = "MatrixPresenter";
            ((System.ComponentModel.ISupportInitialize)(this.CtlBox)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
