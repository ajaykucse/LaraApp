namespace acmedesktop.MasterSetup
{
    partial class FrmUdfMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.TxtFieldDecimal = new acmedesktop.MyInputControls.MyNumericTextBox();
            this.LblFldDecimal = new System.Windows.Forms.Label();
            this.TxtDateFormat = new System.Windows.Forms.ComboBox();
            this.LblDateFormate = new System.Windows.Forms.Label();
            this.TxtPosition = new acmedesktop.MyInputControls.MyNumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkAllowDuplicate = new System.Windows.Forms.CheckBox();
            this.TxtFieldWidth = new acmedesktop.MyInputControls.MyNumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChkMandatoryOption = new System.Windows.Forms.CheckBox();
            this.CmbFieldType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescription = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchDescription = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GridList = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridModule = new System.Windows.Forms.DataGridView();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PnlBorderHeaderTop = new System.Windows.Forms.Panel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.PnlBorderHeaderBottom = new System.Windows.Forms.Panel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.PanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridModule)).BeginInit();
            this.PanelFooter.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelContainer.Controls.Add(this.TxtFieldDecimal);
            this.PanelContainer.Controls.Add(this.LblFldDecimal);
            this.PanelContainer.Controls.Add(this.TxtDateFormat);
            this.PanelContainer.Controls.Add(this.LblDateFormate);
            this.PanelContainer.Controls.Add(this.TxtPosition);
            this.PanelContainer.Controls.Add(this.label2);
            this.PanelContainer.Controls.Add(this.ChkAllowDuplicate);
            this.PanelContainer.Controls.Add(this.TxtFieldWidth);
            this.PanelContainer.Controls.Add(this.label4);
            this.PanelContainer.Controls.Add(this.ChkMandatoryOption);
            this.PanelContainer.Controls.Add(this.CmbFieldType);
            this.PanelContainer.Controls.Add(this.label3);
            this.PanelContainer.Controls.Add(this.TxtDescription);
            this.PanelContainer.Controls.Add(this.BtnSearchDescription);
            this.PanelContainer.Controls.Add(this.label1);
            this.PanelContainer.Controls.Add(this.GridList);
            this.PanelContainer.Controls.Add(this.GridModule);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelContainer.Location = new System.Drawing.Point(0, 36);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(663, 394);
            this.PanelContainer.TabIndex = 1;
            // 
            // TxtFieldDecimal
            // 
            this.TxtFieldDecimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFieldDecimal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtFieldDecimal.Location = new System.Drawing.Point(312, 124);
            this.TxtFieldDecimal.Name = "TxtFieldDecimal";
            this.TxtFieldDecimal.Size = new System.Drawing.Size(115, 22);
            this.TxtFieldDecimal.TabIndex = 8;
            this.TxtFieldDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblFldDecimal
            // 
            this.LblFldDecimal.AutoSize = true;
            this.LblFldDecimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.LblFldDecimal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.LblFldDecimal.Location = new System.Drawing.Point(234, 129);
            this.LblFldDecimal.Name = "LblFldDecimal";
            this.LblFldDecimal.Size = new System.Drawing.Size(77, 16);
            this.LblFldDecimal.TabIndex = 70;
            this.LblFldDecimal.Text = "Fld Decimal";
            // 
            // TxtDateFormat
            // 
            this.TxtDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtDateFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtDateFormat.Font = new System.Drawing.Font("Arial", 9F);
            this.TxtDateFormat.FormattingEnabled = true;
            this.TxtDateFormat.Items.AddRange(new object[] {
            "YYYY",
            "MM/YYYY",
            "DD/MM/YYYY"});
            this.TxtDateFormat.Location = new System.Drawing.Point(525, 95);
            this.TxtDateFormat.Name = "TxtDateFormat";
            this.TxtDateFormat.Size = new System.Drawing.Size(130, 23);
            this.TxtDateFormat.TabIndex = 7;
            this.TxtDateFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFieldType_KeyPress);
            // 
            // LblDateFormate
            // 
            this.LblDateFormate.AutoSize = true;
            this.LblDateFormate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.LblDateFormate.Font = new System.Drawing.Font("Arial", 9.5F);
            this.LblDateFormate.Location = new System.Drawing.Point(439, 99);
            this.LblDateFormate.Name = "LblDateFormate";
            this.LblDateFormate.Size = new System.Drawing.Size(80, 16);
            this.LblDateFormate.TabIndex = 68;
            this.LblDateFormate.Text = "Date Format";
            // 
            // TxtPosition
            // 
            this.TxtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPosition.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtPosition.Location = new System.Drawing.Point(312, 95);
            this.TxtPosition.Name = "TxtPosition";
            this.TxtPosition.Size = new System.Drawing.Size(115, 22);
            this.TxtPosition.TabIndex = 6;
            this.TxtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPosition.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPosition_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label2.Location = new System.Drawing.Point(234, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 66;
            this.label2.Text = "Position";
            // 
            // ChkAllowDuplicate
            // 
            this.ChkAllowDuplicate.AutoSize = true;
            this.ChkAllowDuplicate.Checked = true;
            this.ChkAllowDuplicate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAllowDuplicate.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAllowDuplicate.Location = new System.Drawing.Point(539, 68);
            this.ChkAllowDuplicate.Name = "ChkAllowDuplicate";
            this.ChkAllowDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkAllowDuplicate.Size = new System.Drawing.Size(116, 20);
            this.ChkAllowDuplicate.TabIndex = 5;
            this.ChkAllowDuplicate.Text = "Allow Duplicate";
            this.ChkAllowDuplicate.UseVisualStyleBackColor = true;
            // 
            // TxtFieldWidth
            // 
            this.TxtFieldWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFieldWidth.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtFieldWidth.Location = new System.Drawing.Point(312, 66);
            this.TxtFieldWidth.Name = "TxtFieldWidth";
            this.TxtFieldWidth.Size = new System.Drawing.Size(115, 22);
            this.TxtFieldWidth.TabIndex = 4;
            this.TxtFieldWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFieldWidth.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFieldWidth_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label4.Location = new System.Drawing.Point(234, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Field Width";
            // 
            // ChkMandatoryOption
            // 
            this.ChkMandatoryOption.AutoSize = true;
            this.ChkMandatoryOption.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMandatoryOption.Location = new System.Drawing.Point(525, 40);
            this.ChkMandatoryOption.Name = "ChkMandatoryOption";
            this.ChkMandatoryOption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkMandatoryOption.Size = new System.Drawing.Size(130, 20);
            this.ChkMandatoryOption.TabIndex = 3;
            this.ChkMandatoryOption.Text = "Mandatory Option";
            this.ChkMandatoryOption.UseVisualStyleBackColor = true;
            // 
            // CmbFieldType
            // 
            this.CmbFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFieldType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbFieldType.Font = new System.Drawing.Font("Arial", 9F);
            this.CmbFieldType.FormattingEnabled = true;
            this.CmbFieldType.Location = new System.Drawing.Point(312, 37);
            this.CmbFieldType.Name = "CmbFieldType";
            this.CmbFieldType.Size = new System.Drawing.Size(115, 23);
            this.CmbFieldType.TabIndex = 2;
            this.CmbFieldType.SelectionChangeCommitted += new System.EventHandler(this.CmbFieldType_SelectionChangeCommitted);
            this.CmbFieldType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFieldType_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label3.Location = new System.Drawing.Point(234, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 60;
            this.label3.Text = "Field Type";
            // 
            // TxtDescription
            // 
            this.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescription.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtDescription.Location = new System.Drawing.Point(312, 8);
            this.TxtDescription.MaxLength = 200;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(313, 22);
            this.TxtDescription.TabIndex = 1;
            this.TxtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescription_KeyDown);
            this.TxtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDescription_Validating);
            // 
            // BtnSearchDescription
            // 
            this.BtnSearchDescription.CausesValidation = false;
            this.BtnSearchDescription.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchDescription.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchDescription.Location = new System.Drawing.Point(625, 7);
            this.BtnSearchDescription.Name = "BtnSearchDescription";
            this.BtnSearchDescription.Size = new System.Drawing.Size(31, 25);
            this.BtnSearchDescription.TabIndex = 58;
            this.BtnSearchDescription.TabStop = false;
            this.BtnSearchDescription.UseVisualStyleBackColor = true;
            this.BtnSearchDescription.Click += new System.EventHandler(this.BtnSearchDescription_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label1.Location = new System.Drawing.Point(234, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "Description";
            // 
            // GridList
            // 
            this.GridList.AllowUserToAddRows = false;
            this.GridList.AllowUserToResizeColumns = false;
            this.GridList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridList.BackgroundColor = System.Drawing.Color.White;
            this.GridList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.GridList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.Description});
            this.GridList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridList.Location = new System.Drawing.Point(233, 153);
            this.GridList.MultiSelect = false;
            this.GridList.Name = "GridList";
            this.GridList.RowHeadersVisible = false;
            this.GridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridList.Size = new System.Drawing.Size(423, 233);
            this.GridList.StandardTab = true;
            this.GridList.TabIndex = 9;
            this.GridList.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.GridList_UserDeletedRow);
            this.GridList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridList_KeyDown);
            // 
            // SNo
            // 
            this.SNo.FillWeight = 228.4264F;
            this.SNo.Frozen = true;
            this.SNo.HeaderText = "SNo";
            this.SNo.Name = "SNo";
            this.SNo.Width = 50;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Description.DefaultCellStyle = dataGridViewCellStyle3;
            this.Description.FillWeight = 83.94669F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // GridModule
            // 
            this.GridModule.AllowUserToAddRows = false;
            this.GridModule.AllowUserToDeleteRows = false;
            this.GridModule.AllowUserToOrderColumns = true;
            this.GridModule.AllowUserToResizeColumns = false;
            this.GridModule.AllowUserToResizeRows = false;
            this.GridModule.BackgroundColor = System.Drawing.Color.White;
            this.GridModule.CausesValidation = false;
            this.GridModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleName});
            this.GridModule.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridModule.Location = new System.Drawing.Point(7, 8);
            this.GridModule.Name = "GridModule";
            this.GridModule.RowHeadersVisible = false;
            this.GridModule.Size = new System.Drawing.Size(220, 378);
            this.GridModule.TabIndex = 0;
            this.GridModule.TabStop = false;
            this.GridModule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridModule_CellContentClick);
            this.GridModule.SelectionChanged += new System.EventHandler(this.GridModule_SelectionChanged);
            this.GridModule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridModule_KeyDown);
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleName.HeaderText = "Module Name";
            this.ModuleName.Name = "ModuleName";
            // 
            // PnlBorderFooterBoootm
            // 
            this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 35);
            this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
            this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(663, 1);
            this.PnlBorderFooterBoootm.TabIndex = 3;
            // 
            // BtnCancel
            // 
            this.BtnCancel.CausesValidation = false;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(564, 3);
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
            this.BtnSave.Location = new System.Drawing.Point(505, 3);
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
            this.PnlBorderFooterTop.Size = new System.Drawing.Size(663, 1);
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
            this.PanelFooter.Location = new System.Drawing.Point(0, 430);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(663, 36);
            this.PanelFooter.TabIndex = 2;
            // 
            // PnlBorderHeaderTop
            // 
            this.PnlBorderHeaderTop.BackColor = System.Drawing.Color.White;
            this.PnlBorderHeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBorderHeaderTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderHeaderTop.Name = "PnlBorderHeaderTop";
            this.PnlBorderHeaderTop.Size = new System.Drawing.Size(663, 1);
            this.PnlBorderHeaderTop.TabIndex = 8;
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnExit.Image = global::acmedesktop.Properties.Resources.Exit_24;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(590, 5);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(65, 28);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "     E&XIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
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
            this.PnlBorderHeaderBottom.Size = new System.Drawing.Size(663, 1);
            this.PnlBorderHeaderBottom.TabIndex = 0;
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelHeader.Controls.Add(this.PnlBorderHeaderTop);
            this.PanelHeader.Controls.Add(this.BtnExit);
            this.PanelHeader.Controls.Add(this.BtnDelete);
            this.PanelHeader.Controls.Add(this.BtnEdit);
            this.PanelHeader.Controls.Add(this.BtnNew);
            this.PanelHeader.Controls.Add(this.PnlBorderHeaderBottom);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(663, 36);
            this.PanelHeader.TabIndex = 0;
            // 
            // FrmUdfMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 466);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelHeader);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUdfMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "UDF Master";
            this.Load += new System.EventHandler(this.FrmUdfMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUdfMaster_KeyDown);
            this.PanelContainer.ResumeLayout(false);
            this.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridModule)).EndInit();
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
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Panel PnlBorderHeaderBottom;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.DataGridView GridModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridView GridList;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private MyInputControls.MyNumericTextBox TxtFieldDecimal;
        private System.Windows.Forms.Label LblFldDecimal;
        private System.Windows.Forms.ComboBox TxtDateFormat;
        private System.Windows.Forms.Label LblDateFormate;
        private MyInputControls.MyNumericTextBox TxtPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkAllowDuplicate;
        private MyInputControls.MyNumericTextBox TxtFieldWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChkMandatoryOption;
        private System.Windows.Forms.ComboBox CmbFieldType;
        private System.Windows.Forms.Label label3;
        private MyInputControls.MyTextBox TxtDescription;
        private System.Windows.Forms.Button BtnSearchDescription;
        private System.Windows.Forms.Label label1;
    }
}