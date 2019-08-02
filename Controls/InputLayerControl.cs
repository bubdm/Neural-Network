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
        public InputLayerControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(id, config, onNetworkUIChanged)
        {
            InitializeComponent();
            CtlHeadPanel.Visible = true;
            CtlHeadPanel.SendToBack();

            LoadConfig();

            CtlInputCount.ValueChanged += CtlInputCount_ValueChanged;
            CtlInitial0.Changed += ParameterChanged;
            CtlInitial1.Changed += ParameterChanged;
            CtlActivationFunc.SelectedIndexChanged += CtlActivationFunc_SelectedIndexChanged;
        }

        private void ParameterChanged()
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlActivationFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlActivationFuncLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        public override bool IsInput => true;
        public override int NeuronsCount => (int)(CtlInputCount.Value + GetNeuronsControls().Count(n => n.IsBias));

        public double Initial0 => CtlInitial0.Value;
        public double Initial1 => CtlInitial1.Value;
        public string ActivationFunc => CtlActivationFunc.SelectedItem.ToString();

        private void CtlInputCount_ValueChanged(object sender, EventArgs e)
        {
            var controls = CtlFlow.Controls.OfType<InputNeuronControl>().ToList();
            foreach (var control in controls)
            {
                CtlFlow.Controls.Remove(control);
            }          
            Range.For((int)CtlInputCount.Value, n => CtlFlow.Controls.SetChildIndex(AddNeuron(), 0));
            OnNetworkUIChanged(Notification.ParameterChanged.NeuronsCount, null);
        }

        private void LoadConfig()
        {
            CtlInputCount.Minimum = Config.Main.GetInt(Const.Param.InputNeuronsMinCount, 10).Value;
            CtlInputCount.Maximum = Config.Main.GetInt(Const.Param.InputNeuronsMaxCount, 10000).Value;
            CtlInputCount.Value = Config.GetInt(Const.Param.InputNeuronsCount, Const.DefaultInputNeuronsCount).Value;

            ActivationFunction.Helper.FillComboBox(CtlActivationFunc, Config, Const.Param.InputActivationFunc, nameof(ActivationFunction.None));
            CtlInitial0.Load(Config);
            CtlInitial1.Load(Config);

            Range.For((int)CtlInputCount.Value, n => AddNeuron());

            var neurons = Config.GetArray(Const.Param.Neurons);
            Range.ForEach(neurons, n => AddBias(n));
        }

        public InputNeuronControl AddNeuron()
        {
            var neuron = new InputNeuronControl(CtlFlow.Controls.Count);
            CtlFlow.Controls.Add(neuron);
            return neuron;
        }

        public override void AddNeuron(long id)
        {
            AddBias(id);
        }

        public void AddBias(long id)
        {
            var neuron = new InputBiasControl(id, Config, OnNetworkUIChanged);
            CtlFlow.Controls.Add(neuron);

            if (id == Const.UnknownId)
            {
                OnNetworkUIChanged(Notification.ParameterChanged.NeuronsCount, null);
            }
        }

        public override bool IsValid()
        {
            bool result = CtlInitial0.IsValid() && CtlInitial1.IsValid();
            return result &= GetNeuronsControls().All(n => n.IsValid());
        }

        public override void SaveConfig()
        {
            Config.Set(Const.Param.InputNeuronsCount, (int)CtlInputCount.Value);
            Config.Set(Const.Param.InputActivationFunc, CtlActivationFunc.SelectedItem.ToString());
            CtlInitial0.Save(Config);
            CtlInitial1.Save(Config);

            var neurons = GetNeuronsControls().Where(n => n.IsBias);
            Config.Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        public override void VanishConfig()
        {
            Config.Remove(Const.Param.InputNeuronsCount);
            Config.Remove(Const.Param.Neurons);
            CtlInitial0.Vanish(Config);
            CtlInitial1.Vanish(Config);
            Config.Remove(Const.Param.InputActivationFunc);
            Range.ForEach(GetNeuronsControls(), n => n.VanishConfig());
        }

        private void CtlMenuAddBias_Click(object sender, EventArgs e)
        {
            AddBias(Const.UnknownId);
        }
    }
}
