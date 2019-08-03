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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.CtlStart = new System.Windows.Forms.Button();
            this.CtlTime = new System.Windows.Forms.Label();
            this.CtlBottomPanel = new System.Windows.Forms.Panel();
            this.CtlReset = new System.Windows.Forms.Button();
            this.CtlStop = new System.Windows.Forms.Button();
            this.CtlDataSplitter = new System.Windows.Forms.Splitter();
            this.CtlNetPanel = new System.Windows.Forms.Panel();
            this.CtlStatisticsPresenter = new NN.Controls.StatisticsPresenter();
            this.CtlPlotPresenter = new NN.Controls.PlotterPresenter();
            this.CtlNetworkPresenter = new NN.Controls.NetworkPresenter();
            this.CtlPlotSplitter = new System.Windows.Forms.Splitter();
            this.CtlManagerPanel = new System.Windows.Forms.Panel();
            this.CtlTabs = new System.Windows.Forms.TabControl();
            this.CtlNetworkContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtlMenuAddNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMenuDeleteNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlTabSettings = new System.Windows.Forms.TabPage();
            this.CtlSettingsPanel = new System.Windows.Forms.Panel();
            this.CtlSettings = new NN.Controls.SettingsControl();
            this.CtlSettingsBottom = new System.Windows.Forms.Panel();
            this.CtlCancelSettingsButton = new System.Windows.Forms.Button();
            this.CtlApplySettingsButton = new System.Windows.Forms.Button();
            this.CtlManagerTools = new System.Windows.Forms.Panel();
            this.CtlApplyChanges = new System.Windows.Forms.Button();
            this.CtlMenu = new System.Windows.Forms.MenuStrip();
            this.CtlMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CtlMenuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuAddNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuDeleteNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CtlMainMenuAddLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuDeleteLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlMainMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CtlMainMenuAddNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.CtlInputDataPresenter = new NN.Controls.DataPresenter();
            this.CtlMatrixPresenter = new NN.Controls.MatrixPresenter();
            this.CtlBottomPanel.SuspendLayout();
            this.CtlNetPanel.SuspendLayout();
            this.CtlManagerPanel.SuspendLayout();
            this.CtlTabs.SuspendLayout();
            this.CtlNetworkContextMenu.SuspendLayout();
            this.CtlTabSettings.SuspendLayout();
            this.CtlSettingsPanel.SuspendLayout();
            this.CtlSettingsBottom.SuspendLayout();
            this.CtlManagerTools.SuspendLayout();
            this.CtlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlStart
            // 
            resources.ApplyResources(this.CtlStart, "CtlStart");
            this.CtlStart.Name = "CtlStart";
            this.CtlStart.UseVisualStyleBackColor = true;
            this.CtlStart.Click += new System.EventHandler(this.CtlStart_Click);
            // 
            // CtlTime
            // 
            resources.ApplyResources(this.CtlTime, "CtlTime");
            this.CtlTime.Name = "CtlTime";
            // 
            // CtlBottomPanel
            // 
            this.CtlBottomPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CtlBottomPanel.Controls.Add(this.CtlReset);
            this.CtlBottomPanel.Controls.Add(this.CtlStop);
            this.CtlBottomPanel.Controls.Add(this.CtlStart);
            resources.ApplyResources(this.CtlBottomPanel, "CtlBottomPanel");
            this.CtlBottomPanel.Name = "CtlBottomPanel";
            // 
            // CtlReset
            // 
            resources.ApplyResources(this.CtlReset, "CtlReset");
            this.CtlReset.Name = "CtlReset";
            this.CtlReset.UseVisualStyleBackColor = true;
            this.CtlReset.Click += new System.EventHandler(this.CtlReset_Click);
            // 
            // CtlStop
            // 
            resources.ApplyResources(this.CtlStop, "CtlStop");
            this.CtlStop.Name = "CtlStop";
            this.CtlStop.UseVisualStyleBackColor = true;
            this.CtlStop.Click += new System.EventHandler(this.CtlStop_Click);
            // 
            // CtlDataSplitter
            // 
            this.CtlDataSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.CtlDataSplitter, "CtlDataSplitter");
            this.CtlDataSplitter.Name = "CtlDataSplitter";
            this.CtlDataSplitter.TabStop = false;
            // 
            // CtlNetPanel
            // 
            resources.ApplyResources(this.CtlNetPanel, "CtlNetPanel");
            this.CtlNetPanel.BackColor = System.Drawing.Color.White;
            this.CtlNetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlNetPanel.Controls.Add(this.CtlMatrixPresenter);
            this.CtlNetPanel.Controls.Add(this.CtlStatisticsPresenter);
            this.CtlNetPanel.Controls.Add(this.CtlPlotPresenter);
            this.CtlNetPanel.Controls.Add(this.CtlNetworkPresenter);
            this.CtlNetPanel.Controls.Add(this.CtlTime);
            this.CtlNetPanel.Name = "CtlNetPanel";
            // 
            // CtlStatisticsPresenter
            // 
            resources.ApplyResources(this.CtlStatisticsPresenter, "CtlStatisticsPresenter");
            this.CtlStatisticsPresenter.BackColor = System.Drawing.Color.White;
            this.CtlStatisticsPresenter.Name = "CtlStatisticsPresenter";
            // 
            // CtlPlotPresenter
            // 
            resources.ApplyResources(this.CtlPlotPresenter, "CtlPlotPresenter");
            this.CtlPlotPresenter.BackColor = System.Drawing.Color.White;
            this.CtlPlotPresenter.Name = "CtlPlotPresenter";
            // 
            // CtlNetworkPresenter
            // 
            this.CtlNetworkPresenter.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.CtlNetworkPresenter, "CtlNetworkPresenter");
            this.CtlNetworkPresenter.Name = "CtlNetworkPresenter";
            // 
            // CtlPlotSplitter
            // 
            this.CtlPlotSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.CtlPlotSplitter, "CtlPlotSplitter");
            this.CtlPlotSplitter.Name = "CtlPlotSplitter";
            this.CtlPlotSplitter.TabStop = false;
            // 
            // CtlManagerPanel
            // 
            resources.ApplyResources(this.CtlManagerPanel, "CtlManagerPanel");
            this.CtlManagerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlManagerPanel.Controls.Add(this.CtlTabs);
            this.CtlManagerPanel.Controls.Add(this.CtlManagerTools);
            this.CtlManagerPanel.Name = "CtlManagerPanel";
            // 
            // CtlTabs
            // 
            this.CtlTabs.ContextMenuStrip = this.CtlNetworkContextMenu;
            this.CtlTabs.Controls.Add(this.CtlTabSettings);
            resources.ApplyResources(this.CtlTabs, "CtlTabs");
            this.CtlTabs.Name = "CtlTabs";
            this.CtlTabs.SelectedIndex = 0;
            this.CtlTabs.TabStop = false;
            this.CtlTabs.SelectedIndexChanged += new System.EventHandler(this.CtlTabs_SelectedIndexChanged);
            // 
            // CtlNetworkContextMenu
            // 
            this.CtlNetworkContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlNetworkContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuAddNetwork,
            this.CtlMenuDeleteNetwork});
            this.CtlNetworkContextMenu.Name = "CtlNetworkContextMenu";
            resources.ApplyResources(this.CtlNetworkContextMenu, "CtlNetworkContextMenu");
            this.CtlNetworkContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.CtlNetworkContextMenu_Opening);
            // 
            // CtlMenuAddNetwork
            // 
            this.CtlMenuAddNetwork.Name = "CtlMenuAddNetwork";
            resources.ApplyResources(this.CtlMenuAddNetwork, "CtlMenuAddNetwork");
            this.CtlMenuAddNetwork.Click += new System.EventHandler(this.CtlMainMenuAddNetwork_Click);
            // 
            // CtlMenuDeleteNetwork
            // 
            this.CtlMenuDeleteNetwork.Name = "CtlMenuDeleteNetwork";
            resources.ApplyResources(this.CtlMenuDeleteNetwork, "CtlMenuDeleteNetwork");
            this.CtlMenuDeleteNetwork.Click += new System.EventHandler(this.CtlMainMenuDeleteNetwork_Click);
            // 
            // CtlTabSettings
            // 
            this.CtlTabSettings.Controls.Add(this.CtlSettingsPanel);
            this.CtlTabSettings.Controls.Add(this.CtlSettingsBottom);
            resources.ApplyResources(this.CtlTabSettings, "CtlTabSettings");
            this.CtlTabSettings.Name = "CtlTabSettings";
            this.CtlTabSettings.UseVisualStyleBackColor = true;
            // 
            // CtlSettingsPanel
            // 
            resources.ApplyResources(this.CtlSettingsPanel, "CtlSettingsPanel");
            this.CtlSettingsPanel.Controls.Add(this.CtlSettings);
            this.CtlSettingsPanel.Name = "CtlSettingsPanel";
            // 
            // CtlSettings
            // 
            this.CtlSettings.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.CtlSettings, "CtlSettings");
            this.CtlSettings.Name = "CtlSettings";
            this.CtlSettings.Settings = null;
            // 
            // CtlSettingsBottom
            // 
            this.CtlSettingsBottom.Controls.Add(this.CtlCancelSettingsButton);
            this.CtlSettingsBottom.Controls.Add(this.CtlApplySettingsButton);
            resources.ApplyResources(this.CtlSettingsBottom, "CtlSettingsBottom");
            this.CtlSettingsBottom.Name = "CtlSettingsBottom";
            // 
            // CtlCancelSettingsButton
            // 
            resources.ApplyResources(this.CtlCancelSettingsButton, "CtlCancelSettingsButton");
            this.CtlCancelSettingsButton.Name = "CtlCancelSettingsButton";
            this.CtlCancelSettingsButton.UseVisualStyleBackColor = true;
            this.CtlCancelSettingsButton.Click += new System.EventHandler(this.CtlCancelSettingsButton_Click);
            // 
            // CtlApplySettingsButton
            // 
            resources.ApplyResources(this.CtlApplySettingsButton, "CtlApplySettingsButton");
            this.CtlApplySettingsButton.Name = "CtlApplySettingsButton";
            this.CtlApplySettingsButton.UseVisualStyleBackColor = true;
            this.CtlApplySettingsButton.Click += new System.EventHandler(this.CtlApplySettingsButton_Click);
            // 
            // CtlManagerTools
            // 
            this.CtlManagerTools.Controls.Add(this.CtlApplyChanges);
            this.CtlManagerTools.Controls.Add(this.CtlMenu);
            resources.ApplyResources(this.CtlManagerTools, "CtlManagerTools");
            this.CtlManagerTools.Name = "CtlManagerTools";
            // 
            // CtlApplyChanges
            // 
            resources.ApplyResources(this.CtlApplyChanges, "CtlApplyChanges");
            this.CtlApplyChanges.Name = "CtlApplyChanges";
            this.CtlApplyChanges.TabStop = false;
            this.CtlApplyChanges.UseVisualStyleBackColor = true;
            this.CtlApplyChanges.Click += new System.EventHandler(this.CtlApplyChanges_Click);
            // 
            // CtlMenu
            // 
            this.CtlMenu.BackColor = System.Drawing.Color.White;
            this.CtlMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMenuFile,
            this.CtlMenuNetwork});
            resources.ApplyResources(this.CtlMenu, "CtlMenu");
            this.CtlMenu.Name = "CtlMenu";
            // 
            // CtlMenuFile
            // 
            this.CtlMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMainMenuNew,
            this.CtlMainMenuLoad,
            this.CtlMainMenuSaveAs,
            this.CtlMainMenuSeparator1});
            this.CtlMenuFile.Name = "CtlMenuFile";
            resources.ApplyResources(this.CtlMenuFile, "CtlMenuFile");
            // 
            // CtlMainMenuNew
            // 
            this.CtlMainMenuNew.Name = "CtlMainMenuNew";
            resources.ApplyResources(this.CtlMainMenuNew, "CtlMainMenuNew");
            this.CtlMainMenuNew.Click += new System.EventHandler(this.CtlMenuNew_Click);
            // 
            // CtlMainMenuLoad
            // 
            this.CtlMainMenuLoad.Name = "CtlMainMenuLoad";
            resources.ApplyResources(this.CtlMainMenuLoad, "CtlMainMenuLoad");
            this.CtlMainMenuLoad.Click += new System.EventHandler(this.CtlMenuLoad_Click);
            // 
            // CtlMainMenuSaveAs
            // 
            resources.ApplyResources(this.CtlMainMenuSaveAs, "CtlMainMenuSaveAs");
            this.CtlMainMenuSaveAs.Name = "CtlMainMenuSaveAs";
            this.CtlMainMenuSaveAs.Click += new System.EventHandler(this.CtlMainMenuSaveAs_Click);
            // 
            // CtlMainMenuSeparator1
            // 
            this.CtlMainMenuSeparator1.Name = "CtlMainMenuSeparator1";
            resources.ApplyResources(this.CtlMainMenuSeparator1, "CtlMainMenuSeparator1");
            // 
            // CtlMenuNetwork
            // 
            this.CtlMenuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtlMainMenuAddNetwork,
            this.CtlMainMenuDeleteNetwork,
            this.CtlMainMenuSeparator2,
            this.CtlMainMenuAddLayer,
            this.CtlMainMenuDeleteLayer,
            this.CtlMainMenuSeparator3,
            this.CtlMainMenuAddNeuron});
            resources.ApplyResources(this.CtlMenuNetwork, "CtlMenuNetwork");
            this.CtlMenuNetwork.Name = "CtlMenuNetwork";
            this.CtlMenuNetwork.Click += new System.EventHandler(this.CtlMenuNetwork_Click);
            // 
            // CtlMainMenuAddNetwork
            // 
            this.CtlMainMenuAddNetwork.Name = "CtlMainMenuAddNetwork";
            resources.ApplyResources(this.CtlMainMenuAddNetwork, "CtlMainMenuAddNetwork");
            this.CtlMainMenuAddNetwork.Click += new System.EventHandler(this.CtlMainMenuAddNetwork_Click);
            // 
            // CtlMainMenuDeleteNetwork
            // 
            this.CtlMainMenuDeleteNetwork.Name = "CtlMainMenuDeleteNetwork";
            resources.ApplyResources(this.CtlMainMenuDeleteNetwork, "CtlMainMenuDeleteNetwork");
            this.CtlMainMenuDeleteNetwork.Click += new System.EventHandler(this.CtlMainMenuDeleteNetwork_Click);
            // 
            // CtlMainMenuSeparator2
            // 
            this.CtlMainMenuSeparator2.Name = "CtlMainMenuSeparator2";
            resources.ApplyResources(this.CtlMainMenuSeparator2, "CtlMainMenuSeparator2");
            // 
            // CtlMainMenuAddLayer
            // 
            this.CtlMainMenuAddLayer.Name = "CtlMainMenuAddLayer";
            resources.ApplyResources(this.CtlMainMenuAddLayer, "CtlMainMenuAddLayer");
            this.CtlMainMenuAddLayer.Click += new System.EventHandler(this.CtlMainMenuAddLayer_Click);
            // 
            // CtlMainMenuDeleteLayer
            // 
            this.CtlMainMenuDeleteLayer.Name = "CtlMainMenuDeleteLayer";
            resources.ApplyResources(this.CtlMainMenuDeleteLayer, "CtlMainMenuDeleteLayer");
            this.CtlMainMenuDeleteLayer.Click += new System.EventHandler(this.CtlMainMenuDeleteLayer_Click);
            // 
            // CtlMainMenuSeparator3
            // 
            this.CtlMainMenuSeparator3.Name = "CtlMainMenuSeparator3";
            resources.ApplyResources(this.CtlMainMenuSeparator3, "CtlMainMenuSeparator3");
            // 
            // CtlMainMenuAddNeuron
            // 
            this.CtlMainMenuAddNeuron.Name = "CtlMainMenuAddNeuron";
            resources.ApplyResources(this.CtlMainMenuAddNeuron, "CtlMainMenuAddNeuron");
            this.CtlMainMenuAddNeuron.Click += new System.EventHandler(this.CtlMainMenuAddNeuron_Click);
            // 
            // CtlInputDataPresenter
            // 
            this.CtlInputDataPresenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.CtlInputDataPresenter, "CtlInputDataPresenter");
            this.CtlInputDataPresenter.Name = "CtlInputDataPresenter";
            // 
            // CtlMatrixPresenter
            // 
            resources.ApplyResources(this.CtlMatrixPresenter, "CtlMatrixPresenter");
            this.CtlMatrixPresenter.BackColor = System.Drawing.Color.White;
            this.CtlMatrixPresenter.Name = "CtlMatrixPresenter";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CtlNetPanel);
            this.Controls.Add(this.CtlPlotSplitter);
            this.Controls.Add(this.CtlManagerPanel);
            this.Controls.Add(this.CtlDataSplitter);
            this.Controls.Add(this.CtlInputDataPresenter);
            this.Controls.Add(this.CtlBottomPanel);
            this.DoubleBuffered = true;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.CtlBottomPanel.ResumeLayout(false);
            this.CtlNetPanel.ResumeLayout(false);
            this.CtlManagerPanel.ResumeLayout(false);
            this.CtlTabs.ResumeLayout(false);
            this.CtlNetworkContextMenu.ResumeLayout(false);
            this.CtlTabSettings.ResumeLayout(false);
            this.CtlSettingsPanel.ResumeLayout(false);
            this.CtlSettingsBottom.ResumeLayout(false);
            this.CtlManagerTools.ResumeLayout(false);
            this.CtlManagerTools.PerformLayout();
            this.CtlMenu.ResumeLayout(false);
            this.CtlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CtlStart;
        private System.Windows.Forms.Label CtlTime;
        private System.Windows.Forms.Panel CtlBottomPanel;
        private System.Windows.Forms.Splitter CtlDataSplitter;
        private System.Windows.Forms.Panel CtlNetPanel;
        private System.Windows.Forms.Splitter CtlPlotSplitter;
        private System.Windows.Forms.Panel CtlManagerPanel;
        private System.Windows.Forms.Panel CtlManagerTools;
        private System.Windows.Forms.TabControl CtlTabs;
        private System.Windows.Forms.TabPage CtlTabSettings;
        private System.Windows.Forms.MenuStrip CtlMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuFile;
        private System.Windows.Forms.ContextMenuStrip CtlNetworkContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuAddNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuDeleteNetwork;
        private System.Windows.Forms.Button CtlStop;
        private System.Windows.Forms.Button CtlReset;
        private System.Windows.Forms.Button CtlApplyChanges;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuNew;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuLoad;
        private System.Windows.Forms.ToolStripSeparator CtlMainMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuSaveAs;
        private System.Windows.Forms.Panel CtlSettingsBottom;
        private System.Windows.Forms.Button CtlCancelSettingsButton;
        private System.Windows.Forms.Button CtlApplySettingsButton;
        private System.Windows.Forms.Panel CtlSettingsPanel;
        private Controls.SettingsControl CtlSettings;
        private System.Windows.Forms.ToolStripMenuItem CtlMenuNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuAddNetwork;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuDeleteNetwork;
        private System.Windows.Forms.ToolStripSeparator CtlMainMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuAddLayer;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuDeleteLayer;
        private System.Windows.Forms.ToolStripSeparator CtlMainMenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CtlMainMenuAddNeuron;
        private Controls.DataPresenter CtlInputDataPresenter;
        private Controls.NetworkPresenter CtlNetworkPresenter;
        private Controls.PlotterPresenter CtlPlotPresenter;
        private Controls.StatisticsPresenter CtlStatisticsPresenter;
        private Controls.MatrixPresenter CtlMatrixPresenter;
    }
}

