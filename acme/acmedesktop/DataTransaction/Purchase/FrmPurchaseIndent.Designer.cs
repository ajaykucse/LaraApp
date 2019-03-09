﻿namespace acmedesktop.DataTransaction.Purchase
{
    partial class FrmPurchaseIndent
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.PanelFooter = new System.Windows.Forms.Panel();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
			this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
			this.TabProductInfo = new System.Windows.Forms.TabPage();
			this.Grid = new System.Windows.Forms.DataGridView();
			this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Particular = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AltQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AltConversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AltUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductAltUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QtyConversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QtyUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Action = new System.Windows.Forms.DataGridViewImageColumn();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.PanelContainer = new System.Windows.Forms.Panel();
			this.txtRequestedBy = new acmedesktop.MyInputControls.MyTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtDepartment = new acmedesktop.MyInputControls.MyTextBox();
			this.BtnDepartmentSearch = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.BtnVoucherNoSearch = new System.Windows.Forms.Button();
			this.TxtDate = new acmedesktop.MyInputControls.MyMaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtMiti = new acmedesktop.MyInputControls.MyMaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtVoucherNo = new acmedesktop.MyInputControls.MyTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtRemarks = new acmedesktop.MyInputControls.MyTextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.PanelHeader = new System.Windows.Forms.Panel();
			this.BtnCopy = new System.Windows.Forms.Button();
			this.BtnPrint = new System.Windows.Forms.Button();
			this.BtnExit = new System.Windows.Forms.Button();
			this.BtnLastData = new System.Windows.Forms.Button();
			this.BtnPreviousData = new System.Windows.Forms.Button();
			this.BtnNextData = new System.Windows.Forms.Button();
			this.BtnFirstData = new System.Windows.Forms.Button();
			this.BtnDelete = new System.Windows.Forms.Button();
			this.BtnEdit = new System.Windows.Forms.Button();
			this.PnlBorderHeaderTop = new System.Windows.Forms.Panel();
			this.BtnNew = new System.Windows.Forms.Button();
			this.PnlBorderHeaderBottom = new System.Windows.Forms.Panel();
			this.PanelFooter.SuspendLayout();
			this.TabProductInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.PanelContainer.SuspendLayout();
			this.PanelHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// PanelFooter
			// 
			this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.PanelFooter.Controls.Add(this.BtnCancel);
			this.PanelFooter.Controls.Add(this.BtnOk);
			this.PanelFooter.Controls.Add(this.PnlBorderFooterBoootm);
			this.PanelFooter.Controls.Add(this.PnlBorderFooterTop);
			this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PanelFooter.Location = new System.Drawing.Point(0, 392);
			this.PanelFooter.Name = "PanelFooter";
			this.PanelFooter.Size = new System.Drawing.Size(878, 40);
			this.PanelFooter.TabIndex = 2;
			// 
			// BtnCancel
			// 
			this.BtnCancel.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
			this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCancel.Location = new System.Drawing.Point(780, 5);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(93, 31);
			this.BtnCancel.TabIndex = 2;
			this.BtnCancel.Text = "     &CANCEL";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnOk
			// 
			this.BtnOk.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
			this.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnOk.Location = new System.Drawing.Point(719, 5);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(57, 31);
			this.BtnOk.TabIndex = 1;
			this.BtnOk.Text = "     &OK";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// PnlBorderFooterBoootm
			// 
			this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
			this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 39);
			this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
			this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(878, 1);
			this.PnlBorderFooterBoootm.TabIndex = 3;
			// 
			// PnlBorderFooterTop
			// 
			this.PnlBorderFooterTop.BackColor = System.Drawing.Color.White;
			this.PnlBorderFooterTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlBorderFooterTop.Location = new System.Drawing.Point(0, 0);
			this.PnlBorderFooterTop.Name = "PnlBorderFooterTop";
			this.PnlBorderFooterTop.Size = new System.Drawing.Size(878, 1);
			this.PnlBorderFooterTop.TabIndex = 0;
			// 
			// TabProductInfo
			// 
			this.TabProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.TabProductInfo.Controls.Add(this.Grid);
			this.TabProductInfo.Location = new System.Drawing.Point(4, 25);
			this.TabProductInfo.Name = "TabProductInfo";
			this.TabProductInfo.Padding = new System.Windows.Forms.Padding(3);
			this.TabProductInfo.Size = new System.Drawing.Size(861, 206);
			this.TabProductInfo.TabIndex = 0;
			this.TabProductInfo.Text = "Product Details";
			// 
			// Grid
			// 
			this.Grid.AllowUserToAddRows = false;
			this.Grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.Grid.BackgroundColor = System.Drawing.Color.White;
			this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.Particular,
            this.ProductId,
            this.ProductShortName,
            this.AltQty,
            this.AltConversion,
            this.AltUOM,
            this.ProductAltUnitId,
            this.Qty,
            this.QtyConversion,
            this.QtyUOM,
            this.ProductUnitId,
            this.Narration,
            this.Action});
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Grid.DefaultCellStyle = dataGridViewCellStyle7;
			this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.Grid.Location = new System.Drawing.Point(6, 7);
			this.Grid.MultiSelect = false;
			this.Grid.Name = "Grid";
			this.Grid.RowHeadersVisible = false;
			this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Grid.Size = new System.Drawing.Size(852, 193);
			this.Grid.StandardTab = true;
			this.Grid.TabIndex = 0;
			this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
			this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
			this.Grid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.Grid_UserDeletedRow);
			this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
			// 
			// SNo
			// 
			this.SNo.FillWeight = 228.4264F;
			this.SNo.Frozen = true;
			this.SNo.HeaderText = "SNo";
			this.SNo.Name = "SNo";
			this.SNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.SNo.ToolTipText = "Delete Row";
			this.SNo.Width = 50;
			// 
			// Particular
			// 
			this.Particular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.Particular.DefaultCellStyle = dataGridViewCellStyle3;
			this.Particular.FillWeight = 83.94669F;
			this.Particular.HeaderText = "Particular";
			this.Particular.Name = "Particular";
			this.Particular.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ProductId
			// 
			this.ProductId.HeaderText = "ProductId";
			this.ProductId.Name = "ProductId";
			this.ProductId.Visible = false;
			// 
			// ProductShortName
			// 
			this.ProductShortName.HeaderText = "ProductShortName";
			this.ProductShortName.Name = "ProductShortName";
			this.ProductShortName.Visible = false;
			// 
			// AltQty
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.AltQty.DefaultCellStyle = dataGridViewCellStyle4;
			this.AltQty.HeaderText = "Alt Qty";
			this.AltQty.Name = "AltQty";
			this.AltQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.AltQty.Width = 60;
			// 
			// AltConversion
			// 
			this.AltConversion.HeaderText = "AltConversion";
			this.AltConversion.Name = "AltConversion";
			this.AltConversion.Visible = false;
			// 
			// AltUOM
			// 
			this.AltUOM.HeaderText = "UOM";
			this.AltUOM.Name = "AltUOM";
			this.AltUOM.Width = 50;
			// 
			// ProductAltUnitId
			// 
			this.ProductAltUnitId.HeaderText = "ProductAltUnitId";
			this.ProductAltUnitId.Name = "ProductAltUnitId";
			this.ProductAltUnitId.Visible = false;
			// 
			// Qty
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.Qty.DefaultCellStyle = dataGridViewCellStyle5;
			this.Qty.HeaderText = "Qty";
			this.Qty.Name = "Qty";
			this.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Qty.Width = 60;
			// 
			// QtyConversion
			// 
			this.QtyConversion.HeaderText = "QtyConversion";
			this.QtyConversion.Name = "QtyConversion";
			this.QtyConversion.Visible = false;
			// 
			// QtyUOM
			// 
			this.QtyUOM.HeaderText = "UOM";
			this.QtyUOM.Name = "QtyUOM";
			this.QtyUOM.Width = 50;
			// 
			// ProductUnitId
			// 
			this.ProductUnitId.HeaderText = "ProductUnitId";
			this.ProductUnitId.Name = "ProductUnitId";
			this.ProductUnitId.Visible = false;
			// 
			// Narration
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.Format = "N2";
			dataGridViewCellStyle6.NullValue = null;
			this.Narration.DefaultCellStyle = dataGridViewCellStyle6;
			this.Narration.FillWeight = 83.94669F;
			this.Narration.HeaderText = "Narration";
			this.Narration.Name = "Narration";
			this.Narration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Narration.Width = 250;
			// 
			// Action
			// 
			this.Action.HeaderText = "#";
			this.Action.Image = global::acmedesktop.Properties.Resources.Delete_16;
			this.Action.Name = "Action";
			this.Action.Width = 50;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.TabProductInfo);
			this.tabControl1.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(4, 76);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(869, 235);
			this.tabControl1.TabIndex = 5;
			this.tabControl1.TabStop = false;
			this.tabControl1.Tag = "0";
			// 
			// PanelContainer
			// 
			this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.PanelContainer.Controls.Add(this.txtRequestedBy);
			this.PanelContainer.Controls.Add(this.label4);
			this.PanelContainer.Controls.Add(this.tabControl1);
			this.PanelContainer.Controls.Add(this.TxtDepartment);
			this.PanelContainer.Controls.Add(this.BtnDepartmentSearch);
			this.PanelContainer.Controls.Add(this.label18);
			this.PanelContainer.Controls.Add(this.BtnVoucherNoSearch);
			this.PanelContainer.Controls.Add(this.TxtDate);
			this.PanelContainer.Controls.Add(this.label3);
			this.PanelContainer.Controls.Add(this.TxtMiti);
			this.PanelContainer.Controls.Add(this.label2);
			this.PanelContainer.Controls.Add(this.TxtVoucherNo);
			this.PanelContainer.Controls.Add(this.label1);
			this.PanelContainer.Controls.Add(this.TxtRemarks);
			this.PanelContainer.Controls.Add(this.label29);
			this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelContainer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PanelContainer.Location = new System.Drawing.Point(0, 40);
			this.PanelContainer.Name = "PanelContainer";
			this.PanelContainer.Size = new System.Drawing.Size(878, 392);
			this.PanelContainer.TabIndex = 1;
			// 
			// txtRequestedBy
			// 
			this.txtRequestedBy.BackColor = System.Drawing.Color.White;
			this.txtRequestedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRequestedBy.Font = new System.Drawing.Font("Arial", 9.75F);
			this.txtRequestedBy.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRequestedBy.Location = new System.Drawing.Point(92, 41);
			this.txtRequestedBy.Name = "txtRequestedBy";
			this.txtRequestedBy.Size = new System.Drawing.Size(387, 22);
			this.txtRequestedBy.TabIndex = 3;
			this.txtRequestedBy.Tag = "0";
			this.txtRequestedBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequestedBy_Validating);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label4.Font = new System.Drawing.Font("Arial", 9F);
			this.label4.Location = new System.Drawing.Point(7, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 15);
			this.label4.TabIndex = 188;
			this.label4.Text = "Requested By";
			// 
			// TxtDepartment
			// 
			this.TxtDepartment.BackColor = System.Drawing.Color.White;
			this.TxtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtDepartment.Font = new System.Drawing.Font("Arial", 9.75F);
			this.TxtDepartment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TxtDepartment.Location = new System.Drawing.Point(583, 41);
			this.TxtDepartment.Name = "TxtDepartment";
			this.TxtDepartment.ReadOnly = true;
			this.TxtDepartment.Size = new System.Drawing.Size(220, 22);
			this.TxtDepartment.TabIndex = 4;
			this.TxtDepartment.Tag = "0";
			this.TxtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDepartment_KeyDown);
			this.TxtDepartment.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDepartment_Validating);
			// 
			// BtnDepartmentSearch
			// 
			this.BtnDepartmentSearch.CausesValidation = false;
			this.BtnDepartmentSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnDepartmentSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnDepartmentSearch.Location = new System.Drawing.Point(803, 40);
			this.BtnDepartmentSearch.Name = "BtnDepartmentSearch";
			this.BtnDepartmentSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnDepartmentSearch.TabIndex = 153;
			this.BtnDepartmentSearch.TabStop = false;
			this.BtnDepartmentSearch.UseVisualStyleBackColor = true;
			this.BtnDepartmentSearch.Click += new System.EventHandler(this.BtnDepartmentSearch_Click);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.label18.Font = new System.Drawing.Font("Arial", 9F);
			this.label18.Location = new System.Drawing.Point(498, 44);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(72, 15);
			this.label18.TabIndex = 185;
			this.label18.Text = "Department";
			// 
			// BtnVoucherNoSearch
			// 
			this.BtnVoucherNoSearch.CausesValidation = false;
			this.BtnVoucherNoSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnVoucherNoSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnVoucherNoSearch.Location = new System.Drawing.Point(186, 8);
			this.BtnVoucherNoSearch.Name = "BtnVoucherNoSearch";
			this.BtnVoucherNoSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnVoucherNoSearch.TabIndex = 1;
			this.BtnVoucherNoSearch.TabStop = false;
			this.BtnVoucherNoSearch.UseVisualStyleBackColor = true;
			this.BtnVoucherNoSearch.Click += new System.EventHandler(this.BtnVoucherNoSearch_Click);
			// 
			// TxtDate
			// 
			this.TxtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.TxtDate.Location = new System.Drawing.Point(405, 9);
			this.TxtDate.Mask = "99/99/9999";
			this.TxtDate.Name = "TxtDate";
			this.TxtDate.Size = new System.Drawing.Size(74, 22);
			this.TxtDate.TabIndex = 2;
			this.TxtDate.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDate_Validating);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(363, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 16);
			this.label3.TabIndex = 172;
			this.label3.Text = "Date";
			// 
			// TxtMiti
			// 
			this.TxtMiti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtMiti.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.TxtMiti.Location = new System.Drawing.Point(275, 9);
			this.TxtMiti.Mask = "99/99/9999";
			this.TxtMiti.Name = "TxtMiti";
			this.TxtMiti.Size = new System.Drawing.Size(74, 22);
			this.TxtMiti.TabIndex = 1;
			this.TxtMiti.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMiti_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(233, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 16);
			this.label2.TabIndex = 137;
			this.label2.Text = "Miti";
			// 
			// TxtVoucherNo
			// 
			this.TxtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtVoucherNo.Location = new System.Drawing.Point(92, 9);
			this.TxtVoucherNo.Name = "TxtVoucherNo";
			this.TxtVoucherNo.Size = new System.Drawing.Size(94, 22);
			this.TxtVoucherNo.TabIndex = 0;
			this.TxtVoucherNo.Tag = "0";
			this.TxtVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtVoucherNo_KeyDown);
			this.TxtVoucherNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtVoucherNo_Validating);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 16);
			this.label1.TabIndex = 171;
			this.label1.Text = "Indent No";
			// 
			// TxtRemarks
			// 
			this.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtRemarks.Location = new System.Drawing.Point(94, 320);
			this.TxtRemarks.Name = "TxtRemarks";
			this.TxtRemarks.Size = new System.Drawing.Size(779, 22);
			this.TxtRemarks.TabIndex = 15;
			this.TxtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRemarks_Validating);
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(12, 320);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(60, 16);
			this.label29.TabIndex = 170;
			this.label29.Text = "Remarks";
			// 
			// PanelHeader
			// 
			this.PanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.PanelHeader.Controls.Add(this.BtnCopy);
			this.PanelHeader.Controls.Add(this.BtnPrint);
			this.PanelHeader.Controls.Add(this.BtnExit);
			this.PanelHeader.Controls.Add(this.BtnLastData);
			this.PanelHeader.Controls.Add(this.BtnPreviousData);
			this.PanelHeader.Controls.Add(this.BtnNextData);
			this.PanelHeader.Controls.Add(this.BtnFirstData);
			this.PanelHeader.Controls.Add(this.BtnDelete);
			this.PanelHeader.Controls.Add(this.BtnEdit);
			this.PanelHeader.Controls.Add(this.PnlBorderHeaderTop);
			this.PanelHeader.Controls.Add(this.BtnNew);
			this.PanelHeader.Controls.Add(this.PnlBorderHeaderBottom);
			this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.PanelHeader.Location = new System.Drawing.Point(0, 0);
			this.PanelHeader.Name = "PanelHeader";
			this.PanelHeader.Size = new System.Drawing.Size(878, 40);
			this.PanelHeader.TabIndex = 0;
			// 
			// BtnCopy
			// 
			this.BtnCopy.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnCopy.Image = global::acmedesktop.Properties.Resources.Exit_24;
			this.BtnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCopy.Location = new System.Drawing.Point(666, 2);
			this.BtnCopy.Name = "BtnCopy";
			this.BtnCopy.Size = new System.Drawing.Size(67, 32);
			this.BtnCopy.TabIndex = 7;
			this.BtnCopy.Text = "     COPY";
			this.BtnCopy.UseVisualStyleBackColor = true;
			this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
			// 
			// BtnPrint
			// 
			this.BtnPrint.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnPrint.Image = global::acmedesktop.Properties.Resources.Exit_24;
			this.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnPrint.Location = new System.Drawing.Point(736, 2);
			this.BtnPrint.Name = "BtnPrint";
			this.BtnPrint.Size = new System.Drawing.Size(67, 32);
			this.BtnPrint.TabIndex = 8;
			this.BtnPrint.Text = "     PRINT";
			this.BtnPrint.UseVisualStyleBackColor = true;
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			// 
			// BtnExit
			// 
			this.BtnExit.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnExit.Image = global::acmedesktop.Properties.Resources.Exit_24;
			this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnExit.Location = new System.Drawing.Point(806, 2);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.Size = new System.Drawing.Size(67, 32);
			this.BtnExit.TabIndex = 9;
			this.BtnExit.Text = "     E&XIT";
			this.BtnExit.UseVisualStyleBackColor = true;
			this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// BtnLastData
			// 
			this.BtnLastData.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnLastData.Location = new System.Drawing.Point(533, 5);
			this.BtnLastData.Name = "BtnLastData";
			this.BtnLastData.Size = new System.Drawing.Size(41, 32);
			this.BtnLastData.TabIndex = 6;
			this.BtnLastData.Text = ">|";
			this.BtnLastData.UseVisualStyleBackColor = true;
			// 
			// BtnPreviousData
			// 
			this.BtnPreviousData.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnPreviousData.Location = new System.Drawing.Point(493, 5);
			this.BtnPreviousData.Name = "BtnPreviousData";
			this.BtnPreviousData.Size = new System.Drawing.Size(41, 32);
			this.BtnPreviousData.TabIndex = 5;
			this.BtnPreviousData.Text = "<<";
			this.BtnPreviousData.UseVisualStyleBackColor = true;
			// 
			// BtnNextData
			// 
			this.BtnNextData.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnNextData.Location = new System.Drawing.Point(453, 5);
			this.BtnNextData.Name = "BtnNextData";
			this.BtnNextData.Size = new System.Drawing.Size(41, 32);
			this.BtnNextData.TabIndex = 4;
			this.BtnNextData.Text = ">>";
			this.BtnNextData.UseVisualStyleBackColor = true;
			// 
			// BtnFirstData
			// 
			this.BtnFirstData.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnFirstData.Location = new System.Drawing.Point(413, 5);
			this.BtnFirstData.Name = "BtnFirstData";
			this.BtnFirstData.Size = new System.Drawing.Size(41, 32);
			this.BtnFirstData.TabIndex = 3;
			this.BtnFirstData.Text = "|<";
			this.BtnFirstData.UseVisualStyleBackColor = true;
			// 
			// BtnDelete
			// 
			this.BtnDelete.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnDelete.Image = global::acmedesktop.Properties.Resources.Delete_24;
			this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnDelete.Location = new System.Drawing.Point(146, 5);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(84, 32);
			this.BtnDelete.TabIndex = 2;
			this.BtnDelete.Text = "     &DELETE";
			this.BtnDelete.UseVisualStyleBackColor = true;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// BtnEdit
			// 
			this.BtnEdit.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnEdit.Image = global::acmedesktop.Properties.Resources.Edit_24;
			this.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnEdit.Location = new System.Drawing.Point(77, 5);
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.Size = new System.Drawing.Size(70, 32);
			this.BtnEdit.TabIndex = 1;
			this.BtnEdit.Text = "     &EDIT";
			this.BtnEdit.UseVisualStyleBackColor = true;
			this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			// 
			// PnlBorderHeaderTop
			// 
			this.PnlBorderHeaderTop.BackColor = System.Drawing.Color.White;
			this.PnlBorderHeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlBorderHeaderTop.Location = new System.Drawing.Point(0, 0);
			this.PnlBorderHeaderTop.Name = "PnlBorderHeaderTop";
			this.PnlBorderHeaderTop.Size = new System.Drawing.Size(878, 1);
			this.PnlBorderHeaderTop.TabIndex = 0;
			// 
			// BtnNew
			// 
			this.BtnNew.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnNew.Image = global::acmedesktop.Properties.Resources.New_24;
			this.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnNew.Location = new System.Drawing.Point(10, 5);
			this.BtnNew.Name = "BtnNew";
			this.BtnNew.Size = new System.Drawing.Size(68, 32);
			this.BtnNew.TabIndex = 0;
			this.BtnNew.Text = "     &NEW";
			this.BtnNew.UseVisualStyleBackColor = true;
			this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
			// 
			// PnlBorderHeaderBottom
			// 
			this.PnlBorderHeaderBottom.BackColor = System.Drawing.Color.White;
			this.PnlBorderHeaderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlBorderHeaderBottom.Location = new System.Drawing.Point(0, 39);
			this.PnlBorderHeaderBottom.Name = "PnlBorderHeaderBottom";
			this.PnlBorderHeaderBottom.Size = new System.Drawing.Size(878, 1);
			this.PnlBorderHeaderBottom.TabIndex = 0;
			// 
			// FrmPurchaseIndent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 432);
			this.Controls.Add(this.PanelFooter);
			this.Controls.Add(this.PanelContainer);
			this.Controls.Add(this.PanelHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPurchaseIndent";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Purchase Indent";
			this.Load += new System.EventHandler(this.FrmPurchaseIndent_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPurchaseIndent_KeyDown);
			this.PanelFooter.ResumeLayout(false);
			this.TabProductInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.PanelContainer.ResumeLayout(false);
			this.PanelContainer.PerformLayout();
			this.PanelHeader.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Panel PnlBorderFooterBoootm;
        private System.Windows.Forms.Panel PnlBorderFooterTop;
        private System.Windows.Forms.TabPage TabProductInfo;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel PanelContainer;
        private MyInputControls.MyTextBox TxtDepartment;
        private System.Windows.Forms.Button BtnDepartmentSearch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BtnVoucherNoSearch;
        private MyInputControls.MyMaskedTextBox TxtDate;
        private System.Windows.Forms.Label label3;
        private MyInputControls.MyMaskedTextBox TxtMiti;
        private System.Windows.Forms.Label label2;
        private MyInputControls.MyTextBox TxtVoucherNo;
        private System.Windows.Forms.Label label1;
        private MyInputControls.MyTextBox TxtRemarks;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnLastData;
        private System.Windows.Forms.Button BtnPreviousData;
        private System.Windows.Forms.Button BtnNextData;
        private System.Windows.Forms.Button BtnFirstData;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Panel PnlBorderHeaderTop;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Panel PnlBorderHeaderBottom;
        private MyInputControls.MyTextBox txtRequestedBy;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Particular;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProductShortName;
		private System.Windows.Forms.DataGridViewTextBoxColumn AltQty;
		private System.Windows.Forms.DataGridViewTextBoxColumn AltConversion;
		private System.Windows.Forms.DataGridViewTextBoxColumn AltUOM;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProductAltUnitId;
		private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
		private System.Windows.Forms.DataGridViewTextBoxColumn QtyConversion;
		private System.Windows.Forms.DataGridViewTextBoxColumn QtyUOM;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProductUnitId;
		private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
		private System.Windows.Forms.DataGridViewImageColumn Action;
	}
}