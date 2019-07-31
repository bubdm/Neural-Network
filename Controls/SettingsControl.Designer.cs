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
            this.CtlSkipRoundsForActionLabel = new System.Windows.Forms.Label();
            this.CtlRoundsPerMatrixDrawLabel = new System.Windows.Forms.Label();
            this.CtlSkipRoundsToDrawErrorMatrix = new NN.Controls.IntBox();
            this.CtlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlPanel
            // 
            this.CtlPanel.BackColor = System.Drawing.Color.White;
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsToDrawErrorMatrix);
            this.CtlPanel.Controls.Add(this.CtlSkipRoundsForActionLabel);
            this.CtlPanel.Controls.Add(this.CtlRoundsPerMatrixDrawLabel);
            this.CtlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlPanel.Name = "CtlPanel";
            this.CtlPanel.Size = new System.Drawing.Size(334, 505);
            this.CtlPanel.TabIndex = 0;
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
            // CtlRoundsPerMatrixDrawLabel
            // 
            this.CtlRoundsPerMatrixDrawLabel.AutoSize = true;
            this.CtlRoundsPerMatrixDrawLabel.Location = new System.Drawing.Point(12, 40);
            this.CtlRoundsPerMatrixDrawLabel.Name = "CtlRoundsPerMatrixDrawLabel";
            this.CtlRoundsPerMatrixDrawLabel.Size = new System.Drawing.Size(120, 17);
            this.CtlRoundsPerMatrixDrawLabel.TabIndex = 4;
            this.CtlRoundsPerMatrixDrawLabel.Text = "Draw error matrix:";
            // 
            // CtlSkipRoundsToDrawErrorMatrix
            // 
            this.CtlSkipRoundsToDrawErrorMatrix.ConfigParameter = Tools.Const.Param.SettingsSkipRoundsToDrawErrorMatrix;
            this.CtlSkipRoundsToDrawErrorMatrix.DefaultValue = 1000;
            this.CtlSkipRoundsToDrawErrorMatrix.Location = new System.Drawing.Point(138, 37);
            this.CtlSkipRoundsToDrawErrorMatrix.MaximumValue = 100000;
            this.CtlSkipRoundsToDrawErrorMatrix.MinimumValue = 1;
            this.CtlSkipRoundsToDrawErrorMatrix.Name = "CtlSkipRoundsToDrawErrorMatrix";
            this.CtlSkipRoundsToDrawErrorMatrix.Size = new System.Drawing.Size(100, 22);
            this.CtlSkipRoundsToDrawErrorMatrix.TabIndex = 6;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Label CtlRoundsPerMatrixDrawLabel;
        private IntBox CtlSkipRoundsToDrawErrorMatrix;
    }
}
