using DataAccessLayer.Common;
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
    public partial class TagList : Form
    {
        public string ModuleName { get; set; }
        public List<DataRow> SelectedList = new List<DataRow>();
        private string SearchCol, _SearchKey = "", _ListType = "", _ListName = "";
        public static DataTable dt;
        public static string AcGroup = "", GlDesc = "", PGroup = "", PSGroup = "", PArea = "", PAgent = "", TargetDataBase = "";
        public static string ModuleType = "";
        private ClsPickList _objPickList = new ClsPickList();
        private string _SplitedValue = string.Empty;
        List<string> selectedRow = new List<string>();
        int columnCount = 0;
        public TagList(string ListType, string ListName, string SearchKey)
        {
            InitializeComponent();
            _ListName = ListName;
            GetList(ListType);
            _SearchKey = SearchKey;
        }
        #region --------------- NOT CHNAGE ---------------------
        private void TagList_Load(object sender, EventArgs e)
        {
            Search(_SearchKey);
            this.Text = _ListName;
        }
        private void TagList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8)
            {
                if (TxtSearch.Text.Length > 0)
                    TxtSearch.Text = TxtSearch.Text.Substring(0, TxtSearch.Text.Length - 1);
            }
            else if ((int)e.KeyChar == 27)
            {
                this.Close();
            }
            else if ((int)e.KeyChar == 13)
            {

            }
            else
                TxtSearch.Text += e.KeyChar.ToString();
        }
        public DataTable GetDataTable()
        {
            DataTable dtLocal = new DataTable();
            dtLocal = dt.Clone();

            string colname = Grid.Columns[Grid.CurrentCell.ColumnIndex].Name;

            DataRow drLocal = null;
            foreach (DataGridViewRow dr in Grid.Rows)
            {
                drLocal = dtLocal.NewRow();
                for (var i = 0; i < Grid.Columns.Count; i++)
                {
                    var item = Grid.Columns[i].DataPropertyName;
                    drLocal[item] = dr.Cells[i].Value;
                }

                dtLocal.Rows.Add(drLocal);
            }
            return dtLocal;
        }
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Grid.Rows.Count > 0)
                {
                    int indx = Convert.ToInt32(Grid.CurrentRow.Index);
                    var itm = selectedRow.FirstOrDefault(x => x.Contains(indx.ToString()));
                    if (itm != null)
                    {
                        selectedRow.Remove(indx.ToString());

                        foreach (DataGridViewRow dr in Grid.Rows)
                        {
                            columnCount = Grid.Columns.Count;
                            break;
                        }

                        for (int j = 0; j < columnCount; j++)
                        {
                            Grid.Rows[indx].Cells[j].Style.BackColor = Color.White;
                            Grid.Rows[indx].Cells[j].Style.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        selectedRow.Add(indx.ToString());
                    }

                    RowSelected();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                BtnCancel.PerformClick();
            }
        }
        private void RowSelected()
        {
            for (int i = 0; i < selectedRow.Count; i++)
            {
                try
                {
                    foreach (DataGridViewRow dr in Grid.Rows)
                    {
                        columnCount = Grid.Columns.Count;
                        break;
                    }

                    Grid.Rows[Convert.ToInt32(selectedRow[i].ToString())].Selected = true;

                    for (int j = 0; j < columnCount; j++)
                    {
                        Grid.Rows[Convert.ToInt32(selectedRow[i].ToString())].Cells[j].Style.BackColor = Color.Gray;
                        Grid.Rows[Convert.ToInt32(selectedRow[i].ToString())].Cells[j].Style.ForeColor = Color.White;
                    }
                }
                catch { }
            }
        }
        private void Search(string SearchText)
        {
            int colIndex = 0, rowIndex = 0;
            BindingSource bs = new BindingSource();
            if (!string.IsNullOrEmpty(SearchText) && SearchText != "F1")
            {
                try
                {
                    TxtSearch.Text = SearchText;
                    bs.DataSource = Grid.DataSource;
                    bs.Filter = string.Format("Convert(" + SearchCol + ", 'System.String')") + " like '%" + TxtSearch.Text + "%'";
                    Grid.DataSource = bs;
                    DataGridViewRow row = new DataGridViewRow();
                    Grid.Rows[0].Cells[colIndex].Selected = true;
                }
                catch
                { }
            }
            else
            {
                try
                {
                    bs.DataSource = Grid.DataSource;
                    bs.Filter = string.Format("Convert(" + SearchCol + ", 'System.String')") + " like '%" + TxtSearch.Text + "%'";
                    Grid.DataSource = bs;
                    rowIndex = Grid.CurrentCell.RowIndex;
                    Grid.Rows[0].Cells[colIndex].Selected = true;
                }
                catch
                { }
            }

            RowSelected();
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(TxtSearch.Text);
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (selectedRow.Count > 0)
            {
                DataTable dt1 = GetDataTable();
                for (int i = 0; i < selectedRow.Count; i++)
                {
                    SelectedList.Add(dt1.Rows[Convert.ToInt32(selectedRow[i].ToString())]);
                }
            }
            this.Close();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SelectedList = new List<DataRow>();
            this.Close();
        }
        private void BtnTagAll_Click(object sender, EventArgs e)
        {
            selectedRow.Clear();
            for (int i = 0; i < Grid.RowCount; i++)
            {
                selectedRow.Add(i.ToString());
            }
            RowSelected();
        }
        private void BtnUnTagAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in Grid.Rows)
            {
                columnCount = Grid.Columns.Count;
                break;
            }

            for (int i = 0; i < Grid.RowCount; i++)
            {
                selectedRow.Remove(i.ToString());
                for (int j = 0; j < columnCount; j++)
                {
                    Grid.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Grid.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
        }
        private void BtnInvert_Click(object sender, EventArgs e)
        {

        }
        private void Grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indx = Convert.ToInt32(e.RowIndex);
            var itm = selectedRow.FirstOrDefault(x => x.Contains(indx.ToString()));
            if (itm != null)
            {
                selectedRow.Remove(indx.ToString());

                foreach (DataGridViewRow dr in Grid.Rows)
                {
                    columnCount = Grid.Columns.Count;
                    break;
                }

                for (int j = 0; j < columnCount; j++)
                {
                    Grid.Rows[indx].Cells[j].Style.BackColor = Color.White;
                    Grid.Rows[indx].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            else
            {
                selectedRow.Add(indx.ToString());
            }

            RowSelected();
        }
        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnOk.PerformClick();
        }
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indx = Convert.ToInt32(Grid.CurrentRow.Index);
            var itm = selectedRow.FirstOrDefault(x => x.Contains(indx.ToString()));
            if (itm != null)
            {
                selectedRow.Remove(indx.ToString());

                foreach (DataGridViewRow dr in Grid.Rows)
                {
                    columnCount = Grid.Columns.Count;
                    break;
                }

                for (int j = 0; j < columnCount; j++)
                {
                    Grid.Rows[indx].Cells[j].Style.BackColor = Color.White;
                    Grid.Rows[indx].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            else
            {
                selectedRow.Add(indx.ToString());
            }

            RowSelected();
        }
        #endregion

        public void GetList(string ListType)
        {
            switch (ListType)
            {
                //case "Entry.RefQuotNo":
                //    RefQuotNo();
                //    SearchCol = "Sb_QuotNo";
                //    break;
                //case "Entry.RefOrderNo":
                //    RefOrderNo();
                //    SearchCol = "Sb_OrderNo";
                //    break;
                //case "Entry.RefChallanNo":
                //    RefChallanNo();
                //    SearchCol = "Sb_ChallanNo";
                //    break;
                //case "SalesDispatchOrder":
                //    SalesDispatchList();
                //    SearchCol = "Sb_DisOrderNo";
                //    break;
                //case "Entry.RefPurchaseIndent":
                //    RefPurchaseIndent();
                //    SearchCol = "Indent_No";
                //    break;
                //case "Entry.RefPurchaseQuotNo":
                //    RefPurchaseQuotNo();
                //    SearchCol = "Quot_No";
                //    break;
                //case "Entry.RefPurchaseOrderNo":
                //    RefPurchaseOrderNo();
                //    SearchCol = "Order_No";
                //    break;
                //case "Entry.RefPurchaseChallanNo":
                //    RefPurchaseChallanNo();
                //    SearchCol = "Challan_No";
                //    break;
                //case "Product":
                //    ProductList();
                //    SearchCol = "P_Desc";
                //    break;
                //case "Product1":
                //    ProductList();
                //    SearchCol = "P_Desc";
                //    break;
                //case "Product2":
                //    ProductList();
                //    SearchCol = "P_ShortName";
                //    break;
                //case "ProductGroup":
                //    ProductGroupList();
                //    SearchCol = "Pr_GrpDesc";
                //    break;
                //case "Product.SubGroup":
                //    ProductSubGroupList();
                //    SearchCol = "Pr_GrpDesc";
                //    break;
                //case "Account.Customer":
                //    AccountCustomerList();
                //    SearchCol = "Gl_Desc";
                //    break;
                //case "Account.Customer1":
                //    AccountCustomerList1();
                //    SearchCol = "Gl_Desc";
                //    break;
                //case "Account.Vendor1":
                //    AccountvendorList1();
                //    SearchCol = "Gl_Desc";
                //    break;
                //case "AgentArea.Agent":
                //    AgentList();
                //    SearchCol = "Agent_Desc";
                //    break;

                //case "DebitNote.Agent":
                //    DebitNoteAgentList();
                //    SearchCol = "Agent_Desc";
                //    break;
                //case "DebitNote.Area":
                //    DebitNoteAreaList();
                //    SearchCol = "Agent_Desc";
                //    break;

                //case "AgentArea.Area":
                //    AreaList();
                //    SearchCol = "Area_Desc";
                //    break;
                //case "UserMaster.UserMaster":
                //    UserMasterList();
                //    SearchCol = "Hu_Name";
                //    break;
                //case "Master.Class1":
                //    ClassList("1");
                //    SearchCol = "Cls_Desc";
                //    break;
                //case "Master.Class2":
                //    ClassList("2");
                //    SearchCol = "Cls_Desc";
                //    break;
                //case "Master.Class3":
                //    ClassList("3");
                //    SearchCol = "Cls_Desc";
                //    break;
                //case "InvoiceList":
                //    InvoiceList();
                //    SearchCol = "Invoice No";
                //    break;
                //case "Report.Product":
                //    ReportProductList();
                //    SearchCol = "P_Desc";
                //    break;
                //case "Report.ProductGroup":
                //    ReportProductGroupList();
                //    SearchCol = "Pr_GrpDesc";
                //    break;
                //case "Report.ProductSubGroup":
                //    ReportProductSubGroupList();
                //    SearchCol = "Pr_SGrpDesc";
                //    break;
                //case "Report.GlDesc":
                //    LedgerGlDesc();
                //    SearchCol = "Gl_Desc";
                //    break;
                case "Report.GeneralledgerList":
                    GeneralledgerList();
                    SearchCol = "GlDesc";
                    break;
                //case "Report.AcGroup":
                //    ReportAcGroup();
                //    SearchCol = "Ac_Desc";
                //    break;
                //case "Report.GlWithAcGroup":
                //    LedgerwithAccGroup();
                //    SearchCol = "Gl_Desc";
                //    break;
                //case "Report.AcSubGroupWithAcGroup":
                //    AccSubGroupWithAccGroup();
                //    SearchCol = "Ac_SGrpDesc";
                //    break;
                //case "Report.CashBankDesc":
                //    CashBankDesc();
                //    SearchCol = "GL_Code";
                //    break;
                //case "Report.PRAreaCustomer":
                //    PRCustomer();
                //    SearchCol = "Gl_Desc";
                //    break;
                //case "Report.DebitNote":
                //    DebitParty();
                //    SearchCol = "Gl_Desc";
                //    break;

                //case "Report.PRVendor":
                //    PRVendor();
                //    SearchCol = "Gl_Desc";
                //    break;

                //case "Ageing.Customer":
                //    AgeingCustomer();
                //    SearchCol = "Gl_Desc";
                //    break;
                //case "CopyMaster.AccountMaster":
                //    CopyMasterAccountMaster();
                //    SearchCol = "Ac_Desc";
                //    break;

                //case "CopyMaster.AccountSubGroup":
                //    CopyMasterAccountSubGroup();
                //    SearchCol = "Ac_SGrpDesc";
                //    break;

                //case "CopyMaster.Agent":
                //    CopyMasterAgent();
                //    SearchCol = "Agent_Desc";
                //    break;

                //case "CopyMaster.Area":
                //    CopyMasterArea();
                //    SearchCol = "Area_Desc";
                //    break;

                //case "CopyMaster.GeneralLedger":
                //    CopyMasterGeneralLedger();
                //    SearchCol = "Gl_Desc";
                //    break;

                //case "CopyMaster.SubLedger":
                //    CopyMasterSubLedger();
                //    SearchCol = "Cur_Desc";
                //    break;

                //case "CopyMaster.ProductGroup":
                //    CopyMasterProductGroup();
                //    SearchCol = "Pr_GrpDesc";
                //    break;

                //case "CopyMaster.ProductSubGroup":
                //    CopyMasterProductSubGroup();
                //    SearchCol = "Pr_SGrpDesc";
                //    break;

                //case "CopyMaster.Unit":
                //    CopyMasterUnit();
                //    SearchCol = "Unit_Desc";
                //    break;

                //case "CopyMaster.Product":
                //    CopyMasterProduct();
                //    SearchCol = "P_Desc";
                //    break;

                //case "CopyMaster.ProductScheme":
                //    CopyMasterProductScheme();
                //    SearchCol = "Scheme_Name";
                //    break;

                //case "CopyMaster.Godown":
                //    CopyMasterGodown();
                //    SearchCol = "Gdn_Desc";
                //    break;

                //case "CopyMaster.SalesTerm":
                //    CopyMasterSalesTerm();
                //    SearchCol = "ST_Desc";
                //    break;

                //case "CopyMaster.PurchaseTerm":
                //    CopyMasterPurchaseTerm();
                //    SearchCol = "PT_Desc";
                //    break;

                //case "CopyMaster.Class":
                //    CopyMasterClass();
                //    SearchCol = "Cls_Desc";
                //    break;

                //case "CopyMaster.Currency":
                //    CopyMasterCurrency();
                //    SearchCol = "Cur_Desc";
                //    break;

                //case "CopyMaster.CostCenter":
                //    CopyMasterCostCenter();
                //    SearchCol = "CC_Desc";
                //    break;

                //case "CopyMaster.NarrationMaster":
                //    CopyMasterNarrationMaster();
                //    SearchCol = "Narr_Desc";
                //    break;

                //case "CopyMaster.DocumentNumbering":
                //    CopyMasterDocumentNumbering();
                //    SearchCol = "Cur_Desc";
                //    break;
                //case "BranchSelection":
                //    BranchSelection();
                //    SearchCol = "Branch Name";
                //    break;
                //case "HouseKeep.DocumentMissNumbering":
                //    HouseKeepDocumentNumbering();
                //    SearchCol = "Doc_Desc";
                //    break;
                //case "HouseKeep.AuditTraial":
                //    AuditTraial();
                //    SearchCol = "Module_Name";
                //    break;
                //case "HouseKeep.EntryLogRegister":
                //    EntryLogRegister();
                //    SearchCol = "Module_Name";
                //    break;
            }
        }
        //private void EntryLogRegister()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = new DataTable();
        //    if (dt.Columns.Count == 0)
        //    {
        //        dt.Columns.Add("Module_Name");
        //    }
        //    dt.Rows.Clear();

        //    dt.Rows.Add("Cash/Bank Voucher");
        //    dt.Rows.Add("Journal Voucher");
        //    dt.Rows.Add("Debit Note");
        //    dt.Rows.Add("Credit Note");
        //    dt.Rows.Add("Purchase Order");
        //    dt.Rows.Add("Purchase Challan");
        //    dt.Rows.Add("Purchase Invoice");
        //    dt.Rows.Add("Purchase Additional Invoice");
        //    dt.Rows.Add("Purchase Return");
        //    dt.Rows.Add("Sales Order");
        //    dt.Rows.Add("Sales Challan");
        //    dt.Rows.Add("Abbreviated Tax Invoice");
        //    dt.Rows.Add("Sales Invoice");
        //    dt.Rows.Add("Sales Return");
        //    dt.Rows.Add("Godown Transfer");
        //    dt.Rows.Add("Stock Adjustment");
        //    dt.Rows.Add("Inventory Issue");
        //    dt.Rows.Add("Finished Goods Recieved");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Module_Name", "Module Name");
        //    Grid.Columns["Module_Name"].DataPropertyName = "Module_Name";
        //    Grid.Columns["Module_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    Grid.Columns["Module_Name"].Visible = true;
        //}
        //private void AuditTraial()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = new DataTable();
        //    if (dt.Columns.Count == 0)
        //    {
        //        dt.Columns.Add("Module_Name");
        //    }
        //    dt.Rows.Clear();

        //    dt.Rows.Add("Cash/Bank Voucher");
        //    dt.Rows.Add("Journal Voucher");
        //    dt.Rows.Add("Debit Note");
        //    dt.Rows.Add("Credit Note");
        //    dt.Rows.Add("Purchase Order");
        //    dt.Rows.Add("Purchase Challan");
        //    dt.Rows.Add("Purchase Invoice");
        //    dt.Rows.Add("Purchase Additional Invoice");
        //    dt.Rows.Add("Purchase Return");
        //    dt.Rows.Add("Sales Order");
        //    dt.Rows.Add("Sales Challan");
        //    dt.Rows.Add("Abbreviated Tax Invoice");
        //    dt.Rows.Add("Sales Invoice");
        //    dt.Rows.Add("Sales Return");
        //    dt.Rows.Add("Godown Transfer");
        //    dt.Rows.Add("Stock Adjustment");
        //    dt.Rows.Add("Inventory Issue");
        //    dt.Rows.Add("Finished Goods Recieved");
        //    dt.Rows.Add("General Ledger");
        //    dt.Rows.Add("Product");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Module_Name", "Module Name");
        //    Grid.Columns["Module_Name"].DataPropertyName = "Module_Name";
        //    Grid.Columns["Module_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    Grid.Columns["Module_Name"].Visible = true;
        //}
        //private void HouseKeepDocumentNumbering()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    Module_Name = clsGlobal.ChallanNo;
        //    dt = clsGlobal.FetchDataTable("select Doc_Code,Module_Name, Doc_Desc from Doc_numbering_scheme where Module_Name in (" + Module_Name + ")");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Doc_Code", " Code");
        //    Grid.Columns["Doc_Code"].DataPropertyName = "Doc_Code";
        //    Grid.Columns["Doc_Code"].Width = 50;
        //    Grid.Columns["Doc_Code"].Visible = false;

        //    Grid.Columns.Add("Module_Name", "Name");
        //    Grid.Columns["Module_Name"].DataPropertyName = "Module_Name";
        //    Grid.Columns["Module_Name"].Width = 50;
        //    Grid.Columns["Module_Name"].Visible = true;

        //    Grid.Columns.Add("Doc_Desc", "Description");
        //    Grid.Columns["Doc_Desc"].DataPropertyName = "Doc_Desc";
        //    Grid.Columns["Doc_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void BranchSelection()
        //{
        //    POSDAL.Master.Others.Branch objBranch = new POSDAL.Master.Others.Branch(Util.Database.DBConnection);
        //    Grid.AutoGenerateColumns = false;
        //    dt = objBranch.GetBranchByUserName(clsGlobal.uName, clsGlobal.uCompDatabaseName);

        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Branch Name", "Branch Name");
        //    Grid.Columns["Branch Name"].DataPropertyName = "Branch Name";
        //    Grid.Columns["Branch Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Br_Code", "Code");
        //    Grid.Columns["Br_Code"].DataPropertyName = "Br_Code";
        //    Grid.Columns["Br_Code"].Visible = false;

        //    Grid.Columns.Add("Br_ShortName", "ShortName");
        //    Grid.Columns["Br_ShortName"].DataPropertyName = "Br_ShortName";
        //    Grid.Columns["Br_ShortName"].Visible = false;
        //}
        //private void CopyMasterDocumentNumbering()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Doc_Code,Doc_Desc from " + TargetDataBase + ".dbo.Doc_Numbering_Scheme");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Doc_Desc", "Description");
        //    Grid.Columns["Doc_Desc"].DataPropertyName = "Doc_Desc";
        //    Grid.Columns["Doc_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Doc_Code", "Code");
        //    Grid.Columns["Doc_Code"].DataPropertyName = "Doc_Code";
        //    Grid.Columns["Doc_Code"].Visible = false;
        //}
        //private void CopyMasterNarrationMaster()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Narr_Code,Narr_Desc from    " + TargetDataBase + ".dbo.Narration_Master");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Narr_Desc", "Description");
        //    Grid.Columns["Narr_Desc"].DataPropertyName = "Narr_Desc";
        //    Grid.Columns["Narr_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Narr_Code", "Code");
        //    Grid.Columns["Narr_Code"].DataPropertyName = "Narr_Code";
        //    Grid.Columns["Narr_Code"].Visible = false;
        //}
        //private void CopyMasterCostCenter()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select CC_Code,CC_Desc,CC_ShortName from    " + TargetDataBase + ".dbo.Cost_Center");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("CC_Desc", "Description");
        //    Grid.Columns["CC_Desc"].DataPropertyName = "CC_Desc";
        //    Grid.Columns["CC_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("CC_Code", "Code");
        //    Grid.Columns["CC_Code"].DataPropertyName = "CC_Code";
        //    Grid.Columns["CC_Code"].Visible = false;
        //}
        //private void CopyMasterClass()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Cls_Code,Cls_Desc,Cls_ShortName from    " + TargetDataBase + ".dbo.Class");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Cls_Desc", "Description");
        //    Grid.Columns["Cls_Desc"].DataPropertyName = "Cls_Desc";
        //    Grid.Columns["Cls_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Cls_Code", "Code");
        //    Grid.Columns["Cls_Code"].DataPropertyName = "Cls_Code";
        //    Grid.Columns["Cls_Code"].Visible = false;
        //}
        //private void CopyMasterPurchaseTerm()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select PT_Code,PT_Desc from   " + TargetDataBase + ".dbo.Purchase_BillingTerm_Master");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("PT_Desc", "Description");
        //    Grid.Columns["PT_Desc"].DataPropertyName = "PT_Desc";
        //    Grid.Columns["PT_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("PT_Code", "Code");
        //    Grid.Columns["PT_Code"].DataPropertyName = "PT_Code";
        //    Grid.Columns["PT_Code"].Visible = false;
        //}
        //private void CopyMasterSalesTerm()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select ST_Code,ST_Desc from   " + TargetDataBase + ".dbo.Sales_BillingTerm_Master");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("ST_Desc", "Description");
        //    Grid.Columns["ST_Desc"].DataPropertyName = "ST_Desc";
        //    Grid.Columns["ST_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("ST_Code", "Code");
        //    Grid.Columns["ST_Code"].DataPropertyName = "ST_Code";
        //    Grid.Columns["ST_Code"].Visible = false;
        //}
        //private void CopyMasterGodown()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Gdn_Code,Gdn_Desc from  " + TargetDataBase + ".dbo.Godown");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Gdn_Desc", "Description");
        //    Grid.Columns["Gdn_Desc"].DataPropertyName = "Gdn_Desc";
        //    Grid.Columns["Gdn_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Gdn_Code", "Code");
        //    Grid.Columns["Gdn_Code"].DataPropertyName = "Gdn_Code";
        //    Grid.Columns["Gdn_Code"].Visible = false;
        //}
        //private void CopyMasterProductScheme()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Scheme_Code,Scheme_Name from   " + TargetDataBase + ".dbo.Special_Rate_master");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Scheme_Name", "Description");
        //    Grid.Columns["Scheme_Name"].DataPropertyName = "Scheme_Name";
        //    Grid.Columns["Scheme_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Scheme_Code", "Code");
        //    Grid.Columns["Scheme_Code"].DataPropertyName = "Scheme_Code";
        //    Grid.Columns["Scheme_Code"].Visible = false;
        //}
        //private void CopyMasterProduct()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select P_Code,P_Desc,P_ShortName from  " + TargetDataBase + ".dbo.Product");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("P_Desc", "Description");
        //    Grid.Columns["P_Desc"].DataPropertyName = "P_Desc";
        //    Grid.Columns["P_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("P_ShortName", "ShortName");
        //    Grid.Columns["P_ShortName"].DataPropertyName = "P_ShortName";
        //    Grid.Columns["P_ShortName"].Width = 100;

        //    Grid.Columns.Add("P_Code", "Code");
        //    Grid.Columns["P_Code"].DataPropertyName = "P_Code";
        //    Grid.Columns["P_Code"].Visible = false;
        //}
        //private void CopyMasterUnit()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Unit_Code,Unit_Desc from  " + TargetDataBase + ".dbo.Prod_Unit");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Unit_Desc", "Description");
        //    Grid.Columns["Unit_Desc"].DataPropertyName = "Unit_Desc";
        //    Grid.Columns["Unit_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Unit_Code", "Code");
        //    Grid.Columns["Unit_Code"].DataPropertyName = "Unit_Code";
        //    Grid.Columns["Unit_Code"].Visible = false;
        //}
        //private void CopyMasterProductSubGroup()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Pr_SGrpCode,Pr_SGrpDesc from  " + TargetDataBase + ".dbo.Product_Sub_Group");

        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Pr_SGrpDesc", "Description");
        //    Grid.Columns["Pr_SGrpDesc"].DataPropertyName = "Pr_SGrpDesc";
        //    Grid.Columns["Pr_SGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Pr_SGrpCode", "Code");
        //    Grid.Columns["Pr_SGrpCode"].DataPropertyName = "Pr_SGrpCode";
        //    Grid.Columns["Pr_SGrpCode"].Visible = false;
        //}
        //private void CopyMasterProductGroup()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Pr_GrpCode,Pr_GrpDesc from  " + TargetDataBase + ".dbo.Product_Group");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Pr_GrpDesc", "Description");
        //    Grid.Columns["Pr_GrpDesc"].DataPropertyName = "Pr_GrpDesc";
        //    Grid.Columns["Pr_GrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Pr_GrpCode", "Code");
        //    Grid.Columns["Pr_GrpCode"].DataPropertyName = "Pr_GrpCode";
        //    Grid.Columns["Pr_GrpCode"].Visible = false;
        //}
        //private void CopyMasterSubLedger()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Sl_Code,Sl_Desc from  " + TargetDataBase + ".dbo.Sub_Ledger");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Sl_Desc", "Description");
        //    Grid.Columns["Sl_Desc"].DataPropertyName = "Sl_Desc";
        //    Grid.Columns["Sl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Sl_Code", "Code");
        //    Grid.Columns["Sl_Code"].DataPropertyName = "Sl_Code";
        //    Grid.Columns["Sl_Code"].Visible = false;
        //}
        //private void CopyMasterGeneralLedger()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Gl_Code,Gl_Desc,(case gl_category when 'CU' then 'Customer' when 'OT' then 'Other' when 'BO' then 'Both' else 'Vendor' end) as Category from " + TargetDataBase + ".dbo.General_Ledger");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Gl_Desc", "Description");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Category", "Category");
        //    Grid.Columns["Category"].DataPropertyName = "Category";
        //    Grid.Columns["Category"].Width = 100;

        //    Grid.Columns.Add("Gl_Code", "Code");
        //    Grid.Columns["Gl_Code"].DataPropertyName = "Gl_Code";
        //    Grid.Columns["Gl_Code"].Visible = false;
        //}
        //private void CopyMasterArea()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Area_Code,Area_Desc from " + TargetDataBase + ".dbo.Area");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Area_Desc", "Description");
        //    Grid.Columns["Area_Desc"].DataPropertyName = "Area_Desc";
        //    Grid.Columns["Area_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Area_Code", "Code");
        //    Grid.Columns["Area_Code"].DataPropertyName = "Area_Code";
        //    Grid.Columns["Area_Code"].Visible = false;
        //}
        //private void CopyMasterAgent()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Agent_Code,Agent_Desc from " + TargetDataBase + ".dbo.Agent");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Agent_Desc", "Description");
        //    Grid.Columns["Agent_Desc"].DataPropertyName = "Agent_Desc";
        //    Grid.Columns["Agent_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Agent_Code", "Code");
        //    Grid.Columns["Agent_Code"].DataPropertyName = "Agent_Code";
        //    Grid.Columns["Agent_Code"].Visible = false;
        //}
        //private void CopyMasterCurrency()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Cur_Code,Cur_Desc from " + TargetDataBase + ".dbo.Currency");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Cur_Desc", "Description");
        //    Grid.Columns["Cur_Desc"].DataPropertyName = "Cur_Desc";
        //    Grid.Columns["Cur_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Cur_Code", "Code");
        //    Grid.Columns["Cur_Code"].DataPropertyName = "Cur_Code";
        //    Grid.Columns["Cur_Code"].Visible = false;
        //}
        //private void CopyMasterAccountSubGroup()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Ac_SGrpCode,Ac_SGrpDesc from " + TargetDataBase + ".dbo.Account_Sub_Group");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Ac_SGrpDesc", "Description");
        //    Grid.Columns["Ac_SGrpDesc"].DataPropertyName = "Ac_SGrpDesc";
        //    Grid.Columns["Ac_SGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Ac_SGrpCode", "Code");
        //    Grid.Columns["Ac_SGrpCode"].DataPropertyName = "Ac_SGrpCode";
        //    Grid.Columns["Ac_SGrpCode"].Visible = false;
        //}
        //private void CopyMasterAccountMaster()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Ac_GrpCode,Ac_Desc from " + TargetDataBase + ".dbo.Account_Group");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Ac_Desc", "Description");
        //    Grid.Columns["Ac_Desc"].DataPropertyName = "Ac_Desc";
        //    Grid.Columns["Ac_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Ac_GrpCode", "Code");
        //    Grid.Columns["Ac_GrpCode"].DataPropertyName = "Ac_GrpCode";
        //    Grid.Columns["Ac_GrpCode"].Visible = false;
        //}
        //private void AgeingCustomer()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Gl_desc,Gl_ShortName,'Customer' as type from general_ledger where gl_category in ('CU','BO') order by gl_desc");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Gl_desc", "Name");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";

        //    Grid.Columns["Gl_desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Gl_ShortName", "Short Name");
        //    Grid.Columns["Gl_ShortName"].DataPropertyName = "Gl_ShortName";
        //    Grid.Columns["Gl_ShortName"].Width = 120;

        //    Grid.Columns.Add("type", "Type");
        //    Grid.Columns["type"].DataPropertyName = "type";
        //    Grid.Columns["type"].Width = 120;
        //}
        //private void PRVendor()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    string smt = "";
        //    smt = "Select G.Gl_Code,Gl_Desc,A.Agent_Desc,AA.Area_Desc from general_ledger as G Left outer Join Agent as A on G.Agent_Code = A.Agent_Code Left Outer Join Area as AA on G.Area_Code = AA.Area_Code  where Gl_Category in ('VE','BO')";
        //    if (!string.IsNullOrEmpty(PArea))
        //        smt += "and Area_Desc in (" + PArea + ")";
        //    else if (!string.IsNullOrEmpty(PAgent))
        //        smt += "and Agent_Desc in (" + PAgent + ")";
        //    smt += "order by Gl_Desc";
        //    dt = clsGlobal.FetchDataTable(smt);
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Gl_desc", "Description");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";
        //    Grid.Columns["Gl_desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("GL_Code", "Code");
        //    Grid.Columns["GL_Code"].DataPropertyName = "GL_Code";
        //    Grid.Columns["GL_Code"].Visible = false;
        //}
        //private void PRCustomer()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    string smt = "";
        //    smt = "Select G.Gl_Code,Gl_Desc,A.Agent_Desc,AA.Area_Desc from general_ledger as G Left outer Join Agent as A on G.Agent_Code = A.Agent_Code Left Outer Join Area as AA on G.Area_Code = AA.Area_Code  where Gl_Category in ('CU','BO')";
        //    if (!string.IsNullOrEmpty(PArea))
        //        smt += "and Area_Desc in (" + PArea + ")";
        //    else if (!string.IsNullOrEmpty(PAgent))
        //        smt += "and Agent_Desc in (" + PAgent + ")";
        //    smt += "order by Gl_Desc";
        //    dt = clsGlobal.FetchDataTable(smt);
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Gl_desc", "Description");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";
        //    Grid.Columns["Gl_desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("GL_Code", "Code");
        //    Grid.Columns["GL_Code"].DataPropertyName = "GL_Code";
        //    Grid.Columns["GL_Code"].Visible = false;
        //}
        //private void DebitParty()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    string smt = "";
        //    smt = "SELECT Distinct GLM.Gl_Code,GLM.Gl_Desc,GLM.Gl_ShortName from DebitNote_Master AS DND INNER JOIN DebitNote_Master AS DNM ON DNM.DN_Number=DND.DN_Number  INNER JOIN  General_Ledger AS GLM ON GLM.Gl_Code=DNM.Gl_Code  INNER JOIN  General_Ledger AS GLD ON GLD.Gl_Code=DND.Gl_Code  LEFT JOIN Agent AS A ON A.Agent_Code=DNM.Agent_Code LEFT JOIN Sub_Ledger AS SL ON SL.Sl_Code=DND.Sl_Code  LEFT JOIN Class AS C ON C.Cls_Code=DNM.Cls_Code  LEFT JOIN Class AS C1 ON C1.Cls_Code=DNM.Cls_Code1  LEFT JOIN Class AS C2 ON C2.Cls_Code=DNM.Cls_Code2  LEFT JOIN Currency AS CUR ON CUR.Cur_Code=DNM.Cr_Code ";
        //    if (!string.IsNullOrEmpty(PArea))
        //        smt += "and Area_Desc in (" + PArea + ")";
        //    else if (!string.IsNullOrEmpty(PAgent))
        //        smt += "and Agent_Desc in (" + PAgent + ")";
        //    smt += "order by Gl_Desc";
        //    dt = clsGlobal.FetchDataTable(smt);
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Gl_desc", "Description");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";
        //    Grid.Columns["Gl_desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("GL_Code", "Code");
        //    Grid.Columns["GL_Code"].DataPropertyName = "GL_Code";
        //    Grid.Columns["GL_Code"].Visible = false;
        //}
        //private void CashBankDesc()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("select Gl_desc,Gl_code from general_ledger where cash_bank = 'Y' order by gl_desc");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Gl_desc", "Description");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";
        //    Grid.Columns["Gl_desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    Grid.Columns.Add("GL_Code", "Code");
        //    Grid.Columns["GL_Code"].DataPropertyName = "GL_Code";
        //    Grid.Columns["GL_Code"].Width = 150;
        //}
        //private void LedgerwithAccGroup()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Gl_Desc,gl_shortname from General_Ledger where Gl_Category = 'OT' and  Cash_Bank <> 'Y' AND Cash_Book <> 'Y' AND Ac_GrpCode IN(select Ac_GrpCode from Account_Group where Ac_Desc in(" + AcGroup + ")) order by Gl_Desc");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Gl_desc", "Description");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";
        //    Grid.Columns["Gl_desc"].Width = 500;
        //    Grid.Columns.Add("gl_shortname", "Short Name");
        //    Grid.Columns["gl_shortname"].DataPropertyName = "gl_shortname";
        //    Grid.Columns["gl_shortname"].Width = 150;
        //}
        //private void ReportAcGroup()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("select Ac_GrpCode,Ac_Desc, Ac_Type from Account_Group Order by Ac_Desc");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Ac_GrpCode", "Ac_GrpCode");
        //    Grid.Columns["Ac_GrpCode"].DataPropertyName = "Ac_GrpCode";
        //    Grid.Columns["Ac_GrpCode"].Visible = false;
        //    Grid.Columns.Add("Ac_Desc", "Description");
        //    Grid.Columns["Ac_Desc"].DataPropertyName = "Ac_Desc";
        //    Grid.Columns["Ac_Desc"].Width = 500;
        //    Grid.Columns.Add("Ac_Type", "A/C Type");
        //    Grid.Columns["Ac_Type"].DataPropertyName = "Ac_Type";
        //    Grid.Columns["Ac_Type"].Width = 150;
        //}
        //private void AccSubGroupWithAccGroup()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("select Ac_SGrpDesc,Ac_SGrpCode From (Select  Distinct ac_SGrpDesc,ac_sGrpCode from account_Sub_group  where ac_grpcode in (" + AcGroup + ")  Union all Select  Distinct 'No Sub Group' As Ac_SGrpDesc,'NS' as ac_sGrpCode ) as SubGrp ");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Ac_SGrpDesc", "Account Sub Group");
        //    Grid.Columns["Ac_SGrpDesc"].DataPropertyName = "Ac_SGrpDesc";
        //    Grid.Columns["Ac_SGrpDesc"].Width = 500;
        //    Grid.Columns.Add("Ac_SGrpCode", "Ac_SGrpCode");
        //    Grid.Columns["Ac_SGrpCode"].DataPropertyName = "Ac_SGrpCode";
        //    Grid.Columns["Ac_SGrpCode"].Width = 150;
        //}
        private void GeneralledgerList()
        {
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.GeneralLedgerList("ALL", ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;
            Grid.Columns.Add("LedgerId", "LedgerId");
            Grid.Columns["LedgerId"].DataPropertyName = "LedgerId";
            Grid.Columns["LedgerId"].Visible = false;
            Grid.Columns["LedgerId"].Width = 0;
            Grid.Columns.Add("GlDesc", "Description");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].Width = 500;
            Grid.Columns.Add("GlShortName", "Short Name");
            Grid.Columns["GlShortName"].DataPropertyName = "GlShortName";
            Grid.Columns["GlShortName"].Width = 150;
        }
        //private void LedgerGlDesc()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Gl_Desc,gl_shortname from General_Ledger where Gl_Category = 'OT' and  Cash_Bank <> 'Y' AND Cash_Book <> 'Y' order by Gl_Desc");
        //    Grid.DataSource = dt;
        //    Grid.Columns.Add("Gl_desc", "Description");
        //    Grid.Columns["Gl_desc"].DataPropertyName = "Gl_desc";
        //    Grid.Columns["Gl_desc"].Width = 500;
        //    Grid.Columns.Add("gl_shortname", "Short Name");
        //    Grid.Columns["gl_shortname"].DataPropertyName = "gl_shortname";
        //    Grid.Columns["gl_shortname"].Width = 150;
        //}
        //private void UserMasterList()
        //{
        //    POSDAL.Setup.UserMaster usermaster = new POSDAL.Setup.UserMaster(Database.DBConnection);

        //    Grid.AutoGenerateColumns = false;
        //    dt = usermaster.Get1();
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Hu_Code", " Hu_Code");
        //    Grid.Columns["Hu_Code"].DataPropertyName = "Hu_Code";
        //    Grid.Columns["Hu_Code"].Visible = false;

        //    Grid.Columns.Add("Hu_Name", " Description");
        //    Grid.Columns["Hu_Name"].DataPropertyName = "Hu_Name";
        //    Grid.Columns["Hu_Name"].Width = 200;

        //    Grid.Columns.Add("Hu_Desc", "Hu_Desc");
        //    Grid.Columns["Hu_Desc"].DataPropertyName = "Hu_Desc";
        //    Grid.Columns["Hu_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //}
        //private void ProductSubGroupList()
        //{
        //    POSDAL.Master.Product.ProductSubGroup pro = new POSDAL.Master.Product.ProductSubGroup(Util.Database.DBConnection);
        //    Grid.AutoGenerateColumns = false;
        //    dt = pro.GetSearch();
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Code", "Code");
        //    Grid.Columns["Code"].DataPropertyName = "Pr_SGrpCode";
        //    Grid.Columns["Code"].Visible = false;
        //    Grid.Columns["Code"].Width = 0;


        //    Grid.Columns.Add("Description", "Description");
        //    Grid.Columns["Description"].DataPropertyName = "Pr_SGrpDesc";
        //    Grid.Columns["Description"].Width = 125;
        //    Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Pr_GrpDesc", "Product Group");
        //    Grid.Columns["Pr_GrpDesc"].DataPropertyName = "Pr_GrpDesc";
        //    Grid.Columns["Pr_GrpDesc"].Width = 125;
        //    Grid.Columns["Pr_GrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void AgentList()
        //{
        //    POSDAL.Master.AgentArea.Agent obj = new POSDAL.Master.AgentArea.Agent(Database.DBConnection);
        //    Grid.AutoGenerateColumns = false;
        //    dt = obj.Get("");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Agent_Code", " Code");
        //    Grid.Columns["Agent_Code"].DataPropertyName = "Agent_Code";
        //    Grid.Columns["Agent_Code"].Width = 50;
        //    Grid.Columns["Agent_Code"].Visible = false;

        //    Grid.Columns.Add("Agent_Desc", " Description");
        //    Grid.Columns["Agent_Desc"].DataPropertyName = "Agent_Desc";
        //    Grid.Columns["Agent_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Agent_ShortName", "Short Name");
        //    Grid.Columns["Agent_ShortName"].DataPropertyName = "Agent_ShortName";
        //    Grid.Columns["Agent_ShortName"].Width = 100;
        //}
        //private void DebitNoteAgentList()
        //{

        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("select distinct 'No Agent' as Agent_Desc,'No Agent' as Agent_ShortName,'No Agent' as Agent_Code from Agent union all Select Agent_Desc,Agent_shortname,Agent_code from Agent oRDER BY Agent_Desc");
        //    Grid.DataSource = dt;


        //    Grid.Columns.Add("Agent_Code", " Code");
        //    Grid.Columns["Agent_Code"].DataPropertyName = "Agent_Code";
        //    Grid.Columns["Agent_Code"].Width = 50;
        //    Grid.Columns["Agent_Code"].Visible = false;

        //    Grid.Columns.Add("Agent_Desc", " Description");
        //    Grid.Columns["Agent_Desc"].DataPropertyName = "Agent_Desc";
        //    Grid.Columns["Agent_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Agent_ShortName", "Short Name");
        //    Grid.Columns["Agent_ShortName"].DataPropertyName = "Agent_ShortName";
        //    Grid.Columns["Agent_ShortName"].Width = 100;
        //}
        //private void DebitNoteAreaList()
        //{

        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchData("Select Distinct 'No Area' as Area_Desc,'No Area' as Area_shortname,'No Area' as Area_code from Area Union All Select Area_Desc,Area_shortname,Area_code from Area order by Area_Desc");
        //    Grid.DataSource = dt;


        //    Grid.Columns.Add("Area_code", " Code");
        //    Grid.Columns["Area_code"].DataPropertyName = "Area_code";
        //    Grid.Columns["Area_code"].Width = 50;
        //    Grid.Columns["Area_code"].Visible = false;

        //    Grid.Columns.Add("Area_Desc", " Description");
        //    Grid.Columns["Area_Desc"].DataPropertyName = "Area_Desc";
        //    Grid.Columns["Area_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Area_shortname", "Short Name");
        //    Grid.Columns["Area_shortname"].DataPropertyName = "Area_shortname";
        //    Grid.Columns["Area_shortname"].Width = 100;
        //}
        //private void AreaList()
        //{
        //    POSDAL.Master.AgentArea.Area obj = new POSDAL.Master.AgentArea.Area(Database.DBConnection);
        //    Grid.AutoGenerateColumns = false;
        //    dt = obj.Get("");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Area_Code", " Code");
        //    Grid.Columns["Area_Code"].DataPropertyName = "Area_Code";
        //    Grid.Columns["Area_Code"].Width = 50;
        //    Grid.Columns["Area_Code"].Visible = false;

        //    Grid.Columns.Add("Area_Desc", " Description");
        //    Grid.Columns["Area_Desc"].DataPropertyName = "Area_Desc";
        //    Grid.Columns["Area_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Area_ShortName", "Short Name");
        //    Grid.Columns["Area_ShortName"].DataPropertyName = "Area_ShortName";
        //    Grid.Columns["Area_ShortName"].Width = 100;

        //    //Grid.Columns.Add("MArea_Desc", "Main Area");
        //    //Grid.Columns["MArea_Desc"].DataPropertyName = "MArea_Desc";
        //    //Grid.Columns["MArea_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //}
        //private void AccountCustomerList()
        //{
        //    POSDAL.Master.Ledger.LedgerMaster pro = new POSDAL.Master.Ledger.LedgerMaster(Util.Database.DBConnection);
        //    Grid.AutoGenerateColumns = false;
        //    dt = pro.Get1("", "", "CU,BO");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Code", "Code");
        //    Grid.Columns["Code"].DataPropertyName = "Gl_Code";
        //    Grid.Columns["Code"].Visible = false;
        //    Grid.Columns["Code"].Width = 0;

        //    Grid.Columns.Add("Description", "Description");
        //    Grid.Columns["Description"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("ShortName", "Short Name");
        //    Grid.Columns["ShortName"].DataPropertyName = "Gl_ShortName";
        //    Grid.Columns["ShortName"].Width = 125;
        //}
        //private void AccountvendorList1()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchDataTable("Select Gl_Code,Gl_Desc,Gl_ShortName from General_Ledger Where Gl_Category IN('VE') UNION ALL Select Gl_Code,Gl_Desc,Gl_ShortName from General_Ledger Where Cash_Book='Y'");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Code", "Code");
        //    Grid.Columns["Code"].DataPropertyName = "Gl_Code";
        //    Grid.Columns["Code"].Visible = false;
        //    Grid.Columns["Code"].Width = 0;

        //    Grid.Columns.Add("Description", "Description");
        //    Grid.Columns["Description"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("ShortName", "Short Name");
        //    Grid.Columns["ShortName"].DataPropertyName = "Gl_ShortName";
        //    Grid.Columns["ShortName"].Width = 125;
        //}
        //private void AccountCustomerList1()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchDataTable("Select Gl_Code,Gl_Desc,Gl_ShortName from General_Ledger Where Gl_Category IN('CU') UNION ALL Select Gl_Code,Gl_Desc,Gl_ShortName from General_Ledger Where Cash_Book='Y'");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Code", "Code");
        //    Grid.Columns["Code"].DataPropertyName = "Gl_Code";
        //    Grid.Columns["Code"].Visible = false;
        //    Grid.Columns["Code"].Width = 0;

        //    Grid.Columns.Add("Description", "Description");
        //    Grid.Columns["Description"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("ShortName", "Short Name");
        //    Grid.Columns["ShortName"].DataPropertyName = "Gl_ShortName";
        //    Grid.Columns["ShortName"].Width = 125;
        //}
        //private void RefPurchaseIndent()
        //{
        //    POSDAL.Entry.Purchase.PurchaseIndent obj = new POSDAL.Entry.Purchase.PurchaseIndent(Util.Database.DBConnection);

        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Indent_Master.Indent_No,M_miti as Indent_Date  from  Indent_details,Indent_Master  Left outer join DateMiti on M_Date = Indent_Date    where  Indent_Master.Indent_No = Indent_details.Indent_No    and  Indent_Master.Br_Code is Null     and (Qty-Issue_Qty) > 0   order by Indent_Master.Indent_No ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Indent_Master.Indent_No,M_miti as Indent_Date  from  Indent_details,Indent_Master  Left outer join DateMiti on M_Date = Indent_Date    where  Indent_Master.Indent_No = Indent_details.Indent_No    and  Indent_Master.Br_Code ='" + clsGlobal.BranchCode + "'     and (Qty-Issue_Qty) > 0   order by Indent_Master.Indent_No ");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Indent_Master.Indent_No,M_Date as Indent_Date  from Indent_details,Indent_Master left outer join DateMiti on M_Date = Indent_Date   where  Indent_Master.Indent_No = Indent_details.Indent_No and  Indent_Master.Br_Code is Null   and (Qty-Issue_Qty) > 0   order by  Indent_Master.Indent_No ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Indent_Master.Indent_No,M_Date as Indent_Date  from Indent_details,Indent_Master left outer join DateMiti on M_Date = Indent_Date   where  Indent_Master.Indent_No = Indent_details.Indent_No and  Indent_Master.Br_Code  ='" + clsGlobal.BranchCode + "'   and (Qty-Issue_Qty) > 0   order by  Indent_Master.Indent_No ");

        //    }
        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Indent_No", "Indent No");
        //    Grid.Columns["Indent_No"].DataPropertyName = "Indent_No";
        //    Grid.Columns["Indent_No"].Visible = true;
        //    Grid.Columns["Indent_No"].Width = 100;

        //    Grid.Columns.Add("Indent_Date", "Indent Date");
        //    Grid.Columns["Indent_Date"].DataPropertyName = "Indent_Date";
        //    Grid.Columns["Indent_Date"].Visible = true;
        //    Grid.Columns["Indent_Date"].Width = 150;

        //    //Grid.Columns.Add("Person", "Description");
        //    //Grid.Columns["Person"].DataPropertyName = "Person";
        //    //Grid.Columns["Person"].Visible = true;
        //    //Grid.Columns["Person"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void RefPurchaseQuotNo()
        //{
        //    POSDAL.Entry.Purchase.PurchaseQuotation obj = new POSDAL.Entry.Purchase.PurchaseQuotation(Util.Database.DBConnection);

        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Quotation_Master.Quot_No,M_miti as Quot_Date ,Gl_desc from  Purchase_Quotation_Details,Purchase_Quotation_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Quotation_Master.GL_Code   Left outer join DateMiti on M_Date = Quot_Date   where  Purchase_Quotation_Master.Quot_No = Purchase_Quotation_Details.Quot_No  and  Purchase_Quotation_Master.Br_Code is Null and (Qty-Issue_Qty) > 0   order by Purchase_Quotation_Master.Quot_No ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Quotation_Master.Quot_No,M_miti as Quot_Date ,Gl_desc from  Purchase_Quotation_Details,Purchase_Quotation_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Quotation_Master.GL_Code   Left outer join DateMiti on M_Date = Quot_Date   where  Purchase_Quotation_Master.Quot_No = Purchase_Quotation_Details.Quot_No  and  Purchase_Quotation_Master.Br_Code ='" + clsGlobal.BranchCode + "' and (Qty-Issue_Qty) > 0   order by Purchase_Quotation_Master.Quot_No ");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Quotation_Master.Quot_No,M_Date as Quot_Date ,Gl_desc from  Purchase_Quotation_Details,Purchase_Quotation_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Quotation_Master.GL_Code   Left outer join DateMiti on M_Date = Quot_Date   where  Purchase_Quotation_Master.Quot_No = Purchase_Quotation_Details.Quot_No  and  Purchase_Quotation_Master.Br_Code is Null     and (Qty-Issue_Qty) > 0   order by Purchase_Quotation_Master.Quot_No ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Quotation_Master.Quot_No,M_Date as Quot_Date ,Gl_desc from  Purchase_Quotation_Details,Purchase_Quotation_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Quotation_Master.GL_Code   Left outer join DateMiti on M_Date = Quot_Date   where  Purchase_Quotation_Master.Quot_No = Purchase_Quotation_Details.Quot_No  and  Purchase_Quotation_Master.Br_Code ='" + clsGlobal.BranchCode + "'     and (Qty-Issue_Qty) > 0   order by Purchase_Quotation_Master.Quot_No ");

        //    }
        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Quot_No", "Quotation No");
        //    Grid.Columns["Quot_No"].DataPropertyName = "Quot_No";
        //    Grid.Columns["Quot_No"].Visible = true;
        //    Grid.Columns["Quot_No"].Width = 100;

        //    Grid.Columns.Add("Quot_Date", "Quotation Date");
        //    Grid.Columns["Quot_Date"].DataPropertyName = "Quot_Date";
        //    Grid.Columns["Quot_Date"].Visible = true;
        //    Grid.Columns["Quot_Date"].Width = 150;

        //    Grid.Columns.Add("Gl_Desc", "Vendor");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void RefPurchaseOrderNo()
        //{
        //    POSDAL.Entry.Purchase.PurchaseOrder obj = new POSDAL.Entry.Purchase.PurchaseOrder(Util.Database.DBConnection);

        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Order_Master.Order_No,M_miti as Order_Date ,Gl_desc from  Purchase_Order_Details,Purchase_Order_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Order_Master.GL_Code   Left outer join DateMiti on M_Date = Order_Date  where  Purchase_Order_Master.Order_No = Purchase_Order_Details.Order_No   and  Purchase_Order_Master.Br_Code is Null  and (Qty-Issue_Qty) > 0   order by Purchase_Order_Master.Order_No ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Order_Master.Order_No,M_miti as Order_Date ,Gl_desc from  Purchase_Order_Details,Purchase_Order_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Order_Master.GL_Code   Left outer join DateMiti on M_Date = Order_Date  where  Purchase_Order_Master.Order_No = Purchase_Order_Details.Order_No   and  Purchase_Order_Master.Br_Code='" + clsGlobal.BranchCode + "'  and (Qty-Issue_Qty) > 0   order by Purchase_Order_Master.Order_No ");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Order_Master.Order_No,M_Date as Order_Date ,Gl_desc from  Purchase_Order_Details,Purchase_Order_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Order_Master.GL_Code   Left outer join DateMiti on M_Date = Order_Date  where  Purchase_Order_Master.Order_No = Purchase_Order_Details.Order_No   and  Purchase_Order_Master.Br_Code is Null  and (Qty-Issue_Qty) > 0   order by Purchase_Order_Master.Order_No ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Order_Master.Order_No,M_Date as Order_Date ,Gl_desc from  Purchase_Order_Details,Purchase_Order_Master left outer join General_ledger   on General_ledger.GL_Code=Purchase_Order_Master.GL_Code   Left outer join DateMiti on M_Date = Order_Date  where  Purchase_Order_Master.Order_No = Purchase_Order_Details.Order_No   and  Purchase_Order_Master.Br_Code ='" + clsGlobal.BranchCode + "'  and (Qty-Issue_Qty) > 0   order by Purchase_Order_Master.Order_No ");
        //    }

        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Order_No", "Order No");
        //    Grid.Columns["Order_No"].DataPropertyName = "Order_No";
        //    Grid.Columns["Order_No"].Visible = true;
        //    Grid.Columns["Order_No"].Width = 100;

        //    Grid.Columns.Add("Order_Date", "Order Date");
        //    Grid.Columns["Order_Date"].DataPropertyName = "Order_Date";
        //    Grid.Columns["Order_Date"].Visible = true;
        //    Grid.Columns["Order_Date"].Width = 150;

        //    Grid.Columns.Add("Gl_Desc", "Vendor");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void RefPurchaseChallanNo()
        //{
        //    POSDAL.Entry.Purchase.PurchaseChallan obj = new POSDAL.Entry.Purchase.PurchaseChallan(Util.Database.DBConnection);

        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Challan_master.Challan_No,M_Miti as Date,Gl_Desc, Cur_ShortName from Purchase_Challan_details  ,Purchase_Challan_master left outer join General_ledger on General_ledger.GL_Code=Purchase_Challan_master.GL_Code left Outer join Currency on Purchase_Challan_master.Cr_Code=Currency.Cur_Code left Outer join Datemiti on Challan_Date=M_Date  where Purchase_Challan_master.Challan_No = Purchase_Challan_Details.Challan_No  and Purchase_Challan_MAster.Br_Code is Null  and (not exists (select distinct Pur_Challan_No from Purchase_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=Purchase_Details.PUR_ORDERSNO) and not exists (select distinct IBST_InNo from InterBranch_STIn_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=InterBranch_STIn_Details.PUR_ORDERSNO)) and Challan_Date <='" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'  order by Purchase_Challan_master.Challan_NO,M_Miti");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Challan_master.Challan_No,M_Miti as Date,Gl_Desc, Cur_ShortName from Purchase_Challan_details  ,Purchase_Challan_master left outer join General_ledger on General_ledger.GL_Code=Purchase_Challan_master.GL_Code left Outer join Currency on Purchase_Challan_master.Cr_Code=Currency.Cur_Code left Outer join Datemiti on Challan_Date=M_Date  where Purchase_Challan_master.Challan_No = Purchase_Challan_Details.Challan_No  and Purchase_Challan_MAster.Br_Code ='" + clsGlobal.BranchCode + "'  and (not exists (select distinct Pur_Challan_No from Purchase_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=Purchase_Details.PUR_ORDERSNO) and not exists (select distinct IBST_InNo from InterBranch_STIn_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=InterBranch_STIn_Details.PUR_ORDERSNO)) and Challan_Date <='" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'  order by Purchase_Challan_master.Challan_NO,M_Miti");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Challan_master.Challan_No,M_Date as Date,Gl_Desc, Cur_ShortName from Purchase_Challan_details  ,Purchase_Challan_master left outer join General_ledger on General_ledger.GL_Code=Purchase_Challan_master.GL_Code left Outer join Currency on Purchase_Challan_master.Cr_Code=Currency.Cur_Code left Outer join Datemiti on Challan_Date=M_Date  where Purchase_Challan_master.Challan_No = Purchase_Challan_Details.Challan_No  and Purchase_Challan_MAster.Br_Code is Null  and (not exists (select distinct Pur_Challan_No from Purchase_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=Purchase_Details.PUR_ORDERSNO) and not exists (select distinct IBST_InNo from InterBranch_STIn_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=InterBranch_STIn_Details.PUR_ORDERSNO)) and Challan_Date <='" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'   order by Purchase_Challan_master.Challan_NO,M_Date ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Purchase_Challan_master.Challan_No,M_Date as Date,Gl_Desc, Cur_ShortName from Purchase_Challan_details  ,Purchase_Challan_master left outer join General_ledger on General_ledger.GL_Code=Purchase_Challan_master.GL_Code left Outer join Currency on Purchase_Challan_master.Cr_Code=Currency.Cur_Code left Outer join Datemiti on Challan_Date=M_Date  where Purchase_Challan_master.Challan_No = Purchase_Challan_Details.Challan_No  and Purchase_Challan_MAster.Br_Code ='" + clsGlobal.BranchCode + "'  and (not exists (select distinct Pur_Challan_No from Purchase_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=Purchase_Details.PUR_ORDERSNO) and not exists (select distinct IBST_InNo from InterBranch_STIn_Details where Purchase_Challan_master.Challan_No = Pur_Challan_No AND Purchase_Challan_details.SNO=InterBranch_STIn_Details.PUR_ORDERSNO)) and Challan_Date <='" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'   order by Purchase_Challan_master.Challan_NO,M_Date ");
        //    }

        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Challan_No", "Challan No");
        //    Grid.Columns["Challan_No"].DataPropertyName = "Challan_No";
        //    Grid.Columns["Challan_No"].Visible = true;
        //    Grid.Columns["Challan_No"].Width = 100;

        //    Grid.Columns.Add("Date", "Challan Date");
        //    Grid.Columns["Date"].DataPropertyName = "Date";
        //    Grid.Columns["Date"].Visible = true;
        //    Grid.Columns["Date"].Width = 150;

        //    Grid.Columns.Add("Gl_Desc", "Vendor");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void RefQuotNo()
        //{
        //    POSDAL.Entry.Sales.SalesQuotation obj = new POSDAL.Entry.Sales.SalesQuotation(Util.Database.DBConnection);

        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Sales_Quotation_master.Sb_QuotNo,M_miti as Sb_QuotDate ,Gl_desc from  Sales_Quotation_details,Sales_Quotation_master left outer join General_ledger   on General_ledger.GL_Code=Sales_Quotation_master.GL_Code   Left outer join DateMiti on M_Date = Sb_QuotDate   where  Sales_Quotation_master.Sb_QuotNo = Sales_Quotation_details.Sb_QuotNo  and Sb_QuotDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'  and  Sales_Quotation_master.Br_Code is Null    and (Reconcile is null or Reconcile=0)  and ((Qty-Issue_Qty) > 0  OR Sales_Quotation_master.Sb_QuotNo in (select Distinct Sb_QuotNo from Sales_Challan_Master Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "'))  order by Sales_Quotation_master.Sb_QuotNo ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Sales_Quotation_master.Sb_QuotNo,M_miti as Sb_QuotDate ,Gl_desc from  Sales_Quotation_details,Sales_Quotation_master left outer join General_ledger   on General_ledger.GL_Code=Sales_Quotation_master.GL_Code   Left outer join DateMiti on M_Date = Sb_QuotDate   where  Sales_Quotation_master.Sb_QuotNo = Sales_Quotation_details.Sb_QuotNo  and Sb_QuotDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'  and  Sales_Quotation_master.Br_Code ='" + clsGlobal.BranchCode + "'   and (Reconcile is null or Reconcile=0)  and ((Qty-Issue_Qty) > 0  OR Sales_Quotation_master.Sb_QuotNo in (select Distinct Sb_QuotNo from Sales_Challan_Master Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "'))  order by Sales_Quotation_master.Sb_QuotNo ");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Sales_Quotation_master.Sb_QuotNo,M_Date as Sb_QuotDate ,Gl_desc from  Sales_Quotation_details,Sales_Quotation_master left outer join General_ledger   on General_ledger.GL_Code=Sales_Quotation_master.GL_Code   Left outer join DateMiti on M_Date = Sb_QuotDate   where  Sales_Quotation_master.Sb_QuotNo = Sales_Quotation_details.Sb_QuotNo  and Sb_QuotDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'  and  Sales_Quotation_master.Br_Code is Null    and (Reconcile is null or Reconcile=0)  and ((Qty-Issue_Qty) > 0  OR Sales_Quotation_master.Sb_QuotNo in (select Distinct Sb_QuotNo from Sales_Challan_Master Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "'))  order by Sales_Quotation_master.Sb_QuotNo ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Sales_Quotation_master.Sb_QuotNo,M_Date as Sb_QuotDate ,Gl_desc from  Sales_Quotation_details,Sales_Quotation_master left outer join General_ledger   on General_ledger.GL_Code=Sales_Quotation_master.GL_Code   Left outer join DateMiti on M_Date = Sb_QuotDate   where  Sales_Quotation_master.Sb_QuotNo = Sales_Quotation_details.Sb_QuotNo  and Sb_QuotDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "'  and  Sales_Quotation_master.Br_Code ='" + clsGlobal.BranchCode + "'     and (Reconcile is null or Reconcile=0)  and ((Qty-Issue_Qty) > 0  OR Sales_Quotation_master.Sb_QuotNo in (select Distinct Sb_QuotNo from Sales_Challan_Master Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "'))  order by Sales_Quotation_master.Sb_QuotNo ");
        //    }

        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Sb_QuotNo", "Quotation No");
        //    Grid.Columns["Sb_QuotNo"].DataPropertyName = "Sb_QuotNo";
        //    Grid.Columns["Sb_QuotNo"].Visible = true;
        //    Grid.Columns["Sb_QuotNo"].Width = 100;

        //    Grid.Columns.Add("Sb_QuotDate", "Quotation Date");
        //    Grid.Columns["Sb_QuotDate"].DataPropertyName = "Sb_QuotDate";
        //    Grid.Columns["Sb_QuotDate"].Visible = true;
        //    Grid.Columns["Sb_QuotDate"].Width = 150;

        //    Grid.Columns.Add("Gl_Desc", "Customer");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void RefOrderNo()
        //{
        //    POSDAL.Entry.Sales.SalesQuotation obj = new POSDAL.Entry.Sales.SalesQuotation(Util.Database.DBConnection);

        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (!string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Sales_order_master.Sb_OrderNo,M_miti as Date,Gl_desc from  Sales_order_details,sales_order_master left outer join General_ledger  on General_ledger.GL_Code=sales_order_master.GL_Code  left outer join DateMiti on Sb_OrderDate =M_date where  Sales_Order_master.Sb_orderNo = sales_Order_details.Sb_orderNo  and Sb_orderDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and sales_Order_Master.Br_Code ='" + clsGlobal.BranchCode + "'  And ((Qty-Issue_Qty) > 0  OR Sales_Order_master.Sb_orderNo in (select Distinct sbOrder_No from Sales_Challan_Details Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "')) order by Sales_order_master.Sb_orderNO ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Sales_order_master.Sb_OrderNo,M_miti as Date,Gl_desc from  Sales_order_details,sales_order_master left outer join General_ledger  on General_ledger.GL_Code=sales_order_master.GL_Code  left outer join DateMiti on Sb_OrderDate =M_date where  Sales_Order_master.Sb_orderNo = sales_Order_details.Sb_orderNo  and Sb_orderDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and sales_Order_Master.Br_Code is Null  And ((Qty-Issue_Qty) > 0  OR Sales_Order_master.Sb_orderNo in (select Distinct sbOrder_No from Sales_Challan_Details Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "')) order by Sales_order_master.Sb_orderNO ");
        //    }
        //    else
        //    {
        //        if (!string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct Sales_order_master.Sb_OrderNo,Sb_orderDate as Date,Gl_desc from  Sales_order_details,sales_order_master left outer join General_ledger  on General_ledger.GL_Code=sales_order_master.GL_Code where  Sales_Order_master.Sb_orderNo = sales_Order_details.Sb_orderNo  and Sb_orderDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and sales_Order_Master.Br_Code='" + clsGlobal.BranchCode + "'  And ((Qty-Issue_Qty) > 0  OR Sales_Order_master.Sb_orderNo in (select Distinct sbOrder_No from Sales_Challan_Details Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "')) order by Sales_order_master.Sb_orderNO ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct Sales_order_master.Sb_OrderNo,Sb_orderDate as Date,Gl_desc from  Sales_order_details,sales_order_master left outer join General_ledger  on General_ledger.GL_Code=sales_order_master.GL_Code where  Sales_Order_master.Sb_orderNo = sales_Order_details.Sb_orderNo  and Sb_orderDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and sales_Order_Master.Br_Code is Null  And ((Qty-Issue_Qty) > 0  OR Sales_Order_master.Sb_orderNo in (select Distinct sbOrder_No from Sales_Challan_Details Where Sb_ChallanNo='" + clsGlobal.ChallanNo + "')) order by Sales_order_master.Sb_orderNO ");
        //    }
        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Sb_OrderNo", "Order No");
        //    Grid.Columns["Sb_OrderNo"].DataPropertyName = "Sb_OrderNo";
        //    Grid.Columns["Sb_OrderNo"].Visible = true;
        //    Grid.Columns["Sb_OrderNo"].Width = 100;

        //    Grid.Columns.Add("Date", "Order Date");
        //    Grid.Columns["Date"].DataPropertyName = "Date";
        //    Grid.Columns["Date"].Visible = true;
        //    Grid.Columns["Date"].Width = 150;

        //    Grid.Columns.Add("Gl_Desc", "Customer");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void RefChallanNo()
        //{
        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    if (clsGlobal.Date_Type == "M")
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct sales_Challan_master.Sb_ChallanNo,M_miti as Date,Gl_desc  from sales_Challan_details,sales_Challan_master left outer join  General_ledger on General_ledger.GL_Code=sales_Challan_master.GL_Code  Left outer join DateMiti on Sb_ChallanDate=m_Date where sales_Challan_master.Sb_ChallanNo = sales_Challan_Details.Sb_ChallanNo  and Sb_ChallanDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and Sales_Challan_master.Br_Code is Null  and sales_Challan_master.GL_Code not in(select ISNULL(CancellationCustomer,'0') From System_Control)  and (not exists (select distinct Challan_No from Sales_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and Sales_Details.Order_Sno = Sales_Challan_Details.Sno) and not exists (select distinct IBST_OutNo from InterBranch_STOut_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and InterBranch_STOut_Details.Order_Sno = Sales_Challan_Details.Sno) OR sales_Challan_master.Sb_ChallanNo='') order by sales_Challan_master.Sb_ChallanNO");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct sales_Challan_master.Sb_ChallanNo,M_miti as Date,Gl_desc  from sales_Challan_details,sales_Challan_master left outer join  General_ledger on General_ledger.GL_Code=sales_Challan_master.GL_Code  Left outer join DateMiti on Sb_ChallanDate=m_Date where sales_Challan_master.Sb_ChallanNo = sales_Challan_Details.Sb_ChallanNo  and Sb_ChallanDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and Sales_Challan_master.Br_Code ='" + clsGlobal.BranchCode + "'  and sales_Challan_master.GL_Code not in(select ISNULL(CancellationCustomer,'0') From System_Control)  and (not exists (select distinct Challan_No from Sales_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and Sales_Details.Order_Sno = Sales_Challan_Details.Sno) and not exists (select distinct IBST_OutNo from InterBranch_STOut_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and InterBranch_STOut_Details.Order_Sno = Sales_Challan_Details.Sno) OR sales_Challan_master.Sb_ChallanNo='') order by sales_Challan_master.Sb_ChallanNO");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(clsGlobal.BranchCode))
        //            dt = clsGlobal.FetchData("Select distinct sales_Challan_master.Sb_ChallanNo,Sb_ChallanDate as Date ,Gl_desc  from sales_Challan_details,sales_Challan_master left outer join  General_ledger on General_ledger.GL_Code=sales_Challan_master.GL_Code  where sales_Challan_master.Sb_ChallanNo = sales_Challan_Details.Sb_ChallanNo  and Sb_ChallanDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and Sales_Challan_master.Br_Code is Null  and sales_Challan_master.GL_Code not in(select ISNULL(CancellationCustomer,'0') From System_Control)  and (not exists (select distinct Challan_No from Sales_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and Sales_Details.Order_Sno = Sales_Challan_Details.Sno) and not exists (select distinct IBST_OutNo from InterBranch_STOut_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and InterBranch_STOut_Details.Order_Sno = Sales_Challan_Details.Sno) OR sales_Challan_master.Sb_ChallanNo='') order by sales_Challan_master.Sb_ChallanNO ");
        //        else
        //            dt = clsGlobal.FetchData("Select distinct sales_Challan_master.Sb_ChallanNo,Sb_ChallanDate as Date ,Gl_desc  from sales_Challan_details,sales_Challan_master left outer join  General_ledger on General_ledger.GL_Code=sales_Challan_master.GL_Code  where sales_Challan_master.Sb_ChallanNo = sales_Challan_Details.Sb_ChallanNo  and Sb_ChallanDate <= '" + Convert.ToDateTime(clsGlobal.BillDate).ToString("MM/dd/yyyy") + "' and Sales_Challan_master.Br_Code ='" + clsGlobal.BranchCode + "' and sales_Challan_master.GL_Code not in(select ISNULL(CancellationCustomer,'0') From System_Control)  and (not exists (select distinct Challan_No from Sales_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and Sales_Details.Order_Sno = Sales_Challan_Details.Sno) and not exists (select distinct IBST_OutNo from InterBranch_STOut_Details where sales_Challan_master.Sb_ChallanNo = Challan_No and InterBranch_STOut_Details.Order_Sno = Sales_Challan_Details.Sno) OR sales_Challan_master.Sb_ChallanNo='') order by sales_Challan_master.Sb_ChallanNO ");
        //    }
        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Sb_ChallanNo", "Challan No");
        //    Grid.Columns["Sb_ChallanNo"].DataPropertyName = "Sb_ChallanNo";
        //    Grid.Columns["Sb_ChallanNo"].Visible = true;
        //    Grid.Columns["Sb_ChallanNo"].Width = 100;

        //    Grid.Columns.Add("Date", "Challan Date");
        //    Grid.Columns["Date"].DataPropertyName = "Date";
        //    Grid.Columns["Date"].Visible = true;
        //    Grid.Columns["Date"].Width = 150;

        //    Grid.Columns.Add("Gl_Desc", "Customer");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void SalesDispatchList()
        //{
        //    POSDAL.Entry.Sales.SalesDispatchOrder salesDispatchOrder = new POSDAL.Entry.Sales.SalesDispatchOrder(Util.Database.DBConnection);
        //    this.ClientSize = new System.Drawing.Size(920, 411);
        //    this.Grid.Size = new System.Drawing.Size(900, 329);

        //    dt = clsGlobal.FetchData("Select Sb_DisOrderNo,Sb_DisOrderDate, Sb_DisOrderMiti ,Gl_Desc from Sales_DisOrder_master   left outer join General_Ledger on Sales_DisOrder_master.gl_code=General_Ledger.Gl_Code where  Sb_DisOrderNo  not in (Select distinct SbDisOrder_No from Sales_Challan_Details where  SbDisOrder_No is not null or SbDisOrder_No=' ' )");
        //    Grid.AutoGenerateColumns = false;
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Sb_DisOrderNo", "Dispatch No");
        //    Grid.Columns["Sb_DisOrderNo"].DataPropertyName = "Sb_DisOrderNo";
        //    Grid.Columns["Sb_DisOrderNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Sb_DisOrderDate", "Date");
        //    Grid.Columns["Sb_DisOrderDate"].DataPropertyName = "Sb_DisOrderDate";
        //    Grid.Columns["Sb_DisOrderDate"].Width = 125;

        //    Grid.Columns.Add("Sb_DisOrderMiti", "Miti");
        //    Grid.Columns["Sb_DisOrderMiti"].DataPropertyName = "Sb_DisOrderMiti";
        //    Grid.Columns["Sb_DisOrderMiti"].Width = 125;

        //    Grid.Columns.Add("Gl_Desc", "Customer");
        //    Grid.Columns["Gl_Desc"].DataPropertyName = "Gl_Desc";
        //    Grid.Columns["Gl_Desc"].Visible = true;
        //    Grid.Columns["Gl_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //}
        //private void ProductList()
        //{
        //    POSDAL.Master.Product.ItemProduct pro = new POSDAL.Master.Product.ItemProduct(Util.Database.DBConnection);

        //    Grid.AutoGenerateColumns = false;
        //    dt = pro.Get("", "").Tables[0];
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Code", "Code");
        //    Grid.Columns["Code"].DataPropertyName = "P_Code";
        //    Grid.Columns["Code"].Visible = false;

        //    Grid.Columns.Add("Unit", "Unit");
        //    Grid.Columns["Unit"].DataPropertyName = "Unit";
        //    Grid.Columns["Unit"].Visible = false;

        //    Grid.Columns.Add("Description", "Description");
        //    Grid.Columns["Description"].DataPropertyName = "P_Desc";
        //    Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("ShortName", "Short Name");
        //    Grid.Columns["ShortName"].DataPropertyName = "P_ShortName";
        //    Grid.Columns["ShortName"].Width = 250;
        //}
        //private void ReportProductList()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    string smt = "";
        //    smt = "Select P_Desc,P_ShortName,Pr_GrpDesc as [Group],Pr_SGrpDesc as [Sub Group],P_code From product Left Outer Join Product_Group on P_Group = Pr_GrpCode Left Outer Join Product_Sub_Group on P_SubGroup = Pr_SGrpCode where P_type<>'SV' ";
        //    if (string.IsNullOrEmpty(PSGroup))
        //    {
        //        if (!string.IsNullOrEmpty(PGroup))
        //            smt += "and Pr_GrpDesc in (" + PGroup + ")";
        //    }
        //    else
        //        smt += "and Pr_SGrpDesc in (" + PSGroup + ")";
        //    smt += "order by P_desc";
        //    dt = clsGlobal.FetchDataTable(smt);
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Code", "Code");
        //    Grid.Columns["Code"].DataPropertyName = "P_Code";
        //    Grid.Columns["Code"].Visible = false;

        //    Grid.Columns.Add("ShortName", "Short Name");
        //    Grid.Columns["ShortName"].DataPropertyName = "P_ShortName";
        //    Grid.Columns["ShortName"].Width = 100;

        //    Grid.Columns.Add("Description", "Description");
        //    Grid.Columns["Description"].DataPropertyName = "P_Desc";
        //    Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Group", "Group");
        //    Grid.Columns["Group"].DataPropertyName = "Group";
        //    Grid.Columns["Group"].Width = 150;

        //    Grid.Columns.Add("Sub Group", "Sub Group");
        //    Grid.Columns["Sub Group"].DataPropertyName = "Sub Group";
        //    Grid.Columns["Sub Group"].Width = 150;
        //}
        //private void ReportProductSubGroupList()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    string smt = "";
        //    smt = "Select Pr_SGrpDesc,Pr_GrpDesc from Product_Sub_Group  left outer join Product_group on product_group.pr_grpcode = product_sub_group.pr_grpcode ";
        //    if (!string.IsNullOrEmpty(PGroup))
        //        smt += "where Pr_GrpDesc in (" + PGroup + ")";
        //    smt += "Union All Select Distinct 'No Sub Group' as Pr_SGrpDesc,'No Group' as Pr_GrpDesc from Product_Sub_group  left outer join Product_group on product_group.pr_grpcode = product_sub_group.pr_grpcode Order by  Pr_SGrpDesc";
        //    dt = clsGlobal.FetchDataTable(smt);
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Pr_SGrpDesc", "Product Sub Group");
        //    Grid.Columns["Pr_SGrpDesc"].DataPropertyName = "Pr_SGrpDesc";
        //    Grid.Columns["Pr_SGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Pr_GrpDesc", "Product Group");
        //    Grid.Columns["Pr_GrpDesc"].DataPropertyName = "Pr_GrpDesc";
        //    Grid.Columns["Pr_GrpDesc"].Width = 100;
        //}
        //private void ReportProductGroupList()
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = clsGlobal.FetchDataTable("Select Pr_GrpDesc,Pr_GrpShortName from Product_group Union all Select Distinct 'No Group' as Pr_GrpDesc,'No Group' as Pr_GrpShortName from Product_group Order by  Pr_GrpDesc");
        //    Grid.DataSource = dt;

        //    //Grid.Columns.Add("Code", "Code");
        //    //Grid.Columns["Code"].DataPropertyName = "P_Code";
        //    //Grid.Columns["Code"].Visible = false;

        //    Grid.Columns.Add("Pr_GrpDesc", "Group Name");
        //    Grid.Columns["Pr_GrpDesc"].DataPropertyName = "Pr_GrpDesc";
        //    Grid.Columns["Pr_GrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Pr_GrpShortName", "Short Name");
        //    Grid.Columns["Pr_GrpShortName"].DataPropertyName = "Pr_GrpShortName";
        //    Grid.Columns["Pr_GrpShortName"].Width = 100;
        //}
        //private void ProductGroupList()
        //{
        //    POSDAL.Master.Product.ProductGroup objGroup = new POSDAL.Master.Product.ProductGroup(Util.Database.DBConnection);

        //    Grid.AutoGenerateColumns = false;
        //    dt = objGroup.Get();
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Pr_GrpCode", "Code");
        //    Grid.Columns["Pr_GrpCode"].DataPropertyName = "Pr_GrpCode";
        //    Grid.Columns["Pr_GrpCode"].Visible = false;

        //    Grid.Columns.Add("Pr_GrpDesc", "Description");
        //    Grid.Columns["Pr_GrpDesc"].DataPropertyName = "Pr_GrpDesc";
        //    Grid.Columns["Pr_GrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Pr_GrpShortName", "Short Name");
        //    Grid.Columns["Pr_GrpShortName"].DataPropertyName = "Pr_GrpShortName";
        //    Grid.Columns["Pr_GrpShortName"].Width = 250;

        //}
        //private void ClassList(string segment)
        //{
        //    Grid.AutoGenerateColumns = false;
        //    dt = dt = clsGlobal.FetchData("SELECT Cls_Code,Cls_ShortName,Cls_Desc FROM Class WHERE Segment='" + segment + "'");
        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Cls_Code", "Cls_Code");
        //    Grid.Columns["Cls_Code"].DataPropertyName = "Cls_Code";
        //    Grid.Columns["Cls_Code"].Visible = false;

        //    Grid.Columns.Add("Cls_ShortName", "Cls_ShortName");
        //    Grid.Columns["Cls_ShortName"].DataPropertyName = "Cls_ShortName";
        //    Grid.Columns["Cls_ShortName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    Grid.Columns.Add("Cls_Desc", "Cls_Desc");
        //    Grid.Columns["Cls_Desc"].DataPropertyName = "Cls_Desc";
        //    Grid.Columns["Cls_Desc"].Width = 250;
        //}
        //private void InvoiceList()
        //{
        //    Grid.AutoGenerateColumns = false;

        //    if (_ListName == "Sales Invoice")
        //        dt = dt = clsGlobal.FetchData("SELECT [Invoice No],[Invoice Date],[Invoice Miti],[Customer Name]  FROM SalesBillHeader ORDER BY [Invoice No]");
        //    else if (_ListName == "Sales Order")
        //        dt = dt = clsGlobal.FetchData("SELECT [Order No] AS [Invoice No],[Order Date] AS [Invoice Date],[Order Miti] AS [Invoice Miti],[Customer Name]  FROM SalesOrderHeader ORDER BY [Order No]");
        //    else if (_ListName == "Sales Challan")
        //        dt = dt = clsGlobal.FetchData("SELECT [Challan No] AS [Invoice No],[Challan Date] AS [Invoice Date],[Challan Miti] AS [Invoice Miti],[Customer Name]  FROM SalesChallanHeader ORDER BY [Challan No]");

        //    Grid.DataSource = dt;

        //    Grid.Columns.Add("Invoice No", _ListName + " No");
        //    Grid.Columns["Invoice No"].DataPropertyName = "Invoice No";
        //    Grid.Columns["Invoice No"].Width = 120;

        //    Grid.Columns.Add("Invoice Date", "Invoice Date");
        //    Grid.Columns["Invoice Date"].DataPropertyName = "Invoice Date";
        //    Grid.Columns["Invoice Date"].Width = 100;

        //    Grid.Columns.Add("Invoice Miti", "Invoice Miti");
        //    Grid.Columns["Invoice Miti"].DataPropertyName = "Invoice Miti";
        //    Grid.Columns["Invoice Miti"].Width = 100;

        //    Grid.Columns.Add("Customer Name", "Customer Name");
        //    Grid.Columns["Customer Name"].DataPropertyName = "Customer Name";
        //    Grid.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //}
       
    }
}
