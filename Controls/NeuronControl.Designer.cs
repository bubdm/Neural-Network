namespace Dots.Controls
{
    partial class NeuronControl
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
            this.CtlWeightsIniterLabel = new System.Windows.Forms.Label();
            this.CtlWeightsIniter = new System.Windows.Forms.ComboBox();
            this.CtlWeightsIniterParamALabel = new System.Windows.Forms.Label();
            this.CtlWeightsIniterParamA = new System.Windows.Forms.TextBox();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlUpperBorder
            // 
            this.CtlUpperBorder.BackColor = System.Drawing.Color.Silver;
            this.CtlUpperBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlUpperBorder.Location = new System.Drawing.Point(0, 0);
            this.CtlUpperBorder.Name = "CtlUpperBorder";
            this.CtlUpperBorder.Size = new System.Drawing.Size(271, 1);
            this.CtlUpperBorder.TabIndex = 0;
            // 
            // CtlContextMenu
            // 
            this.CtlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddNeuron,
            this.CtlMenuDeleteNeuron});
            this.CtlContextMenu.Name = "CtlContextMenu";
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
            // CtlWeightsIniterLabel
            // 
            this.CtlWeightsIniterLabel.AutoSize = true;
            this.CtlWeightsIniterLabel.Location = new System.Drawing.Point(3, 9);
            this.CtlWeightsIniterLabel.Name = "CtlWeightsIniterLabel";
            this.CtlWeightsIniterLabel.Size = new System.Drawing.Size(103, 17);
            this.CtlWeightsIniterLabel.TabIndex = 1;
            this.CtlWeightsIniterLabel.Text = "Weights init-er:";
            // 
            // CtlWeightsIniter
            // 
            this.CtlWeightsIniter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlWeightsIniter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtlWeightsIniter.FormattingEnabled = true;
            this.CtlWeightsIniter.Location = new System.Drawing.Point(112, 6);
            this.CtlWeightsIniter.Name = "CtlWeightsIniter";
            this.CtlWeightsIniter.Size = new System.Drawing.Size(146, 24);
            this.CtlWeightsIniter.TabIndex = 2;
            // 
            // CtlWeightsIniterParamALabel
            // 
            this.CtlWeightsIniterParamALabel.AutoSize = true;
            this.CtlWeightsIniterParamALabel.Location = new System.Drawing.Point(86, 44);
            this.CtlWeightsIniterParamALabel.Name = "CtlWeightsIniterParamALabel";
            this.CtlWeightsIniterParamALabel.Size = new System.Drawing.Size(20, 17);
            this.CtlWeightsIniterParamALabel.TabIndex = 3;
            this.CtlWeightsIniterParamALabel.Text = "a:";
            // 
            // CtlWeightsIniterParamA
            // 
            this.CtlWeightsIniterParamA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlWeightsIniterParamA.Location = new System.Drawing.Point(112, 44);
            this.CtlWeightsIniterParamA.Name = "CtlWeightsIniterParamA";
            this.CtlWeightsIniterParamA.Size = new System.Drawing.Size(146, 22);
            this.CtlWeightsIniterParamA.TabIndex = 4;
            this.CtlWeightsIniterParamA.Text = "1";
            // 
            // NeuronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.CtlWeightsIniterParamA);
            this.Controls.Add(this.CtlWeightsIniterParamALabel);
            this.Controls.Add(this.CtlWeightsIniter);
            this.Controls.Add(this.CtlWeightsIniterLabel);
            this.Controls.Add(this.CtlUpperBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NeuronControl";
            this.Size = new System.Drawing.Size(271, 124);
            this.CtlContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CtlUpperBorder;
        private System.Windows.Forms.ContextMenuStrip CtlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddNeuron;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuDeleteNeuron;
        private System.Windows.Forms.Label CtlWeightsIniterLabel;
        private System.Windows.Forms.ComboBox CtlWeightsIniter;
        private System.Windows.Forms.Label CtlWeightsIniterParamALabel;
        private System.Windows.Forms.TextBox CtlWeightsIniterParamA;
    }
}
