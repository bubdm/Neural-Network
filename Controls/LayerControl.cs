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
    public partial class LayerControl : UserControl
    {
        public readonly long Id;
        public readonly Config Config;
        public readonly Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public LayerControl()
        {
            InitializeComponent();
        }

        public LayerControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();

            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;
            Id = id;
            Config = config.Extend(Id);
        }
    }
}
