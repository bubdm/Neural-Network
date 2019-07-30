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
            Text = "Randomizer Viewer | " + randomizer;

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

            int alpha = 200;
            int mult = Height / 12;

            int unit = 30;

            var zeroColor = new Pen(Color.FromArgb(100, Color.Gray));
            var rangeColor = new Pen(Color.FromArgb(50, Color.White));

            // get ranges
            var ranges = new Dictionary<int, HashSet<int>>();

            for (int layer = 0; layer < Model.Layers.Count - 1; ++layer)
            {
                ranges[layer] = new HashSet<int>();

                var neuronsCount = Model.Layers[layer].Neurons.Count;
                for (int neuron = 0; neuron < neuronsCount; ++neuron)
                {
                    CtlPresenter.G.DrawLine(zeroColor, left - neuron + layer * 150, top + neuron, 100 + left - neuron + layer * 150, top + neuron);

                    bool hasNextRange = false;

                    for (int weight = 0; weight < Model.Layers[layer].Neurons[neuron].Weights.Count; ++weight)
                    {
                        var value = Model.Layers[layer].Neurons[neuron].Weights[weight].Weight;
                        if (value > 0)
                        {
                            ranges[layer].Add(1);
                        }
                        if (value > 1)
                        {
                            ranges[layer].Add(2);
                        }
                        if (value > 2)
                        {
                            ranges[layer].Add(3);
                        }
                        if (value > 3)
                        {
                            ranges[layer].Add(4);
                        }
                        if (value > 4)
                        {
                            ranges[layer].Add(5);
                        }
                        if (value > 5)
                        {
                            ranges[layer].Add(6);
                        }
                        if (value > 6)
                        {
                            ranges[layer].Add(7);
                        }
                    }
                }
            }

            for (int layer = 0; layer < Model.Layers.Count - 1; ++layer)
            {
                var neuronsCount = Model.Layers[layer].Neurons.Count;
                for (int neuron = 0; neuron < neuronsCount; ++neuron)
                {
                    CtlPresenter.G.DrawLine(zeroColor, left - neuron + layer * 150, top + neuron, 100 + left - neuron + layer * 150, top + neuron);

                    for (int r = 0; r < ranges[layer].Count; ++r)
                    {

                        for (int weight = 0; weight < Model.Layers[layer].Neurons[neuron].Weights.Count; ++weight)
                        {
                            var value = Model.Layers[layer].Neurons[neuron].Weights[weight].Weight;
                            var origValue = value;

                            if (value > 0)
                            {
                                if (value > r + 1)
                                {
                                    value = 1;
                                }
                                else
                                {
                                    value -= r;
                                }
                            }

                            var hover = value == 0 ? 0 : unit * Math.Sign(value);
                            using (var pen = new Pen(Draw.GetColorDradient(Color.Black, origValue >= 0 ? Color.Red : Color.Blue, 200, Math.Abs(origValue) / ranges[layer].Max())))//  .GetPen(origValue, 1, alpha))
                            {
                                if (value > 0 && r > 0)
                                {
                                    CtlPresenter.G.FillEllipse(Brushes.White,
    left - neuron + layer * 150 + weight - 1,
    top + neuron - hover - mult * r - 1,
    3,
    3);
                                }

                                if (value >= 0 || r == 0)
                                {

                                    CtlPresenter.G.DrawLine(pen,
                                                            left - neuron + layer * 150 + weight,
                                                            top + neuron - hover - mult * r,
                                                            left - neuron + layer * 150 + weight,
                                                            top + neuron - hover - (float)(mult * (r + 1) * value));
                                }

                                if ((value < 0 && r == 0) || (value >= 0 && value < 1))
                                {
                                    CtlPresenter.G.FillEllipse(Brushes.Orange,
                                                               left - neuron + layer * 150 + weight - 1,
                                                               top + neuron - hover - (float)(mult * (r + 1) * value),
                                                               2,
                                                               2);
                                }

                            }
                        }



                        if (r < ranges[layer].Count - 1)
                        {
                            CtlPresenter.G.DrawLine(rangeColor, left - neuron + layer * 150, top + neuron - unit - mult * (r + 1), 100 + left - neuron + layer * 150, top + neuron - unit - mult * (r + 1));
                        }
                    }



                }

                CtlPresenter.G.DrawLine(Pens.Black,
                                        left - 105,
                                        top + 100 - unit,
                                        left - 105,
                                        top + 100 - unit - mult);

                CtlPresenter.G.DrawString("1", Font, Brushes.Black,
                                          left - 115,
                                          top + 100 - Font.Height - unit);

                CtlPresenter.Invalidate();
            }


            zeroColor.Dispose();
            rangeColor.Dispose();
        }

        private void RandomViewer_Shown(object sender, EventArgs e)
        {
            Render();
        }
    }
}

/*
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
                        using (var pen = Draw.GetPen(value, 0, alpha))
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

    */