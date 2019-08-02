namespace NN.Controls
{
    partial class HiddenLayerControl
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
            this.components = new System.ComponentModel.Container();
            this.CtlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuAddNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlHeadPanel
            // 
            this.CtlHeadPanel.Size = new System.Drawing.Size(224, 40);
            // 
            // CtlContextMenu
            // 
            this.CtlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddNeuron});
            this.CtlContextMenu.Name = "CtlContextMenu";
            this.CtlContextMenu.Size = new System.Drawing.Size(157, 28);
            // 
            // CtlMenuAddNeuron
            // 
            this.CtlMenuAddNeuron.Name = "CtlMenuAddNeuron";
            this.CtlMenuAddNeuron.Size = new System.Drawing.Size(156, 24);
            this.CtlMenuAddNeuron.Text = "Add neuron";
            this.CtlMenuAddNeuron.Click += new System.EventHandler(this.CtlMenuAddNeuron_Click);
            // 
            // HiddenLayerControl
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Name = "HiddenLayerControl";
            this.Size = new System.Drawing.Size(224, 117);
            this.Controls.SetChildIndex(this.CtlHeadPanel, 0);
            this.CtlContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip CtlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddNeuron;
    }
}
