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
        }

        public void AddData(int input, int output)
        {
            ++Input[input];
            ++Output[output];
            ++Matrix[input, output];
        }

        public void Draw()
        {
            int size = 8;

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
                    using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.Gray, x == y ? Color.Lime : Color.Red, 255, (double)Matrix[y, x] / (double)(x == y ? goodMax : badMax))))
                    {
                        G.FillRectangle(brush, axisOffset + x * size, axisOffset + y * size, size, size);
                    }
                }
            }
            
            long outputMax = Math.Max(Output.Max(), 1);
            for (int x = 0; x < Output.Length; ++x)
            {
                using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.Gray, Color.Lime, 255, (double)Output[x] / (double)outputMax)))
                {
                    G.FillRectangle(brush, axisOffset + x * size, 2 + axisOffset + (Input.Length) * size, size, (int)(bound * (double)Output[x] / (double)outputMax));
                }        
            }

            long inputMax = Math.Max(Input.Max(), 1);
            for (int y = 0; y < Input.Length; ++y)
            {
                using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.Gray, Color.Lime, 255, (double)Input[y] / (double)inputMax)))
                {
                    G.FillRectangle(brush, 2 + axisOffset + (Output.Length) * size, axisOffset + y * size, (int)(bound * (double)Input[y] / (double)inputMax), size);
                }
            }

            G.DrawString("Output", Font, Brushes.Black, axisOffset, axisOffset - Font.Height - 1);
            G.RotateTransform(-90);
            G.DrawString("Input", Font, Brushes.Black, - axisOffset - (Output.Length) * size, axisOffset - Font.Height - 1);
            G.RotateTransform(90);

            Invalidate();
        }
    }
}
