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
    public partial class NeuronControl : UserControl
    {
        public readonly long Id;
        public Config Config;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public NeuronControl()
        {
            InitializeComponent();
        }

        public NeuronControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            BackColor = Draw.GetRandomColor(20);
            Dock = DockStyle.Top;

            Id = id;
            Mapping.NeuronsMap[Id] = this;
            Config = config;

            LoadConfig();
        }

        public void LoadConfig()
        {
            InitializeMode.Helper.FillComboBox(CtlWeightsIniter, Config);
            CtlWeightsIniterParamA.Text = Config.GetString(Const.Param.InitializerParamA, "1");
        }

        public void SaveConfig()
        {
            Config.Set(Const.Param.Initializer, CtlWeightsIniter.SelectedValue.ToString());
            Config.Set(Const.Param.InitializerParamA, CtlWeightsIniterParamA.Text);
        }

        public void VanishConfig()
        {
            
        }

        private void CtlMenuDeleteNeuron_Click(object sender, EventArgs e)
        {
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
            (Parent as LayerControl).AddNeuron(Const.UnknownId);
        }
    }
}
