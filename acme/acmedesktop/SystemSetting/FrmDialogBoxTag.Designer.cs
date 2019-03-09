namespace acmedesktop.SystemSetting
{
	partial class FrmDialogBoxTag
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
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
            this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlTagableContent = new System.Windows.Forms.Panel();
            this.PnlSub = new System.Windows.Forms.Panel();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PanelFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PnlTagableContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelFooter.CausesValidation = false;
            this.PanelFooter.Controls.Add(this.BtnOk);
            this.PanelFooter.Controls.Add(this.BtnCancel);
            this.PanelFooter.Controls.Add(this.PnlBorderFooterBoootm);
            this.PanelFooter.Controls.Add(this.PnlBorderFooterTop);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 202);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(456, 45);
            this.PanelFooter.TabIndex = 4;
            // 
            // BtnOk
            // 
            this.BtnOk.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOk.Location = new System.Drawing.Point(290, 8);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(74, 31);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "     &OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.CausesValidation = false;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(365, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(88, 31);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "     &CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PnlBorderFooterBoootm
            // 
            this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 44);
            this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
            this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(456, 1);
            this.PnlBorderFooterBoootm.TabIndex = 3;
            // 
            // PnlBorderFooterTop
            // 
            this.PnlBorderFooterTop.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBorderFooterTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderFooterTop.Name = "PnlBorderFooterTop";
            this.PnlBorderFooterTop.Size = new System.Drawing.Size(456, 1);
            this.PnlBorderFooterTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 202);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.panel2.Controls.Add(this.PnlTagableContent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 202);
            this.panel2.TabIndex = 0;
            // 
            // PnlTagableContent
            // 
            this.PnlTagableContent.Controls.Add(this.PnlSub);
            this.PnlTagableContent.Controls.Add(this.PnlMain);
            this.PnlTagableContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTagableContent.Location = new System.Drawing.Point(0, 0);
            this.PnlTagableContent.Name = "PnlTagableContent";
            this.PnlTagableContent.Size = new System.Drawing.Size(456, 202);
            this.PnlTagableContent.TabIndex = 1;
            // 
            // PnlSub
            // 
            this.PnlSub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlSub.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlSub.Location = new System.Drawing.Point(255, 0);
            this.PnlSub.Name = "PnlSub";
            this.PnlSub.Size = new System.Drawing.Size(201, 202);
            this.PnlSub.TabIndex = 1;
            // 
            // PnlMain
            // 
            this.PnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(252, 202);
            this.PnlMain.TabIndex = 0;
            // 
            // FrmDialogBoxTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 247);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialogBoxTag";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog Tag";
            this.Load += new System.EventHandler(this.FrmDialogBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDialogBox_KeyDown);
            this.PanelFooter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.PnlTagableContent.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel PanelFooter;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Panel PnlBorderFooterBoootm;
		private System.Windows.Forms.Panel PnlBorderFooterTop;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel PnlTagableContent;
        private System.Windows.Forms.Panel PnlSub;
        private System.Windows.Forms.Panel PnlMain;
    }
}