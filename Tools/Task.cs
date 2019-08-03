using NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace Tools
{
    public static class NetworkTask
    {
        static Dictionary<int, double[]> _arrays = new Dictionary<int, double[]>();

        public static void CountDotsSymmetric(NetworkDataModel model)
        {
            int bound = 10;

            int number = Rand.Flat.Next(bound + 1);
            if (number == 0)
            {
                return;
            }

            if (!_arrays.ContainsKey(bound))
            {
                _arrays.Add(bound, new double[bound]);
            }

            for (int i = 0; i < _arrays[bound].Length; ++i)
            {
                _arrays[bound][i] = i < number ? model.InputInitial1 : model.InputInitial0;
            }

            var shaffle = _arrays[bound].OrderBy(a => Rand.Flat.Next()).ToArray();

            int k = 0;
            Range.ForEach(model.Layers.First().Neurons.Where(n => !n.IsBias), n => n.Activation = shaffle[k++]);
        }

        public static void CountDotsAsymmetric(NetworkDataModel model)
        {
            Range.For(Rand.Flat.Next(11), i => model.Layers.First().Neurons.RandomElementTrimEnd(model.Layers.First().BiasCount).Activation = model.InputInitial1);
        }

        public static class Helper
        {
            public static string[] GetItems()
            {
                return typeof(NetworkTask).GetMethods().Where(r => r.IsStatic).Select(r => r.Name).ToArray();
            }

            public static void Invoke(string name, NetworkDataModel model)
            {
                var method = typeof(NetworkTask).GetMethod(name);
                method.Invoke(null, new object[] { model });
            }

            public static void FillComboBox(ComboBox cb, Config config, Const.Param param, string defaultValue)
            {
                Initializer.FillComboBox(typeof(NetworkTask.Helper), cb, config, param, defaultValue);
            }
        }
    }

    public static class NetworkTaskResult
    {
        public static class Helper
        {
            public static double Invoke(string name, double a)
            {
                var method = typeof(NetworkTaskResult).GetMethod(name);
                return (double)method.Invoke(null, new object[] { a });
            }
        }
    }
}
