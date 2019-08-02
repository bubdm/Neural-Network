﻿using NN;
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
        const int NEURON_SIZE = 8;
        const int NEURON_RADIUS = NEURON_SIZE / 2;
        const int BIAS_SIZE = 14;
        const int BIAS_RADIUS = BIAS_SIZE / 2;

        public NetworkPresenter()
        {
            Dock = DockStyle.Fill;
        }

        public int LayerDistance(NetworkDataModel model)
        {
            return (Width - 2 * HORIZONTAL_OFFSET) / (model.Layers.Count - 1);
        }

        private float VerticalDistance(int count)
        {
            return Math.Min(((float)Height - 220) / count, NEURON_MAX_DIST);
        }

        private int LayerX(NetworkDataModel model, LayerDataModel layer)
        {
            return HORIZONTAL_OFFSET + LayerDistance(model) * layer.Id;
        }

        private float MaxHeight(NetworkDataModel model)
        {
            return model.Layers.Max(layer => layer.Height * VerticalDistance(layer.Height));
        }

        private float VerticalShift(NetworkDataModel model, LayerDataModel layer)
        {
            return (MaxHeight(model) - layer.Height * VerticalDistance(layer.Height)) / 2;
        }

        private void DrawLayersLinks(bool fullState, NetworkDataModel model, LayerDataModel layer1 , LayerDataModel layer2)
        {
            double threshold = model.Layers.First() == layer1 ? model.InputThreshold : 0;

            Range.ForEach(layer1.Neurons, layer2.Neurons, (neuron1, neuron2) =>
            {
                if (!neuron2.IsBias || (neuron1.IsBias && neuron2.IsBiasConnected))
                {
                    if (fullState || ((neuron1.IsBias || neuron1.Activation > threshold) && neuron1.AxW(neuron2) != 0))
                    {
                        using (var pen = Tools.Draw.GetPen(neuron1.AxW(neuron2), 1))
                        {
                            G.DrawLine(pen,
                                       LayerX(model, layer1), VERTICAL_OFFSET + VerticalShift(model, layer1) + neuron1.Id * VerticalDistance(layer1.Height),
                                       LayerX(model, layer2), VERTICAL_OFFSET + VerticalShift(model, layer2) + neuron2.Id * VerticalDistance(layer2.Height));
                        }
                    }
                }
            });
        }

        private void DrawLayerNeurons(bool fullState, NetworkDataModel model, LayerDataModel layer)
        {
            double threshold = model.Layers.First() == layer ? model.InputThreshold : 0;

            Range.ForEach(layer.Neurons, neuron =>
            {
                if (fullState || (neuron.IsBias || neuron.Activation > threshold))
                {
                    using (var brush = Tools.Draw.GetBrush(neuron.Activation))
                    {
                        if (neuron.IsBias)
                        {
                            G.FillEllipse(Brushes.Orange,
                                          LayerX(model, layer) - BIAS_RADIUS,
                                          VERTICAL_OFFSET + VerticalShift(model, layer) + neuron.Id * VerticalDistance(layer.Height) - BIAS_RADIUS,
                                          BIAS_SIZE, BIAS_SIZE);
                        }

                        G.FillEllipse(brush,
                                      LayerX(model, layer) - NEURON_RADIUS,
                                      VERTICAL_OFFSET + VerticalShift(model, layer) + neuron.Id * VerticalDistance(layer.Height) - NEURON_RADIUS,
                                      NEURON_SIZE, NEURON_SIZE);
                    }
                }
            });
        }

        private void Draw(bool fullState, NetworkDataModel model)
        {
            StartRender();
            Clear();

            if (model == null)
            {
                return;
            }

            lock (Main.ApplyChangesLocker)
            {
                if (model.Layers.Count > 0)
                {
                    Range.ForEachTrimEnd(model.Layers, -1, layer => DrawLayersLinks(fullState, model, layer, layer.Next));
                }

                Range.ForEach(model.Layers, layer => DrawLayerNeurons(fullState, model, layer));
            }

            Invalidate();
        }

        public void RenderStanding(NetworkDataModel model)
        {
            Draw(true, model);
        }

        public void RenderRunning(NetworkDataModel model)
        {
            Draw(false, model);
        }
    }
}
