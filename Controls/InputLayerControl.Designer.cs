namespace NN.Controls
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
            this.CtlInitial1Label = new System.Windows.Forms.Label();
            this.CtlInitial0Label = new System.Windows.Forms.Label();
            this.CtlInitial1 = new NN.Controls.DoubleBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlInitial0 = new NN.Controls.DoubleBox();
            this.CtlActivationFunc = new System.Windows.Forms.ComboBox();
            this.CtlActivationFuncLabel = new System.Windows.Forms.Label();
            this.CtlHeadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).BeginInit();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlHeadPanel
            // 
            this.CtlHeadPanel.Controls.Add(this.CtlActivationFuncLabel);
            this.CtlHeadPanel.Controls.Add(this.CtlActivationFunc);
            this.CtlHeadPanel.Controls.Add(this.CtlInitial0);
            this.CtlHeadPanel.Controls.Add(this.CtlInitial1);
            this.CtlHeadPanel.Controls.Add(this.CtlInitial0Label);
            this.CtlHeadPanel.Controls.Add(this.CtlInitial1Label);
            this.CtlHeadPanel.Size = new System.Drawing.Size(353, 98);
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
            // CtlInitial1Label
            // 
            this.CtlInitial1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlInitial1Label.AutoSize = true;
            this.CtlInitial1Label.Location = new System.Drawing.Point(238, 40);
            this.CtlInitial1Label.Name = "CtlInitial1Label";
            this.CtlInitial1Label.Size = new System.Drawing.Size(56, 17);
            this.CtlInitial1Label.TabIndex = 1;
            this.CtlInitial1Label.Text = "Initial 1:";
            // 
            // CtlInitial0Label
            // 
            this.CtlInitial0Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlInitial0Label.AutoSize = true;
            this.CtlInitial0Label.Location = new System.Drawing.Point(122, 40);
            this.CtlInitial0Label.Name = "CtlInitial0Label";
            this.CtlInitial0Label.Size = new System.Drawing.Size(56, 17);
            this.CtlInitial0Label.TabIndex = 2;
            this.CtlInitial0Label.Text = "Initial 0:";
            this.CtlInitial0Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CtlInitial1
            // 
            this.CtlInitial1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlInitial1.BackColor = System.Drawing.Color.White;
            this.CtlInitial1.ConfigParameter = Tools.Const.Param.InputInitial1;
            this.CtlInitial1.DefaultValue = 1D;
            this.CtlInitial1.IsNullAllowed = false;
            this.CtlInitial1.Location = new System.Drawing.Point(293, 37);
            this.CtlInitial1.MaximumValue = 100D;
            this.CtlInitial1.MinimumValue = -100D;
            this.CtlInitial1.Name = "CtlInitial1";
            this.CtlInitial1.Size = new System.Drawing.Size(57, 22);
            this.CtlInitial1.TabIndex = 3;
            this.CtlInitial1.Text = "1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CtlInitial0
            // 
            this.CtlInitial0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlInitial0.BackColor = System.Drawing.Color.White;
            this.CtlInitial0.ConfigParameter = Tools.Const.Param.InputInitial0;
            this.CtlInitial0.DefaultValue = 0D;
            this.CtlInitial0.IsNullAllowed = false;
            this.CtlInitial0.Location = new System.Drawing.Point(178, 37);
            this.CtlInitial0.MaximumValue = 100D;
            this.CtlInitial0.MinimumValue = -100D;
            this.CtlInitial0.Name = "CtlInitial0";
            this.CtlInitial0.Size = new System.Drawing.Size(57, 22);
            this.CtlInitial0.TabIndex = 4;
            this.CtlInitial0.Text = "0";
            // 
            // CtlActivationFunc
            // 
            this.CtlActivationFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlActivationFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtlActivationFunc.FormattingEnabled = true;
            this.CtlActivationFunc.Location = new System.Drawing.Point(178, 65);
            this.CtlActivationFunc.Name = "CtlActivationFunc";
            this.CtlActivationFunc.Size = new System.Drawing.Size(172, 24);
            this.CtlActivationFunc.TabIndex = 5;
            // 
            // CtlActivationFuncLabel
            // 
            this.CtlActivationFuncLabel.AutoSize = true;
            this.CtlActivationFuncLabel.Location = new System.Drawing.Point(74, 68);
            this.CtlActivationFuncLabel.Name = "CtlActivationFuncLabel";
            this.CtlActivationFuncLabel.Size = new System.Drawing.Size(104, 17);
            this.CtlActivationFuncLabel.TabIndex = 6;
            this.CtlActivationFuncLabel.Text = "Activation func:";
            this.CtlActivationFuncLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputLayerControl
            // 
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.CtlInputCount);
            this.Controls.Add(this.CtlInputCountLabel);
            this.DoubleBuffered = true;
            this.Name = "InputLayerControl";
            this.Size = new System.Drawing.Size(353, 160);
            this.Controls.SetChildIndex(this.CtlHeadPanel, 0);
            this.Controls.SetChildIndex(this.CtlInputCountLabel, 0);
            this.Controls.SetChildIndex(this.CtlInputCount, 0);
            this.CtlHeadPanel.ResumeLayout(false);
            this.CtlHeadPanel.PerformLayout();
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
        private DoubleBox CtlInitial0;
        private DoubleBox CtlInitial1;
        private System.Windows.Forms.Label CtlInitial0Label;
        private System.Windows.Forms.Label CtlInitial1Label;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label CtlActivationFuncLabel;
        private System.Windows.Forms.ComboBox CtlActivationFunc;
    }
}
