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

namespace NN.Controls
{
    public partial class OutputLayerControl : LayerBase
    {
        public OutputLayerControl()
        {
            InitializeComponent();
        }

        public OutputLayerControl(Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(Const.OutputLayerId, config, onNetworkUIChanged)
        {
            InitializeComponent();

            var neurons = Config.GetArray(Const.Param.Neurons);
            Range.ForEach(neurons, n => AddNeuron(n));

            if (neurons.Length == 0)
            {
                Range.For(Const.DefaultOutputNeuronsCount, c => AddNeuron(Const.UnknownId));
            }
        }

        public override bool IsOutput => true;

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron(Const.UnknownId);          
        }

        public void AddNeuron(long id)
        {
            var neuron = new OutputNeuronControl(id == Const.UnknownId ? DateTime.Now.Ticks : id, Config, OnNetworkUIChanged);
            CtlFlow.Controls.Add(neuron);

            if (id == Const.UnknownId)
            {
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public override void ValidateConfig()
        {
            var neurons = GetNeuronsControls();
            Range.ForEach(neurons, n => n.ValidateConfig());
        }

        public override void SaveConfig()
        {
            var neurons = GetNeuronsControls();
            Config.Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        public override void VanishConfig()
        {
            Config.Remove(Const.Param.Neurons);
            Range.ForEach(GetNeuronsControls(), n => n.VanishConfig());
        }
    }
}
