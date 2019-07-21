namespace Dots.Controls
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
            this.CtlSplitter = new System.Windows.Forms.Splitter();
            this.CtlTabsLayers = new System.Windows.Forms.TabControl();
            this.CtlTabInput = new System.Windows.Forms.TabPage();
            this.CtlTabOutput = new System.Windows.Forms.TabPage();
            this.CtlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuAddLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlRandomizeModeLabel = new System.Windows.Forms.Label();
            this.CtlRandomizer = new System.Windows.Forms.ComboBox();
            this.CtlMainPanel.SuspendLayout();
            this.CtlTabsLayers.SuspendLayout();
            this.CtlContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlMainPanel
            // 
            this.CtlMainPanel.Controls.Add(this.CtlRandomizer);
            this.CtlMainPanel.Controls.Add(this.CtlRandomizeModeLabel);
            this.CtlMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlMainPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlMainPanel.Name = "CtlMainPanel";
            this.CtlMainPanel.Size = new System.Drawing.Size(320, 96);
            this.CtlMainPanel.TabIndex = 0;
            // 
            // CtlSplitter
            // 
            this.CtlSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlSplitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlSplitter.Location = new System.Drawing.Point(0, 96);
            this.CtlSplitter.Name = "CtlSplitter";
            this.CtlSplitter.Size = new System.Drawing.Size(320, 5);
            this.CtlSplitter.TabIndex = 1;
            this.CtlSplitter.TabStop = false;
            // 
            // CtlTabsLayers
            // 
            this.CtlTabsLayers.Controls.Add(this.CtlTabInput);
            this.CtlTabsLayers.Controls.Add(this.CtlTabOutput);
            this.CtlTabsLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlTabsLayers.Location = new System.Drawing.Point(0, 101);
            this.CtlTabsLayers.Name = "CtlTabsLayers";
            this.CtlTabsLayers.SelectedIndex = 0;
            this.CtlTabsLayers.Size = new System.Drawing.Size(320, 134);
            this.CtlTabsLayers.TabIndex = 2;
            // 
            // CtlTabInput
            // 
            this.CtlTabInput.Location = new System.Drawing.Point(4, 25);
            this.CtlTabInput.Name = "CtlTabInput";
            this.CtlTabInput.Size = new System.Drawing.Size(312, 105);
            this.CtlTabInput.TabIndex = 0;
            this.CtlTabInput.Text = "Input";
            this.CtlTabInput.UseVisualStyleBackColor = true;
            // 
            // CtlTabOutput
            // 
            this.CtlTabOutput.Location = new System.Drawing.Point(4, 25);
            this.CtlTabOutput.Name = "CtlTabOutput";
            this.CtlTabOutput.Size = new System.Drawing.Size(312, 105);
            this.CtlTabOutput.TabIndex = 1;
            this.CtlTabOutput.Text = "Output";
            this.CtlTabOutput.UseVisualStyleBackColor = true;
            // 
            // CtlContextMenu
            // 
            this.CtlContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddLayer});
            this.CtlContextMenu.Name = "CtlContextMenu";
            this.CtlContextMenu.Size = new System.Drawing.Size(143, 28);
            // 
            // CtlMenuAddLayer
            // 
            this.CtlMenuAddLayer.Name = "CtlMenuAddLayer";
            this.CtlMenuAddLayer.Size = new System.Drawing.Size(142, 24);
            this.CtlMenuAddLayer.Text = "Add layer";
            this.CtlMenuAddLayer.Click += new System.EventHandler(this.CtlMenuAddLayer_Click);
            // 
            // CtlRandomizeModeLabel
            // 
            this.CtlRandomizeModeLabel.AutoSize = true;
            this.CtlRandomizeModeLabel.Location = new System.Drawing.Point(3, 15);
            this.CtlRandomizeModeLabel.Name = "CtlRandomizeModeLabel";
            this.CtlRandomizeModeLabel.Size = new System.Drawing.Size(122, 17);
            this.CtlRandomizeModeLabel.TabIndex = 0;
            this.CtlRandomizeModeLabel.Text = "Randomize mode:";
            // 
            // CtlRandomizer
            // 
            this.CtlRandomizer.FormattingEnabled = true;
            this.CtlRandomizer.Location = new System.Drawing.Point(132, 15);
            this.CtlRandomizer.Name = "CtlRandomizer";
            this.CtlRandomizer.Size = new System.Drawing.Size(170, 24);
            this.CtlRandomizer.TabIndex = 1;
            // 
            // NetworkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.CtlContextMenu;
            this.Controls.Add(this.CtlTabsLayers);
            this.Controls.Add(this.CtlSplitter);
            this.Controls.Add(this.CtlMainPanel);
            this.Name = "NetworkControl";
            this.Size = new System.Drawing.Size(320, 235);
            this.CtlMainPanel.ResumeLayout(false);
            this.CtlMainPanel.PerformLayout();
            this.CtlTabsLayers.ResumeLayout(false);
            this.CtlContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlMainPanel;
        private System.Windows.Forms.Splitter CtlSplitter;
        private System.Windows.Forms.TabControl CtlTabsLayers;
        private System.Windows.Forms.TabPage CtlTabInput;
        private System.Windows.Forms.TabPage CtlTabOutput;
        private System.Windows.Forms.ContextMenuStrip CtlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddLayer;
        private System.Windows.Forms.ComboBox CtlRandomizer;
        private System.Windows.Forms.Label CtlRandomizeModeLabel;
    }
}
