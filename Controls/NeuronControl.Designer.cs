namespace NN.Controls
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
            this.CtlIsBias = new System.Windows.Forms.CheckBox();
            this.CtlIsBiasConnected = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlUpperBorder
            // 
            this.CtlUpperBorder.BackColor = System.Drawing.Color.Silver;
            this.CtlUpperBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlUpperBorder.Location = new System.Drawing.Point(0, 0);
            this.CtlUpperBorder.Name = "CtlUpperBorder";
            this.CtlUpperBorder.Size = new System.Drawing.Size(320, 1);
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
            this.CtlWeightsIniterLabel.Location = new System.Drawing.Point(1, 37);
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
            this.CtlWeightsIniter.Location = new System.Drawing.Point(110, 34);
            this.CtlWeightsIniter.MinimumSize = new System.Drawing.Size(110, 0);
            this.CtlWeightsIniter.Name = "CtlWeightsIniter";
            this.CtlWeightsIniter.Size = new System.Drawing.Size(110, 24);
            this.CtlWeightsIniter.TabIndex = 2;
            // 
            // CtlWeightsIniterParamALabel
            // 
            this.CtlWeightsIniterParamALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlWeightsIniterParamALabel.AutoSize = true;
            this.CtlWeightsIniterParamALabel.Location = new System.Drawing.Point(227, 37);
            this.CtlWeightsIniterParamALabel.Name = "CtlWeightsIniterParamALabel";
            this.CtlWeightsIniterParamALabel.Size = new System.Drawing.Size(20, 17);
            this.CtlWeightsIniterParamALabel.TabIndex = 3;
            this.CtlWeightsIniterParamALabel.Text = "a:";
            // 
            // CtlWeightsIniterParamA
            // 
            this.CtlWeightsIniterParamA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlWeightsIniterParamA.Location = new System.Drawing.Point(247, 34);
            this.CtlWeightsIniterParamA.MinimumSize = new System.Drawing.Size(50, 4);
            this.CtlWeightsIniterParamA.Name = "CtlWeightsIniterParamA";
            this.CtlWeightsIniterParamA.Size = new System.Drawing.Size(70, 22);
            this.CtlWeightsIniterParamA.TabIndex = 4;
            this.CtlWeightsIniterParamA.Text = "1";
            // 
            // CtlIsBias
            // 
            this.CtlIsBias.AutoSize = true;
            this.CtlIsBias.Location = new System.Drawing.Point(4, 4);
            this.CtlIsBias.Name = "CtlIsBias";
            this.CtlIsBias.Size = new System.Drawing.Size(70, 21);
            this.CtlIsBias.TabIndex = 5;
            this.CtlIsBias.Text = "Is bias";
            this.CtlIsBias.UseVisualStyleBackColor = true;
            // 
            // CtlIsBiasConnected
            // 
            this.CtlIsBiasConnected.AutoSize = true;
            this.CtlIsBiasConnected.Location = new System.Drawing.Point(80, 4);
            this.CtlIsBiasConnected.Name = "CtlIsBiasConnected";
            this.CtlIsBiasConnected.Size = new System.Drawing.Size(140, 21);
            this.CtlIsBiasConnected.TabIndex = 6;
            this.CtlIsBiasConnected.Text = "Is bias connected";
            this.CtlIsBiasConnected.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "a:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "a:";
            // 
            // NeuronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.CtlIsBiasConnected);
            this.Controls.Add(this.CtlIsBias);
            this.Controls.Add(this.CtlWeightsIniterParamA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CtlWeightsIniterParamALabel);
            this.Controls.Add(this.CtlWeightsIniter);
            this.Controls.Add(this.CtlWeightsIniterLabel);
            this.Controls.Add(this.CtlUpperBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(320, 0);
            this.Name = "NeuronControl";
            this.Size = new System.Drawing.Size(320, 124);
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
        private System.Windows.Forms.CheckBox CtlIsBias;
        private System.Windows.Forms.CheckBox CtlIsBiasConnected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
