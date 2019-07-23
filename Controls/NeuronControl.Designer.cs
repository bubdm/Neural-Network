namespace Dots.Controls
{
    partial class NeuronControl
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
            this.CtlUpperBorder = new System.Windows.Forms.Panel();
            this.CtlDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CtlUpperBorder
            // 
            this.CtlUpperBorder.BackColor = System.Drawing.Color.Silver;
            this.CtlUpperBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlUpperBorder.Location = new System.Drawing.Point(0, 0);
            this.CtlUpperBorder.Name = "CtlUpperBorder";
            this.CtlUpperBorder.Size = new System.Drawing.Size(271, 1);
            this.CtlUpperBorder.TabIndex = 0;
            // 
            // CtlDelete
            // 
            this.CtlDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CtlDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtlDelete.Location = new System.Drawing.Point(248, 3);
            this.CtlDelete.Name = "CtlDelete";
            this.CtlDelete.Size = new System.Drawing.Size(20, 20);
            this.CtlDelete.TabIndex = 1;
            this.CtlDelete.Text = "X";
            this.CtlDelete.UseVisualStyleBackColor = true;
            this.CtlDelete.Click += new System.EventHandler(this.CtlDelete_Click);
            // 
            // NeuronControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CtlDelete);
            this.Controls.Add(this.CtlUpperBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NeuronControl";
            this.Size = new System.Drawing.Size(271, 124);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtlUpperBorder;
        private System.Windows.Forms.Button CtlDelete;
    }
}
