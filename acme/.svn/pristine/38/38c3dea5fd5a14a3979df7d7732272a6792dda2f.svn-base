using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.Common
{
    public partial class DocPrintingOption : Form
    {
        string _ModuleName = "", _PageTitle = "", _VoucherNo = "", _val1, _val2,  _SearchKey = "";
        IDocPrintSetting _objDocPrintSetting = new ClsDocPrintSetting();
        ClsDateMiti _objDate = new ClsDateMiti();
        ClsFormControl control = null;
        DateTime FromVoucherDate, ToVoucherDate;
        DataTable DtPrintDesignList = new DataTable();
        ReportDocument _objReportDocument = new ReportDocument();
        ISalesInvoice _objSalesInvoice = new ClsSalesInvoice();

        private void BtnFromVoucherSearch_Click(object sender, EventArgs e)
        {
            if (_SearchKey.Length > 1)
            {
                _SearchKey = "";
            }
            if (_ModuleName == "SB")
            {
                ClsButtonClick.SalesVoucherBtnClick(_SearchKey,"EDIT", TxtFromVoucher, e);                
            }else if(_ModuleName == "SO")
            {
                ClsButtonClick.SalesOrderVoucherBtnClick(_SearchKey,"EDIT", TxtFromVoucher, e);               
            }
        }

        private void TxtFromVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnFromVoucherSearch.PerformClick();
            }
        }

        private void BtnToVoucherSearch_Click(object sender, EventArgs e)
        {
            if (_SearchKey.Length > 1)
            {
                _SearchKey = "";
            }
            if (_ModuleName == "SB")
            {
                ClsButtonClick.SalesVoucherBtnClick(_SearchKey, "EDIT", TxtToVoucher, e);               
            }
            else if (_ModuleName == "SO")
            {
                ClsButtonClick.SalesOrderVoucherBtnClick(_SearchKey, "EDIT", TxtToVoucher, e);
            }
        }

        private void TxtToVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnToVoucherSearch.PerformClick();
            }
        }

        private void TxtToVoucher_Validating(object sender, CancelEventArgs e)
        {
            if (ActiveControl == TxtToVoucher) return;
            if (TxtToVoucher.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtToVoucher.Text))
            {
                MessageBox.Show("Voucher number cannot left blank.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (string.IsNullOrEmpty(_objSalesInvoice.IsExistsVNumber(TxtFromVoucher.Text)))
            {
                MessageBox.Show("Voucher number doesn't exist.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
        }

        private void TxtFromVoucher_Validating(object sender, CancelEventArgs e)
        {
            if ( ActiveControl == TxtFromVoucher) return;
            if (TxtFromVoucher.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtFromVoucher.Text))
            {
                MessageBox.Show("Voucher number nannot left blank.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
           else if (string.IsNullOrEmpty(_objSalesInvoice.IsExistsVNumber(TxtFromVoucher.Text)))
            {
                MessageBox.Show("Voucher number doesn't exist.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtToVoucher.Text))
                {
                    TxtToVoucher.Text = TxtFromVoucher.Text;
                }
            }
        }

        public DocPrintingOption(string ModuleName, string PageTitle, string VoucherNo)
        {
            InitializeComponent();
            control = new ClsFormControl(this);
            DtPrintDesignList = _objDocPrintSetting.PrintDesignList(ModuleName);
            CmbDesignList.ValueMember = "PrintDesignId";
            CmbDesignList.DisplayMember = "DesignName";
            CmbDesignList.DataSource = DtPrintDesignList;
            if (DtPrintDesignList.Rows.Count > 0)
            {
                TxtNoOfCopyPrint.Text = DtPrintDesignList.Rows[0]["NoofCopy"].ToString() == "0" ? "1" : DtPrintDesignList.Rows[0]["NoofCopy"].ToString();
            }
            ClsPrinterList.GetPrinterList(CmbPrinterList);
            CmbOption.SelectedIndex = 0;
            this.Text = "Document Printing - " + PageTitle;
            _ModuleName = ModuleName;
            _PageTitle = PageTitle;
            _VoucherNo = VoucherNo;
        }

        private void DocPrintingOption_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_VoucherNo))
            {
                CmbOption.Enabled = false;
                TxtFromVoucher.Enabled = false;
                TxtToVoucher.Enabled = false;
                BtnFromVoucherSearch.Enabled = false;
                BtnToVoucherSearch.Enabled = false;
                TxtFromVoucher.Text = _VoucherNo;
                TxtToVoucher.Text = _VoucherNo;
            }
            TxtFromDate.Visible = false;
            TxtToDate.Visible = false;
        }

        private void DocPrintingOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnCancel.PerformClick();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            #region --------- Form Validation ------------------
           
            if (CmbOption.Text == "Date")
            {
                if (TxtFromDate.Text == "  /  /")
                {
                    MessageBox.Show("From date cannot left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtFromDate.Focus();
                    return;
                }
                else if (TxtToDate.Text == "  /  /")
                {
                    MessageBox.Show("To date cannot left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtToDate.Focus();
                    return;
                }
            }
            else
            {
                if (TxtFromVoucher.Text.Trim() == "")
                {
                    MessageBox.Show("From voucher no cannot left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtFromVoucher.Focus();
                    return;
                }
                else if (TxtToVoucher.Text.Trim() == "")
                {
                    MessageBox.Show("To voucher no cannot left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtToVoucher.Focus();
                    return;
                }
            }

            if (CmbDesignList.Items.Count <= 0)
            {
                MessageBox.Show("Print design not avilable.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDesignList.Focus();
                return;
            }

            int.TryParse(TxtNoOfCopyPrint.Text, out int _NoOfCopyPrint);
            if (_NoOfCopyPrint < 1)
            {
                MessageBox.Show("No of copy print can not accept zero value.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNoOfCopyPrint.Focus();
                return;
            }

            if (CmbOption.Text == "Date")
            {
                if (ClsGlobal.DateType == "D")
                {
                    FromVoucherDate = Convert.ToDateTime(TxtFromDate.Text);
                    ToVoucherDate = Convert.ToDateTime(TxtToDate.Text);
                }
                else
                {
                    FromVoucherDate = _objDate.GetDate1(TxtFromDate.Text);
                    ToVoucherDate = _objDate.GetDate1(TxtToDate.Text);
                }

                _val1 = ""; //clsGlobal.FetchSingleData("Select top 1 [Invoice No] from SalesBillHeader where  [Invoice Date] between '" + FromDate.ToString("MM/dd/yyyy") + "'And '" + ToDate.ToString("MM/dd/yyyy") + "'");
                _val2 = ""; //clsGlobal.FetchSingleData("Select top 1 [Invoice No] from SalesBillHeader where  [Invoice Date] between '" + FromDate.ToString("MM/dd/yyyy") + "'And '" + ToDate.ToString("MM/dd/yyyy") + "' order by [Invoice No] desc");
            }
            else
            {
                _val1 = TxtFromVoucher.Text;
                _val2 = TxtToVoucher.Text;
            }

            //string doctype = clsGlobal.GetAnyData("Select Doc_Type From Doc_Printing_Design where Module_Name='" + _pageTitle + "' and Printing_Document ='" + cmbDesign.Text + "' ");

            DataRow[] dr = DtPrintDesignList.Select("PrintDesignId='" + CmbDesignList.SelectedValue.ToString() + "'");
            string DesignType = dr[0]["DesignType"].ToString();
            string DesignPath = dr[0]["DesignPath"].ToString();
            
            this.Close();
            #endregion

            switch (_ModuleName)
            {
                #region -------------- POS -------------

                //case "POS":
                //    if (cmbOption.Text == "Date")
                //    {
                //        // ss = "select Sb_InvNo from sales_master where Sb_InvDate BETWEEN '" + FromDate.ToString("MM/dd/yyyy") + "' AND '" + ToDate.ToString("MM/dd/yyyy") + "' order by Sb_InvNo ";
                //        dt = clsGlobal.FetchDataTable("select Sb_InvNo from sales_master where Sb_InvDate BETWEEN '" + FromDate.ToString("MM/dd/yyyy") + "' AND '" + ToDate.ToString("MM/dd/yyyy") + "' order by Sb_InvNo ");
                //    }
                //    else if (cmbOption.Text == "Number")
                //        dt = clsGlobal.FetchDataTable("select Sb_InvNo from sales_master where Sb_InvNo BETWEEN '" + txtFromNumber.Text.Trim() + "' AND '" + txtToNumber.Text.Trim() + "' order by Sb_InvNo ");
                //    if (dt.Rows.Count > 0)
                //    {
                //        foreach (DataRow dr in dt.Rows)
                //        {
                //            POSUtil.Print.DocPrintPOS prnt = new POSUtil.Print.DocPrintPOS(SwastikPOS.Util.Database.DBConnection, dr["Sb_InvNo"].ToString(), cmbPrinter.SelectedItem.ToString(), cmbDesign.Text, clsGlobal.BranchName, clsGlobal.uName, clsGlobal.TodayDateTime, Convert.ToInt32(txtNoofCopy.Text));
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Sales Invoice -------------
                case "SB":
                    if (DesignType == "DLL")
                    {
                        //if (CmbOption.Text == "Date")
                        //    dt = clsGlobal.FetchDataTable("select Sb_InvNo from sales_master where Sb_InvDate BETWEEN '" + FromDate + "' AND '" + ToDate + "' order by Sb_InvNo ");
                        //else if (cmbOption.Text == "Number")
                        //    dt = clsGlobal.FetchDataTable("select Sb_InvNo from sales_master where Sb_InvNo BETWEEN '" + txtFromNumber.Text.Trim() + "' AND '" + txtToNumber.Text.Trim() + "' order by Sb_InvNo ");
                        //foreach (DataRow dr in dt.Rows)
                        //{
                        DataAccessLayer.DLLPrinting.DllInvoicePrint a = new DataAccessLayer.DLLPrinting.DllInvoicePrint(TxtFromVoucher.Text, CmbPrinterList.Text, "3InchCounterTaxBill", ClsGlobal.LoginUserCode, ClsGlobal.TodayDateTime, Convert.ToInt32(TxtNoOfCopyPrint.Text));
                        //sb.updatePrintStatus(dr["Sb_InvNo"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                        //}
                    }
                    else if (DesignType == "Crystal")
                    {
                        DataSet dataSet = _objDocPrintSetting.SalesInvoiceDataSet(TxtFromVoucher.Text);
                        _objReportDocument.Load(DesignPath);
                        _objReportDocument.SetDataSource(dataSet);
                        _objReportDocument.SetDatabaseLogon(Properties.Settings.Default.ServeUserName, Properties.Settings.Default.ServerPassword, Properties.Settings.Default.ServerName, ClsGlobal.DatabaseName);
                        int val = Convert.ToInt32(TxtNoOfCopyPrint.Text);
                        for (int i = 1; i <= val; i++)
                        {
                            try { _objReportDocument.DataDefinition.FormulaFields["CopyNo"].Text = Convert.ToInt32(i).ToString(); }
                            catch { }
                            crystalReportViewer1.ReportSource = _objReportDocument;
                            crystalReportViewer1.Refresh();
                            //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                            _objReportDocument.PrintOptions.PrinterName = CmbPrinterList.Text;
                            _objReportDocument.PrintToPrinter(1, false, 0, 0);
                        }

                        //foreach (DataRow dr in myTable.Rows)
                        //{
                        _objDocPrintSetting.UpdatePrintStatus(TxtFromVoucher.Text, ClsGlobal.LoginUserCode, ClsGlobal.TodayDateTime);
                        //}
                    }
                    break;
                #endregion

                #region -------------- Sales Order -------------
                //case "Sales Order":
                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Order No] FROM SalesOrderHeader  where [Order No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Order No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM SalesOrderHeader  where [Order No]= '" + invno + "'; SELECT *  FROM SalesOrderDetails where [Order No] = '" + invno + "';  select * from SalesOrderTermVertical  where [Order No] = '" + invno + "';  select * from SalesOrderOtherDetails  where [Order No] = '" + invno + "'; select * from SalesOrderProductTermVertical  where [Order No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());
                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "SalesOrderHeader";
                //            dataSet.Tables[2].TableName = "SalesOrderDetails";
                //            dataSet.Tables[3].TableName = "SalesOrderTermVertical";
                //            dataSet.Tables[4].TableName = "SalesOrderOtherDetails";
                //            dataSet.Tables[5].TableName = "SalesOrderProductTermVertical";
                //            objRpt.SetDataSource(dataSet);
                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Order No] FROM SalesOrderHeader  where [Order No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.SalesOrderTables(item["Order No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.SalesOrderTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Sales Challan -------------

                //case "Sales Challan":
                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Challan No] FROM SalesOrderHeader  where [Challan No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Challan No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM SalesOrderHeader  where [Challan No]= '" + invno + "'; SELECT *  FROM SalesChallanDetails where [Challan No] = '" + invno + "';  select * from SalesChallanTermVertical  where [Challan No] = '" + invno + "';  select * from SalesChallanOtherDetails  where [Challan No] = '" + invno + "'; select * from SalesChallanProductTermVertical  where [Challan No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());
                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "SalesChallanHeader";
                //            dataSet.Tables[2].TableName = "SalesChallanDetails";
                //            dataSet.Tables[3].TableName = "SalesChallanTermVertical";
                //            dataSet.Tables[4].TableName = "SalesChallanOtherDetails";
                //            dataSet.Tables[5].TableName = "SalesChallanProductTermVertical";
                //            objRpt.SetDataSource(dataSet);
                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Challan No] FROM SalesChallanHeader  where [Challan No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.SalesChallanTables(item["Challan No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.SalesChallanTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);
                //                        rpt.DataSource = dataSet;
                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Sales Return -------------

                //case "Sales Return":
                //    if (doctype == "DLL")
                //    {
                //        if (string.IsNullOrEmpty(cmbDesign.SelectedValue.ToString()))
                //        {
                //            if (cmbOption.Text == "Date")
                //                dt = clsGlobal.FetchDataTable("select SR_InvNo from SalesReturn_Master where SR_InvDate BETWEEN '" + FromDate + "' AND '" + ToDate + "' order by SR_InvNo ");
                //            else if (cmbOption.Text == "Number")
                //                dt = clsGlobal.FetchDataTable("select SR_InvNo from SalesReturn_Master where SR_InvNo BETWEEN '" + txtFromNumber.Text.Trim() + "' AND '" + txtToNumber.Text.Trim() + "' order by SR_InvNo ");
                //            foreach (DataRow dr in dt.Rows)
                //            {
                //                POSUtil.Print.DocPrintSalesReturn prnt = new POSUtil.Print.DocPrintSalesReturn(SwastikPOS.Util.Database.DBConnection, dr["SR_InvNo"].ToString(), cmbPrinter.SelectedItem.ToString(), cmbDesign.Text, clsGlobal.BranchName, clsGlobal.uName, clsGlobal.TodayDateTime, Convert.ToInt32(txtNoofCopy.Text));
                //                sb.updatePrintStatus(dr["SR_InvNo"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //            }
                //        }
                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable1 = clsGlobal.FetchDataTable("SELECT [Return No] FROM SalesReturnHeader  where [Return No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable1.Rows)
                //        {
                //            string invno = item["Return No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation;SELECT * FROM SalesReturnHeader  where [Return No]= '" + invno + "';SELECT *  FROM SalesReturnDetails where [Return No] = '" + invno + "'; select * from SalesReturnBillTermVertical  where [Return No] = '" + invno + "'; select * from SalesReturnBatchDetails  where [Return No] = '" + invno + "'; select * from SalesReturnOtherDetails  where [Return No] = '" + invno + "';select * from SalesReturnProductTermVertical  where [Return No] = '" + invno + "'; ");

                //            objRpt.Load(cmbDesign.SelectedValue.ToString());
                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "SalesReturnHeader";
                //            dataSet.Tables[2].TableName = "SalesReturnDetails";
                //            dataSet.Tables[3].TableName = "SalesReturnBillTermVertical";
                //            dataSet.Tables[4].TableName = "SalesReturnBatchDetails";
                //            dataSet.Tables[5].TableName = "SalesReturnOtherDetails";
                //            dataSet.Tables[6].TableName = "SalesReturnProductTermVertical";

                //            objRpt.SetDataSource(dataSet);
                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                //  crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                // crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                // crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }
                //        foreach (DataRow dr in myTable1.Rows)
                //        {
                //            sb.updatePrintStatus(dr["Return No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Return No] FROM SalesReturnHeader  where [Return No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.SalesReturnTables(item["Return No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.SalesReturnTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);
                //                        rpt.DataSource = dataSet;
                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }
                //                    sb.updatePrintStatus(item["Return No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }

                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }


                //    break;
                #endregion

                #region --------------  Sales Ex/Br Return -------------

                //case "Sales Ex/Br Return":
                //    if (doctype == "DLL")
                //    {
                //        if (string.IsNullOrEmpty(cmbDesign.SelectedValue.ToString()))
                //        {
                //            if (cmbOption.Text == "Date")
                //                dt = clsGlobal.FetchDataTable("Select ExBr_No from Sales_ExBr_Master where  ExBr_Date '" + FromDate + "' AND '" + ToDate + "' order by ExBr_No ");
                //            else if (cmbOption.Text == "Number")
                //                dt = clsGlobal.FetchDataTable("select ExBr_No from Sales_ExBr_Master where ExBr_No BETWEEN '" + txtFromNumber.Text.Trim() + "' AND '" + txtToNumber.Text.Trim() + "' order by ExBr_No ");
                //            foreach (DataRow dr in dt.Rows)
                //            {
                //                POSUtil.Print.DocPrintSalesReturn prnt = new POSUtil.Print.DocPrintSalesReturn(SwastikPOS.Util.Database.DBConnection, dr["ExBr_No"].ToString(), cmbPrinter.SelectedItem.ToString(), cmbDesign.Text, clsGlobal.BranchName, clsGlobal.uName, clsGlobal.TodayDateTime, Convert.ToInt32(txtNoofCopy.Text));
                //                sb.updatePrintStatus(dr["ExBr_No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //            }
                //        }
                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable1 = clsGlobal.FetchDataTable("select [ExBr No] from SalesExBrHeader where [ExBr No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable1.Rows)
                //        {
                //            string invno = item["ExBr No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM SalesExBrHeader  where [ExBr No]= '" + invno + "'; SELECT *  FROM SalesExBrDetails where [ExBr No] = '" + invno + "';  select * from SalesExBrBillTermVertical  where [Invoice No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());
                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "SalesExBrHeader";
                //            dataSet.Tables[2].TableName = "SalesExBrDetails";
                //            dataSet.Tables[3].TableName = "SalesExBrBillTermVertical";
                //            objRpt.SetDataSource(dataSet);
                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }
                //        foreach (DataRow dr in myTable1.Rows)
                //        {
                //            sb.updateReturnPrintStatus(dr["ExBr No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [ExBr No] FROM SalesExBrHeader  where [ExBr No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.SalesExpiryBreakageTables(item["ExBr No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.SalesExpiryBreakageTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);
                //                        rpt.DataSource = dataSet;
                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }
                //                    sb.updatePrintStatus(item["ExBr No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }

                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }

                //    break;
                #endregion

                #region --------------  Sales Additional -------------

                //case "Sales Additional":
                //    if (doctype == "DLL")
                //    {
                //        if (string.IsNullOrEmpty(cmbDesign.SelectedValue.ToString()))
                //        {
                //            if (cmbOption.Text == "Date")
                //                dt = clsGlobal.FetchDataTable("Select AddBill_No from Sales_AddBill_Master where  AddBill_Date '" + FromDate + "' AND '" + ToDate + "' order by AddBill_No ");
                //            else if (cmbOption.Text == "Number")
                //                dt = clsGlobal.FetchDataTable("select AddBill_No from Sales_AddBill_Master where AddBill_No BETWEEN '" + txtFromNumber.Text.Trim() + "' AND '" + txtToNumber.Text.Trim() + "' order by AddBill_No ");
                //            foreach (DataRow dr in dt.Rows)
                //            {
                //                POSUtil.Print.DocPrintSalesReturn prnt = new POSUtil.Print.DocPrintSalesReturn(SwastikPOS.Util.Database.DBConnection, dr["AddBill_No"].ToString(), cmbPrinter.SelectedItem.ToString(), cmbDesign.Text, clsGlobal.BranchName, clsGlobal.uName, clsGlobal.TodayDateTime, Convert.ToInt32(txtNoofCopy.Text));
                //                sb.updatePrintStatus(dr["AddBill_No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //            }
                //        }
                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable1 = clsGlobal.FetchDataTable("select [Additional BillNo] from SalesAddBillHeader where [Additional BillNo] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable1.Rows)
                //        {
                //            string invno = item["Additional BillNo"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM SalesAddBillHeader  where [Additional BillNo]= '" + invno + "'; SELECT *  FROM SalesAddBillDetails where [Additional BillNo] = '" + invno + "';  select * from SalesAddBillTermVertical  where [Additional BillNo] = '" + invno + "' ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());
                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "SalesAddBillHeader";
                //            dataSet.Tables[2].TableName = "SalesAddBillDetails";
                //            dataSet.Tables[3].TableName = "SalesAddBillTermVertical";
                //            objRpt.SetDataSource(dataSet);
                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }
                //        foreach (DataRow dr in myTable1.Rows)
                //        {
                //            sb.updateReturnPrintStatus(dr["Additional BillNo"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Additional BillNo] FROM SalesAddBillHeader  where [Additional BillNo] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.SalesAdditionalTables(item["Additional BillNo"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.SalesAdditionalTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);
                //                        rpt.DataSource = dataSet;
                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }
                //                    sb.updatePrintStatus(item["Additional BillNo"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }

                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Purchase Invoice -------------

                //case "Purchase Invoice":

                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Invoice No] FROM PurchaseBillHeader  where [Invoice No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Invoice No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM PurchaseBillHeader  where [Invoice No]= '" + invno + "'; SELECT *  FROM PurchaseBillDetails where [Invoice No] = '" + invno + "';  select * from PurchaseBillTerms  where [Invoice No] = '" + invno + "'; select * from PurchaseBillProductTermVertical  where [Invoice No] = '" + invno + "'; select * from PurchaseBillProductTermHorizontal  where [Invoice No] = '" + invno + "'; select * from PurchaseBillTermVertical  where [Invoice No] = '" + invno + "'; select * from PurchaseBillProductTerms  where [Invoice No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());

                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "PurchaseBillHeader";
                //            dataSet.Tables[2].TableName = "PurchaseBillDetails";
                //            dataSet.Tables[3].TableName = "PurchaseBillTerms";
                //            dataSet.Tables[4].TableName = "PurchaseBillProductTermVertical";
                //            dataSet.Tables[5].TableName = "PurchaseBillProductTermHorizontal";
                //            dataSet.Tables[6].TableName = "PurchaseBillTermVertical";
                //            dataSet.Tables[7].TableName = "PurchaseBillProductTerms";
                //            objRpt.SetDataSource(dataSet);
                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }

                //        foreach (DataRow dr in myTable.Rows)
                //        {
                //            sb.updatePrintStatus(dr["Invoice No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            _TodayDateTime = objDateMiti.GetServerDateTime();

                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Invoice No] FROM PurchaseBillHeader  where [Invoice No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.PurchaseBillTables(item["Invoice No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.PurchaseBillTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        if (rpt.Parameters.Count > 0)
                //                        {
                //                            rpt.Parameters["copyno"].Type = typeof(int);
                //                            rpt.Parameters["copyno"].Value = i;
                //                        }

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }

                //                    sb.updatePrintStatus(item["Invoice No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Purchase Order -------------

                //case "Purchase Order":

                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Order No] FROM PurchaseOrderHeader  where [Order No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Order No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM PurchaseOrderHeader  where [Order No]= '" + invno + "'; SELECT *  FROM PurchaseOrderDetails where [Order No] = '" + invno + "';  select * from PurchaseOrderTerms  where [Order No] = '" + invno + "'; select * from PurchaseOrderProductTermVertical  where [Order No] = '" + invno + "'; select * from PurchaseOrderProductTermHorizontal  where [Order No] = '" + invno + "'; select * from PurchaseOrderTermVertical  where [Order No] = '" + invno + "'; select * from PurchaseOrderProductTerms  where [Order No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());

                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "PurchaseOrderHeader";
                //            dataSet.Tables[2].TableName = "PurchaseOrderDetails";
                //            dataSet.Tables[3].TableName = "PurchaseOrderTerms";
                //            dataSet.Tables[4].TableName = "PurchaseOrderProductTermVertical";
                //            dataSet.Tables[5].TableName = "PurchaseOrderProductTermHorizontal";
                //            dataSet.Tables[6].TableName = "PurchaseOrderTermVertical";
                //            dataSet.Tables[7].TableName = "PurchaseOrderProductTerms";
                //            objRpt.SetDataSource(dataSet);

                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }

                //        foreach (DataRow dr in myTable.Rows)
                //        {
                //            sb.updatePrintStatus(dr["Order No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            _TodayDateTime = objDateMiti.GetServerDateTime();

                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"Select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Order No] FROM PurchaseOrderHeader  where [Order No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.PurchaseOrderTables(item["Order No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.PurchaseOrderTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        if (rpt.Parameters.Count > 0)
                //                        {
                //                            rpt.Parameters["copyno"].Type = typeof(int);
                //                            rpt.Parameters["copyno"].Value = i;
                //                        }

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }

                //                    sb.updatePrintStatus(item["Order No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Purchase Challan -------------

                //case "Purchase Challan":

                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Challan No] FROM PurchaseChallanHeader  where [Challan No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Challan No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM PurchaseChallanHeader  where [Challan No]= '" + invno + "'; SELECT *  FROM PurchaseChallanDetails where [Challan No] = '" + invno + "';  select * from PurchaseChallanTerms  where [Challan No] = '" + invno + "'; select * from PurchaseChallanProductTermVertical  where [Challan No] = '" + invno + "'; select * from PurchaseChallanProductTermHorizontal  where [Challan No] = '" + invno + "'; select * from PurchaseChallanTermVertical  where [Challan No] = '" + invno + "'; select * from PurchaseChallanProductTerms  where [Challan No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());

                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "PurchaseChallanHeader";
                //            dataSet.Tables[2].TableName = "PurchaseChallanDetails";
                //            dataSet.Tables[3].TableName = "PurchaseChallanTerms";
                //            dataSet.Tables[4].TableName = "PurchaseChallanProductTermVertical";
                //            dataSet.Tables[5].TableName = "PurchaseChallanProductTermHorizontal";
                //            dataSet.Tables[6].TableName = "PurchaseChallanTermVertical";
                //            dataSet.Tables[7].TableName = "PurchaseChallanProductTerms";
                //            objRpt.SetDataSource(dataSet);

                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }

                //        foreach (DataRow dr in myTable.Rows)
                //        {
                //            sb.updatePrintStatus(dr["Challan No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            _TodayDateTime = objDateMiti.GetServerDateTime();

                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"Select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Challan No] FROM PurchaseChallanHeader  where [Challan No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.PurchaseChallanTables(item["Challan No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.PurchaseChallanTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        if (rpt.Parameters.Count > 0)
                //                        {
                //                            rpt.Parameters["copyno"].Type = typeof(int);
                //                            rpt.Parameters["copyno"].Value = i;
                //                        }

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }

                //                    sb.updatePrintStatus(item["Challan No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Purchase Return -------------

                //case "Purchase Return":

                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Return No] FROM PurchaseReturnHeader  where [Return No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Return No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM PurchaseReturnHeader  where [Return No]= '" + invno + "'; SELECT *  FROM PurchaseReturnDetails where [Return No] = '" + invno + "';  select * from PurchaseReturnTerms  where [Return No] = '" + invno + "'; select * from PurchaseReturnProductTermVertical  where [Return No] = '" + invno + "'; select * from PurchaseReturnProductTermHorizontal  where [Return No] = '" + invno + "'; select * from PurchaseReturnBillTermVertical  where [Return No] = '" + invno + "'; select * from PurchaseReturnProductTerms  where [Return No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());

                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "PurchaseReturnHeader";
                //            dataSet.Tables[2].TableName = "PurchaseReturnDetails";
                //            dataSet.Tables[3].TableName = "PurchaseReturnTerms";
                //            dataSet.Tables[4].TableName = "PurchaseReturnProductTermVertical";
                //            dataSet.Tables[5].TableName = "PurchaseReturnProductTermHorizontal";
                //            dataSet.Tables[6].TableName = "PurchaseReturnBillTermVertical";
                //            dataSet.Tables[7].TableName = "PurchaseReturnProductTerms";
                //            objRpt.SetDataSource(dataSet);

                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }

                //        foreach (DataRow dr in myTable.Rows)
                //        {
                //            sb.updatePrintStatus(dr["Return No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            _TodayDateTime = objDateMiti.GetServerDateTime();

                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"Select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Return No] FROM PurchaseReturnHeader  where [Return No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.PurchaseReturnTables(item["Return No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.PurchaseReturnTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        if (rpt.Parameters.Count > 0)
                //                        {
                //                            rpt.Parameters["copyno"].Type = typeof(int);
                //                            rpt.Parameters["copyno"].Value = i;
                //                        }

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }

                //                    sb.updatePrintStatus(item["Return No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Purchase Ex/Br Return -------------

                //case "Purchase Ex/Br Return":

                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [ExBr No] FROM PurchaseExBrHeader  where [ExBr No] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["ExBr No"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM PurchaseExBrHeader  where [ExBr No]= '" + invno + "'; SELECT *  FROM PurchaseExBrDetails where [ExBr No] = '" + invno + "';  select * from PurchaseExBrTerms  where [ExBr No] = '" + invno + "'; select * from PurchaseExBrProductTermVertical  where [ExBr No] = '" + invno + "'; select * from PurchaseExBrProductTermHorizontal  where [ExBr No] = '" + invno + "'; select * from PurchaseExBrBillTermVertical  where [Invoice No] = '" + invno + "'; select * from PurchaseExBrProductTerms  where [ExBr No] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());

                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "PurchaseExBrHeader";
                //            dataSet.Tables[2].TableName = "PurchaseExBrDetails";
                //            dataSet.Tables[3].TableName = "PurchaseExBrTerms";
                //            dataSet.Tables[4].TableName = "PurchaseExBrProductTermVertical";
                //            dataSet.Tables[5].TableName = "PurchaseExBrProductTermHorizontal";
                //            dataSet.Tables[6].TableName = "PurchaseExBrBillTermVertical";
                //            dataSet.Tables[7].TableName = "PurchaseExBrProductTerms";
                //            objRpt.SetDataSource(dataSet);

                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }

                //        foreach (DataRow dr in myTable.Rows)
                //        {
                //            sb.updatePrintStatus(dr["ExBr No"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            _TodayDateTime = objDateMiti.GetServerDateTime();

                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"Select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [ExBr No] FROM PurchaseExBrHeader  where [ExBr No] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.PurchaseExpiryBreakageTables(item["ExBr No"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.PurchaseExpiryBreakageTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        if (rpt.Parameters.Count > 0)
                //                        {
                //                            rpt.Parameters["copyno"].Type = typeof(int);
                //                            rpt.Parameters["copyno"].Value = i;
                //                        }

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }

                //                    sb.updatePrintStatus(item["ExBr No"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                #region -------------- Purchase Additional -------------

                //case "Purchase Additional":

                //    if (doctype == "DLL")
                //    {

                //    }
                //    else if (doctype == "Crystal")
                //    {
                //        DataTable myTable = clsGlobal.FetchDataTable("SELECT [Additional BillNo] FROM PurchaseAddBillHeader  where [Additional BillNo] between '" + _val1 + "' and '" + _val2 + "';");
                //        foreach (DataRow item in myTable.Rows)
                //        {
                //            string invno = item["Additional BillNo"].ToString();
                //            DataSet dataSet = new DataSet();
                //            dataSet = clsGlobal.FetchDataSet("select * from CompanyInformation; SELECT * FROM PurchaseAddBillHeader  where [Additional BillNo]= '" + invno + "'; SELECT *  FROM PurchaseAddBillDetails where [Additional BillNo] = '" + invno + "';  select * from PurchaseAddBillTerms  where [Additional BillNo] = '" + invno + "'; select * from PurchaseAddBillProductTermVertical  where [Additional BillNo] = '" + invno + "'; select * from PurchaseAddBillProductTermHorizontal  where [Additional BillNo] = '" + invno + "'; select * from PurchaseAddBillTermVertical  where [Additional BillNo] = '" + invno + "'; select * from PurchaseAddBillProductTerms  where [Additional BillNo] = '" + invno + "'; ");
                //            objRpt.Load(cmbDesign.SelectedValue.ToString());

                //            dataSet.Tables[0].TableName = "CompanyInformation";
                //            dataSet.Tables[1].TableName = "PurchaseAddBillHeader";
                //            dataSet.Tables[2].TableName = "PurchaseAddBillDetails";
                //            dataSet.Tables[3].TableName = "PurchaseAddBillTerms";
                //            dataSet.Tables[4].TableName = "PurchaseAddBillProductTermVertical";
                //            dataSet.Tables[5].TableName = "PurchaseAddBillProductTermHorizontal";
                //            dataSet.Tables[6].TableName = "PurchaseAddBillTermVertical";
                //            dataSet.Tables[7].TableName = "PurchaseAddBillProductTerms";
                //            objRpt.SetDataSource(dataSet);

                //            objRpt.SetDatabaseLogon(clsGlobal.uServerUserName, clsGlobal.uServerPassword, clsGlobal.uServerName, clsGlobal.uCompDatabaseName);

                //            //------ SET Parameter VALUE
                //            ParameterFieldDefinitions crParameterFieldDefinitions;
                //            ParameterFieldDefinition crParameterFieldDefinition;
                //            ParameterValues crParameterValues = new ParameterValues();
                //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //            int val = Convert.ToInt32(txtNoofCopy.Text);
                //            for (int i = 1; i <= val; i++)
                //            {
                //                crParameterDiscreteValue.Value = i.ToString();
                //                crParameterFieldDefinitions = objRpt.DataDefinition.ParameterFields;
                //                crParameterFieldDefinition = crParameterFieldDefinitions["copyno"];
                //                crParameterValues = crParameterFieldDefinition.CurrentValues;
                //                crParameterValues.Add(crParameterDiscreteValue);
                //                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //                crystalReportViewer1.ReportSource = objRpt;
                //                crystalReportViewer1.Refresh();
                //                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //                objRpt.PrintOptions.PrinterName = cmbPrinter.Text;
                //                objRpt.PrintToPrinter(1, false, 0, 0);
                //            }
                //        }

                //        foreach (DataRow dr in myTable.Rows)
                //        {
                //            sb.updatePrintStatus(dr["Additional BillNo"].ToString(), clsGlobal.uName, clsGlobal.TodayDateTime);
                //        }
                //    }
                //    else if (doctype == "DevExpress")
                //    {
                //        if (cmbDesign.Items.Count > 0)
                //        {
                //            _TodayDateTime = objDateMiti.GetServerDateTime();

                //            DataSet dataSet = new DataSet();
                //            DataTable dt1 = clsGlobal.FetchDataTable(@"Select Sourcefile,DesignerName FROM tblDocDesignerSource where DesignerName='" + cmbDesign.Text + "' and ModuleName='" + _pageTitle + "'");

                //            string Sourcefile = dt1.Rows[0]["Sourcefile"].ToString();
                //            string dname = dt1.Rows[0]["DesignerName"].ToString();
                //            byte[] byteArray = Encoding.ASCII.GetBytes(Sourcefile);
                //            MemoryStream Stream = new MemoryStream(byteArray);

                //            DataTable myTable = clsGlobal.FetchDataTable("SELECT [Additional BillNo] FROM PurchaseAddBillHeader  where [Additional BillNo] BETWEEN '" + _val1 + "' and '" + _val2 + "';");
                //            if (myTable.Rows.Count > 0)
                //            {
                //                foreach (DataRow item in myTable.Rows)
                //                {
                //                    StringBuilder strSql = POSDAL.Util.clsTableRelation.PurchaseAdditionalTables(item["Additional BillNo"].ToString());
                //                    dataSet = clsGlobal.FetchDataSet(strSql.ToString());
                //                    POSDAL.Util.clsTableRelation.PurchaseAdditionalTableRelation(dataSet);

                //                    int val = Convert.ToInt32(txtNoofCopy.Text);
                //                    for (int i = 1; i <= val; i++)
                //                    {
                //                        rpt = new XtraReport();
                //                        rpt.Name = dname;
                //                        rpt.DisplayName = dname;
                //                        rpt.LoadLayoutFromXml(Stream);

                //                        if (rpt.Parameters.Count > 0)
                //                        {
                //                            rpt.Parameters["copyno"].Type = typeof(int);
                //                            rpt.Parameters["copyno"].Value = i;
                //                        }

                //                        rpt.DataSource = dataSet;

                //                        rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //                        rpt.Print();
                //                    }

                //                    sb.updatePrintStatus(item["Additional BillNo"].ToString(), clsGlobal.uName, _TodayDateTime);
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("Data not available");
                //                return;
                //            }
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Designe Not available");
                //        }
                //    }
                //    break;
                #endregion

                default:
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void CmbOption_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbOption.Text == "Number")
            {
                TxtFromVoucher.Visible = true;
                BtnFromVoucherSearch.Visible = true;
                TxtToVoucher.Visible = true;
                BtnToVoucherSearch.Visible = true;
                TxtFromDate.Visible = false;
                TxtToDate.Visible = false;
                lblFromVoucher.Text = "From Voucher";
                lblToVoucher.Text = "To Voucher";
                TxtFromVoucher.Focus();
            }
            else
            {
                TxtFromVoucher.Visible = false;
                BtnFromVoucherSearch.Visible = false;
                TxtToVoucher.Visible = false;
                BtnToVoucherSearch.Visible = false;
                TxtFromDate.Visible = true;
                TxtToDate.Visible = true;
                lblFromVoucher.Text = "From Date";
                lblToVoucher.Text = "To Date";
                TxtFromDate.Mask = "00/00/0000";
                TxtToDate.Mask = "00/00/0000";
                TxtFromDate.Location = new System.Drawing.Point(379, 15);
                TxtToDate.Location = new System.Drawing.Point(379, 49);
                TxtFromDate.Focus();
                if (ClsGlobal.DateType == "M")
                {
                    TxtFromDate.Text = _objDate.GetMiti(Convert.ToDateTime(ClsGlobal.CompanyStartDate));
                    TxtToDate.Text = _objDate.GetMiti(Convert.ToDateTime(ClsGlobal.CompanyEndDate));
                }
                else
                {
                    TxtFromDate.Text = ClsGlobal.CompanyStartDate;
                    TxtToDate.Text = ClsGlobal.CompanyEndDate;
                }
            }
        }
    }
}