using NN.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NN
{
    public class NetworkDataModel
    {
        public ListX<LayerDataModel> Layers = new ListX<LayerDataModel>();
        public double LearningRate;
        public string Randomizer;
        public double? RandomizerParamA;

        public NetworkDataModel(int[] layersSize)
        {
            Range.For(layersSize.Length, n =>
                CreateLayer(layersSize[n], n < layersSize.Length - 1 ? layersSize[n + 1] : 0));
        }

        public void CreateLayer(int neuronCount, int weightsCount)
        {
            Layers.Add(new LayerDataModel(Layers.Count, neuronCount, weightsCount));
        }

        public double Cost(int x)
        {
            return Layers.Last().Neurons.Sum(n => Math.Pow(n.Activation - (x == n.Id ? 1 : 0), 2));
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

        public NeuronDataModel GetMaxActivatedOutputNeuron()
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

        public void InitState()
        {
            Range.ForEach(Layers.First().Neurons, n => n.Activation = 1);
            RandomizeMode.Helper.Invoke(Randomizer, this, RandomizerParamA);
        }

        public void SetInputData()
        {
            Range.ForEach(Layers.First().Neurons.Where(n => !n.IsBias), n => n.Activation = 0);
            Range.For(Rand.Flat.Next(11), i => Layers.First().Neurons.RandomElement(Layers.First().BiasCount).Activation = 1);
        }

        public int GetNumberOfFirstLayerActiveNeurons(double threshold = 0)
        {
            return Layers.First().Neurons.Where(n => !n.IsBias).Count(n => n.Activation > threshold);
        }

        public void FeedForward()
        {
            Range.ForEachTrimEnd(Layers, -1, layer =>
            Range.ForEach(layer.Next.Neurons, nextNeuron =>
            {
                if (nextNeuron.IsBias && nextNeuron.IsBiasConnected)
                {
                    nextNeuron.Activation = Activation.LogisticSigmoid(Range.SumForEach(layer.Neurons.Where(n => n.IsBias), bias => bias.AxW(nextNeuron)));
                }

                if (!nextNeuron.IsBias)
                {
                    nextNeuron.Activation = Activation.LogisticSigmoid(Range.SumForEach(layer.Neurons, neuron => neuron.AxW(nextNeuron)));
                }
            }));
        }

        public void BackPropagation(int targetValue)
        {
            // backpropogation

            ClearErrors();
            Range.ForEach(Layers.Last().Neurons, neuron =>
            neuron.Error = ((neuron.Id == targetValue ? 1 : 0) - neuron.Activation) * Derivative.LogisticSigmoid(neuron.Activation));

            Range.BackEachTrimEnd(Layers, -1, layer =>
            {
                Range.ForEach(layer.Previous.Neurons, neuronPrev =>
                {
                    neuronPrev.Error = Range.SumForEach(layer.Neurons, neuron =>
                    {
                        return neuronPrev.IsBias && !neuron.IsBiasConnected
                               ? 0
                               : neuron.Error * neuronPrev.WeightTo(neuron).Weight * Derivative.LogisticSigmoid(neuronPrev.Activation);
                    });
                    int f = 1;
                });
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
                            double initValue = InitializeMode.Helper.Invoke(newNeuron.WeightsInitializer, newNeuron.WeightsInitializerParamA);
                            if (InitializeMode.Helper.IsSkipValue(initValue))
                            {
                                foreach (var newWeight in newNeuron.Weights)
                                {
                                    var weight = neuron.Weights.Find(w => w.Id == newWeight.Id);
                                    if (weight != null)
                                    {
                                        newWeight.Weight = weight.Weight;
                                    }
                                }
                            }

                            if (newNeuron.IsBias)
                            {
                                initValue = InitializeMode.Helper.Invoke(newNeuron.ActivationInitializer, newNeuron.ActivationInitializerParamA);
                                if (InitializeMode.Helper.IsSkipValue(initValue))
                                {
                                    newNeuron.Activation = neuron.Activation;
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
