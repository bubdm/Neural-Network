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
    public partial class LayerBase : UserControl
    {
        public readonly long Id;
        public readonly Config Config;
        public readonly Action<Notification.ParameterChanged, object> OnNetworkUIChanged;

        public LayerBase()
        {
            InitializeComponent();
        }

        public LayerBase(long id, Config config, Action<Notification.ParameterChanged, object> onNetworkUIChanged)
        {
            InitializeComponent();

            OnNetworkUIChanged = onNetworkUIChanged;

            Dock = DockStyle.Fill;
            Id = id;
            Config = config.Extend(Id);
        }

        public virtual bool IsInput => false;
        public virtual bool IsHidden => false;
        public virtual bool IsOutput => false;

        public virtual int NeuronsCount
        {
            get;
        }

        public virtual List<NeuronBase> GetNeuronsControls()
        {
            throw new NotImplementedException();
        }

        public virtual void ValidateConfig()
        {
            throw new NotImplementedException();
        }

        public virtual void SaveConfig()
        {
            throw new NotImplementedException();
        }

        public virtual void VanishConfig()
        {
            throw new NotImplementedException();
        }

        private void CtlFlow_Layout(object sender, LayoutEventArgs e)
        {
            Dispatch(() =>
            {
                if (CtlFlow.Controls.Count > 0)
                {
                    CtlFlow.SuspendLayout();
                    int ordinalNumber = 0;
                    foreach (NeuronBase control in CtlFlow.Controls)
                    {
                        control.OrdinalNumberChanged(++ordinalNumber);
                        control.Width = CtlFlow.Width - (CtlFlow.VerticalScroll.Visible ? System.Windows.Forms.SystemInformation.VerticalScrollBarWidth : 0);
                    }
                    CtlFlow.ResumeLayout();
                }
            });
        }

        private void CtlFlow_ControlAdded(object sender, ControlEventArgs e)
        {      
            Dispatch(() =>
            {
                CtlFlow.ScrollControlIntoView(e.Control);
                CtlFlow.HorizontalScroll.Value = 0;
                PerformLayout();
            });
        }

        private void Dispatch(Action action)
        {
            var timer = new System.Timers.Timer(20);
            timer.Elapsed += (s, e) => { BeginInvoke(action); };
            timer.AutoReset = false;
            timer.Start();
        }

        private void CtlFlow_ControlRemoved(object sender, ControlEventArgs e)
        {
            Dispatch(() =>
            {
                CtlFlow.HorizontalScroll.Value = 0;
                PerformLayout();
            });
        }
    }
}
