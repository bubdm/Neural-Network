namespace Dots.Controls
{
    partial class InputLayerControl
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
            this.CtlInputCountLabel = new System.Windows.Forms.Label();
            this.CtlInputCount = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlInputCountLabel
            // 
            this.CtlInputCountLabel.AutoSize = true;
            this.CtlInputCountLabel.Location = new System.Drawing.Point(3, 0);
            this.CtlInputCountLabel.Name = "CtlInputCountLabel";
            this.CtlInputCountLabel.Size = new System.Drawing.Size(82, 17);
            this.CtlInputCountLabel.TabIndex = 0;
            this.CtlInputCountLabel.Text = "Input count:";
            // 
            // CtlInputCount
            // 
            this.CtlInputCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CtlInputCount.Location = new System.Drawing.Point(91, 0);
            this.CtlInputCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CtlInputCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtlInputCount.Name = "CtlInputCount";
            this.CtlInputCount.Size = new System.Drawing.Size(105, 22);
            this.CtlInputCount.TabIndex = 1;
            this.CtlInputCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CtlInputCountLabel);
            this.panel1.Controls.Add(this.CtlInputCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 160);
            this.panel1.TabIndex = 2;
            // 
            // InputLayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InputLayerControl";
            this.Size = new System.Drawing.Size(353, 160);
            ((System.ComponentModel.ISupportInitialize)(this.CtlInputCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CtlInputCountLabel;
        private System.Windows.Forms.NumericUpDown CtlInputCount;
        private System.Windows.Forms.Panel panel1;
    }
}
