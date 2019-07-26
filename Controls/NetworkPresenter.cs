using NN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    class NetworkPresenter : PresenterControl
    {
        const int NEURON_MAX_DIST = 40;
        const int HORIZONTAL_OFFSET = 10;
        const int VERTICAL_OFFSET = 10;
        const int NEURON_SIZE = 7;
        const int NEURON_RADIUS = NEURON_SIZE / 2;
        const int BIAS_SIZE = 14;
        const int BIAS_RADIUS = BIAS_SIZE / 2;

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
                    Render();
                else
                    RenderFullState();
            }
        }

        public int LayerDistance()
        {
            return (Width - 2 * HORIZONTAL_OFFSET) / (NetworkModel.Layers.Count - 1);
        }

        public void SetNetwork(NetworkDataModel network)
        {
            IsNetworkRunning = false;
            NetworkModel = network;
            RenderFullState();
        }

        public void UpdateNetwork(NetworkDataModel network)
        {
            NetworkModel = network;
            Render();
        }

        private float VerticalDistance(int count)
        {
            return Math.Min(((float)Height - 220) / count, NEURON_MAX_DIST);
        }

        private int LayerX(LayerDataModel layer)
        {
            return HORIZONTAL_OFFSET + LayerDistance() * layer.Id;
        }

        private float MaxHeight()
        {
            return NetworkModel.Layers.Max(layer => layer.Height * VerticalDistance(layer.Height));
        }

        private float VerticalShift(LayerDataModel layer)
        {
            return (MaxHeight() - layer.Height * VerticalDistance(layer.Height)) / 2;
        }

        private void DrawLayersLinks(bool fullState, LayerDataModel layer1 , LayerDataModel layer2)
        {
            Range.ForEach(layer1.Neurons, layer2.Neurons, (neuron1, neuron2) =>
            {
                if (!neuron2.IsBias || (neuron1.IsBias && neuron2.IsBiasConnected))
                {
                    if (fullState || neuron1.AxW(neuron2) != 0)
                    {
                        using (var pen = Tools.Draw.GetPen(neuron1.AxW(neuron2)))
                        {
                            G.DrawLine(pen,
                                       LayerX(layer1), VERTICAL_OFFSET + VerticalShift(layer1) + neuron1.Id * VerticalDistance(layer1.Height),
                                       LayerX(layer2), VERTICAL_OFFSET + VerticalShift(layer2) + neuron2.Id * VerticalDistance(layer2.Height));
                        }
                    }
                }
            });
        }

        private void DrawLayerNeurons(bool fullState, LayerDataModel layer)
        {
            Range.ForEach(layer.Neurons, neuron =>
            {
                if (fullState || neuron.Activation != 0)
                {
                    using (var brush = Tools.Draw.GetBrush(neuron.Activation))
                    {
                        if (neuron.IsBias)
                        {
                            G.FillEllipse(Brushes.Green,
                                          LayerX(layer) - BIAS_RADIUS,
                                          VERTICAL_OFFSET + VerticalShift(layer) + neuron.Id * VerticalDistance(layer.Height) - BIAS_RADIUS,
                                          BIAS_SIZE, BIAS_SIZE);
                        }

                        G.FillEllipse(brush,
                                      LayerX(layer) - NEURON_RADIUS,
                                      VERTICAL_OFFSET + VerticalShift(layer) + neuron.Id * VerticalDistance(layer.Height) - NEURON_RADIUS,
                                      NEURON_SIZE, NEURON_SIZE);
                    }
                }
            });
        }

        private void Draw(bool fullState)
        {
            StartRender();
            Clear();
            if (NetworkModel.Layers.Count > 0)
            {
                Range.ForEachTrimEnd(NetworkModel.Layers, -1, layer => DrawLayersLinks(fullState, layer, layer.Next));
            }
            Range.ForEach(NetworkModel.Layers, layer => DrawLayerNeurons(fullState, layer));

            Invalidate();
        }

        public void RenderFullState()
        {
            Draw(true);
        }

        public void Render()
        {
            Draw(false);
        }
    }
}
