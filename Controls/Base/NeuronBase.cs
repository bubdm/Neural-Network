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

            BackColor = Draw.GetRandomColor(20, Color.FromArgb(240, 240, 250));
            //Dock = DockStyle.Top;
            //Anchor = AnchorStyles.Left | AnchorStyles.Right;

            Id = id;
            Config = config.Extend(Id);
        }

        public void StateChanged()
        {
            BackColor = IsBias ? Draw.GetRandomColor(20, Color.FromArgb(240, 250, 240)) : Draw.GetRandomColor(20, Color.FromArgb(240, 240, 250));
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
