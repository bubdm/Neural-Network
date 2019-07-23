using Dots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace Tools
{
    public static class RandomizeMode
    {
        public static void Random(NetworkDataModel network, double a)
        {
            foreach (var layer in network.Layers)
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

        public static void FlatProgress(NetworkDataModel network, double a)
        {
            foreach (var layer in network.Layers)
            {
                foreach (var neuron in layer.Neurons)
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

        public static class Helper
        {
            public static string[] GetRandomizers()
            {
                return typeof(RandomizeMode).GetMethods().Where(r => r.IsStatic).Select(r => r.Name).ToArray();
            }

            public static void Invoke(string name, NetworkDataModel N, double a)
            {
                var method = typeof(RandomizeMode).GetMethod(name);
                method.Invoke(null, new object[] { N, a });
            }

            public static void FillComboBox(ComboBox cb, Config config)
            {
                cb.Items.Clear();
                var randomizers = RandomizeMode.Helper.GetRandomizers();
                foreach (var rand in randomizers)
                {
                    cb.Items.Add(rand);
                }
                var randomizer = config.GetString(Const.Param.Randomizer, Config.Main.GetString(Const.Param.Randomizer, randomizers.Any() ? randomizers[0] : null));
                if (randomizers.Any())
                {
                    if (!randomizers.Any(r => r == randomizer))
                    {
                        randomizer = randomizers[0];
                    }
                }
                else
                {
                    randomizer = null;
                }

                if (!String.IsNullOrEmpty(randomizer))
                {
                    cb.SelectedItem = randomizer;
                }
            }
        }
    }
}
