using NN;
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
    public static class InitializeMode
    {
        public static double DoNotApply(double? a)
        {
            return Const.InitializerSkipValue;
        }

        public static double Constant(double? a)
        {
            if (!a.HasValue)
            {
                a = 0;
            }
            return a.Value;
        }

        public static double SimpleRandom(double? a)
        {
            if (!a.HasValue)
            {
                a = 1;
            }
            return a.Value * Rand.GetFlatRandom();
        }

        public static double Centered(double? a)
        {
            if (!a.HasValue)
            {
                a = 1;
            }
            return -a.Value/2 + a.Value * Rand.GetFlatRandom();
        }

        public static class Helper
        {
            public static bool IsSkipValue(double d)
            {
                return double.IsNaN(d);
            }

            public static string[] GetInitializers()
            {
                return typeof(InitializeMode).GetMethods().Where(r => r.IsStatic).Select(r => r.Name).ToArray();
            }

            public static double Invoke(string name, double? a)
            {
                var method = typeof(InitializeMode).GetMethod(name);
                return (double)method.Invoke(null, new object[] { a });
            }

            public static void FillComboBox(ComboBox cb, Config config, Const.Param param, string defaultValue)
            {
                cb.Items.Clear();
                var initializers = InitializeMode.Helper.GetInitializers();
                foreach (var init in initializers)
                {
                    cb.Items.Add(init);
                }
                var initializer = config.GetString(param, !String.IsNullOrEmpty(defaultValue) ? defaultValue : initializers.Any() ? initializers[0] : null);
                if (initializers.Any())
                {
                    if (!initializers.Any(r => r == initializer))
                    {
                        initializer = initializers[0];
                    }
                }
                else
                {
                    initializer = null;
                }

                if (!String.IsNullOrEmpty(initializer))
                {
                    cb.SelectedItem = initializer;
                }
            }
        }
    }
}
