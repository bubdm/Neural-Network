﻿namespace NN
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
            this.CtlStart = new System.Windows.Forms.Button();
            this.CtlPointsCount = new System.Windows.Forms.NumericUpDown();
            this.CtlLog = new System.Windows.Forms.TextBox();
            this.CtlTime = new System.Windows.Forms.Label();
            this.CtlBottomPanel = new System.Windows.Forms.Panel();
            this.CtlDataPanel = new System.Windows.Forms.Panel();
            this.CtlDataSplitter = new System.Windows.Forms.Splitter();
            this.CtlNetPanel = new System.Windows.Forms.Panel();
            this.CtlPlotSplitter = new System.Windows.Forms.Splitter();
            this.CtlManagerPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CtlTabLog = new System.Windows.Forms.TabPage();
            this.CtlManagerTools = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CtlPointsCount)).BeginInit();
            this.CtlBottomPanel.SuspendLayout();
            this.CtlManagerPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.CtlTabLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlStart
            // 
            this.CtlStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CtlStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlStart.Location = new System.Drawing.Point(12, 13);
            this.CtlStart.Name = "CtlStart";
            this.CtlStart.Size = new System.Drawing.Size(97, 32);
            this.CtlStart.TabIndex = 1;
            this.CtlStart.Text = "Start";
            this.CtlStart.UseVisualStyleBackColor = true;
            this.CtlStart.Click += new System.EventHandler(this.btnRecalc_Click);
            // 
            // CtlPointsCount
            // 
            this.CtlPointsCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlPointsCount.Location = new System.Drawing.Point(147, 19);
            this.CtlPointsCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CtlPointsCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlPointsCount.Name = "CtlPointsCount";
            this.CtlPointsCount.Size = new System.Drawing.Size(120, 22);
            this.CtlPointsCount.TabIndex = 8;
            this.CtlPointsCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // CtlLog
            // 
            this.CtlLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CtlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlLog.Location = new System.Drawing.Point(3, 3);
            this.CtlLog.Multiline = true;
            this.CtlLog.Name = "CtlLog";
            this.CtlLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CtlLog.Size = new System.Drawing.Size(255, 355);
            this.CtlLog.TabIndex = 10;
            // 
            // CtlTime
            // 
            this.CtlTime.AutoSize = true;
            this.CtlTime.Location = new System.Drawing.Point(289, 24);
            this.CtlTime.Name = "CtlTime";
            this.CtlTime.Size = new System.Drawing.Size(59, 17);
            this.CtlTime.TabIndex = 11;
            this.CtlTime.Text = "Time: ...";
            // 
            // CtlBottomPanel
            // 
            this.CtlBottomPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CtlBottomPanel.Controls.Add(this.CtlTime);
            this.CtlBottomPanel.Controls.Add(this.CtlStart);
            this.CtlBottomPanel.Controls.Add(this.CtlPointsCount);
            this.CtlBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CtlBottomPanel.Location = new System.Drawing.Point(0, 443);
            this.CtlBottomPanel.Name = "CtlBottomPanel";
            this.CtlBottomPanel.Size = new System.Drawing.Size(1226, 57);
            this.CtlBottomPanel.TabIndex = 14;
            // 
            // CtlDataPanel
            // 
            this.CtlDataPanel.AutoScroll = true;
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
            this.CtlManagerPanel.Controls.Add(this.tabControl1);
            this.CtlManagerPanel.Controls.Add(this.CtlManagerTools);
            this.CtlManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlManagerPanel.Location = new System.Drawing.Point(957, 0);
            this.CtlManagerPanel.Name = "CtlManagerPanel";
            this.CtlManagerPanel.Size = new System.Drawing.Size(269, 443);
            this.CtlManagerPanel.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CtlTabLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(269, 390);
            this.tabControl1.TabIndex = 1;
            // 
            // CtlTabLog
            // 
            this.CtlTabLog.Controls.Add(this.CtlLog);
            this.CtlTabLog.Location = new System.Drawing.Point(4, 25);
            this.CtlTabLog.Name = "CtlTabLog";
            this.CtlTabLog.Padding = new System.Windows.Forms.Padding(3);
            this.CtlTabLog.Size = new System.Drawing.Size(261, 361);
            this.CtlTabLog.TabIndex = 0;
            this.CtlTabLog.Text = "Log";
            this.CtlTabLog.UseVisualStyleBackColor = true;
            // 
            // CtlManagerTools
            // 
            this.CtlManagerTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlManagerTools.Location = new System.Drawing.Point(0, 0);
            this.CtlManagerTools.Name = "CtlManagerTools";
            this.CtlManagerTools.Size = new System.Drawing.Size(269, 53);
            this.CtlManagerTools.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.CtlPointsCount)).EndInit();
            this.CtlBottomPanel.ResumeLayout(false);
            this.CtlBottomPanel.PerformLayout();
            this.CtlManagerPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.CtlTabLog.ResumeLayout(false);
            this.CtlTabLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CtlStart;
        private System.Windows.Forms.NumericUpDown CtlPointsCount;
        private System.Windows.Forms.TextBox CtlLog;
        private System.Windows.Forms.Label CtlTime;
        private System.Windows.Forms.Panel CtlBottomPanel;
        private System.Windows.Forms.Panel CtlDataPanel;
        private System.Windows.Forms.Splitter CtlDataSplitter;
        private System.Windows.Forms.Panel CtlNetPanel;
        private System.Windows.Forms.Splitter CtlPlotSplitter;
        private System.Windows.Forms.Panel CtlManagerPanel;
        private System.Windows.Forms.Panel CtlManagerTools;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CtlTabLog;
    }
}

