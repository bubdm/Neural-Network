﻿namespace NN.Controls
{
    partial class OutputNeuronControl
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
            this.CtlUpperBorder = new System.Windows.Forms.Panel();
            this.CtlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuAddNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuDeleteNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlUpperBorder
            // 
            this.CtlUpperBorder.BackColor = System.Drawing.Color.Silver;
            this.CtlUpperBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlUpperBorder.Location = new System.Drawing.Point(0, 0);
            this.CtlUpperBorder.Name = "CtlUpperBorder";
            this.CtlUpperBorder.Size = new System.Drawing.Size(236, 1);
            this.CtlUpperBorder.TabIndex = 0;
            // 
            // CtlContextMenu
            // 
            this.CtlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddNeuron,
            this.CtlMenuDeleteNeuron});
            this.CtlContextMenu.Name = "contextMenuStrip1";
            this.CtlContextMenu.Size = new System.Drawing.Size(173, 52);
            // 
            // CtlMenuAddNeuron
            // 
            this.CtlMenuAddNeuron.Name = "CtlMenuAddNeuron";
            this.CtlMenuAddNeuron.Size = new System.Drawing.Size(172, 24);
            this.CtlMenuAddNeuron.Text = "Add neuron";
            this.CtlMenuAddNeuron.Click += new System.EventHandler(this.CtlMenuAddNeuron_Click);
            // 
            // CtlMenuDeleteNeuron
            // 
            this.CtlMenuDeleteNeuron.Name = "CtlMenuDeleteNeuron";
            this.CtlMenuDeleteNeuron.Size = new System.Drawing.Size(172, 24);
            this.CtlMenuDeleteNeuron.Text = "Delete neuron";
            this.CtlMenuDeleteNeuron.Click += new System.EventHandler(this.CtlMenuDeleteNeuron_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // OutputNeuronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CtlUpperBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "OutputNeuronControl";
            this.Size = new System.Drawing.Size(236, 45);
            this.CtlContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CtlUpperBorder;
        private System.Windows.Forms.ContextMenuStrip CtlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddNeuron;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuDeleteNeuron;
        private System.Windows.Forms.Label label1;
    }
}
