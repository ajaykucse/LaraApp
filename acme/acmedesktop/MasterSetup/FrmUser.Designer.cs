namespace acmedesktop.MasterSetup
{
    partial class FrmUser
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.TxtMobileNo = new acmedesktop.MyInputControls.MyNumericTextBox();
            this.TxtUserPassword = new acmedesktop.MyInputControls.MyTextBox();
            this.TxtEmailId = new acmedesktop.MyInputControls.MyTextBox();
            this.TxtUserCode = new acmedesktop.MyInputControls.MyTextBox();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
            this.PanelContainer.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label3.Location = new System.Drawing.Point(22, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mobile No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label7.Location = new System.Drawing.Point(22, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Password";
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelContainer.Controls.Add(this.TxtMobileNo);
            this.PanelContainer.Controls.Add(this.TxtUserPassword);
            this.PanelContainer.Controls.Add(this.label7);
            this.PanelContainer.Controls.Add(this.TxtEmailId);
            this.PanelContainer.Controls.Add(this.TxtUserCode);
            this.PanelContainer.Controls.Add(this.label2);
            this.PanelContainer.Controls.Add(this.label1);
            this.PanelContainer.Controls.Add(this.label3);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(374, 173);
            this.PanelContainer.TabIndex = 0;
            // 
            // TxtMobileNo
            // 
            this.TxtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMobileNo.Location = new System.Drawing.Point(103, 39);
            this.TxtMobileNo.MaxLength = 10;
            this.TxtMobileNo.Name = "TxtMobileNo";
            this.TxtMobileNo.Size = new System.Drawing.Size(260, 22);
            this.TxtMobileNo.TabIndex = 6;
            this.TxtMobileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMobileNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMobileNo_Validating);
            // 
            // TxtUserPassword
            // 
            this.TxtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserPassword.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtUserPassword.Location = new System.Drawing.Point(103, 98);
            this.TxtUserPassword.MaxLength = 50;
            this.TxtUserPassword.Name = "TxtUserPassword";
            this.TxtUserPassword.PasswordChar = '*';
            this.TxtUserPassword.Size = new System.Drawing.Size(260, 22);
            this.TxtUserPassword.TabIndex = 14;
            this.TxtUserPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserPassword_Validating);
            // 
            // TxtEmailId
            // 
            this.TxtEmailId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmailId.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtEmailId.Location = new System.Drawing.Point(103, 70);
            this.TxtEmailId.MaxLength = 50;
            this.TxtEmailId.Name = "TxtEmailId";
            this.TxtEmailId.Size = new System.Drawing.Size(260, 22);
            this.TxtEmailId.TabIndex = 8;
            this.TxtEmailId.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmailId_Validating);
            // 
            // TxtUserCode
            // 
            this.TxtUserCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserCode.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtUserCode.Location = new System.Drawing.Point(103, 8);
            this.TxtUserCode.MaxLength = 200;
            this.TxtUserCode.Name = "TxtUserCode";
            this.TxtUserCode.Size = new System.Drawing.Size(260, 22);
            this.TxtUserCode.TabIndex = 1;
            this.TxtUserCode.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserCode_Validating);
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelFooter.CausesValidation = false;
            this.PanelFooter.Controls.Add(this.PnlBorderFooterBoootm);
            this.PanelFooter.Controls.Add(this.BtnSave);
            this.PanelFooter.Controls.Add(this.PnlBorderFooterTop);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 135);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(374, 38);
            this.PanelFooter.TabIndex = 3;
            // 
            // PnlBorderFooterBoootm
            // 
            this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 37);
            this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
            this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(374, 1);
            this.PnlBorderFooterBoootm.TabIndex = 3;
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnSave.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(303, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(64, 31);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "     &OK";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // PnlBorderFooterTop
            // 
            this.PnlBorderFooterTop.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBorderFooterTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderFooterTop.Name = "PnlBorderFooterTop";
            this.PnlBorderFooterTop.Size = new System.Drawing.Size(374, 1);
            this.PnlBorderFooterTop.TabIndex = 0;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 173);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelContainer);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUser_KeyDown);
            this.PanelContainer.ResumeLayout(false);
            this.PanelContainer.PerformLayout();
            this.PanelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyInputControls.MyTextBox TxtEmailId;
        private System.Windows.Forms.Label label7;
        private MyInputControls.MyTextBox TxtUserPassword;
        private MyInputControls.MyNumericTextBox TxtMobileNo;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Panel PnlBorderFooterBoootm;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Panel PnlBorderFooterTop;
        private MyInputControls.MyTextBox TxtUserCode;
    }
}