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
    public partial class OutputNeuronControl : NeuronBase
    {
        public OutputNeuronControl()
        {
            InitializeComponent();
        }

        public OutputNeuronControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(id, config, onNetworkUIChanged)
        {
            InitializeComponent();
        }

        public override string WeightsInitializer => nameof(InitializeMode.DoNotApply);
        public override double? WeightsInitializerParamA => 0;

        public override void ValidateConfig()
        {

        }

        public override void SaveConfig()
        {

        }

        public override void VanishConfig()
        {

        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            (Parent as OutputLayerControl).AddNeuron(Const.UnknownId);
        }

        private void CtlMenuDeleteNeuron_Click(object sender, EventArgs e)
        {
            if (Parent.Controls.OfType<OutputNeuronControl>().Count() == 1)
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
    }
}
