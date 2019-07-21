using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dots.Controls
{
    public partial class InputLayerControl : UserControl
    {
        public InputLayerControl()
        {
            InitializeComponent();
            CtlInputCount.Minimum = Config.Main.GetInt(Config.Param.InputMinimum, 1);
            CtlInputCount.Maximum = Config.Main.GetInt(Config.Param.InputMaximum, 10000);
            CtlInputCount.Value = Config.Main.GetInt(Config.Param.InputCount, 1000);
        }

        public void LoadConfig(Config config)
        {
            CtlInputCount.Value = config.GetInt(Config.Param.InputCount, Config.Main.GetInt(Config.Param.InputCount, 1000));
        }

        public void SaveConfig(Config config)
        {
             config.Set(Config.Param.InputCount, (int)CtlInputCount.Value);
        }
    }
}
