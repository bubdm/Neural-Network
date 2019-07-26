namespace NN.Controls
{
    partial class LayerBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CtlFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // CtlFlow
            // 
            this.CtlFlow.AutoScroll = true;
            this.CtlFlow.BackColor = System.Drawing.Color.White;
            this.CtlFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.CtlFlow.Location = new System.Drawing.Point(0, 0);
            this.CtlFlow.Name = "CtlFlow";
            this.CtlFlow.Size = new System.Drawing.Size(172, 137);
            this.CtlFlow.TabIndex = 0;
            this.CtlFlow.WrapContents = false;
            this.CtlFlow.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.CtlFlow_ControlAdded);
            this.CtlFlow.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.CtlFlow_ControlRemoved);
            this.CtlFlow.Layout += new System.Windows.Forms.LayoutEventHandler(this.CtlFlow_Layout);
            this.CtlFlow.Resize += new System.EventHandler(this.CtlFlow_Resize);
            // 
            // LayerBase
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CtlFlow);
            this.Name = "LayerBase";
            this.Size = new System.Drawing.Size(172, 137);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.FlowLayoutPanel CtlFlow;
    }
}
