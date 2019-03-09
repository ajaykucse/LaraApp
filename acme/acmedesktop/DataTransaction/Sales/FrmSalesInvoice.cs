﻿using acmedesktop.Common;
using acmedesktop.MasterSetup;
using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.MasterSetup;
using DataAccessLayer.SystemSetting;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.Sales
{
    public partial class FrmSalesInvoice : Form
    {
        MyGridPickListTextBox TxtGridParticular;
        MyGridPickListTextBox TxtGridGodown;
        MyGridNumericTextBox TxtGridAltQty;
        MyGridPickListTextBox TxtGridAltUOM;
        MyGridNumericTextBox TxtGridQty;
        MyGridPickListTextBox TxtGridQtyUOM;
        MyGridNumericTextBox TxtGridRate;
        MyGridNumericTextBox TxtGridBasicAmt;
        MyGridNumericTextBox TxtGridTermsAmt;
        MyGridNumericTextBox TxtGridNetAmt;
        MyGridTextBox TxtGridTermsDetails;

        ISalesInvoice _objSalesInvoice = new ClsSalesInvoice();
		private ISalesOrder _objSalesOrder = new ClsSalesOrder();
		private ISalesChallan _objSalesChallan = new ClsSalesChallan();
		ISalesBillingTerm _objSalesBillingTerm = new ClsSalesBillingTerm();
        ClsGeneralLedger _objLedger = new ClsGeneralLedger();
        IGodown _objGodown = new ClsGodown();
        IProductScheme _objScheme = new ClsProductScheme();
        ClsCommon _objCommon = new ClsCommon();
        ClsDateMiti _objDate = new ClsDateMiti();
        IUdfMaster _objUDF = new ClsUdfMaster();
        IGeneralLedger _objGeneralLedger = new ClsGeneralLedger();
        IDocPrintSetting _objDocPrintSetting = new ClsDocPrintSetting();
        int _IsSaveAndPrint = 0; int Indexcount;
        string _Tag = "", _dtBillTermExists = "", _dtProductTermExists = "", _VoucherNo = "", _SearchKey = "", _GlCategory = "";
        string _ChallanNo = "";
        Boolean _StartTermCalculation = false, _isSubledgerRequired = false;
        Boolean _GridControlMode { get; set; }

        DataTable DTUDFDetails = new DataTable();
        DataTable DtUDFMaster = new DataTable();
        int _DocId = 0;
        public FrmSalesInvoice()
        {
            InitializeComponent();
            TxtGridParticular = new MyGridPickListTextBox(Grid);
            TxtGridParticular.Validating += new System.ComponentModel.CancelEventHandler(TxtGridParticular_Validating);
            TxtGridParticular.PickListType = MyGridPickListTextBox.ListType.Product;

            TxtGridGodown = new MyGridPickListTextBox(Grid);
            TxtGridGodown.Validating += new System.ComponentModel.CancelEventHandler(TxtGridGodown_Validating);
            TxtGridGodown.PickListType = MyGridPickListTextBox.ListType.GoDown;

            TxtGridAltQty = new MyGridNumericTextBox(Grid);
            TxtGridAltQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridAltQty_Validating);
            TxtGridAltQty.TextChanged += new System.EventHandler(TxtGridAltQty_TextChanged);

            TxtGridAltUOM = new MyGridPickListTextBox(Grid);
            TxtGridAltUOM.PickListType = MyGridPickListTextBox.ListType.ProductUnit;
            // TxtGridGodown.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridGodown_Validating);

            TxtGridQty = new MyGridNumericTextBox(Grid);
            TxtGridQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridQty_Validating);
            TxtGridQty.TextChanged += new System.EventHandler(TxtGridQty_TextChanged);
            TxtGridQtyUOM = new MyGridPickListTextBox(Grid);
            TxtGridQtyUOM.PickListType = MyGridPickListTextBox.ListType.ProductUnit;

            TxtGridRate = new MyGridNumericTextBox(Grid);
            TxtGridRate.Validating += new System.ComponentModel.CancelEventHandler(TxtGridRate_Validating);
            TxtGridRate.TextChanged += new System.EventHandler(TxtGridRate_TextChanged);
            TxtGridRate.ReadOnly = ClsGlobal.AccessSalesRateChange == 1 ? false : true;

            TxtGridBasicAmt = new MyGridNumericTextBox(Grid);
            TxtGridBasicAmt.Validating += new System.ComponentModel.CancelEventHandler(TxtGridBasicAmt_Validating);

            TxtGridTermsAmt = new MyGridNumericTextBox(Grid);
            TxtGridTermsAmt.ReadOnly = true;
            TxtGridTermsAmt.TabStop = false;

            TxtGridNetAmt = new MyGridNumericTextBox(Grid);
            TxtGridNetAmt.Validating += new System.ComponentModel.CancelEventHandler(TxtGridNetAmt_Validating);
            TxtGridNetAmt.ReadOnly = true;

            TxtGridTermsDetails = new MyGridTextBox(Grid);
            TxtGridTermsDetails.Visible = false;

            GridControlMode(false);
            _GridControlMode = true;

            Utility.EnableDesibleColor(TxtGridTermsAmt, false);
            Utility.EnableDesibleColor(TxtGridNetAmt, false);

            // ------------------- UDF ----------------------
            ClsGlobal.UDFExistingDataTableDetails.Reset();

            ClsGlobal.UDFExistingDataTableDetails.Columns.Add(new DataColumn("SNO", typeof(string)));
            DTUDFDetails = _objUDF.GetCodeByEntryModule("Sales Details Global");
            foreach (DataRow ro in DTUDFDetails.Rows)
            {
                ClsGlobal.UDFExistingDataTableDetails.Columns.Add(new DataColumn("UDFCode" + ro["UDFCode"].ToString(), typeof(string)));
                ClsGlobal.UDFExistingDataTableDetails.Columns.Add(new DataColumn("UDFData" + ro["UDFCode"].ToString(), typeof(string)));
            }

            ClsGlobal.UDFExistingDataMaster.Reset();
            ClsGlobal.UDFExistingDataMaster.Columns.Add(new DataColumn("SNO", typeof(string)));
            DtUDFMaster = _objUDF.GetCodeByEntryModule("Sales Master Global");
            BtnUDF.Enabled = DtUDFMaster.Rows.Count > 0 ? true : false;
            foreach (DataRow ro in DtUDFMaster.Rows)
            {
                ClsGlobal.UDFExistingDataMaster.Columns.Add(new DataColumn("UDFCode" + ro["UDFCode"].ToString(), typeof(string)));
                ClsGlobal.UDFExistingDataMaster.Columns.Add(new DataColumn("UDFData" + ro["UDFCode"].ToString(), typeof(string)));
            }
            // ------------------- END UDF ----------------------
            TxtGridBasicAmt.ReadOnly = ClsGlobal.SalesChangeBasicAmountControlVal == 'N' ? true : false;

            _IsSaveAndPrint = _objDocPrintSetting.CheckIsSaveAndPrint("SB");
        }
        private void FrmSalesInvoice_Load(object sender, EventArgs e)
        {
            _dtProductTermExists = _objSalesBillingTerm.CheckTermExists(ClsGlobal.BranchId, "N");
            _dtBillTermExists = _objSalesBillingTerm.CheckTermExists(ClsGlobal.BranchId, "Y");
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();
        }
        public void ControlEnableDisable(bool btn, bool fld)
        {
            BtnNew.Enabled = btn;
            BtnEdit.Enabled = btn;
            BtnDelete.Enabled = btn;
            BtnExit.Enabled = btn;
            BtnCopy.Enabled = btn;
            BtnPrint.Enabled = btn;
            BtnFirstData.Enabled = btn;
            BtnNextData.Enabled = btn;
            BtnPreviousData.Enabled = btn;
            BtnLastData.Enabled = btn;
            if (BtnNew.Enabled == true) { BtnNew.Focus(); }
            TxtVoucherNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtVoucherNo, fld);
            BtnVoucherNoSearch.Enabled = fld;
            TxtMiti.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtMiti, fld);
            TxtDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtDate, fld);
            TxtChallanNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtChallanNo, fld);
            BtnChallanNoSearch.Enabled = fld;
            TxtOrderNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtOrderNo, fld);
            BtnOrderNoSearch.Enabled = fld;

            TxtCustomer.Enabled = fld;
            Utility.EnableDesibleColor(TxtCustomer, fld);
            BtnCustomerNameSearch.Enabled = fld;

            TxtDueDays.Enabled = fld;
            Utility.EnableDesibleColor(TxtDueDays, fld);

            TxtSalesman.Enabled = fld;
            Utility.EnableDesibleColor(TxtSalesman, fld);
            BtnSalesmanSearch.Enabled = fld;

            TxtDepartment.Enabled = fld;
            Utility.EnableDesibleColor(TxtDepartment, fld);
            BtnDepartmentSearch.Enabled = fld;

            TxtSubledger.Enabled = fld;
            Utility.EnableDesibleColor(TxtSubledger, fld);
            BtnSubledgerSearch.Enabled = fld;

            TxtCurrency.Enabled = fld;
            Utility.EnableDesibleColor(TxtCurrency, fld);
            BtnCurrencySearch.Enabled = fld;

            TxtCurrencyRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtCurrencyRate, fld);

            TxtRemarks.Enabled = fld;
            Utility.EnableDesibleColor(TxtRemarks, fld);

            CmbInvoiceType.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbInvoiceType, fld);
			//------------Other Details and Billing Address Controls---
		
			TxtTransport.Enabled = fld;
			Utility.EnableDesibleColor(TxtTransport, fld);
			TxtVehicleNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtVehicleNo, fld);
			TxtPackage.Enabled = fld;
			Utility.EnableDesibleColor(TxtPackage, fld);
			TxtCnNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtCnNo, fld);
			TxtCnFreight.Enabled = fld;
			Utility.EnableDesibleColor(TxtCnFreight, fld);
			CmbCnType.Enabled = fld;
			Utility.EnableDesibleComboBoxColor(CmbCnType, fld);
			TxtAdvance.Enabled = fld;
			Utility.EnableDesibleColor(TxtAdvance, fld);
			TxtBalFreight.Enabled = fld;
			Utility.EnableDesibleColor(TxtBalFreight, fld);
			TxtDriverLicenseNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtDriverLicenseNo, fld);

			TxtCnDate.Enabled = fld;
			Utility.EnableDesibleDateColor(TxtCnDate, fld);
			TxtContactDate.Enabled = fld;
			Utility.EnableDesibleDateColor(TxtContactDate, fld);
			TxtPODate.Enabled = fld;
			Utility.EnableDesibleDateColor(TxtPODate, fld);
			TxtExportInvDate.Enabled = fld;
			Utility.EnableDesibleDateColor(TxtExportInvDate, fld);

			TxtDriverName.Enabled = fld;
			Utility.EnableDesibleColor(TxtDriverName, fld);
			TxtDriverMobileNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtDriverMobileNo, fld);
			TxtContactNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtContactNo, fld);
			TxtExportInvNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtExportInvNo, fld);
			TxtPONo.Enabled = fld;
			Utility.EnableDesibleColor(TxtPONo, fld);
			TxtDocBank.Enabled = fld;
			Utility.EnableDesibleColor(TxtDocBank, fld);
			TxtLCNo.Enabled = fld;
			Utility.EnableDesibleColor(TxtLCNo, fld);
			TxtCustomerName.Enabled = fld;
			Utility.EnableDesibleColor(TxtCustomerName, fld);
			TxtCoFd.Enabled = fld;
			Utility.EnableDesibleColor(TxtCoFd, fld);

			TxtBillingAddress.Enabled = fld;
			Utility.EnableDesibleColor(TxtBillingAddress, fld);
			TxtBillingCity.Enabled = fld;
			Utility.EnableDesibleColor(TxtBillingCity, fld);
			TxtBillingState.Enabled = fld;
			Utility.EnableDesibleColor(TxtBillingState, fld);
			TxtBillingCountry.Enabled = fld;
			Utility.EnableDesibleColor(TxtBillingCountry, fld);
			TxtBillingEmail.Enabled = fld;
			Utility.EnableDesibleColor(TxtBillingEmail, fld);
			TxtShippingAddress.Enabled = fld;
			Utility.EnableDesibleColor(TxtShippingAddress, fld);
			TxtShippingCity.Enabled = fld;
			Utility.EnableDesibleColor(TxtShippingCity, fld);
			TxtShippingState.Enabled = fld;
			Utility.EnableDesibleColor(TxtShippingState, fld);
			TxtShippingCountry.Enabled = fld;
			Utility.EnableDesibleColor(TxtShippingCountry, fld);
			TxtShippingEmail.Enabled = fld;
			Utility.EnableDesibleColor(TxtShippingEmail, fld);
						
			//---------------------

			BtnOk.Enabled = fld;
            BtnCancel.Enabled = fld;

            Grid.Enabled = true;

            if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
            {
                if (ClsGlobal.SalesVoucherDateControlVal == 'Y')
                {
                    TxtMiti.Enabled = true;
                    Utility.EnableDesibleDateColor(TxtMiti, true);
                    TxtDate.Enabled = true;
                    Utility.EnableDesibleDateColor(TxtDate, true);
                }
                else
                {
                    TxtMiti.Enabled = false;
                    Utility.EnableDesibleDateColor(TxtMiti, false);
                    TxtDate.Enabled = false;
                    Utility.EnableDesibleDateColor(TxtDate, false);
                }
                if (ClsGlobal.SalesChallanControlVal == 'Y')
                {
                    TxtChallanNo.Enabled = true;
                    TxtChallanNo.BackColor = Color.White;
                    BtnChallanNoSearch.Enabled = true;
                }
                else
                {
                    TxtChallanNo.Enabled = false;
                    TxtChallanNo.BackColor = SystemColors.Control;
                    BtnChallanNoSearch.Enabled = false;
                }
                if (ClsGlobal.SalesOrderControlVal == 'Y')
                {
                    TxtOrderNo.Enabled = true;
                    TxtOrderNo.BackColor = Color.White;
                    BtnOrderNoSearch.Enabled = true;
                }
                else
                {
                    TxtOrderNo.Enabled = false;
                    TxtOrderNo.BackColor = SystemColors.Control;
                    BtnOrderNoSearch.Enabled = false;
                }

                if (ClsGlobal.SalesCurrencyControlVal == 'Y')
                {
                    TxtCurrency.Enabled = true;
                    Utility.EnableDesibleColor(TxtCurrency, true);
                    BtnCurrencySearch.Enabled = true;
                    TxtCurrencyRate.Enabled = true;
                    Utility.EnableDesibleColor(TxtCurrencyRate, true);
                }
                else
                {
                    TxtCurrency.Enabled = false;
                    Utility.EnableDesibleColor(TxtCurrency, false);
                    BtnCurrencySearch.Enabled = false;
                    TxtCurrencyRate.Enabled = false;
                    Utility.EnableDesibleColor(TxtCurrencyRate, false);
                }

                if (ClsGlobal.SalesSalesmanControlVal == 'Y')
                {
                    TxtSalesman.Enabled = true;
                    TxtSalesman.BackColor = Color.White;
                    BtnSalesmanSearch.Enabled = true;
                }
                else
                {
                    TxtSalesman.Enabled = false;
                    TxtSalesman.BackColor = SystemColors.Control;
                    BtnSalesmanSearch.Enabled = false;
                }

                if (ClsGlobal.SalesSubledgerControlVal == 'Y')
                {
                    TxtSubledger.Enabled = true;
                    TxtSubledger.BackColor = Color.White;
                    BtnSubledgerSearch.Enabled = true;
                }
                else
                {
                    TxtSubledger.Enabled = false;
                    TxtSubledger.BackColor = SystemColors.Control;
                    BtnSubledgerSearch.Enabled = false;
                }

                if (ClsGlobal.SalesDepartmentControlVal == 'Y')
                {
                    TxtDepartment.Enabled = true;
                    TxtDepartment.BackColor = Color.White;
                    BtnDepartmentSearch.Enabled = true;
                }
                else
                {
                    TxtDepartment.Enabled = false;
                    TxtDepartment.BackColor = SystemColors.Control;
                    BtnDepartmentSearch.Enabled = false;
                }

                if (ClsGlobal.SalesRemarksControlVal == 'Y')
                {
                    TxtRemarks.Enabled = true;
                    Utility.EnableDesibleColor(TxtRemarks, true);
                }
                else
                {
                    TxtRemarks.Enabled = false;
                    Utility.EnableDesibleColor(TxtRemarks, false);
                }
            }
            else
            {
                TxtMiti.Enabled = fld;
                TxtDate.Enabled = fld;
                TxtCurrency.Enabled = fld;
                Utility.EnableDesibleColor(TxtCurrency, fld);
                TxtCurrencyRate.Enabled = fld;
                Utility.EnableDesibleColor(TxtCurrencyRate, fld);
                TxtDepartment.Enabled = fld;
                TxtRemarks.Enabled = fld;
            }

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtVoucherNo.Enabled == true)
            {
                TxtVoucherNo.Focus();
            }

            if (TxtGridParticular.Visible == true)
            {
                GridControlMode(false);
                Grid.Focus();
            }

            BtnBillTerm.Enabled = _dtBillTermExists == "Yes" ? fld : false;

            if (DtUDFMaster.Rows.Count <= 0)
            {
                BtnUDF.Visible = false;
            }
            else
            {
                BtnUDF.Visible = true;
                BtnUDF.Enabled = fld;
            }
        }
        private void ClearFld()
        {
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }

            TxtDueMiti.Text = "";
            TxtDueDate.Text = "";
            _GlCategory = "";
            CmbInvoiceType.SelectedIndex = 0;
            TxtTransport.Text = "";
            TxtVehicleNo.Text = "";
            TxtPackage.Text = "";
            TxtCnNo.Text = "";
            TxtCnFreight.Text = "";
            CmbCnType.Text = "";
            TxtAdvance.Text = "";
            TxtBalFreight.Text = "";
            TxtDriverName.Tag = "";
            TxtDriverLicenseNo.Text = "";
            TxtDriverMobileNo.Text = "";
            TxtContactNo.Text = "";
            TxtExportInvNo.Text = "";
            TxtPONo.Text = "";
            TxtDocBank.Text = "";
            TxtLCNo.Text = "";
            TxtCustomerName.Text = "";
            TxtCoFd.Text = "";
            TxtBillingAddress.Text = "";
            TxtBillingCity.Text = "";
            TxtBillingState.Text = "";
            TxtBillingCountry.Text = "";
            TxtBillingEmail.Text = "";
            TxtShippingAddress.Text = "";
            TxtShippingCity.Text = "";
            TxtShippingState.Text = "";
            TxtShippingCountry.Text = "";
            TxtShippingEmail.Text = "";
            LblTotalAltQty.Text = "";
            LblTotalQty.Text = "";
            LblBasicAmt.Text = "";
            TxtBillTermAmt.Text = "";
			TxtBillTermAmt.Tag = "";
            LblNetAmt.Text = "";
            LblLocalNetAmt.Text = "";
            LblPanNo.Text = "";
            LblCurrentBalance.Text = "";
            LblCreditLimit.Text = "";
			tabControl1.SelectedTab = TabProductInfo;
            Grid.Rows.Clear();
            Grid.Rows.Add();

            ClsGlobal.FieldNameArrMaster.Clear();
            ClsGlobal.UDFDataArrMaster.Clear();
            ClsGlobal.UDFExistingDataMaster.Clear();
            ClsGlobal.UDFExistingDataTableDetails.Clear();
            ClsGlobal.UDFExistingDataTableDetails.Clear();
            ClsGlobal.UDFCodeArrayDetails.Clear();
            ClsGlobal.UDFDataArrayDetails.Clear();
            //ClsGlobal.ClearCashData();
            CashPartyViewModel.PartyName = string.Empty;
            CashPartyViewModel.PartyAddress = string.Empty;
            CashPartyViewModel.PartyVatNo = string.Empty;
            CashPartyViewModel.ChequeNo = string.Empty;
            CashPartyViewModel.ChequeDate = null;
            CashPartyViewModel.PartyMobileNo = string.Empty;
            CashPartyViewModel.PartyEmail = string.Empty;
			TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
			TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
		}

        private void GridControlMode(bool mode)
        {
            if (Grid.CurrentRow != null)
            {
                int currRo = Grid.CurrentRow.Index;
                int colindex = 0;
                if (mode == true)
                {
                    colindex = Grid.Columns["Particular"].Index;
                    TxtGridParticular.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridParticular.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
                    {
                        if (ClsGlobal.SalesGodownControlVal == 'Y')
                        {
                            colindex = Grid.Columns["Godown"].Index;
                            TxtGridGodown.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                            TxtGridGodown.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                            Utility.EnableDesibleColor(TxtGridGodown, true);
                        }
                    }

                    colindex = Grid.Columns["AltQty"].Index;
                    TxtGridAltQty.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridAltQty.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["AltUOM"].Index;
                    TxtGridAltUOM.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridAltUOM.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["Qty"].Index;
                    TxtGridQty.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridQty.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["QtyUOM"].Index;
                    TxtGridQtyUOM.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridQtyUOM.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["Rate"].Index;
                    TxtGridRate.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridRate.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["BasicAmt"].Index;
                    TxtGridBasicAmt.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridBasicAmt.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["TermsAmt"].Index;
                    TxtGridTermsAmt.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridTermsAmt.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["NetAmt"].Index;
                    TxtGridNetAmt.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridNetAmt.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                }
                SetGridValueToTextBox(currRo);
            }

            TxtGridParticular.Enabled = mode;
            TxtGridParticular.Visible = mode;

            if (mode == true)
            {
                BtnOk.Enabled = false;
            }
            else
            {
                BtnOk.Enabled = true;
            }

            if (ClsGlobal.SalesGodownControlVal == 'Y')
            {
                Grid.Columns["Godown"].Visible = true;
            }
            else
            {
                Grid.Columns["Godown"].Visible = false;
            }

            if (ClsGlobal.SalesGodownControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
            {
                TxtGridGodown.Visible = mode;
            }
            else
            {
                TxtGridGodown.Visible = false;
            }

            TxtGridAltQty.Enabled = mode;
            TxtGridAltQty.Visible = mode;

            TxtGridAltUOM.Visible = mode;
            TxtGridAltUOM.Enabled = mode;

            TxtGridQty.Enabled = mode;
            TxtGridQty.Visible = mode;

            TxtGridQtyUOM.Visible = mode;
            TxtGridQtyUOM.Enabled = mode;

            TxtGridRate.Visible = mode;
            TxtGridRate.Enabled = mode;

            TxtGridBasicAmt.Visible = mode;
            TxtGridBasicAmt.Enabled = mode;

            TxtGridTermsAmt.Visible = mode;
            TxtGridTermsAmt.Enabled = mode;

            TxtGridNetAmt.Visible = mode;
            TxtGridNetAmt.Enabled = mode;
			

			if (mode == true)
            {
				if (!string.IsNullOrEmpty(TxtOrderNo.Text) || !string.IsNullOrEmpty(TxtChallanNo.Text))
				{
					TxtGridParticular.Enabled = false;
					TxtGridQty.Focus();
				}
				else
					TxtGridParticular.Focus();

                if (TxtGridBasicAmt.ReadOnly == true)
                {
                    Utility.EnableDesibleColor(TxtGridBasicAmt, false);
                }
                else
                {
                    Utility.EnableDesibleColor(TxtGridBasicAmt, true);
                }
            }
        }
        private bool SetTextBoxValueToGrid()
        {
            if (string.IsNullOrEmpty(TxtGridParticular.Text))
            {
                TxtGridParticular.Focus();
                return false; // return false for not add grid new 1 row
            }
            else
            {
                Utility.EnableDesibleColor(TxtGridAltUOM, true);
                Utility.EnableDesibleColor(TxtGridAltQty, true);
                DataGridViewRow ro = new DataGridViewRow();
                ro = Grid.Rows[Grid.CurrentRow.Index];
                ro.Cells["SNo"].Value = Grid.CurrentRow.Index + 1;
                ro.Cells["Particular"].Value = TxtGridParticular.Text;
                ro.Cells["ProductId"].Value = TxtGridParticular.Tag.ToString();
                ro.Cells["AltConversion"].Value = TxtGridParticular.AltConversion.ToString();
                ro.Cells["ProductShortName"].Value = TxtGridParticular.ProductShortName.ToString();
                ro.Cells["QtyConversion"].Value = TxtGridParticular.ProductQtyConversion.ToString();
                ro.Cells["TermDetails"].Value = TxtGridTermsDetails.Text;

                if (TxtGridGodown.Visible == true)
                {
                    ro.Cells["Godown"].Value = TxtGridGodown.Text;
                    if (string.IsNullOrEmpty(TxtGridGodown.Text.Trim()))
                        ro.Cells["GodownId"].Value = "0";
                    else
                        ro.Cells["GodownId"].Value = TxtGridGodown.Tag != null ? TxtGridGodown.Tag.ToString() : "0";
                }

                if (!string.IsNullOrEmpty(TxtGridAltQty.Text))
                {
                    ro.Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridAltQty.Text), 1, ClsGlobal._AltQtyDecimalFormat);
                }

                ro.Cells["AltUOM"].Value = TxtGridAltUOM.Text;

                if (string.IsNullOrEmpty(TxtGridAltUOM.Text.Trim()))
                    ro.Cells["ProductAltUnitId"].Value = "0";
                else
                    ro.Cells["ProductAltUnitId"].Value = !string.IsNullOrEmpty(TxtGridAltUOM.Tag.ToString()) ? TxtGridAltUOM.Tag.ToString() : "0";

                if (!string.IsNullOrEmpty(TxtGridQty.Text))
                {
                    ro.Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridQty.Text), 1, ClsGlobal._QtyDecimalFormat);
                }
                ro.Cells["QtyUOM"].Value = TxtGridQtyUOM.Text;

                if (string.IsNullOrEmpty(TxtGridAltUOM.Text.Trim()))
                    ro.Cells["ProductUnitId"].Value = "0";
                else
                    ro.Cells["ProductUnitId"].Value = !string.IsNullOrEmpty(TxtGridQtyUOM.Tag.ToString()) ? TxtGridQtyUOM.Tag.ToString() : "0";

                if (!string.IsNullOrEmpty(TxtGridRate.Text))
                {
                    ro.Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridRate.Text), 1, ClsGlobal._RateDecimalFormat);
                }

                if (!string.IsNullOrEmpty(TxtGridBasicAmt.Text))
                {
                    ro.Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridBasicAmt.Text), 1, ClsGlobal._AmountDecimalFormat);
                }

                if (!string.IsNullOrEmpty(TxtGridTermsAmt.Text))
                {
                    ro.Cells["TermsAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridTermsAmt.Text), 1, ClsGlobal._AmountDecimalFormat);
                }

                if (!string.IsNullOrEmpty(TxtGridNetAmt.Text))
                {
                    ro.Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridNetAmt.Text), 1, ClsGlobal._AmountDecimalFormat);
                }

                if (!string.IsNullOrEmpty(LblAltStockQty.Text))
                {
                    ro.Cells["AltStockQty"].Value = LblAltStockQty.Text;
                }
                if (!string.IsNullOrEmpty(LblStockQty.Text))
                {
                    ro.Cells["StockQty"].Value = LblStockQty.Text;
                }
                CalTotal();
            }
            return true; // return true for add grid new row
        }
        private void SetGridValueToTextBox(int row)
        {
            TxtGridParticular.Text = "";
            TxtGridParticular.Tag = "0";
            TxtGridParticular.ProductShortName = "";
            TxtGridParticular.ProductQtyConversion = "0";
            TxtGridGodown.Text = "";
            TxtGridGodown.Tag = "0";
            TxtGridAltQty.Text = "";
            TxtGridAltUOM.Text = "";
            TxtGridAltUOM.Tag = "0";
            TxtGridQty.Text = "";
            TxtGridQtyUOM.Text = "";
            TxtGridQtyUOM.Tag = "0";
            TxtGridRate.Text = "";
            TxtGridBasicAmt.Text = "";
            TxtGridTermsAmt.Text = "";
            TxtGridNetAmt.Text = "";
            TxtGridTermsDetails.Text = "";

            if (Grid["Particular", row].Value != null)
            {
                TxtGridParticular.Text = Grid["Particular", row].Value.ToString();
                TxtGridParticular.Tag = Grid["ProductId", row].Value.ToString();
                TxtGridParticular.AltConversion = Convert.ToDecimal(Grid["AltConversion", row].Value.ToString());
                TxtGridParticular.ProductShortName = Grid["ProductShortName", row].Value.ToString();
                TxtGridParticular.ProductQtyConversion = Grid["QtyConversion", row].Value.ToString();
                TxtGridTermsDetails.Text = Grid["TermDetails", row].Value.ToString();
            }
            else
            {
                LblShortName.Text = "";
                LblAltStockQty.Text = "";
                LblStockQty.Text = "";
            }

            if (ClsGlobal.SalesGodownControlVal == 'Y')
            {
                if (Grid["Godown", row].Value != null)
                {
                    TxtGridGodown.Text = Grid["Godown", row].Value.ToString();
                    TxtGridGodown.Tag = Grid["GodownId", row].Value.ToString();
                }
            }

            if (Grid["AltQty", row].Value != null)
            {
                TxtGridAltQty.Text = Grid["AltQty", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["AltUOM", row].Value != null)
            {
                TxtGridAltUOM.Text = Grid["AltUOM", row].Value.ToString();
                TxtGridAltUOM.Tag = Grid["ProductAltUnitId", row].Value.ToString();
            }

            if (Grid["Qty", row].Value != null)
            {
                TxtGridQty.Text = Grid["Qty", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["QtyUOM", row].Value != null)
            {
                TxtGridQtyUOM.Text = Grid["QtyUOM", row].Value.ToString();
                TxtGridQtyUOM.Tag = Grid["ProductUnitId", row].Value.ToString();
            }

            if (Grid["Rate", row].Value != null)
            {
                TxtGridRate.Text = Grid["Rate", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["BasicAmt", row].Value != null)
            {
                TxtGridBasicAmt.Text = Grid["BasicAmt", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["TermsAmt", row].Value != null)
            {
                TxtGridTermsAmt.Text = Grid["TermsAmt", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["NetAmt", row].Value != null)
            {
                TxtGridNetAmt.Text = Grid["NetAmt", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["AltStockQty", row].Value != null)
            {
                LblAltStockQty.Text = Grid["AltStockQty", row].Value.ToString().Replace(",", string.Empty);
            }
            else
            {
                LblAltStockQty.Text = "";
            }
            if (Grid["StockQty", row].Value != null)
            {
                LblStockQty.Text = Grid["StockQty", row].Value.ToString().Replace(",", string.Empty);
            }
            else
            {
                LblStockQty.Text = "";
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Sales Invoice [NEW]";
            if (ClsGlobal.DateType == "M")
            {
                TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtCnDate.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtContactDate.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtExportInvDate.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtPODate.Text = _objDate.GetMiti(_objDate.GetServerDate());
            }
            else
            {
                TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtDate.Text));
                TxtCnDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtContactDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtExportInvDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtPODate.Text = _objDate.GetServerDate().ToShortDateString();
            }

            if (TxtDate.Enabled == true)
            {
                Utility.GetVoucherNo1("Sales Invoice", TxtVoucherNo, TxtDate, _Tag, "", _DocId);
            }
            else if (TxtChallanNo.Enabled == true)
            {
                Utility.GetVoucherNo2("Sales Invoice", TxtVoucherNo, TxtChallanNo, _Tag, "", _DocId);
            }
			else if (TxtOrderNo.Enabled == true)
			{
				Utility.GetVoucherNo2("Sales Invoice", TxtVoucherNo, TxtOrderNo, _Tag, "", _DocId);
			}
			else
            {
                Utility.GetVoucherNo2("Sales Invoice", TxtVoucherNo, TxtCustomer, _Tag, "", _DocId);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Sales Invoice [EDIT]";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClear == 1)
            {
                DialogResult dialog = ClsGlobal.ConfirmFormClearing();
                if (dialog == DialogResult.Yes)
                {
                    _Tag = "";
                    ControlEnableDisable(true, false);
                    ClearFld();
                    TxtVoucherNo.Text = "";
                    Text = "Sales Invoice";
                }
                else
                {
                    return;
                }
            }
            else if (ClsGlobal.ConfirmFormClear == 0)
            {
                _Tag = "";
                ControlEnableDisable(true, false);
                ClearFld();
                TxtVoucherNo.Text = "";
                Text = "Sales Invoice";
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmSalesInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != Grid)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridParticular.Visible == true)
                {
                    _GridControlMode = false;
                    GridControlMode(false);
                    _GridControlMode = true;
                    Grid.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    BtnCancel.PerformClick();
                }
                else if (BtnCancel.Enabled == false)
                {
                    BtnExit.PerformClick();
                }

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void BtnVoucherNoSearch_Click(object sender, EventArgs e)
        {
            PickList frmPickList = new PickList("SalesVoucher", _SearchKey);
            if (PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    _VoucherNo = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                    DataSet ds = _objSalesInvoice.GetDataSalesVoucher(_VoucherNo);
                    ClearFld();
                    SetData(ds);
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in sales voucher.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            TxtVoucherNo.Focus();
        }

        private void BtnCustomerNameSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger.Customer,Both,LC,Cash Book,Bank Book", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtCustomer.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtCustomer.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    DataTable dt = _objGeneralLedger.GetCurrrentBalance(Convert.ToInt32(TxtCustomer.Tag.ToString()), Convert.ToDateTime(TxtDate.Text), ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                    LblCurrentBalance.Text = Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()) >= 0 ? ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Dr" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Cr";
                    LblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                    LblCreditLimit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CreditLimit"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    TxtDueDays.Text = dt.Rows[0]["CreditDays"].ToString();
                    TxtSalesman.Text = dt.Rows[0]["SalesmanDesc"].ToString();
                    TxtSalesman.Tag = string.IsNullOrEmpty(dt.Rows[0]["SalesmanId"].ToString()) ? "0" : dt.Rows[0]["SalesmanId"].ToString();
                    this._isSubledgerRequired = Convert.ToBoolean(dt.Rows[0]["IsSubledger"].ToString());
                    this._GlCategory = frmPickList.SelectedList[0]["GlCategory"].ToString();
                    //DueDateCalculate();
                    TxtCustomer.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in ledger.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCustomer.Focus();
                return;
            }
            _SearchKey = string.Empty;
            TxtCustomer.Focus();
        }

        private void TxtVoucherNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtVoucherNo) return;
            if (TxtVoucherNo.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtVoucherNo.Text))
            {
                MessageBox.Show("Voucher number cannot be left blank.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            if (_Tag == "NEW")
            {
                if (!string.IsNullOrEmpty(_objSalesInvoice.IsExistsVNumber(TxtVoucherNo.Text)))
                {
                    MessageBox.Show("Voucher number already exist.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
			else
			{
				if (this._VoucherNo != TxtVoucherNo.Text.Trim())
				{
					this._VoucherNo = TxtVoucherNo.Text.Trim();
					DataSet ds = _objSalesInvoice.GetDataSalesVoucher(this._VoucherNo);
					ClearFld();
					SetData(ds);
				}
			}
		}

        private void TxtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnVoucherNoSearch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtVoucherNo, BtnVoucherNoSearch, true);
            }
        }

        private void TxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtCustomer.Text = frm._NewLedger;
                TxtCustomer.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtCustomer, BtnCustomerNameSearch, false);
            }
        }

        private void TxtCustomer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtCustomer || string.IsNullOrEmpty(TxtVoucherNo.Text.Trim())) return;
            if (TxtCustomer.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtCustomer.Text.Trim()))
            {
                MessageBox.Show("Customer Cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            else
            {
				if (this._GlCategory == "Cash Book" || this._GlCategory == "Bank Book")
                {
                    FrmCashPartyInfo frm = new FrmCashPartyInfo();
                    frm.ShowDialog();
                }
            }
        }

        private void BtnSalesmanSearch_Click(object sender, EventArgs e)
        {
            ClsButtonClick.SalesManBtnClick(_SearchKey, TxtSalesman, e);
            _SearchKey = string.Empty;
        }

        private void BtnSubledgerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClsButtonClick.SubledgerBtnClick(_SearchKey, TxtSubledger, Convert.ToInt32(TxtCustomer.Tag.ToString()), e);
                _SearchKey = string.Empty;
            }
            catch
            {
                MessageBox.Show("First select customer.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtSalesman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmSalesMan frm = new FrmSalesMan();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSalesman.Text = frm._NewSubSalesMan;
                TxtSalesman.Tag = frm._SalesmanId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSalesman, BtnSalesmanSearch, false);
            }
        }

        private void TxtSubledger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmSubledger frm = new FrmSubledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSubledger.Text = frm._NewSubLedger;
                TxtSubledger.Tag = frm._SubledgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSubledger, BtnSubledgerSearch, false);
            }
        }

        private void BtnCurrencySearch_Click(object sender, EventArgs e)
        {
            ClsButtonClick.CurrencyBtnClick(_SearchKey, TxtCurrency, e);
            _SearchKey = string.Empty;
        }

        private void TxtCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmCurrency frm = new FrmCurrency();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtCurrency.Text = frm._NewCurrency;
                TxtCurrency.Tag = frm._CurrencyId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtCurrency, BtnCurrencySearch, false);
            }
        }

        private void BtnDepartmentSearch_Click(object sender, EventArgs e)
        {
            ClsButtonClick.DepartmentBtnClick(_SearchKey, TxtDepartment, e);
            _SearchKey = string.Empty;
        }

        private void BtnChallanNoSearch_Click(object sender, EventArgs e)
        {
			Common.PickList frmPickList = new Common.PickList("SalesChallanOutstandingList", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0)
				{
					TxtChallanNo.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
					TxtChallanNo.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No list available in sales challan.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtChallanNo.Focus();
				return;
			}
			_SearchKey = string.Empty;
			TxtChallanNo.Focus();
		}

        private void BtnOrderNoSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesOrderOutstandingList", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtOrderNo.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
					TxtOrderNo.Tag = "";
					TxtOrderNo.SelectAll();
				}
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in sales order.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtOrderNo.Focus();
                return;
            }
            _SearchKey = string.Empty;
            TxtOrderNo.Focus();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.CheckDateInsideCompanyPeriod(Convert.ToDateTime(TxtDate.Text)) == 1)
            {
                ClsGlobal.DateMitiRangeMsg();
                return;
            }

            if (string.IsNullOrEmpty(TxtVoucherNo.Text.Trim()))
            {
                MessageBox.Show("Voucher number cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            if (TxtMiti.Text == "  /  /")
            {
                MessageBox.Show("Miti cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMiti.Focus();
                return;
            }

            if (TxtDate.Text == "  /  /")
            {
                MessageBox.Show("Date cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDate.Focus();
                return;
            }

            decimal.TryParse(LblNetAmt.Text, out decimal _NetAmt);
            if (_NetAmt < 0)
            {
                MessageBox.Show("Sales invoice negative should not be save.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnOk.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtCustomer.Text))
            {
                MessageBox.Show("Customer cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCustomer.Focus();
                return;
            }

            if (Grid.Rows.Count <= 0)
            {
                MessageBox.Show("Invoice details not found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Grid.Focus();
                return;
            }

            if (Grid.Rows.Count == 1 && Grid.Rows[0].Cells["Particular"].Value == null)
            {
                MessageBox.Show("Invoice details not found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnOk.Enabled = false;
                Grid.Focus();
                return;
            }

            decimal.TryParse(TxtCurrencyRate.Text, out decimal _CurrencyRate);
            if (_CurrencyRate <= 0 && !string.IsNullOrEmpty(TxtCurrency.Text))
            {
                MessageBox.Show("Currency rate can not zero value.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCurrencyRate.Focus();
                return;
            }

            if (_Tag == "REVERSE")
            {
                if (string.IsNullOrEmpty(TxtReasonForCancel.Text))
                {
                    MessageBox.Show("Reason for bill cancel cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtReasonForCancel.Focus();
                    return;
                }
            }
            _objSalesInvoice.Model.EntryFromProject = "Normal";
            _objSalesInvoice.Model.Gadget = "Desktop";
            _objSalesInvoice.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objSalesInvoice.Model.ReferenceNo = "";
            _objSalesInvoice.Model.ReferenceDate = null;

            _objSalesInvoice.Model.PartyName = !string.IsNullOrEmpty(CashPartyViewModel.PartyName) ? CashPartyViewModel.PartyName : TxtCustomer.Text.Trim();
            _objSalesInvoice.Model.PartyAddress = CashPartyViewModel.PartyAddress;
            _objSalesInvoice.Model.PartyVatNo = CashPartyViewModel.PartyVatNo;
            if (!string.IsNullOrEmpty(CashPartyViewModel.ChequeNo))
            {
                _objSalesInvoice.Model.ChequeNo = CashPartyViewModel.ChequeNo;
                _objSalesInvoice.Model.ChequeDate = Convert.ToDateTime(CashPartyViewModel.ChequeDate);
                _objSalesInvoice.Model.ChequeMiti = null;
            }
            else
            {
                _objSalesInvoice.Model.ChequeNo = null;
                _objSalesInvoice.Model.ChequeDate = null;
                _objSalesInvoice.Model.ChequeMiti = null;
            }
            _objSalesInvoice.Model.PartyMobileNo = CashPartyViewModel.PartyMobileNo;
            _objSalesInvoice.Model.PartyEmail = CashPartyViewModel.PartyEmail;

            _objSalesInvoice.Model.ReferenceMiti = "";
            _objSalesInvoice.Model.TaxableAmount = 0;
            _objSalesInvoice.Model.TaxFreeAmount = 0;
            _objSalesInvoice.Model.VatAmount = 0;
            _objSalesInvoice.Model.UdfDetails = ClsGlobal.UDFExistingDataTableDetails;
            _objSalesInvoice.Model.UdfMaster = ClsGlobal.UDFExistingDataMaster;
            _objSalesInvoice.Model.VDate = Convert.ToDateTime(TxtDate.Text);
            _objSalesInvoice.Model.Tag = _Tag;

            if (_Tag == "NEW")
            {
                string[] VoucherNoDetails = _objCommon.GetVoucherNo(TxtVoucherNo.Tag.ToString(), "Sales Invoice", ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                _objSalesInvoice.Model.DocId = ((TxtVoucherNo.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtVoucherNo.Tag.ToString()));
                _objSalesInvoice.Model.VoucherNo = (!string.IsNullOrEmpty(VoucherNoDetails[0])) ? VoucherNoDetails[0] : TxtVoucherNo.Text.Trim();
            }
            else
            {
                _objSalesInvoice.Model.VoucherNo = TxtVoucherNo.Text.Trim();
            }

            _objSalesInvoice.Model.VTime = _objDate.GetServerDateTime();
            _objSalesInvoice.Model.VMiti = TxtMiti.Text;
            _objSalesInvoice.Model.LedgerId = Convert.ToInt32(TxtCustomer.Tag.ToString());
            _objSalesInvoice.Model.DueDay = !string.IsNullOrEmpty(TxtDueDays.Text) ? Convert.ToInt32(TxtDueDays.Text) : 0;
            if (TxtDueDate.Text != "  /  /")
            {
                _objSalesInvoice.Model.DueDate = Convert.ToDateTime(TxtDueDate.Text);
                _objSalesInvoice.Model.DueMiti = TxtDueMiti.Text;
            }
            else
            {
                _objSalesInvoice.Model.DueDate = null;
                _objSalesInvoice.Model.DueMiti = null;
            }
            _objSalesInvoice.Model.SalesmanId = Convert.ToInt32(TxtSalesman.Tag.ToString());

            if (!string.IsNullOrEmpty(TxtDepartment.Text))
            {
                string[] dept = TxtDepartment.Tag.ToString().Split('|');
                _objSalesInvoice.Model.DepartmentId1 = ((dept[0].ToString() == "") ? 0 : Convert.ToInt32(dept[0].ToString()));
                _objSalesInvoice.Model.DepartmentId2 = ((dept[1].ToString() == "") ? 0 : Convert.ToInt32(dept[1].ToString()));
                _objSalesInvoice.Model.DepartmentId3 = ((dept[2].ToString() == "") ? 0 : Convert.ToInt32(dept[2].ToString()));
                _objSalesInvoice.Model.DepartmentId4 = ((dept[3].ToString() == "") ? 0 : Convert.ToInt32(dept[3].ToString()));
            }
            _objSalesInvoice.Model.BranchId = ClsGlobal.BranchId;
            _objSalesInvoice.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;
            _objSalesInvoice.Model.CurrencyId = Convert.ToInt32(TxtCurrency.Tag.ToString());
            _objSalesInvoice.Model.CurrencyRate = _CurrencyRate;
            _objSalesInvoice.Model.InvoiceType = CmbInvoiceType.Text;
            decimal.TryParse(LblBasicAmt.Text.Trim(), out decimal BasicAmt);
            _objSalesInvoice.Model.BasicAmount = BasicAmt;
            decimal.TryParse(TxtBillTermAmt.Text.Trim(), out decimal TermAmt);
            _objSalesInvoice.Model.TermAmount = TermAmt;
            decimal.TryParse(LblNetAmt.Text.Trim(), out decimal NetAmt);
            _objSalesInvoice.Model.NetAmount = NetAmt;
            _objSalesInvoice.Model.TenderAmount = 0;
            _objSalesInvoice.Model.ReturnAmount = 0;
            _objSalesInvoice.Model.SubLedgerId = Convert.ToInt32(TxtSubledger.Tag.ToString());
            _objSalesInvoice.Model.OrderNo = TxtOrderNo.Text;
            _objSalesInvoice.Model.ChallanNo = TxtChallanNo.Text;
            _objSalesInvoice.Model.Remarks = TxtRemarks.Text;

            if (_Tag == "REVERSE")
            {
                _objSalesInvoice.Model.CancelRemarks = TxtReasonForCancel.Text;
                _objSalesInvoice.Model.CancelInvoiceDate = _objDate.GetServerDate();
                _objSalesInvoice.Model.CancelInvoiceTime = _objDate.GetServerDateTime();
            }

            if (!string.IsNullOrEmpty(TxtBillingAddress.Text.ToString().Trim()))
            {
                _objSalesInvoice.ModelBillAddress.LedgerId = Convert.ToInt32(TxtCustomer.Tag.ToString());
                _objSalesInvoice.ModelBillAddress.BillingAddress = TxtBillingAddress.Text.Trim();
                _objSalesInvoice.ModelBillAddress.BillingCity = TxtBillingCity.Text.Trim();
                _objSalesInvoice.ModelBillAddress.BillingState = TxtBillingState.Text.Trim();
                _objSalesInvoice.ModelBillAddress.BillingCountry = TxtBillingCountry.Text.Trim();
                _objSalesInvoice.ModelBillAddress.BillingEmail = TxtBillingEmail.Text.Trim();
                _objSalesInvoice.ModelBillAddress.ShippingAddress = TxtShippingAddress.Text.Trim();
                _objSalesInvoice.ModelBillAddress.ShippingCity = TxtShippingCity.Text.Trim();
                _objSalesInvoice.ModelBillAddress.ShippingState = TxtShippingState.Text.Trim();
                _objSalesInvoice.ModelBillAddress.ShippingCountry = TxtShippingCountry.Text.Trim();
                _objSalesInvoice.ModelBillAddress.ShippingEmail = TxtShippingEmail.Text.Trim();
            }
            _objSalesInvoice.ModelOtherDetails.Transport = TxtTransport.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.VehicleNo = TxtVehicleNo.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.Package = TxtPackage.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.CnNo = TxtCnNo.Text.Trim();

            if (TxtCnDate.Text != "  /  /")
            {
                if (ClsGlobal.DateType == "M")
                    _objSalesInvoice.ModelOtherDetails.CnDate = _objDate.GetDate(TxtCnDate.Text);
                else
                    _objSalesInvoice.ModelOtherDetails.CnDate = Convert.ToDateTime(TxtCnDate.Text);
            }
            else
                _objSalesInvoice.ModelOtherDetails.CnDate = null;

            _objSalesInvoice.ModelOtherDetails.CnFreight = TxtCnFreight.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.Advance = TxtAdvance.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.BalFreight = TxtBalFreight.Text.Trim();

            if (CmbCnType.Text == "Due")
                _objSalesInvoice.ModelOtherDetails.CnType = "D";
            else if (CmbCnType.Text == "To Pay")
                _objSalesInvoice.ModelOtherDetails.CnType = "T";
            else if (CmbCnType.Text == "Paid")
                _objSalesInvoice.ModelOtherDetails.CnType = "P";
            else if (CmbCnType.Text == "Free")
                _objSalesInvoice.ModelOtherDetails.CnType = "F";
            else if (CmbCnType.Text == "")
                _objSalesInvoice.ModelOtherDetails.CnType = null;

            _objSalesInvoice.ModelOtherDetails.DriverName = TxtDriverName.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.DriverLicNo = TxtDriverLicenseNo.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.DriverMobileNo = TxtDriverMobileNo.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.ContractNo = TxtContactNo.Text.Trim();
            if (TxtContactDate.Text != "  /  /")
            {
                if (ClsGlobal.DateType == "M")
                    _objSalesInvoice.ModelOtherDetails.ContractDate = _objDate.GetDate(TxtContactDate.Text);
                else
                    _objSalesInvoice.ModelOtherDetails.ContractDate = Convert.ToDateTime(TxtContactDate.Text);
            }
            else
                _objSalesInvoice.ModelOtherDetails.ContractDate = null;

            _objSalesInvoice.ModelOtherDetails.ExpInvNo = TxtExportInvNo.Text.Trim();

            if (TxtExportInvDate.Text != "  /  /")
            {
                if (ClsGlobal.DateType == "M")
                    _objSalesInvoice.ModelOtherDetails.ExpInvDate = _objDate.GetDate(TxtExportInvDate.Text);
                else
                    _objSalesInvoice.ModelOtherDetails.ExpInvDate = Convert.ToDateTime(TxtExportInvDate.Text);
            }
            else
                _objSalesInvoice.ModelOtherDetails.ExpInvDate = null;

            _objSalesInvoice.ModelOtherDetails.PoNo = TxtPONo.Text.Trim();

            if (TxtPODate.Text != "  /  /")
            {
                if (ClsGlobal.DateType == "M")
                    _objSalesInvoice.ModelOtherDetails.PoDate = _objDate.GetDate(TxtPODate.Text);
                else
                    _objSalesInvoice.ModelOtherDetails.PoDate = Convert.ToDateTime(TxtPODate.Text);
            }
            else
                _objSalesInvoice.ModelOtherDetails.PoDate = null;

            _objSalesInvoice.ModelOtherDetails.DocBank = TxtDocBank.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.LcNo = TxtLCNo.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.CustomName = TxtCustomerName.Text.Trim();
            _objSalesInvoice.ModelOtherDetails.Cofd = TxtCoFd.Text.Trim();

            SalesInvoiceDetailsViewModel _SalesInvoiceDetails = null;
            TermViewModel _SalesInvoiceTerm = null;

            int dc = Grid.Rows.Count;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
				if (ro.Cells["Particular"].Value != null)
				{
					_SalesInvoiceDetails = new SalesInvoiceDetailsViewModel();
					_SalesInvoiceDetails.VoucherNo = _objSalesInvoice.Model.VoucherNo;
					_SalesInvoiceDetails.Sno = Grid.Rows.IndexOf(ro) + 1;
					_SalesInvoiceDetails.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
					if (ro.Cells["GodownId"].Value != null)
						_SalesInvoiceDetails.GodownId = string.IsNullOrEmpty(ro.Cells["GodownId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["GodownId"].Value.ToString());
					else
						_SalesInvoiceDetails.GodownId = 0;

					if (ro.Cells["AltQty"].Value != null)
					{
						decimal.TryParse(ro.Cells["AltQty"].Value.ToString().Trim(), out decimal _AltQty);
						_SalesInvoiceDetails.AltQty = _AltQty;
					}
					else
					{
						_SalesInvoiceDetails.AltQty = 0;
					}

					if (ro.Cells["ProductAltUnitId"].Value != null)
						_SalesInvoiceDetails.ProductAltUnitId = string.IsNullOrEmpty(ro.Cells["ProductAltUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["ProductAltUnitId"].Value.ToString());
					else
						_SalesInvoiceDetails.ProductAltUnitId = 0;

					_SalesInvoiceDetails.Qty = ro.Cells["Qty"].Value != null ? Convert.ToDecimal(ro.Cells["Qty"].Value.ToString().Trim()) : 0;

					if (ro.Cells["ProductUnitId"].Value != null)
						_SalesInvoiceDetails.ProductUnitId = string.IsNullOrEmpty(ro.Cells["ProductUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["ProductUnitId"].Value.ToString());
					else
						_SalesInvoiceDetails.ProductUnitId = 0;

					_SalesInvoiceDetails.ConversionRatio = ro.Cells["QtyConversion"].Value != null ? Convert.ToDecimal(ro.Cells["QtyConversion"].Value.ToString().Trim()) : 0;
					_SalesInvoiceDetails.SalesRate = ro.Cells["Rate"].Value != null ? Convert.ToDecimal(ro.Cells["Rate"].Value.ToString().Trim()) : 0;
					_SalesInvoiceDetails.BasicAmount = ro.Cells["BasicAmt"].Value != null ? Convert.ToDecimal(ro.Cells["BasicAmt"].Value.ToString().Trim()) : 0;
					_SalesInvoiceDetails.TermAmount = ro.Cells["TermsAmt"].Value != null ? Convert.ToDecimal(ro.Cells["TermsAmt"].Value.ToString().Trim()) : 0;
					_SalesInvoiceDetails.NetAmount = ro.Cells["NetAmt"].Value != null ? Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString().Trim()) : 0;
					if (ro.Cells["OrderSNO"].Value != null)
						_SalesInvoiceDetails.OrderSNo = !string.IsNullOrEmpty(ro.Cells["OrderSNO"].Value.ToString()) ? Convert.ToInt32(ro.Cells["OrderSNO"].Value.ToString().Trim()) : 0;
					else
						_SalesInvoiceDetails.OrderSNo = 0;
					_SalesInvoiceDetails.OrderNo = ro.Cells["OrderNO"].Value?.ToString().Trim();
					if (ro.Cells["ChallanSNo"].Value != null)
						_SalesInvoiceDetails.ChallanSNo = !string.IsNullOrEmpty(ro.Cells["ChallanSNO"].Value.ToString()) ? Convert.ToInt32(ro.Cells["ChallanSNO"].Value.ToString().Trim()) : 0;
					else
						_SalesInvoiceDetails.ChallanSNo = 0;
					_SalesInvoiceDetails.ChallanNo = ro.Cells["ChallanNO"].Value?.ToString().Trim();
					_SalesInvoiceDetails.AdditionalDesc = ro.Cells["AdditionalDesc"].Value != null ? ro.Cells["AdditionalDesc"].Value.ToString() : ro.Cells["Particular"].Value.ToString().Trim();
					_SalesInvoiceDetails.FreeQty = 0;

					_objSalesInvoice.ModelDetails.Add(_SalesInvoiceDetails);
					if (ro.Cells["TermDetails"].Value != null)
					{
						if (!string.IsNullOrEmpty(ro.Cells["TermDetails"].Value.ToString()))
						{
							string termData = ro.Cells["TermDetails"].Value.ToString();
							string[] val1 = termData.Split('|');
							string[] termSignArr = val1[0].Split(',');
							string[] termCodeArr = val1[1].Split(',');
							string[] termRatePercentArr = val1[2].Split(',');
							string[] termAmountntArr = val1[3].Split(',');
							for (int i = 0; i < termCodeArr.Count(); i++)
							{
								_SalesInvoiceTerm = new TermViewModel();
								_SalesInvoiceTerm.VoucherNo = TxtVoucherNo.Text;
								_SalesInvoiceTerm.TermId = Convert.ToInt32(termCodeArr[i]);
								_SalesInvoiceTerm.Sno = Grid.Rows.IndexOf(ro) + 1;
								_SalesInvoiceTerm.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
								_SalesInvoiceTerm.STSign = termSignArr[i];
								_SalesInvoiceTerm.TermType = "P";
								_SalesInvoiceTerm.TermRate = Convert.ToDecimal(termRatePercentArr[i]);
								_SalesInvoiceTerm.TermAmt = Convert.ToDecimal(termAmountntArr[i]);
								_objSalesInvoice.ModelTerms.Add(_SalesInvoiceTerm);
							}
						}
					}
				}
            }

            if (!string.IsNullOrEmpty(TxtBillTermAmt.Tag.ToString().Trim()))
            {
                string[] val2 = TxtBillTermAmt.Tag.ToString().Trim().Split('|');
                string[] termSignArr = val2[0].Split(',');
                string[] termCodeArr1 = val2[1].Split(',');
                string[] termRatePercentArr1 = val2[2].Split(',');
                string[] termAmountntArr1 = val2[3].Split(',');
                for (int i = 0; i < termCodeArr1.Count(); i++)
                {
                    _SalesInvoiceTerm = new TermViewModel();
                    _SalesInvoiceTerm.VoucherNo = _objSalesInvoice.Model.VoucherNo;
                    _SalesInvoiceTerm.TermId = Convert.ToInt32(termCodeArr1[i]);
                    _SalesInvoiceTerm.Sno = 0;
                    _SalesInvoiceTerm.ProductId = 0;
                    _SalesInvoiceTerm.TermType = "B";
                    decimal.TryParse(termRatePercentArr1[i], out decimal _termRatePercentArr1);
                    decimal.TryParse(termAmountntArr1[i], out decimal _termAmountArr1);
                    _SalesInvoiceTerm.TermRate = _termRatePercentArr1;
                    _SalesInvoiceTerm.TermAmt = _termAmountArr1;
                    _SalesInvoiceTerm.STSign = termSignArr[i];
                    _objSalesInvoice.ModelTerms.Add(_SalesInvoiceTerm);
                }
            }

            _objSalesInvoice.Model.DocId = Convert.ToInt32(TxtVoucherNo.Tag.ToString());
            string output = _objSalesInvoice.SaveSalesInvoice();
            if (string.IsNullOrEmpty(output))
            {
                MessageBox.Show("Error occurred during data submission.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_Tag == "NEW")
                    MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been generated.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (_Tag == "EDIT")
                    MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been updated.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (_Tag == "DELETE")
                    MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been deleted.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_IsSaveAndPrint == 1 && _Tag != "DELETE")
                {
                    DocPrintingOption frm = new DocPrintingOption("SB", "Sales Invoice", TxtVoucherNo.Text);
                    frm.ShowDialog();
                }

                ClearFld();
                if (_Tag == "NEW")
                {
                    this._DocId = Convert.ToInt32(TxtVoucherNo.Tag.ToString());
                    BtnNew.Enabled = true;
                    BtnNew.PerformClick();
                }
                else if (_Tag == "EDIT")
                {
                    BtnEdit.Enabled = true;
                    BtnEdit.PerformClick();
                }
                else if (_Tag == "DELETE")
                {
                    BtnDelete.Enabled = true;
                    BtnDelete.PerformClick();
                }
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
				if (Grid.Rows.Count == 0)
					Grid.Rows.Add();
				e.Handled = true;
                GridControlMode(true);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //LblShortName.Text = ""; LblAltStockQty.Text = ""; LblStockQty.Text = "";
            //if (Grid.CurrentRow.Cells["Particular"].Value != null)
            //{
            //    _objProduct.GetSingleProduct(Grid.CurrentRow.Cells["Particular"].Value.ToString());
            //    LblShortName.Text = _objProduct.Model.ProductShortName;
            //}

            //if (Grid.CurrentRow.Cells["Godown"].Value != null)
            //{
            //    if (Grid.CurrentRow.Cells["Godown"].Value.ToString() != "")
            //    {
            //        _objGodown.GetSingleGodown(Grid.CurrentRow.Cells["Godown"].Value.ToString());
            //    }
            //}

            //-------- START DELETE ROW --------------
            if (Grid.Columns[e.ColumnIndex].Name == "Action")
            {
                if (TxtGridParticular.Visible == true)
                {
                    GridControlMode(false);
                    Grid.Focus();
                }

                if (Grid.Rows.Count > 1)
                {
                    if (Grid.Rows[Grid.CurrentRow.Index].Cells["SNo"].Value != null)
                    {
                        int _sn = int.Parse(Grid.Rows[Grid.CurrentRow.Index].Cells["SNo"].Value.ToString());
                        DataRow[] rows = ClsGlobal.UDFExistingDataTableDetails.Select("SNO ='" + _sn + "'");
                        foreach (var row in rows) { row.Delete(); }

                        ClsGlobal.UDFExistingDataTableDetails.DefaultView.Sort = "SNO ASC";
                        ClsGlobal.UDFExistingDataTableDetails = ClsGlobal.UDFExistingDataTableDetails.DefaultView.ToTable();

                        //re set sn in clsGlobal.UDFDtDtl
                        for (int i = 0; i < ClsGlobal.UDFExistingDataTableDetails.Rows.Count; i++)
                        {
                            ClsGlobal.UDFExistingDataTableDetails.Rows[i]["SNO"] = (i + 1).ToString();
                        }
                    }
                    Grid.Rows.RemoveAt(e.RowIndex);
                    CalTotal();
                }
            }
            //-------- END DELETE ROW --------------
        }
        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            LblShortName.Text = ""; LblAltStockQty.Text = ""; LblStockQty.Text = "";
            if (Grid.Rows.Count > 0)
            {
                if (Grid.CurrentRow.Cells["Particular"].Value != null)
                {
                    if (!string.IsNullOrEmpty(Grid.CurrentRow.Cells["Particular"].Value.ToString()))
                    {
                        LblShortName.Text = Grid.CurrentRow.Cells["ProductShortName"].Value.ToString();
                        if (Grid.CurrentRow.Cells["AltStockQty"] != null)
                            LblAltStockQty.Text = Grid.CurrentRow.Cells["AltStockQty"].Value.ToString();
                        if (Grid.CurrentRow.Cells["StockQty"] != null)
                            LblStockQty.Text = Grid.CurrentRow.Cells["StockQty"].Value.ToString();
                    }
                }
            }
        }
        private void Grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BtnOk.Enabled = false;
            if (TxtGridParticular.Visible == true)
            {
                Grid.Focus();
            }
            if (Grid.Rows.Count > 1)
            {
                if (Grid.Rows[Grid.CurrentRow.Index].Cells["SNo"].Value != null)
                {
                    DataRow[] rows = ClsGlobal.UDFExistingDataTableDetails.Select("SNO ='" + (Convert.ToInt32(Grid.CurrentRow.Index.ToString()) + 1) + "'");
                    foreach (var row in rows) { row.Delete(); }
                    ClsGlobal.UDFExistingDataTableDetails.DefaultView.Sort = "SNO ASC";
                    ClsGlobal.UDFExistingDataTableDetails = ClsGlobal.UDFExistingDataTableDetails.DefaultView.ToTable();
                    for (int i = 0; i < ClsGlobal.UDFExistingDataTableDetails.Rows.Count; i++)
                    {
                        ClsGlobal.UDFExistingDataTableDetails.Rows[i]["SNO"] = (i + 1).ToString();
                    }
                }
                CalTotal();
            }
            BtnOk.Enabled = true;
        }

        private void CalTotal()
        {
            TxtGridBasicAmt.Text = ClsGlobal.DecimalFormate((string.IsNullOrEmpty(TxtGridQty.Text) ? 0 : Convert.ToDecimal(TxtGridQty.Text) * (string.IsNullOrEmpty(TxtGridRate.Text) ? 0 : Convert.ToDecimal(TxtGridRate.Text))), 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtGridNetAmt.Text = ClsGlobal.DecimalFormate((string.IsNullOrEmpty(TxtGridBasicAmt.Text) ? 0 : Convert.ToDecimal(TxtGridBasicAmt.Text) + (string.IsNullOrEmpty(TxtGridTermsAmt.Text) ? 0 : Convert.ToDecimal(TxtGridTermsAmt.Text))), 1, ClsGlobal._AmountDecimalFormat).ToString();
            decimal totalAltqty = 0;
            decimal totalQty = 0;
            decimal totalBasicAmt = 0;
            decimal totalNetAmt = 0;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                // BasicAmt,TermsAmt,NetAmt
                if (ro.Cells["AltQty"].Value != null)
                {
                    totalAltqty += (string.IsNullOrEmpty(ro.Cells["AltQty"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["AltQty"].Value.ToString()));
                }

                if (ro.Cells["Qty"].Value != null)
                {
                    totalQty += (string.IsNullOrEmpty(ro.Cells["Qty"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["Qty"].Value.ToString()));
                }

                if (ro.Cells["BasicAmt"].Value != null)
                {
                    totalBasicAmt += (string.IsNullOrEmpty(ro.Cells["BasicAmt"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["BasicAmt"].Value.ToString()));
                }

                if (ro.Cells["NetAmt"].Value != null)
                {
                    totalNetAmt += (string.IsNullOrEmpty(ro.Cells["NetAmt"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString()));
                }

                ro.Cells["SNo"].Value = Grid.Rows.IndexOf(ro) + 1;
            }

            LblTotalAltQty.Text = ClsGlobal.DecimalFormate(totalAltqty, 1, ClsGlobal._AltQtyDecimalFormat);
            LblTotalQty.Text = ClsGlobal.DecimalFormate(totalQty, 1, ClsGlobal._QtyDecimalFormat);
            LblBasicAmt.Text = ClsGlobal.DecimalFormate(totalNetAmt, 1, ClsGlobal._AmountDecimalFormat);
            //--------- BILL WISE TERM CALCULATION -----------
            if (_dtBillTermExists == "Yes")
            {
                decimal.TryParse(LblTotalQty.Text, out decimal _Qty);
                decimal.TryParse(LblBasicAmt.Text, out decimal _BasicAmt);
                FrmTerm frmterm = new FrmTerm("SALES", _BasicAmt, TxtBillTermAmt.Tag.ToString().Trim(), _Qty, 0);
                TxtBillTermAmt.Text = ClsGlobal.DecimalFormate(frmterm.TermAmount(), 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtBillTermAmt.Tag = frmterm.TermDetails.ToString();
            }
            decimal.TryParse(TxtBillTermAmt.Text, out decimal BillTermAmount);
            LblNetAmt.Text = ClsGlobal.DecimalFormate((totalNetAmt + BillTermAmount), 1, ClsGlobal._AmountDecimalFormat);
            decimal CurrencyRate = (string.IsNullOrEmpty(TxtCurrencyRate.Text) ? 1 : Convert.ToDecimal(TxtCurrencyRate.Text));
            LblLocalNetAmt.Text = ClsGlobal.DecimalFormate(((totalNetAmt + BillTermAmount) * CurrencyRate), 1, ClsGlobal._AmountDecimalFormat);
        }

        private void TxtGridParticular_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtGridParticular) return;
            if (TxtGridParticular.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtGridParticular.Text))
            {
                if (Grid.Rows.Count <= 1)
                {
                    MessageBox.Show("Particular description cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtGridParticular.Focus();
                    return;
                }
                else
                {
                    GridControlMode(false);
                }
            }

            if (!string.IsNullOrEmpty(TxtGridParticular.Text))
            {
                Indexcount = Grid.Rows.Count;
                if (TxtGridParticular.ProductDetails.Count > 0)
                {
                    if (!Grid.Columns["Godown"].Visible)
                    {
                        TxtGridGodown.Text = "";
                    }
                    else if ((Grid.Rows[0].Cells["Godown"].Value == null || Indexcount <= 0 ? false : TxtGridGodown.Text == ""))
                    {
                        if (Indexcount != 1)
                        {
                            TxtGridGodown.Text = Grid.Rows[Indexcount - 2].Cells["Godown"].Value.ToString();
                        }
                        else
                        {
                            TxtGridGodown.Text = Grid.Rows[0].Cells["Godown"].Value.ToString();
                        }
                    }

                    LblShortName.Text = TxtGridParticular.ProductDetails["ProductShortName"].ToString();
                    TxtGridAltUOM.Text = TxtGridParticular.ProductDetails["ProductAltUnit"].ToString();
                    TxtGridAltUOM.Tag = TxtGridParticular.ProductDetails["ProductAltUnitId"].ToString();
                    TxtGridQtyUOM.Text = TxtGridParticular.ProductDetails["ProductUnit"].ToString();
                    TxtGridQtyUOM.Tag = TxtGridParticular.ProductDetails["ProductUnitId"].ToString();
                    TxtGridRate.Text = TxtGridParticular.ProductDetails["SalesRate"].ToString();
                    LblAltStockQty.Text = TxtGridParticular.ProductDetails["AltStockQty"].ToString();
                    LblStockQty.Text = TxtGridParticular.ProductDetails["StockQty"].ToString();
                    TxtGridParticular.ProductDetails.Clear();
                }
                if (!string.IsNullOrEmpty(TxtGridAltUOM.Text))
                {
                    TxtGridAltUOM.Enabled = true;
                    TxtGridAltQty.Enabled = true;
                    Utility.EnableDesibleColor(TxtGridAltUOM, true);
                    Utility.EnableDesibleColor(TxtGridAltQty, true);
                }
                else
                {
                    TxtGridAltUOM.Enabled = false;
                    TxtGridAltQty.Enabled = false;
                    Utility.EnableDesibleColor(TxtGridAltUOM, false);
                    Utility.EnableDesibleColor(TxtGridAltQty, false);
                    if (TxtGridGodown.Visible == false)
                    {
                        TxtGridQty.Focus();
                    }
                }
            }
            else
            {
                BtnBillTerm.PerformClick();
            }
        }

        private void TxtGridGodown_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtGridGodown) return;
            if (!string.IsNullOrEmpty(_Tag.ToString()))
            {
                if ((ClsGlobal.SalesMGodownControlVal == 'Y' || _objLedger.CheckGlContainsSubledger(TxtGridParticular.Text) == "Y") && (string.IsNullOrEmpty(TxtGridGodown.Text)))
                {
                    ClsGlobal.MandatoryMsg("Godown");
                    TxtGridGodown.Focus();
                    return;
                }
            }
            if (!string.IsNullOrEmpty(TxtGridGodown.Text))
            {
                _objGodown.GetSingleGodown(TxtGridGodown.Text);
            }
        }

        private void TxtGridAltQty_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == TxtGridAltQty)
            {
                _StartTermCalculation = true;
            }
        }
        private void TxtGridAltQty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal _convRatio = TxtGridParticular.AltConversion;
            if (ClsGlobal.InventoryAltQtyConversionRatioChange == "Y" && !string.IsNullOrEmpty(TxtGridAltQty.Text))
            {
                ConversionQty frm = new ConversionQty(ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridParticular.ProductQtyConversion), 1, ClsGlobal._QtyDecimalFormat));
                frm.ShowDialog();
                TxtGridParticular.ProductQtyConversion = frm._ConversionQty;
            }

            if (ClsGlobal.InventoryAltQtyConversion == "Y" && Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridAltQty.Text) ? "0" : TxtGridAltQty.Text) * Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }
            else if (ClsGlobal.InventoryAltQtyConversion == "N" && _StartTermCalculation == true && Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridAltQty.Text) ? "0" : TxtGridAltQty.Text) * Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }

            if (!string.IsNullOrEmpty(TxtGridAltQty.Text))
            {
                StartTermCalculation();
            }
        }
        private void TxtGridQty_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == TxtGridQty)
            {
                _StartTermCalculation = true;
            }
        }
        private void TxtGridQty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
			if (!string.IsNullOrEmpty(TxtGridParticular.Text))
			{
				decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
				if (_Qty <= 0)
				{
					TxtGridQty.Focus();
					return;
				}

				decimal _convRatio = TxtGridParticular.AltConversion;
				if (ClsGlobal.InventoryAltQtyConversion == "Y" && TxtGridAltQty.Enabled == true && Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
				{
					TxtGridAltQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridQty.Text) ? "0" : TxtGridQty.Text) / Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) * _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
				}
				StartTermCalculation();
			}
			else
			{
				GridControlMode(false);
				BtnBillTerm.PerformClick();
			}
		
        }
        private void TxtGridRate_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == TxtGridRate)
            {
                _StartTermCalculation = true;
            }

        }
        private void TxtGridRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StartTermCalculation();
        }
        private void TxtGridBasicAmt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TxtGridBasicAmt.ReadOnly == false)
            {
                decimal.TryParse(TxtGridBasicAmt.Text, out decimal _BasicAmt);
                decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
                if (_Qty > 0)
                {
                    TxtGridRate.Text = ClsGlobal.DecimalFormate((_BasicAmt / _Qty), 1, ClsGlobal._RateDecimalFormat).ToString();
                }
            }

            if (_dtProductTermExists == "Yes" && TxtGridParticular.Visible == true && ClsGlobal.AccessSalesTermChange == 1)
            {
                decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
                decimal.TryParse(TxtGridBasicAmt.Text, out decimal _BasicAmt);
                FrmTerm frmterm = new FrmTerm("SALES", _BasicAmt, TxtGridTermsDetails.Text, _Qty, Convert.ToInt32(TxtGridParticular.Tag.ToString()));
                frmterm.ShowDialog();
                frmterm.Dispose();
                TxtGridTermsAmt.Text = ClsGlobal.DecimalFormate(frmterm.TotalTermAmt, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtGridTermsDetails.Text = frmterm.TermDetails;
                decimal.TryParse(TxtGridTermsAmt.Text, out decimal Termamount);
                TxtGridNetAmt.Text = ClsGlobal.DecimalFormate((_BasicAmt + Termamount), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
        }
        private void TxtGridNetAmt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClsGlobal.SalesAdditionalDescControlVal == 'Y')
            {
                string _AdditionalDesc = "";
                if (Grid.CurrentRow.Cells["AdditionalDesc"].Value != null)
                {
                    _AdditionalDesc = Grid.CurrentRow.Cells["AdditionalDesc"].Value.ToString();
                }

                FrmAdditionalDesc frmAdditionalDesc = new FrmAdditionalDesc(TxtGridParticular.Tag.ToString(), _AdditionalDesc);
                frmAdditionalDesc.ShowDialog();
                Grid.CurrentRow.Cells["AdditionalDesc"].Value = frmAdditionalDesc._AdditionalDesc;
            }

            if (SetTextBoxValueToGrid() == true)
            {
                if (Grid.CurrentRow.Index == (Grid.Rows.Count - 1))
                {
                    Grid.Rows.Add();
                    Grid.CurrentCell = Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"];
                }
                else
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["Particular"];
                }

                #region ---------------- UDF --------------------
                int _SNo = int.Parse(Grid.Rows[Grid.CurrentRow.Index - 1].Cells["SNo"].Value.ToString());
                if (DTUDFDetails.Rows.Count > 0)
                {
                    FrmUDFDetailEntry frm = new FrmUDFDetailEntry("Sales Details Global", _VoucherNo, _SNo);
                    frm.ShowDialog();
                }
                #endregion

                GridControlMode(_GridControlMode);

                //if (Grid.CurrentRow.Index == (Grid.Rows.Count - 1) && !string.IsNullOrEmpty(TxtChallanNo.Text))
                //{
                //    GridControlMode(false);
                //    BtnBillTerm.PerformClick();
                //}
                //TotalAmtAndTotalAmtInRs();
            }
        }

        private void TxtCurrency_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtCurrency) return;
            ClsButtonClick.CurrencyValidating(TxtCurrency, TxtCurrencyRate, LblNetAmt, LblLocalNetAmt, "SALES", e);
        }

        private void TxtCurrencyRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtCurrencyRate) return;
            ClsButtonClick.CurrencyRateValidating(TxtCurrency, TxtCurrencyRate, LblNetAmt, LblLocalNetAmt, e);
        }

        private void TxtSalesman_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtSalesman) return;
            ClsButtonClick.SalesmanValidating(TxtSalesman, e);
        }

        private void TxtSubledger_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtSubledger || string.IsNullOrEmpty(TxtCustomer.Text)) return;
            ClsButtonClick.SubledgerValidating(TxtSubledger, _isSubledgerRequired, "SALES", e);
        }

        private void TxtDepartment_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDepartment) return;
            if (TxtDepartment.Enabled == false) return;
            if (ClsGlobal.SalesMDepartmentControlVal == 'Y' && string.IsNullOrEmpty(TxtDepartment.Text))
            {
                MessageBox.Show("Department cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDepartment.Focus();
            }
        }

        private void TxtOrderNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtOrderNo) return;
            if (TxtOrderNo.Enabled == false) return;
            if (ClsGlobal.SalesMOrderControlVal == 'Y' && string.IsNullOrEmpty(TxtOrderNo.Text.Trim()))
            {
                MessageBox.Show("Order no cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtOrderNo.Focus();
            }

            if (!string.IsNullOrEmpty(TxtOrderNo.Text.Trim()))
            {
				//if (TxtOrderNo.Tag.ToString() != TxtOrderNo.Text.Trim())
				//{
					DataSet ds = _objSalesOrder.GetDataOrderForSales(TxtOrderNo.Text.Trim(),TxtVoucherNo.Text,"SB");
					Grid.Rows.Clear();
					Grid.Rows.Add();
					SetDataSalesOrder(ds);
				//}
			}
        }

        private void TxtChallanNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtChallanNo) return;
            if (TxtChallanNo.Enabled == false) return;
            if (ClsGlobal.SalesMChallanControlVal == 'Y' && string.IsNullOrEmpty(TxtChallanNo.Text))
            {
                MessageBox.Show("Challan No cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtChallanNo.Focus();
            }
			if (!string.IsNullOrEmpty(TxtChallanNo.Text.Trim()))
			{
				if (this._Tag == "NEW")
				{
					DataSet ds = _objSalesChallan.GetDataSalesChallanVoucher(TxtChallanNo.Text.Trim());
					Grid.Rows.Clear();
					Grid.Rows.Add();
					Grid.Enabled = false;
					SetDataSalesChallan(ds);
				}
				else
					Grid.Enabled = false;

				TxtOrderNo.Enabled = false;
				Utility.EnableDesibleColor(TxtOrderNo, false);
				BtnOrderNoSearch.Enabled = false;

			}

		}

        private void TxtRemarks_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtRemarks) { return; }
            ClsButtonClick.RemarksValidating(TxtRemarks, "SALES", e);
            BtnOk.Enabled = true;
        }

        private void TxtBillTermAmt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BtnOk.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Sales Invoice [DELETE]";
            TxtVoucherNo.Enabled = true;
            BtnVoucherNoSearch.Enabled = true;
            TxtVoucherNo.Focus();
            BtnUDF.Enabled = false;
            BtnOk.Enabled = true;
            BtnCancel.Enabled = true;
            Grid.Enabled = false;
        }

        private void BtnBillTerm_Click(object sender, EventArgs e)
        {
            decimal.TryParse(LblTotalQty.Text, out decimal _Qty);
            if (_dtBillTermExists == "Yes" && ClsGlobal.AccessSalesTermChange == 1 && _Qty > 0)
            {
                decimal.TryParse(LblBasicAmt.Text, out decimal _BasicAmt);
                FrmTerm frmterm = new FrmTerm("SALES", _BasicAmt, TxtBillTermAmt.Tag.ToString(), _Qty, 0);
                frmterm.ShowDialog();
                frmterm.Dispose();
                TxtBillTermAmt.Text = ClsGlobal.DecimalFormate(frmterm.TotalTermAmt, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtBillTermAmt.Tag = frmterm.TermDetails.ToString();
                decimal _CurrencyRate = (string.IsNullOrEmpty(TxtCurrencyRate.Text) ? 1 : Convert.ToDecimal(TxtCurrencyRate.Text));
                LblNetAmt.Text = ClsGlobal.DecimalFormate((_BasicAmt + frmterm.TotalTermAmt), 1, ClsGlobal._AmountDecimalFormat).ToString();
                LblLocalNetAmt.Text = ClsGlobal.DecimalFormate(((_BasicAmt + frmterm.TotalTermAmt) * _CurrencyRate), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
        }

        public void StartTermCalculation()
        {
            if (_StartTermCalculation == true)
            {
                decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
                decimal.TryParse(TxtGridRate.Text, out decimal _Rate);
                TxtGridBasicAmt.Text = ClsGlobal.DecimalFormate((_Qty * _Rate), 1, ClsGlobal._AmountDecimalFormat).ToString();
                FrmTerm frmterm = new FrmTerm("SALES", (_Qty * _Rate), TxtGridTermsDetails.Text, _Qty, Convert.ToInt32(TxtGridParticular.Tag.ToString()));
                TxtGridTermsAmt.Text = ClsGlobal.DecimalFormate(frmterm.TermAmount(), 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtGridTermsDetails.Text = frmterm.TermDetails;
                decimal.TryParse(TxtGridTermsAmt.Text, out decimal Termamount);
                TxtGridNetAmt.Text = ClsGlobal.DecimalFormate(((_Qty * _Rate) + Termamount), 1, ClsGlobal._AmountDecimalFormat).ToString();
                _StartTermCalculation = false;
            }
        }

        private void TxtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmDepartment frm = new FrmDepartment();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtDepartment.Text = frm._NewDepartment;
                TxtDepartment.Tag = frm._DepartmentId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtDepartment, BtnDepartmentSearch, false);
            }
        }

        private void BtnUDF_Click(object sender, EventArgs e)
        {
            string _odrno = ClsGlobal.GetOrderNoFrmGrid(Grid);
            if (_Tag == "NEW" && !string.IsNullOrEmpty(TxtChallanNo.Text))
            {
                GetUDFMasterDataforChallan();
            }
            else if (_Tag == "NEW" && !string.IsNullOrEmpty(_odrno))
            {
                string[] a = _odrno.Split(',');
                GetUDFMasterDataforOrder(a[1]);
            }
            else
            {
                FrmUDFMasterEntry frm = new FrmUDFMasterEntry("Sales Master Global", _VoucherNo, "SB");
                frm.ShowDialog();
            }
            BtnOk.Focus();
        }

        private void TxtMiti_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtMiti) return;
            ClsGlobal.MitiValidation(TxtMiti, TxtDate);
        }

        private void TxtDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDate) return;
            ClsGlobal.DateValidation(TxtDate, TxtMiti);
        }

        private void TxtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtOrderNo, BtnOrderNoSearch, false);
        }

        private void GetUDFMasterDataforChallan()
        {
            string[] ss = { };
            if (_ChallanNo.Contains(','))
            {
                ss = _ChallanNo.Split(',');
                _ChallanNo = ss[0];
            }

            FrmUDFMasterEntry frm = new FrmUDFMasterEntry("Sales Master Global", _VoucherNo, "SC");
            frm.ShowDialog();
            ClsGlobal.UDFExistingDataMaster.Rows.Clear();
            DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();
            dr[0] = 0;
            for (int i = 0; i < ClsGlobal.FieldNameArrMaster.Count(); i++)
            {
                if (i == 0)
                {
                    dr[i + 1] = ClsGlobal.FieldNameArrMaster[i];
                    dr[i + 2] = ClsGlobal.UDFDataArrMaster[i];
                }
                else
                {
                    dr[i + 2 + (i - 1)] = ClsGlobal.FieldNameArrMaster[i];
                    dr[i + 3 + (i - 1)] = ClsGlobal.UDFDataArrMaster[i];
                }
            }
            //ClsGlobal.UDFExistingDataMaster.Rows.Add(dr);
            //DataAccessLayer.DataTransaction.SalesUDfViewModel SalesUDf = null;
            //_objSalesInvoice.SalesUDfs.Clear();
            //for (int i = 0; i < ClsGlobal.UDFDataArrMaster.Count; i++)
            //{
            //    SalesUDf = new DataAccessLayer.DataTransaction.SalesUDfViewModel();
            //    SalesUDf.Sb_invNo = _objSalesInvoice.Model.VoucherNo;
            //    SalesUDf.UDF_Code = ClsGlobal.FieldNameArrMaster[i];
            //    SalesUDf.SNO = 0;
            //    SalesUDf.P_Code = "";
            //    SalesUDf.Source = "SB";
            //    SalesUDf.UDF_Data = ClsGlobal.UDFDataArrMaster[i];
            //    _objSalesInvoice.SalesUDfs.Add(SalesUDf);
            //}
        }

		private void TxtChallanNo_KeyDown(object sender, KeyEventArgs e)
		{
			_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
			ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtChallanNo, BtnChallanNoSearch, false);

		}

		private void GetUDFMasterDataforOrder(string _orderno)
        {
            FrmUDFMasterEntry frm = new FrmUDFMasterEntry("Sales Master Global", _VoucherNo, "SO");
            frm.ShowDialog();
            ClsGlobal.UDFExistingDataMaster.Rows.Clear();
            DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();
            dr[0] = 0;
            for (int i = 0; i < ClsGlobal.FieldNameArrMaster.Count(); i++)
            {
                if (i == 0)
                {
                    dr[i + 1] = ClsGlobal.FieldNameArrMaster[i];
                    dr[i + 2] = ClsGlobal.UDFDataArrMaster[i];
                }
                else
                {
                    dr[i + 2 + (i - 1)] = ClsGlobal.FieldNameArrMaster[i];
                    dr[i + 3 + (i - 1)] = ClsGlobal.UDFDataArrMaster[i];
                }
            }
        }

		private void TxtContactDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void TxtDueDays_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDueDays) return;
            if (TxtDueDays.Text == "0" || string.IsNullOrEmpty(TxtDueDays.Text))
            {
                TxtDueDate.Text = TxtDate.Text;
                TxtDueMiti.Text = TxtMiti.Text;
            }
            else
            {
                DueDateCalculate();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DocPrintingOption frm = new DocPrintingOption("SB", "Sales Invoice", "");
            frm.ShowDialog();
        }

        private void DueDateCalculate()
        {
            if (ClsGlobal.DateType == "M")
            {
                TxtDueMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtDate.Text).AddDays(string.IsNullOrEmpty(TxtDueDays.Text) ? 0 : Convert.ToInt32(TxtDueDays.Text)));
                TxtDueDate.Text = Convert.ToDateTime(TxtDate.Text).AddDays(string.IsNullOrEmpty(TxtDueDays.Text) ? 0 : Convert.ToInt32(TxtDueDays.Text)).ToShortDateString();
            }
            else
            {
                TxtDueDate.Text = Convert.ToDateTime(TxtDate.Text).AddDays(string.IsNullOrEmpty(TxtDueDays.Text) ? 0 : Convert.ToInt32(TxtDueDays.Text)).ToShortDateString();
                TxtDueMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtDate.Text).AddDays(string.IsNullOrEmpty(TxtDueDays.Text) ? 0 : Convert.ToInt32(TxtDueDays.Text)));
            }
        }

        private void SetData(DataSet ds)
        {
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];
            DataTable dtTerm = ds.Tables[2];

            DataRow[] dtUDFMaster = ds.Tables[3].Select("SNO=0");
            DataRow[] dtUDFDetails = ds.Tables[3].Select("SNO<>0");
            DataTable dtOtherDetail = ds.Tables[4];
            DataTable dtBillingaddress = ds.Tables[5];

            if (dtUDFDetails.Count() > 0)
            {
                foreach (DataRow drDetails in dtDetails.Rows)
                {
                    string sno = drDetails["SNo"].ToString();
                    DataRow[] dtUDFDetails1 = ds.Tables[3].Select("SNO=" + drDetails["SNo"].ToString() + "");
                    DataRow dr = ClsGlobal.UDFExistingDataTableDetails.NewRow();
                    dr[0] = drDetails["SNo"].ToString();
                    for (int i = 0; i < dtUDFDetails1.Count(); i++)
                    {
                        if (i == 0)
                        {
                            dr[i + 1] = dtUDFDetails1[i]["UDFCode"];
                            dr[i + 2] = dtUDFDetails1[i]["UDFData"];
                        }
                        else
                        {
                            dr[i + 2 + (i - 1)] = dtUDFDetails1[i]["UDFCode"];
                            dr[i + 3 + (i - 1)] = dtUDFDetails1[i]["UDFData"];
                        }
                    }
                    ClsGlobal.UDFExistingDataTableDetails.Rows.Add(dr);
                }
            }

            if (dtUDFMaster.Count() > 0)
            {
                DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();
                dr[0] = 0;
                for (int i = 0; i < dtUDFMaster.Count(); i++)
                {
                    if (i == 0)
                    {
                        dr[i + 1] = dtUDFMaster[i]["UDFCode"];
                        dr[i + 2] = dtUDFMaster[i]["UDFData"];
                    }
                    else
                    {
                        dr[i + 2 + (i - 1)] = dtUDFMaster[i]["UDFCode"];
                        dr[i + 3 + (i - 1)] = dtUDFMaster[i]["UDFData"];
                    }
                }
                ClsGlobal.UDFExistingDataMaster.Rows.Add(dr);
            }

            TxtVoucherNo.Text = dtMaster.Rows[0]["VoucherNo"].ToString();
            _VoucherNo = dtMaster.Rows[0]["VoucherNo"].ToString();
            TxtDate.Text = dtMaster.Rows[0]["VDate"].ToString();
            TxtMiti.Text = dtMaster.Rows[0]["VMiti"].ToString();
            TxtDueDays.Text = dtMaster.Rows[0]["DueDay"].ToString();
            TxtDueDate.Text = dtMaster.Rows[0]["DueDate"].ToString();
            TxtDueMiti.Text = dtMaster.Rows[0]["DueMiti"].ToString();
            TxtCustomer.Text = dtMaster.Rows[0]["GlDesc"].ToString();
            TxtCustomer.Tag = dtMaster.Rows[0]["LedgerId"].ToString();
            this._GlCategory = dtMaster.Rows[0]["GlCategory"].ToString();
            TxtSalesman.Text = dtMaster.Rows[0]["SalesmanDesc"].ToString();
            TxtSalesman.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["salesmanId"].ToString()) ? "0" : dtMaster.Rows[0]["salesmanId"].ToString();
            TxtSubledger.Text = dtMaster.Rows[0]["SubLedgerDesc"].ToString();
            TxtSubledger.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["SubledgerId"].ToString()) ? "0" : dtMaster.Rows[0]["SubledgerId"].ToString();
            CmbInvoiceType.Text = dtMaster.Rows[0]["InvoiceType"].ToString();
			TxtOrderNo.Text = dtMaster.Rows[0]["OrderNo"].ToString();
			TxtOrderNo.Tag = dtMaster.Rows[0]["OrderNo"].ToString();
			TxtChallanNo.Text = dtMaster.Rows[0]["ChallanNo"].ToString();
			TxtChallanNo.Tag = dtMaster.Rows[0]["ChallanNo"].ToString();

			CashPartyViewModel.PartyName = dtMaster.Rows[0]["PartyName"].ToString();
            CashPartyViewModel.PartyAddress = dtMaster.Rows[0]["PartyAddress"].ToString();
            CashPartyViewModel.PartyVatNo = dtMaster.Rows[0]["PartyVatNo"].ToString();
            CashPartyViewModel.ChequeNo = dtMaster.Rows[0]["ChequeNo"].ToString();
            CashPartyViewModel.ChequeDate = null; //(!string.IsNullOrEmpty(dtMaster.Rows[0]["ChequeDate"].ToString())) ? Convert.ToDateTime(dtMaster.Rows[0]["ChequeDate"].ToString()):null;
            CashPartyViewModel.PartyMobileNo = dtMaster.Rows[0]["PartyMobileNo"].ToString();
            CashPartyViewModel.PartyEmail = dtMaster.Rows[0]["PartyEmail"].ToString();

            DataTable dt = _objGeneralLedger.GetCurrrentBalance(Convert.ToInt32(TxtCustomer.Tag.ToString()), Convert.ToDateTime(TxtDate.Text), ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            LblCurrentBalance.Text = Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()) >= 0 ? ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Dr" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Cr";
            LblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
            LblCreditLimit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CreditLimit"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

            if (string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc4"].ToString()))
            {
                string[] Dept = new string[] { dtMaster.Rows[0]["DepartmentDesc1"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc2"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString() };
                TxtDepartment.Text = string.Concat(Dept);
                string[] Depttag = new string[] { dtMaster.Rows[0]["DepartmentId1"].ToString(), "|", dtMaster.Rows[0]["DepartmentId2"].ToString(), "|", dtMaster.Rows[0]["DepartmentId3"].ToString(), "|", dtMaster.Rows[0]["DepartmentId4"].ToString() };
                TxtDepartment.Tag = string.Concat(Depttag);
            }

            TxtCurrency.Text = dtMaster.Rows[0]["CurrencyDesc"].ToString();
            TxtCurrency.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyId"].ToString()) ? "0" : dtMaster.Rows[0]["CurrencyId"].ToString();
            if (!string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyDesc"].ToString()))
            {
                if (Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()) != 1)
                    TxtCurrencyRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()), 1, ClsGlobal._CurrencyDecimalFormat);
            }
            else
            {
                TxtCurrencyRate.Text = "";
            }

            TxtRemarks.Text = dtMaster.Rows[0]["Remarks"].ToString();

            LblBasicAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["BasicAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            LblNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            LblLocalNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["LocalNetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

            DataRow[] BillTerm = dtTerm.Select("TermType='B'");
            string STSign = "", TermId = "", TermRate = "", TermAmt = "", BillTermDetails = "";
            if (BillTerm.Count() > 0)
            {
                for (int i = 0; i < BillTerm.Count(); i++)
                {
                    STSign += "," + BillTerm[i]["STSign"].ToString().Trim(); TermId += "," + BillTerm[i]["TermId"].ToString().Trim(); TermRate += "," + BillTerm[i]["TermRate"].ToString().Trim(); TermAmt += "," + BillTerm[i]["TermAmt"].ToString().Trim();
                }
                BillTermDetails = STSign.Substring(1) + "|" + TermId.Substring(1) + "|" + TermRate.Substring(1) + "|" + TermAmt.Substring(1);
            }
            else
            {
                BillTermDetails = "";
            }
            TxtBillTermAmt.Tag = BillTermDetails;
            TxtBillTermAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            decimal _TotalQty = 0, _TotalAltQty = 0;
            foreach (DataRow drDetails in dtDetails.Rows)
            {
                DataRow[] ProductTerm = dtTerm.Select("SNo=" + Grid.Rows.Count.ToString() + " and TermType='P'");
                STSign = ""; TermId = ""; TermRate = ""; TermAmt = "";
                string ProductTermDetails = "";
                if (ProductTerm.Count() > 0)
                {
                    for (int i = 0; i < ProductTerm.Count(); i++)
                    {
                        STSign += "," + ProductTerm[i]["STSign"].ToString().Trim(); TermId += "," + ProductTerm[i]["TermId"].ToString().Trim(); TermRate += "," + ProductTerm[i]["TermRate"].ToString().Trim(); TermAmt += "," + ProductTerm[i]["TermAmt"].ToString().Trim();
                    }
                    ProductTermDetails = STSign.Substring(1) + "|" + TermId.Substring(1) + "|" + TermRate.Substring(1) + "|" + TermAmt.Substring(1);
                }
                else
                {
                    ProductTermDetails = "";
                }

                _TotalAltQty = _TotalQty + Convert.ToDecimal(drDetails["AltQty"].ToString());
                _TotalQty = _TotalQty + Convert.ToDecimal(drDetails["Qty"].ToString());

                Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltConversion"].Value = drDetails["AltConv"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Godown"].Value = drDetails["GodownDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["GodownId"].Value = drDetails["GodownId"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltUOM"].Value = drDetails["ProductAltUnitDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductAltUnitId"].Value = drDetails["ProductAltUnit"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["QtyUOM"].Value = drDetails["ProductUnitDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["QtyConversion"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["ConversionRatio"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRate"].ToString()), 1, ClsGlobal._RateDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["TermsAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["TermDetails"].Value = ProductTermDetails;
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltStockQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["StockQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["OrderNo"].Value = drDetails["OrderNo"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["OrderSNo"].Value = drDetails["OrderSno"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ChallanNo"].Value = drDetails["ChallanNo"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ChallanSNo"].Value = drDetails["ChallanSno"].ToString();

				Grid.Rows.Add();
            }

            if (dtOtherDetail.Rows.Count > 0)
            {
                TxtTransport.Text = dtOtherDetail.Rows[0]["Transport"].ToString();
                TxtVehicleNo.Text = dtOtherDetail.Rows[0]["VehicleNo"].ToString();
                TxtPackage.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["Package"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["Package"].ToString()).ToString("0.00");
                TxtCnNo.Text = dtOtherDetail.Rows[0]["CnNo"].ToString();
                TxtCnDate.Text = dtOtherDetail.Rows[0]["CnDate"].ToString();
                TxtCnFreight.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["CnFreight"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["CnFreight"].ToString()).ToString("0.00");
                if (dtOtherDetail.Rows[0]["CnType"].ToString() == "D")
                    CmbCnType.Text = "Due";
                else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "T")
                    CmbCnType.Text = "To Pay";
                else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "P")
                    CmbCnType.Text = "Paid";
                else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "F")
                    CmbCnType.Text = "Free";
                else if (string.IsNullOrEmpty(dtOtherDetail.Rows[0]["CnType"].ToString()))
                    CmbCnType.Text = "";

                TxtAdvance.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["Advance"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["Advance"].ToString()).ToString("0.00");
                TxtBalFreight.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["BalFreight"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["BalFreight"].ToString()).ToString("0.00");
                TxtDriverName.Tag = dtOtherDetail.Rows[0]["DriverName"].ToString();
                TxtDriverLicenseNo.Text = dtOtherDetail.Rows[0]["DriverLicNo"].ToString();
                TxtDriverMobileNo.Text = dtOtherDetail.Rows[0]["DriverMobileNo"].ToString();
                TxtContactNo.Text = dtOtherDetail.Rows[0]["ContractNo"].ToString();
                TxtContactDate.Text = dtOtherDetail.Rows[0]["ContractDate"].ToString();
                TxtExportInvNo.Text = dtOtherDetail.Rows[0]["ExpInvNo"].ToString();
                TxtExportInvDate.Text = dtOtherDetail.Rows[0]["ExpInvDate"].ToString();
                TxtPONo.Text = dtOtherDetail.Rows[0]["PoNo"].ToString();
                TxtPODate.Text = dtOtherDetail.Rows[0]["PoDate"].ToString();
                TxtDocBank.Text = dtOtherDetail.Rows[0]["DocBank"].ToString();
                TxtLCNo.Text = dtOtherDetail.Rows[0]["LcNo"].ToString();
                TxtCustomerName.Text = dtOtherDetail.Rows[0]["CustomName"].ToString();
                TxtCoFd.Text = dtOtherDetail.Rows[0]["Cofd"].ToString();
            }
            if (dtBillingaddress.Rows.Count > 0)
            {
                TxtBillingAddress.Text = dtBillingaddress.Rows[0]["BillingAddress"].ToString();
                TxtBillingCity.Text = dtBillingaddress.Rows[0]["BillingCity"].ToString();
                TxtBillingState.Text = dtBillingaddress.Rows[0]["BillingState"].ToString();
                TxtBillingCountry.Text = dtBillingaddress.Rows[0]["BillingCountry"].ToString();
                TxtBillingEmail.Text = dtBillingaddress.Rows[0]["BillingEmail"].ToString();
                TxtShippingAddress.Text = dtBillingaddress.Rows[0]["ShippingAddress"].ToString();
                TxtShippingCity.Text = dtBillingaddress.Rows[0]["ShippingCity"].ToString();
                TxtShippingState.Text = dtBillingaddress.Rows[0]["ShippingState"].ToString();
                TxtShippingCountry.Text = dtBillingaddress.Rows[0]["ShippingCountry"].ToString();
                TxtShippingEmail.Text = dtBillingaddress.Rows[0]["ShippingEmail"].ToString();
            }

            LblTotalAltQty.Text = ClsGlobal.DecimalFormate(_TotalAltQty, 1, ClsGlobal._AltQtyDecimalFormat).ToString();
            LblTotalQty.Text = ClsGlobal.DecimalFormate(_TotalQty, 1, ClsGlobal._QtyDecimalFormat).ToString();
        }

		private void SetDataSalesOrder(DataSet ds)
		{
			DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];
            DataTable dtTerm = ds.Tables[2];
            DataRow[] dtUDFMaster = ds.Tables[3].Select("SNO=0");
            DataRow[] dtUDFDetails = ds.Tables[3].Select("SNO<>0");
            DataTable dtOtherDetail = ds.Tables[4];
            DataTable dtBillingaddress = ds.Tables[5];
            if (dtUDFDetails.Count() > 0)
            {
                foreach (DataRow drDetails in dtDetails.Rows)
                {
                    string sno = drDetails["SNo"].ToString();
                    DataRow[] dtUDFDetails1 = ds.Tables[3].Select("SNO=" + drDetails["SNo"].ToString() + "");
                    DataRow dr = ClsGlobal.UDFExistingDataTableDetails.NewRow();
                    dr[0] = drDetails["SNo"].ToString();
                    for (int i = 0; i < dtUDFDetails1.Count(); i++)
                    {
                        if (i == 0)
                        {
                            dr[i + 1] = dtUDFDetails1[i]["UDFCode"];
                            dr[i + 2] = dtUDFDetails1[i]["UDFData"];
                        }
                        else
                        {
                            dr[i + 2 + (i - 1)] = dtUDFDetails1[i]["UDFCode"];
                            dr[i + 3 + (i - 1)] = dtUDFDetails1[i]["UDFData"];
                        }
                    }
                    ClsGlobal.UDFExistingDataTableDetails.Rows.Add(dr);
                }
            }

            if (dtUDFMaster.Count() > 0)
            {
                DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();
                dr[0] = 0;
                for (int i = 0; i < dtUDFMaster.Count(); i++)
                {
                    if (i == 0)
                    {
                        dr[i + 1] = dtUDFMaster[i]["UDFCode"];
                        dr[i + 2] = dtUDFMaster[i]["UDFData"];
                    }
                    else
                    {
                        dr[i + 2 + (i - 1)] = dtUDFMaster[i]["UDFCode"];
                        dr[i + 3 + (i - 1)] = dtUDFMaster[i]["UDFData"];
                    }
                }
                ClsGlobal.UDFExistingDataMaster.Rows.Add(dr);
            }

            //TxtVoucherNo.Text = dtMaster.Rows[0]["VoucherNo"].ToString();
            //_VoucherNo = dtMaster.Rows[0]["VoucherNo"].ToString();
            //TxtDate.Text = dtMaster.Rows[0]["VDate"].ToString();
            //TxtMiti.Text = dtMaster.Rows[0]["VMiti"].ToString();
            TxtDueDays.Text = "0";
            TxtDueDate.Text = TxtDate.Text;
            TxtDueMiti.Text = TxtMiti.Text;
            TxtCustomer.Text = dtMaster.Rows[0]["GlDesc"].ToString();
            TxtCustomer.Tag = dtMaster.Rows[0]["LedgerId"].ToString();
            this._GlCategory = dtMaster.Rows[0]["GlCategory"].ToString();
            TxtSalesman.Text = dtMaster.Rows[0]["SalesmanDesc"].ToString();
            TxtSalesman.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["salesmanId"].ToString()) ? "0" : dtMaster.Rows[0]["salesmanId"].ToString();
            TxtSubledger.Text = dtMaster.Rows[0]["SubLedgerDesc"].ToString();
            TxtSubledger.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["SubledgerId"].ToString()) ? "0" : dtMaster.Rows[0]["SubledgerId"].ToString();
            //CmbInvoiceType.Text = dtMaster.Rows[0]["InvoiceType"].ToString();

            CashPartyViewModel.PartyName = dtMaster.Rows[0]["PartyName"].ToString();
            CashPartyViewModel.PartyAddress = dtMaster.Rows[0]["PartyAddress"].ToString();
            CashPartyViewModel.PartyVatNo = dtMaster.Rows[0]["PartyVatNo"].ToString();
            CashPartyViewModel.ChequeNo = dtMaster.Rows[0]["ChequeNo"].ToString();
            CashPartyViewModel.ChequeDate = null; //(!string.IsNullOrEmpty(dtMaster.Rows[0]["ChequeDate"].ToString())) ? Convert.ToDateTime(dtMaster.Rows[0]["ChequeDate"].ToString()):null;
            CashPartyViewModel.PartyMobileNo = dtMaster.Rows[0]["PartyMobileNo"].ToString();
            CashPartyViewModel.PartyEmail = dtMaster.Rows[0]["PartyEmail"].ToString();

            DataTable dt = _objGeneralLedger.GetCurrrentBalance(Convert.ToInt32(TxtCustomer.Tag.ToString()), Convert.ToDateTime(TxtDate.Text), ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            LblCurrentBalance.Text = Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()) >= 0 ? ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Dr" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Cr";
            LblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
            LblCreditLimit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CreditLimit"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

            if (string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc4"].ToString()))
            {
                string[] Dept = new string[] { dtMaster.Rows[0]["DepartmentDesc1"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc2"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString() };
                TxtDepartment.Text = string.Concat(Dept);
                string[] Depttag = new string[] { dtMaster.Rows[0]["DepartmentId1"].ToString(), "|", dtMaster.Rows[0]["DepartmentId2"].ToString(), "|", dtMaster.Rows[0]["DepartmentId3"].ToString(), "|", dtMaster.Rows[0]["DepartmentId4"].ToString() };
                TxtDepartment.Tag = string.Concat(Depttag);
            }

            TxtCurrency.Text = dtMaster.Rows[0]["CurrencyDesc"].ToString();
            TxtCurrency.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyId"].ToString()) ? "0" : dtMaster.Rows[0]["CurrencyId"].ToString();
            if (!string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyDesc"].ToString()))
            {
                if (Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()) != 1)
                    TxtCurrencyRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()), 1, ClsGlobal._CurrencyDecimalFormat);
            }
            else
            {
                TxtCurrencyRate.Text = "";
            }

            TxtRemarks.Text = dtMaster.Rows[0]["Remarks"].ToString();

            LblBasicAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["BasicAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            LblNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            LblLocalNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["LocalNetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

            DataRow[] BillTerm = dtTerm.Select("TermType='B'");
            string STSign = "", TermId = "", TermRate = "", TermAmt = "", BillTermDetails = "";
            if (BillTerm.Count() > 0)
            {
                for (int i = 0; i < BillTerm.Count(); i++)
                {
                    STSign += "," + BillTerm[i]["STSign"].ToString().Trim(); TermId += "," + BillTerm[i]["TermId"].ToString().Trim(); TermRate += "," + BillTerm[i]["TermRate"].ToString().Trim(); TermAmt += "," + BillTerm[i]["TermAmt"].ToString().Trim();
                }
                BillTermDetails = STSign.Substring(1) + "|" + TermId.Substring(1) + "|" + TermRate.Substring(1) + "|" + TermAmt.Substring(1);
            }
            else
            {
                BillTermDetails = "";
            }
            TxtBillTermAmt.Tag = BillTermDetails;
            TxtBillTermAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            decimal _TotalQty = 0, _TotalAltQty = 0;
            foreach (DataRow drDetails in dtDetails.Rows)
            {
                DataRow[] ProductTerm = dtTerm.Select("SNo=" + Grid.Rows.Count.ToString() + " and TermType='P'");
                STSign = ""; TermId = ""; TermRate = ""; TermAmt = "";
                string ProductTermDetails = "";
                if (ProductTerm.Count() > 0)
                {
                    for (int i = 0; i < ProductTerm.Count(); i++)
                    {
                        STSign += "," + ProductTerm[i]["STSign"].ToString().Trim(); TermId += "," + ProductTerm[i]["TermId"].ToString().Trim(); TermRate += "," + ProductTerm[i]["TermRate"].ToString().Trim(); TermAmt += "," + ProductTerm[i]["TermAmt"].ToString().Trim();
                    }
                    ProductTermDetails = STSign.Substring(1) + "|" + TermId.Substring(1) + "|" + TermRate.Substring(1) + "|" + TermAmt.Substring(1);
                }
                else
                {
                    ProductTermDetails = "";
                }

                _TotalAltQty = _TotalQty + Convert.ToDecimal(drDetails["AltQty"].ToString());
                _TotalQty = _TotalQty + Convert.ToDecimal(drDetails["Qty"].ToString());

                Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltConversion"].Value = drDetails["AltConv"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Godown"].Value = drDetails["GodownDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["GodownId"].Value = drDetails["GodownId"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltUOM"].Value = drDetails["ProductAltUnitDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductAltUnitId"].Value = drDetails["ProductAltUnit"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["QtyUOM"].Value = drDetails["ProductUnitDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["QtyConversion"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["ConversionRatio"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRate"].ToString()), 1, ClsGlobal._RateDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
				decimal.TryParse(drDetails["Qty"].ToString(), out decimal _Qty);
				decimal.TryParse(drDetails["SalesRate"].ToString(), out decimal _Rate);
				TxtGridBasicAmt.Text = ClsGlobal.DecimalFormate((_Qty * _Rate), 1, ClsGlobal._AmountDecimalFormat).ToString();
				FrmTerm frmterm = new FrmTerm("SALES", (_Qty * _Rate), ProductTermDetails, _Qty, Convert.ToInt32(drDetails["ProductId"].ToString()));
				decimal _TermAmount = frmterm.TermAmount();
				Grid.Rows[Grid.Rows.Count - 1].Cells["TermsAmt"].Value = ClsGlobal.DecimalFormate(_TermAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(((_Qty * _Rate) + _TermAmount), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["TermDetails"].Value = frmterm.TermDetails;
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltStockQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["StockQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["OrderNo"].Value = drDetails["VoucherNo"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["OrderSNo"].Value = drDetails["Sno"].ToString();
                Grid.Rows.Add();
			}

            if (dtOtherDetail.Rows.Count > 0)
            {
                TxtTransport.Text = dtOtherDetail.Rows[0]["Transport"].ToString();
                TxtVehicleNo.Text = dtOtherDetail.Rows[0]["VehicleNo"].ToString();
                TxtPackage.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["Package"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["Package"].ToString()).ToString("0.00");
                TxtCnNo.Text = dtOtherDetail.Rows[0]["CnNo"].ToString();
                TxtCnDate.Text = dtOtherDetail.Rows[0]["CnDate"].ToString();
                TxtCnFreight.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["CnFreight"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["CnFreight"].ToString()).ToString("0.00");
                if (dtOtherDetail.Rows[0]["CnType"].ToString() == "D")
                    CmbCnType.Text = "Due";
                else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "T")
                    CmbCnType.Text = "To Pay";
                else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "P")
                    CmbCnType.Text = "Paid";
                else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "F")
                    CmbCnType.Text = "Free";
                else if (string.IsNullOrEmpty(dtOtherDetail.Rows[0]["CnType"].ToString()))
                    CmbCnType.Text = "";

                TxtAdvance.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["Advance"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["Advance"].ToString()).ToString("0.00");
                TxtBalFreight.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["BalFreight"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["BalFreight"].ToString()).ToString("0.00");
                TxtDriverName.Tag = dtOtherDetail.Rows[0]["DriverName"].ToString();
                TxtDriverLicenseNo.Text = dtOtherDetail.Rows[0]["DriverLicNo"].ToString();
                TxtDriverMobileNo.Text = dtOtherDetail.Rows[0]["DriverMobileNo"].ToString();
                TxtContactNo.Text = dtOtherDetail.Rows[0]["ContractNo"].ToString();
                TxtContactDate.Text = dtOtherDetail.Rows[0]["ContractDate"].ToString();
                TxtExportInvNo.Text = dtOtherDetail.Rows[0]["ExpInvNo"].ToString();
                TxtExportInvDate.Text = dtOtherDetail.Rows[0]["ExpInvDate"].ToString();
                TxtPONo.Text = dtOtherDetail.Rows[0]["PoNo"].ToString();
                TxtPODate.Text = dtOtherDetail.Rows[0]["PoDate"].ToString();
                TxtDocBank.Text = dtOtherDetail.Rows[0]["DocBank"].ToString();
                TxtLCNo.Text = dtOtherDetail.Rows[0]["LcNo"].ToString();
                TxtCustomerName.Text = dtOtherDetail.Rows[0]["CustomName"].ToString();
                TxtCoFd.Text = dtOtherDetail.Rows[0]["Cofd"].ToString();
            }
            if (dtBillingaddress.Rows.Count > 0)
            {
                TxtBillingAddress.Text = dtBillingaddress.Rows[0]["BillingAddress"].ToString();
                TxtBillingCity.Text = dtBillingaddress.Rows[0]["BillingCity"].ToString();
                TxtBillingState.Text = dtBillingaddress.Rows[0]["BillingState"].ToString();
                TxtBillingCountry.Text = dtBillingaddress.Rows[0]["BillingCountry"].ToString();
                TxtBillingEmail.Text = dtBillingaddress.Rows[0]["BillingEmail"].ToString();
                TxtShippingAddress.Text = dtBillingaddress.Rows[0]["ShippingAddress"].ToString();
                TxtShippingCity.Text = dtBillingaddress.Rows[0]["ShippingCity"].ToString();
                TxtShippingState.Text = dtBillingaddress.Rows[0]["ShippingState"].ToString();
                TxtShippingCountry.Text = dtBillingaddress.Rows[0]["ShippingCountry"].ToString();
                TxtShippingEmail.Text = dtBillingaddress.Rows[0]["ShippingEmail"].ToString();
            }

            LblTotalAltQty.Text = ClsGlobal.DecimalFormate(_TotalAltQty, 1, ClsGlobal._AltQtyDecimalFormat).ToString();
            LblTotalQty.Text = ClsGlobal.DecimalFormate(_TotalQty, 1, ClsGlobal._QtyDecimalFormat).ToString();
			CalTotal();
		}

		private void SetDataSalesChallan(DataSet ds)
		{
			DataTable dtMaster = ds.Tables[0];
			DataTable dtDetails = ds.Tables[1];
			DataTable dtTerm = ds.Tables[2];

			DataRow[] dtUDFMaster = ds.Tables[3].Select("SNO=0");
			DataRow[] dtUDFDetails = ds.Tables[3].Select("SNO<>0");
			DataTable dtOtherDetail = ds.Tables[4];
			DataTable dtBillingaddress = ds.Tables[5];

			if (dtUDFDetails.Count() > 0)
			{
				foreach (DataRow drDetails in dtDetails.Rows)
				{
					string sno = drDetails["SNo"].ToString();
					DataRow[] dtUDFDetails1 = ds.Tables[3].Select("SNO=" + drDetails["SNo"].ToString() + "");
					DataRow dr = ClsGlobal.UDFExistingDataTableDetails.NewRow();
					dr[0] = drDetails["SNo"].ToString();
					for (int i = 0; i < dtUDFDetails1.Count(); i++)
					{
						if (i == 0)
						{
							dr[i + 1] = dtUDFDetails1[i]["UDFCode"];
							dr[i + 2] = dtUDFDetails1[i]["UDFData"];
						}
						else
						{
							dr[i + 2 + (i - 1)] = dtUDFDetails1[i]["UDFCode"];
							dr[i + 3 + (i - 1)] = dtUDFDetails1[i]["UDFData"];
						}
					}
					ClsGlobal.UDFExistingDataTableDetails.Rows.Add(dr);
				}
			}

			if (dtUDFMaster.Count() > 0)
			{
				DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();
				dr[0] = 0;
				for (int i = 0; i < dtUDFMaster.Count(); i++)
				{
					if (i == 0)
					{
						dr[i + 1] = dtUDFMaster[i]["UDFCode"];
						dr[i + 2] = dtUDFMaster[i]["UDFData"];
					}
					else
					{
						dr[i + 2 + (i - 1)] = dtUDFMaster[i]["UDFCode"];
						dr[i + 3 + (i - 1)] = dtUDFMaster[i]["UDFData"];
					}
				}
				ClsGlobal.UDFExistingDataMaster.Rows.Add(dr);
			}

			//TxtVoucherNo.Text = dtMaster.Rows[0]["VoucherNo"].ToString();
			//_VoucherNo = dtMaster.Rows[0]["VoucherNo"].ToString();
			//TxtDate.Text = dtMaster.Rows[0]["VDate"].ToString();
			//TxtMiti.Text = dtMaster.Rows[0]["VMiti"].ToString();
			TxtCustomer.Text = dtMaster.Rows[0]["GlDesc"].ToString();
			TxtCustomer.Tag = dtMaster.Rows[0]["LedgerId"].ToString();
			TxtSalesman.Text = dtMaster.Rows[0]["SalesmanDesc"].ToString();
			TxtSalesman.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["salesmanId"].ToString()) ? "0" : dtMaster.Rows[0]["salesmanId"].ToString();
			TxtSubledger.Text = dtMaster.Rows[0]["SubLedgerDesc"].ToString();
			TxtSubledger.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["SubledgerId"].ToString()) ? "0" : dtMaster.Rows[0]["SubledgerId"].ToString();
			TxtOrderNo.Text = dtMaster.Rows[0]["OrderNo"].ToString();

			CashPartyViewModel.PartyName = dtMaster.Rows[0]["PartyName"].ToString();
			CashPartyViewModel.PartyAddress = dtMaster.Rows[0]["PartyAddress"].ToString();
			CashPartyViewModel.PartyVatNo = dtMaster.Rows[0]["PartyVatNo"].ToString();
			CashPartyViewModel.ChequeNo = dtMaster.Rows[0]["ChequeNo"].ToString();
			CashPartyViewModel.ChequeDate = null; //(!string.IsNullOrEmpty(dtMaster.Rows[0]["ChequeDate"].ToString())) ? Convert.ToDateTime(dtMaster.Rows[0]["ChequeDate"].ToString()):null;
			CashPartyViewModel.PartyMobileNo = dtMaster.Rows[0]["PartyMobileNo"].ToString();
			CashPartyViewModel.PartyEmail = dtMaster.Rows[0]["PartyEmail"].ToString();

			DataTable dt = _objGeneralLedger.GetCurrrentBalance(Convert.ToInt32(TxtCustomer.Tag.ToString()), Convert.ToDateTime(TxtDate.Text), ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			LblCurrentBalance.Text = Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()) >= 0 ? ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Dr" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrentBalance"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Cr";
			LblPanNo.Text = dt.Rows[0]["PanNo"].ToString();
			LblCreditLimit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CreditLimit"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

			if (string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc4"].ToString()))
			{
				string[] Dept = new string[] { dtMaster.Rows[0]["DepartmentDesc1"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc2"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString() };
				TxtDepartment.Text = string.Concat(Dept);
				string[] Depttag = new string[] { dtMaster.Rows[0]["DepartmentId1"].ToString(), "|", dtMaster.Rows[0]["DepartmentId2"].ToString(), "|", dtMaster.Rows[0]["DepartmentId3"].ToString(), "|", dtMaster.Rows[0]["DepartmentId4"].ToString() };
				TxtDepartment.Tag = string.Concat(Depttag);
			}

			TxtCurrency.Text = dtMaster.Rows[0]["CurrencyDesc"].ToString();
			TxtCurrency.Tag = string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyId"].ToString()) ? "0" : dtMaster.Rows[0]["CurrencyId"].ToString();
			if (!string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyDesc"].ToString()))
			{
				if (Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()) != 1)
					TxtCurrencyRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()), 1, ClsGlobal._CurrencyDecimalFormat);
			}
			else
			{
				TxtCurrencyRate.Text = "";
			}

			TxtRemarks.Text = dtMaster.Rows[0]["Remarks"].ToString();

			LblBasicAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["BasicAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
			LblNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
			LblLocalNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["LocalNetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

			DataRow[] BillTerm = dtTerm.Select("TermType='B'");
			string STSign = "", TermId = "", TermRate = "", TermAmt = "", BillTermDetails = "";
			if (BillTerm.Count() > 0)
			{
				for (int i = 0; i < BillTerm.Count(); i++)
				{
					STSign += "," + BillTerm[i]["STSign"].ToString().Trim(); TermId += "," + BillTerm[i]["TermId"].ToString().Trim(); TermRate += "," + BillTerm[i]["TermRate"].ToString().Trim(); TermAmt += "," + BillTerm[i]["TermAmt"].ToString().Trim();
				}
				BillTermDetails = STSign.Substring(1) + "|" + TermId.Substring(1) + "|" + TermRate.Substring(1) + "|" + TermAmt.Substring(1);
			}
			else
			{
				BillTermDetails = "";
			}
			TxtBillTermAmt.Tag = BillTermDetails;
			TxtBillTermAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
			decimal _TotalQty = 0, _TotalAltQty = 0;
			foreach (DataRow drDetails in dtDetails.Rows)
			{
				DataRow[] ProductTerm = dtTerm.Select("SNo=" + Grid.Rows.Count.ToString() + " and TermType='P'");
				STSign = ""; TermId = ""; TermRate = ""; TermAmt = "";
				string ProductTermDetails = "";
				if (ProductTerm.Count() > 0)
				{
					for (int i = 0; i < ProductTerm.Count(); i++)
					{
						STSign += "," + ProductTerm[i]["STSign"].ToString().Trim(); TermId += "," + ProductTerm[i]["TermId"].ToString().Trim(); TermRate += "," + ProductTerm[i]["TermRate"].ToString().Trim(); TermAmt += "," + ProductTerm[i]["TermAmt"].ToString().Trim();
					}
					ProductTermDetails = STSign.Substring(1) + "|" + TermId.Substring(1) + "|" + TermRate.Substring(1) + "|" + TermAmt.Substring(1);
				}
				else
				{
					ProductTermDetails = "";
				}

				_TotalAltQty = _TotalQty + Convert.ToDecimal(drDetails["AltQty"].ToString());
				_TotalQty = _TotalQty + Convert.ToDecimal(drDetails["Qty"].ToString());

				Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltConversion"].Value = drDetails["AltConv"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["Godown"].Value = drDetails["GodownDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["GodownId"].Value = drDetails["GodownId"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltUOM"].Value = drDetails["ProductAltUnitDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductAltUnitId"].Value = drDetails["ProductAltUnit"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["QtyUOM"].Value = drDetails["ProductUnitDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["QtyConversion"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["ConversionRatio"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRate"].ToString()), 1, ClsGlobal._RateDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
				decimal.TryParse(drDetails["Qty"].ToString(), out decimal _Qty);
				decimal.TryParse(drDetails["SalesRate"].ToString(), out decimal _Rate);
				TxtGridBasicAmt.Text = ClsGlobal.DecimalFormate((_Qty * _Rate), 1, ClsGlobal._AmountDecimalFormat).ToString();
				FrmTerm frmterm = new FrmTerm("SALES", (_Qty * _Rate), ProductTermDetails, _Qty, Convert.ToInt32(drDetails["ProductId"].ToString()));
				decimal _TermAmount = frmterm.TermAmount();
				Grid.Rows[Grid.Rows.Count - 1].Cells["TermsAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["TermDetails"].Value = ProductTermDetails;
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltStockQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["StockQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ChallanNo"].Value = drDetails["VoucherNo"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ChallanSNo"].Value = drDetails["Sno"].ToString();
				//Grid.Rows[Grid.Rows.Count - 1].Cells["OrderNo"].Value = drDetails["OrderNo"].ToString();
				//Grid.Rows[Grid.Rows.Count - 1].Cells["OrderSNo"].Value = drDetails["OrderSno"].ToString();
				Grid.Rows.Add();
			}

			if (dtOtherDetail.Rows.Count > 0)
			{
				TxtTransport.Text = dtOtherDetail.Rows[0]["Transport"].ToString();
				TxtVehicleNo.Text = dtOtherDetail.Rows[0]["VehicleNo"].ToString();
				TxtPackage.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["Package"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["Package"].ToString()).ToString("0.00");
				TxtCnNo.Text = dtOtherDetail.Rows[0]["CnNo"].ToString();
				TxtCnDate.Text = dtOtherDetail.Rows[0]["CnDate"].ToString();
				TxtCnFreight.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["CnFreight"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["CnFreight"].ToString()).ToString("0.00");
				if (dtOtherDetail.Rows[0]["CnType"].ToString() == "D")
					CmbCnType.Text = "Due";
				else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "T")
					CmbCnType.Text = "To Pay";
				else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "P")
					CmbCnType.Text = "Paid";
				else if (dtOtherDetail.Rows[0]["CnType"].ToString() == "F")
					CmbCnType.Text = "Free";
				else if (string.IsNullOrEmpty(dtOtherDetail.Rows[0]["CnType"].ToString()))
					CmbCnType.Text = "";
				TxtAdvance.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["Advance"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["Advance"].ToString()).ToString("0.00");
				TxtBalFreight.Text = string.IsNullOrEmpty(dtOtherDetail.Rows[0]["BalFreight"].ToString()) ? "" : Convert.ToDecimal(dtOtherDetail.Rows[0]["BalFreight"].ToString()).ToString("0.00");
				TxtDriverName.Tag = dtOtherDetail.Rows[0]["DriverName"].ToString();
				TxtDriverLicenseNo.Text = dtOtherDetail.Rows[0]["DriverLicNo"].ToString();
				TxtDriverMobileNo.Text = dtOtherDetail.Rows[0]["DriverMobileNo"].ToString();
				TxtContactNo.Text = dtOtherDetail.Rows[0]["ContractNo"].ToString();
				TxtContactDate.Text = dtOtherDetail.Rows[0]["ContractDate"].ToString();
				TxtExportInvNo.Text = dtOtherDetail.Rows[0]["ExpInvNo"].ToString();
				TxtExportInvDate.Text = dtOtherDetail.Rows[0]["ExpInvDate"].ToString();
				TxtPONo.Text = dtOtherDetail.Rows[0]["PoNo"].ToString();
				TxtPODate.Text = dtOtherDetail.Rows[0]["PoDate"].ToString();
				TxtDocBank.Text = dtOtherDetail.Rows[0]["DocBank"].ToString();
				TxtLCNo.Text = dtOtherDetail.Rows[0]["LcNo"].ToString();
				TxtCustomerName.Text = dtOtherDetail.Rows[0]["CustomName"].ToString();
				TxtCoFd.Text = dtOtherDetail.Rows[0]["Cofd"].ToString();
			}
			if (dtBillingaddress.Rows.Count > 0)
			{
				TxtBillingAddress.Text = dtBillingaddress.Rows[0]["BillingAddress"].ToString();
				TxtBillingCity.Text = dtBillingaddress.Rows[0]["BillingCity"].ToString();
				TxtBillingState.Text = dtBillingaddress.Rows[0]["BillingState"].ToString();
				TxtBillingCountry.Text = dtBillingaddress.Rows[0]["BillingCountry"].ToString();
				TxtBillingEmail.Text = dtBillingaddress.Rows[0]["BillingEmail"].ToString();

				TxtShippingAddress.Text = dtBillingaddress.Rows[0]["ShippingAddress"].ToString();
				TxtShippingCity.Text = dtBillingaddress.Rows[0]["ShippingCity"].ToString();
				TxtShippingState.Text = dtBillingaddress.Rows[0]["ShippingState"].ToString();
				TxtShippingCountry.Text = dtBillingaddress.Rows[0]["ShippingCountry"].ToString();
				TxtShippingEmail.Text = dtBillingaddress.Rows[0]["ShippingEmail"].ToString();
			}

			LblTotalAltQty.Text = ClsGlobal.DecimalFormate(_TotalAltQty, 1, ClsGlobal._AltQtyDecimalFormat).ToString();
			LblTotalQty.Text = ClsGlobal.DecimalFormate(_TotalQty, 1, ClsGlobal._QtyDecimalFormat).ToString();
			CalTotal();
		}
	}
}
