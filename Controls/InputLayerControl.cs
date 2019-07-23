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
            LayerConfig = config;
            
            CtlInputCount.Minimum = Config.Main.GetInt(Config.Param.InputNeuronsMinCount, 1);
            CtlInputCount.Maximum = Config.Main.GetInt(Config.Param.InputNeuronsMaxCount, 10000);
            CtlInputCount.Value = LayerConfig.Extend(Const.InputLayerId).GetInt(Config.Param.NeuronsCount, Config.Main.GetInt(Config.Param.NeuronsCount, 1000));
        }

        public void SaveConfig()
        {
             LayerConfig.Extend(Const.InputLayerId).Set(Config.Param.NeuronsCount, (int)CtlInputCount.Value);
        }
    }
}
