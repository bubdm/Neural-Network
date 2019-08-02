namespace NN.Controls
{
    partial class NetworkControl
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
            this.CtlMainPanel = new System.Windows.Forms.Panel();
            this.CtlColor = new System.Windows.Forms.Label();
            this.CtlColorLabel = new System.Windows.Forms.Label();
            this.CtlRandomViewerButton = new System.Windows.Forms.Button();
            this.CtlLearningRate = new NN.Controls.DoubleBox();
            this.CtlLearningRateLabel = new System.Windows.Forms.Label();
            this.CtlRandomizerParamA = new NN.Controls.DoubleBox();
            this.CtlRandomizerParamALabel = new System.Windows.Forms.Label();
            this.CtlRandomizer = new System.Windows.Forms.ComboBox();
            this.CtlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuAddLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuDeleteLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlTabsLayers = new System.Windows.Forms.TabControl();
            this.CtlTabInput = new System.Windows.Forms.TabPage();
            this.CtlTabOutput = new System.Windows.Forms.TabPage();
            this.CtlMainPanel.SuspendLayout();
            this.CtlContextMenu.SuspendLayout();
            this.CtlTabsLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlMainPanel
            // 
            this.CtlMainPanel.Controls.Add(this.CtlColor);
            this.CtlMainPanel.Controls.Add(this.CtlColorLabel);
            this.CtlMainPanel.Controls.Add(this.CtlRandomViewerButton);
            this.CtlMainPanel.Controls.Add(this.CtlLearningRate);
            this.CtlMainPanel.Controls.Add(this.CtlLearningRateLabel);
            this.CtlMainPanel.Controls.Add(this.CtlRandomizerParamA);
            this.CtlMainPanel.Controls.Add(this.CtlRandomizerParamALabel);
            this.CtlMainPanel.Controls.Add(this.CtlRandomizer);
            this.CtlMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlMainPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlMainPanel.Name = "CtlMainPanel";
            this.CtlMainPanel.Size = new System.Drawing.Size(410, 103);
            this.CtlMainPanel.TabIndex = 0;
            // 
            // CtlColor
            // 
            this.CtlColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlColor.BackColor = System.Drawing.Color.White;
            this.CtlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CtlColor.Location = new System.Drawing.Point(389, 54);
            this.CtlColor.Name = "CtlColor";
            this.CtlColor.Size = new System.Drawing.Size(16, 16);
            this.CtlColor.TabIndex = 7;
            this.CtlColor.Click += new System.EventHandler(this.CtlColor_Click);
            // 
            // CtlColorLabel
            // 
            this.CtlColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlColorLabel.AutoSize = true;
            this.CtlColorLabel.Location = new System.Drawing.Point(341, 53);
            this.CtlColorLabel.Name = "CtlColorLabel";
            this.CtlColorLabel.Size = new System.Drawing.Size(45, 17);
            this.CtlColorLabel.TabIndex = 6;
            this.CtlColorLabel.Text = "Color:";
            // 
            // CtlRandomViewerButton
            // 
            this.CtlRandomViewerButton.Location = new System.Drawing.Point(4, 15);
            this.CtlRandomViewerButton.Name = "CtlRandomViewerButton";
            this.CtlRandomViewerButton.Size = new System.Drawing.Size(132, 24);
            this.CtlRandomViewerButton.TabIndex = 5;
            this.CtlRandomViewerButton.Text = "Randomize mode:";
            this.CtlRandomViewerButton.UseVisualStyleBackColor = true;
            this.CtlRandomViewerButton.Click += new System.EventHandler(this.CtlRandomViewerButton_Click);
            // 
            // CtlLearningRate
            // 
            this.CtlLearningRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlLearningRate.BackColor = System.Drawing.Color.White;
            this.CtlLearningRate.ConfigParameter = Tools.Const.Param.LearningRate;
            this.CtlLearningRate.DefaultValue = 0.05D;
            this.CtlLearningRate.IsNullAllowed = false;
            this.CtlLearningRate.Location = new System.Drawing.Point(142, 48);
            this.CtlLearningRate.MaximumValue = 100D;
            this.CtlLearningRate.MinimumValue = -1D;
            this.CtlLearningRate.Name = "CtlLearningRate";
            this.CtlLearningRate.Size = new System.Drawing.Size(82, 22);
            this.CtlLearningRate.TabIndex = 4;
            this.CtlLearningRate.TabStop = false;
            this.CtlLearningRate.Text = "0.05";
            // 
            // CtlLearningRateLabel
            // 
            this.CtlLearningRateLabel.AutoSize = true;
            this.CtlLearningRateLabel.Location = new System.Drawing.Point(39, 51);
            this.CtlLearningRateLabel.Name = "CtlLearningRateLabel";
            this.CtlLearningRateLabel.Size = new System.Drawing.Size(97, 17);
            this.CtlLearningRateLabel.TabIndex = 3;
            this.CtlLearningRateLabel.Text = "Learning rate:";
            this.CtlLearningRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtlRandomizerParamA
            // 
            this.CtlRandomizerParamA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlRandomizerParamA.BackColor = System.Drawing.Color.White;
            this.CtlRandomizerParamA.ConfigParameter = Tools.Const.Param.RandomizeModeParamA;
            this.CtlRandomizerParamA.DefaultValue = null;
            this.CtlRandomizerParamA.IsNullAllowed = true;
            this.CtlRandomizerParamA.Location = new System.Drawing.Point(324, 15);
            this.CtlRandomizerParamA.MaximumValue = 1000D;
            this.CtlRandomizerParamA.MinimumValue = -1000D;
            this.CtlRandomizerParamA.Name = "CtlRandomizerParamA";
            this.CtlRandomizerParamA.Size = new System.Drawing.Size(82, 22);
            this.CtlRandomizerParamA.TabIndex = 0;
            this.CtlRandomizerParamA.TabStop = false;
            // 
            // CtlRandomizerParamALabel
            // 
            this.CtlRandomizerParamALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlRandomizerParamALabel.AutoSize = true;
            this.CtlRandomizerParamALabel.Location = new System.Drawing.Point(298, 15);
            this.CtlRandomizerParamALabel.Name = "CtlRandomizerParamALabel";
            this.CtlRandomizerParamALabel.Size = new System.Drawing.Size(20, 17);
            this.CtlRandomizerParamALabel.TabIndex = 2;
            this.CtlRandomizerParamALabel.Text = "a:";
            // 
            // CtlRandomizer
            // 
            this.CtlRandomizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlRandomizer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtlRandomizer.FormattingEnabled = true;
            this.CtlRandomizer.Location = new System.Drawing.Point(142, 15);
            this.CtlRandomizer.Name = "CtlRandomizer";
            this.CtlRandomizer.Size = new System.Drawing.Size(150, 24);
            this.CtlRandomizer.TabIndex = 1;
            this.CtlRandomizer.TabStop = false;
            // 
            // CtlContextMenu
            // 
            this.CtlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddLayer,
            this.CtlMenuDeleteLayer});
            this.CtlContextMenu.Name = "CtlContextMenu";
            this.CtlContextMenu.Size = new System.Drawing.Size(171, 52);
            this.CtlContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.CtlContextMenu_Opening);
            // 
            // CtlMenuAddLayer
            // 
            this.CtlMenuAddLayer.Name = "CtlMenuAddLayer";
            this.CtlMenuAddLayer.Size = new System.Drawing.Size(170, 24);
            this.CtlMenuAddLayer.Text = "Add Layer";
            this.CtlMenuAddLayer.Click += new System.EventHandler(this.CtlMenuAddLayer_Click);
            // 
            // CtlMenuDeleteLayer
            // 
            this.CtlMenuDeleteLayer.Enabled = false;
            this.CtlMenuDeleteLayer.Name = "CtlMenuDeleteLayer";
            this.CtlMenuDeleteLayer.Size = new System.Drawing.Size(170, 24);
            this.CtlMenuDeleteLayer.Text = "Delete Layer...";
            this.CtlMenuDeleteLayer.Click += new System.EventHandler(this.CtlMenuDeleteLayer_Click);
            // 
            // CtlTabsLayers
            // 
            this.CtlTabsLayers.Controls.Add(this.CtlTabInput);
            this.CtlTabsLayers.Controls.Add(this.CtlTabOutput);
            this.CtlTabsLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlTabsLayers.Location = new System.Drawing.Point(0, 103);
            this.CtlTabsLayers.Name = "CtlTabsLayers";
            this.CtlTabsLayers.SelectedIndex = 0;
            this.CtlTabsLayers.Size = new System.Drawing.Size(410, 132);
            this.CtlTabsLayers.TabIndex = 2;
            this.CtlTabsLayers.TabStop = false;
            // 
            // CtlTabInput
            // 
            this.CtlTabInput.Location = new System.Drawing.Point(4, 25);
            this.CtlTabInput.Name = "CtlTabInput";
            this.CtlTabInput.Size = new System.Drawing.Size(402, 103);
            this.CtlTabInput.TabIndex = 0;
            this.CtlTabInput.Text = "Input";
            this.CtlTabInput.UseVisualStyleBackColor = true;
            // 
            // CtlTabOutput
            // 
            this.CtlTabOutput.Location = new System.Drawing.Point(4, 25);
            this.CtlTabOutput.Name = "CtlTabOutput";
            this.CtlTabOutput.Size = new System.Drawing.Size(402, 103);
            this.CtlTabOutput.TabIndex = 1;
            this.CtlTabOutput.Text = "Output";
            this.CtlTabOutput.UseVisualStyleBackColor = true;
            // 
            // NetworkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.CtlTabsLayers);
            this.Controls.Add(this.CtlMainPanel);
            this.DoubleBuffered = true;
            this.Name = "NetworkControl";
            this.Size = new System.Drawing.Size(410, 235);
            this.CtlMainPanel.ResumeLayout(false);
            this.CtlMainPanel.PerformLayout();
            this.CtlContextMenu.ResumeLayout(false);
            this.CtlTabsLayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlMainPanel;
        private System.Windows.Forms.TabControl CtlTabsLayers;
        private System.Windows.Forms.TabPage CtlTabInput;
        private System.Windows.Forms.TabPage CtlTabOutput;
        private System.Windows.Forms.ContextMenuStrip CtlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddLayer;
        private System.Windows.Forms.ComboBox CtlRandomizer;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuDeleteLayer;
        private DoubleBox CtlRandomizerParamA;
        private System.Windows.Forms.Label CtlRandomizerParamALabel;
        private DoubleBox CtlLearningRate;
        private System.Windows.Forms.Button CtlRandomViewerButton;
        private System.Windows.Forms.Label CtlLearningRateLabel;
        private System.Windows.Forms.Label CtlColor;
        private System.Windows.Forms.Label CtlColorLabel;
    }
}
