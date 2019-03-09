namespace acmedesktop.DataTransaction.BillingTransaction
{
    partial class FrmRestaurantBilling
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRestaurantBilling));
			this.PnlLeft = new System.Windows.Forms.Panel();
			this.PnlTableList = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.PnlTableFilter = new System.Windows.Forms.Panel();
			this.FloorFocusIndicate = new System.Windows.Forms.Label();
			this.PnlTableType = new System.Windows.Forms.Panel();
			this.IndicateFocus = new System.Windows.Forms.Label();
			this.BtnReceiptTable = new System.Windows.Forms.Button();
			this.BtnOccupiedTable = new System.Windows.Forms.Button();
			this.BtnPackingTable = new System.Windows.Forms.Button();
			this.BtnAllTable = new System.Windows.Forms.Button();
			this.BtnDiningTable = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TableFocusIndicate = new System.Windows.Forms.Label();
			this.PnlRight = new System.Windows.Forms.Panel();
			this.PnlRightGrid = new System.Windows.Forms.Panel();
			this.Grid = new System.Windows.Forms.DataGridView();
			this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Particular = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GodownId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BasicAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TermAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NetAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.OrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TermsDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsTaxable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaxFreeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Kot = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsPrintKot = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsNote = new System.Windows.Forms.DataGridViewImageColumn();
			this.PrintKot = new System.Windows.Forms.DataGridViewImageColumn();
			this.RemoveRow = new System.Windows.Forms.DataGridViewImageColumn();
			this.PnlRightBottm = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtTotalNetAmt = new acmedesktop.MyInputControls.MyTextBox();
			this.TxtTotalTermAmt = new acmedesktop.MyInputControls.MyTextBox();
			this.TxtTotalBasicAmt = new acmedesktop.MyInputControls.MyTextBox();
			this.TxtTotalQty = new acmedesktop.MyInputControls.MyTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtAdjustAmount = new acmedesktop.MyInputControls.MyNumericTextBox();
			this.TxtBillDiscount = new acmedesktop.MyInputControls.MyNumericTextBox();
			this.TxtBillDiscountPercent = new acmedesktop.MyInputControls.MyNumericTextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.TxtVat = new acmedesktop.MyInputControls.MyTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.TxtBillAmt = new acmedesktop.MyInputControls.MyTextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.BtnCancelBill = new System.Windows.Forms.Button();
			this.BtnCancelOrder = new System.Windows.Forms.Button();
			this.BtnPrintOrder = new System.Windows.Forms.Button();
			this.BtnCardPayment = new System.Windows.Forms.Button();
			this.BtnCashPayment = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnCreditPayment = new System.Windows.Forms.Button();
			this.TxtRemarks = new acmedesktop.MyInputControls.MyTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.PnlRight6 = new System.Windows.Forms.Panel();
			this.PnlRight5 = new System.Windows.Forms.Panel();
			this.BtnPrintKOT = new System.Windows.Forms.Button();
			this.BtnNote = new System.Windows.Forms.Button();
			this.BtnTransferTable = new System.Windows.Forms.Button();
			this.BtnMergeTable = new System.Windows.Forms.Button();
			this.BtnSplitTable = new System.Windows.Forms.Button();
			this.BtnQty = new System.Windows.Forms.Button();
			this.BtnRate = new System.Windows.Forms.Button();
			this.BtnVat = new System.Windows.Forms.Button();
			this.BtnServiceCharge = new System.Windows.Forms.Button();
			this.BtnDiscount = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.PnlRight3 = new System.Windows.Forms.Panel();
			this.TxtKotNo = new acmedesktop.MyInputControls.MyTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.BtnWaiterSearch = new System.Windows.Forms.Button();
			this.BtnMemberSearch = new System.Windows.Forms.Button();
			this.TxtWaiter = new acmedesktop.MyInputControls.MyTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtMember = new acmedesktop.MyInputControls.MyTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.BtnProductSearch = new System.Windows.Forms.Button();
			this.TxtProduct = new acmedesktop.MyInputControls.MyTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.PnlRight2 = new System.Windows.Forms.Panel();
			this.PnlRight1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtOrderTime = new acmedesktop.MyInputControls.MyTextBox();
			this.TxtInvoiceNo = new acmedesktop.MyInputControls.MyTextBox();
			this.BtnVoucherNoSearch = new System.Windows.Forms.Button();
			this.TxtTable = new acmedesktop.MyInputControls.MyTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtDate = new acmedesktop.MyInputControls.MyMaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtMiti = new acmedesktop.MyInputControls.MyMaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtVoucherNo = new acmedesktop.MyInputControls.MyTextBox();
			this.lblVoucherNo = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.PnlLeft.SuspendLayout();
			this.PnlTableList.SuspendLayout();
			this.PnlTableFilter.SuspendLayout();
			this.PnlTableType.SuspendLayout();
			this.PnlRight.SuspendLayout();
			this.PnlRightGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
			this.PnlRightBottm.SuspendLayout();
			this.panel5.SuspendLayout();
			this.PnlRight5.SuspendLayout();
			this.PnlRight3.SuspendLayout();
			this.PnlRight1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PnlLeft
			// 
			this.PnlLeft.Controls.Add(this.PnlTableList);
			this.PnlLeft.Controls.Add(this.PnlTableFilter);
			this.PnlLeft.Controls.Add(this.PnlTableType);
			this.PnlLeft.Controls.Add(this.panel1);
			this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.PnlLeft.Location = new System.Drawing.Point(0, 0);
			this.PnlLeft.Name = "PnlLeft";
			this.PnlLeft.Size = new System.Drawing.Size(314, 487);
			this.PnlLeft.TabIndex = 0;
			// 
			// PnlTableList
			// 
			this.PnlTableList.AutoScroll = true;
			this.PnlTableList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlTableList.Controls.Add(this.panel3);
			this.PnlTableList.Controls.Add(this.panel2);
			this.PnlTableList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PnlTableList.Location = new System.Drawing.Point(0, 46);
			this.PnlTableList.Name = "PnlTableList";
			this.PnlTableList.Size = new System.Drawing.Size(313, 378);
			this.PnlTableList.TabIndex = 4;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 377);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(313, 1);
			this.panel3.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(313, 1);
			this.panel2.TabIndex = 0;
			// 
			// PnlTableFilter
			// 
			this.PnlTableFilter.AutoScroll = true;
			this.PnlTableFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlTableFilter.Controls.Add(this.FloorFocusIndicate);
			this.PnlTableFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlTableFilter.Location = new System.Drawing.Point(0, 424);
			this.PnlTableFilter.Name = "PnlTableFilter";
			this.PnlTableFilter.Size = new System.Drawing.Size(313, 63);
			this.PnlTableFilter.TabIndex = 2;
			// 
			// FloorFocusIndicate
			// 
			this.FloorFocusIndicate.BackColor = System.Drawing.Color.Yellow;
			this.FloorFocusIndicate.ForeColor = System.Drawing.Color.White;
			this.FloorFocusIndicate.Location = new System.Drawing.Point(9, 11);
			this.FloorFocusIndicate.Name = "FloorFocusIndicate";
			this.FloorFocusIndicate.Size = new System.Drawing.Size(49, 5);
			this.FloorFocusIndicate.TabIndex = 182;
			// 
			// PnlTableType
			// 
			this.PnlTableType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlTableType.Controls.Add(this.IndicateFocus);
			this.PnlTableType.Controls.Add(this.BtnReceiptTable);
			this.PnlTableType.Controls.Add(this.BtnOccupiedTable);
			this.PnlTableType.Controls.Add(this.BtnPackingTable);
			this.PnlTableType.Controls.Add(this.BtnAllTable);
			this.PnlTableType.Controls.Add(this.BtnDiningTable);
			this.PnlTableType.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlTableType.Location = new System.Drawing.Point(0, 0);
			this.PnlTableType.Name = "PnlTableType";
			this.PnlTableType.Size = new System.Drawing.Size(313, 46);
			this.PnlTableType.TabIndex = 1;
			// 
			// IndicateFocus
			// 
			this.IndicateFocus.BackColor = System.Drawing.Color.Yellow;
			this.IndicateFocus.ForeColor = System.Drawing.Color.White;
			this.IndicateFocus.Location = new System.Drawing.Point(6, 34);
			this.IndicateFocus.Name = "IndicateFocus";
			this.IndicateFocus.Size = new System.Drawing.Size(67, 5);
			this.IndicateFocus.TabIndex = 181;
			// 
			// BtnReceiptTable
			// 
			this.BtnReceiptTable.BackColor = System.Drawing.Color.MidnightBlue;
			this.BtnReceiptTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnReceiptTable.ForeColor = System.Drawing.Color.White;
			this.BtnReceiptTable.Location = new System.Drawing.Point(319, 5);
			this.BtnReceiptTable.Name = "BtnReceiptTable";
			this.BtnReceiptTable.Size = new System.Drawing.Size(54, 35);
			this.BtnReceiptTable.TabIndex = 5;
			this.BtnReceiptTable.Text = "Receipt";
			this.BtnReceiptTable.UseVisualStyleBackColor = false;
			this.BtnReceiptTable.Visible = false;
			this.BtnReceiptTable.Click += new System.EventHandler(this.BtnReceiptTable_Click);
			// 
			// BtnOccupiedTable
			// 
			this.BtnOccupiedTable.BackColor = System.Drawing.Color.Brown;
			this.BtnOccupiedTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnOccupiedTable.ForeColor = System.Drawing.Color.White;
			this.BtnOccupiedTable.Location = new System.Drawing.Point(223, 5);
			this.BtnOccupiedTable.Name = "BtnOccupiedTable";
			this.BtnOccupiedTable.Size = new System.Drawing.Size(70, 35);
			this.BtnOccupiedTable.TabIndex = 4;
			this.BtnOccupiedTable.Text = "Occupied";
			this.BtnOccupiedTable.UseVisualStyleBackColor = false;
			this.BtnOccupiedTable.Click += new System.EventHandler(this.BtnOccupiedTable_Click);
			// 
			// BtnPackingTable
			// 
			this.BtnPackingTable.BackColor = System.Drawing.Color.SeaGreen;
			this.BtnPackingTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnPackingTable.ForeColor = System.Drawing.Color.White;
			this.BtnPackingTable.Location = new System.Drawing.Point(151, 5);
			this.BtnPackingTable.Name = "BtnPackingTable";
			this.BtnPackingTable.Size = new System.Drawing.Size(70, 35);
			this.BtnPackingTable.TabIndex = 3;
			this.BtnPackingTable.Text = "Packing";
			this.BtnPackingTable.UseVisualStyleBackColor = false;
			this.BtnPackingTable.Click += new System.EventHandler(this.BtnPackingTable_Click);
			// 
			// BtnAllTable
			// 
			this.BtnAllTable.BackColor = System.Drawing.Color.ForestGreen;
			this.BtnAllTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnAllTable.ForeColor = System.Drawing.Color.White;
			this.BtnAllTable.Location = new System.Drawing.Point(6, 5);
			this.BtnAllTable.Name = "BtnAllTable";
			this.BtnAllTable.Size = new System.Drawing.Size(70, 35);
			this.BtnAllTable.TabIndex = 1;
			this.BtnAllTable.Text = "All";
			this.BtnAllTable.UseVisualStyleBackColor = false;
			this.BtnAllTable.Click += new System.EventHandler(this.BtnAllTable_Click);
			// 
			// BtnDiningTable
			// 
			this.BtnDiningTable.BackColor = System.Drawing.Color.SeaGreen;
			this.BtnDiningTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnDiningTable.ForeColor = System.Drawing.Color.White;
			this.BtnDiningTable.Location = new System.Drawing.Point(78, 5);
			this.BtnDiningTable.Name = "BtnDiningTable";
			this.BtnDiningTable.Size = new System.Drawing.Size(70, 35);
			this.BtnDiningTable.TabIndex = 2;
			this.BtnDiningTable.Text = "Dining";
			this.BtnDiningTable.UseVisualStyleBackColor = false;
			this.BtnDiningTable.Click += new System.EventHandler(this.BtnDiningTable_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(313, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1, 487);
			this.panel1.TabIndex = 0;
			// 
			// TableFocusIndicate
			// 
			this.TableFocusIndicate.BackColor = System.Drawing.Color.Yellow;
			this.TableFocusIndicate.ForeColor = System.Drawing.Color.White;
			this.TableFocusIndicate.Location = new System.Drawing.Point(256, 58);
			this.TableFocusIndicate.Name = "TableFocusIndicate";
			this.TableFocusIndicate.Size = new System.Drawing.Size(65, 5);
			this.TableFocusIndicate.TabIndex = 182;
			this.TableFocusIndicate.Visible = false;
			// 
			// PnlRight
			// 
			this.PnlRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.PnlRight.Controls.Add(this.PnlRightGrid);
			this.PnlRight.Controls.Add(this.PnlRightBottm);
			this.PnlRight.Controls.Add(this.PnlRight6);
			this.PnlRight.Controls.Add(this.PnlRight5);
			this.PnlRight.Controls.Add(this.panel4);
			this.PnlRight.Controls.Add(this.PnlRight3);
			this.PnlRight.Controls.Add(this.PnlRight2);
			this.PnlRight.Controls.Add(this.PnlRight1);
			this.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PnlRight.Location = new System.Drawing.Point(314, 0);
			this.PnlRight.Name = "PnlRight";
			this.PnlRight.Size = new System.Drawing.Size(991, 487);
			this.PnlRight.TabIndex = 1;
			// 
			// PnlRightGrid
			// 
			this.PnlRightGrid.Controls.Add(this.Grid);
			this.PnlRightGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PnlRightGrid.Location = new System.Drawing.Point(0, 136);
			this.PnlRightGrid.Name = "PnlRightGrid";
			this.PnlRightGrid.Size = new System.Drawing.Size(991, 210);
			this.PnlRightGrid.TabIndex = 7;
			// 
			// Grid
			// 
			this.Grid.AllowUserToAddRows = false;
			this.Grid.AllowUserToDeleteRows = false;
			this.Grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.Grid.BackgroundColor = System.Drawing.Color.White;
			this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.ProductShortName,
            this.Particular,
            this.ProductId,
            this.GodownId,
            this.Qty,
            this.Unit,
            this.ProductUnitId,
            this.Rate,
            this.BasicAmt,
            this.TermAmt,
            this.NetAmt,
            this.OrderTime,
            this.TermsDetails,
            this.IsTaxable,
            this.TaxFreeAmount,
            this.Kot,
            this.Notes,
            this.IsPrintKot,
            this.IsNote,
            this.PrintKot,
            this.RemoveRow});
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Grid.DefaultCellStyle = dataGridViewCellStyle10;
			this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.Grid.Location = new System.Drawing.Point(0, 0);
			this.Grid.MultiSelect = false;
			this.Grid.Name = "Grid";
			this.Grid.RowHeadersVisible = false;
			this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Grid.Size = new System.Drawing.Size(991, 210);
			this.Grid.StandardTab = true;
			this.Grid.TabIndex = 14;
			this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
			this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
			this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
			// 
			// SNo
			// 
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SNo.DefaultCellStyle = dataGridViewCellStyle3;
			this.SNo.FillWeight = 228.4264F;
			this.SNo.Frozen = true;
			this.SNo.HeaderText = "SNo";
			this.SNo.Name = "SNo";
			this.SNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.SNo.Width = 50;
			// 
			// ProductShortName
			// 
			this.ProductShortName.HeaderText = "Code";
			this.ProductShortName.Name = "ProductShortName";
			this.ProductShortName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ProductShortName.Width = 80;
			// 
			// Particular
			// 
			this.Particular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Particular.DefaultCellStyle = dataGridViewCellStyle4;
			this.Particular.FillWeight = 83.94669F;
			this.Particular.HeaderText = "Particular";
			this.Particular.Name = "Particular";
			this.Particular.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ProductId
			// 
			this.ProductId.HeaderText = "ProductId";
			this.ProductId.Name = "ProductId";
			this.ProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ProductId.Visible = false;
			// 
			// GodownId
			// 
			this.GodownId.HeaderText = "GodownId";
			this.GodownId.Name = "GodownId";
			this.GodownId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.GodownId.Visible = false;
			this.GodownId.Width = 20;
			// 
			// Qty
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.Qty.DefaultCellStyle = dataGridViewCellStyle5;
			this.Qty.HeaderText = "Qty";
			this.Qty.Name = "Qty";
			this.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Qty.Width = 50;
			// 
			// Unit
			// 
			this.Unit.HeaderText = "Unit";
			this.Unit.Name = "Unit";
			this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Unit.Width = 50;
			// 
			// ProductUnitId
			// 
			this.ProductUnitId.HeaderText = "ProductUnitId";
			this.ProductUnitId.Name = "ProductUnitId";
			this.ProductUnitId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ProductUnitId.Visible = false;
			this.ProductUnitId.Width = 20;
			// 
			// Rate
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.Rate.DefaultCellStyle = dataGridViewCellStyle6;
			this.Rate.HeaderText = "Rate";
			this.Rate.Name = "Rate";
			this.Rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Rate.Width = 70;
			// 
			// BasicAmt
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BasicAmt.DefaultCellStyle = dataGridViewCellStyle7;
			this.BasicAmt.FillWeight = 83.94669F;
			this.BasicAmt.HeaderText = "Basic Amt";
			this.BasicAmt.Name = "BasicAmt";
			this.BasicAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.BasicAmt.Width = 80;
			// 
			// TermAmt
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TermAmt.DefaultCellStyle = dataGridViewCellStyle8;
			this.TermAmt.HeaderText = "Term Amt";
			this.TermAmt.Name = "TermAmt";
			this.TermAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TermAmt.Width = 70;
			// 
			// NetAmt
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.NetAmt.DefaultCellStyle = dataGridViewCellStyle9;
			this.NetAmt.HeaderText = "Net Amt";
			this.NetAmt.Name = "NetAmt";
			this.NetAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.NetAmt.Width = 80;
			// 
			// OrderTime
			// 
			this.OrderTime.HeaderText = "Time";
			this.OrderTime.Name = "OrderTime";
			this.OrderTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.OrderTime.Width = 70;
			// 
			// TermsDetails
			// 
			this.TermsDetails.HeaderText = "TermsDetails";
			this.TermsDetails.Name = "TermsDetails";
			this.TermsDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TermsDetails.Visible = false;
			// 
			// IsTaxable
			// 
			this.IsTaxable.HeaderText = "IsTaxable";
			this.IsTaxable.Name = "IsTaxable";
			this.IsTaxable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.IsTaxable.Visible = false;
			// 
			// TaxFreeAmount
			// 
			this.TaxFreeAmount.HeaderText = "TaxFreeAmount";
			this.TaxFreeAmount.Name = "TaxFreeAmount";
			this.TaxFreeAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TaxFreeAmount.Visible = false;
			// 
			// Kot
			// 
			this.Kot.HeaderText = "Kot";
			this.Kot.Name = "Kot";
			this.Kot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Kot.Width = 60;
			// 
			// Notes
			// 
			this.Notes.HeaderText = "Notes";
			this.Notes.Name = "Notes";
			this.Notes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Notes.Visible = false;
			// 
			// IsPrintKot
			// 
			this.IsPrintKot.HeaderText = "IsPrintKot";
			this.IsPrintKot.Name = "IsPrintKot";
			this.IsPrintKot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.IsPrintKot.Visible = false;
			// 
			// IsNote
			// 
			this.IsNote.HeaderText = "Note";
			this.IsNote.Image = global::acmedesktop.Properties.Resources.transparent;
			this.IsNote.Name = "IsNote";
			this.IsNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.IsNote.Width = 50;
			// 
			// PrintKot
			// 
			this.PrintKot.HeaderText = "#";
			this.PrintKot.Image = global::acmedesktop.Properties.Resources.transparent;
			this.PrintKot.Name = "PrintKot";
			this.PrintKot.Width = 50;
			// 
			// RemoveRow
			// 
			this.RemoveRow.HeaderText = "#";
			this.RemoveRow.Image = global::acmedesktop.Properties.Resources.transparent;
			this.RemoveRow.Name = "RemoveRow";
			this.RemoveRow.Width = 50;
			// 
			// PnlRightBottm
			// 
			this.PnlRightBottm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlRightBottm.Controls.Add(this.panel5);
			this.PnlRightBottm.Controls.Add(this.TxtAdjustAmount);
			this.PnlRightBottm.Controls.Add(this.TxtBillDiscount);
			this.PnlRightBottm.Controls.Add(this.TxtBillDiscountPercent);
			this.PnlRightBottm.Controls.Add(this.btnOk);
			this.PnlRightBottm.Controls.Add(this.TxtVat);
			this.PnlRightBottm.Controls.Add(this.label16);
			this.PnlRightBottm.Controls.Add(this.TxtBillAmt);
			this.PnlRightBottm.Controls.Add(this.label12);
			this.PnlRightBottm.Controls.Add(this.label15);
			this.PnlRightBottm.Controls.Add(this.label14);
			this.PnlRightBottm.Controls.Add(this.BtnCancelBill);
			this.PnlRightBottm.Controls.Add(this.BtnCancelOrder);
			this.PnlRightBottm.Controls.Add(this.BtnPrintOrder);
			this.PnlRightBottm.Controls.Add(this.BtnCardPayment);
			this.PnlRightBottm.Controls.Add(this.BtnCashPayment);
			this.PnlRightBottm.Controls.Add(this.BtnCancel);
			this.PnlRightBottm.Controls.Add(this.BtnCreditPayment);
			this.PnlRightBottm.Controls.Add(this.TxtRemarks);
			this.PnlRightBottm.Controls.Add(this.label13);
			this.PnlRightBottm.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlRightBottm.Location = new System.Drawing.Point(0, 346);
			this.PnlRightBottm.Name = "PnlRightBottm";
			this.PnlRightBottm.Size = new System.Drawing.Size(991, 141);
			this.PnlRightBottm.TabIndex = 6;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.label18);
			this.panel5.Controls.Add(this.label17);
			this.panel5.Controls.Add(this.label11);
			this.panel5.Controls.Add(this.label10);
			this.panel5.Controls.Add(this.TxtTotalNetAmt);
			this.panel5.Controls.Add(this.TxtTotalTermAmt);
			this.panel5.Controls.Add(this.TxtTotalBasicAmt);
			this.panel5.Controls.Add(this.TxtTotalQty);
			this.panel5.Controls.Add(this.label9);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(991, 32);
			this.panel5.TabIndex = 205;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(559, 6);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(55, 16);
			this.label18.TabIndex = 213;
			this.label18.Text = "Net Amt";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(389, 6);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(63, 16);
			this.label17.TabIndex = 212;
			this.label17.Text = "Term Amt";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(89, 6);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 16);
			this.label11.TabIndex = 211;
			this.label11.Text = "Qty";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(216, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 16);
			this.label10.TabIndex = 210;
			this.label10.Text = "Basic Amt";
			// 
			// TxtTotalNetAmt
			// 
			this.TxtTotalNetAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTotalNetAmt.Enabled = false;
			this.TxtTotalNetAmt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTotalNetAmt.Location = new System.Drawing.Point(615, 3);
			this.TxtTotalNetAmt.Name = "TxtTotalNetAmt";
			this.TxtTotalNetAmt.ReadOnly = true;
			this.TxtTotalNetAmt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TxtTotalNetAmt.Size = new System.Drawing.Size(92, 22);
			this.TxtTotalNetAmt.TabIndex = 209;
			this.TxtTotalNetAmt.Tag = "0";
			this.TxtTotalNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtTotalTermAmt
			// 
			this.TxtTotalTermAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTotalTermAmt.Enabled = false;
			this.TxtTotalTermAmt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTotalTermAmt.Location = new System.Drawing.Point(453, 3);
			this.TxtTotalTermAmt.Name = "TxtTotalTermAmt";
			this.TxtTotalTermAmt.ReadOnly = true;
			this.TxtTotalTermAmt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TxtTotalTermAmt.Size = new System.Drawing.Size(92, 22);
			this.TxtTotalTermAmt.TabIndex = 208;
			this.TxtTotalTermAmt.Tag = "0";
			this.TxtTotalTermAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtTotalBasicAmt
			// 
			this.TxtTotalBasicAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTotalBasicAmt.Enabled = false;
			this.TxtTotalBasicAmt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTotalBasicAmt.Location = new System.Drawing.Point(286, 3);
			this.TxtTotalBasicAmt.Name = "TxtTotalBasicAmt";
			this.TxtTotalBasicAmt.ReadOnly = true;
			this.TxtTotalBasicAmt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TxtTotalBasicAmt.Size = new System.Drawing.Size(92, 22);
			this.TxtTotalBasicAmt.TabIndex = 207;
			this.TxtTotalBasicAmt.Tag = "0";
			this.TxtTotalBasicAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtTotalQty
			// 
			this.TxtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTotalQty.Enabled = false;
			this.TxtTotalQty.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTotalQty.Location = new System.Drawing.Point(121, 3);
			this.TxtTotalQty.Name = "TxtTotalQty";
			this.TxtTotalQty.ReadOnly = true;
			this.TxtTotalQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.TxtTotalQty.Size = new System.Drawing.Size(77, 22);
			this.TxtTotalQty.TabIndex = 206;
			this.TxtTotalQty.Tag = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(5, 6);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 16);
			this.label9.TabIndex = 205;
			this.label9.Text = "Total :";
			this.label9.Click += new System.EventHandler(this.label9_Click_1);
			// 
			// TxtAdjustAmount
			// 
			this.TxtAdjustAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtAdjustAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtAdjustAmount.Location = new System.Drawing.Point(399, 40);
			this.TxtAdjustAmount.Name = "TxtAdjustAmount";
			this.TxtAdjustAmount.Size = new System.Drawing.Size(90, 22);
			this.TxtAdjustAmount.TabIndex = 203;
			this.TxtAdjustAmount.TabStop = false;
			this.TxtAdjustAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtAdjustAmount.TextChanged += new System.EventHandler(this.TxtAdjustAmount_TextChanged);
			this.TxtAdjustAmount.Validating += new System.ComponentModel.CancelEventHandler(this.TxtAdjustAmount_Validating);
			// 
			// TxtBillDiscount
			// 
			this.TxtBillDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtBillDiscount.Enabled = false;
			this.TxtBillDiscount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtBillDiscount.Location = new System.Drawing.Point(308, 40);
			this.TxtBillDiscount.Name = "TxtBillDiscount";
			this.TxtBillDiscount.Size = new System.Drawing.Size(90, 22);
			this.TxtBillDiscount.TabIndex = 202;
			this.TxtBillDiscount.TabStop = false;
			this.TxtBillDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtBillDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBillDiscount_Validating);
			// 
			// TxtBillDiscountPercent
			// 
			this.TxtBillDiscountPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtBillDiscountPercent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtBillDiscountPercent.Location = new System.Drawing.Point(93, 40);
			this.TxtBillDiscountPercent.Name = "TxtBillDiscountPercent";
			this.TxtBillDiscountPercent.Size = new System.Drawing.Size(105, 22);
			this.TxtBillDiscountPercent.TabIndex = 201;
			this.TxtBillDiscountPercent.TabStop = false;
			this.TxtBillDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtBillDiscountPercent.TextChanged += new System.EventHandler(this.TxtBillDiscountPercent_TextChanged);
			this.TxtBillDiscountPercent.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBillDiscountPercent_Validating);
			// 
			// btnOk
			// 
			this.btnOk.Font = new System.Drawing.Font("Arial", 9.5F);
			this.btnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.Location = new System.Drawing.Point(846, 97);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(81, 40);
			this.btnOk.TabIndex = 198;
			this.btnOk.Text = "       OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Visible = false;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// TxtVat
			// 
			this.TxtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtVat.Enabled = false;
			this.TxtVat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtVat.Location = new System.Drawing.Point(591, 40);
			this.TxtVat.Name = "TxtVat";
			this.TxtVat.ReadOnly = true;
			this.TxtVat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.TxtVat.Size = new System.Drawing.Size(118, 22);
			this.TxtVat.TabIndex = 197;
			this.TxtVat.Tag = "0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(525, 42);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(61, 16);
			this.label16.TabIndex = 196;
			this.label16.Text = "Vat(13%)";
			// 
			// TxtBillAmt
			// 
			this.TxtBillAmt.BackColor = System.Drawing.Color.DarkOrange;
			this.TxtBillAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtBillAmt.Enabled = false;
			this.TxtBillAmt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtBillAmt.ForeColor = System.Drawing.Color.Black;
			this.TxtBillAmt.Location = new System.Drawing.Point(818, 39);
			this.TxtBillAmt.Name = "TxtBillAmt";
			this.TxtBillAmt.ReadOnly = true;
			this.TxtBillAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.TxtBillAmt.Size = new System.Drawing.Size(170, 39);
			this.TxtBillAmt.TabIndex = 181;
			this.TxtBillAmt.Tag = "0";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(731, 50);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(85, 18);
			this.label12.TabIndex = 178;
			this.label12.Text = "Bill Amount";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(216, 43);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(86, 16);
			this.label15.TabIndex = 194;
			this.label15.Text = "Discount Amt";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(5, 42);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(83, 16);
			this.label14.TabIndex = 192;
			this.label14.Text = "Discount (%)";
			// 
			// BtnCancelBill
			// 
			this.BtnCancelBill.CausesValidation = false;
			this.BtnCancelBill.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCancelBill.Image = global::acmedesktop.Properties.Resources.Cancel_24;
			this.BtnCancelBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCancelBill.Location = new System.Drawing.Point(373, 97);
			this.BtnCancelBill.Name = "BtnCancelBill";
			this.BtnCancelBill.Size = new System.Drawing.Size(118, 40);
			this.BtnCancelBill.TabIndex = 191;
			this.BtnCancelBill.Text = "     CANCEL BILL";
			this.BtnCancelBill.UseVisualStyleBackColor = true;
			this.BtnCancelBill.Click += new System.EventHandler(this.BtnCancelBill_Click);
			// 
			// BtnCancelOrder
			// 
			this.BtnCancelOrder.CausesValidation = false;
			this.BtnCancelOrder.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCancelOrder.Image = global::acmedesktop.Properties.Resources.Cancel_24;
			this.BtnCancelOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCancelOrder.Location = new System.Drawing.Point(617, 97);
			this.BtnCancelOrder.Name = "BtnCancelOrder";
			this.BtnCancelOrder.Size = new System.Drawing.Size(138, 40);
			this.BtnCancelOrder.TabIndex = 190;
			this.BtnCancelOrder.Text = "     CANCEL ORDER";
			this.BtnCancelOrder.UseVisualStyleBackColor = true;
			this.BtnCancelOrder.Click += new System.EventHandler(this.BtnCancelOrder_Click);
			// 
			// BtnPrintOrder
			// 
			this.BtnPrintOrder.CausesValidation = false;
			this.BtnPrintOrder.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnPrintOrder.Image = global::acmedesktop.Properties.Resources.Printer_24;
			this.BtnPrintOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnPrintOrder.Location = new System.Drawing.Point(492, 97);
			this.BtnPrintOrder.Name = "BtnPrintOrder";
			this.BtnPrintOrder.Size = new System.Drawing.Size(124, 40);
			this.BtnPrintOrder.TabIndex = 189;
			this.BtnPrintOrder.Text = "     PRINT ORDER";
			this.BtnPrintOrder.UseVisualStyleBackColor = true;
			this.BtnPrintOrder.Click += new System.EventHandler(this.BtnPrintOrder_Click);
			// 
			// BtnCardPayment
			// 
			this.BtnCardPayment.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCardPayment.Image = global::acmedesktop.Properties.Resources.card_24;
			this.BtnCardPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCardPayment.Location = new System.Drawing.Point(146, 97);
			this.BtnCardPayment.Name = "BtnCardPayment";
			this.BtnCardPayment.Size = new System.Drawing.Size(139, 40);
			this.BtnCardPayment.TabIndex = 185;
			this.BtnCardPayment.Text = "       CARD RECEIPT";
			this.BtnCardPayment.UseVisualStyleBackColor = true;
			this.BtnCardPayment.Click += new System.EventHandler(this.BtnCardPayment_Click);
			// 
			// BtnCashPayment
			// 
			this.BtnCashPayment.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCashPayment.Image = global::acmedesktop.Properties.Resources.cash_24;
			this.BtnCashPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCashPayment.Location = new System.Drawing.Point(6, 97);
			this.BtnCashPayment.Name = "BtnCashPayment";
			this.BtnCashPayment.Size = new System.Drawing.Size(139, 40);
			this.BtnCashPayment.TabIndex = 184;
			this.BtnCashPayment.Text = "       CASH RECEIPT";
			this.BtnCashPayment.UseVisualStyleBackColor = true;
			this.BtnCashPayment.Click += new System.EventHandler(this.BtnCashPayment_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.CausesValidation = false;
			this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
			this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCancel.Location = new System.Drawing.Point(756, 97);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(91, 40);
			this.BtnCancel.TabIndex = 187;
			this.BtnCancel.Text = "     &CANCEL";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnCreditPayment
			// 
			this.BtnCreditPayment.Font = new System.Drawing.Font("Arial", 9.5F);
			this.BtnCreditPayment.Image = global::acmedesktop.Properties.Resources.credit_24;
			this.BtnCreditPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtnCreditPayment.Location = new System.Drawing.Point(286, 97);
			this.BtnCreditPayment.Name = "BtnCreditPayment";
			this.BtnCreditPayment.Size = new System.Drawing.Size(86, 40);
			this.BtnCreditPayment.TabIndex = 186;
			this.BtnCreditPayment.Text = "      CREDIT";
			this.BtnCreditPayment.UseVisualStyleBackColor = true;
			this.BtnCreditPayment.Click += new System.EventHandler(this.BtnCreditPayment_Click);
			// 
			// TxtRemarks
			// 
			this.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtRemarks.Font = new System.Drawing.Font("Arial", 9.75F);
			this.TxtRemarks.Location = new System.Drawing.Point(93, 70);
			this.TxtRemarks.Name = "TxtRemarks";
			this.TxtRemarks.Size = new System.Drawing.Size(617, 22);
			this.TxtRemarks.TabIndex = 183;
			this.TxtRemarks.TabStop = false;
			this.TxtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRemarks_Validating);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.Font = new System.Drawing.Font("Arial", 9.5F);
			this.label13.Location = new System.Drawing.Point(5, 73);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 16);
			this.label13.TabIndex = 182;
			this.label13.Text = "Remarks";
			// 
			// PnlRight6
			// 
			this.PnlRight6.BackColor = System.Drawing.Color.White;
			this.PnlRight6.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlRight6.Location = new System.Drawing.Point(0, 135);
			this.PnlRight6.Name = "PnlRight6";
			this.PnlRight6.Size = new System.Drawing.Size(991, 1);
			this.PnlRight6.TabIndex = 5;
			// 
			// PnlRight5
			// 
			this.PnlRight5.BackColor = System.Drawing.Color.PowderBlue;
			this.PnlRight5.Controls.Add(this.BtnPrintKOT);
			this.PnlRight5.Controls.Add(this.BtnNote);
			this.PnlRight5.Controls.Add(this.BtnTransferTable);
			this.PnlRight5.Controls.Add(this.BtnMergeTable);
			this.PnlRight5.Controls.Add(this.BtnSplitTable);
			this.PnlRight5.Controls.Add(this.BtnQty);
			this.PnlRight5.Controls.Add(this.BtnRate);
			this.PnlRight5.Controls.Add(this.BtnVat);
			this.PnlRight5.Controls.Add(this.BtnServiceCharge);
			this.PnlRight5.Controls.Add(this.BtnDiscount);
			this.PnlRight5.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlRight5.Location = new System.Drawing.Point(0, 94);
			this.PnlRight5.Name = "PnlRight5";
			this.PnlRight5.Size = new System.Drawing.Size(991, 41);
			this.PnlRight5.TabIndex = 4;
			// 
			// BtnPrintKOT
			// 
			this.BtnPrintKOT.BackColor = System.Drawing.Color.Transparent;
			this.BtnPrintKOT.BackgroundImage = global::acmedesktop.Properties.Resources.printer_go;
			this.BtnPrintKOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.BtnPrintKOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnPrintKOT.ForeColor = System.Drawing.Color.Transparent;
			this.BtnPrintKOT.Location = new System.Drawing.Point(883, 5);
			this.BtnPrintKOT.Name = "BtnPrintKOT";
			this.BtnPrintKOT.Size = new System.Drawing.Size(40, 30);
			this.BtnPrintKOT.TabIndex = 14;
			this.BtnPrintKOT.TabStop = false;
			this.toolTip1.SetToolTip(this.BtnPrintKOT, "Print KOT");
			this.BtnPrintKOT.UseVisualStyleBackColor = false;
			this.BtnPrintKOT.Click += new System.EventHandler(this.BtnPrintKOT_Click);
			// 
			// BtnNote
			// 
			this.BtnNote.BackColor = System.Drawing.Color.Transparent;
			this.BtnNote.BackgroundImage = global::acmedesktop.Properties.Resources.note_16;
			this.BtnNote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.BtnNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnNote.ForeColor = System.Drawing.Color.Transparent;
			this.BtnNote.Location = new System.Drawing.Point(840, 5);
			this.BtnNote.Name = "BtnNote";
			this.BtnNote.Size = new System.Drawing.Size(40, 30);
			this.BtnNote.TabIndex = 13;
			this.BtnNote.TabStop = false;
			this.toolTip1.SetToolTip(this.BtnNote, "Add Notes");
			this.BtnNote.UseVisualStyleBackColor = false;
			this.BtnNote.Click += new System.EventHandler(this.BtnNote_Click);
			// 
			// BtnTransferTable
			// 
			this.BtnTransferTable.BackColor = System.Drawing.Color.Teal;
			this.BtnTransferTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnTransferTable.ForeColor = System.Drawing.Color.White;
			this.BtnTransferTable.Location = new System.Drawing.Point(693, 5);
			this.BtnTransferTable.Name = "BtnTransferTable";
			this.BtnTransferTable.Size = new System.Drawing.Size(112, 30);
			this.BtnTransferTable.TabIndex = 12;
			this.BtnTransferTable.TabStop = false;
			this.BtnTransferTable.Text = "&TRANSFER TABLE";
			this.BtnTransferTable.UseVisualStyleBackColor = false;
			this.BtnTransferTable.EnabledChanged += new System.EventHandler(this.BtnTransferTable_EnabledChanged);
			this.BtnTransferTable.Click += new System.EventHandler(this.BtnTransferTable_Click);
			this.BtnTransferTable.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnTransferTable_Paint);
			// 
			// BtnMergeTable
			// 
			this.BtnMergeTable.BackColor = System.Drawing.Color.Teal;
			this.BtnMergeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnMergeTable.ForeColor = System.Drawing.Color.White;
			this.BtnMergeTable.Location = new System.Drawing.Point(595, 5);
			this.BtnMergeTable.Name = "BtnMergeTable";
			this.BtnMergeTable.Size = new System.Drawing.Size(95, 30);
			this.BtnMergeTable.TabIndex = 11;
			this.BtnMergeTable.TabStop = false;
			this.BtnMergeTable.Text = "&MERGE TABLE";
			this.BtnMergeTable.UseVisualStyleBackColor = false;
			this.BtnMergeTable.EnabledChanged += new System.EventHandler(this.BtnMergeTable_EnabledChanged);
			this.BtnMergeTable.Click += new System.EventHandler(this.BtnMergeTable_Click);
			this.BtnMergeTable.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnMergeTable_Paint);
			// 
			// BtnSplitTable
			// 
			this.BtnSplitTable.BackColor = System.Drawing.Color.Teal;
			this.BtnSplitTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSplitTable.ForeColor = System.Drawing.Color.White;
			this.BtnSplitTable.Location = new System.Drawing.Point(506, 5);
			this.BtnSplitTable.Name = "BtnSplitTable";
			this.BtnSplitTable.Size = new System.Drawing.Size(86, 30);
			this.BtnSplitTable.TabIndex = 10;
			this.BtnSplitTable.TabStop = false;
			this.BtnSplitTable.Text = "SP&LIT TABLE";
			this.BtnSplitTable.UseVisualStyleBackColor = false;
			this.BtnSplitTable.EnabledChanged += new System.EventHandler(this.BtnSplitTable_EnabledChanged);
			this.BtnSplitTable.Click += new System.EventHandler(this.BtnSplitTable_Click);
			this.BtnSplitTable.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnSplitTable_Paint);
			// 
			// BtnQty
			// 
			this.BtnQty.BackColor = System.Drawing.Color.Teal;
			this.BtnQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnQty.ForeColor = System.Drawing.Color.White;
			this.BtnQty.Location = new System.Drawing.Point(310, 5);
			this.BtnQty.Name = "BtnQty";
			this.BtnQty.Size = new System.Drawing.Size(50, 30);
			this.BtnQty.TabIndex = 9;
			this.BtnQty.TabStop = false;
			this.BtnQty.Text = "&QTY";
			this.BtnQty.UseVisualStyleBackColor = false;
			this.BtnQty.EnabledChanged += new System.EventHandler(this.BtnQty_EnabledChanged);
			this.BtnQty.Click += new System.EventHandler(this.BtnQty_Click);
			this.BtnQty.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnQty_Paint);
			// 
			// BtnRate
			// 
			this.BtnRate.BackColor = System.Drawing.Color.Teal;
			this.BtnRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnRate.ForeColor = System.Drawing.Color.White;
			this.BtnRate.Location = new System.Drawing.Point(257, 5);
			this.BtnRate.Name = "BtnRate";
			this.BtnRate.Size = new System.Drawing.Size(50, 30);
			this.BtnRate.TabIndex = 8;
			this.BtnRate.TabStop = false;
			this.BtnRate.Text = "&RATE";
			this.BtnRate.UseVisualStyleBackColor = false;
			this.BtnRate.EnabledChanged += new System.EventHandler(this.BtnRate_EnabledChanged);
			this.BtnRate.Click += new System.EventHandler(this.BtnRate_Click);
			this.BtnRate.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnRate_Paint);
			// 
			// BtnVat
			// 
			this.BtnVat.BackColor = System.Drawing.Color.Teal;
			this.BtnVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnVat.ForeColor = System.Drawing.Color.White;
			this.BtnVat.Location = new System.Drawing.Point(204, 5);
			this.BtnVat.Name = "BtnVat";
			this.BtnVat.Size = new System.Drawing.Size(50, 30);
			this.BtnVat.TabIndex = 7;
			this.BtnVat.TabStop = false;
			this.BtnVat.Text = "VAT";
			this.BtnVat.UseVisualStyleBackColor = false;
			this.BtnVat.EnabledChanged += new System.EventHandler(this.BtnVat_EnabledChanged);
			this.BtnVat.Click += new System.EventHandler(this.BtnVat_Click);
			this.BtnVat.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnVat_Paint);
			// 
			// BtnServiceCharge
			// 
			this.BtnServiceCharge.BackColor = System.Drawing.Color.Teal;
			this.BtnServiceCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnServiceCharge.ForeColor = System.Drawing.Color.White;
			this.BtnServiceCharge.Location = new System.Drawing.Point(85, 5);
			this.BtnServiceCharge.Name = "BtnServiceCharge";
			this.BtnServiceCharge.Size = new System.Drawing.Size(116, 30);
			this.BtnServiceCharge.TabIndex = 6;
			this.BtnServiceCharge.TabStop = false;
			this.BtnServiceCharge.Text = "SERVICE &CHARGE";
			this.BtnServiceCharge.UseVisualStyleBackColor = false;
			this.BtnServiceCharge.EnabledChanged += new System.EventHandler(this.BtnServiceCharge_EnabledChanged);
			this.BtnServiceCharge.Click += new System.EventHandler(this.BtnServiceCharge_Click);
			this.BtnServiceCharge.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnServiceCharge_Paint);
			// 
			// BtnDiscount
			// 
			this.BtnDiscount.BackColor = System.Drawing.Color.Teal;
			this.BtnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnDiscount.ForeColor = System.Drawing.Color.White;
			this.BtnDiscount.Location = new System.Drawing.Point(8, 5);
			this.BtnDiscount.Name = "BtnDiscount";
			this.BtnDiscount.Size = new System.Drawing.Size(74, 30);
			this.BtnDiscount.TabIndex = 5;
			this.BtnDiscount.TabStop = false;
			this.BtnDiscount.Text = "&DISCOUNT";
			this.BtnDiscount.UseVisualStyleBackColor = false;
			this.BtnDiscount.EnabledChanged += new System.EventHandler(this.BtnDiscount_EnabledChanged);
			this.BtnDiscount.Click += new System.EventHandler(this.BtnDiscount_Click);
			this.BtnDiscount.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnDiscount_Paint);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.White;
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 93);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(991, 1);
			this.panel4.TabIndex = 3;
			// 
			// PnlRight3
			// 
			this.PnlRight3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlRight3.Controls.Add(this.TxtKotNo);
			this.PnlRight3.Controls.Add(this.label8);
			this.PnlRight3.Controls.Add(this.BtnWaiterSearch);
			this.PnlRight3.Controls.Add(this.BtnMemberSearch);
			this.PnlRight3.Controls.Add(this.TxtWaiter);
			this.PnlRight3.Controls.Add(this.label7);
			this.PnlRight3.Controls.Add(this.TxtMember);
			this.PnlRight3.Controls.Add(this.label6);
			this.PnlRight3.Controls.Add(this.BtnProductSearch);
			this.PnlRight3.Controls.Add(this.TxtProduct);
			this.PnlRight3.Controls.Add(this.label5);
			this.PnlRight3.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlRight3.Location = new System.Drawing.Point(0, 47);
			this.PnlRight3.Name = "PnlRight3";
			this.PnlRight3.Size = new System.Drawing.Size(991, 46);
			this.PnlRight3.TabIndex = 2;
			// 
			// TxtKotNo
			// 
			this.TxtKotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtKotNo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtKotNo.Location = new System.Drawing.Point(76, 11);
			this.TxtKotNo.Name = "TxtKotNo";
			this.TxtKotNo.Size = new System.Drawing.Size(86, 23);
			this.TxtKotNo.TabIndex = 0;
			this.TxtKotNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtKotNo_Validating);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(16, 14);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 16);
			this.label8.TabIndex = 183;
			this.label8.Text = "KOT No";
			// 
			// BtnWaiterSearch
			// 
			this.BtnWaiterSearch.CausesValidation = false;
			this.BtnWaiterSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnWaiterSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnWaiterSearch.Location = new System.Drawing.Point(346, 12);
			this.BtnWaiterSearch.Name = "BtnWaiterSearch";
			this.BtnWaiterSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnWaiterSearch.TabIndex = 182;
			this.BtnWaiterSearch.TabStop = false;
			this.BtnWaiterSearch.UseVisualStyleBackColor = true;
			this.BtnWaiterSearch.Click += new System.EventHandler(this.BtnWaiterSearch_Click);
			// 
			// BtnMemberSearch
			// 
			this.BtnMemberSearch.CausesValidation = false;
			this.BtnMemberSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnMemberSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnMemberSearch.Location = new System.Drawing.Point(904, 10);
			this.BtnMemberSearch.Name = "BtnMemberSearch";
			this.BtnMemberSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnMemberSearch.TabIndex = 176;
			this.BtnMemberSearch.TabStop = false;
			this.BtnMemberSearch.UseVisualStyleBackColor = true;
			this.BtnMemberSearch.Click += new System.EventHandler(this.BtnMemberSearch_Click);
			// 
			// TxtWaiter
			// 
			this.TxtWaiter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtWaiter.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtWaiter.Location = new System.Drawing.Point(240, 13);
			this.TxtWaiter.Name = "TxtWaiter";
			this.TxtWaiter.Size = new System.Drawing.Size(106, 23);
			this.TxtWaiter.TabIndex = 1;
			this.TxtWaiter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtWaiter_KeyDown);
			this.TxtWaiter.Validating += new System.ComponentModel.CancelEventHandler(this.TxtWaiter_Validating);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(189, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 16);
			this.label7.TabIndex = 179;
			this.label7.Text = "Waiter";
			// 
			// TxtMember
			// 
			this.TxtMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtMember.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtMember.Location = new System.Drawing.Point(751, 12);
			this.TxtMember.Name = "TxtMember";
			this.TxtMember.Size = new System.Drawing.Size(153, 22);
			this.TxtMember.TabIndex = 3;
			this.TxtMember.Tag = "0";
			this.TxtMember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMember_KeyDown);
			this.TxtMember.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMember_Validating);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(690, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 16);
			this.label6.TabIndex = 177;
			this.label6.Text = "Member";
			// 
			// BtnProductSearch
			// 
			this.BtnProductSearch.CausesValidation = false;
			this.BtnProductSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnProductSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnProductSearch.Location = new System.Drawing.Point(650, 9);
			this.BtnProductSearch.Name = "BtnProductSearch";
			this.BtnProductSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnProductSearch.TabIndex = 173;
			this.BtnProductSearch.TabStop = false;
			this.BtnProductSearch.UseVisualStyleBackColor = true;
			this.BtnProductSearch.Click += new System.EventHandler(this.BtnProductSearch_Click);
			// 
			// TxtProduct
			// 
			this.TxtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtProduct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtProduct.Location = new System.Drawing.Point(469, 11);
			this.TxtProduct.Name = "TxtProduct";
			this.TxtProduct.Size = new System.Drawing.Size(181, 22);
			this.TxtProduct.TabIndex = 2;
			this.TxtProduct.Tag = "0";
			this.TxtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProduct_KeyDown);
			this.TxtProduct.Validating += new System.ComponentModel.CancelEventHandler(this.TxtProduct_Validating);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(403, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 16);
			this.label5.TabIndex = 174;
			this.label5.Text = "Product";
			// 
			// PnlRight2
			// 
			this.PnlRight2.BackColor = System.Drawing.Color.White;
			this.PnlRight2.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlRight2.Location = new System.Drawing.Point(0, 46);
			this.PnlRight2.Name = "PnlRight2";
			this.PnlRight2.Size = new System.Drawing.Size(991, 1);
			this.PnlRight2.TabIndex = 1;
			// 
			// PnlRight1
			// 
			this.PnlRight1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
			this.PnlRight1.Controls.Add(this.label1);
			this.PnlRight1.Controls.Add(this.TxtOrderTime);
			this.PnlRight1.Controls.Add(this.TxtInvoiceNo);
			this.PnlRight1.Controls.Add(this.BtnVoucherNoSearch);
			this.PnlRight1.Controls.Add(this.TxtTable);
			this.PnlRight1.Controls.Add(this.label4);
			this.PnlRight1.Controls.Add(this.TxtDate);
			this.PnlRight1.Controls.Add(this.label3);
			this.PnlRight1.Controls.Add(this.TxtMiti);
			this.PnlRight1.Controls.Add(this.label2);
			this.PnlRight1.Controls.Add(this.TxtVoucherNo);
			this.PnlRight1.Controls.Add(this.lblVoucherNo);
			this.PnlRight1.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlRight1.Location = new System.Drawing.Point(0, 0);
			this.PnlRight1.Name = "PnlRight1";
			this.PnlRight1.Size = new System.Drawing.Size(991, 46);
			this.PnlRight1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(837, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 16);
			this.label1.TabIndex = 185;
			this.label1.Text = "Total Time: ";
			// 
			// TxtOrderTime
			// 
			this.TxtOrderTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtOrderTime.Enabled = false;
			this.TxtOrderTime.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtOrderTime.Location = new System.Drawing.Point(916, 13);
			this.TxtOrderTime.Name = "TxtOrderTime";
			this.TxtOrderTime.ReadOnly = true;
			this.TxtOrderTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.TxtOrderTime.Size = new System.Drawing.Size(60, 26);
			this.TxtOrderTime.TabIndex = 184;
			// 
			// TxtInvoiceNo
			// 
			this.TxtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtInvoiceNo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtInvoiceNo.Location = new System.Drawing.Point(609, 14);
			this.TxtInvoiceNo.Name = "TxtInvoiceNo";
			this.TxtInvoiceNo.Size = new System.Drawing.Size(117, 23);
			this.TxtInvoiceNo.TabIndex = 183;
			this.TxtInvoiceNo.Visible = false;
			this.TxtInvoiceNo.TextChanged += new System.EventHandler(this.TxtInvoiceNo_TextChanged);
			// 
			// BtnVoucherNoSearch
			// 
			this.BtnVoucherNoSearch.CausesValidation = false;
			this.BtnVoucherNoSearch.Font = new System.Drawing.Font("Arial", 9F);
			this.BtnVoucherNoSearch.Image = global::acmedesktop.Properties.Resources.search_16;
			this.BtnVoucherNoSearch.Location = new System.Drawing.Point(193, 13);
			this.BtnVoucherNoSearch.Name = "BtnVoucherNoSearch";
			this.BtnVoucherNoSearch.Size = new System.Drawing.Size(31, 25);
			this.BtnVoucherNoSearch.TabIndex = 181;
			this.BtnVoucherNoSearch.TabStop = false;
			this.BtnVoucherNoSearch.UseVisualStyleBackColor = true;
			this.BtnVoucherNoSearch.Click += new System.EventHandler(this.BtnVoucherNoSearch_Click);
			// 
			// TxtTable
			// 
			this.TxtTable.BackColor = System.Drawing.SystemColors.Window;
			this.TxtTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtTable.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTable.ForeColor = System.Drawing.Color.Black;
			this.TxtTable.Location = new System.Drawing.Point(522, 14);
			this.TxtTable.Name = "TxtTable";
			this.TxtTable.Size = new System.Drawing.Size(86, 23);
			this.TxtTable.TabIndex = 178;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(479, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 16);
			this.label4.TabIndex = 177;
			this.label4.Text = "Table";
			// 
			// TxtDate
			// 
			this.TxtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtDate.Location = new System.Drawing.Point(393, 14);
			this.TxtDate.Mask = "99/99/9999";
			this.TxtDate.Name = "TxtDate";
			this.TxtDate.Size = new System.Drawing.Size(74, 23);
			this.TxtDate.TabIndex = 174;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(353, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 16);
			this.label3.TabIndex = 176;
			this.label3.Text = "Date";
			// 
			// TxtMiti
			// 
			this.TxtMiti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtMiti.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtMiti.Location = new System.Drawing.Point(271, 14);
			this.TxtMiti.Mask = "99/99/9999";
			this.TxtMiti.Name = "TxtMiti";
			this.TxtMiti.Size = new System.Drawing.Size(74, 23);
			this.TxtMiti.TabIndex = 173;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(236, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 16);
			this.label2.TabIndex = 175;
			this.label2.Text = "Miti";
			// 
			// TxtVoucherNo
			// 
			this.TxtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtVoucherNo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtVoucherNo.Location = new System.Drawing.Point(76, 14);
			this.TxtVoucherNo.Name = "TxtVoucherNo";
			this.TxtVoucherNo.Size = new System.Drawing.Size(117, 23);
			this.TxtVoucherNo.TabIndex = 1;
			this.TxtVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtVoucherNo_KeyDown);
			this.TxtVoucherNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtVoucherNo_Validating);
			// 
			// lblVoucherNo
			// 
			this.lblVoucherNo.AutoSize = true;
			this.lblVoucherNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVoucherNo.Location = new System.Drawing.Point(10, 16);
			this.lblVoucherNo.Name = "lblVoucherNo";
			this.lblVoucherNo.Size = new System.Drawing.Size(60, 16);
			this.lblVoucherNo.TabIndex = 0;
			this.lblVoucherNo.Text = "Order No";
			// 
			// FrmRestaurantBilling
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.ClientSize = new System.Drawing.Size(1305, 487);
			this.Controls.Add(this.TableFocusIndicate);
			this.Controls.Add(this.PnlRight);
			this.Controls.Add(this.PnlLeft);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "FrmRestaurantBilling";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Restaurant Billing";
			this.Load += new System.EventHandler(this.FrmRestaurantBilling_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRestaurantBilling_KeyDown);
			this.PnlLeft.ResumeLayout(false);
			this.PnlTableList.ResumeLayout(false);
			this.PnlTableFilter.ResumeLayout(false);
			this.PnlTableType.ResumeLayout(false);
			this.PnlRight.ResumeLayout(false);
			this.PnlRightGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
			this.PnlRightBottm.ResumeLayout(false);
			this.PnlRightBottm.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.PnlRight5.ResumeLayout(false);
			this.PnlRight3.ResumeLayout(false);
			this.PnlRight3.PerformLayout();
			this.PnlRight1.ResumeLayout(false);
			this.PnlRight1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PnlRight;
        private System.Windows.Forms.Panel PnlTableType;
        private System.Windows.Forms.Panel PnlTableList;
        private System.Windows.Forms.Panel PnlTableFilter;
        private System.Windows.Forms.Button BtnAllTable;
        private System.Windows.Forms.Button BtnDiningTable;
        private System.Windows.Forms.Button BtnPackingTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnReceiptTable;
        private System.Windows.Forms.Button BtnOccupiedTable;
        private System.Windows.Forms.Panel PnlRight3;
        private System.Windows.Forms.Panel PnlRight2;
        private System.Windows.Forms.Panel PnlRight1;
        private System.Windows.Forms.Label lblVoucherNo;
        private MyInputControls.MyTextBox TxtVoucherNo;
        private MyInputControls.MyTextBox TxtTable;
        private System.Windows.Forms.Label label4;
        private MyInputControls.MyMaskedTextBox TxtDate;
        private System.Windows.Forms.Label label3;
        private MyInputControls.MyMaskedTextBox TxtMiti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnProductSearch;
        private MyInputControls.MyTextBox TxtProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnMemberSearch;
        private MyInputControls.MyTextBox TxtMember;
        private System.Windows.Forms.Label label6;
        private MyInputControls.MyTextBox TxtWaiter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnVoucherNoSearch;
        private System.Windows.Forms.Panel PnlRight5;
        private System.Windows.Forms.Button BtnQty;
        private System.Windows.Forms.Button BtnRate;
        private System.Windows.Forms.Button BtnVat;
        private System.Windows.Forms.Button BtnServiceCharge;
        private System.Windows.Forms.Button BtnDiscount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel PnlRightGrid;
        private System.Windows.Forms.Panel PnlRightBottm;
        private System.Windows.Forms.Panel PnlRight6;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button BtnWaiterSearch;
        private System.Windows.Forms.Label label12;
        private MyInputControls.MyTextBox TxtBillAmt;
        private MyInputControls.MyTextBox TxtRemarks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BtnCardPayment;
        private System.Windows.Forms.Button BtnCashPayment;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnCreditPayment;
        private System.Windows.Forms.Button BtnMergeTable;
        private System.Windows.Forms.Button BtnSplitTable;
        private System.Windows.Forms.Button BtnTransferTable;
        private System.Windows.Forms.Button BtnCancelBill;
        private System.Windows.Forms.Button BtnCancelOrder;
        private System.Windows.Forms.Button BtnPrintOrder;
        private System.Windows.Forms.Button BtnNote;
        private System.Windows.Forms.Button BtnPrintKOT;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label IndicateFocus;
        private System.Windows.Forms.Label TableFocusIndicate;
        private System.Windows.Forms.Label FloorFocusIndicate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private MyInputControls.MyTextBox TxtVat;
        private System.Windows.Forms.Label label16;
        private MyInputControls.MyTextBox TxtInvoiceNo;
        private MyInputControls.MyTextBox TxtKotNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private MyInputControls.MyTextBox TxtOrderTime;
        private MyInputControls.MyNumericTextBox TxtBillDiscountPercent;
        private MyInputControls.MyNumericTextBox TxtBillDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particular;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GodownId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermsDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsTaxable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxFreeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPrintKot;
        private System.Windows.Forms.DataGridViewImageColumn IsNote;
        private System.Windows.Forms.DataGridViewImageColumn PrintKot;
        private System.Windows.Forms.DataGridViewImageColumn RemoveRow;
        private MyInputControls.MyNumericTextBox TxtAdjustAmount;
        private System.Windows.Forms.Panel panel5;
        private MyInputControls.MyTextBox TxtTotalNetAmt;
        private MyInputControls.MyTextBox TxtTotalTermAmt;
        private MyInputControls.MyTextBox TxtTotalBasicAmt;
        private MyInputControls.MyTextBox TxtTotalQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}