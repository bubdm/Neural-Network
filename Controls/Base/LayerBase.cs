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

            CtlFlow.AutoScroll = false;
            CtlFlow.HorizontalScroll.Maximum = 0;
            CtlFlow.HorizontalScroll.Enabled = false;
            CtlFlow.HorizontalScroll.Visible = false;
            CtlFlow.AutoScroll = true;

            Id = id;
            Config = config.Extend(Id);
            /*
            this.Resize += new EventHandler(CustomPanel_Resize);
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer,
                          true);
                          */
        }
        /*
        private void CustomPanel_Resize(object sender, EventArgs e)
        {
            if (this.Visible) this.Refresh();

        }
        */



        /*
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
        */

        public virtual bool IsInput => false;
        public virtual bool IsHidden => false;
        public virtual bool IsOutput => false;

        public int NeuronsCount => GetNeuronsControls().Count;

        public List<NeuronBase> GetNeuronsControls()
        {
            return CtlFlow.Controls.OfType<NeuronBase>().ToList();
        }

        public virtual bool IsValid()
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
           //HorizontalScroll.Visible = false;

            //Dispatch(() =>
            //{

                if (CtlFlow.Controls.Count > 0)
                {
                    //CtlFlow.SuspendLayout();
                    int ordinalNumber = 0;
                    foreach (NeuronBase control in CtlFlow.Controls)
                    {
                        control.OrdinalNumberChanged(++ordinalNumber);
                        control.Width = CtlFlow.Width - (CtlFlow.VerticalScroll.Visible ? System.Windows.Forms.SystemInformation.VerticalScrollBarWidth : 0);
                    }
                    //CtlFlow.ResumeLayout();


                }
            //});
        }

        private void CtlFlow_ControlAdded(object sender, ControlEventArgs e)
        {      
            Dispatch(() =>
            {
                //CtlFlow.ScrollControlIntoView(e.Control);
                //CtlFlow.HorizontalScroll.Value = 0;
                //PerformLayout();
            });

            CtlFlow.ScrollControlIntoView(e.Control);
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
                //CtlFlow.HorizontalScroll.Value = 0;
                //PerformLayout();
            });
        }

        private void CtlFlow_Resize(object sender, EventArgs e)
        {
            /*
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
            */
        }
    }
}
