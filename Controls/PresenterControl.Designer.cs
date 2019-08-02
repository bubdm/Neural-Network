namespace NN.Controls
{
    partial class PresenterControl
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
            this.CtlBox = new System.Windows.Forms.PictureBox();
            this.CtlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtlBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CtlPanel
            // 
            this.CtlPanel.BackColor = System.Drawing.Color.White;
            this.CtlPanel.Controls.Add(this.CtlBox);
            this.CtlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlPanel.Name = "CtlPanel";
            this.CtlPanel.Size = new System.Drawing.Size(150, 150);
            this.CtlPanel.TabIndex = 0;
            // 
            // CtlBox
            // 
            this.CtlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlBox.Location = new System.Drawing.Point(0, 0);
            this.CtlBox.Name = "CtlBox";
            this.CtlBox.Size = new System.Drawing.Size(150, 150);
            this.CtlBox.TabIndex = 0;
            this.CtlBox.TabStop = false;
            // 
            // PresenterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CtlPanel);
            this.Name = "PresenterControl";
            this.CtlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CtlBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlPanel;
        public System.Windows.Forms.PictureBox CtlBox;
    }
}
