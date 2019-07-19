using NN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace Dots.Controls
{
    class NetBox : DrawBox
    {
        const int WIDTH = 630;
        const int NEURON_MAX_DIST = 40;
        const int HORIZONTAL_OFFSET = 10;
        const int VERTICAL_OFFSET = 10;
        const int NEURON_SIZE = 7;
        const int NEURON_RADIUS = NEURON_SIZE / 2;

        Network Network;

        int LayersCount;
        int MaxNeuronCount;
        int LayerDistance;

        public void SetNetwork(Network network)
        {
            Network = network;

            LayersCount = Network.L.Length;
            MaxNeuronCount = Network.L.Max(L => L == Network.L.First() ? 0 : L.Height);
            LayerDistance = (WIDTH - 2 * HORIZONTAL_OFFSET) / (LayersCount - 1);

            int height = (int)(VERTICAL_OFFSET * 2 + MaxNeuronCount * VertDist(MaxNeuronCount));

            Size = new Size(WIDTH, height);
        }

        private float VertDist(int count)
        {
            return Math.Min(600f / count, NEURON_MAX_DIST);
        }

        private int LayerX(Layer L)
        {
            return HORIZONTAL_OFFSET + LayerDistance * L.Id;
        }

        public void DrawLayersLink(Layer L1 , Layer L2)
        {
            Range.For(L1.Height, y1 =>
            {
                Range.For(L2.Height, y2 =>
                {
                    if (L1.AxW(y1, y2) != 0)
                    {
                        using (var pen = Tools.Draw.GetPen(L1.AxW(y1, y2)))
                        {
                            G.DrawLine(pen,
                                       LayerX(L1), VERTICAL_OFFSET + y1 * VertDist(L1.Height),
                                       LayerX(L2), VERTICAL_OFFSET + y2 * VertDist(L2.Height));
                        }
                    }
                });
            });
        }

        public void DrawLayerNeurons(Layer L)
        {
            Range.For(L.Height, y =>
            {
                if (L.A[y] != 0)
                {
                    using (var brush = Tools.Draw.GetBrush(L.A[y]))
                    {
                        G.FillEllipse(brush,
                                      LayerX(L) - NEURON_RADIUS,
                                      VERTICAL_OFFSET + y * VertDist(L.Height) - NEURON_RADIUS,
                                      NEURON_SIZE, NEURON_SIZE);
                    }
                }
            });
        }

        public void Draw()
        {
            Clear();
            Range.For(Network.L.Length - 1, n => DrawLayersLink(Network.L[n], Network.L[n + 1]));
            Range.For(Network.L.Length, n => DrawLayerNeurons(Network.L[n]));

            Invalidate();
        }
    }
}
