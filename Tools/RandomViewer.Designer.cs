namespace Tools
{
    partial class RandomViewer
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
            this.CtlPresenter = new NN.Controls.PresenterControl();
            ((System.ComponentModel.ISupportInitialize)(this.CtlPresenter)).BeginInit();
            this.SuspendLayout();
            // 
            // CtlPresenter
            // 
            this.CtlPresenter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CtlPresenter.BackColor = System.Drawing.Color.White;
            this.CtlPresenter.Location = new System.Drawing.Point(26, 0);
            this.CtlPresenter.Name = "CtlPresenter";
            this.CtlPresenter.Size = new System.Drawing.Size(800, 450);
            this.CtlPresenter.TabIndex = 0;
            this.CtlPresenter.TabStop = false;
            // 
            // RandomViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.CtlPresenter);
            this.DoubleBuffered = true;
            this.Name = "RandomViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randomizer Viewer";
            this.Shown += new System.EventHandler(this.RandomViewer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.CtlPresenter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NN.Controls.PresenterControl CtlPresenter;
    }
}