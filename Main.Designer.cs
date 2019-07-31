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
            this.CtlTime = new System.Windows.Forms.Label();
            this.CtlBottomPanel = new System.Windows.Forms.Panel();
            this.CtlReset = new System.Windows.Forms.Button();
            this.CtlStop = new System.Windows.Forms.Button();
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
            this.CtlTabNetwork = new System.Windows.Forms.TabPage();
            this.CtlManagerTools = new System.Windows.Forms.Panel();
            this.CtlApplyChanges = new System.Windows.Forms.Button();
            this.CtlMenu = new System.Windows.Forms.MenuStrip();
            this.CtlMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuNewNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuLoadNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuDeleteNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CtlMainMenuAddLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuDeleteLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CtlMainMenuNewNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlSettingsPanel = new System.Windows.Forms.Panel();
            this.CtlSettingsBottom = new System.Windows.Forms.Panel();
            this.CtlApplySettingsButton = new System.Windows.Forms.Button();
            this.CtlCancelSettingsButton = new System.Windows.Forms.Button();
            this.CtlSettings = new NN.Controls.SettingsControl();
            this.CtlBottomPanel.SuspendLayout();
            this.CtlNetPanel.SuspendLayout();
            this.CtlManagerPanel.SuspendLayout();
            this.CtlTabs.SuspendLayout();
            this.CtlNetworkContextMenu.SuspendLayout();
            this.CtlTabSettings.SuspendLayout();
            this.CtlManagerTools.SuspendLayout();
            this.CtlMenu.SuspendLayout();
            this.CtlSettingsPanel.SuspendLayout();
            this.CtlSettingsBottom.SuspendLayout();
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
            // CtlTime
            // 
            this.CtlTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlTime.Location = new System.Drawing.Point(614, 422);
            this.CtlTime.Name = "CtlTime";
            this.CtlTime.Size = new System.Drawing.Size(100, 15);
            this.CtlTime.TabIndex = 11;
            this.CtlTime.Text = "Time: ...";
            this.CtlTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.CtlBottomPanel.Size = new System.Drawing.Size(1339, 57);
            this.CtlBottomPanel.TabIndex = 14;
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
            // CtlDataPanel
            // 
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
            this.CtlNetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlNetPanel.Location = new System.Drawing.Point(205, 0);
            this.CtlNetPanel.Name = "CtlNetPanel";
            this.CtlNetPanel.Size = new System.Drawing.Size(719, 443);
            this.CtlNetPanel.TabIndex = 17;
            // 
            // CtlPlotSplitter
            // 
            this.CtlPlotSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlPlotSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.CtlPlotSplitter.Location = new System.Drawing.Point(924, 0);
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
            this.CtlManagerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CtlManagerPanel.Location = new System.Drawing.Point(929, 0);
            this.CtlManagerPanel.MinimumSize = new System.Drawing.Size(410, 2);
            this.CtlManagerPanel.Name = "CtlManagerPanel";
            this.CtlManagerPanel.Size = new System.Drawing.Size(410, 443);
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
            this.CtlTabs.Size = new System.Drawing.Size(408, 369);
            this.CtlTabs.TabIndex = 1;
            this.CtlTabs.TabStop = false;
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
            this.CtlTabSettings.Controls.Add(this.CtlSettingsPanel);
            this.CtlTabSettings.Controls.Add(this.CtlSettingsBottom);
            this.CtlTabSettings.Location = new System.Drawing.Point(4, 25);
            this.CtlTabSettings.Name = "CtlTabSettings";
            this.CtlTabSettings.Size = new System.Drawing.Size(400, 340);
            this.CtlTabSettings.TabIndex = 1;
            this.CtlTabSettings.Text = "Settings";
            this.CtlTabSettings.UseVisualStyleBackColor = true;
            // 
            // CtlTabNetwork
            // 
            this.CtlTabNetwork.Location = new System.Drawing.Point(4, 25);
            this.CtlTabNetwork.Name = "CtlTabNetwork";
            this.CtlTabNetwork.Size = new System.Drawing.Size(400, 340);
            this.CtlTabNetwork.TabIndex = 2;
            this.CtlTabNetwork.Text = "Network";
            this.CtlTabNetwork.UseVisualStyleBackColor = true;
            // 
            // CtlManagerTools
            // 
            this.CtlManagerTools.Controls.Add(this.CtlApplyChanges);
            this.CtlManagerTools.Controls.Add(this.CtlMenu);
            this.CtlManagerTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlManagerTools.Location = new System.Drawing.Point(0, 0);
            this.CtlManagerTools.Name = "CtlManagerTools";
            this.CtlManagerTools.Size = new System.Drawing.Size(408, 72);
            this.CtlManagerTools.TabIndex = 0;
            // 
            // CtlApplyChanges
            // 
            this.CtlApplyChanges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CtlApplyChanges.Enabled = false;
            this.CtlApplyChanges.Location = new System.Drawing.Point(0, 41);
            this.CtlApplyChanges.Name = "CtlApplyChanges";
            this.CtlApplyChanges.Size = new System.Drawing.Size(408, 31);
            this.CtlApplyChanges.TabIndex = 1;
            this.CtlApplyChanges.TabStop = false;
            this.CtlApplyChanges.Text = "Save and apply network changes";
            this.CtlApplyChanges.UseVisualStyleBackColor = true;
            this.CtlApplyChanges.Click += new System.EventHandler(this.CtlApplyChanges_Click);
            // 
            // CtlMenu
            // 
            this.CtlMenu.BackColor = System.Drawing.SystemColors.Control;
            this.CtlMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuFile,
            this.CtlMenuRun});
            this.CtlMenu.Location = new System.Drawing.Point(0, 0);
            this.CtlMenu.Name = "CtlMenu";
            this.CtlMenu.Size = new System.Drawing.Size(408, 28);
            this.CtlMenu.TabIndex = 0;
            this.CtlMenu.Text = "menuStrip1";
            // 
            // CtlMenuFile
            // 
            this.CtlMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMainMenuNewNetwork,
            this.CtlMainMenuLoadNetwork,
            this.CtlMainMenuSaveAs,
            this.CtlMainMenuDeleteNetwork,
            this.CtlMainMenuSeparator1,
            this.CtlMainMenuAddLayer,
            this.CtlMainMenuDeleteLayer,
            this.CtlMainMenuSeparator2,
            this.CtlMainMenuNewNeuron});
            this.CtlMenuFile.Name = "CtlMenuFile";
            this.CtlMenuFile.Size = new System.Drawing.Size(44, 24);
            this.CtlMenuFile.Text = "&File";
            // 
            // CtlMainMenuNewNetwork
            // 
            this.CtlMainMenuNewNetwork.Name = "CtlMainMenuNewNetwork";
            this.CtlMainMenuNewNetwork.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.CtlMainMenuNewNetwork.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuNewNetwork.Text = "New Network...";
            this.CtlMainMenuNewNetwork.Click += new System.EventHandler(this.CtlMenuNewNetwork_Click);
            // 
            // CtlMainMenuLoadNetwork
            // 
            this.CtlMainMenuLoadNetwork.Name = "CtlMainMenuLoadNetwork";
            this.CtlMainMenuLoadNetwork.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuLoadNetwork.Text = "Load Network...";
            this.CtlMainMenuLoadNetwork.Click += new System.EventHandler(this.CtlMenuLoadNetwork_Click);
            // 
            // CtlMainMenuSaveAs
            // 
            this.CtlMainMenuSaveAs.Enabled = false;
            this.CtlMainMenuSaveAs.Name = "CtlMainMenuSaveAs";
            this.CtlMainMenuSaveAs.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuSaveAs.Text = "Save As...";
            this.CtlMainMenuSaveAs.Click += new System.EventHandler(this.CtlMainMenuSaveAs_Click);
            // 
            // CtlMainMenuDeleteNetwork
            // 
            this.CtlMainMenuDeleteNetwork.Enabled = false;
            this.CtlMainMenuDeleteNetwork.Name = "CtlMainMenuDeleteNetwork";
            this.CtlMainMenuDeleteNetwork.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuDeleteNetwork.Text = "Delete Network...";
            this.CtlMainMenuDeleteNetwork.Click += new System.EventHandler(this.CtlMenuDeleteNetwork_Click);
            // 
            // CtlMainMenuSeparator1
            // 
            this.CtlMainMenuSeparator1.Name = "CtlMainMenuSeparator1";
            this.CtlMainMenuSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // CtlMainMenuAddLayer
            // 
            this.CtlMainMenuAddLayer.Enabled = false;
            this.CtlMainMenuAddLayer.Name = "CtlMainMenuAddLayer";
            this.CtlMainMenuAddLayer.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuAddLayer.Text = "Add Layer";
            this.CtlMainMenuAddLayer.Click += new System.EventHandler(this.CtlMainMenuAddLayer_Click);
            // 
            // CtlMainMenuDeleteLayer
            // 
            this.CtlMainMenuDeleteLayer.Enabled = false;
            this.CtlMainMenuDeleteLayer.Name = "CtlMainMenuDeleteLayer";
            this.CtlMainMenuDeleteLayer.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuDeleteLayer.Text = "Delete Layer";
            this.CtlMainMenuDeleteLayer.Click += new System.EventHandler(this.CtlMainMenuDeleteLayer_Click);
            // 
            // CtlMainMenuSeparator2
            // 
            this.CtlMainMenuSeparator2.Name = "CtlMainMenuSeparator2";
            this.CtlMainMenuSeparator2.Size = new System.Drawing.Size(233, 6);
            // 
            // CtlMainMenuNewNeuron
            // 
            this.CtlMainMenuNewNeuron.Enabled = false;
            this.CtlMainMenuNewNeuron.Name = "CtlMainMenuNewNeuron";
            this.CtlMainMenuNewNeuron.Size = new System.Drawing.Size(236, 26);
            this.CtlMainMenuNewNeuron.Text = "New Neuron";
            // 
            // CtlMenuRun
            // 
            this.CtlMenuRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuStart});
            this.CtlMenuRun.Name = "CtlMenuRun";
            this.CtlMenuRun.Size = new System.Drawing.Size(46, 24);
            this.CtlMenuRun.Text = "&Run";
            // 
            // CtlMenuStart
            // 
            this.CtlMenuStart.Name = "CtlMenuStart";
            this.CtlMenuStart.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.CtlMenuStart.Size = new System.Drawing.Size(139, 26);
            this.CtlMenuStart.Text = "Start";
            // 
            // CtlSettingsPanel
            // 
            this.CtlSettingsPanel.AutoScroll = true;
            this.CtlSettingsPanel.Controls.Add(this.CtlSettings);
            this.CtlSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlSettingsPanel.Name = "CtlSettingsPanel";
            this.CtlSettingsPanel.Size = new System.Drawing.Size(400, 301);
            this.CtlSettingsPanel.TabIndex = 3;
            // 
            // CtlSettingsBottom
            // 
            this.CtlSettingsBottom.Controls.Add(this.CtlCancelSettingsButton);
            this.CtlSettingsBottom.Controls.Add(this.CtlApplySettingsButton);
            this.CtlSettingsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CtlSettingsBottom.Location = new System.Drawing.Point(0, 301);
            this.CtlSettingsBottom.Name = "CtlSettingsBottom";
            this.CtlSettingsBottom.Size = new System.Drawing.Size(400, 39);
            this.CtlSettingsBottom.TabIndex = 4;
            // 
            // CtlApplySettingsButton
            // 
            this.CtlApplySettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlApplySettingsButton.Enabled = false;
            this.CtlApplySettingsButton.Location = new System.Drawing.Point(235, 6);
            this.CtlApplySettingsButton.Name = "CtlApplySettingsButton";
            this.CtlApplySettingsButton.Size = new System.Drawing.Size(75, 28);
            this.CtlApplySettingsButton.TabIndex = 0;
            this.CtlApplySettingsButton.Text = "Apply";
            this.CtlApplySettingsButton.UseVisualStyleBackColor = true;
            this.CtlApplySettingsButton.Click += new System.EventHandler(this.CtlApplySettingsButton_Click);
            // 
            // CtlCancelSettingsButton
            // 
            this.CtlCancelSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlCancelSettingsButton.Enabled = false;
            this.CtlCancelSettingsButton.Location = new System.Drawing.Point(316, 6);
            this.CtlCancelSettingsButton.Name = "CtlCancelSettingsButton";
            this.CtlCancelSettingsButton.Size = new System.Drawing.Size(75, 28);
            this.CtlCancelSettingsButton.TabIndex = 1;
            this.CtlCancelSettingsButton.Text = "Cancel";
            this.CtlCancelSettingsButton.UseVisualStyleBackColor = true;
            this.CtlCancelSettingsButton.Click += new System.EventHandler(this.CtlCancelSettingsButton_Click);
            // 
            // CtlSettings
            // 
            this.CtlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlSettings.Location = new System.Drawing.Point(0, 0);
            this.CtlSettings.Name = "CtlSettings";
            this.CtlSettings.Settings = null;
            this.CtlSettings.Size = new System.Drawing.Size(379, 505);
            this.CtlSettings.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 500);
            this.Controls.Add(this.CtlNetPanel);
            this.Controls.Add(this.CtlPlotSplitter);
            this.Controls.Add(this.CtlManagerPanel);
            this.Controls.Add(this.CtlDataSplitter);
            this.Controls.Add(this.CtlDataPanel);
            this.Controls.Add(this.CtlBottomPanel);
            this.DoubleBuffered = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neural Network";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.CtlBottomPanel.ResumeLayout(false);
            this.CtlNetPanel.ResumeLayout(false);
            this.CtlManagerPanel.ResumeLayout(false);
            this.CtlTabs.ResumeLayout(false);
            this.CtlNetworkContextMenu.ResumeLayout(false);
            this.CtlTabSettings.ResumeLayout(false);
            this.CtlManagerTools.ResumeLayout(false);
            this.CtlManagerTools.PerformLayout();
            this.CtlMenu.ResumeLayout(false);
            this.CtlMenu.PerformLayout();
            this.CtlSettingsPanel.ResumeLayout(false);
            this.CtlSettingsBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CtlStart;
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
        private System.Windows.Forms.ToolStripMenuItem CtlMenuFile;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuRun;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuStart;
        private System.Windows.Forms.TabPage CtlTabNetwork;
        private System.Windows.Forms.ContextMenuStrip CtlNetworkContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuNewNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuDeleteNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuLoadNetwork;
        private System.Windows.Forms.Button CtlStop;
        private System.Windows.Forms.Button CtlReset;
        private System.Windows.Forms.Button CtlApplyChanges;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuNewNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuLoadNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuDeleteNetwork;
        private System.Windows.Forms.ToolStripSeparator CtlMainMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuAddLayer;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuDeleteLayer;
        private System.Windows.Forms.ToolStripSeparator CtlMainMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuNewNeuron;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuSaveAs;
        private System.Windows.Forms.Panel CtlSettingsBottom;
        private System.Windows.Forms.Button CtlCancelSettingsButton;
        private System.Windows.Forms.Button CtlApplySettingsButton;
        private System.Windows.Forms.Panel CtlSettingsPanel;
        private Controls.SettingsControl CtlSettings;
    }
}

