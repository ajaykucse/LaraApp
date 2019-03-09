namespace acmedesktop.Opening
{
    partial class FrmLedgerOpening
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
            this.myTextBox1 = new acmedesktop.MyInputControls.MyTextBox();
            this.SuspendLayout();
            // 
            // myTextBox1
            // 
            this.myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox1.Location = new System.Drawing.Point(272, 171);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(100, 20);
            this.myTextBox1.TabIndex = 0;
            // 
            // FrmLedgerOpening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myTextBox1);
            this.Name = "FrmLedgerOpening";
            this.Text = "FrmLedgerOpening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyInputControls.MyTextBox myTextBox1;
    }
}