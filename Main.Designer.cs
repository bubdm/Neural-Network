namespace NN
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CtlStart = new System.Windows.Forms.Button();
            this.CtlDefaultInputCount = new System.Windows.Forms.NumericUpDown();
            this.CtlTime = new System.Windows.Forms.Label();
            this.CtlBottomPanel = new System.Windows.Forms.Panel();
            this.CtlDataPanel = new System.Windows.Forms.Panel();
            this.CtlDataSplitter = new System.Windows.Forms.Splitter();
            this.CtlNetPanel = new System.Windows.Forms.Panel();
            this.CtlPlotSplitter = new System.Windows.Forms.Splitter();
            this.CtlManagerPanel = new System.Windows.Forms.Panel();
            this.CtlTabs = new System.Windows.Forms.TabControl();
            this.CtlNetworkContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuNewNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuLoadNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuDeleteNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlTabSettings = new System.Windows.Forms.TabPage();
            this.CtlDefaultRandomizer = new System.Windows.Forms.ComboBox();
            this.CtlDefaultRandomizerLabel = new System.Windows.Forms.Label();
            this.CtlDefaultInputCountLabel = new System.Windows.Forms.Label();
            this.CtlTabNetwork = new System.Windows.Forms.TabPage();
            this.CtlManagerTools = new System.Windows.Forms.Panel();
            this.CtlMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlStop = new System.Windows.Forms.Button();
            this.CtlReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CtlDefaultInputCount)).BeginInit();
            this.CtlBottomPanel.SuspendLayout();
            this.CtlNetPanel.SuspendLayout();
            this.CtlManagerPanel.SuspendLayout();
            this.CtlTabs.SuspendLayout();
            this.CtlNetworkContextMenu.SuspendLayout();
            this.CtlTabSettings.SuspendLayout();
            this.CtlManagerTools.SuspendLayout();
            this.CtlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlStart
            // 
            this.CtlStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CtlStart.Enabled = false;
            this.CtlStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlStart.Location = new System.Drawing.Point(12, 13);
            this.CtlStart.Name = "CtlStart";
            this.CtlStart.Size = new System.Drawing.Size(97, 32);
            this.CtlStart.TabIndex = 1;
            this.CtlStart.Text = "Start";
            this.CtlStart.UseVisualStyleBackColor = true;
            this.CtlStart.Click += new System.EventHandler(this.CtlStart_Click);
            // 
            // CtlDefaultInputCount
            // 
            this.CtlDefaultInputCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlDefaultInputCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlDefaultInputCount.Location = new System.Drawing.Point(136, 3);
            this.CtlDefaultInputCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CtlDefaultInputCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlDefaultInputCount.Name = "CtlDefaultInputCount";
            this.CtlDefaultInputCount.Size = new System.Drawing.Size(120, 22);
            this.CtlDefaultInputCount.TabIndex = 8;
            this.CtlDefaultInputCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // CtlTime
            // 
            this.CtlTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlTime.AutoSize = true;
            this.CtlTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlTime.Location = new System.Drawing.Point(680, 420);
            this.CtlTime.Name = "CtlTime";
            this.CtlTime.Size = new System.Drawing.Size(50, 15);
            this.CtlTime.TabIndex = 11;
            this.CtlTime.Text = "Time: ...";
            // 
            // CtlBottomPanel
            // 
            this.CtlBottomPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CtlBottomPanel.Controls.Add(this.CtlReset);
            this.CtlBottomPanel.Controls.Add(this.CtlStop);
            this.CtlBottomPanel.Controls.Add(this.CtlStart);
            this.CtlBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CtlBottomPanel.Location = new System.Drawing.Point(0, 443);
            this.CtlBottomPanel.Name = "CtlBottomPanel";
            this.CtlBottomPanel.Size = new System.Drawing.Size(1226, 57);
            this.CtlBottomPanel.TabIndex = 14;
            // 
            // CtlDataPanel
            // 
            this.CtlDataPanel.AutoScroll = true;
            this.CtlDataPanel.BackColor = System.Drawing.Color.White;
            this.CtlDataPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlDataPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CtlDataPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlDataPanel.Name = "CtlDataPanel";
            this.CtlDataPanel.Size = new System.Drawing.Size(200, 443);
            this.CtlDataPanel.TabIndex = 15;
            this.CtlDataPanel.SizeChanged += new System.EventHandler(this.CtlDataPanel_SizeChanged);
            // 
            // CtlDataSplitter
            // 
            this.CtlDataSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlDataSplitter.Location = new System.Drawing.Point(200, 0);
            this.CtlDataSplitter.Name = "CtlDataSplitter";
            this.CtlDataSplitter.Size = new System.Drawing.Size(5, 443);
            this.CtlDataSplitter.TabIndex = 16;
            this.CtlDataSplitter.TabStop = false;
            // 
            // CtlNetPanel
            // 
            this.CtlNetPanel.AutoScroll = true;
            this.CtlNetPanel.BackColor = System.Drawing.Color.White;
            this.CtlNetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlNetPanel.Controls.Add(this.CtlTime);
            this.CtlNetPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CtlNetPanel.Location = new System.Drawing.Point(205, 0);
            this.CtlNetPanel.Name = "CtlNetPanel";
            this.CtlNetPanel.Size = new System.Drawing.Size(747, 443);
            this.CtlNetPanel.TabIndex = 17;
            // 
            // CtlPlotSplitter
            // 
            this.CtlPlotSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlPlotSplitter.Location = new System.Drawing.Point(952, 0);
            this.CtlPlotSplitter.Name = "CtlPlotSplitter";
            this.CtlPlotSplitter.Size = new System.Drawing.Size(5, 443);
            this.CtlPlotSplitter.TabIndex = 18;
            this.CtlPlotSplitter.TabStop = false;
            // 
            // CtlManagerPanel
            // 
            this.CtlManagerPanel.AutoScroll = true;
            this.CtlManagerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlManagerPanel.Controls.Add(this.CtlTabs);
            this.CtlManagerPanel.Controls.Add(this.CtlManagerTools);
            this.CtlManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlManagerPanel.Location = new System.Drawing.Point(957, 0);
            this.CtlManagerPanel.Name = "CtlManagerPanel";
            this.CtlManagerPanel.Size = new System.Drawing.Size(269, 443);
            this.CtlManagerPanel.TabIndex = 19;
            // 
            // CtlTabs
            // 
            this.CtlTabs.ContextMenuStrip = this.CtlNetworkContextMenu;
            this.CtlTabs.Controls.Add(this.CtlTabSettings);
            this.CtlTabs.Controls.Add(this.CtlTabNetwork);
            this.CtlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlTabs.Location = new System.Drawing.Point(0, 72);
            this.CtlTabs.Name = "CtlTabs";
            this.CtlTabs.SelectedIndex = 0;
            this.CtlTabs.Size = new System.Drawing.Size(267, 369);
            this.CtlTabs.TabIndex = 1;
            // 
            // CtlNetworkContextMenu
            // 
            this.CtlNetworkContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlNetworkContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuNewNetwork,
            this.CtlMenuLoadNetwork,
            this.CtlMenuDeleteNetwork});
            this.CtlNetworkContextMenu.Name = "CtlNetworkContextMenu";
            this.CtlNetworkContextMenu.Size = new System.Drawing.Size(180, 76);
            // 
            // CtlMenuNewNetwork
            // 
            this.CtlMenuNewNetwork.Name = "CtlMenuNewNetwork";
            this.CtlMenuNewNetwork.Size = new System.Drawing.Size(179, 24);
            this.CtlMenuNewNetwork.Text = "New network...";
            this.CtlMenuNewNetwork.Click += new System.EventHandler(this.CtlMenuNewNetwork_Click);
            // 
            // CtlMenuLoadNetwork
            // 
            this.CtlMenuLoadNetwork.Name = "CtlMenuLoadNetwork";
            this.CtlMenuLoadNetwork.Size = new System.Drawing.Size(179, 24);
            this.CtlMenuLoadNetwork.Text = "Load network...";
            this.CtlMenuLoadNetwork.Click += new System.EventHandler(this.CtlMenuLoadNetwork_Click);
            // 
            // CtlMenuDeleteNetwork
            // 
            this.CtlMenuDeleteNetwork.Enabled = false;
            this.CtlMenuDeleteNetwork.Name = "CtlMenuDeleteNetwork";
            this.CtlMenuDeleteNetwork.Size = new System.Drawing.Size(179, 24);
            this.CtlMenuDeleteNetwork.Text = "Delete network";
            this.CtlMenuDeleteNetwork.Click += new System.EventHandler(this.CtlMenuDeleteNetwork_Click);
            // 
            // CtlTabSettings
            // 
            this.CtlTabSettings.Controls.Add(this.CtlDefaultRandomizer);
            this.CtlTabSettings.Controls.Add(this.CtlDefaultRandomizerLabel);
            this.CtlTabSettings.Controls.Add(this.CtlDefaultInputCountLabel);
            this.CtlTabSettings.Controls.Add(this.CtlDefaultInputCount);
            this.CtlTabSettings.Location = new System.Drawing.Point(4, 25);
            this.CtlTabSettings.Name = "CtlTabSettings";
            this.CtlTabSettings.Size = new System.Drawing.Size(259, 340);
            this.CtlTabSettings.TabIndex = 1;
            this.CtlTabSettings.Text = "Settings";
            this.CtlTabSettings.UseVisualStyleBackColor = true;
            // 
            // CtlDefaultRandomizer
            // 
            this.CtlDefaultRandomizer.FormattingEnabled = true;
            this.CtlDefaultRandomizer.Location = new System.Drawing.Point(136, 46);
            this.CtlDefaultRandomizer.Name = "CtlDefaultRandomizer";
            this.CtlDefaultRandomizer.Size = new System.Drawing.Size(101, 24);
            this.CtlDefaultRandomizer.TabIndex = 11;
            // 
            // CtlDefaultRandomizerLabel
            // 
            this.CtlDefaultRandomizerLabel.AutoSize = true;
            this.CtlDefaultRandomizerLabel.Location = new System.Drawing.Point(3, 46);
            this.CtlDefaultRandomizerLabel.Name = "CtlDefaultRandomizerLabel";
            this.CtlDefaultRandomizerLabel.Size = new System.Drawing.Size(132, 17);
            this.CtlDefaultRandomizerLabel.TabIndex = 10;
            this.CtlDefaultRandomizerLabel.Text = "Default randomizer:";
            // 
            // CtlDefaultInputCountLabel
            // 
            this.CtlDefaultInputCountLabel.AutoSize = true;
            this.CtlDefaultInputCountLabel.Location = new System.Drawing.Point(3, 5);
            this.CtlDefaultInputCountLabel.Name = "CtlDefaultInputCountLabel";
            this.CtlDefaultInputCountLabel.Size = new System.Drawing.Size(131, 17);
            this.CtlDefaultInputCountLabel.TabIndex = 9;
            this.CtlDefaultInputCountLabel.Text = "Default input count:";
            // 
            // CtlTabNetwork
            // 
            this.CtlTabNetwork.Location = new System.Drawing.Point(4, 25);
            this.CtlTabNetwork.Name = "CtlTabNetwork";
            this.CtlTabNetwork.Size = new System.Drawing.Size(259, 340);
            this.CtlTabNetwork.TabIndex = 2;
            this.CtlTabNetwork.Text = "Network";
            this.CtlTabNetwork.UseVisualStyleBackColor = true;
            // 
            // CtlManagerTools
            // 
            this.CtlManagerTools.Controls.Add(this.CtlMenu);
            this.CtlManagerTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlManagerTools.Location = new System.Drawing.Point(0, 0);
            this.CtlManagerTools.Name = "CtlManagerTools";
            this.CtlManagerTools.Size = new System.Drawing.Size(267, 72);
            this.CtlManagerTools.TabIndex = 0;
            // 
            // CtlMenu
            // 
            this.CtlMenu.BackColor = System.Drawing.SystemColors.Control;
            this.CtlMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
            this.CtlMenu.Location = new System.Drawing.Point(0, 0);
            this.CtlMenu.Name = "CtlMenu";
            this.CtlMenu.Size = new System.Drawing.Size(267, 28);
            this.CtlMenu.TabIndex = 0;
            this.CtlMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuStart});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.runToolStripMenuItem.Text = "&Run";
            // 
            // CtlMenuStart
            // 
            this.CtlMenuStart.Name = "CtlMenuStart";
            this.CtlMenuStart.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.CtlMenuStart.Size = new System.Drawing.Size(139, 26);
            this.CtlMenuStart.Text = "Start";
            // 
            // CtlStop
            // 
            this.CtlStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CtlStop.Enabled = false;
            this.CtlStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlStop.Location = new System.Drawing.Point(115, 13);
            this.CtlStop.Name = "CtlStop";
            this.CtlStop.Size = new System.Drawing.Size(97, 32);
            this.CtlStop.TabIndex = 2;
            this.CtlStop.Text = "Stop";
            this.CtlStop.UseVisualStyleBackColor = true;
            this.CtlStop.Click += new System.EventHandler(this.CtlStop_Click);
            // 
            // CtlReset
            // 
            this.CtlReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CtlReset.Enabled = false;
            this.CtlReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlReset.Location = new System.Drawing.Point(218, 13);
            this.CtlReset.Name = "CtlReset";
            this.CtlReset.Size = new System.Drawing.Size(97, 32);
            this.CtlReset.TabIndex = 3;
            this.CtlReset.Text = "Reset";
            this.CtlReset.UseVisualStyleBackColor = true;
            this.CtlReset.Click += new System.EventHandler(this.CtlReset_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 500);
            this.Controls.Add(this.CtlManagerPanel);
            this.Controls.Add(this.CtlPlotSplitter);
            this.Controls.Add(this.CtlNetPanel);
            this.Controls.Add(this.CtlDataSplitter);
            this.Controls.Add(this.CtlDataPanel);
            this.Controls.Add(this.CtlBottomPanel);
            this.DoubleBuffered = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neural Network";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CtlDefaultInputCount)).EndInit();
            this.CtlBottomPanel.ResumeLayout(false);
            this.CtlNetPanel.ResumeLayout(false);
            this.CtlNetPanel.PerformLayout();
            this.CtlManagerPanel.ResumeLayout(false);
            this.CtlTabs.ResumeLayout(false);
            this.CtlNetworkContextMenu.ResumeLayout(false);
            this.CtlTabSettings.ResumeLayout(false);
            this.CtlTabSettings.PerformLayout();
            this.CtlManagerTools.ResumeLayout(false);
            this.CtlManagerTools.PerformLayout();
            this.CtlMenu.ResumeLayout(false);
            this.CtlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CtlStart;
        private System.Windows.Forms.NumericUpDown CtlDefaultInputCount;
        private System.Windows.Forms.Label CtlTime;
        private System.Windows.Forms.Panel CtlBottomPanel;
        private System.Windows.Forms.Panel CtlDataPanel;
        private System.Windows.Forms.Splitter CtlDataSplitter;
        private System.Windows.Forms.Panel CtlNetPanel;
        private System.Windows.Forms.Splitter CtlPlotSplitter;
        private System.Windows.Forms.Panel CtlManagerPanel;
        private System.Windows.Forms.Panel CtlManagerTools;
        private System.Windows.Forms.TabControl CtlTabs;
        private System.Windows.Forms.TabPage CtlTabSettings;
        private System.Windows.Forms.MenuStrip CtlMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuStart;
        private System.Windows.Forms.TabPage CtlTabNetwork;
        private System.Windows.Forms.ContextMenuStrip CtlNetworkContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuNewNetwork;
        private System.Windows.Forms.Label CtlDefaultInputCountLabel;
        private System.Windows.Forms.ComboBox CtlDefaultRandomizer;
        private System.Windows.Forms.Label CtlDefaultRandomizerLabel;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuDeleteNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuLoadNetwork;
        private System.Windows.Forms.Button CtlStop;
        private System.Windows.Forms.Button CtlReset;
    }
}

