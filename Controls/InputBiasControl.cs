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
    public partial class InputBiasControl : NeuronControl
    {
        public InputBiasControl()
        {
            InitializeComponent();
        }

        public InputBiasControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(id, config, onNetworkUIChanged)
        {
            InitializeComponent();

            CtlIsBias.Checked = true;
            CtlIsBiasConnected.Checked = false;
            CtlIsBias.Enabled = false;
            CtlIsBiasConnected.Visible = CtlIsBias.Checked;
            CtlIsBiasConnected.Enabled = false;
        }
    }
}
