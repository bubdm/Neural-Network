using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Dots
{
    public class Network
    {
        public Layer[] L;
        public double LearningRate = 0.05;

        public Network(int[] layersSize)
        {
            var list = new List<Layer>();

            Range.For(layersSize.Length, n =>
                CreateLayer(layersSize[n], n < layersSize.Length - 1 ? layersSize[n + 1] : 0, list));

            L = list.ToArray();
        }

        public void CreateLayer(int l, int nextl, List<Layer> list)
        {
            if (l > 0)
                list.Add(new Layer(list.Count(), l, nextl));
        }

        public double Cost(int x)
        {
            return Range.Sum(L.Last().Height, y => Math.Pow(L.Last().A[y] - (y == x ? 1 : 0), 2));
        }

        public long WeightsCount()
        {
            long count = L[0].Height;

            for (int l = 1; l < L.Length; ++l)
            {
                count *= L[l].Height;
            }

            return count;
        }


        public void RandomizeWeights(string randomizer)
        {
            MethodInfo method = typeof(RandomizeMode).GetMethod(randomizer);
            method.Invoke(null, new object[] { this });

            //RandDefault();
        }

        private double GetRand()
        {
            return -3 + 6 * Rand.Flat.NextDouble();
        }

        private void RandHe()
        {
            Range.For(L.Length, l =>
            {
                Range.For(L[l].Height, L[l].Width, (y, x) =>
                {
                    if (l > 0)
                        L[l].W[y, x] = Math.Abs(GetRand() * Math.Sqrt(2 / L[l - 1].Height));
                    else
                        L[l].W[y, x] = GetRand();
                });
            });
        }

        private void RandDefault()
        {
            Range.For(L.Length, l =>
            {
                Range.For(L[l].Height, L[l].Width, (y, x) =>
                {
                    if (l % 2 == 0)
                    {
                        L[l].W[y, x] = GetRand() * (1 / ((double)x + (double)y + 1));
                    }
                    else
                    {
                        L[l].W[y, x] = GetRand() * (1 - 1 / ((double)x + (double)y + 1));
                    }
                });
            });
        }

        private void RandDefault2()
        {
            double c = 0;

            Range.For(L.Length, l =>
            {
                Range.For(L[l].Height, L[l].Width, (y, x) =>
                {
                    if (l % 2 == 0)
                    {
                        L[l].W[y, x] = GetRand() * (1 / (c + 1));
                    }
                    else
                    {
                        L[l].W[y, x] = GetRand() * (1 - 1 / (c + 1));
                    }

                    ++c;

                });
            });
        }

        private void UniqValues()
        {
            var values = Uniq.GetUniq(2, WeightsCount());

            long prevCount = 0;

            Range.For(L.Length - 1, l =>
            {
                var part = new double[L[l].Height * L[l + 1].Height];
                Array.Copy(values, prevCount, part, 0, part.Length);
                prevCount = part.Length;
                
                part = part.OrderBy(x => Rand.Flat.Next()).ToArray();
                long c = 0;
                for (c = 0; c < part.Length; c += 2)
                {
                    part[c] *= -1; 
                }

                c = 0;
                Range.For(L[l].Height, L[l].Width, (y, x) =>
                {
                    L[l].W[y, x] = part[c];
                    ++c;
                });
            });
        }

        public void RandFlatInput()
        {
            Range.For(L[0].Height, L[0].Width, (y, x) =>
            {
                L[0].W[y, x] = 0.01;
            });
        }

        public void RandLinerInput()
        {
            Range.For(L[0].Height, L[0].Width, (y, x) =>
            {
                L[0].W[y, x] = 1 / (x + y + 1);
            });
        }

        public void ClearErrors()
        {
            Range.For(L.Length, n => L[n].ClearErrors());
        }

        public Tuple<int, double> GetOutValue()
        {
            double max = int.MinValue;
            int n = -1;
            Range.For(L.Last().Height, y =>
            {
                if (L.Last().A[y] > max)
                {
                    max = L.Last().A[y];
                    n = y;
                }
            });

            return new Tuple<int, double>(n, max);
        }

        public void FeedForward()
        {
            Range.For(L[0].Height, y => L[0].A[y] = 0);
            Range.For(Rand.Flat.Next(11), i => L[0].A[Rand.Flat.Next(L[0].Height)] = 1);

            Range.For(L.Length - 1, n =>
            Range.For(L[n + 1].Height, y2 => L[n + 1].A[y2] = Activation.Sigmoid(Range.Sum(L[n].Height, y1 => L[n].AxW(y1, y2)))));
        }

        public void BackPropagation()
        {
            var number = L[0].A.Sum();

            // backpropogation

            ClearErrors();
            Range.For(L.Last().Height, y =>
            L.Last().E[y] = ((y == number ? 1 : 0) - L.Last().A[y]) * Activation.SigmoidDerivative(L.Last().A[y]));

            Range.Back(L.Length, n =>
            {
                if (n > 0)
                {
                    Range.For(L[n - 1].Height, ycurr =>
                        L[n - 1].E[ycurr] = Range.Sum(L[n].Height, ynext =>
                            L[n].E[ynext] * L[n - 1].W[ycurr, ynext] * Activation.SigmoidDerivative(L[n - 1].A[ycurr])));
                }
            });

            // update weights

            Range.Back(L.Length, n =>
            {
                if (n > 0)
                {
                    Range.For(L[n - 1].Height, L[n].Height, (ycurr, ynext) => L[n - 1].W[ycurr, ynext] += L[n].E[ynext] * L[n - 1].A[ycurr] * LearningRate);
                }
            });
        }
    }
}
