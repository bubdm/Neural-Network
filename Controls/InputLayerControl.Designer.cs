﻿namespace NN.Controls
{
    partial class InputLayerControl
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
            this.CtlInputCountLabel = new System.Windows.Forms.Label();
            this.CtlInputCount = new System.Windows.Forms.NumericUpDown();
            this.CtlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuAddBias = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).BeginInit();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlInputCountLabel
            // 
            this.CtlInputCountLabel.AutoSize = true;
            this.CtlInputCountLabel.Location = new System.Drawing.Point(3, 10);
            this.CtlInputCountLabel.Name = "CtlInputCountLabel";
            this.CtlInputCountLabel.Size = new System.Drawing.Size(82, 17);
            this.CtlInputCountLabel.TabIndex = 0;
            this.CtlInputCountLabel.Text = "Input count:";
            // 
            // CtlInputCount
            // 
            this.CtlInputCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlInputCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlInputCount.Location = new System.Drawing.Point(91, 10);
            this.CtlInputCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CtlInputCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtlInputCount.Name = "CtlInputCount";
            this.CtlInputCount.Size = new System.Drawing.Size(259, 22);
            this.CtlInputCount.TabIndex = 1;
            this.CtlInputCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // CtlContextMenu
            // 
            this.CtlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddBias});
            this.CtlContextMenu.Name = "CtlContextMenu";
            this.CtlContextMenu.Size = new System.Drawing.Size(138, 28);
            // 
            // CtlMenuAddBias
            // 
            this.CtlMenuAddBias.Name = "CtlMenuAddBias";
            this.CtlMenuAddBias.Size = new System.Drawing.Size(137, 24);
            this.CtlMenuAddBias.Text = "Add Bias";
            this.CtlMenuAddBias.Click += new System.EventHandler(this.CtlMenuAddBias_Click);
            // 
            // InputLayerControl
            // 
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.CtlInputCount);
            this.Controls.Add(this.CtlInputCountLabel);
            this.Name = "InputLayerControl";
            this.Size = new System.Drawing.Size(353, 160);
            this.Controls.SetChildIndex(this.CtlInputCountLabel, 0);
            this.Controls.SetChildIndex(this.CtlInputCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).EndInit();
            this.CtlContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CtlInputCountLabel;
        private System.Windows.Forms.NumericUpDown CtlInputCount;
        private System.Windows.Forms.ContextMenuStrip CtlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddBias;
    }
}
