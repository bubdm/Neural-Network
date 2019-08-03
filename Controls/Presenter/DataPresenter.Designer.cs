namespace NN.Controls
{
    partial class DataPresenter
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
            this.CtlHead = new System.Windows.Forms.Panel();
            this.CtlInputCount = new System.Windows.Forms.NumericUpDown();
            this.CtlInputCountLabel = new System.Windows.Forms.Label();
            this.CtlPresenter = new NN.Controls.PresenterControl();
            this.CtlTaskLabel = new System.Windows.Forms.Label();
            this.CtlTask = new System.Windows.Forms.ComboBox();
            this.CtlPanel.SuspendLayout();
            this.CtlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).BeginInit();
            this.SuspendLayout();
            // 
            // CtlPanel
            // 
            this.CtlPanel.BackColor = System.Drawing.Color.White;
            this.CtlPanel.Controls.Add(this.CtlPresenter);
            this.CtlPanel.Controls.Add(this.CtlHead);
            this.CtlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlPanel.Location = new System.Drawing.Point(0, 0);
            this.CtlPanel.Name = "CtlPanel";
            this.CtlPanel.Size = new System.Drawing.Size(197, 150);
            this.CtlPanel.TabIndex = 0;
            // 
            // CtlHead
            // 
            this.CtlHead.Controls.Add(this.CtlTask);
            this.CtlHead.Controls.Add(this.CtlTaskLabel);
            this.CtlHead.Controls.Add(this.CtlInputCount);
            this.CtlHead.Controls.Add(this.CtlInputCountLabel);
            this.CtlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlHead.Location = new System.Drawing.Point(0, 0);
            this.CtlHead.Name = "CtlHead";
            this.CtlHead.Size = new System.Drawing.Size(197, 85);
            this.CtlHead.TabIndex = 2;
            // 
            // CtlInputCount
            // 
            this.CtlInputCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlInputCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlInputCount.Location = new System.Drawing.Point(90, 55);
            this.CtlInputCount.Name = "CtlInputCount";
            this.CtlInputCount.Size = new System.Drawing.Size(104, 22);
            this.CtlInputCount.TabIndex = 0;
            // 
            // CtlInputCountLabel
            // 
            this.CtlInputCountLabel.AutoSize = true;
            this.CtlInputCountLabel.Location = new System.Drawing.Point(3, 57);
            this.CtlInputCountLabel.Name = "CtlInputCountLabel";
            this.CtlInputCountLabel.Size = new System.Drawing.Size(82, 17);
            this.CtlInputCountLabel.TabIndex = 1;
            this.CtlInputCountLabel.Text = "Input count:";
            // 
            // CtlPresenter
            // 
            this.CtlPresenter.BackColor = System.Drawing.Color.White;
            this.CtlPresenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlPresenter.Location = new System.Drawing.Point(0, 85);
            this.CtlPresenter.Name = "CtlPresenter";
            this.CtlPresenter.Size = new System.Drawing.Size(197, 49);
            this.CtlPresenter.TabIndex = 1;
            // 
            // CtlTaskLabel
            // 
            this.CtlTaskLabel.AutoSize = true;
            this.CtlTaskLabel.Location = new System.Drawing.Point(3, 5);
            this.CtlTaskLabel.Name = "CtlTaskLabel";
            this.CtlTaskLabel.Size = new System.Drawing.Size(43, 17);
            this.CtlTaskLabel.TabIndex = 2;
            this.CtlTaskLabel.Text = "Task:";
            // 
            // CtlTask
            // 
            this.CtlTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtlTask.FormattingEnabled = true;
            this.CtlTask.Location = new System.Drawing.Point(6, 25);
            this.CtlTask.Name = "CtlTask";
            this.CtlTask.Size = new System.Drawing.Size(188, 24);
            this.CtlTask.TabIndex = 3;
            this.CtlTask.TabStop = false;
            // 
            // DataPresenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CtlPanel);
            this.Name = "DataPresenter";
            this.Size = new System.Drawing.Size(197, 150);
            this.CtlPanel.ResumeLayout(false);
            this.CtlHead.ResumeLayout(false);
            this.CtlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlPanel;
        private System.Windows.Forms.NumericUpDown CtlInputCount;
        private PresenterControl CtlPresenter;
        private System.Windows.Forms.Panel CtlHead;
        private System.Windows.Forms.Label CtlInputCountLabel;
        private System.Windows.Forms.Label CtlTaskLabel;
        private System.Windows.Forms.ComboBox CtlTask;
    }
}
