using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace Dots.Controls
{
    public partial class OutputLayerControl : UserControl
    {
        Config LayerConfig;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public OutputLayerControl()
        {
            InitializeComponent();
        }

        public OutputLayerControl(Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;
            LayerConfig = config;

            var neurons = LayerConfig.Extend(Const.OutputLayerId).GetArray(Const.Param.Neurons);
            Range.ForEach(neurons, n => AddNeuron(neurons[n]));

            if (neurons.Length == 0)
            {
                var count = Config.Main.GetInt(Const.Param.DefaultOutputNeuronsCount, 10);
                Range.For(count, c => AddNeuron(-1));
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron(-1);
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void AddNeuron(long id)
        {
            id = id == Const.UnknownId ? DateTime.Now.Ticks : id;
            var neuron = new OutputNeuronControl(id, LayerConfig, OnNetworkUIChanged);
            Controls.Add(neuron);
            neuron.BringToFront();
        }

        public void SaveConfig()
        {
            var neurons = GetNeuronsControls();
            LayerConfig.Extend(Const.OutputLayerId).Set(Const.Param.NeuronsCount, neurons.Count);
            LayerConfig.Extend(Const.OutputLayerId).Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        private List<OutputNeuronControl> GetNeuronsControls()
        {
            return Controls.OfType<OutputNeuronControl>().ToList();
        }
    }
}
