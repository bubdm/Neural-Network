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

            CtlInitial0.Changed += ParameterChanged;
            CtlInitial1.Changed += ParameterChanged;
            CtlActivationFunc.SelectedIndexChanged += CtlActivationFunc_SelectedIndexChanged;
            CtlActivationFuncParamA.Changed += ParameterChanged;
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
        public override int NeuronsCount => GetNeuronsControls().Count;

        public double Initial0 => CtlInitial0.Value;
        public double Initial1 => CtlInitial1.Value;
        public string ActivationFunc => CtlActivationFunc.SelectedItem.ToString();
        public double ActivationFuncParamA => CtlActivationFuncParamA.Value;

        public void OnInputDataChanged(int newCount)
        {
            var controls = CtlFlow.Controls.OfType<InputNeuronControl>().ToList();
            foreach (var control in controls)
            {
                CtlFlow.Controls.Remove(control);
            }          
            Range.For(newCount, n => CtlFlow.Controls.SetChildIndex(AddNeuron(), 0));
        }

        private void LoadConfig()
        {
            ActivationFunction.Helper.FillComboBox(CtlActivationFunc, Config, Const.Param.ActivationFunc, nameof(ActivationFunction.None));
            CtlInitial0.Load(Config);
            CtlInitial1.Load(Config);
            CtlActivationFuncParamA.Load(Config);

            var neurons = Config.GetArray(Const.Param.Neurons);
            Range.ForEach(neurons, n => AddBias(n));
        }

        public InputNeuronControl AddNeuron()
        {
            var neuron = new InputNeuronControl(CtlFlow.Controls.Count);
            CtlFlow.Controls.Add(neuron);
            neuron.ActivationFunc = CtlActivationFunc.SelectedItem.ToString();
            neuron.ActivationFuncParamA = CtlActivationFuncParamA.ValueOrNull;
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
            bool result = CtlInitial0.IsValid() && CtlInitial1.IsValid() && CtlActivationFuncParamA.IsValid();
            return result &= GetNeuronsControls().All(n => n.IsValid());
        }

        public override void SaveConfig()
        {
            Config.Set(Const.Param.ActivationFunc, CtlActivationFunc.SelectedItem.ToString());
            CtlInitial0.Save(Config);
            CtlInitial1.Save(Config);
            CtlActivationFuncParamA.Save(Config);

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
            CtlActivationFuncParamA.Vanish(Config);
            Config.Remove(Const.Param.ActivationFunc);
            Range.ForEach(GetNeuronsControls(), n => n.VanishConfig());
        }

        private void CtlMenuAddBias_Click(object sender, EventArgs e)
        {
            AddBias(Const.UnknownId);
        }
    }
}
