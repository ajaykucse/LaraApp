namespace acmedesktop.DataTransaction.BillingTransaction
{
    partial class FrmMerge
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
			this.PnlTableType = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblMergInfo = new System.Windows.Forms.Label();
			this.PnlTableList = new System.Windows.Forms.Panel();
			this.TableFocusIndicate = new System.Windows.Forms.Label();
			this.PnlTableType.SuspendLayout();
			this.panel1.SuspendLayout();
			this.PnlTableList.SuspendLayout();
			this.SuspendLayout();
			// 
			// PnlTableType
			// 
			this.PnlTableType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlTableType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PnlTableType.Controls.Add(this.btnOk);
			this.PnlTableType.Controls.Add(this.BtnCancel);
			this.PnlTableType.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlTableType.Location = new System.Drawing.Point(0, 320);
			this.PnlTableType.Name = "PnlTableType";
			this.PnlTableType.Size = new System.Drawing.Size(374, 40);
			this.PnlTableType.TabIndex = 2;
			// 
			// btnOk
			// 
			this.btnOk.Enabled = false;
			this.btnOk.Font = new System.Drawing.Font("Arial", 9.5F);
			this.btnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.Location = new System.Drawing.Point(162, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(112, 34);
			this.btnOk.TabIndex = 200;
			this.btnOk.Text = "       C&ONFORM";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.CausesValidation = false;
			this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
			this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCancel.Location = new System.Drawing.Point(273, 3);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(89, 34);
			this.BtnCancel.TabIndex = 199;
			this.BtnCancel.Text = "     &CANCEL";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblMergInfo);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(374, 46);
			this.panel1.TabIndex = 202;
			// 
			// lblMergInfo
			// 
			this.lblMergInfo.AutoSize = true;
			this.lblMergInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMergInfo.Location = new System.Drawing.Point(6, 13);
			this.lblMergInfo.Name = "lblMergInfo";
			this.lblMergInfo.Size = new System.Drawing.Size(0, 15);
			this.lblMergInfo.TabIndex = 0;
			// 
			// PnlTableList
			// 
			this.PnlTableList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlTableList.Controls.Add(this.TableFocusIndicate);
			this.PnlTableList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PnlTableList.Location = new System.Drawing.Point(0, 46);
			this.PnlTableList.Name = "PnlTableList";
			this.PnlTableList.Size = new System.Drawing.Size(374, 274);
			this.PnlTableList.TabIndex = 203;
			// 
			// TableFocusIndicate
			// 
			this.TableFocusIndicate.BackColor = System.Drawing.Color.Yellow;
			this.TableFocusIndicate.ForeColor = System.Drawing.Color.White;
			this.TableFocusIndicate.Location = new System.Drawing.Point(133, 131);
			this.TableFocusIndicate.Name = "TableFocusIndicate";
			this.TableFocusIndicate.Size = new System.Drawing.Size(65, 5);
			this.TableFocusIndicate.TabIndex = 183;
			this.TableFocusIndicate.Visible = false;
			// 
			// FrmMerge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(374, 360);
			this.Controls.Add(this.PnlTableList);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.PnlTableType);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmMerge";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Merge";
			this.Load += new System.EventHandler(this.FrmMerge_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMerge_KeyDown);
			this.PnlTableType.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.PnlTableList.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTableType;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMergInfo;
        private System.Windows.Forms.Panel PnlTableList;
        private System.Windows.Forms.Label TableFocusIndicate;
    }
}