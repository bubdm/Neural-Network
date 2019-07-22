using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tools
{
    public class ListX<T> : List<T> where T : class
    {
        public T RandomElement
        {
            get
            {
                return this[Rand.Flat.Next(Count)];
            }
        }

        public new void Add(T obj)
        {
            if (Count == 0)
            {
                (this as List<T>).Add(obj);
            }
            else if (obj is ListNode<T>)
            {
                var last = this.Last() as ListNode<T>;
                last.Next = obj;
                (obj as ListNode<T>).Previous = this.Last();
                (this as List<T>).Add(obj);
            }
            else
            {
                (this as List<T>).Add(obj);
            }
        }
    }

    public class ListNode<T>// where T : class
    {
        public T Next;
        public T Previous;
    }

    public static class Draw
    {
        public static Color GetColor(double v)
        {
            int s = Math.Sign(v);

            v = Math.Abs(v);

            if (v > 1)
                v = 1;

            if (s >= 0)
                return Color.FromArgb((int)(255 * v), (int)(50 * v), (int)(50 * v));
            else
                return Color.FromArgb((int)(50 * v), (int)(50 * v), (int)(255 * v));
        }

        public static Brush GetBrush(double v)
        {
            return new SolidBrush(GetColor(v));
        }

        public static Pen GetPen(double v, float width = 1)
        {
            return new Pen(new SolidBrush(GetColor(v)), width);
        }

        public static Pen GetPen(Color c, float width = 1)
        {
            return new Pen(new SolidBrush(c), width);
        }

        public static Color GetRandomColor(int offsetFromTop)
        {
            return Color.FromArgb(255 - offsetFromTop + Rand.Flat.Next(offsetFromTop),
                                  255 - offsetFromTop + Rand.Flat.Next(offsetFromTop),
                                  255 - offsetFromTop + Rand.Flat.Next(offsetFromTop));
        }
    }

    public static class Range
    {
        public static IEnumerable<int> Make(int a, int b = 0)
        {
            return a < b ? Enumerable.Range(a, b - a) : Enumerable.Range(b, a - b);
        }

        public static void For(int range, Action<int> action)
        {
            foreach (int y in Make(range))
                action(y);
        }

        public static void ForEach<T>(IEnumerable<T> range, Action<T> action)
        {
            foreach (T y in range)
                action(y);
        }

        public static void BackEach<T>(IEnumerable<T> range, Action<T> action)
        {
            foreach (T y in range.Reverse())
                action(y);
        }

        public static void BackEachTrimEnd<T>(IEnumerable<T> range, int trim, Action<T> action)
        {
            long n = 0;
            range = range.Reverse();
            long count = range.Count();
            foreach (T y in range)
            {
                if (n == count - 1 + trim)
                {
                    break;
                }

                action(y);
                ++n;
            }
        }

        public static void ForEachTrimEnd<T>(IEnumerable<T> range, int trim, Action<T> action)
        {
            long n = 0;
            long count = range.Count();
            foreach (T y in range)
            {
                if (n == count + trim)
                {
                    break;
                }

                action(y);
                ++n;
            }
        }

        public static void Back(int range, Action<int> action)
        {
            foreach (int y in Make(range).Reverse())
                action(y);
        }

        public static void For(int range1, int range2, Action<int, int> action)
        {
            For(range1, y1 => For(range2, y2 => action(y1, y2)));
        }

        public static void ForEach<T1, T2>(IEnumerable<T1> range1, IEnumerable<T2> range2, Action<T1, T2> action)
        {
            ForEach(range1, y1 => ForEach(range2, y2 => action(y1, y2)));
        }

        public static double Sum(int range, Func<int, double> func)
        {
            double s = 0;
            For(range, x => s += func(x));
            return s;
        }

        public static double SumForEach<T>(IEnumerable<T> range, Func<T, double> func)
        {
            double s = 0;
            ForEach(range, x => s += func(x));
            return s;
        }
    }

    public static class Rand
    {
        public static Random Flat = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
        public static GaussianRandom GaussianRand = new GaussianRandom(Flat);

        public static double GetFlatRandom(double upperBound = 1)
        {
            return upperBound * Flat.NextDouble();
        }

        public static double GetSpreadRandom(double lowerBound, double upperBound)
        {
            return -lowerBound + upperBound * Flat.NextDouble();
        }

        public static double GetSpreadInRange(double range)
        {
            return -range/2 + range * Flat.NextDouble();
        }
    }

    public static class Activation
    {
        public static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public static double SigmoidDerivative(double x)
        {
            return x * (1 - x);
        }
    }

    public sealed class GaussianRandom
    {
        private bool _hasDeviate;
        private double _storedDeviate;
        private readonly Random _random;

        public GaussianRandom(Random random = null)
        {
            _random = random ?? new Random((int)(DateTime.Now.Ticks % int.MaxValue));
        }

        /// <summary>
        /// Obtains normally (Gaussian) distributed random numbers, using the Box-Muller
        /// transformation.  This transformation takes two uniformly distributed deviates
        /// within the unit circle, and transforms them into two independently
        /// distributed normal deviates.
        /// </summary>
        /// <param name="mu">The mean of the distribution.  Default is zero.</param>
        /// <param name="sigma">The standard deviation of the distribution.  Default is one.</param>
        /// <returns></returns>
        public double NextGaussian(double mu = 0, double sigma = 1)
        {
            if (sigma <= 0)
                throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");

            if (_hasDeviate)
            {
                _hasDeviate = false;
                return _storedDeviate * sigma + mu;
            }

            double v1, v2, rSquared;
            do
            {
                // two random values between -1.0 and 1.0
                v1 = 2 * _random.NextDouble() - 1;
                v2 = 2 * _random.NextDouble() - 1;
                rSquared = v1 * v1 + v2 * v2;
                // ensure within the unit circle
            } while (rSquared >= 1 || rSquared == 0);

            // calculate polar tranformation for each deviate
            var polar = Math.Sqrt(-2 * Math.Log(rSquared) / rSquared);
            // store first deviate
            _storedDeviate = v2 * polar;
            _hasDeviate = true;
            // return second deviate
            return v1 * polar * sigma + mu;
        }
    }

    public static class Uniq
    {
        public static double[] GetUniq(double spread, long count)
        {
            var result = new double[count];

            double step = 1 / (double)count;
            double a = step;

            for (long c = 0; c < count; ++c)
            {
                result[c] = spread * a;// (Math.Pow(a, 6) + a / spread);
                a += step;
            }

            return result;
        }
    }

    public static class Notification
    {
        public enum ParameterChanged
        {
            Randomizer,
            Structure
        }
    }
}   