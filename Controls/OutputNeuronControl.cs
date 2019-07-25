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
        public override bool IsBias => false;
        public override bool IsBiasConnected => false;

        public override void OrdinalNumberChanged(int number)
        {

        }

        public override void ValidateConfig()
        {

        }

        public override void SaveConfig()
        {

        }

        public override void VanishConfig()
        {

        }
    }
}
