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
        public Config Config;
        Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public NeuronControl()
        {
            InitializeComponent();
        }

        public NeuronControl(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();
            OnNetworkUIChanged = onNetworkUIChanged;

            BackColor = Draw.GetRandomColor(20);
            Dock = DockStyle.Top;

            Id = id;
            Mapping.NeuronsMap[Id] = this;
            Config = config;

            CtlWeightsIniterParamA.TextChanged += CtlWeightsIniterParamA_TextChanged;

            LoadConfig();
        }

        private void CtlWeightsIniterParamA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateWeightsIniterParamA();
                CtlWeightsIniterParamA.BackColor = Color.White;
            }
            catch
            {
                CtlWeightsIniterParamA.BackColor = Color.Red;
                return;
            }
        }

        public string WeightsInitializer => CtlWeightsIniter.Text;
        public double? WeightsInitializerParamA => Converter.TextToDouble(CtlWeightsIniterParamA.Text);

        public void LoadConfig()
        {
            InitializeMode.Helper.FillComboBox(CtlWeightsIniter, Config);
            CtlWeightsIniterParamA.Text = Config.GetString(Const.Param.WeightsInitializerParamA, "1");
        }

        private void ValidateParameters()
        {
            ValidateWeightsIniterParamA();
        }

        private void ValidateWeightsIniterParamA()
        {
            if (CtlWeightsIniterParamA.Text.Length != 0)
            {
                if (!double.TryParse(CtlWeightsIniterParamA.Text, out double result))
                {
                    throw new Exception($"Invalid weight initializer parameter a value '{CtlWeightsIniterParamA.Text}'.");
                }
            }
        }

        public void SaveConfig()
        {
            ValidateParameters();

            Config.Set(Const.Param.WeightsInitializer, CtlWeightsIniter.SelectedItem.ToString());
            Config.Set(Const.Param.WeightsInitializerParamA, CtlWeightsIniterParamA.Text);
        }

        public void VanishConfig()
        {
            Config.Remove(Const.Param.WeightsInitializer);
            Config.Remove(Const.Param.WeightsInitializerParamA);
        }

        private void CtlMenuDeleteNeuron_Click(object sender, EventArgs e)
        {
            if (Parent.Controls.OfType<NeuronControl>().Count() == 1)
            {
                MessageBox.Show("At least one neuron must exist.", "Warning", MessageBoxButtons.OK);
                return;
            }

            var color = BackColor;
            BackColor = Color.Red;

            if (MessageBox.Show("Would you really like to delete the neuron?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Parent.Controls.Remove(this);
                VanishConfig();
                OnNetworkUIChanged(Notification.ParameterChanged.Structure, null);
            }
            else
            {
                BackColor = color;
            }
        }

        private void CtlMenuAddNeuron_Click(object sender, EventArgs e)
        {
            (Parent as LayerControl).AddNeuron(Const.UnknownId);
        }
    }
}
