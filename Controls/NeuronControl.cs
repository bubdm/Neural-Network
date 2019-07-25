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

            CtlWeightsIniterParamA.TextChanged += CtlWeightsIniterParamA_TextChanged;
            CtlWeightsIniter.SelectedIndexChanged += CtlWeightsIniter_SelectedIndexChanged;

            LoadConfig();
        }

        private void CtlWeightsIniter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtlWeightsIniterLabel.Focus();
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, false);
        }

        private void CtlWeightsIniterParamA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateWeightsIniterParamA();
                CtlWeightsIniterParamA.BackColor = Color.White;
            }
            catch
            {
                CtlWeightsIniterParamA.BackColor = Color.Red;
                return;
            }
        }

        public override string WeightsInitializer => CtlWeightsIniter.Text;
        public override double? WeightsInitializerParamA => Converter.TextToDouble(CtlWeightsIniterParamA.Text);

        public void LoadConfig()
        {
            InitializeMode.Helper.FillComboBox(CtlWeightsIniter, Config);
            CtlWeightsIniterParamA.Text = Config.GetString(Const.Param.WeightsInitializerParamA, "1");
        }

        private void ValidateParameters()
        {
            ValidateWeightsIniterParamA();
        }

        private void ValidateWeightsIniterParamA()
        {
            if (!Converter.TryTextToDouble(CtlWeightsIniterParamA.Text, out double? result))
            {
                throw new Exception($"Invalid weight initializer parameter a value '{CtlWeightsIniterParamA.Text}'.");
            }
        }

        public override void ValidateConfig()
        {
            ValidateParameters();
        }

        public override void SaveConfig()
        {
            Config.Set(Const.Param.WeightsInitializer, CtlWeightsIniter.SelectedItem.ToString());
            Config.Set(Const.Param.WeightsInitializerParamA, CtlWeightsIniterParamA.Text);
        }

        public override void VanishConfig()
        {
            Config.Remove(Const.Param.WeightsInitializer);
            Config.Remove(Const.Param.WeightsInitializerParamA);
        }

        private void CtlMenuDeleteNeuron_Click(object sender, EventArgs e)
        {
            if (Parent.Controls.OfType<NeuronControl>().Count() == 1)
            {
                MessageBox.Show("At least one neuron must exist.", "Warning", MessageBoxButtons.OK);
                return;
            }

            var color = BackColor;
            BackColor = Color.Red;

            if (MessageBox.Show("Would you really like to delete the neuron?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Parent.Controls.Remove(this);
                VanishConfig();
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
            else
            {
                BackColor = color;
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            (Parent as HiddenLayerControl).AddNeuron(Const.UnknownId);
        }
    }
}
