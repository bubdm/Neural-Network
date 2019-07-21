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
    public partial class NeuronControl : UserControl
    {
        int Id;
        Config Config;

        public NeuronControl()
        {
            InitializeComponent();
            BackColor = Draw.GetRandomColor(20);
        }

        public NeuronControl(int id, Config config)
        {
            InitializeComponent();
            BackColor = Draw.GetRandomColor(20);

            Id = id;
            Config = config;
        }

        public void SaveConfig()
        {
            
        }
    }
}
