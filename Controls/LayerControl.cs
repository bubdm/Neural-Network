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
    public partial class LayerControl : UserControl
    {
        int Id;
        Config Config;

        public LayerControl()
        {
            InitializeComponent();
        }

        public LayerControl(int id, Config config)
        {
            InitializeComponent();
            Id = id;
            Config = config;

            var neuronsCount = Config.Extend(Id.ToString()).GetInt(Config.Param.NeuronsCount, 0);
            for (int i = 0; i < neuronsCount; ++i)
            {
                AddNeuron();
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            AddNeuron();
        }

        private void AddNeuron()
        {
            int id = Controls.Count + 1;
            var neuron = new NeuronControl(id, Config);            
            Controls.Add(neuron);
            neuron.Dock = DockStyle.Top;
            neuron.BringToFront();
        }

        public void SaveConfig()
        {
            Config.Extend(Id.ToString()).Set(Config.Param.NeuronsCount, Controls.Count);
            for (int i = 0; i < Controls.Count; ++i)
            {
                var neuron = Controls[i] as NeuronControl;
                if (neuron != null)
                {
                    neuron.SaveConfig();
                }
            }
        }
    }
}
