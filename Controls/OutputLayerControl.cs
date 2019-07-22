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
        int Id = 1;
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

            var neurons = LayerConfig.Extend(Id).GetArray(Config.Param.Neurons);
            for (int i = 0; i < neurons.Length; ++i)
            {
                AddNeuron(neurons[i]);
            }

            if (neurons.Length == 0)
            {
                var count = Config.Main.GetInt(Config.Param.OutputNeuronsCount, 10);
                for (int i = 0; i < count; ++i)
                {
                    AddNeuron(-1);
                }
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron(-1);
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void AddNeuron(long id)
        {
            id = id == -1 ? DateTime.Now.Ticks : id;
            var neuron = new OutputNeuronControl(id, LayerConfig, OnNetworkUIChanged);
            Controls.Add(neuron);
            neuron.BringToFront();
        }

        public void SaveConfig()
        {
            var neurons = GetNeuronsControls();
            LayerConfig.Extend(Id).Set(Config.Param.OutputNeuronsCount, neurons.Count);
            foreach (var neuron in neurons)
            {
                neuron.SaveConfig();
            }
            LayerConfig.Extend(Id).Set(Config.Param.Neurons, String.Join(",", neurons.Select(n => n.Id)));
        }

        private List<OutputNeuronControl> GetNeuronsControls()
        {
            var result = new List<OutputNeuronControl>();
            for (int i = 0; i < Controls.Count; ++i)
            {
                if (Controls[i] is OutputNeuronControl neuron)
                {
                     result.Add(neuron);
                }
            }
            return result;
        }
    }
}
