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
                Range.For(Const.DefaultOutputNeuronsCount, c => AddNeuron(Const.UnknownId));
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron(Const.UnknownId);
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
            LayerConfig.Extend(Const.OutputLayerId).Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        public List<OutputNeuronControl> GetNeuronsControls()
        {
            return Controls.OfType<OutputNeuronControl>().ToList();
        }
    }
}
