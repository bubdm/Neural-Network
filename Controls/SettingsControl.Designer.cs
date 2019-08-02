namespace NN.Controls
{
    partial class SettingsControl
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
            this.CtlPanel = new System.Windows.Forms.Panel();
            this.CtlSkipRoundsToDrawNetworks = new NN.Controls.IntBox();
            this.CtlSkipRoundsToDrawSelectedNetworkLabel = new System.Windows.Forms.Label();
            this.CtlSkipRoundsToDrawErrorMatrix = new NN.Controls.IntBox();
            this.CtlSkipRoundsForActionLabel = new System.Windows.Forms.Label();
            this.CtlSkipRoundsToDrawMatrixLabel = new System.Windows.Forms.Label();
            this.CtlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlPanel
            // 
            this.CtlPanel.BackColor = System.Drawing.Color.White;
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsToDrawNetworks);
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsToDrawSelectedNetworkLabel);
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsToDrawErrorMatrix);
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsForActionLabel);
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsToDrawMatrixLabel);
            this.CtlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlPanel.Name = "CtlPanel";
            this.CtlPanel.Size = new System.Drawing.Size(334, 505);
            this.CtlPanel.TabIndex = 0;
            // 
            // CtlSkipRoundsToDrawNetworks
            // 
            this.CtlSkipRoundsToDrawNetworks.BackColor = System.Drawing.Color.White;
            this.CtlSkipRoundsToDrawNetworks.ConfigParameter = Tools.Const.Param.SettingsSkipRoundsToDrawNetworks;
            this.CtlSkipRoundsToDrawNetworks.DefaultValue = 10000;
            this.CtlSkipRoundsToDrawNetworks.IsNullAllowed = false;
            this.CtlSkipRoundsToDrawNetworks.Location = new System.Drawing.Point(139, 76);
            this.CtlSkipRoundsToDrawNetworks.MaximumValue = 100000;
            this.CtlSkipRoundsToDrawNetworks.MinimumValue = 1;
            this.CtlSkipRoundsToDrawNetworks.Name = "CtlSkipRoundsToDrawNetworks";
            this.CtlSkipRoundsToDrawNetworks.Size = new System.Drawing.Size(100, 22);
            this.CtlSkipRoundsToDrawNetworks.TabIndex = 8;
            // 
            // CtlSkipRoundsToDrawSelectedNetworkLabel
            // 
            this.CtlSkipRoundsToDrawSelectedNetworkLabel.AutoSize = true;
            this.CtlSkipRoundsToDrawSelectedNetworkLabel.Location = new System.Drawing.Point(12, 76);
            this.CtlSkipRoundsToDrawSelectedNetworkLabel.Name = "CtlSkipRoundsToDrawSelectedNetworkLabel";
            this.CtlSkipRoundsToDrawSelectedNetworkLabel.Size = new System.Drawing.Size(120, 17);
            this.CtlSkipRoundsToDrawSelectedNetworkLabel.TabIndex = 7;
            this.CtlSkipRoundsToDrawSelectedNetworkLabel.Text = "Draw error matrix:";
            // 
            // CtlSkipRoundsToDrawErrorMatrix
            // 
            this.CtlSkipRoundsToDrawErrorMatrix.BackColor = System.Drawing.Color.White;
            this.CtlSkipRoundsToDrawErrorMatrix.ConfigParameter = Tools.Const.Param.SettingsSkipRoundsToDrawErrorMatrix;
            this.CtlSkipRoundsToDrawErrorMatrix.DefaultValue = 1000;
            this.CtlSkipRoundsToDrawErrorMatrix.IsNullAllowed = false;
            this.CtlSkipRoundsToDrawErrorMatrix.Location = new System.Drawing.Point(138, 37);
            this.CtlSkipRoundsToDrawErrorMatrix.MaximumValue = 100000;
            this.CtlSkipRoundsToDrawErrorMatrix.MinimumValue = 1;
            this.CtlSkipRoundsToDrawErrorMatrix.Name = "CtlSkipRoundsToDrawErrorMatrix";
            this.CtlSkipRoundsToDrawErrorMatrix.Size = new System.Drawing.Size(100, 22);
            this.CtlSkipRoundsToDrawErrorMatrix.TabIndex = 6;
            // 
            // CtlSkipRoundsForActionLabel
            // 
            this.CtlSkipRoundsForActionLabel.AutoSize = true;
            this.CtlSkipRoundsForActionLabel.Location = new System.Drawing.Point(12, 11);
            this.CtlSkipRoundsForActionLabel.Name = "CtlSkipRoundsForActionLabel";
            this.CtlSkipRoundsForActionLabel.Size = new System.Drawing.Size(128, 17);
            this.CtlSkipRoundsForActionLabel.TabIndex = 3;
            this.CtlSkipRoundsForActionLabel.Text = "Rounds per action:";
            // 
            // CtlSkipRoundsToDrawMatrixLabel
            // 
            this.CtlSkipRoundsToDrawMatrixLabel.AutoSize = true;
            this.CtlSkipRoundsToDrawMatrixLabel.Location = new System.Drawing.Point(12, 40);
            this.CtlSkipRoundsToDrawMatrixLabel.Name = "CtlSkipRoundsToDrawMatrixLabel";
            this.CtlSkipRoundsToDrawMatrixLabel.Size = new System.Drawing.Size(120, 17);
            this.CtlSkipRoundsToDrawMatrixLabel.TabIndex = 4;
            this.CtlSkipRoundsToDrawMatrixLabel.Text = "Draw error matrix:";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CtlPanel);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(334, 505);
            this.CtlPanel.ResumeLayout(false);
            this.CtlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlPanel;
        private System.Windows.Forms.Label CtlSkipRoundsForActionLabel;
        private System.Windows.Forms.Label CtlSkipRoundsToDrawMatrixLabel;
        private IntBox CtlSkipRoundsToDrawErrorMatrix;
        private System.Windows.Forms.Label CtlSkipRoundsToDrawSelectedNetworkLabel;
        private IntBox CtlSkipRoundsToDrawNetworks;
    }
}
