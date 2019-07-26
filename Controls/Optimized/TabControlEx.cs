using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN.Controls
{
    public partial class TabControlEx : TabControl
    {
        public TabControlEx()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
    }
}

/*
     public class CustomTabControl : TabControl
    {

        private void CustomTabControl_Resize(object sender, EventArgs e)
        {
           if (this.Visible) this.Refresh();
        }

        public CustomTabControl()
        {
            this.Resize +=new EventHandler(CustomTabControl_Resize);
            this.SetStyle(ControlStyles.UserPaint |
                                    ControlStyles.AllPaintingInWmPaint |
                                    ControlStyles.OptimizedDoubleBuffer,
                                    true);
        }
    }
    */
