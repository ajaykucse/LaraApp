namespace acmedesktop.DataTransaction
{
    partial class FrmAdditionalDesc
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
            this.TxtAdditionalDesc = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtAdditionalDesc
            // 
            this.TxtAdditionalDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAdditionalDesc.Location = new System.Drawing.Point(13, 13);
            this.TxtAdditionalDesc.Multiline = true;
            this.TxtAdditionalDesc.Name = "TxtAdditionalDesc";
            this.TxtAdditionalDesc.Size = new System.Drawing.Size(333, 83);
            this.TxtAdditionalDesc.TabIndex = 0;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(241, 102);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(44, 26);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "&Ok";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(289, 102);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(56, 26);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmAdditionalDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(358, 132);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtAdditionalDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdditionalDesc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Additional Desc";
            this.Load += new System.EventHandler(this.FrmAdditionalDesc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAdditionalDesc_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyInputControls.MyTextBox TxtAdditionalDesc;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}