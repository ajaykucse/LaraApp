namespace acmedesktop.SystemSetting
{
    partial class FrmUserMaster
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
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.TxtMobileNo = new acmedesktop.MyInputControls.MyNumericTextBox();
            this.TxtLedger = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchLedger = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtEndDate = new acmedesktop.MyInputControls.MyMaskedTextBox();
            this.TxtStartDate = new acmedesktop.MyInputControls.MyMaskedTextBox();
            this.TxtConUserPassword = new acmedesktop.MyInputControls.MyTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtUserPassword = new acmedesktop.MyInputControls.MyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtEmailId = new acmedesktop.MyInputControls.MyTextBox();
            this.TxtUserCode = new acmedesktop.MyInputControls.MyTextBox();
            this.TxtUserName = new acmedesktop.MyInputControls.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSearchUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PnlBorderHeaderTop = new System.Windows.Forms.Panel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnLastData = new System.Windows.Forms.Button();
            this.BtnPreviousData = new System.Windows.Forms.Button();
            this.BtnNextData = new System.Windows.Forms.Button();
            this.BtnFirstData = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.PnlBorderHeaderBottom = new System.Windows.Forms.Panel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbUserType = new System.Windows.Forms.ComboBox();
            this.PanelContainer.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelContainer.Controls.Add(this.CmbUserType);
            this.PanelContainer.Controls.Add(this.label10);
            this.PanelContainer.Controls.Add(this.TxtMobileNo);
            this.PanelContainer.Controls.Add(this.TxtLedger);
            this.PanelContainer.Controls.Add(this.BtnSearchLedger);
            this.PanelContainer.Controls.Add(this.label9);
            this.PanelContainer.Controls.Add(this.TxtEndDate);
            this.PanelContainer.Controls.Add(this.TxtStartDate);
            this.PanelContainer.Controls.Add(this.TxtConUserPassword);
            this.PanelContainer.Controls.Add(this.label8);
            this.PanelContainer.Controls.Add(this.TxtUserPassword);
            this.PanelContainer.Controls.Add(this.label7);
            this.PanelContainer.Controls.Add(this.label6);
            this.PanelContainer.Controls.Add(this.label4);
            this.PanelContainer.Controls.Add(this.TxtEmailId);
            this.PanelContainer.Controls.Add(this.TxtUserCode);
            this.PanelContainer.Controls.Add(this.TxtUserName);
            this.PanelContainer.Controls.Add(this.label5);
            this.PanelContainer.Controls.Add(this.BtnSearchUser);
            this.PanelContainer.Controls.Add(this.label2);
            this.PanelContainer.Controls.Add(this.label1);
            this.PanelContainer.Controls.Add(this.label3);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelContainer.Location = new System.Drawing.Point(0, 36);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(465, 297);
            this.PanelContainer.TabIndex = 1;
            // 
            // TxtMobileNo
            // 
            this.TxtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMobileNo.Location = new System.Drawing.Point(153, 62);
            this.TxtMobileNo.MaxLength = 10;
            this.TxtMobileNo.Name = "TxtMobileNo";
            this.TxtMobileNo.Size = new System.Drawing.Size(260, 22);
            this.TxtMobileNo.TabIndex = 6;
            this.TxtMobileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMobileNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMobileNo_Validating);
            // 
            // TxtLedger
            // 
            this.TxtLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLedger.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtLedger.Location = new System.Drawing.Point(153, 232);
            this.TxtLedger.Name = "TxtLedger";
            this.TxtLedger.Size = new System.Drawing.Size(260, 22);
            this.TxtLedger.TabIndex = 18;
            this.TxtLedger.Tag = "0";
            this.TxtLedger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLedger_KeyDown);
            // 
            // BtnSearchLedger
            // 
            this.BtnSearchLedger.CausesValidation = false;
            this.BtnSearchLedger.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchLedger.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchLedger.Location = new System.Drawing.Point(413, 231);
            this.BtnSearchLedger.Name = "BtnSearchLedger";
            this.BtnSearchLedger.Size = new System.Drawing.Size(31, 25);
            this.BtnSearchLedger.TabIndex = 19;
            this.BtnSearchLedger.TabStop = false;
            this.BtnSearchLedger.UseVisualStyleBackColor = true;
            this.BtnSearchLedger.Click += new System.EventHandler(this.BtnSearchLedger_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label9.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label9.Location = new System.Drawing.Point(22, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Leger";
            // 
            // TxtEndDate
            // 
            this.TxtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEndDate.Font = new System.Drawing.Font("Arial Narrow", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEndDate.Location = new System.Drawing.Point(153, 148);
            this.TxtEndDate.Mask = "99/99/9999";
            this.TxtEndDate.Name = "TxtEndDate";
            this.TxtEndDate.Size = new System.Drawing.Size(100, 22);
            this.TxtEndDate.TabIndex = 12;
            // 
            // TxtStartDate
            // 
            this.TxtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtStartDate.Font = new System.Drawing.Font("Arial Narrow", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStartDate.Location = new System.Drawing.Point(153, 120);
            this.TxtStartDate.Mask = "99/99/9999";
            this.TxtStartDate.Name = "TxtStartDate";
            this.TxtStartDate.Size = new System.Drawing.Size(100, 22);
            this.TxtStartDate.TabIndex = 10;
            // 
            // TxtConUserPassword
            // 
            this.TxtConUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConUserPassword.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtConUserPassword.Location = new System.Drawing.Point(153, 204);
            this.TxtConUserPassword.Name = "TxtConUserPassword";
            this.TxtConUserPassword.PasswordChar = '*';
            this.TxtConUserPassword.Size = new System.Drawing.Size(260, 22);
            this.TxtConUserPassword.TabIndex = 16;
            this.TxtConUserPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtConUserPassword_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label8.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label8.Location = new System.Drawing.Point(22, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Confirm Password";
            // 
            // TxtUserPassword
            // 
            this.TxtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserPassword.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtUserPassword.Location = new System.Drawing.Point(153, 176);
            this.TxtUserPassword.Name = "TxtUserPassword";
            this.TxtUserPassword.PasswordChar = '*';
            this.TxtUserPassword.Size = new System.Drawing.Size(260, 22);
            this.TxtUserPassword.TabIndex = 14;
            this.TxtUserPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserPassword_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label7.Location = new System.Drawing.Point(22, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label6.Location = new System.Drawing.Point(22, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label4.Location = new System.Drawing.Point(22, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start Date";
            // 
            // TxtEmailId
            // 
            this.TxtEmailId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmailId.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtEmailId.Location = new System.Drawing.Point(153, 93);
            this.TxtEmailId.Name = "TxtEmailId";
            this.TxtEmailId.Size = new System.Drawing.Size(260, 22);
            this.TxtEmailId.TabIndex = 8;
            this.TxtEmailId.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmailId_Validating);
            // 
            // TxtUserCode
            // 
            this.TxtUserCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserCode.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtUserCode.Location = new System.Drawing.Point(153, 8);
            this.TxtUserCode.Name = "TxtUserCode";
            this.TxtUserCode.Size = new System.Drawing.Size(260, 22);
            this.TxtUserCode.TabIndex = 1;
            this.TxtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUserCode_KeyDown);
            this.TxtUserCode.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserCode_Validating);
            // 
            // TxtUserName
            // 
            this.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserName.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtUserName.Location = new System.Drawing.Point(153, 36);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(260, 22);
            this.TxtUserName.TabIndex = 4;
            this.TxtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserName_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label5.Location = new System.Drawing.Point(22, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Full Name";
            // 
            // BtnSearchUser
            // 
            this.BtnSearchUser.CausesValidation = false;
            this.BtnSearchUser.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchUser.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchUser.Location = new System.Drawing.Point(413, 7);
            this.BtnSearchUser.Name = "BtnSearchUser";
            this.BtnSearchUser.Size = new System.Drawing.Size(31, 25);
            this.BtnSearchUser.TabIndex = 2;
            this.BtnSearchUser.TabStop = false;
            this.BtnSearchUser.UseVisualStyleBackColor = true;
            this.BtnSearchUser.Click += new System.EventHandler(this.BtnSearchUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label2.Location = new System.Drawing.Point(22, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mobile No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label3.Location = new System.Drawing.Point(22, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email Id";
            // 
            // PnlBorderFooterBoootm
            // 
            this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 35);
            this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
            this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(465, 1);
            this.PnlBorderFooterBoootm.TabIndex = 3;
            // 
            // BtnCancel
            // 
            this.BtnCancel.CausesValidation = false;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(365, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "     &CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnSave.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(307, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(57, 31);
            this.BtnSave.TabIndex = 0;
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
            this.PnlBorderFooterTop.Size = new System.Drawing.Size(465, 1);
            this.PnlBorderFooterTop.TabIndex = 0;
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelFooter.CausesValidation = false;
            this.PanelFooter.Controls.Add(this.PnlBorderFooterBoootm);
            this.PanelFooter.Controls.Add(this.BtnCancel);
            this.PanelFooter.Controls.Add(this.BtnSave);
            this.PanelFooter.Controls.Add(this.PnlBorderFooterTop);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 333);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(465, 36);
            this.PanelFooter.TabIndex = 2;
            // 
            // PnlBorderHeaderTop
            // 
            this.PnlBorderHeaderTop.BackColor = System.Drawing.Color.White;
            this.PnlBorderHeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBorderHeaderTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderHeaderTop.Name = "PnlBorderHeaderTop";
            this.PnlBorderHeaderTop.Size = new System.Drawing.Size(465, 1);
            this.PnlBorderHeaderTop.TabIndex = 0;
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnExit.Image = global::acmedesktop.Properties.Resources.Exit_24;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(391, 4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(65, 28);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "     E&XIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnLastData
            // 
            this.BtnLastData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnLastData.Location = new System.Drawing.Point(347, 4);
            this.BtnLastData.Name = "BtnLastData";
            this.BtnLastData.Size = new System.Drawing.Size(35, 28);
            this.BtnLastData.TabIndex = 6;
            this.BtnLastData.Text = ">|";
            this.BtnLastData.UseVisualStyleBackColor = true;
            this.BtnLastData.Click += new System.EventHandler(this.BtnLastData_Click);
            // 
            // BtnPreviousData
            // 
            this.BtnPreviousData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnPreviousData.Location = new System.Drawing.Point(312, 4);
            this.BtnPreviousData.Name = "BtnPreviousData";
            this.BtnPreviousData.Size = new System.Drawing.Size(35, 28);
            this.BtnPreviousData.TabIndex = 5;
            this.BtnPreviousData.Text = "<<";
            this.BtnPreviousData.UseVisualStyleBackColor = true;
            this.BtnPreviousData.Click += new System.EventHandler(this.BtnPreviousData_Click);
            // 
            // BtnNextData
            // 
            this.BtnNextData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnNextData.Location = new System.Drawing.Point(277, 4);
            this.BtnNextData.Name = "BtnNextData";
            this.BtnNextData.Size = new System.Drawing.Size(35, 28);
            this.BtnNextData.TabIndex = 4;
            this.BtnNextData.Text = ">>";
            this.BtnNextData.UseVisualStyleBackColor = true;
            this.BtnNextData.Click += new System.EventHandler(this.BtnNextData_Click);
            // 
            // BtnFirstData
            // 
            this.BtnFirstData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnFirstData.Location = new System.Drawing.Point(242, 4);
            this.BtnFirstData.Name = "BtnFirstData";
            this.BtnFirstData.Size = new System.Drawing.Size(35, 28);
            this.BtnFirstData.TabIndex = 3;
            this.BtnFirstData.Text = "|<";
            this.BtnFirstData.UseVisualStyleBackColor = true;
            this.BtnFirstData.Click += new System.EventHandler(this.BtnFirstData_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnDelete.Image = global::acmedesktop.Properties.Resources.Delete_24;
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.Location = new System.Drawing.Point(137, 4);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(90, 28);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "     &DELETE";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnEdit.Image = global::acmedesktop.Properties.Resources.Edit_24;
            this.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEdit.Location = new System.Drawing.Point(70, 4);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(67, 28);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "     &EDIT";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnNew.Image = global::acmedesktop.Properties.Resources.New_24;
            this.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNew.Location = new System.Drawing.Point(3, 4);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(67, 28);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "     &NEW";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlBorderHeaderBottom
            // 
            this.PnlBorderHeaderBottom.BackColor = System.Drawing.Color.White;
            this.PnlBorderHeaderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderHeaderBottom.Location = new System.Drawing.Point(0, 35);
            this.PnlBorderHeaderBottom.Name = "PnlBorderHeaderBottom";
            this.PnlBorderHeaderBottom.Size = new System.Drawing.Size(465, 1);
            this.PnlBorderHeaderBottom.TabIndex = 0;
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelHeader.Controls.Add(this.PnlBorderHeaderTop);
            this.PanelHeader.Controls.Add(this.BtnExit);
            this.PanelHeader.Controls.Add(this.BtnLastData);
            this.PanelHeader.Controls.Add(this.BtnPreviousData);
            this.PanelHeader.Controls.Add(this.BtnNextData);
            this.PanelHeader.Controls.Add(this.BtnFirstData);
            this.PanelHeader.Controls.Add(this.BtnDelete);
            this.PanelHeader.Controls.Add(this.BtnEdit);
            this.PanelHeader.Controls.Add(this.BtnNew);
            this.PanelHeader.Controls.Add(this.PnlBorderHeaderBottom);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(465, 36);
            this.PanelHeader.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label10.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label10.Location = new System.Drawing.Point(22, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "User Type";
            // 
            // CmbUserType
            // 
            this.CmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUserType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUserType.FormattingEnabled = true;
            this.CmbUserType.Items.AddRange(new object[] {
            "Normal",
            "Waiter"});
            this.CmbUserType.Location = new System.Drawing.Point(153, 260);
            this.CmbUserType.Name = "CmbUserType";
            this.CmbUserType.Size = new System.Drawing.Size(112, 24);
            this.CmbUserType.TabIndex = 29;
            // 
            // FrmUserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 369);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelHeader);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserMaster";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Master";
            this.Load += new System.EventHandler(this.FrmUserMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUserMaster_KeyDown);
            this.PanelContainer.ResumeLayout(false);
            this.PanelContainer.PerformLayout();
            this.PanelFooter.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Panel PnlBorderFooterBoootm;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Panel PnlBorderFooterTop;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Panel PnlBorderHeaderTop;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnLastData;
        private System.Windows.Forms.Button BtnPreviousData;
        private System.Windows.Forms.Button BtnNextData;
        private System.Windows.Forms.Button BtnFirstData;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Panel PnlBorderHeaderBottom;
        private System.Windows.Forms.Panel PanelHeader;
        private MyInputControls.MyMaskedTextBox TxtEndDate;
        private MyInputControls.MyMaskedTextBox TxtStartDate;
        private MyInputControls.MyTextBox TxtConUserPassword;
        private System.Windows.Forms.Label label8;
        private MyInputControls.MyTextBox TxtUserPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private MyInputControls.MyTextBox TxtEmailId;
        private MyInputControls.MyTextBox TxtUserCode;
        private MyInputControls.MyTextBox TxtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSearchUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private MyInputControls.MyTextBox TxtLedger;
        private System.Windows.Forms.Button BtnSearchLedger;
        private System.Windows.Forms.Label label9;
        private MyInputControls.MyNumericTextBox TxtMobileNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbUserType;
    }
}