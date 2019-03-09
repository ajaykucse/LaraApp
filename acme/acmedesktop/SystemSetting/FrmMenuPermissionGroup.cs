using DataAccessLayer.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.SystemSetting
{
    public partial class FrmMenuPermissionGroup : Form
    {
        string _Tag = "", _SearchKey = "";
        DataAccessLayer.SystemSetting.ClsMenuPermissionGroup _objmennupermission = new DataAccessLayer.SystemSetting.ClsMenuPermissionGroup();
        public FrmMenuPermissionGroup()
        {
            InitializeComponent();
        }
        private void FrmMenuPermissionGroup_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();

            #region------------Company--------------------
            GridCompany.AutoGenerateColumns = false;

            GridCompany.Rows.Add("1", "Company Master", "Company", "Company", "1", false, "MnuCompanyMaster", "Company");
            GridCompany.Rows.Add("2", "Company Master", "Branch", "Branch", "2", false, "MnuBranch", "Company");
            GridCompany.Rows.Add("3", "Company Master", "Company Unit", "Company Unit", "3", false, "MnuCompanyUnit", "Company");
            GridCompany.Rows.Add("4", "Company Master", "Update Company", "Update Company", "4", false, "MnuUpdateCompany", "Company");

            GridCompany.Rows.Add("5", "List of Master", "Company List", "Company List", "1", false, "MnuCompanyList", "Company");
            GridCompany.Rows.Add("6", "List of Master", "Branch List", "Branch List", "2", false, "MnuBranchList", "Company");
            GridCompany.Rows.Add("7", "List of Master", "Company Unit List", "Company Unit List", "3", false, "MnuCompanyUnitList", "Company");

            GridCompany.Rows.Add("8", "Numbering Master", "Document Numbering", "Document Numbering", "1", false, "MnuDocNumbering", "Company");
            GridCompany.Rows.Add("9", "Numbering Master", "Re-Document Numbering", "Re-Document Numbering", "2", false, "MnuReDocumentNumbering", "Company");

            GridCompany.Rows.Add("10", "Biiling Term", "Sales Term", "Sales Term", "1", false, "MnuSalesTerm", "Company");
            GridCompany.Rows.Add("11", "Biiling Term", "Purchase Term", "Purchase Term", "2", false, "MnuPurchaseTerm", "Company");

            GridCompany.Rows.Add("12", "User Master", "Menu Permission Group", "Menu Permission Group", "1", false, "MnuMenuPermissionGroup", "Company");
            GridCompany.Rows.Add("13", "User Master", "Menu Permission Rights", "Menu Permission Rights", "2", false, "MnuMenuPermissionRights", "Company");
            GridCompany.Rows.Add("14", "User Master", "User Master", "User Master", "3", false, "MnuUserMaster", "Company");
            GridCompany.Rows.Add("15", "User Master", "Company Rights", "Company Rights", "4", false, "MnuCompanyRights", "Company");
            GridCompany.Rows.Add("16", "User Master", "Branch Rights", "Branch Rights", "5", false, "MnuBranchRights", "Company");
            GridCompany.Rows.Add("17", "User Master", "Company Unit Rights", "Company Unit Rights", "6", false, "MnuCompanyUnitRights", "Company");
            GridCompany.Rows.Add("18", "User Master", "Change Password", "Change Password", "7", false, "MnuChangePassword", "Company");

            GridCompany.Rows.Add("19", "Print Setting", "Print Setting", "Print Setting", "1", false, "MnuPrintSetting", "Company");
            GridCompany.Rows.Add("20", "System Setting", "System Setting", "System Setting", "1", false, "MnuSystemSetting", "Company");

            #endregion------------Company--------------------

            #region------------Master--------------------
            GridMaster.AutoGenerateColumns = false;

            GridMaster.Rows.Add("1", "Chats of Account", "Account Group", "Account Group", "1", false, "MnuAccountGroup", "Master");
            GridMaster.Rows.Add("2", "Chats of Account", "Account SubGroup", "Account SubGroup", "2", false, "MnuAccountSubGroup", "Master");
            GridMaster.Rows.Add("3", "Chats of Account", "General Ledger", "General Ledger", "3", false, "MnuGeneralLedger", "Master");
            GridMaster.Rows.Add("4", "Chats of Account", "Subledger", "Subledger", "4", false, "MnuSubledger", "Master");
            GridMaster.Rows.Add("5", "Chats of Account", "GroupWise Mapping", "GroupWise Mapping", "5", false, "MnuGroupwiseMapping", "Master");
            GridMaster.Rows.Add("6", "Chats of Account", "BranchWise Mapping", "BranchWise Mapping", "6", false, "MnuBranchwiseMapping", "Master");
            GridMaster.Rows.Add("7", "Chats of Account", "UnitWise Mapping", "UnitWise Mapping", "7", false, "MnuUnitwiseMapping", "Master");
            GridMaster.Rows.Add("8", "Chats of Account", "Ledger Lock/Unlock", "Ledger Lock/Unlock", "8", false, "MnuLedgerLock", "Master");
            GridMaster.Rows.Add("9", "Chats of Account", "Ledger Import", "Ledger Import", "9", false, "MnuLedgerImport", "Master");
            GridMaster.Rows.Add("10", "Product Master", "Product Group", "Product Group", "1", false, "MnuProductGroup", "Master");
            GridMaster.Rows.Add("11", "Product Master", "Product SubGroup", "Product SubGroup", "2", false, "MnuProductSubGroup", "Master");
            GridMaster.Rows.Add("12", "Product Master", "Product Unit", "Product Unit", "3", false, "MnuProductUnit", "Master");
            GridMaster.Rows.Add("13", "Product Master", "Product Company", "Product Company", "4", false, "MnuProductCompany", "Master");
            GridMaster.Rows.Add("14", "Product Master", "Item/Product", "Item/Product", "5", false, "MnuProduct", "Master");
            GridMaster.Rows.Add("15", "Product Master", "Counter Product", "Counter Product", "6", false, "MnuCounterProduct", "Master");
            GridMaster.Rows.Add("16", "Product Master", "Product Scheme", "Product Scheme", "7", false, "MnuProductScheme", "Master");
            GridMaster.Rows.Add("17", "Product Master", "Product Import", "Product Import", "8", false, "MnuProductImport", "Master");
            GridMaster.Rows.Add("18", "Product Master", "Product Lock/Unlock", "Product Lock/Unlock", "9", false, "MnuProductLock", "Master");
            GridMaster.Rows.Add("19", "SalesMan", "Main SalesMan", "Main SalesMan", "1", false, "MnuMainSalesman", "Master");
            GridMaster.Rows.Add("20", "SalesMan", "Sub SalesMan", "Sub SalesMan", "2", false, "MnuSubSalesman", "Master");
            GridMaster.Rows.Add("21", "Area", "Main Area", "Main Area", "1", false, "MnuMainArea", "Master");
            GridMaster.Rows.Add("22", "Area", "Sub Area", "Sub Area", "2", false, "MnuSubArea", "Master");
            GridMaster.Rows.Add("23", "Counter Master", "Counter Master", "Counter Master", "1", false, "MnuCounter", "Master");
            GridMaster.Rows.Add("24", "Godown", "Godown", "Godown", "1", false, "MnuGodown", "Master");
            GridMaster.Rows.Add("25", "Department", "Department", "Department", "1", false, "MnuDepartment", "Master");
            GridMaster.Rows.Add("26", "Currency", "Currency", "Currency", "1", false, "MnuCurrency", "Master");
            GridMaster.Rows.Add("27", "Narration Master", "Narration Master", "Narration Master", "1", false, "MnuNarration", "Master");
            GridMaster.Rows.Add("28", "Copy Master", "Copy Master", "Copy Master", "1", false, "MnuCopyMaster", "Master");
            GridMaster.Rows.Add("29", "Opening Import", "Ledger Import", "Ledger Import", "1", false, "MnuLedgerOpening", "Master");
            GridMaster.Rows.Add("30", "Opening Import", "Product Import", "Product Import", "2", false, "MnuProductOpening", "Master");


            #endregion------------Master--------------------

            #region------------Transaction--------------------
            GridTransaction.AutoGenerateColumns = false;

            GridTransaction.Rows.Add("1", "Opening Master", "Ledger Opening", "Ledger Opening", "1", false, "MnuOpeningLedger", "Transaction");
            GridTransaction.Rows.Add("2", "Opening Master", "Product Opening", "Product Opening", "2", false, "MnuOpeningProduct", "Transaction");
            GridTransaction.Rows.Add("3", "Purchase Transaction", "Indent", "Indent", "3", false, "MnuPurchaseIndent", "Transaction");
            GridTransaction.Rows.Add("4", "Purchase Transaction", "Order", "Order", "4", false, "MnuPurchaseOrder", "Transaction");
            GridTransaction.Rows.Add("5", "Purchase Transaction", "Challan", "Challan", "5", false, "MnuPurchaseChallan", "Transaction");
            GridTransaction.Rows.Add("6", "Purchase Transaction", "GIT", "GIT", "6", false, "MnuPurchaseGIT", "Transaction");
            GridTransaction.Rows.Add("7", "Purchase Transaction", "Invoice", "Invoice", "7", false, "MnuPurchaseInvoice", "Transaction");
            GridTransaction.Rows.Add("8", "Purchase Transaction", "AVT Invoice", "AVT Invoice", "8", false, "MnuPurchaseAVTInvoice", "Transaction");
            GridTransaction.Rows.Add("9", "Purchase Transaction", "Additional", "Additional", "9", false, "MnuPurchaseAdditional", "Transaction");
            GridTransaction.Rows.Add("10", "Purchase Transaction", "Return", "Return", "10", false, "MnuPurchaseReturn", "Transaction");
            GridTransaction.Rows.Add("11", "Purchase Transaction", "ExpBrk Invoice", "ExpBrk Invoice", "11", false, "MnuPurchaseExpBrk", "Transaction");
            GridTransaction.Rows.Add("12", "Sales Transaction", "Quotation", "Quotation", "1", false, "MnuSalesQuotation", "Transaction");
            GridTransaction.Rows.Add("13", "Sales Transaction", "Order", "Order", "2", false, "MnuSalesOrder", "Transaction");
            GridTransaction.Rows.Add("14", "Sales Transaction", "Challan", "Challan", "3", false, "MnuSalesChallan", "Transaction");
            GridTransaction.Rows.Add("15", "Sales Transaction", "Invoice", "Invoice", "4", false, "MnuSalesInvoice", "Transaction");
            GridTransaction.Rows.Add("16", "Sales Transaction", "POS Invoice", "POS Invoice", "5", false, "MnuSalesPOSInvoice", "Transaction");
            GridTransaction.Rows.Add("17", "Sales Transaction", "Additional", "Additional", "6", false, "MnuSalesAdditional", "Transaction");
            GridTransaction.Rows.Add("18", "Sales Transaction", "Return", "Return", "7", false, "MnuSalesReturnInvoice", "Transaction");
            GridTransaction.Rows.Add("19", "Sales Transaction", "ExpBrk Invoice", "ExpBrk Invoice", "8", false, "MnuSalesExpBrk", "Transaction");
            GridTransaction.Rows.Add("20", "Cash Bank Voucher", "Cash Bank Voucher", "Cash Bank Voucher", "1", false, "MnuCashBankEntry", "Transaction");
            GridTransaction.Rows.Add("21", "Journal Voucher", "Journal Voucher", "Journal Voucher", "1", false, "MnuJournalVoucher", "Transaction");
            GridTransaction.Rows.Add("22", "Notes Transaction", "Debit Notes", "Debit Notes", "1", false, "MnuDebitNotes", "Transaction");
            GridTransaction.Rows.Add("23", "Notes Transaction", "Credit Notes", "Credit Notes", "2", false, "MnuCreditNotes", "Transaction");

            #endregion------------Transaction--------------------
        }
        private void GridCompany_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                return;
            }

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = GridCompany.AdvancedCellBorderStyle.Top;
            }
        }
        private void GridCompany_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                return;
            }

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
        bool IsTheSameCellValue(int column, int row)
        {
            if (column == 4 || column == 5)
            {
                return false;
            }

            DataGridViewCell cell1 = GridCompany[column, row];
            DataGridViewCell cell2 = GridCompany[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
        bool IsTheSameMasterCellValue(int column, int row)
        {
            if (column == 4 || column == 5)
            {
                return false;
            }

            DataGridViewCell cell1 = GridMaster[column, row];
            DataGridViewCell cell2 = GridMaster[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
        bool IsTheSameTransactionCellValue(int column, int row)
        {
            if (column == 4 || column == 5)
            {
                return false;
            }

            DataGridViewCell cell1 = GridTransaction[column, row];
            DataGridViewCell cell2 = GridTransaction[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
        private void GridMaster_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                return;
            }

            if (IsTheSameMasterCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
        private void GridMaster_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                return;
            }

            if (IsTheSameMasterCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = GridMaster.AdvancedCellBorderStyle.Top;
            }
        }
        private void GridTransaction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                return;
            }

            if (IsTheSameTransactionCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
        private void GridTransaction_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                return;
            }

            if (IsTheSameTransactionCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = GridTransaction.AdvancedCellBorderStyle.Top;
            }
        }
        private void GridCompany_Click(object sender, EventArgs e)
        {
            if (GridCompany.Rows.Count > 0)
            {
                if (Convert.ToBoolean(GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value) == true)
                {
                    GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value = false;
                }
                else
                {
                    GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value = true;
                }
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Menu Permission Group [NEW]";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtGroup.Text))
            {
                MessageBox.Show("Please Enter Group Name.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                TxtGroup.Focus();
                return;
            }
            
            DataAccessLayer.SystemSetting.MenuPermissionGroupViewModel _model = null;

            if (_Tag != "DELETE")
            {
                foreach (DataGridViewRow ro in GridCompany.Rows)
                {
                    _model = new DataAccessLayer.SystemSetting.MenuPermissionGroupViewModel();

                    // _model.ID = Convert.ToInt32(ro.Cells["ID"].Value.ToString());
                    _model.MainForm = ro.Cells["MainForm"].Value.ToString();
                    _model.FormName = ro.Cells["FormName"].Value.ToString();
                    _model.DisplayName = ro.Cells["DisplayName"].Value.ToString();
                    _model.Odr = Convert.ToInt32(ro.Cells["Order"].Value.ToString());
                    _model.Access = Convert.ToBoolean(ro.Cells["Access"].Value) == true ? 1 : 0;
                    _model.MenuId = ro.Cells["MenuId"].Value.ToString();
                    _model.Module = ro.Cells["Module"].Value.ToString();
                    _model.PremissionGroupName = TxtGroup.Text;
                    _objmennupermission.Model.Add(_model);
                }

                foreach (DataGridViewRow ro in GridMaster.Rows)
                {
                    _model = new DataAccessLayer.SystemSetting.MenuPermissionGroupViewModel();
                    //  _model.ID = Convert.ToInt32(ro.Cells["MasterId"].Value.ToString());
                    _model.MainForm = ro.Cells["MasterMainForm"].Value.ToString();
                    _model.FormName = ro.Cells["MasterFormName"].Value.ToString();
                    _model.DisplayName = ro.Cells["MasterDisplayName"].Value.ToString();
                    _model.Odr = Convert.ToInt32(ro.Cells["MasterOrder"].Value.ToString());
                    _model.Access = Convert.ToBoolean(ro.Cells["MasterAccess"].Value) == true ? 1 : 0;
                    _model.MenuId = ro.Cells["MasterMenuId"].Value.ToString();
                    _model.Module = ro.Cells["MasterModule"].Value.ToString();
                    _model.PremissionGroupName = TxtGroup.Text;
                    _objmennupermission.Model.Add(_model);
                }

                foreach (DataGridViewRow ro in GridTransaction.Rows)
                {
                    _model = new DataAccessLayer.SystemSetting.MenuPermissionGroupViewModel();
                    //  _model.ID = Convert.ToInt32(ro.Cells["TransactionId"].Value.ToString());
                    _model.MainForm = ro.Cells["TransactionMainForm"].Value.ToString();
                    _model.FormName = ro.Cells["TransactionFormName"].Value.ToString();
                    _model.DisplayName = ro.Cells["TransactionDisplayName"].Value.ToString();
                    _model.Odr = Convert.ToInt32(ro.Cells["TransactionOrder"].Value.ToString());
                    _model.Access = Convert.ToBoolean(ro.Cells["TransactionAccess"].Value) == true ? 1 : 0;
                    _model.MenuId = ro.Cells["TransactionMenuId"].Value.ToString();
                    _model.Module = ro.Cells["TransactionModule"].Value.ToString();
                    _model.PremissionGroupName = TxtGroup.Text;
                    _objmennupermission.Model.Add(_model);
                }

                foreach (DataGridViewRow ro in GridFinance.Rows)
                {
                    _model = new DataAccessLayer.SystemSetting.MenuPermissionGroupViewModel();
                    //  _model.ID = Convert.ToInt32(ro.Cells["FinanceId"].Value.ToString());
                    _model.MainForm = ro.Cells["FinanceMainForm"].Value.ToString();
                    _model.FormName = ro.Cells["FinanceFormName"].Value.ToString();
                    _model.DisplayName = ro.Cells["FinanceDisplayName"].Value.ToString();
                    _model.Odr = Convert.ToInt32(ro.Cells["FinanceOrder"].Value.ToString());
                    _model.Access = Convert.ToBoolean(ro.Cells["FinanceAccess"].Value) == true ? 1 : 0;
                    _model.MenuId = ro.Cells["FinanceMenuId"].Value.ToString();
                    _model.Module = ro.Cells["FinanceModule"].Value.ToString();
                    _model.PremissionGroupName = TxtGroup.Text;
                    _objmennupermission.Model.Add(_model);
                }

                foreach (DataGridViewRow ro in GridARAP.Rows)
                {
                    _model = new DataAccessLayer.SystemSetting.MenuPermissionGroupViewModel();
                    //  _model.ID = Convert.ToInt32(ro.Cells["ARAPId"].Value.ToString());
                    _model.MainForm = ro.Cells["ARAPMainForm"].Value.ToString();
                    _model.FormName = ro.Cells["ARAPFormName"].Value.ToString();
                    _model.DisplayName = ro.Cells["ARAPDisplayName"].Value.ToString();
                    _model.Odr = Convert.ToInt32(ro.Cells["ARAPOrder"].Value.ToString());
                    _model.Access = Convert.ToBoolean(ro.Cells["ARAPAccess"].Value) == true ? 1 : 0;
                    _model.MenuId = ro.Cells["ARAPMenuId"].Value.ToString();
                    _model.Module = ro.Cells["ARAPModule"].Value.ToString();
                    _model.PremissionGroupName = TxtGroup.Text;
                    _objmennupermission.Model.Add(_model);
                }
            }

            _objmennupermission.SaveMenuPermission(TxtGroup.Text.Trim());

            MessageBox.Show("Data has been updated successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFld();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClose == 1)
            {
                var dialogResult = MessageBox.Show("Are you sure want to Close Form..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                Close();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Tag = "";
            ControlEnableDisable(true, false);
            Text = "Menu Permission Group";
            ClearFld();
        }
        private void FrmMenuPermissionGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    BtnCancel.PerformClick();
                }
                else
                    BtnExit.PerformClick();
                DialogResult = DialogResult.Cancel;
                return;
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Menu Permission Group [EDIT]";
        }
        private void TxtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (_objmennupermission.CheckDuplicate(TxtGroup.Text.Trim(),_Tag) > 0 )
            {
                MessageBox.Show("Group Name Already Exists", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGroup.Focus();
                return;
            }

            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearchGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtGroup, BtnSearchGroup, true);
            }
        }
        private void BtnSearchGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("MenuPermissionGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtGroup.Text = frmPickList.SelectedList[0]["PremissionGroupName"].ToString().Trim();
                    DataTable dt=  _objmennupermission.GetMenuPermissionByName(frmPickList.SelectedList[0]["PremissionGroupName"].ToString().Trim());
                    
                    DataRow[] result1 = dt.Select("Module='Company'");
                    int i = 0;
                    foreach (DataRow row in result1)
                    {
                        GridCompany.Rows[i].Cells[5].Value =  Convert.ToInt32(row["Access"].ToString()) == 0 ? false : true;
                        i++;
                    }

                    DataRow[] result2 = dt.Select("Module='Master'");
                    i = 0;
                    foreach (DataRow row in result2)
                    {
                        GridMaster.Rows[i].Cells[5].Value = Convert.ToInt32(row["Access"].ToString()) == 0 ? false : true;
                        i++;
                    }

                    DataRow[] result3 = dt.Select("Module='Transaction'");
                    i = 0;
                    foreach (DataRow row in result3)
                    {
                        GridTransaction.Rows[i].Cells[5].Value = Convert.ToInt32(row["Access"].ToString()) == 0 ? false : true;
                        i++;
                    }

                    TxtGroup.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Menu Permission Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGroup.Focus();
                return;
            }
            TxtGroup.Focus();
        }
        public void ControlEnableDisable(bool trb, bool fld)
        {
            BtnNew.Enabled = trb;
            BtnEdit.Enabled = trb;
            BtnDelete.Enabled = trb;
            BtnExit.Enabled = trb;
            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }

            BtnSearchGroup.Enabled = fld;
            TxtGroup.Enabled = fld;
            Utility.EnableDesibleColor(TxtGroup, fld);
            tabControl1.Enabled = fld;
            BtnSave.Enabled = fld;
            BtnCancel.Enabled = fld;

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtGroup.Enabled == true)
            {
                TxtGroup.Focus();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Menu Permission Group [DELETE]";
            TxtGroup.Enabled = true;
            BtnSearchGroup.Enabled = true;
            TxtGroup.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void ClearFld()
        {
            foreach (DataGridViewRow ro in GridCompany.Rows)
            {
                ro.Cells["Access"].Value = false;
            }

            foreach (DataGridViewRow ro in GridMaster.Rows)
            {
                ro.Cells["MasterAccess"].Value = false;
            }

            foreach (DataGridViewRow ro in GridTransaction.Rows)
            {
                ro.Cells["TransactionAccess"].Value = false;
            }

            TxtGroup.Text = "";
            TxtGroup.Focus();
        }
    }
}
