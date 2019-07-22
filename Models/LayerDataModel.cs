﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Dots
{
    public class LayerDataModel : ListNode<LayerDataModel>
    {
        public int Id;
        public ListX<NeuronDataModel> Neurons;

        public LayerDataModel(int id, int neuronsCount, int weightsCount)
        {
            Id = id;

            Neurons = new ListX<NeuronDataModel>();
            Range.For(neuronsCount, n => Neurons.Add(new NeuronDataModel(n, weightsCount)));            
        }

        public int Height => Neurons.Count;
        public int Width => Neurons.First().Weights.Count;
        /*
        public double AxW(int neuron, int weight)
        {
            return Neurons.ElementAt(neuron).AxW(weight);
        }
        */
        public void ClearErrors()
        {
            foreach (var neuron in Neurons)
            {
                neuron.E = 0;
            }
        }
    }
}