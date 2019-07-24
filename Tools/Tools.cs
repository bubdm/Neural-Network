using Dots.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tools
{
    public static class Mapping
    {
        public static Dictionary<long, NeuronControl> NeuronsMap = new Dictionary<long, NeuronControl>();
        public static Dictionary<long, OutputNeuronControl> OutputNeuronsMap = new Dictionary<long, OutputNeuronControl>();

        public static void Clear()
        {
            NeuronsMap.Clear();
            OutputNeuronsMap.Clear();
        }
    }
}   