using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Dots
{
    public class NetworkDataModel
    {
        public ListX<LayerDataModel> Layers = new ListX<LayerDataModel>();
        public double LearningRate = 0.05;

        public NetworkDataModel(int[] layersSize)
        {
            Range.For(layersSize.Length, n =>
                CreateLayer(layersSize[n], n < layersSize.Length - 1 ? layersSize[n + 1] : 0));
        }

        public void CreateLayer(int neuronCount, int weightsCount)
        {
            if (neuronCount > 0)
                Layers.Add(new LayerDataModel(Layers.Count, neuronCount, weightsCount));
        }

        public double Cost(int x)
        {
            return Layers.Last().Neurons.Sum(n => Math.Pow(n.Activation - (x == n.Id ? 1 : 0), 2));
        }

        public void RandomizeWeights(string randomizer, double a)
        {
            RandomizeMode.Helper.Invoke(randomizer, this, a);
        }

        private void RandHe()
        {
            /*
            Range.For(L.Length, l =>
            {
                Range.For(L[l].Height, L[l].Width, (y, x) =>
                {
                    if (l > 0)
                        L[l].W[y, x] = Math.Abs(GetRand() * Math.Sqrt(2 / L[l - 1].Height));
                    else
                        L[l].W[y, x] = GetRand();
                });
            });
            */
        }

        public void ClearErrors()
        {
            Range.ForEach(Layers, l => l.ClearErrors());
        }

        public NeuronDataModel GetMaxActivatedNeuron()
        {
            var max = Layers.Last().Neurons.First();
            Range.ForEach(Layers.Last().Neurons, neuron =>
            {
                if (neuron.Activation > max.Activation)
                {
                    max = neuron;
                }
            });

            return max;
        }

        public void FeedForward()
        {
            Range.ForEach(Layers.First().Neurons, n => n.Activation = 0);
            Range.For(Rand.Flat.Next(11), i => Layers.First().Neurons.RandomElement.Activation = 1);

            Range.ForEachTrimEnd(Layers, -1, layer =>
            Range.ForEach(layer.Next.Neurons, nextNeuron => nextNeuron.Activation = Activation.Sigmoid(Range.SumForEach(layer.Neurons, neuron => neuron.AxW(nextNeuron)))));
        }

        public void BackPropagation()
        {
            var number = Layers.First().Neurons.Sum(n => n.Activation);

            // backpropogation

            ClearErrors();
            Range.ForEach(Layers.Last().Neurons, neuron =>
            neuron.Error = ((neuron.Id == number ? 1 : 0) - neuron.Activation) * Derivative.Sigmoid(neuron.Activation));

            Range.BackEachTrimEnd(Layers, -1, layer =>
            {
                Range.ForEach(layer.Previous.Neurons, neuronPrev =>
                    neuronPrev.Error = Range.SumForEach(layer.Neurons, neuron =>
                        neuron.Error * neuronPrev.WeightTo(neuron).Weight * Derivative.Sigmoid(neuronPrev.Activation)));
            });

            // update weights

            Range.BackEachTrimEnd(Layers, -1, layer =>
            {
                Range.ForEach(layer.Previous.Neurons, layer.Neurons, (neuronPrev, neuron) => neuronPrev.WeightTo(neuron).Add(neuron.Error * neuronPrev.Activation * LearningRate));
            });
        }

        public NetworkDataModel Merge(NetworkDataModel model)
        {
            foreach (var newLayer in model.Layers)
            {
                var layer = Layers.Find(l => l.VisualId == newLayer.VisualId);
                if (layer != null)
                {
                    foreach (var newNeuron in newLayer.Neurons)
                    {
                        var neuron = layer.Neurons.Find(n => n.VisualId == newNeuron.VisualId);
                        if (neuron != null)
                        {
                            newNeuron.Activation = neuron.Activation;
                            newNeuron.Error = neuron.Error;

                            foreach (var newWeight in newNeuron.Weights)
                            {
                                var weight = neuron.Weights.Find(w => w.Id == newWeight.Id);
                                if (weight != null)
                                {
                                    newWeight.Weight = weight.Weight;
                                }
                            }
                        }
                    }
                }
            }

            return model;
        }
    }
}
