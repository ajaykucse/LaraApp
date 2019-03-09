using DataAccessLayer.ARAPReport;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.ARAPReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.ARAPReport
{
    public partial class RptSalesRegister : Form
    {
        IRptSalesRegister _objRptSalesRegister = new ClsRptSalesRegister();
        ClsCommon _objCommon = new ClsCommon();
        static private PageSettings _myPageSettings = new PageSettings();
        public RptSalesRegister()
        {
            InitializeComponent();
            this.Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void RptSalesRegister_Load(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.BtnFilterOption, "Filter Option");
            ToolTip1.SetToolTip(this.BtnPrint, "Print");
            ToolTip1.SetToolTip(this.BtnEmail, "Email");
            ToolTip1.SetToolTip(this.BtnAdvanceSearch, "Advance Search");
            ToolTip1.SetToolTip(this.BtnExcel, "Export");
            Grid.DefaultCellStyle.Font = new Font("Arial", 11F, GraphicsUnit.Pixel);
        }
        private void RptSalesRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F)
            {
                BtnFilterOption.PerformClick();
            }
        }
        private void AfterLoading(object sender, EventArgs e)
        {
            this.Activated -= AfterLoading;
            FilterRptSalesRegister frm = new FilterRptSalesRegister();
            frm.ShowDialog();
            BindReport(frm);
        }

        private void BtnFilterOption_Click(object sender, EventArgs e)
        {
            FilterRptSalesRegister frm = new FilterRptSalesRegister();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            BindReport(frm);
        }

        private void BindReport(FilterRptSalesRegister frm)
        {
            DataTable dtTerm = new DataTable();
            DataSet ds = new DataSet();
            if (frm.ButtonAction == "OK")
            {
                DataTable NullDt = new DataTable();
                Grid.DataSource = NullDt;
                DateTime FromDate = new DateTime();
                DateTime ToDate = new DateTime();
                if (ClsGlobal.DateType == "D")
                {
                    FromDate = Convert.ToDateTime(frm.TxtFromDate.Text);
                    ToDate = Convert.ToDateTime(frm.TxtToDate.Text);
                }
                else
                {
                    FromDate = Convert.ToDateTime(frm.TxtFromDate.Tag.ToString());
                    ToDate = Convert.ToDateTime(frm.TxtToDate.Tag.ToString());
                }

                if (frm.ChkDetails.Checked == true && frm.ChkHorizontal.Checked == true) //------ DETAILS WITH HORIZONTAL DATE WISE ----------
                {
                    ds = _objRptSalesRegister.SalesRegisterDetailsHorizontalDateWise(FromDate, ToDate, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                    dtTerm = ds.Tables[1];
                    Grid.DataSource = ds.Tables[0];
                    Grid.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Basic Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Net Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Date"].Width = 75;
                    Grid.Columns["Qty"].Width = 100;
                    Grid.Columns["Rate"].Width = 90;
                    Grid.Columns["Basic Amt"].Width = 90;
                    Grid.Columns["Net Amt"].Width = 90;
                    Grid.Columns["Particular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (DataColumn col1 in dtTerm.Columns)
                    {
                        Grid.Columns[col1.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        Grid.Columns[col1.ColumnName].Width = 90;
                    }
                    foreach (DataGridViewRow row in Grid.Rows)
                    {
                        if (row.Cells["Particular"].Value.ToString() == "Total :" || row.Cells["Particular"].Value.ToString() == "Grand Total :")
                        {
                            Grid.Rows[row.Index].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        }
                    }
                }
                else if (frm.ChkDetails.Checked == true && frm.ChkProductHorizontal.Checked == true) //------ DETAILS WITH PRODUCT HORIZONTAL AND BILL VERTICLE DATE WISE ----------
                {
                    ds = _objRptSalesRegister.SalesRegisterDetailsProductHorizontalBillVerticleDateWise(FromDate, ToDate, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                    Grid.DataSource = ds.Tables[0];
                    Grid.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Basic Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Net Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Date"].Width = 75;
                    Grid.Columns["Qty"].Width = 100;
                    Grid.Columns["Rate"].Width = 90;
                    Grid.Columns["Basic Amt"].Width = 90;
                    foreach (DataColumn col1 in ds.Tables[1].Columns)
                    {
                        Grid.Columns[col1.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        Grid.Columns[col1.ColumnName].Width = 90;
                    }
                    Grid.Columns["Particular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (DataGridViewRow row in Grid.Rows)
                    {
                        if (string.IsNullOrEmpty(row.Cells["Date"].Value.ToString())  && !string.IsNullOrEmpty(row.Cells["Particular"].Value.ToString()))
                        {
                            Grid.Rows[row.Index].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        }
                    }
                }
                else if (frm.ChkDetails.Checked == true) //------ DETAILS WITH VERTICLE DATE WISE ----------
                {
                    ds = _objRptSalesRegister.SalesRegisterDetailsVerticleDateWise(FromDate, ToDate, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                    dtTerm = ds.Tables[1];
                    Grid.DataSource = ds.Tables[0];
                    Grid.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Basic Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Date"].Width = 75;
                    Grid.Columns["Qty"].Width = 100;
                    Grid.Columns["Rate"].Width = 90;
                    Grid.Columns["Basic Amt"].Width = 90;
                    Grid.Columns["Particular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (DataGridViewRow row in Grid.Rows)
                    {
                        if (row.Cells["Particular"].Value.ToString() == "Total :" || row.Cells["Particular"].Value.ToString() == "Grand Total :")
                        {
                            Grid.Rows[row.Index].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        }
                        foreach (DataColumn col1 in dtTerm.Columns)
                        {
                            if (row.Cells["Particular"].Value.ToString() == col1.ColumnName)
                            {
                                Grid.Rows[row.Index].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                            }
                        }
                    }
                }
                else  //--------------- SUMMARY DATE WISE ----------------
                {
                    ds = _objRptSalesRegister.SalesRegisterSummaryDateWise(FromDate, ToDate, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                    if (ds.Tables.Count > 1)
                        dtTerm = ds.Tables[1].Copy();

                    Grid.DataSource = ds.Tables[0];
                    Grid.Columns["Voucher No"].Width = 80;
                    Grid.Columns["Date"].Width = 75;
                    Grid.Columns["Miti"].Width = 75;
                    Grid.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid.Columns["Qty"].Width = 70;
                    Grid.Columns["Basic Amt"].Width = 90;
                    Grid.Columns["Net Amt"].Width = 90;
                    Grid.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Basic Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grid.Columns["Net Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    foreach (DataColumn col1 in dtTerm.Columns)
                    {
                        Grid.Columns[col1.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        Grid.Columns[col1.ColumnName].Width = 90;
                    }
                    Grid.Columns["Miti"].Visible = false;
                    if (frm.ChkOrderNo.Checked == false)
                    {
                        Grid.Columns["OrderNo"].Visible = false;
                    }
                    Grid.Rows[Grid.Rows.Count - 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                Grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                Grid.Columns["IsBold"].Visible = false;
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells["IsBold"].Value.ToString() == "Y")
                    {
                        Grid.Rows[row.Index].DefaultCellStyle.Font = new Font("Arial", 8f, FontStyle.Bold);
                    }
                }
            }
            frm.Dispose();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintPreview("porterate", "YES");
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(BtnPrintPreview, 0, BtnPrintPreview.Height);
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdvanceSearch_Click(object sender, EventArgs e)
        {

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            _objCommon.GridToExcel(Grid, "Sales Register");
        }

        private void PorteratePrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreview("porterate", "NO");
        }

        private void LandscapePrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreview("landscape", "NO");
        }

        private void PrintPreview(string Mode, string IsPrint)
        {
            this.Width = Mode == "porterate" ? 763 : 1019;
            ////------------ PRINT PREVIEW
            DGVPrinter printer = new DGVPrinter();
            printer.Title = LblCompanyName.Text;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(LblCompanyAddress.Text))
                strSql.Append(LblCompanyAddress.Text + "\n");
            if (!string.IsNullOrEmpty(LblCompanyPhoneNo.Text))
                strSql.Append(LblCompanyPhoneNo.Text + "\n");
            strSql.Append("\n");
            printer.SubTitle = strSql.ToString() + LblReportName.Text + "\n" + LblReportFromToDate.Text;
            printer.SubTitleSpacing = 5;
            //printer.SubTitle = string.Empty;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "FY :- " + ClsGlobal.CompanyFiscalYear;

            if (null != MyPageSettings)
                printer.printDocument.DefaultPageSettings = MyPageSettings;

            printer.PageSettings.Landscape = Mode == "porterate" ? false : true;
            MyPageSettings.Margins = new Margins(40, 60, 20, 60);
            printer.FooterSpacing = 5;
            printer.PreviewDialog = printPreviewDialog1;

            if (IsPrint == "YES")
                printer.PrintDataGridView(Grid);
            else
                printer.PrintPreviewDataGridView(Grid);
            this.Width = 1019;
        }

        private void RptSalesRegister_Resize(object sender, EventArgs e)
        {
            BtnPrint.Enabled = WindowState != FormWindowState.Normal ? false : true;
            BtnPrintPreview.Enabled = WindowState != FormWindowState.Normal ? false : true;
        }

        static public PageSettings MyPageSettings
        {
            get { return _myPageSettings; }
            set { _myPageSettings = value; }
        }

        private void BtnClipboardCopy_Click(object sender, EventArgs e)
        {
            Grid.MultiSelect = true;
            Grid.SelectAll();
            CopyToClipboardWithHeaders(Grid);
            //if (this.Grid.GetCellCount(DataGridViewElementStates.Selected) > 0)
            //{
            //    try
            //    {
            //        // Add the selection to the clipboard.
            //        Clipboard.SetDataObject(this.Grid.GetClipboardContent());

            //        // Replace the text box contents with the clipboard text.
            //        //this.TextBox1.Text = Clipboard.GetText();
            //    }
            //    catch (System.Runtime.InteropServices.ExternalException)
            //    {
            //        MessageBox.Show("The Clipboard could not be accessed. Please try again.");
            //    }
            //}
        }

        public void CopyToClipboardWithHeaders(DataGridView _dgv)
        {
            //Copy to clipboard
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
    }
}
