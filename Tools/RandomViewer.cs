using NN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class RandomViewer : Form
    {
        string Randomizer;
        double? A;
        double Mult;

        NetworkDataModel Model = new NetworkDataModel(new int[] { 100, 100, 100, 100, 100, 100 });

        public RandomViewer()
        {
            InitializeComponent();
        }

        public RandomViewer(string randomizer, double? a)
        {
            InitializeComponent();

            Randomizer = randomizer;
            A = a;

            RandomizeMode.Helper.Invoke(Randomizer, Model, A);

            CtlPresenter.Width = Screen.PrimaryScreen.Bounds.Width;
            CtlPresenter.Height = Screen.PrimaryScreen.Bounds.Height;
            CtlPresenter.Left = Width / 2 - CtlPresenter.Width / 2;
            CtlPresenter.Top = Height / 2 - CtlPresenter.Height / 2;

            CtlPresenter.StartRender();
        }

        private void Render()
        { 
            int left = 3 + (CtlPresenter.Width / 2) - ((Model.Layers.Count - 1) * 125) / 2;
            int top = (CtlPresenter.Height / 2) - Model.Layers[0].Height / 2  - 30;
            int distance = 50;

            int alpha = 100;
            int mult = Height / 12;

            var zeroColor = new Pen(Color.FromArgb(alpha, Color.Gray));

            for (int layer = 0; layer < Model.Layers.Count - 1; ++layer)
            {
                var neuronsCount = Model.Layers[layer].Neurons.Count;
                for (int neuron = 0; neuron < neuronsCount; ++neuron)
                {
                    CtlPresenter.G.DrawLine(zeroColor, left - neuron + layer * 150, top + neuron, 100 + left - neuron + layer * 150, top + neuron);

                    for (int weight = 0; weight < Model.Layers[layer].Neurons[neuron].Weights.Count; ++weight)
                    {
                        var value = Model.Layers[layer].Neurons[neuron].Weights[weight].Weight;
                        var hover = value == 0 ? 0 : 30 * Math.Sign(value);
                        using (var pen = Draw.GetPen(value, value == 0 ? 1 : 2, alpha))
                        {
                            CtlPresenter.G.DrawLine(pen,
                                                    left - neuron + layer * 150 + weight,
                                                    top + neuron - hover,
                                                    left - neuron + layer * 150 + weight,
                                                    top + neuron - hover - (float)(mult * value));

                            CtlPresenter.G.FillEllipse(Brushes.Orange,
                                                       left - neuron + layer * 150 + weight - 1,
                                                       top + neuron - hover - (float)(mult * value),
                                                       2,
                                                       2);
                        }
                    }
                }

                CtlPresenter.G.DrawLine(Pens.Black,
                                        left - 105,
                                        top + 100 - 30,
                                        left - 105,
                                        top + 100 - 30 - mult);

                CtlPresenter.G.DrawString("1", Font, Brushes.Black,
                                          left - 115,
                                          top + 100 - Font.Height - 30);

                CtlPresenter.Invalidate();
            }

            zeroColor.Dispose();
        }

        private void RandomViewer_Shown(object sender, EventArgs e)
        {
            Render();
        }
    }
}
