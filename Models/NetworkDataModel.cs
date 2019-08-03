﻿using NN.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NN
{
    public class NetworkDataModel
    {
        public long VisualId;
        public ListX<LayerDataModel> Layers = new ListX<LayerDataModel>();
        public double LearningRate;
        public string RandomizeMode;
        public double? RandomizerParamA;
        public double InputInitial0;
        public double InputInitial1;

        public Statistic Statistic;
        public DynamicStatistic DynamicStatistic;
        public Color Color;

        public NetworkDataModel(long visualId, int[] layersSize)
        {
            VisualId = visualId;
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

        public double InputThreshold => (InputInitial0 + InputInitial1) / 2;

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
            Range.ForEach(Layers.First().Neurons, n => n.Activation = InputInitial1);
            Tools.RandomizeMode.Helper.Invoke(RandomizeMode, this, RandomizerParamA);
        }

        public void Activate()
        {
            Range.ForEach(Layers, layer => Range.ForEach(layer.Neurons, n => n.Activation = InputInitial1));
            Tools.RandomizeMode.Helper.Invoke(RandomizeMode, this, RandomizerParamA);
        }

        public int GetNumberOfFirstLayerActiveNeurons()
        {
            return Layers.First().Neurons.Where(n => !n.IsBias).Count(n => n.Activation > InputThreshold);
        }

        public void FeedForward()
        {
            Range.ForEachTrimEnd(Layers, -1, layer =>
            Range.ForEach(layer.Next.Neurons, nextNeuron =>
            {
                if (nextNeuron.IsBias && nextNeuron.IsBiasConnected)
                {
                    nextNeuron.Activation = ActivationFunction.Helper.Invoke(nextNeuron.ActivationFunc, Range.SumForEach(layer.Neurons.Where(n => n.IsBias), bias => bias.AxW(nextNeuron)));
                }

                if (!nextNeuron.IsBias)
                {
                    nextNeuron.Activation = ActivationFunction.Helper.Invoke(nextNeuron.ActivationFunc, Range.SumForEach(layer.Neurons, neuron => neuron.AxW(nextNeuron)));
                }

                // not connected bias doesn't change it's activation

            }));
        }

        public void BackPropagation(int targetValue)
        {
            // backpropogation

            ClearErrors();
            Range.ForEach(Layers.Last().Neurons, neuron =>
            neuron.Error = ((neuron.Id == targetValue ? 1 : 0) - neuron.Activation) * ActivationFunctionDerivative.Helper.Invoke(neuron.ActivationFunc, neuron.Activation));

            Range.BackEachTrimEnd(Layers, -1, layer =>
            {
                Range.ForEach(layer.Previous.Neurons, neuronPrev =>
                {
                    neuronPrev.Error = Range.SumForEach(layer.Neurons, neuron =>
                    {
                        if (neuronPrev.IsBias)
                        {
                            if (neuron.IsBiasConnected)
                            {
                                return neuron.Error * neuronPrev.WeightTo(neuron).Weight * ActivationFunctionDerivative.Helper.Invoke(neuronPrev.ActivationFunc, neuronPrev.Activation);
                            }
                            else
                            {
                                return neuron.Error * neuronPrev.WeightTo(neuron).Weight * ActivationFunctionDerivative.Helper.Invoke(neuronPrev.ActivationFunc, neuronPrev.Activation);
                            }
                        }
                        else
                        {
                            return neuron.Error * neuronPrev.WeightTo(neuron).Weight * ActivationFunctionDerivative.Helper.Invoke(neuronPrev.ActivationFunc, neuronPrev.Activation);
                        }
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

        public NetworkDataModel Merge(NetworkDataModel newModel)
        {
            newModel.Statistic = Statistic;
            newModel.DynamicStatistic = DynamicStatistic;

            foreach (var newLayer in newModel.Layers)
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

            return newModel;
        }
    }
}
