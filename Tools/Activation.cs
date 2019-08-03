using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public static class ActivationFunction
    {
        public static double None(double x)
        {
            return x;
        }

        public static double LogisticSigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));

            //2/​(1+​exp(​(‑x)*​4))-​1
        }

        public static class Helper
        {
            public static string[] GetItems()
            {
                return typeof(ActivationFunction).GetMethods().Where(r => r.IsStatic).Select(r => r.Name).ToArray();
            }

            public static double Invoke(string name, double a)
            {
                if (name == nameof(None))
                {
                    return a;
                }

                var method = typeof(ActivationFunction).GetMethod(name);
                return (double)method.Invoke(null, new object[] { a });
            }

            public static void FillComboBox(ComboBox cb, Config config, Const.Param param, string defaultValue)
            {
                Initializer.FillComboBox(typeof(ActivationFunction.Helper), cb, config, param, defaultValue, "GetItems");
            }
        }
    }

    public static class ActivationFunctionDerivative
    {
        public static double None(double x)
        {
            return x;
        }

        public static double LogisticSigmoid(double x)
        {
            return x * (1 - x);
        }

        public static class Helper
        {
            public static double Invoke(string name, double a)
            {
                if (name == nameof(None))
                {
                    return a;
                }

                var method = typeof(ActivationFunctionDerivative).GetMethod(name);
                return (double)method.Invoke(null, new object[] { a });
            }
        }
    }
}
