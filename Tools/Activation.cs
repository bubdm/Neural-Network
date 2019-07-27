using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public static class Activation
    {
        public static double LogisticSigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public static class Helper
        {
            public static string[] GetActivations()
            {
                return typeof(Activation).GetMethods().Where(r => r.IsStatic).Select(r => r.Name).ToArray();
            }

            public static void Invoke(string name, double a)
            {
                var method = typeof(Activation).GetMethod(name);
                method.Invoke(null, new object[] { a });
            }

            public static void FillComboBox(ComboBox cb, Config config)
            {
                cb.Items.Clear();
                var activations = Activation.Helper.GetActivations();
                foreach (var act in activations)
                {
                    cb.Items.Add(act);
                }
                var activation = config.GetString(Const.Param.Randomizer, Config.Main.GetString(Const.Param.Randomizer, activations.Any() ? activations[0] : null));
                if (activations.Any())
                {
                    if (!activations.Any(r => r == activation))
                    {
                        activation = activations[0];
                    }
                }
                else
                {
                    activation = null;
                }

                if (!String.IsNullOrEmpty(activation))
                {
                    cb.SelectedItem = activation;
                }
            }
        }
    }

    public static class Derivative
    {
        public static double LogisticSigmoid(double x)
        {/*
            if (x == 0)
            {
                x += 0.0001;
            }
            if (x == 1)
            {
                x -= 0.0001;
            }
            */
            return x * (1 - x);
        }

        public static class Helper
        {
            public static void Invoke(string name, double a)
            {
                var method = typeof(Derivative).GetMethod(name);
                method.Invoke(null, new object[] { a });
            }
        }
    }
}
