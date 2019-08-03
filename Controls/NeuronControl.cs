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
    public partial class NeuronControl : NeuronBase
    {
        public NeuronControl()
        {
            InitializeComponent();
        }

        public NeuronControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(id, config, onNetworkUIChanged)
        {
            InitializeComponent();

            LoadConfig();

            CtlActivationIniterParamA.Changed += OnChanged;
            CtlActivationIniter.SelectedIndexChanged += CtlActivationIniter_SelectedIndexChanged;
            CtlWeightsIniterParamA.Changed += OnChanged;
            CtlWeightsIniter.SelectedIndexChanged += CtlWeightsIniter_SelectedIndexChanged;
            CtlIsBias.CheckedChanged += CtlIsBias_CheckedChanged;
            CtlIsBiasConnected.CheckedChanged += CtlIsBiasConnected_CheckedChanged;
            CtlActivationFunc.SelectedIndexChanged += CtlActivationFunc_SelectedIndexChanged;
            CtlActivationFuncParamA.Changed += OnChanged;
        }

        private void CtlActivationFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlActivationFuncParamALabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void OnChanged()
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        public override void OrdinalNumberChanged(int number)
        {
            CtlNumber.Text = number.ToString();
        }

        private void CtlIsBiasConnected_CheckedChanged(object sender, EventArgs e)
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlIsBias_CheckedChanged(object sender, EventArgs e)
        {
            CtlIsBiasConnected.Visible = CtlIsBias.Checked;
            CtlActivationPanel.Visible = CtlIsBias.Checked;
            StateChanged();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlActivationIniter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlActivationIniterLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlWeightsIniter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlWeightsIniterLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        public override string ActivationInitializer => (CtlIsBias.Checked ? CtlActivationIniter.SelectedItem.ToString() : null);
        public override double? ActivationInitializerParamA => (CtlIsBias.Checked ? CtlActivationIniterParamA.ValueOrNull : null);
        public override string WeightsInitializer => CtlWeightsIniter.SelectedItem.ToString();
        public override double? WeightsInitializerParamA => CtlWeightsIniterParamA.ValueOrNull;
        public override bool IsBias => CtlIsBias.Checked;
        public override bool IsBiasConnected => CtlIsBiasConnected.Checked && IsBias;
        public override string ActivationFunc => CtlActivationFunc.SelectedItem.ToString();
        public override double? ActivationFuncParamA => CtlActivationFuncParamA.ValueOrNull;

        public void LoadConfig()
        {
            InitializeMode.Helper.FillComboBox(CtlWeightsIniter, Config, Const.Param.WeightsInitializer, nameof(InitializeMode.None));
            CtlWeightsIniterParamA.Load(Config);

            CtlIsBias.Checked = Config.GetBool(Const.Param.IsBias, false);
            CtlIsBiasConnected.Visible = CtlIsBias.Checked;
            CtlIsBiasConnected.Checked = CtlIsBias.Checked && Config.GetBool(Const.Param.IsBiasConnected, false);
            CtlActivationPanel.Visible = CtlIsBias.Checked;

            InitializeMode.Helper.FillComboBox(CtlActivationIniter, Config, Const.Param.ActivationInitializer, nameof(InitializeMode.Constant));
            CtlActivationIniterParamA.Load(Config);

            ActivationFunction.Helper.FillComboBox(CtlActivationFunc, Config, Const.Param.ActivationFunc, nameof(ActivationFunction.LogisticSigmoid));
            CtlActivationFuncParamA.Load(Config);

            StateChanged();
        }

        public bool IsValidActivationIniterParamA()
        {
            return !IsBias || Converter.TryTextToDouble(CtlActivationIniterParamA.Text, out double? result);
        }

        public override bool IsValid()
        {
            return CtlWeightsIniterParamA.IsValid() && (!IsBias || CtlActivationIniterParamA.IsValid());
        }

        public override void SaveConfig()
        {
            if (CtlIsBias.Checked)
            {
                Config.Set(Const.Param.ActivationInitializer, CtlActivationIniter.SelectedItem.ToString());
                CtlActivationIniterParamA.Save(Config);
            }
            else
            {
                Config.Remove(Const.Param.ActivationInitializer);
                CtlActivationIniterParamA.Vanish(Config);
            }

            Config.Set(Const.Param.WeightsInitializer, CtlWeightsIniter.SelectedItem.ToString());
            CtlWeightsIniterParamA.Save(Config);

            Config.Set(Const.Param.ActivationFunc, CtlActivationFunc.SelectedItem.ToString());
            CtlActivationFuncParamA.Save(Config);

            Config.Set(Const.Param.IsBias, CtlIsBias.Checked);
            Config.Set(Const.Param.IsBiasConnected, CtlIsBias.Checked && CtlIsBiasConnected.Checked);
        }

        public override void VanishConfig()
        {
            Config.Remove(Const.Param.ActivationInitializer);
            Config.Remove(Const.Param.WeightsInitializer);
            Config.Remove(Const.Param.IsBias);
            Config.Remove(Const.Param.IsBiasConnected);
            Config.Remove(Const.Param.ActivationFunc);

            CtlWeightsIniterParamA.Vanish(Config);
            CtlActivationIniterParamA.Vanish(Config);
            CtlActivationFuncParamA.Vanish(Config);
        }
    }
}
