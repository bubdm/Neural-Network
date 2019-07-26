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
    public partial class NeuronBase : UserControl
    {
        public readonly long Id;
        public Config Config;
        public readonly Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public NeuronBase()
        {
            InitializeComponent();
        }

        public NeuronBase(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Id = id;
            Config = config.Extend(Id);
        }

        public void StateChanged()
        {
            BackColor = IsBias ? Draw.GetRandomColor(20, Color.FromArgb(240, 250, 240)) : Draw.GetRandomColor(20, Color.Lavender);
        }

        public virtual string WeightsInitializer
        {
            get { throw new NotImplementedException(); }
        }

        public virtual double? WeightsInitializerParamA
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsBias
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsBiasConnected
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

        public virtual void SaveConfig()
        {
            throw new NotImplementedException();
        }

        public virtual void VanishConfig()
        {
            throw new NotImplementedException();
        }

        public virtual void OrdinalNumberChanged(int number)
        {
            throw new NotImplementedException();
        }

        private void CtlMenuDeleteNeuron_Click(object sender, EventArgs e)
        {
            if (Parent.Controls.OfType<NeuronBase>().Count() == 1)
            {
                MessageBox.Show("At least one neuron must exist.", "Warning", MessageBoxButtons.OK);
                return;
            }

            var color = BackColor;
            BackColor = Color.Tomato;

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
            (Parent.Parent as HiddenLayerControl).AddNeuron(Const.UnknownId);
        }
    }
}
