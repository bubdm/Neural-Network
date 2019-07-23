using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Activation
    {
        public static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }

    public static class Derivative
    {
        public static double Sigmoid(double x)
        {
            return x * (1 - x);
        }
    }
}
