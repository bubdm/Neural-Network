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
            this.CtlUpperBorder = new System.Windows.Forms.Panel();
            this.CtlWeightsIniterLabel = new System.Windows.Forms.Label();
            this.CtlWeightsIniter = new System.Windows.Forms.ComboBox();
            this.CtlWeightsIniterParamALabel = new System.Windows.Forms.Label();
            this.CtlWeightsIniterParamA = new NN.Controls.DoubleBox();
            this.CtlIsBias = new System.Windows.Forms.CheckBox();
            this.CtlIsBiasConnected = new System.Windows.Forms.CheckBox();
            this.CtlNumber = new System.Windows.Forms.Label();
            this.CtlHeadPanel = new System.Windows.Forms.Panel();
            this.CtlWeightsPanel = new System.Windows.Forms.Panel();
            this.CtlActivationPanel = new System.Windows.Forms.Panel();
            this.CtlActivationIniterLabel = new System.Windows.Forms.Label();
            this.CtlActivationIniter = new System.Windows.Forms.ComboBox();
            this.CtlActivationIniterParamALabel = new System.Windows.Forms.Label();
            this.CtlActivationIniterParamA = new NN.Controls.DoubleBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CtlActivationFuncParamALabel = new System.Windows.Forms.Label();
            this.CtlActivationFuncParamA = new NN.Controls.DoubleBox();
            this.CtlActivationFunc = new System.Windows.Forms.ComboBox();
            this.CtlActivationFuncLabel = new System.Windows.Forms.Label();
            this.CtlHeadPanel.SuspendLayout();
            this.CtlWeightsPanel.SuspendLayout();
            this.CtlActivationPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlUpperBorder
            // 
            this.CtlUpperBorder.BackColor = System.Drawing.Color.Silver;
            this.CtlUpperBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlUpperBorder.Location = new System.Drawing.Point(0, 0);
            this.CtlUpperBorder.Name = "CtlUpperBorder";
            this.CtlUpperBorder.Size = new System.Drawing.Size(365, 1);
            this.CtlUpperBorder.TabIndex = 0;
            // 
            // CtlWeightsIniterLabel
            // 
            this.CtlWeightsIniterLabel.AutoSize = true;
            this.CtlWeightsIniterLabel.Location = new System.Drawing.Point(13, 3);
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
            this.CtlWeightsIniter.Location = new System.Drawing.Point(122, 0);
            this.CtlWeightsIniter.Name = "CtlWeightsIniter";
            this.CtlWeightsIniter.Size = new System.Drawing.Size(133, 24);
            this.CtlWeightsIniter.TabIndex = 2;
            this.CtlWeightsIniter.TabStop = false;
            // 
            // CtlWeightsIniterParamALabel
            // 
            this.CtlWeightsIniterParamALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlWeightsIniterParamALabel.AutoSize = true;
            this.CtlWeightsIniterParamALabel.Location = new System.Drawing.Point(261, 3);
            this.CtlWeightsIniterParamALabel.Name = "CtlWeightsIniterParamALabel";
            this.CtlWeightsIniterParamALabel.Size = new System.Drawing.Size(20, 17);
            this.CtlWeightsIniterParamALabel.TabIndex = 3;
            this.CtlWeightsIniterParamALabel.Text = "a:";
            // 
            // CtlWeightsIniterParamA
            // 
            this.CtlWeightsIniterParamA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlWeightsIniterParamA.BackColor = System.Drawing.Color.White;
            this.CtlWeightsIniterParamA.ConfigParameter = Tools.Const.Param.WeightsInitializerParamA;
            this.CtlWeightsIniterParamA.DefaultValue = null;
            this.CtlWeightsIniterParamA.IsNullAllowed = true;
            this.CtlWeightsIniterParamA.Location = new System.Drawing.Point(287, 0);
            this.CtlWeightsIniterParamA.MaximumValue = 100D;
            this.CtlWeightsIniterParamA.MinimumSize = new System.Drawing.Size(4, 4);
            this.CtlWeightsIniterParamA.MinimumValue = -100D;
            this.CtlWeightsIniterParamA.Name = "CtlWeightsIniterParamA";
            this.CtlWeightsIniterParamA.Size = new System.Drawing.Size(75, 22);
            this.CtlWeightsIniterParamA.TabIndex = 4;
            this.CtlWeightsIniterParamA.TabStop = false;
            // 
            // CtlIsBias
            // 
            this.CtlIsBias.AutoSize = true;
            this.CtlIsBias.Location = new System.Drawing.Point(3, 3);
            this.CtlIsBias.Name = "CtlIsBias";
            this.CtlIsBias.Size = new System.Drawing.Size(70, 21);
            this.CtlIsBias.TabIndex = 5;
            this.CtlIsBias.TabStop = false;
            this.CtlIsBias.Text = "Is bias";
            this.CtlIsBias.UseVisualStyleBackColor = true;
            // 
            // CtlIsBiasConnected
            // 
            this.CtlIsBiasConnected.AutoSize = true;
            this.CtlIsBiasConnected.Location = new System.Drawing.Point(79, 3);
            this.CtlIsBiasConnected.Name = "CtlIsBiasConnected";
            this.CtlIsBiasConnected.Size = new System.Drawing.Size(140, 21);
            this.CtlIsBiasConnected.TabIndex = 6;
            this.CtlIsBiasConnected.TabStop = false;
            this.CtlIsBiasConnected.Text = "Is bias connected";
            this.CtlIsBiasConnected.UseVisualStyleBackColor = true;
            // 
            // CtlNumber
            // 
            this.CtlNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlNumber.Location = new System.Drawing.Point(297, 0);
            this.CtlNumber.Margin = new System.Windows.Forms.Padding(0);
            this.CtlNumber.Name = "CtlNumber";
            this.CtlNumber.Size = new System.Drawing.Size(68, 19);
            this.CtlNumber.TabIndex = 7;
            this.CtlNumber.Text = "1";
            this.CtlNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CtlNumber.UseCompatibleTextRendering = true;
            // 
            // CtlHeadPanel
            // 
            this.CtlHeadPanel.Controls.Add(this.CtlIsBias);
            this.CtlHeadPanel.Controls.Add(this.CtlNumber);
            this.CtlHeadPanel.Controls.Add(this.CtlIsBiasConnected);
            this.CtlHeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlHeadPanel.Location = new System.Drawing.Point(0, 1);
            this.CtlHeadPanel.Name = "CtlHeadPanel";
            this.CtlHeadPanel.Size = new System.Drawing.Size(365, 32);
            this.CtlHeadPanel.TabIndex = 8;
            // 
            // CtlWeightsPanel
            // 
            this.CtlWeightsPanel.Controls.Add(this.CtlWeightsIniterLabel);
            this.CtlWeightsPanel.Controls.Add(this.CtlWeightsIniter);
            this.CtlWeightsPanel.Controls.Add(this.CtlWeightsIniterParamALabel);
            this.CtlWeightsPanel.Controls.Add(this.CtlWeightsIniterParamA);
            this.CtlWeightsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlWeightsPanel.Location = new System.Drawing.Point(0, 63);
            this.CtlWeightsPanel.Name = "CtlWeightsPanel";
            this.CtlWeightsPanel.Size = new System.Drawing.Size(365, 30);
            this.CtlWeightsPanel.TabIndex = 9;
            // 
            // CtlActivationPanel
            // 
            this.CtlActivationPanel.Controls.Add(this.CtlActivationIniterLabel);
            this.CtlActivationPanel.Controls.Add(this.CtlActivationIniter);
            this.CtlActivationPanel.Controls.Add(this.CtlActivationIniterParamALabel);
            this.CtlActivationPanel.Controls.Add(this.CtlActivationIniterParamA);
            this.CtlActivationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlActivationPanel.Location = new System.Drawing.Point(0, 33);
            this.CtlActivationPanel.Name = "CtlActivationPanel";
            this.CtlActivationPanel.Size = new System.Drawing.Size(365, 30);
            this.CtlActivationPanel.TabIndex = 10;
            this.CtlActivationPanel.Visible = false;
            // 
            // CtlActivationIniterLabel
            // 
            this.CtlActivationIniterLabel.AutoSize = true;
            this.CtlActivationIniterLabel.Location = new System.Drawing.Point(3, 3);
            this.CtlActivationIniterLabel.Name = "CtlActivationIniterLabel";
            this.CtlActivationIniterLabel.Size = new System.Drawing.Size(113, 17);
            this.CtlActivationIniterLabel.TabIndex = 1;
            this.CtlActivationIniterLabel.Text = "Activation init-er:";
            // 
            // CtlActivationIniter
            // 
            this.CtlActivationIniter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationIniter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtlActivationIniter.FormattingEnabled = true;
            this.CtlActivationIniter.Location = new System.Drawing.Point(122, 0);
            this.CtlActivationIniter.Name = "CtlActivationIniter";
            this.CtlActivationIniter.Size = new System.Drawing.Size(133, 24);
            this.CtlActivationIniter.TabIndex = 2;
            this.CtlActivationIniter.TabStop = false;
            // 
            // CtlActivationIniterParamALabel
            // 
            this.CtlActivationIniterParamALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationIniterParamALabel.AutoSize = true;
            this.CtlActivationIniterParamALabel.Location = new System.Drawing.Point(261, 3);
            this.CtlActivationIniterParamALabel.Name = "CtlActivationIniterParamALabel";
            this.CtlActivationIniterParamALabel.Size = new System.Drawing.Size(20, 17);
            this.CtlActivationIniterParamALabel.TabIndex = 3;
            this.CtlActivationIniterParamALabel.Text = "a:";
            // 
            // CtlActivationIniterParamA
            // 
            this.CtlActivationIniterParamA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationIniterParamA.BackColor = System.Drawing.Color.White;
            this.CtlActivationIniterParamA.ConfigParameter = Tools.Const.Param.ActivationInitializerParamA;
            this.CtlActivationIniterParamA.DefaultValue = 1D;
            this.CtlActivationIniterParamA.IsNullAllowed = false;
            this.CtlActivationIniterParamA.Location = new System.Drawing.Point(287, 0);
            this.CtlActivationIniterParamA.MaximumValue = 100D;
            this.CtlActivationIniterParamA.MinimumSize = new System.Drawing.Size(4, 4);
            this.CtlActivationIniterParamA.MinimumValue = -100D;
            this.CtlActivationIniterParamA.Name = "CtlActivationIniterParamA";
            this.CtlActivationIniterParamA.Size = new System.Drawing.Size(75, 22);
            this.CtlActivationIniterParamA.TabIndex = 4;
            this.CtlActivationIniterParamA.TabStop = false;
            this.CtlActivationIniterParamA.Text = "1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CtlActivationFuncParamALabel);
            this.panel1.Controls.Add(this.CtlActivationFuncParamA);
            this.panel1.Controls.Add(this.CtlActivationFunc);
            this.panel1.Controls.Add(this.CtlActivationFuncLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 30);
            this.panel1.TabIndex = 11;
            // 
            // CtlActivationFuncParamALabel
            // 
            this.CtlActivationFuncParamALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationFuncParamALabel.AutoSize = true;
            this.CtlActivationFuncParamALabel.Location = new System.Drawing.Point(261, 3);
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
            this.CtlActivationFuncParamA.Location = new System.Drawing.Point(287, 0);
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
            this.CtlActivationFunc.Location = new System.Drawing.Point(122, 0);
            this.CtlActivationFunc.Name = "CtlActivationFunc";
            this.CtlActivationFunc.Size = new System.Drawing.Size(133, 24);
            this.CtlActivationFunc.TabIndex = 3;
            this.CtlActivationFunc.TabStop = false;
            // 
            // CtlActivationFuncLabel
            // 
            this.CtlActivationFuncLabel.AutoSize = true;
            this.CtlActivationFuncLabel.Location = new System.Drawing.Point(12, 3);
            this.CtlActivationFuncLabel.Name = "CtlActivationFuncLabel";
            this.CtlActivationFuncLabel.Size = new System.Drawing.Size(104, 17);
            this.CtlActivationFuncLabel.TabIndex = 2;
            this.CtlActivationFuncLabel.Text = "Activation func:";
            // 
            // NeuronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CtlWeightsPanel);
            this.Controls.Add(this.CtlActivationPanel);
            this.Controls.Add(this.CtlHeadPanel);
            this.Controls.Add(this.CtlUpperBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NeuronControl";
            this.Size = new System.Drawing.Size(365, 159);
            this.CtlHeadPanel.ResumeLayout(false);
            this.CtlHeadPanel.PerformLayout();
            this.CtlWeightsPanel.ResumeLayout(false);
            this.CtlWeightsPanel.PerformLayout();
            this.CtlActivationPanel.ResumeLayout(false);
            this.CtlActivationPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlUpperBorder;
        private System.Windows.Forms.Label CtlWeightsIniterLabel;
        private System.Windows.Forms.ComboBox CtlWeightsIniter;
        private System.Windows.Forms.Label CtlWeightsIniterParamALabel;
        private DoubleBox CtlWeightsIniterParamA;
        private System.Windows.Forms.Label CtlNumber;
        protected System.Windows.Forms.CheckBox CtlIsBias;
        protected System.Windows.Forms.CheckBox CtlIsBiasConnected;
        private System.Windows.Forms.Panel CtlHeadPanel;
        private System.Windows.Forms.Panel CtlWeightsPanel;
        private System.Windows.Forms.Panel CtlActivationPanel;
        private System.Windows.Forms.Label CtlActivationIniterLabel;
        private System.Windows.Forms.ComboBox CtlActivationIniter;
        private System.Windows.Forms.Label CtlActivationIniterParamALabel;
        private DoubleBox CtlActivationIniterParamA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CtlActivationFuncParamALabel;
        private DoubleBox CtlActivationFuncParamA;
        private System.Windows.Forms.ComboBox CtlActivationFunc;
        private System.Windows.Forms.Label CtlActivationFuncLabel;
    }
}
