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
    public partial class HiddenLayerControl : LayerBase
    {
        public HiddenLayerControl()
        {
            InitializeComponent();
        }

        public HiddenLayerControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(id, config, onNetworkUIChanged)
        {
            InitializeComponent();

            var neurons = Config.GetArray(Const.Param.Neurons);
            if (neurons.Length == 0)
            {
                neurons = new long[] { Const.UnknownId }; 
            }
            Range.ForEach(neurons, n => AddNeuron(n));
        }

        public override bool IsHidden => true;
        public override int NeuronsCount => GetNeuronsControls().Count;

        public override List<NeuronBase> GetNeuronsControls()
        {
            return Controls.OfType<NeuronBase>().ToList();
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron(Const.UnknownId);
        }

        public void AddNeuron(long id)
        {
            var neuron = new NeuronControl(id == Const.UnknownId ? DateTime.Now.Ticks : id, Config, OnNetworkUIChanged);            
            Controls.Add(neuron);
            neuron.BringToFront();

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
