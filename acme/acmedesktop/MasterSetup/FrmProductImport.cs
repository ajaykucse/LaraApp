using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MasterSetup
{
    public partial class FrmProductImport : Form
    {
        ClsCommon _objCommon = new ClsCommon();
        ClsProduct _objProduct = new ClsProduct();
        public FrmProductImport()
        {
            InitializeComponent();

        }
        private void FrmProductImport_Load(object sender, EventArgs e)
        {

        }
        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Worksheets|*.xlsx";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                DataTable dt = _objCommon.ReadExcelFile(System.IO.Path.GetFullPath(openFileDialog1.FileName),"Product");
                Grid.DataSource = dt;
                Grid.ClearSelection();
                Grid.AutoResizeColumns();
                Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            }
        }
        private void BtnDownloadFormat_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Desc");
            dt.Columns.Add("Product Code");
            dt.Columns.Add("Product Printing Name");
            dt.Columns.Add("Inventory/Fixed Assets");
            dt.Columns.Add("Product Group");
            dt.Columns.Add("Product Group Code");
            dt.Columns.Add("Product Sub Group");
            dt.Columns.Add("Product Sub Group Code");
            dt.Columns.Add("Product Unit");
            dt.Columns.Add("Product Unit Code");
            dt.Columns.Add("Buy Rate");
            dt.Columns.Add("Sales Rate");
           _objCommon.DataTableToExcel(dt, "Product");
        }
        private void BtnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = _objProduct.ProductListForImportFormat();
           _objCommon.DataTableToExcel(dt,"Product");
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
