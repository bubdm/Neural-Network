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

namespace NN.Controls
{
    public partial class InputNeuronControl : NeuronBase
    {
        public InputNeuronControl()
        {
            InitializeComponent();
            Visible = false; // do not show it
        }

        public override string WeightsInitializer => nameof(InitializeMode.DoNotApply);
        public override double? WeightsInitializerParamA => 0;

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
