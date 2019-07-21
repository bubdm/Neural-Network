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
    class NetworkPresenter : PresenterControl
    {
        const int NEURON_MAX_DIST = 40;
        const int HORIZONTAL_OFFSET = 10;
        const int VERTICAL_OFFSET = 10;
        const int NEURON_SIZE = 7;
        const int NEURON_RADIUS = NEURON_SIZE / 2;

        public bool IsNetworkRunning;

        NetworkDataModel NetworkModel;

        public NetworkPresenter()
        {
            Dock = DockStyle.Fill;
            SizeChanged += NetworkPresenter_SizeChanged;
        }

        private void NetworkPresenter_SizeChanged(object sender, EventArgs e)
        {
            if (NetworkModel != null)
            {
                if (IsNetworkRunning)
                    Draw();
                else
                    DrawFullState();
            }
        }

        public int LayerDistance()
        {
            return (Width - 2 * HORIZONTAL_OFFSET) / (NetworkModel.L.Length - 1);
        }

        public void SetNetwork(NetworkDataModel network)
        {
            IsNetworkRunning = false;
            NetworkModel = network;
            DrawFullState();
        }

        private float VertDist(int count)
        {
            return Math.Min(((float)Height - 220) / count, NEURON_MAX_DIST);
        }

        private int LayerX(LayerDataModel L)
        {
            return HORIZONTAL_OFFSET + LayerDistance() * L.Id;
        }

        private void DrawLayersLink(bool fullState, LayerDataModel L1 , LayerDataModel L2)
        {
            Range.For(L1.Height, y1 =>
            {
                Range.For(L2.Height, y2 =>
                {
                    if (fullState || L1.AxW(y1, y2) != 0)
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

        private void DrawLayerNeurons(bool fullState, LayerDataModel L)
        {
            Range.For(L.Height, y =>
            {
                if (fullState || L.A[y] != 0)
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

        private void Draw(bool fullState)
        {
            StartRender();
            Clear();
            if (NetworkModel.L.Length > 0)
            {
                Range.For(NetworkModel.L.Length - 1, n => DrawLayersLink(fullState, NetworkModel.L[n], NetworkModel.L[n + 1]));
            }
            Range.For(NetworkModel.L.Length, n => DrawLayerNeurons(fullState, NetworkModel.L[n]));

            Invalidate();
        }

        public void DrawFullState()
        {
            Draw(true);
        }

        public void Draw()
        {
            Draw(false);
        }
    }
}
