namespace NN.Controls
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
            this.CtlActivationPanel = new System.Windows.Forms.Panel();
            this.CtlActivationFuncParamALabel = new System.Windows.Forms.Label();
            this.CtlActivationFuncParamA = new NN.Controls.DoubleBox();
            this.CtlActivationFunc = new System.Windows.Forms.ComboBox();
            this.CtlActivationFuncLabel = new System.Windows.Forms.Label();
            this.CtlNumber = new System.Windows.Forms.Label();
            this.CtlUpperBorder = new System.Windows.Forms.Panel();
            this.CtlActivationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlActivationPanel
            // 
            this.CtlActivationPanel.Controls.Add(this.CtlActivationFuncParamALabel);
            this.CtlActivationPanel.Controls.Add(this.CtlActivationFuncParamA);
            this.CtlActivationPanel.Controls.Add(this.CtlActivationFunc);
            this.CtlActivationPanel.Controls.Add(this.CtlActivationFuncLabel);
            this.CtlActivationPanel.Controls.Add(this.CtlNumber);
            this.CtlActivationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlActivationPanel.Location = new System.Drawing.Point(0, 1);
            this.CtlActivationPanel.Name = "CtlActivationPanel";
            this.CtlActivationPanel.Size = new System.Drawing.Size(392, 30);
            this.CtlActivationPanel.TabIndex = 13;
            // 
            // CtlActivationFuncParamALabel
            // 
            this.CtlActivationFuncParamALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationFuncParamALabel.AutoSize = true;
            this.CtlActivationFuncParamALabel.Location = new System.Drawing.Point(255, 4);
            this.CtlActivationFuncParamALabel.Name = "CtlActivationFuncParamALabel";
            this.CtlActivationFuncParamALabel.Size = new System.Drawing.Size(20, 17);
            this.CtlActivationFuncParamALabel.TabIndex = 5;
            this.CtlActivationFuncParamALabel.Text = "a:";
            // 
            // CtlActivationFuncParamA
            // 
            this.CtlActivationFuncParamA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationFuncParamA.BackColor = System.Drawing.Color.White;
            this.CtlActivationFuncParamA.ConfigParameter = Tools.Const.Param.ActivationFuncParamA;
            this.CtlActivationFuncParamA.DefaultValue = null;
            this.CtlActivationFuncParamA.IsNullAllowed = true;
            this.CtlActivationFuncParamA.Location = new System.Drawing.Point(281, 1);
            this.CtlActivationFuncParamA.MaximumValue = 100D;
            this.CtlActivationFuncParamA.MinimumSize = new System.Drawing.Size(4, 4);
            this.CtlActivationFuncParamA.MinimumValue = -100D;
            this.CtlActivationFuncParamA.Name = "CtlActivationFuncParamA";
            this.CtlActivationFuncParamA.Size = new System.Drawing.Size(75, 22);
            this.CtlActivationFuncParamA.TabIndex = 6;
            this.CtlActivationFuncParamA.TabStop = false;
            // 
            // CtlActivationFunc
            // 
            this.CtlActivationFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtlActivationFunc.FormattingEnabled = true;
            this.CtlActivationFunc.Location = new System.Drawing.Point(113, 1);
            this.CtlActivationFunc.Name = "CtlActivationFunc";
            this.CtlActivationFunc.Size = new System.Drawing.Size(136, 24);
            this.CtlActivationFunc.TabIndex = 3;
            this.CtlActivationFunc.TabStop = false;
            // 
            // CtlActivationFuncLabel
            // 
            this.CtlActivationFuncLabel.AutoSize = true;
            this.CtlActivationFuncLabel.Location = new System.Drawing.Point(3, 4);
            this.CtlActivationFuncLabel.Name = "CtlActivationFuncLabel";
            this.CtlActivationFuncLabel.Size = new System.Drawing.Size(104, 17);
            this.CtlActivationFuncLabel.TabIndex = 2;
            this.CtlActivationFuncLabel.Text = "Activation func:";
            // 
            // CtlNumber
            // 
            this.CtlNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlNumber.Location = new System.Drawing.Point(341, 0);
            this.CtlNumber.Margin = new System.Windows.Forms.Padding(0);
            this.CtlNumber.Name = "CtlNumber";
            this.CtlNumber.Size = new System.Drawing.Size(51, 19);
            this.CtlNumber.TabIndex = 12;
            this.CtlNumber.Text = "1";
            this.CtlNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CtlNumber.UseCompatibleTextRendering = true;
            // 
            // CtlUpperBorder
            // 
            this.CtlUpperBorder.BackColor = System.Drawing.Color.Silver;
            this.CtlUpperBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlUpperBorder.Location = new System.Drawing.Point(0, 0);
            this.CtlUpperBorder.Name = "CtlUpperBorder";
            this.CtlUpperBorder.Size = new System.Drawing.Size(392, 1);
            this.CtlUpperBorder.TabIndex = 14;
            // 
            // OutputNeuronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.CtlActivationPanel);
            this.Controls.Add(this.CtlUpperBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OutputNeuronControl";
            this.Size = new System.Drawing.Size(392, 91);
            this.CtlActivationPanel.ResumeLayout(false);
            this.CtlActivationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NeuronControl CtlBaseNeuron;
        private NeuronControl neuronControl1;
        private System.Windows.Forms.Panel CtlActivationPanel;
        private System.Windows.Forms.Label CtlActivationFuncParamALabel;
        private DoubleBox CtlActivationFuncParamA;
        private System.Windows.Forms.ComboBox CtlActivationFunc;
        private System.Windows.Forms.Label CtlActivationFuncLabel;
        private System.Windows.Forms.Label CtlNumber;
        private System.Windows.Forms.Panel CtlUpperBorder;
    }
}
