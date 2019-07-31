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
            CtlHeadPanel.Visible = true;
            CtlHeadPanel.SendToBack();

            LoadConfig();

            CtlInputCount.ValueChanged += CtlInputCount_ValueChanged;
            CtlInitial0.TextChanged += CtlInitial0_TextChanged;
            CtlInitial1.TextChanged += CtlInitial1_TextChanged;
            CtlActivationFunc.SelectedIndexChanged += CtlActivationFunc_SelectedIndexChanged;
        }

        private void CtlActivationFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlActivationFuncLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlInitial1_TextChanged(object sender, EventArgs e)
        {
            CtlInitial1.BackColor = IsValidInitial1() ? Color.White : Color.Tomato;
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlInitial0_TextChanged(object sender, EventArgs e)
        {
            CtlInitial0.BackColor = IsValidInitial0() ? Color.White : Color.Tomato;
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        public override bool IsInput => true;
        public override int NeuronsCount => (int)(CtlInputCount.Value + GetNeuronsControls().Count(n => n.IsBias));

        public double Initial0 => Converter.TextToDouble(CtlInitial0.Text, 0);
        public double Initial1 => Converter.TextToDouble(CtlInitial1.Text, 1);
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
            CtlInputCount.Minimum = Config.Main.GetInt(Const.Param.InputNeuronsMinCount, 10);
            CtlInputCount.Maximum = Config.Main.GetInt(Const.Param.InputNeuronsMaxCount, 10000);
            CtlInputCount.Value = Config.GetInt(Const.Param.InputNeuronsCount, Const.DefaultInputNeuronsCount);

            ActivationFunction.Helper.FillComboBox(CtlActivationFunc, Config, Const.Param.InputActivationFunc, nameof(ActivationFunction.None));
            CtlInitial0.Text = Config.GetString(Const.Param.InputInitial0, "0");
            CtlInitial1.Text = Config.GetString(Const.Param.InputInitial1, "1");


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
            var neuron = new InputBiasControl(id == Const.UnknownId ? DateTime.Now.Ticks : id, Config, OnNetworkUIChanged);
            CtlFlow.Controls.Add(neuron);

            if (id == Const.UnknownId)
            {
                OnNetworkUIChanged(Notification.ParameterChanged.NeuronsCount, null);
            }
        }

        public bool IsValidInitial0()
        {
            return Converter.TryTextToDouble(CtlInitial0.Text, out double? result);
        }

        public bool IsValidInitial1()
        {
            return Converter.TryTextToDouble(CtlInitial1.Text, out double? result);
        }

        public override bool IsValid()
        {
            bool result = IsValidInitial0() && IsValidInitial1();
            var neurons = GetNeuronsControls();
            Range.ForEach(neurons, n => result &= n.IsValid());
            return result;
        }

        public override void SaveConfig()
        {
            Config.Set(Const.Param.InputNeuronsCount, (int)CtlInputCount.Value);
            Config.Set(Const.Param.InputInitial0, CtlInitial0.Text);
            Config.Set(Const.Param.InputInitial1, CtlInitial1.Text);
            Config.Set(Const.Param.InputActivationFunc, CtlActivationFunc.SelectedItem.ToString());

            var neurons = GetNeuronsControls().Where(n => n.IsBias);
            Config.Set(Const.Param.Neurons, neurons.Select(n => n.Id));
            Range.ForEach(neurons, n => n.SaveConfig());
        }

        public override void VanishConfig()
        {
            Config.Remove(Const.Param.InputNeuronsCount);
            Config.Remove(Const.Param.Neurons);
            Config.Remove(Const.Param.InputInitial0);
            Config.Remove(Const.Param.InputInitial1);
            Config.Remove(Const.Param.InputActivationFunc);
            Range.ForEach(GetNeuronsControls(), n => n.VanishConfig());
        }

        private void CtlMenuAddBias_Click(object sender, EventArgs e)
        {
            AddBias(Const.UnknownId);
        }
    }
}
