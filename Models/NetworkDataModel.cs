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

        public NetworkDataModel(NetworkControl network)
        {
            var layersSize = network.GetLayersSize();
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

        public void PrepareForStart()
        {
            RandomizeMode.Helper.Invoke(Randomizer, this, RandomizerParamA);
        }

        public void FeedForward()
        {
            Range.ForEach(Layers.First().Neurons, n => n.Activation = 0);
            Range.For(Rand.Flat.Next(11), i => Layers.First().Neurons.RandomElement.Activation = 1);

            Range.ForEachTrimEnd(Layers, -1, layer =>
            Range.ForEach(layer.Next.Neurons, nextNeuron =>
            {
                if (nextNeuron.IsBias && nextNeuron.IsBiasConnected)
                {
                    nextNeuron.Activation = Activation.LogisticSigmoid(Range.SumForEach(layer.Neurons.Where(n => n.IsBias), neuron => neuron.AxW(nextNeuron)));
                }

                if (!nextNeuron.IsBias)
                {
                    nextNeuron.Activation = Activation.LogisticSigmoid(Range.SumForEach(layer.Neurons, neuron => neuron.AxW(nextNeuron)));
                }
            }));
        }

        public void BackPropagation()
        {
            var number = Layers.First().Neurons.Sum(n => n.Activation);

            // backpropogation

            ClearErrors();
            Range.ForEach(Layers.Last().Neurons, neuron =>
            neuron.Error = ((neuron.Id == number ? 1 : 0) - neuron.Activation) * Derivative.LogisticSigmoid(neuron.Activation));

            Range.BackEachTrimEnd(Layers, -2, layer =>
            {
                Range.ForEach(layer.Previous.Neurons, neuronPrev =>
                {
                    neuronPrev.Error = Range.SumForEach(layer.Neurons, neuron =>
                    {/*
                        return neuron.IsBias && !neuron.IsBiasConnected
                                ? 0
                                : 
                                */
                               return neuron.Error * neuronPrev.WeightTo(neuron).Weight * Derivative.LogisticSigmoid(neuronPrev.Activation);
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
                            newNeuron.Activation = neuron.Activation;
                            newNeuron.Error = neuron.Error;

                            newNeuron.IsBias = neuron.IsBias;
                            newNeuron.IsBiasConnected = neuron.IsBiasConnected;

                            newNeuron.WeightsInitializer = neuron.WeightsInitializer;
                            newNeuron.WeightsInitializerParamA = neuron.WeightsInitializerParamA;

                            double initValue = InitializeMode.Helper.Invoke(newNeuron.WeightsInitializer, newNeuron.WeightsInitializerParamA);
                            if (!InitializeMode.Helper.IsSkipValue(initValue))
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
                                newNeuron.ActivationInitializer = neuron.ActivationInitializer;
                                newNeuron.ActivationInitializerParamA = neuron.ActivationInitializerParamA;

                                initValue = InitializeMode.Helper.Invoke(newNeuron.ActivationInitializer, newNeuron.ActivationInitializerParamA);
                                if (!InitializeMode.Helper.IsSkipValue(initValue))
                                {
                                    newNeuron.Activation = initValue;
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
