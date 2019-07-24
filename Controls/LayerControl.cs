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

        public Config Config;
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
            Config = config.Extend(Id);

            var neurons = Config.GetArray(Const.Param.Neurons);
            Range.ForEach(neurons, n => AddNeuron(n));
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

        public List<NeuronControl> GetNeuronsControls()
        {
            return Controls.OfType<NeuronControl>().ToList();
        }

        public int NeuronsCount => GetNeuronsControls().Count;

        public void SaveConfig()
        {
            var neurons = GetNeuronsControls();
            Config.Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        public void VanishConfig()
        {
            Config.Remove(Const.Param.Neurons);
            Range.ForEach(GetNeuronsControls(), n => n.VanishConfig());
        }
    }
}
