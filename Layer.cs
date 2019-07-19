using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Dots
{
    public class Layer
    {
        public int Height;
        public int Width;
        public int Id;

        public double[] A; // activation
        public double[] E; // error
        public double[,] W; // weight

        public Layer(int id, int height, int width)
        {
            Id = id;
            Height = height;
            Width = width;

            A = new double[height];
            E = new double[height];
            W = new double[height, width];

            Range.For(height, y =>
            {
                A[y] = 0; E[y] = 0;
                Range.For(width, x => W[y, x] = -1 + 2 * Math.Pow(Rand.Flat.NextDouble(), 3));
            });
        }

        public double AxW(int y, int yn)
        {
            return A[y] * W[y, yn];
        }

        public void ClearErrors()
        {
            Array.Clear(E, 0, E.Length);
        }
    }
}
