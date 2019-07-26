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
    public partial class InputLayerControl : LayerBase
    {
        public InputLayerControl(Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(Const.InputLayerId, config, onNetworkUIChanged)
        {
            InitializeComponent();

            LoadConfig();

            CtlInputCount.ValueChanged += CtlInputCount_ValueChanged;
        }

        public override bool IsInput => true;

        private void CtlInputCount_ValueChanged(object sender, EventArgs e)
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void LoadConfig()
        {
            CtlInputCount.Minimum = Config.Main.GetInt(Const.Param.InputNeuronsMinCount, 10);
            CtlInputCount.Maximum = Config.Main.GetInt(Const.Param.InputNeuronsMaxCount, 10000);
            CtlInputCount.Value = Config.GetInt(Const.Param.InputNeuronsCount, Const.DefaultInputNeuronsCount);

            var neurons = Config.GetArray(Const.Param.Neurons);
            if (neurons.Length == 0)
            {
                neurons = new long[] { Const.UnknownId };
            }
            Range.For((int)CtlInputCount.Value, n => AddNeuron());
        }

        public void AddNeuron()
        {
            var neuron = new InputNeuronControl();
            CtlFlow.Controls.Add(neuron);
        }

        public void AddBias(long id)
        {
            var neuron = new BiasControl(id == Const.UnknownId ? DateTime.Now.Ticks : id, Config, OnNetworkUIChanged);
            CtlFlow.Controls.Add(neuron);

            if (id == Const.UnknownId)
            {
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }

        public override void ValidateConfig()
        {

        }

        public override void SaveConfig()
        {
             Config.Set(Const.Param.InputNeuronsCount, (int)CtlInputCount.Value);
        }

        public override void VanishConfig()
        {
            
        }

        private void CtlMenuAddBias_Click(object sender, EventArgs e)
        {
            AddBias(Const.UnknownId);
        }
    }
}
