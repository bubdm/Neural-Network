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

        public enum NeuronType
        {
            Neuron,
            Bias
        }

        public NeuronBase()
        {
            InitializeComponent();
        }

        public NeuronBase(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            BackColor = Draw.GetRandomColor(20);
            Dock = DockStyle.Top;

            Id = id;
            Config = config.Extend(Id);
        }

        public virtual string WeightsInitializer
        {
            get;
        }

        public virtual double? WeightsInitializerParamA
        {
            get;
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
