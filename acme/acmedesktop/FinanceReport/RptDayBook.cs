using DataAccessLayer.ARAPReport;
using DataAccessLayer.Common;
using DataAccessLayer.FinanceReport;
using DataAccessLayer.Interface.ARAPReport;
using DataAccessLayer.Interface.FinanceReport;
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

namespace acmedesktop.FinanceReport
{
    public partial class RptDayBook : Form
    {
        IRptAllLedger _objRptAllLedger = new ClsRptAllLedger();
        ClsCommon _objCommon = new ClsCommon();
        static private PageSettings _myPageSettings = new PageSettings();
        public RptDayBook()
        {
            InitializeComponent();
            this.Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void RptDayBook_Load(object sender, EventArgs e)
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
        private void RptDayBook_KeyDown(object sender, KeyEventArgs e)
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
            FilterRptDayBook frm = new FilterRptDayBook();
            frm.ShowDialog();
            BindReport(frm);
        }

        private void BtnFilterOption_Click(object sender, EventArgs e)
        {
            FilterRptDayBook frm = new FilterRptDayBook();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            BindReport(frm);
        }

        private void BindReport(FilterRptDayBook frm)
        {
            //DataTable dtTerm = new DataTable();
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
				    
                bool isNarrationShow = (frm.ChkNarration.Checked == true) ? true : false;
                ds = _objRptAllLedger.DayBookDateWise(FromDate, ToDate, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId, isNarrationShow);
                Grid.DataSource = ds.Tables[0];

				Grid.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				Grid.Columns["Voucher No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				Grid.Columns["Particulars"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				Grid.Columns["Dr Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				Grid.Columns["Cr Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

				Grid.Columns["Dr Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				Grid.Columns["Cr Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				int i = 0;
				foreach (DataGridViewRow row in Grid.Rows)
				{
					if (row.Cells["IsBold"].Value.ToString() == "Y" || row.Cells["Particulars"].Value.ToString() == "Total :" || row.Cells["Particulars"].Value.ToString() == "Day Total :" || row.Cells["Voucher No"].Value.ToString() == "Narr :")
					{
						if (row.Cells["IsBold"].Value.ToString() == "Y")
							Grid.Rows[row.Index].DefaultCellStyle.Font = new Font("Arial", 8f, FontStyle.Bold);
						if (row.Cells["Particulars"].Value.ToString() == "Total :" || row.Cells["Particulars"].Value.ToString() == "Day Total :")
							Grid.Rows[row.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

						if (row.Cells["Voucher No"].Value.ToString() == "Narr :")
						{
							Grid.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
							Grid.Rows[row.Index].DefaultCellStyle.Font = new Font("Arial", 8f, FontStyle.Italic);
						}
					}
					i++;
				}
				Grid.Columns["IsBold"].Visible = false;
                Grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
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
