namespace acmedesktop.MasterSetup
{
    partial class FrmSalesTerm
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
			this.PanelHeader = new System.Windows.Forms.Panel();
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
			this.PanelFooter = new System.Windows.Forms.Panel();
			this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnSave = new System.Windows.Forms.Button();
			this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
			this.PanelContainer = new System.Windows.Forms.Panel();
			this.ChkSupressZero = new System.Windows.Forms.CheckBox();
			this.ChkProfitability = new System.Windows.Forms.CheckBox();
			this.TxtFormula = new acmedesktop.MyInputControls.MyTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtTermRate = new acmedesktop.MyInputControls.MyNumericTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.CmbBillwise = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CmbTermType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.CmbSTSign = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.CmbBasis = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.CmbCategory = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtLedger = new acmedesktop.MyInputControls.MyTextBox();
			this.BtnLedgerSearch = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtTermPosition = new acmedesktop.MyInputControls.MyNumericTextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.TxtDescription = new acmedesktop.MyInputControls.MyTextBox();
			this.ChkActive = new System.Windows.Forms.CheckBox();
			this.BtnSearcDescription = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.PanelHeader.SuspendLayout();
			this.PanelFooter.SuspendLayout();
			this.PanelContainer.SuspendLayout();
			this.SuspendLayout();
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
			this.PanelHeader.Size = new System.Drawing.Size(616, 36);
			this.PanelHeader.TabIndex = 0;
			// 
			// PnlBorderHeaderTop
			// 
			this.PnlBorderHeaderTop.BackColor = System.Drawing.Color.White;
			this.PnlBorderHeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlBorderHeaderTop.Location = new System.Drawing.Point(0, 0);
			this.PnlBorderHeaderTop.Name = "PnlBorderHeaderTop";
			this.PnlBorderHeaderTop.Size = new System.Drawing.Size(616, 1);
			this.PnlBorderHeaderTop.TabIndex = 8;
			// 
			// BtnExit
			// 
			this.BtnExit.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnExit.Image = global::acmedesktop.Properties.Resources.Exit_24;
			this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnExit.Location = new System.Drawing.Point(544, 3);
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
			this.BtnLastData.Location = new System.Drawing.Point(408, 4);
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
			this.BtnPreviousData.Location = new System.Drawing.Point(373, 4);
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
			this.BtnNextData.Location = new System.Drawing.Point(338, 4);
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
			this.BtnFirstData.Location = new System.Drawing.Point(303, 4);
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
			this.PnlBorderHeaderBottom.Size = new System.Drawing.Size(616, 1);
			this.PnlBorderHeaderBottom.TabIndex = 0;
			// 
			// PanelFooter
			// 
			this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.PanelFooter.Controls.Add(this.PnlBorderFooterBoootm);
			this.PanelFooter.Controls.Add(this.BtnCancel);
			this.PanelFooter.Controls.Add(this.BtnSave);
			this.PanelFooter.Controls.Add(this.PnlBorderFooterTop);
			this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PanelFooter.Location = new System.Drawing.Point(0, 254);
			this.PanelFooter.Name = "PanelFooter";
			this.PanelFooter.Size = new System.Drawing.Size(616, 36);
			this.PanelFooter.TabIndex = 1;
			// 
			// PnlBorderFooterBoootm
			// 
			this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
			this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 35);
			this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
			this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(616, 1);
			this.PnlBorderFooterBoootm.TabIndex = 3;
			// 
			// BtnCancel
			// 
			this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
			this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCancel.Location = new System.Drawing.Point(518, 3);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(91, 31);
			this.BtnCancel.TabIndex = 2;
			this.BtnCancel.Text = "     &CANCEL";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnSave
			// 
			this.BtnSave.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnSave.Image = global::acmedesktop.Properties.Resources.Ok_24;
			this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnSave.Location = new System.Drawing.Point(461, 3);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(57, 31);
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
			this.PnlBorderFooterTop.Size = new System.Drawing.Size(616, 1);
			this.PnlBorderFooterTop.TabIndex = 0;
			// 
			// PanelContainer
			// 
			this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.PanelContainer.Controls.Add(this.ChkSupressZero);
			this.PanelContainer.Controls.Add(this.ChkProfitability);
			this.PanelContainer.Controls.Add(this.TxtFormula);
			this.PanelContainer.Controls.Add(this.label9);
			this.PanelContainer.Controls.Add(this.TxtTermRate);
			this.PanelContainer.Controls.Add(this.label8);
			this.PanelContainer.Controls.Add(this.CmbBillwise);
			this.PanelContainer.Controls.Add(this.label7);
			this.PanelContainer.Controls.Add(this.CmbTermType);
			this.PanelContainer.Controls.Add(this.label5);
			this.PanelContainer.Controls.Add(this.CmbSTSign);
			this.PanelContainer.Controls.Add(this.label6);
			this.PanelContainer.Controls.Add(this.CmbBasis);
			this.PanelContainer.Controls.Add(this.label4);
			this.PanelContainer.Controls.Add(this.CmbCategory);
			this.PanelContainer.Controls.Add(this.label3);
			this.PanelContainer.Controls.Add(this.TxtLedger);
			this.PanelContainer.Controls.Add(this.BtnLedgerSearch);
			this.PanelContainer.Controls.Add(this.label2);
			this.PanelContainer.Controls.Add(this.TxtTermPosition);
			this.PanelContainer.Controls.Add(this.label12);
			this.PanelContainer.Controls.Add(this.TxtDescription);
			this.PanelContainer.Controls.Add(this.ChkActive);
			this.PanelContainer.Controls.Add(this.BtnSearcDescription);
			this.PanelContainer.Controls.Add(this.label1);
			this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelContainer.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PanelContainer.Location = new System.Drawing.Point(0, 36);
			this.PanelContainer.Name = "PanelContainer";
			this.PanelContainer.Size = new System.Drawing.Size(616, 218);
			this.PanelContainer.TabIndex = 2;
			// 
			// ChkSupressZero
			// 
			this.ChkSupressZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.ChkSupressZero.Checked = true;
			this.ChkSupressZero.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkSupressZero.Font = new System.Drawing.Font("Arial", 9.5F);
			this.ChkSupressZero.Location = new System.Drawing.Point(226, 185);
			this.ChkSupressZero.Name = "ChkSupressZero";
			this.ChkSupressZero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.ChkSupressZero.Size = new System.Drawing.Size(181, 26);
			this.ChkSupressZero.TabIndex = 12;
			this.ChkSupressZero.Text = "Supress if Zero Amount";
			this.ChkSupressZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkSupressZero.UseVisualStyleBackColor = false;
			// 
			// ChkProfitability
			// 
			this.ChkProfitability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.ChkProfitability.Checked = true;
			this.ChkProfitability.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkProfitability.Font = new System.Drawing.Font("Arial", 9.5F);
			this.ChkProfitability.Location = new System.Drawing.Point(12, 185);
			this.ChkProfitability.Name = "ChkProfitability";
			this.ChkProfitability.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.ChkProfitability.Size = new System.Drawing.Size(128, 26);
			this.ChkProfitability.TabIndex = 11;
			this.ChkProfitability.Text = "Profitability";
			this.ChkProfitability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkProfitability.UseVisualStyleBackColor = false;
			// 
			// TxtFormula
			// 
			this.TxtFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtFormula.Font = new System.Drawing.Font("Arial", 9.5F);
			this.TxtFormula.Location = new System.Drawing.Point(128, 157);
			this.TxtFormula.MaxLength = 255;
			this.TxtFormula.Name = "TxtFormula";
			this.TxtFormula.Size = new System.Drawing.Size(186, 22);
			this.TxtFormula.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label9.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label9.Location = new System.Drawing.Point(12, 160);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(55, 16);
			this.label9.TabIndex = 80;
			this.label9.Text = "Formula";
			// 
			// TxtTermRate
			// 
			this.TxtTermRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTermRate.Location = new System.Drawing.Point(425, 129);
			this.TxtTermRate.MaxLength = 18;
			this.TxtTermRate.Name = "TxtTermRate";
			this.TxtTermRate.Size = new System.Drawing.Size(100, 22);
			this.TxtTermRate.TabIndex = 9;
			this.TxtTermRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtTermRate.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTermRate_Validating);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label8.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label8.Location = new System.Drawing.Point(345, 134);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 16);
			this.label8.TabIndex = 78;
			this.label8.Text = "Term Rate";
			// 
			// CmbBillwise
			// 
			this.CmbBillwise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbBillwise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CmbBillwise.Font = new System.Drawing.Font("Arial", 9F);
			this.CmbBillwise.FormattingEnabled = true;
			this.CmbBillwise.Items.AddRange(new object[] {
            "Product Wise",
            "Bill Wise"});
			this.CmbBillwise.Location = new System.Drawing.Point(128, 127);
			this.CmbBillwise.Name = "CmbBillwise";
			this.CmbBillwise.Size = new System.Drawing.Size(184, 23);
			this.CmbBillwise.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label7.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label7.Location = new System.Drawing.Point(12, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 16);
			this.label7.TabIndex = 76;
			this.label7.Text = "Term Wise";
			// 
			// CmbTermType
			// 
			this.CmbTermType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbTermType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CmbTermType.Font = new System.Drawing.Font("Arial", 9F);
			this.CmbTermType.FormattingEnabled = true;
			this.CmbTermType.Items.AddRange(new object[] {
            "Both",
            "Invoice",
            "Return"});
			this.CmbTermType.Location = new System.Drawing.Point(425, 99);
			this.CmbTermType.Name = "CmbTermType";
			this.CmbTermType.Size = new System.Drawing.Size(184, 23);
			this.CmbTermType.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label5.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label5.Location = new System.Drawing.Point(345, 106);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 16);
			this.label5.TabIndex = 74;
			this.label5.Text = "Term Type";
			// 
			// CmbSTSign
			// 
			this.CmbSTSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbSTSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CmbSTSign.Font = new System.Drawing.Font("Arial", 9F);
			this.CmbSTSign.FormattingEnabled = true;
			this.CmbSTSign.Items.AddRange(new object[] {
            "+",
            "-"});
			this.CmbSTSign.Location = new System.Drawing.Point(128, 97);
			this.CmbSTSign.Name = "CmbSTSign";
			this.CmbSTSign.Size = new System.Drawing.Size(184, 23);
			this.CmbSTSign.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label6.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label6.Location = new System.Drawing.Point(12, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 16);
			this.label6.TabIndex = 72;
			this.label6.Text = "Sign";
			// 
			// CmbBasis
			// 
			this.CmbBasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbBasis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CmbBasis.Font = new System.Drawing.Font("Arial", 9F);
			this.CmbBasis.FormattingEnabled = true;
			this.CmbBasis.Items.AddRange(new object[] {
            "Value",
            "Quantity"});
			this.CmbBasis.Location = new System.Drawing.Point(425, 69);
			this.CmbBasis.Name = "CmbBasis";
			this.CmbBasis.Size = new System.Drawing.Size(184, 23);
			this.CmbBasis.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label4.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label4.Location = new System.Drawing.Point(345, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 16);
			this.label4.TabIndex = 70;
			this.label4.Text = "Basis";
			// 
			// CmbCategory
			// 
			this.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CmbCategory.Font = new System.Drawing.Font("Arial", 9F);
			this.CmbCategory.FormattingEnabled = true;
			this.CmbCategory.Items.AddRange(new object[] {
            "General",
            "Additional",
            "RoundOff"});
			this.CmbCategory.Location = new System.Drawing.Point(128, 67);
			this.CmbCategory.Name = "CmbCategory";
			this.CmbCategory.Size = new System.Drawing.Size(184, 23);
			this.CmbCategory.TabIndex = 4;
			this.CmbCategory.SelectionChangeCommitted += new System.EventHandler(this.CmbCategory_SelectionChangeCommitted);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label3.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label3.Location = new System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 16);
			this.label3.TabIndex = 68;
			this.label3.Text = "Category";
			// 
			// TxtLedger
			// 
			this.TxtLedger.BackColor = System.Drawing.Color.White;
			this.TxtLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtLedger.Font = new System.Drawing.Font("Arial", 9.5F);
			this.TxtLedger.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TxtLedger.Location = new System.Drawing.Point(128, 39);
			this.TxtLedger.Name = "TxtLedger";
			this.TxtLedger.ReadOnly = true;
			this.TxtLedger.Size = new System.Drawing.Size(449, 22);
			this.TxtLedger.TabIndex = 3;
			this.TxtLedger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLedger_KeyDown);
			this.TxtLedger.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLedger_Validating);
			// 
			// BtnLedgerSearch
			// 
			this.BtnLedgerSearch.CausesValidation = false;
			this.BtnLedgerSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnLedgerSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnLedgerSearch.Location = new System.Drawing.Point(578, 37);
			this.BtnLedgerSearch.Name = "BtnLedgerSearch";
			this.BtnLedgerSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnLedgerSearch.TabIndex = 66;
			this.BtnLedgerSearch.TabStop = false;
			this.BtnLedgerSearch.UseVisualStyleBackColor = true;
			this.BtnLedgerSearch.Click += new System.EventHandler(this.BtnLedgerSearch_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label2.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label2.Location = new System.Drawing.Point(12, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 65;
			this.label2.Text = "Ledger";
			// 
			// TxtTermPosition
			// 
			this.TxtTermPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTermPosition.Location = new System.Drawing.Point(509, 10);
			this.TxtTermPosition.MaxLength = 2;
			this.TxtTermPosition.Name = "TxtTermPosition";
			this.TxtTermPosition.Size = new System.Drawing.Size(100, 22);
			this.TxtTermPosition.TabIndex = 2;
			this.TxtTermPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtTermPosition.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTermPosition_Validating);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label12.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label12.Location = new System.Drawing.Point(443, 15);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(55, 16);
			this.label12.TabIndex = 63;
			this.label12.Text = "Position";
			// 
			// TxtDescription
			// 
			this.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtDescription.Font = new System.Drawing.Font("Arial", 9.5F);
			this.TxtDescription.Location = new System.Drawing.Point(128, 11);
			this.TxtDescription.MaxLength = 50;
			this.TxtDescription.Name = "TxtDescription";
			this.TxtDescription.Size = new System.Drawing.Size(213, 22);
			this.TxtDescription.TabIndex = 1;
			this.TxtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescription_KeyDown);
			this.TxtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDescription_Validating);
			// 
			// ChkActive
			// 
			this.ChkActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.ChkActive.Checked = true;
			this.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkActive.Font = new System.Drawing.Font("Arial", 9.5F);
			this.ChkActive.Location = new System.Drawing.Point(494, 185);
			this.ChkActive.Name = "ChkActive";
			this.ChkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.ChkActive.Size = new System.Drawing.Size(112, 26);
			this.ChkActive.TabIndex = 13;
			this.ChkActive.Text = "Active";
			this.ChkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkActive.UseVisualStyleBackColor = false;
			// 
			// BtnSearcDescription
			// 
			this.BtnSearcDescription.CausesValidation = false;
			this.BtnSearcDescription.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnSearcDescription.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnSearcDescription.Location = new System.Drawing.Point(341, 10);
			this.BtnSearcDescription.Name = "BtnSearcDescription";
			this.BtnSearcDescription.Size = new System.Drawing.Size(31, 25);
			this.BtnSearcDescription.TabIndex = 35;
			this.BtnSearcDescription.TabStop = false;
			this.BtnSearcDescription.UseVisualStyleBackColor = true;
			this.BtnSearcDescription.Click += new System.EventHandler(this.BtnDescription_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label1.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 16);
			this.label1.TabIndex = 26;
			this.label1.Text = "Description";
			// 
			// FrmSalesTerm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.ClientSize = new System.Drawing.Size(616, 290);
			this.Controls.Add(this.PanelContainer);
			this.Controls.Add(this.PanelFooter);
			this.Controls.Add(this.PanelHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "FrmSalesTerm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sales Term";
			this.Load += new System.EventHandler(this.FrmSalesTerm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalesTerm_KeyDown);
			this.PanelHeader.ResumeLayout(false);
			this.PanelFooter.ResumeLayout(false);
			this.PanelContainer.ResumeLayout(false);
			this.PanelContainer.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Panel PnlBorderHeaderBottom;
        private System.Windows.Forms.Panel PnlBorderFooterTop;
        private System.Windows.Forms.Button BtnLastData;
        private System.Windows.Forms.Button BtnPreviousData;
        private System.Windows.Forms.Button BtnNextData;
        private System.Windows.Forms.Button BtnFirstData;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearcDescription;
        private System.Windows.Forms.CheckBox ChkActive;
        private System.Windows.Forms.Button BtnExit;
        private MyInputControls.MyTextBox TxtDescription;
        private System.Windows.Forms.Panel PnlBorderHeaderTop;
        private System.Windows.Forms.Panel PnlBorderFooterBoootm;
        private MyInputControls.MyNumericTextBox TxtTermPosition;
        private System.Windows.Forms.Label label12;
        private MyInputControls.MyTextBox TxtLedger;
        private System.Windows.Forms.Button BtnLedgerSearch;
        private System.Windows.Forms.Label label2;
        private MyInputControls.MyNumericTextBox TxtTermRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbBillwise;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbTermType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbSTSign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbBasis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkSupressZero;
        private System.Windows.Forms.CheckBox ChkProfitability;
        private MyInputControls.MyTextBox TxtFormula;
        private System.Windows.Forms.Label label9;
    }
}