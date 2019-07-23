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
    public partial class InputLayerControl : UserControl
    {
        Config LayerConfig;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public InputLayerControl(Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Top;
            LayerConfig = config;

            LoadConfig();

            CtlInputCount.ValueChanged += CtlInputCount_ValueChanged;
        }

        private void CtlInputCount_ValueChanged(object sender, EventArgs e)
        {
            OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
        }

        private void LoadConfig()
        {
            CtlInputCount.Minimum = Config.Main.GetInt(Const.Param.InputNeuronsMinCount, 10);
            CtlInputCount.Maximum = Config.Main.GetInt(Const.Param.InputNeuronsMaxCount, 10000);
            CtlInputCount.Value = LayerConfig.Extend(Const.InputLayerId).GetInt(Const.Param.InputNeuronsCount, Const.DefaultInputNeuronsCount);
        }

        public void SaveConfig()
        {
             LayerConfig.Extend(Const.InputLayerId).Set(Const.Param.InputNeuronsCount, (int)CtlInputCount.Value);
        }
    }
}
