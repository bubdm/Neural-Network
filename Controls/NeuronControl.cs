﻿using System;
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
        public readonly long Id;
        Config NeuronConfig;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public NeuronControl()
        {
            InitializeComponent();
            BackColor = Draw.GetRandomColor(20);
        }

        public NeuronControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            BackColor = Draw.GetRandomColor(20);
            Dock = DockStyle.Top;

            Id = id;
            NeuronConfig = config;
        }

        public void SaveConfig()
        {
            
        }

        public void VanishConfig()
        {
            
        }

        private void CtlDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you really like to delete the neuron?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Parent.Controls.Remove(this);
                VanishConfig();
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
        }
    }
}