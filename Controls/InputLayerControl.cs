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
    public partial class InputLayerControl : LayerControl
    {
        public InputLayerControl(Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
            : base(Const.InputLayerId, config, onNetworkUIChanged)
        {
            InitializeComponent();

            LoadConfig();

            CtlInputCount.ValueChanged += CtlInputCount_ValueChanged;
        }

        public override bool IsInput => true;

        public int NeuronsCount => (int)CtlInputCount.Value;

        private void CtlInputCount_ValueChanged(object sender, EventArgs e)
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void LoadConfig()
        {
            CtlInputCount.Minimum = Config.Main.GetInt(Const.Param.InputNeuronsMinCount, 10);
            CtlInputCount.Maximum = Config.Main.GetInt(Const.Param.InputNeuronsMaxCount, 10000);
            CtlInputCount.Value = Config.GetInt(Const.Param.InputNeuronsCount, Const.DefaultInputNeuronsCount);
        }

        public void ValidateConfig()
        {

        }

        public void SaveConfig()
        {
             Config.Set(Const.Param.InputNeuronsCount, (int)CtlInputCount.Value);
        }
    }
}
