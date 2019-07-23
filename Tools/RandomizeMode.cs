using Dots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Randomize
{
    static class RandomizeMode
    {
        public static void SimpleFlat(NetworkDataModel N)
        {
            foreach (var layer in N.Layers)
            {
                foreach (var neuron in layer.Neurons)
                {
                    foreach (var weight in neuron.Weights)
                    {
                        weight.Weight = Rand.GetFlatRandom();
                    }
                }
            }
        }

        public static void FlatProgress(NetworkDataModel N)
        {
            foreach (var layer in N.Layers)
            {
                foreach(var neuron in layer.Neurons)
                {
                    foreach (var weight in neuron.Weights)
                    {
                        if (layer.Id % 2 == 0)
                        {
                            weight.Weight = Rand.GetSpreadInRange(6) * (1 / ((double)neuron.Id + (double)weight.Id + 1));
                        }
                        else
                        {
                            weight.Weight = Rand.GetSpreadInRange(6) * (1 - 1 / ((double)neuron.Id + (double)weight.Id + 1));
                        }
                    }
                }
            }
        }
    }

    static class Helper
    {
        public static string[] GetRandomizers()
        {
            return typeof(RandomizeMode).GetMethods().Where(r => r.IsStatic).Select(r => r.Name).ToArray();
        }

        public static void Invoke(string name, NetworkDataModel N)
        {
            MethodInfo method = typeof(RandomizeMode).GetMethod(name);
            method.Invoke(null, new object[] { N });
        }
    }
}
