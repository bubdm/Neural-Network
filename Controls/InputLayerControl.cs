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
        public InputLayerControl(Config config)
        {
            InitializeComponent();
            CtlInputCount.Minimum = Config.Main.GetInt(Config.Param.InputNeuronsMinCount, 1);
            CtlInputCount.Maximum = Config.Main.GetInt(Config.Param.InputNeuronsMaxCount, 10000);
            CtlInputCount.Value = config.GetInt(Config.Param.InputNeuronsCount, Config.Main.GetInt(Config.Param.InputNeuronsCount, 1000));
        }

        public int NeuronsCount
        {
            get
            {
                return (int)CtlInputCount.Value;
            }
        }

        public void SaveConfig(Config config)
        {
             config.Set(Config.Param.InputNeuronsCount, (int)CtlInputCount.Value);
        }
    }
}
