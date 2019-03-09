﻿using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    class MyGridPickListTextBox : TextBox
    {
        public enum ListType
        {
            GeneralLedger = 1,
            SubLedger = 2,
            Salesman = 3,
            Department = 4,
            Product = 5,
            Currency = 6,
            Narration = 7,
            GoDown = 8,
            ProductUnit = 9,
            None = 10,
            GeneralLedgerForJV = 11,
            DRCRLedger = 12,
            SalesBatch = 13,
            OrderProduct = 14,
            RefOrderNO = 15,
            Group = 16,
            ProductScheme = 17,
            AddPurchaseBillTerm = 18,
            AddSalesBillTerm = 19,
            CostCenter = 20,
            GeneralLedgerForOB = 21,
            GenrealLedgerforOL = 22,
            ProductForPhysStock = 23,
            Vouchers = 24,
            VouchersPB = 25,
            AdjustPurchaseVouchers = 26,
            AdjustSalesVouchers = 27,
            Waiter=28
        }
        public event EnterKeyPressHandler EnterKeyPress;
        public delegate void EnterKeyPressHandler();

        string searchKey = "";
        public string ProductShortName { get; set; }
        public string ProductQtyConversion { get; set; }
        public decimal AltConversion { get; set; }
        //public Decimal Qty { get; set; }
        //public Decimal AltQty { get; set; }
        //public Decimal BalanceQty { get; set; }
        //public string AdjustVoucher { get; set; }
        //public int AdjustIndex { get; set; }
        //public string previousData { get; set; }
        //public string currentData { get; set; }
        //public bool isF1 { get; set; }
        public string GlTaggedSalesmanName { get; set; }
        public string GlTaggedSalesmanCode { get; set; }
        //public char IsDocumentContraType { get; set; }   // used from cash bank book
        //public string Unit { get; set; }
        //public string AltUnit { get; set; }
        //public decimal SalesRate { get; set; }
        //public decimal BuyRate { get; set; }
        //public TextBox StockQty { get; set; } // used from SALES INVOICE
        //public TextBox AltStockQty { get; set; } // used from SALES INVOICE
        //public string P_code { get; set; }

        //public DateTime vDate { get; set; }  //used for voucher Adjustment
        //public decimal vAmount { get; set; }  //used for voucher Adjustment 
        //public string vSource { get; set; } //used for voucher Adjustment Source
        //public string vSerial { get; set; } //used for voucher Adjustment Source

        public Dictionary<string, string> ProductDetails = new Dictionary<string, string>();

        DataGridView gridview = new DataGridView();
        public TextBox TxtValue { get; set; }
        public ListType PickListType { get; set; }

        public MyGridPickListTextBox()
        {
            ReadOnly = true;
            BackColor = System.Drawing.Color.White;
        }
        public MyGridPickListTextBox(DataGridView grid)
        {
            ReadOnly = true;
            BackColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            GotFocus += new EventHandler(PickListTextBox_GotFocus);
            LostFocus += new EventHandler(PickListTextBox_LostFocus);
            gridview = grid;
            if (grid != null)
            {
                grid.Controls.Add(this);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            searchKey = keyData.ToString();
            char key = (char)keyData;

            if (keyData == Keys.D0 || keyData == Keys.NumPad0)
            {
                searchKey = "0";
            }

            if (keyData == Keys.D1 || keyData == Keys.NumPad1)
            {
                searchKey = "1";
            }

            if (keyData == Keys.D2 || keyData == Keys.NumPad2)
            {
                searchKey = "2";
            }

            if (keyData == Keys.D3 || keyData == Keys.NumPad3)
            {
                searchKey = "3";
            }

            if (keyData == Keys.D4 || keyData == Keys.NumPad4)
            {
                searchKey = "4";
            }

            if (keyData == Keys.D5 || keyData == Keys.NumPad5)
            {
                searchKey = "5";
            }

            if (keyData == Keys.D6 || keyData == Keys.NumPad6)
            {
                searchKey = "6";
            }

            if (keyData == Keys.D7 || keyData == Keys.NumPad7)
            {
                searchKey = "7";
            }

            if (keyData == Keys.D8 || keyData == Keys.NumPad8)
            {
                searchKey = "8";
            }

            if (keyData == Keys.D9 || keyData == Keys.NumPad9)
            {
                searchKey = "9";
            }

            //if (searchKey == "0" || searchKey == "1" || searchKey == "2" || searchKey == "3" || searchKey == "4" || searchKey == "5" || searchKey == "6" || searchKey == "7" || searchKey == "8" || searchKey == "9")
            //{
            //    ShowList();
            //}

            if (keyData == Keys.F1)
            {
                //if (ReadOnly == false)
                //{
                    //previousData = Text;
                    // this.Text = "";                                                                       
                    ShowList();
                //}
            }
			if (keyData == Keys.F2)
			{
				if (Convert.ToInt32(gridview.CurrentRow.Index) > 0 && PickListType.ToString() == "Narration")
				{
					Text = "";
					Text = gridview.Rows[Convert.ToInt32(gridview.CurrentRow.Index) - 1].Cells["Narration"].Value.ToString();
				}
			}
			else if (keyData == Keys.F3)
			{
				if (Convert.ToInt32(gridview.CurrentRow.Index) > 0 && PickListType.ToString() == "Narration")
				{
					Text = "";
					Text = gridview.Rows[0].Cells["Narration"].Value.ToString();
				}
			}
			else if (System.Text.RegularExpressions.Regex.IsMatch(keyData.ToString(), @"^D?[a-zA-Z0-9]{1}$"))
			{
				if (PickListType.ToString() != "Narration")
				{
					ShowList();
				}
			}
			else if (keyData == (Keys.N | Keys.Control))
			{
				//CreateNew();
			}
			else if (keyData == Keys.Delete)
			{
				Text = "";
			}
			else if (keyData == Keys.Back)
			{
				if (PickListType.ToString() != "Narration")
					Text = "";
			}
			else if (keyData == Keys.Enter)
			{
				if (EnterKeyPress != null)
				{
					EnterKeyPress();
					return true; //Or false??? return to override the basic behavior
				}
				else
				{
					SendKeys.Send("{Tab}");
					return true;
				}
			}
			else if (keyData == Keys.Up || keyData == Keys.Down)
			{
				return true;//Or false??? return to override the basic behavior
			}
			else if (keyData == Keys.Tab)
			{
				// SendKeys.Send("+{Tab}");
			}
			else
			{
				//HandleCmdKey(keyData);
			}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowList()
        {
            switch (PickListType)
            {
                case ListType.CostCenter:
                    CostCenter();
                    break;
                case ListType.GeneralLedger:
                    GeneralLedger();
                    break;
                case ListType.GeneralLedgerForJV:
                    GeneralLedgerForJV();
                    break;
                case ListType.DRCRLedger:
                    GeneralLedgerForDRCR();
                    break;
                case ListType.SubLedger:
                    SubLedger();
                    break;
                case ListType.Salesman:
                    Salesman();
                    break;
                case ListType.Department:
                    Department();
                    break;
                case ListType.Narration:
                    if (searchKey == "F1")
                    {
                        Narration();
                    }
                    break;
                case ListType.GoDown:
                    Godown();
                    break;
                case ListType.ProductUnit:
                    ProductUnit();
                    break;
                case ListType.Product:
                    Product();
                    break;
                case ListType.ProductForPhysStock:
                    ProductForPhysStock();
                    break;
                case ListType.ProductScheme:
                    ProductScheme();
                    break;
                case ListType.Group:
                    Group();
                    break;
                case ListType.Currency:
                    Currency();
                    break;
                case ListType.GeneralLedgerForOB:
                    GeneralLedgerForOB();
                    break;
                //case ListType.OrderProduct:
                //    if (clsGlobal.ChangeProduct == false)
                //        Product();
                //    break;
                case ListType.SalesBatch:
                    SalesBatch();
                    break;
                case ListType.RefOrderNO:
                    SalesRefOrderNo();
                    break;
                case ListType.AddPurchaseBillTerm:
                    AddPurchaseBillTerm();
                    break;
                case ListType.AddSalesBillTerm:
                    AddSalesBillTerm();
                    break;
                case ListType.GenrealLedgerforOL:
                    GeneralLedgerForOL();
                    break;
                case ListType.Vouchers:
                    Vouchers();
                    break;
                case ListType.VouchersPB:
                    VouchersPB();
                    break;
                case ListType.AdjustPurchaseVouchers:
                    AdjustPurchaseVouchers();
                    break;

                case ListType.AdjustSalesVouchers:
                    AdjustSalesVouchers();
                    break;
                case ListType.Waiter:
                    Waiter();
                    break;
            }
        }

        public void PickListTextBox_GotFocus(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.NavajoWhite;
        }

        private void PickListTextBox_LostFocus(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.White;
        }

        private void Vouchers()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Adj.Vouchers", "Voucher List", searchKey);
            //if (frm.SearchDT.Rows.Count < 1)
            //{
            //    MessageBox.Show("No list available in reference voucher list.", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["VNo"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["VNo"].ToString();
            //    this.Value = frm.SelectedList[0]["VNo"].ToString();
            //    this.vDate = Convert.ToDateTime(frm.SelectedList[0]["M_Date"].ToString());
            //    this.vAmount = Convert.ToDecimal(frm.SelectedList[0]["BalAmt"].ToString());
            //    this.vSource = frm.SelectedList[0]["V_Source"].ToString();
            //    this.vSerial = frm.SelectedList[0]["sno"].ToString();

            //}
            //else
            //{
            //    this.Value = "";
            //    this.vAmount = 0;
            //    this.vSource = "";
            //    this.vSerial = "";
            //}
            //frm.SearchDT.Rows.Clear();
            //frm.Dispose();
        }
        private void VouchersPB()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Adj.VouchersPB", "Voucher List", searchKey);
            //if (frm.SearchDT.Rows.Count < 1)
            //{
            //    MessageBox.Show("No list available in reference voucher list.", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["VNo"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["VNo"].ToString();
            //    this.Value = frm.SelectedList[0]["VNo"].ToString();
            //    this.vDate = Convert.ToDateTime(frm.SelectedList[0]["M_Date"].ToString());
            //    this.vAmount = Convert.ToDecimal(frm.SelectedList[0]["BalAmt"].ToString());
            //    this.vSource = frm.SelectedList[0]["V_Source"].ToString();
            //    this.vSerial = frm.SelectedList[0]["sno"].ToString();
            //}
            //else
            //{
            //    this.Value = "";
            //    this.vAmount = 0;
            //    this.vSource = "";
            //    this.vSerial = "";
            //}
            //frm.SearchDT.Rows.Clear();
            //frm.Dispose();
        }


        private void AdjustPurchaseVouchers()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Adj.PurchaseVouchers", "Voucher List", searchKey);
            //if (frm.SearchDT.Rows.Count < 1)
            //{
            //    MessageBox.Show("No list available in reference voucher list.", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["VNo"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["VNo"].ToString();
            //    this.Value = frm.SelectedList[0]["VNo"].ToString();
            //    this.vDate = Convert.ToDateTime(frm.SelectedList[0]["M_Date"].ToString());
            //    this.vAmount = Convert.ToDecimal(frm.SelectedList[0]["BalAmt"].ToString());
            //    this.vSource = frm.SelectedList[0]["V_Source"].ToString();
            //    this.vSerial = frm.SelectedList[0]["sno"].ToString();
            //}
            //else
            //{
            //    this.Value = "";
            //    this.vAmount = 0;
            //    this.vSource = "";
            //    this.vSerial = "";
            //}
            //frm.SearchDT.Rows.Clear();
            //frm.Dispose();
        }
        private void AdjustSalesVouchers()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Adj.SalesVouchers", "Voucher List", searchKey);
            //if (frm.SearchDT.Rows.Count < 1)
            //{
            //    MessageBox.Show("No list available in reference voucher list.", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["VNo"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["VNo"].ToString();
            //    this.Value = frm.SelectedList[0]["VNo"].ToString();
            //    this.vDate = Convert.ToDateTime(frm.SelectedList[0]["M_Date"].ToString());
            //    this.vAmount = Convert.ToDecimal(frm.SelectedList[0]["BalAmt"].ToString());
            //    this.vSource = frm.SelectedList[0]["V_Source"].ToString();
            //}
            //else
            //{
            //    this.Value = "";
            //    this.vAmount = 0;
            //    this.vSource = "";
            //    this.vSerial = "";
            //}
            //frm.SearchDT.Rows.Clear();
            //frm.Dispose();
        }
        private void GeneralLedgerForOB()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Opening.Ledger", "Opening Ledger List", searchKey);
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["GL_Desc"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["GL_Desc"].ToString();
            //    this.Value = frm.SelectedList[0]["GL_Desc"].ToString();
            //}
            //frm.Dispose();
        }
        private void GeneralLedgerForOL()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Opening.Ledger", "Opening Ledger List", searchKey);
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["GL_Desc"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["GL_Desc"].ToString();
            //    this.Value = frm.SelectedList[0]["GL_Desc"].ToString();
            //}
            //frm.Dispose();
        }
        public void CostCenter()
        {
            Common.PickList frm = new Common.PickList("CostCenter", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                Text = frm.SelectedList[0]["CostCenterDesc"].ToString();
                Tag = frm.SelectedList[0]["CostCenterId"].ToString();
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available for CostCenter !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Focus();
                return;
            }
        }

        public void AddSalesBillTerm()
        {
           
        }

        public void AddPurchaseBillTerm()
        {
           
        }
        public void GeneralLedger()
        {
            if (!string.IsNullOrEmpty(ClsGlobal.FilterGlCategory))
                ClsGlobal.FilterGlCategory = "." + ClsGlobal.FilterGlCategory;
            Common.PickList frm = new Common.PickList("Generalledger" + ClsGlobal.FilterGlCategory, searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                Text = frm.SelectedList[0]["GlDesc"].ToString();
                Tag = frm.SelectedList[0]["LedgerId"].ToString();

                GlTaggedSalesmanName = "";
                GlTaggedSalesmanCode = "";
            }
            frm.Dispose();
        }
        public void GeneralLedgerForDRCR()
        {
        }
        public void GeneralLedgerForJV()
        {
            
        }
        public void ProductForPhysStock()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("ProductforPhysStock", "Product List", searchKey);
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    decimal srate = 0;
            //    decimal.TryParse(frm.SelectedList[0]["Sales_Rate"].ToString(), out srate);
            //    this.Text = frm.SelectedList[0]["P_Desc"].ToString();
            //    isF1 = true;
            //    currentData = frm.SelectedList[0]["P_Desc"].ToString();
            //    if (string.IsNullOrEmpty(previousData))
            //        previousData = currentData;
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["P_ShortName"].ToString();
            //    this.Value = frm.SelectedList[0]["P_ShortName"].ToString();
            //    this.Unit = frm.SelectedList[0]["Unit"].ToString();
            //    if (this.AltUnit != null) this.AltUnit = frm.SelectedList[0]["AltUnit"].ToString();
            //    decimal stockqty = 0;
            //    decimal.TryParse(frm.SelectedList[0]["StockQty"].ToString(), out stockqty);
            //    this.StockQty.Text = clsGlobal.DecimalFormate(stockqty, 1, clsGlobal._Format_Qty);
            //    this.SalesRate = srate;

            //    if (!string.IsNullOrEmpty(clsGlobal.BranchCode))
            //    {
            //        //DataTable dt = clsGlobal.FetchDataTable("SELECT sum(Case when Transaction_Type = 'I' then  StockQty else  - StockQty end) as Qty ,Br_code,sum(Case when Transaction_Type = 'I' then  AltStockQty else  - AltStockQty end) as AltQty,Product.AltUnit,Product.Unit FROM Stock_Transaction,Product WHERE P_Code=ProductCode AND P_Desc='" + frm.SelectedList[0]["P_Desc"].ToString() + "' and v_date <= '" + clsGlobal.TodayDate.ToString("MM/dd/yyyy") + "' and Br_Code='" + clsGlobal.BranchCode + "' group by Product.AltUnit,Product.Unit,Br_Code");
            //        //if (dt.Rows.Count > 0)
            //        //{
            //        //    this.StockQty.Text = Convert.ToDecimal(dt.Rows[0]["Qty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["Unit"].ToString();
            //        //    this.AltStockQty.Text = Convert.ToDecimal(dt.Rows[0]["AltQty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["AltUnit"].ToString();
            //        //}
            //        //else
            //        //{
            //        //    this.StockQty.Text = "0.000";
            //        //    this.AltStockQty.Text = "0.000";
            //        //}
            //    }
            //    else
            //    {
            //        DataTable dt = clsGlobal.FetchDataTable("SELECT sum(Case when Transaction_Type = 'I' then  StockQty else  - StockQty end) as Qty ,Br_code,sum(Case when Transaction_Type = 'I' then  AltStockQty else  - AltStockQty end) as AltQty,Product.AltUnit,Product.Unit FROM Stock_Transaction,Product WHERE P_Code=ProductCode AND Br_Code is null AND P_Desc='" + frm.SelectedList[0]["P_Desc"].ToString() + "' and v_date <= '" + clsGlobal.TodayDate.ToString("MM/dd/yyyy") + "' group by Product.AltUnit,Product.Unit,Br_Code");
            //        if (dt.Rows.Count > 0)
            //        {
            //            //this.StockQty.Text = Convert.ToDecimal(dt.Rows[0]["Qty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["Unit"].ToString();
            //            //this.AltStockQty.Text = Convert.ToDecimal(dt.Rows[0]["AltQty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["AltUnit"].ToString();
            //        }
            //        else
            //        {
            //            //this.StockQty.Text = "0.000";
            //            //this.AltStockQty.Text = "0.000";
            //        }
            //    }
            //}
            //frm.Dispose();
        }
       
        public void Product()
        {
            Common.PickList frm = new Common.PickList("Product", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                ProductDetails.Clear();
                this.Text = frm.SelectedList[0]["ProductDesc"].ToString();
                this.Tag = frm.SelectedList[0]["ProductId"].ToString();
                this.ProductShortName = frm.SelectedList[0]["ProductShortName"].ToString();
                this.ProductQtyConversion = frm.SelectedList[0]["QtyConv"].ToString();
                this.AltConversion = Convert.ToDecimal(frm.SelectedList[0]["AltConv"].ToString());
                ProductDetails.Add("ProductShortName", frm.SelectedList[0]["ProductShortName"].ToString());
                ProductDetails.Add("ProductAltUnitId", frm.SelectedList[0]["ProductAltUnitId"].ToString());
                ProductDetails.Add("ProductAltUnit", frm.SelectedList[0]["ProductAltUnit"].ToString());
                ProductDetails.Add("ProductUnitId", frm.SelectedList[0]["ProductUnitId"].ToString());
                ProductDetails.Add("ProductUnit", frm.SelectedList[0]["ProductUnit"].ToString());
                ProductDetails.Add("SalesRate", frm.SelectedList[0]["SalesRate"].ToString());
                ProductDetails.Add("BuyRate", frm.SelectedList[0]["BuyRate"].ToString());
                ProductDetails.Add("QtyConv", frm.SelectedList[0]["QtyConv"].ToString());
                ProductDetails.Add("AltStockQty", frm.SelectedList[0]["AltStockQty"].ToString());
                ProductDetails.Add("StockQty", frm.SelectedList[0]["StockQty"].ToString());
            }
            frm.Dispose();
        }
        public void ProductScheme()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Product", "Product List", searchKey);
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    decimal srate = 0;
            //    decimal.TryParse(frm.SelectedList[0]["Sales_Rate"].ToString(), out srate);
            //    this.Text = frm.SelectedList[0]["P_Desc"].ToString();
            //    decimal brate = 0;
            //    decimal.TryParse(frm.SelectedList[0]["Buy_Rate"].ToString(), out brate);
            //    isF1 = true;
            //    currentData = frm.SelectedList[0]["P_Desc"].ToString();
            //    if (string.IsNullOrEmpty(previousData))
            //        previousData = currentData;
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["P_ShortName"].ToString();
            //    this.Value = frm.SelectedList[0]["P_ShortName"].ToString();
            //    //this.Unit = frm.SelectedList[0]["Unit"].ToString();
            //    //this.AltUnit = frm.SelectedList[0]["AltUnit"].ToString();

            //    //decimal stockqty = 0;
            //    //decimal.TryParse(frm.SelectedList[0]["StockQty"].ToString(), out stockqty);
            //    //this.StockQty.Text = clsGlobal.DecimalFormate(stockqty, 1, clsGlobal._Format_Qty).ToString();
            //    this.SalesRate = srate;
            //    this.BuyRate = brate;

            //    if (!string.IsNullOrEmpty(clsGlobal.BranchCode))
            //    {
            //        //DataTable dt = clsGlobal.FetchDataTable("SELECT sum(Case when Transaction_Type = 'I' then  StockQty else  - StockQty end) as Qty ,Br_code,sum(Case when Transaction_Type = 'I' then  AltStockQty else  - AltStockQty end) as AltQty,Product.AltUnit,Product.Unit FROM Stock_Transaction,Product WHERE P_Code=ProductCode AND P_Desc='" + frm.SelectedList[0]["P_Desc"].ToString() + "' and v_date <= '" + clsGlobal.TodayDate.ToString("MM/dd/yyyy") + "' and Br_Code='" + clsGlobal.BranchCode + "' group by Product.AltUnit,Product.Unit,Br_Code");
            //        //if (dt.Rows.Count > 0)
            //        //{
            //        //    this.StockQty.Text = Convert.ToDecimal(dt.Rows[0]["Qty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["Unit"].ToString();
            //        //    this.AltStockQty.Text = Convert.ToDecimal(dt.Rows[0]["AltQty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["AltUnit"].ToString();
            //        //}
            //        //else
            //        //{
            //        //    this.StockQty.Text = "0.000";
            //        //    this.AltStockQty.Text = "0.000";
            //        //}
            //    }
            //    else
            //    {
            //        DataTable dt = clsGlobal.FetchDataTable("SELECT sum(Case when Transaction_Type = 'I' then  StockQty else  - StockQty end) as Qty ,Br_code,sum(Case when Transaction_Type = 'I' then  AltStockQty else  - AltStockQty end) as AltQty,Product.AltUnit,Product.Unit FROM Stock_Transaction,Product WHERE P_Code=ProductCode AND Br_Code is null AND P_Desc='" + frm.SelectedList[0]["P_Desc"].ToString() + "' and v_date <= '" + clsGlobal.TodayDate.ToString("MM/dd/yyyy") + "' group by Product.AltUnit,Product.Unit,Br_Code");
            //        if (dt.Rows.Count > 0)
            //        {
            //            //this.StockQty.Text = Convert.ToDecimal(dt.Rows[0]["Qty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["Unit"].ToString();
            //            //this.AltStockQty.Text = Convert.ToDecimal(dt.Rows[0]["AltQty"].ToString()).ToString("0.000") + ' ' + dt.Rows[0]["AltUnit"].ToString();
            //        }
            //        else
            //        {
            //            //this.StockQty.Text = "0.000";
            //            //this.AltStockQty.Text = "0.000";
            //        }
            //    }
            //}
            //frm.Dispose();
        }
        public void Group()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Product.Group", "Product Group List", searchKey);
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    //decimal srate = 0;
            //    //decimal.TryParse(frm.SelectedList[0]["Sales_Rate"].ToString(), out srate);
            //    this.Text = frm.SelectedList[0]["Pr_GrpDesc"].ToString();
            //    //decimal brate = 0;
            //    //decimal.TryParse(frm.SelectedList[0]["Buy_Rate"].ToString(), out brate);
            //    isF1 = true;
            //    currentData = frm.SelectedList[0]["Pr_GrpDesc"].ToString();
            //    if (string.IsNullOrEmpty(previousData))
            //        previousData = currentData;
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["Pr_GrpShortName"].ToString();
            //    this.Value = frm.SelectedList[0]["Pr_GrpShortName"].ToString();
            //    //this.Unit = frm.SelectedList[0]["Unit"].ToString();
            //    //this.AltUnit = frm.SelectedList[0]["AltUnit"].ToString();

            //    //decimal stockqty = 0;
            //    //decimal.TryParse(frm.SelectedList[0]["StockQty"].ToString(), out stockqty);
            //    //this.StockQty.Text = clsGlobal.DecimalFormate(stockqty, 1, clsGlobal._Format_Qty).ToString();
            //    //this.SalesRate = srate;
            //    //this.BuyRate = brate;


            //}
            //frm.Dispose();
        }
        public void Currency()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Others.Currency", "Currency List", searchKey);
            //if (frmSearch.dt.Rows.Count > 0)
            //{
            //    frm.ShowDialog();
            //    if (frm.SelectedList.Count > 0)
            //    {
            //        this.Text = frm.SelectedList[0]["Cur_Desc"].ToString();
            //        isF1 = true;
            //        currentData = frm.SelectedList[0]["Cur_Desc"].ToString();
            //        if (string.IsNullOrEmpty(previousData))
            //            previousData = currentData;
            //        if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["Cur_ShortName"].ToString();
            //        this.Value = frm.SelectedList[0]["Cur_ShortName"].ToString();
            //    }
            //    frm.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("No List Available for Currency !", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Focus();
            //    return;
            //}
        }
        public void SubLedger()
        {
            //SwastikPOS.Util.frmSearch frm = new frmSearch("Ledger.SubLedger", "Sub Ledger List", searchKey);
            //if (frmSearch.dt.Rows.Count > 0)
            //{
            //    frm.ShowDialog();
            //    if (frm.SelectedList.Count > 0)
            //    {
            //        this.Text = frm.SelectedList[0]["Sl_Desc"].ToString();
            //        if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["Sl_ShortName"].ToString();
            //        this.Value = frm.SelectedList[0]["Sl_ShortName"].ToString();
            //    }
            //    frm.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("No List Available for Sub Ledger !", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Focus();
            //    return;
            //}
        }
        public void Salesman()
        {
            Common.PickList frm = new Common.PickList("SalesMan", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                Text = frm.SelectedList[0]["SalesmanDesc"].ToString();
                Tag = frm.SelectedList[0]["SalesmanId"].ToString();
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available for Salesman !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Focus();
                return;
            }
        }
        public void Narration()
        {
            Common.PickList frm = new Common.PickList("Narration", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                Text = frm.SelectedList[0]["NarrationDesc"].ToString();
                Tag = frm.SelectedList[0]["NarrationId"].ToString();
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available for Narration !", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Focus();
                return;
            }
        }
        public void Godown()
        {
            Common.PickList frm = new Common.PickList("Godown", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                Text = frm.SelectedList[0]["GodownDesc"].ToString();
                Tag = frm.SelectedList[0]["GodownId"].ToString();
                frm.Dispose();
            }
            //else
            //{
            //    if (frm._searchKey != "27")
            //    {
            //        MessageBox.Show("No List Available for Godown !", "Swastik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Focus();
            //        return;
            //    }
            //}
        }
        public void ProductUnit()
        {
            Common.PickList frm = new Common.PickList("ProductUnit", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                Text = frm.SelectedList[0]["ProductUnitDesc"].ToString();
                Tag = frm.SelectedList[0]["ProductUnitId"].ToString();
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available for Product Unit !", "ACME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Focus();
                return;
            }
        }
        public void Department()
        {
            if (searchKey == "Escape") searchKey = "";
            IDepartment _objDepartment = new ClsDepartment();
            DataTable dt = _objDepartment.DepartmentLevel();
            if (dt.Rows.Count > 0)
            {
                DataRow[] result1 = dt.Select("Departmentlevel = 'I'");
                if (result1.Length > 0)
                {
                    Common.PickList frmPickList = new Common.PickList("DepartmentI", searchKey);
                    frmPickList.ShowDialog();
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        Text = frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        Tag = Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        Text = "";
                        Tag = "";
                    }
                    frmPickList.Dispose();
                }

                DataRow[] result2 = dt.Select("Departmentlevel = 'II'");
                if (result2.Length > 0)
                {
                    searchKey = "";
                    Common.PickList frmPickList = new Common.PickList("DepartmentII", searchKey);
                    frmPickList.ShowDialog();
                    Text = Text.Trim() + '|';
                    Tag = Tag.ToString().Trim() + '|';
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        Text = Text + frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        Tag = Tag.ToString() + Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        string[] _arr1 = Text.Split('|');
                        string[] _arr2 = Tag.ToString().Split('|');
                        Text = _arr1[0] + "|";
                        Tag = _arr2[0] + "|";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    string[] _arr1 = Text.Split('|');
                    string[] _arr2 = Tag.ToString().Split('|');
                    Text = _arr1[0] + "|";
                    Tag = _arr2[0] + "|";
                }

                DataRow[] result3 = dt.Select("Departmentlevel = 'III'");
                if (result3.Length > 0)
                {
                    searchKey = "";
                    Common.PickList frmPickList = new Common.PickList("DepartmentIII", searchKey);
                    frmPickList.ShowDialog();
                    Text = Text.Trim() + '|';
                    Tag = Tag.ToString().Trim() + '|';
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        Text = Text + frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        Tag = Tag.ToString() + Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        string[] _arr1 = Text.Split('|');
                        string[] _arr2 = Tag.ToString().Split('|');
                        Text = _arr1[0] + "|" + _arr1[1] + "|";
                        Tag = _arr2[0] + "|" + _arr2[1] + "|";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    string[] _arr1 = Text.Split('|');
                    string[] _arr2 = Tag.ToString().Split('|');
                    Text = _arr1[0] + "|" + _arr1[1] + "|";
                    Tag = _arr2[0] + "|" + _arr2[1] + "|";
                }

                DataRow[] result4 = dt.Select("Departmentlevel = 'IV'");
                if (result4.Length > 0)
                {
                    searchKey = "";
                    Common.PickList frmPickList = new Common.PickList("DepartmentIV", searchKey);
                    frmPickList.ShowDialog();
                    Text = Text.Trim() + '|';
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        Text = Text + frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        Tag = Tag.ToString() + Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        string[] _arr1 = Text.Split('|');
                        string[] _arr2 = Tag.ToString().Split('|');
                        Text = _arr1[0] + "|" + _arr1[1] + "|" + _arr1[2] + "|";
                        Tag = _arr2[0] + "|" + _arr2[1] + "|" + _arr2[2] + "|";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    string[] _arr1 = Text.Split('|');
                    string[] _arr2 = Tag.ToString().Split('|');
                    Text = _arr1[0] + "|" + _arr1[1] + "|" + _arr1[2] + "|";
                    Tag = _arr2[0] + "|" + _arr2[1] + "|" + _arr2[2] + "|";
                }
            }
        }

        public void SalesBatch()
        {
            //clsGlobal.P_Code = P_code;
            //clsGlobal.BillDate = clsGlobal.TodayDate;
            //SwastikPOS.Util.frmSearch frm = new SwastikPOS.Util.frmSearch("Sales.Batch", "Product Serial Number", searchKey);
            //frm.ShowDialog();

            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["Serial_No"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["Serial_No"].ToString();
            //    this.Qty = Convert.ToDecimal(frm.SelectedList[0]["Qty"].ToString());
            //    this.AltQty = Convert.ToDecimal(frm.SelectedList[0]["AltQty"].ToString());
            //    this.AdjustVoucher = frm.SelectedList[0]["AdjustVoucher"].ToString();
            //    this.AdjustIndex = Convert.ToInt32(frm.SelectedList[0]["Pro_Index"].ToString());
            //    //this.BalanceQty = Convert.ToInt32(frm.SelectedList[0]["Balance"].ToString());

            //    //SendKeys.Send("{Tab}");
            //}
            //frm.Dispose();
        }

        public void SalesRefOrderNo()
        {
            //SwastikPOS.Util.frmSearch frm = new SwastikPOS.Util.frmSearch("Entry.RefOrderNo", "RefOrder List", searchKey);
            //frm.ShowDialog();
            //if (frm.SelectedList.Count > 0)
            //{
            //    this.Text = frm.SelectedList[0]["Sb_OrderNo"].ToString();
            //    if (this.txtValue != null) this.txtValue.Text = frm.SelectedList[0]["Sb_OrderNo"].ToString();
            //    this.Value = frm.SelectedList[0]["Sb_OrderNo"].ToString();
            //    //SendKeys.Send("{Tab}");
            //}
            //frm.Dispose();
        }

        public void Waiter()
        {
            Common.PickList frmPickList = new Common.PickList("Waiter", searchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    Text = frmPickList.SelectedList[0]["UserCode"].ToString().Trim();
                    Tag = frmPickList.SelectedList[0]["UserCode"].ToString().Trim();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Waiter ...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Focus();
                return;
            }
        }
    }
}