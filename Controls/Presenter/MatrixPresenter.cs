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
        public MatrixPresenter()
        {
            Font = new Font("Tahoma", 6.5f, FontStyle.Bold);
        }

        public void Draw(List<NetworkDataModel> models, NetworkDataModel selectedModel)
        {
            int size = 9;

            StartRender();
            Clear();

            long goodMax = 1;
            long badMax = 1;
            long axisOffset = 12;
            long bound = 60;

            var matrix = selectedModel.ErrorMatrix;

            for (int y = 0; y < matrix.Output.Length; ++y)
            {
                for (int x = 0; x < matrix.Input.Length; ++x)
                {
                    if (x == y)
                    {
                        goodMax = Math.Max(goodMax, matrix.Matrix[x, y]);
                    }
                    else
                    {
                        badMax = Math.Max(badMax, matrix.Matrix[x, y]);
                    }
                }
            }
            
            for (int y = 0; y < matrix.Output.Length; ++y)
            {
                for (int x = 0; x < matrix.Input.Length; ++x)
                {
                    var value = (double)matrix.Matrix[y, x] / (double)(x == y ? goodMax : badMax);
                    using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.LightGray, x == y ? Color.Green : Color.Red, 255, value)))
                    {
                        G.FillRectangle(brush, axisOffset + x * size, axisOffset + y * size, size, size);
                        G.DrawRectangle(Pens.Silver, axisOffset + x * size, axisOffset + y * size, size, size);
                    }
                }
            }
            
            long outputMax = Math.Max(matrix.Output.Max(), 1);
            for (int x = 0; x < matrix.Output.Length; ++x)
            {
                using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.White, matrix.Output[x] > matrix.Input[x] ? Color.Red : matrix.Output[x] < matrix.Input[x] ? Color.Blue : Color.Green, 100, (double)matrix.Output[x] / (double)outputMax)))
                {
                    G.FillRectangle(brush, axisOffset + x * size, 2 + axisOffset + (matrix.Input.Length) * size, size, (int)(bound * (double)matrix.Output[x] / (double)outputMax));
                    G.DrawRectangle(Pens.Silver, axisOffset + x * size, 2 + axisOffset + (matrix.Input.Length) * size, size, (int)(bound * (double)matrix.Output[x] / (double)outputMax));
                }        
            }

            long inputMax = Math.Max(matrix.Input.Max(), 1);
            for (int y = 0; y < matrix.Input.Length; ++y)
            {
                using (var brush = new SolidBrush(Tools.Draw.GetColorDradient(Color.White, Color.Green, 100, (double)matrix.Input[y] / (double)inputMax)))
                {
                    G.FillRectangle(brush, 2 + axisOffset + (matrix.Output.Length) * size, axisOffset + y * size, (int)(bound * (double)matrix.Input[y] / (double)inputMax), size);
                    G.DrawRectangle(Pens.Silver, 2 + axisOffset + (matrix.Output.Length) * size, axisOffset + y * size, (int)(bound * (double)matrix.Input[y] / (double)inputMax), size);
                }
            }

            G.DrawString("Output", Font, Brushes.Black, axisOffset, axisOffset - Font.Height - 1);
            G.RotateTransform(-90);
            G.DrawString("Input", Font, Brushes.Black, - axisOffset - (matrix.Output.Length) * size, axisOffset - Font.Height - 1);
            G.RotateTransform(90);

            G.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            CtlBox.Invalidate();
        }
    }
}
