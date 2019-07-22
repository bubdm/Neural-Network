using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Dots
{
    public class NeuronDataModel : ListNode<NeuronDataModel>
    {
        public int Id;
        public double Activation; // activation
        public double E; // error
        public ListX<WeightDataModel> Weights;

        public NeuronDataModel(int id, int weightsCount)
        {
            Id = id;
            Weights = new ListX<WeightDataModel>();
            Range.For(weightsCount, n => Weights.Add(new WeightDataModel(n)));
        }

        public double AxW(NeuronDataModel neuron)
        {
            return Activation * WeightTo(neuron).Weight;
        }

        public WeightDataModel WeightTo(NeuronDataModel neuron)
        {
            return Weights[neuron.Id];
        }
    }

    public class WeightDataModel : ListNode<WeightDataModel>
    {
        public int Id;
        public double Weight;

        public WeightDataModel(int id)
        {
            Id = id;
        }

        public void Add(double w)
        {
            Weight += w;
        }
    }
}
