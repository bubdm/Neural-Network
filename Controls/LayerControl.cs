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

        public virtual bool IsInput => false;
        public virtual bool IsHidden => false;
        public virtual bool IsOutput => false;

        public virtual void ValidateConfig()
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
    }
}
