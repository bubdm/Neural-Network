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
    public partial class InputNeuronControl : NeuronBase
    {
        public InputNeuronControl(long id)
            : base(id, null,null)
        {
            InitializeComponent();
            Visible = false; // do not show it
        }

        public override string WeightsInitializer => nameof(InitializeMode.None);
        public override double? WeightsInitializerParamA => 0;
        public override bool IsBias => false;
        public override bool IsBiasConnected => false;

        public override void OrdinalNumberChanged(int number)
        {

        }

        public override bool IsValid()
        {
            return true;
        }

        public override void SaveConfig()
        {
            
        }

        public override void VanishConfig()
        {

        }
    }
}
