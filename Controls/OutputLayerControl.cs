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
        public Config Config;
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
            Config = config.Extend(Const.OutputLayerId);

            var neurons = Config.GetArray(Const.Param.Neurons);
            Range.ForEach(neurons, n => AddNeuron(n));

            if (neurons.Length == 0)
            {
                Range.For(Const.DefaultOutputNeuronsCount, c => AddNeuron(Const.UnknownId));
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron(Const.UnknownId);          
        }

        public void AddNeuron(long id)
        {
            var neuron = new OutputNeuronControl(id == Const.UnknownId ? DateTime.Now.Ticks : id, Config, OnNetworkUIChanged);
            Controls.Add(neuron);
            neuron.BringToFront();

            if (id == Const.UnknownId)
            {
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public void ValidateConfig()
        {
            var neurons = GetNeuronsControls();
            Range.ForEach(neurons, n => n.ValidateConfig());
        }

        public void SaveConfig()
        {
            var neurons = GetNeuronsControls();
            Config.Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        public List<OutputNeuronControl> GetNeuronsControls()
        {
            return Controls.OfType<OutputNeuronControl>().ToList();
        }

        public int NeuronsCount => GetNeuronsControls().Count;
    }
}
