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

            CtlActivationIniterParamA.TextChanged += CtlActivationIniterParamA_TextChanged;
            CtlActivationIniter.SelectedIndexChanged += CtlActivationIniter_SelectedIndexChanged;
            CtlWeightsIniterParamA.TextChanged += CtlWeightsIniterParamA_TextChanged;
            CtlWeightsIniter.SelectedIndexChanged += CtlWeightsIniter_SelectedIndexChanged;
            CtlIsBias.CheckedChanged += CtlIsBias_CheckedChanged;
            CtlIsBiasConnected.CheckedChanged += CtlIsBiasConnected_CheckedChanged;
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

        private void CtlActivationIniterParamA_TextChanged(object sender, EventArgs e)
        {
            CtlActivationIniterParamA.BackColor = IsValidActivationIniterParamA() ? Color.White : Color.Tomato;
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlWeightsIniter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlWeightsIniterLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlWeightsIniterParamA_TextChanged(object sender, EventArgs e)
        { 
            CtlWeightsIniterParamA.BackColor = IsValidWeightsIniterParamA() ? Color.White : Color.Tomato;
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        public override string ActivationInitializer => (CtlIsBias.Checked ? CtlActivationIniter.SelectedItem.ToString() : null);
        public override double? ActivationInitializerParamA => (CtlIsBias.Checked ? Converter.TextToDouble(CtlActivationIniterParamA.Text) : null);
        public override string WeightsInitializer => CtlWeightsIniter.SelectedItem.ToString();
        public override double? WeightsInitializerParamA => Converter.TextToDouble(CtlWeightsIniterParamA.Text);
        public override bool IsBias => CtlIsBias.Checked;
        public override bool IsBiasConnected => CtlIsBiasConnected.Checked && IsBias;

        public void LoadConfig()
        {
            InitializeMode.Helper.FillComboBox(CtlWeightsIniter, Config, Const.Param.WeightsInitializer, nameof(InitializeMode.DoNotApply));
            CtlWeightsIniterParamA.Text = Config.GetString(Const.Param.WeightsInitializerParamA);

            CtlIsBias.Checked = Config.GetBool(Const.Param.IsBias, false);
            CtlIsBiasConnected.Visible = CtlIsBias.Checked;
            CtlIsBiasConnected.Checked = CtlIsBias.Checked && Config.GetBool(Const.Param.IsBiasConnected, false);
            CtlActivationPanel.Visible = CtlIsBias.Checked;

            InitializeMode.Helper.FillComboBox(CtlActivationIniter, Config, Const.Param.ActivationInitializer, nameof(InitializeMode.Constant));
            CtlActivationIniterParamA.Text = Config.GetString(Const.Param.ActivationInitializerParamA, "1");
            
            StateChanged();
        }

        public bool IsValidWeightsIniterParamA()
        {
            return Converter.TryTextToDouble(CtlWeightsIniterParamA.Text, out double? result);
        }

        public bool IsValidActivationIniterParamA()
        {
            return !IsBias || Converter.TryTextToDouble(CtlActivationIniterParamA.Text, out double? result);
        }

        public override bool IsValid()
        {
            return IsValidWeightsIniterParamA() && IsValidActivationIniterParamA();
        }

        public override void SaveConfig()
        {
            if (CtlIsBias.Checked)
            {
                Config.Set(Const.Param.ActivationInitializer, CtlActivationIniter.SelectedItem.ToString());
                Config.Set(Const.Param.ActivationInitializerParamA, CtlActivationIniterParamA.Text);
            }
            else
            {
                Config.Remove(Const.Param.ActivationInitializer);
                Config.Remove(Const.Param.ActivationInitializerParamA);
            }

            Config.Set(Const.Param.WeightsInitializer, CtlWeightsIniter.SelectedItem.ToString());
            Config.Set(Const.Param.WeightsInitializerParamA, CtlWeightsIniterParamA.Text);
            Config.Set(Const.Param.IsBias, CtlIsBias.Checked);
            Config.Set(Const.Param.IsBiasConnected, CtlIsBias.Checked && CtlIsBiasConnected.Checked);
        }

        public override void VanishConfig()
        {
            Config.Remove(Const.Param.ActivationInitializer);
            Config.Remove(Const.Param.ActivationInitializerParamA);
            Config.Remove(Const.Param.WeightsInitializer);
            Config.Remove(Const.Param.WeightsInitializerParamA);
            Config.Remove(Const.Param.IsBias);
            Config.Remove(Const.Param.IsBiasConnected);
        }
    }
}
