namespace acmedesktop.DataTransaction.BillingTransaction
{
	partial class FrmDialogBox
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
			this.LblDialog = new System.Windows.Forms.Label();
			this.TxtDialog = new acmedesktop.MyInputControls.MyTextBox();
			this.PanelFooter.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
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
			this.PanelFooter.Location = new System.Drawing.Point(0, 82);
			this.PanelFooter.Name = "PanelFooter";
			this.PanelFooter.Size = new System.Drawing.Size(280, 43);
			this.PanelFooter.TabIndex = 4;
			// 
			// BtnOk
			// 
			this.BtnOk.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
			this.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnOk.Location = new System.Drawing.Point(98, 6);
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
			this.BtnCancel.Location = new System.Drawing.Point(173, 6);
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
			this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 42);
			this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
			this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(280, 1);
			this.PnlBorderFooterBoootm.TabIndex = 3;
			// 
			// PnlBorderFooterTop
			// 
			this.PnlBorderFooterTop.BackColor = System.Drawing.Color.White;
			this.PnlBorderFooterTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlBorderFooterTop.Location = new System.Drawing.Point(0, 0);
			this.PnlBorderFooterTop.Name = "PnlBorderFooterTop";
			this.PnlBorderFooterTop.Size = new System.Drawing.Size(280, 1);
			this.PnlBorderFooterTop.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 82);
			this.panel1.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.panel2.Controls.Add(this.TxtDialog);
			this.panel2.Controls.Add(this.LblDialog);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(280, 82);
			this.panel2.TabIndex = 0;
			// 
			// LblDialog
			// 
			this.LblDialog.AutoSize = true;
			this.LblDialog.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblDialog.Location = new System.Drawing.Point(30, 27);
			this.LblDialog.Name = "LblDialog";
			this.LblDialog.Size = new System.Drawing.Size(47, 16);
			this.LblDialog.TabIndex = 1;
			this.LblDialog.Text = "label1";
			// 
			// TxtDialog
			// 
			this.TxtDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtDialog.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtDialog.Location = new System.Drawing.Point(97, 18);
			this.TxtDialog.Name = "TxtDialog";
			this.TxtDialog.Size = new System.Drawing.Size(166, 35);
			this.TxtDialog.TabIndex = 0;
			this.TxtDialog.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDialog_Validating);
			// 
			// FrmDialogBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 125);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.PanelFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmDialogBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dialog Box";
			this.Load += new System.EventHandler(this.FrmDialogBox_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDialogBox_KeyDown);
			this.PanelFooter.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
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
		public System.Windows.Forms.Label LblDialog;
		public MyInputControls.MyTextBox TxtDialog;
	}
}