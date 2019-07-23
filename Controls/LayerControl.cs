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
    public partial class LayerControl : UserControl
    {
        public readonly long Id;

        Config LayerConfig;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public LayerControl()
        {
            InitializeComponent();
        }

        public LayerControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;
            Id = id;
            LayerConfig = config;

            var neurons = LayerConfig.Extend(Id).GetArray(Const.Param.Neurons);
            for (int i = 0; i < neurons.Length; ++i)
            {
                AddNeuron(neurons[i]);
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
            var neuron = new NeuronControl(id, LayerConfig, OnNetworkUIChanged);            
            Controls.Add(neuron);
            neuron.BringToFront();
        }

        private List<NeuronControl> GetNeuronsControls()
        {
            var result = new List<NeuronControl>();
            for (int i = 0; i < Controls.Count; ++i)
            {
                if (Controls[i] is NeuronControl neuron)
                {
                    result.Add(neuron);
                }
            }
            return result;
        }

        public void SaveConfig()
        {
            var neurons = GetNeuronsControls();
            LayerConfig.Extend(Id).Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, neuron => neuron.SaveConfig());
        }

        public void VanishConfig()
        {
            LayerConfig.Extend(Id).Remove(Const.Param.Neurons);
            var neurons = GetNeuronsControls();
            foreach (var neuron in neurons)
            {
                neuron.VanishConfig();
            }
        }
    }
}
