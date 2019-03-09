using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.MasterSetup
{
    public partial class FrmGeneralLedgerMapping : Form
    {
        public ClsGeneralLedger _objGeneralLedger = new ClsGeneralLedger();
        ClsCommon _objCommon = new ClsCommon();
        string _Tag = "", _SearchKey = "";
        DataRow[] GlDataRows;
        DataTable dtAccountGroupListForLedgerMapping = new DataTable();
        DataTable dtAccountSubGroupListForLedgerMapping = new DataTable();
        DataTable dtSalesManListForLedgerMapping = new DataTable();
        DataTable dtAreaForLedgerMapping = new DataTable();
        DataTable dtBranchForLedgerMapping = new DataTable();
        DataTable dtCopanyUnitForLedgerMapping = new DataTable();


        public FrmGeneralLedgerMapping()
        {
            InitializeComponent();
        }

        private void FrmGeneralLedgerMapping_Load(object sender, EventArgs e)
        {
            _Tag = "NEW";
            AccountGroupListForLedgerMapping();
            AccountSubGroupListForLedgerMapping();
            SalesManListForLedgerMapping();
            AreaListForLedgerMapping();
            BranchListForLedgerMapping();
            CompanyUnitListForLedgerMapping();
        }

        private void FrmGeneralLedgerMapping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void TxtAccountGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchAccountGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtAccountGroup, BtnSearchAccountGroup, true);
            }
        }

        private void BtnSearchAccountGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("AccountGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtAccountGroup.Text = frmPickList.SelectedList[0]["AccountGrpDesc"].ToString().Trim();
                    TxtAccountGroup.Tag = frmPickList.SelectedList[0]["AccountGrpId"].ToString().Trim();
                    AccountGroupListForLedgerMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Account Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }
            TxtAccountGroup.Focus();
        }
        private void TxtAccountSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchAccountSubGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtAccountSubGroup, BtnSearchAccountSubGroup, true);
            }
        }

        private void BtnSearchAccountSubGroup_Click(object sender, EventArgs e)
        {          
            Common.PickList frmPickList = new Common.PickList("AccountSubGroup." + TxtAccGroup.Tag, _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtAccountSubGroup.Text = frmPickList.SelectedList[0]["AccountSubGrpDesc"].ToString().Trim();
                    TxtAccountSubGroup.Tag = frmPickList.SelectedList[0]["AccountSubGrpId"].ToString().Trim();
                    AccountSubGroupListForLedgerMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Account Sub Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountSubGroup.Focus();
                return;
            }
            TxtAccountSubGroup.Focus();
        }

        private void BtnMapToAccGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAccountGroup.Text))
            {
                MessageBox.Show("Account Group Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }

            LedgerMappingList ObjLedgerMappingList = null;
            foreach (DataGridViewRow ro in GridAccGroup.Rows)
            {
                ObjLedgerMappingList = new LedgerMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjLedgerMappingList.LedgerId = Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString());
                    ObjLedgerMappingList.AccountGrpId = Convert.ToInt32(TxtAccountGroup.Tag.ToString());                  
                    _objGeneralLedger.ModelLedgerMappingList.Add(ObjLedgerMappingList);
                }
            }           

            _objGeneralLedger.SaveLedgerMapping("AccountGroup");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AccountGroupListForLedgerMapping();
        }

        private void BtnMapToAccGroupCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridAccGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtAccountGroup.Tag.ToString() != "0")
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (GlDataRows.Length > 0)
                    {
                        for (int i = 0; i < GlDataRows.Length; i++)
                        {
                            if (GlDataRows[i]["LedgerId"].ToString() == GridAccGroup.Rows[Convert.ToInt32(GridAccGroup.CurrentRow.Index)].Cells["LedgerId"].Value.ToString())
                            {
                                return;
                            }
                        }
                    }

                    if (Convert.ToBoolean(GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value) == true)
                    {
                        GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value = false;
                        return;
                    }

                    var editingCell = Convert.ToBoolean(((DataGridViewCheckBoxCell)GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells[0]).EditingCellFormattedValue);
                    if (editingCell == false)
                    {
                        var _ledgerId = GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["LedgerId"];
                        DataRow[] result1 = dtAccountGroupListForLedgerMapping.Select("LedgerId ='" + _ledgerId.Value.ToString() + "'");
                        DialogResult dialog = MessageBox.Show("This Ledger is Already Tag in ...[" + result1[0]["AccountGrpDesc"].ToString() + "]... Account Group. Do you want to continue?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value = true;
                        }
                        else
                        {
                            var datagridView = (DataGridView)sender;
                            if (GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value == null)
                            {
                                GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value = true;
                            }
                            else
                            {
                                GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value = false;
                            }
                            datagridView.EndEdit();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Account Group Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }
        }

        private void GridAccGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TxtAccountGroup.Tag.ToString() != "0")
            {
                if (e.RowIndex > -1 && e.ColumnIndex == 0)
                {
                    if (GlDataRows.Length > 0)
                    {
                        for (int i = 0; i < GlDataRows.Length; i++)
                        {
                            if (GlDataRows[i]["LedgerId"].ToString() == GridAccGroup.Rows[Convert.ToInt32(GridAccGroup.CurrentRow.Index)].Cells["LedgerId"].Value.ToString())
                            {
                                return;
                            }
                        }
                    }

                    var editingCell = Convert.ToBoolean(((DataGridViewCheckBoxCell)GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells[0]).EditingCellFormattedValue);
                    if (editingCell == false)
                    {
                        var _ledgerId = GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["LedgerId"];
                        DataRow[] result1 = dtAccountGroupListForLedgerMapping.Select("LedgerId ='" + _ledgerId.Value.ToString() + "'");
                        DialogResult dialog = MessageBox.Show("This Ledger is Already Tag in ...[" + result1[0]["AccountGrpDesc"].ToString() + "]... Account Group. Do you want to continue?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            GridAccGroup.Rows[GridAccGroup.CurrentRow.Index].Cells["Tag"].Value = true;
                        }
                        else
                        {
                            var datagridView = (DataGridView)sender;
                            var cell = datagridView[0, e.RowIndex];
                            if (cell.Value == null)
                            {
                                cell.Value = true;
                            }

                            cell.Value = false;
                            datagridView.EndEdit();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Account Group Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }
        }

        public void AccountGroupListForLedgerMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Group");
            dt.Columns.Add("LedgerId");
            dt.Columns.Add("AccountGrpId");
            dtAccountGroupListForLedgerMapping = _objGeneralLedger.AccountGroupListForLedgerMapping(TxtAccountGroup.Tag.ToString());
            GlDataRows = dtAccountGroupListForLedgerMapping.Select("Tag='True'");
            foreach (DataRow row in dtAccountGroupListForLedgerMapping.Rows)
            {
                if (dtAccountGroupListForLedgerMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["GlShortName"].ToString();
                    dr["Description"] = row["GlDesc"].ToString();
                    dr["Group"] = row["AccountGrpDesc"].ToString();
                    dr["LedgerId"] = row["LedgerId"].ToString();
                    dr["AccountGrpId"] = row["AccountGrpId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridAccGroup.DataSource = dt;
            GridAccGroup.Columns["Tag"].Width = 40;
            GridAccGroup.Columns["Short Name"].Width = 100;
            GridAccGroup.Columns["Short Name"].ReadOnly = true;
            GridAccGroup.Columns["Description"].ReadOnly = true;
            GridAccGroup.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridAccGroup.Columns["Group"].Width = 180;
            GridAccGroup.Columns["Group"].ReadOnly = true;
            GridAccGroup.Columns["LedgerId"].Visible = false;
            GridAccGroup.Columns["AccountGrpId"].Visible = false;
            GridAccGroup.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridAccGroup.Rows)
            {
                if (GridAccGroup.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void AccountSubGroupListForLedgerMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Group");
            dt.Columns.Add("SubGroup");
            dt.Columns.Add("LedgerId");           
            dtAccountSubGroupListForLedgerMapping = _objGeneralLedger.AccountSubGroupListForLedgerMapping(TxtAccountSubGroup.Tag.ToString());
            GlDataRows = dtAccountSubGroupListForLedgerMapping.Select("Tag='True'");
            foreach (DataRow row in dtAccountSubGroupListForLedgerMapping.Rows)
            {
                if (dtAccountSubGroupListForLedgerMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["GlShortName"].ToString();
                    dr["Description"] = row["GlDesc"].ToString();
                    dr["Group"] = row["AccountGrpDesc"].ToString();
                    dr["SubGroup"] = row["AccountSubGrpDesc"].ToString();
                    dr["LedgerId"] = row["LedgerId"].ToString();                   
                    dt.Rows.Add(dr);
                }
            }

            GridAccSubGroup.DataSource = dt;
            GridAccSubGroup.Columns["Tag"].Width = 40;
            GridAccSubGroup.Columns["Short Name"].Width = 100;
            GridAccSubGroup.Columns["Short Name"].ReadOnly = true;
            GridAccSubGroup.Columns["Description"].ReadOnly = true;
            GridAccSubGroup.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridAccSubGroup.Columns["Group"].Width = 180;
            GridAccSubGroup.Columns["Group"].ReadOnly = true;
            GridAccSubGroup.Columns["SubGroup"].Width = 180;
            GridAccSubGroup.Columns["SubGroup"].ReadOnly = true;
            GridAccSubGroup.Columns["LedgerId"].Visible = false;           
            GridAccSubGroup.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridAccSubGroup.Rows)
            {
                if (GridAccSubGroup.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void SalesManListForLedgerMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Sales Man");
            dt.Columns.Add("LedgerId");
            dt.Columns.Add("SalesmanId");
            dtSalesManListForLedgerMapping = _objGeneralLedger.SalesManpListForLedgerMapping(TxtSalesMan.Tag.ToString());
            GlDataRows = dtSalesManListForLedgerMapping.Select("Tag='True'");
            foreach (DataRow row in dtSalesManListForLedgerMapping.Rows)
            {
                if (dtSalesManListForLedgerMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["GlShortName"].ToString();
                    dr["Description"] = row["GlDesc"].ToString();
                    dr["Sales Man"] = row["SalesmanDesc"].ToString();
                    dr["LedgerId"] = row["LedgerId"].ToString();
                    dr["SalesmanId"] = row["SalesmanId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridSalesMan.DataSource = dt;
            GridSalesMan.Columns["Tag"].Width = 40;
            GridSalesMan.Columns["Short Name"].Width = 100;
            GridSalesMan.Columns["Short Name"].ReadOnly = true;
            GridSalesMan.Columns["Description"].ReadOnly = true;
            GridSalesMan.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridSalesMan.Columns["Sales Man"].Width = 180;
            GridSalesMan.Columns["Sales Man"].ReadOnly = true;
            GridSalesMan.Columns["LedgerId"].Visible = false;
            GridSalesMan.Columns["SalesmanId"].Visible = false;
            GridSalesMan.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridSalesMan.Rows)
            {
                if (GridSalesMan.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void AreaListForLedgerMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Area");
            dt.Columns.Add("LedgerId");
            dt.Columns.Add("AreaId");
            dtAreaForLedgerMapping = _objGeneralLedger.AreaListForLedgerMapping(TxtArea.Tag.ToString());
            GlDataRows = dtAreaForLedgerMapping.Select("Tag='True'");
            foreach (DataRow row in dtAreaForLedgerMapping.Rows)
            {
                if (dtAreaForLedgerMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["GlShortName"].ToString();
                    dr["Description"] = row["GlDesc"].ToString();
                    dr["Area"] = row["AreaDesc"].ToString();
                    dr["LedgerId"] = row["LedgerId"].ToString();
                    dr["AreaId"] = row["AreaId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridArea.DataSource = dt;
            GridArea.Columns["Tag"].Width = 40;
            GridArea.Columns["Short Name"].Width = 100;
            GridArea.Columns["Short Name"].ReadOnly = true;
            GridArea.Columns["Description"].ReadOnly = true;
            GridArea.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridArea.Columns["Area"].Width = 180;
            GridArea.Columns["Area"].ReadOnly = true;
            GridArea.Columns["LedgerId"].Visible = false;
            GridArea.Columns["AreaId"].Visible = false;
            GridArea.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridArea.Rows)
            {
                if (GridArea.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void BranchListForLedgerMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Branch");
            dt.Columns.Add("LedgerId");
            dt.Columns.Add("BranchId");
            dtBranchForLedgerMapping = _objGeneralLedger.BranchListForLedgerMapping(TxtBranch.Tag.ToString());
            GlDataRows = dtBranchForLedgerMapping.Select("Tag='True'");
            foreach (DataRow row in dtBranchForLedgerMapping.Rows)
            {
                if (dtBranchForLedgerMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["GlShortName"].ToString();
                    dr["Description"] = row["GlDesc"].ToString();
                    dr["Branch"] = row["BranchName"].ToString();
                    dr["LedgerId"] = row["LedgerId"].ToString();
                    dr["BranchId"] = row["BranchId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridBranch.DataSource = dt;
            GridBranch.Columns["Tag"].Width = 40;
            GridBranch.Columns["Short Name"].Width = 100;
            GridBranch.Columns["Short Name"].ReadOnly = true;
            GridBranch.Columns["Description"].ReadOnly = true;
            GridBranch.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridBranch.Columns["Branch"].Width = 180;
            GridBranch.Columns["Branch"].ReadOnly = true;
            GridBranch.Columns["LedgerId"].Visible = false;
            GridBranch.Columns["BranchId"].Visible = false;
            GridBranch.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridBranch.Rows)
            {
                if (GridBranch.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void CompanyUnitListForLedgerMapping() 
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Company Unit");
            dt.Columns.Add("LedgerId");
            dtCopanyUnitForLedgerMapping = _objGeneralLedger.CompanyUnitListForLedgerMapping(TxtCompanyUnit.Tag.ToString());
            GlDataRows = dtCopanyUnitForLedgerMapping.Select("Tag='True'");
            foreach (DataRow row in dtCopanyUnitForLedgerMapping.Rows)
            {
                if (dtCopanyUnitForLedgerMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["GlShortName"].ToString();
                    dr["Description"] = row["GlDesc"].ToString();
                    dr["Company Unit"] = row["CmpUnitName"].ToString();
                    dr["LedgerId"] = row["LedgerId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridCompanyUnit.DataSource = dt;
            GridCompanyUnit.Columns["Tag"].Width = 40;
            GridCompanyUnit.Columns["Short Name"].Width = 100;
            GridCompanyUnit.Columns["Short Name"].ReadOnly = true;
            GridCompanyUnit.Columns["Description"].ReadOnly = true;
            GridCompanyUnit.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridCompanyUnit.Columns["Company Unit"].Width = 180;
            GridCompanyUnit.Columns["Company Unit"].ReadOnly = true;
            GridCompanyUnit.Columns["LedgerId"].Visible = false;
            GridCompanyUnit.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridCompanyUnit.Rows)
            {
                if (GridCompanyUnit.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        private void BtnSearchSalesMan_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SubSalesman", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSalesMan.Text = frmPickList.SelectedList[0]["Salesmandesc"].ToString().Trim();
                    TxtSalesMan.Tag = frmPickList.SelectedList[0]["SalesmanId"].ToString().Trim();
                    SalesManListForLedgerMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Sales Man !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesMan.Focus();
                return;
            }
            TxtSalesMan.Focus();
        }

        private void TxtSalesMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchSalesMan.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtSalesMan, BtnSearchSalesMan, true);
            }
            
        }

        private void TxtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchArea.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtArea, BtnSearchArea, true);
            }
           
        }

        private void GridSalesMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtSalesMan.Tag.ToString() != "0")
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (GlDataRows.Length > 0)
                    {
                        for (int i = 0; i < GlDataRows.Length; i++)
                        {
                            if (GlDataRows[i]["LedgerId"].ToString() == GridSalesMan.Rows[Convert.ToInt32(GridSalesMan.CurrentRow.Index)].Cells["LedgerId"].Value.ToString())
                            {
                                return;
                            }
                        }
                    }

                    if (Convert.ToBoolean(GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value) == true)
                    {
                        GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value = false;
                        return;
                    }

                    var editingCell = Convert.ToBoolean(((DataGridViewCheckBoxCell)GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells[0]).EditingCellFormattedValue);
                    if (editingCell == false)
                    {
                        var _ledgerId = GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["LedgerId"];
                        DataRow[] result1 = dtSalesManListForLedgerMapping.Select("LedgerId ='" + _ledgerId.Value.ToString() + "'");
                        DialogResult dialog = MessageBox.Show("This Ledger is Already Tag in ...[" + result1[0]["SalesmanDesc"].ToString() + "]... Sales Man. Do you want to continue?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value = true;
                        }
                        else
                        {
                            var datagridView = (DataGridView)sender;
                            if (GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value == null)
                            {
                                GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value = true;
                            }
                            else
                            {
                                GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value = false;
                            }
                            datagridView.EndEdit();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sales Man Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesMan.Focus();
                return;
            }
        }

        private void GridArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtArea.Tag.ToString() != "0")
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (GlDataRows.Length > 0)
                    {
                        for (int i = 0; i < GlDataRows.Length; i++)
                        {
                            if (GlDataRows[i]["LedgerId"].ToString() == GridArea.Rows[Convert.ToInt32(GridArea.CurrentRow.Index)].Cells["LedgerId"].Value.ToString())
                            {
                                return;
                            }
                        }
                    }

                    if (Convert.ToBoolean(GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value) == true)
                    {
                        GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value = false;
                        return;
                    }

                    var editingCell = Convert.ToBoolean(((DataGridViewCheckBoxCell)GridArea.Rows[GridArea.CurrentRow.Index].Cells[0]).EditingCellFormattedValue);
                    if (editingCell == false)
                    {
                        var _ledgerId = GridArea.Rows[GridArea.CurrentRow.Index].Cells["LedgerId"];
                        DataRow[] result1 = dtAreaForLedgerMapping.Select("LedgerId ='" + _ledgerId.Value.ToString() + "'");
                        DialogResult dialog = MessageBox.Show("This Ledger is Already Tag in ...[" + result1[0]["AreaDesc"].ToString() + "]...Area. Do you want to continue?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value = true;
                        }
                        else
                        {
                            var datagridView = (DataGridView)sender;
                            if (GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value == null)
                            {
                                GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value = true;
                            }
                            else
                            {
                                GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value = false;
                            }
                            datagridView.EndEdit();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Area Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtArea.Focus();
                return;
            }
        }

        private void GridSalesMan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TxtSalesMan.Tag.ToString() != "0")
            {
                if (e.RowIndex > -1 && e.ColumnIndex == 0)
                {
                    if (GlDataRows.Length > 0)
                    {
                        for (int i = 0; i < GlDataRows.Length; i++)
                        {
                            if (GlDataRows[i]["LedgerId"].ToString() == GridSalesMan.Rows[Convert.ToInt32(GridSalesMan.CurrentRow.Index)].Cells["LedgerId"].Value.ToString())
                            {
                                return;
                            }
                        }
                    }

                    var editingCell = Convert.ToBoolean(((DataGridViewCheckBoxCell)GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells[0]).EditingCellFormattedValue);
                    if (editingCell == false)
                    {
                        var _ledgerId = GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["LedgerId"];
                        DataRow[] result1 = dtSalesManListForLedgerMapping.Select("LedgerId ='" + _ledgerId.Value.ToString() + "'");
                        DialogResult dialog = MessageBox.Show("This Ledger is Already Tag in ...[" + result1[0]["SalesmanDesc"].ToString() + "]... Sales Man. Do you want to continue?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells["Tag"].Value = true;
                        }
                        else
                        {
                            var datagridView = (DataGridView)sender;
                            var cell = datagridView[0, e.RowIndex];
                            if (cell.Value == null)
                            {
                                cell.Value = true;
                            }

                            cell.Value = false;
                            datagridView.EndEdit();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sales Man Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesMan.Focus();
                return;
            }
        }

        private void GridArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TxtArea.Tag.ToString() != "0")
            {
                if (e.RowIndex > -1 && e.ColumnIndex == 0)
                {
                    if (GlDataRows.Length > 0)
                    {
                        for (int i = 0; i < GlDataRows.Length; i++)
                        {
                            if (GlDataRows[i]["LedgerId"].ToString() == GridArea.Rows[Convert.ToInt32(GridArea.CurrentRow.Index)].Cells["LedgerId"].Value.ToString())
                            {
                                return;
                            }
                        }
                    }

                    var editingCell = Convert.ToBoolean(((DataGridViewCheckBoxCell)GridSalesMan.Rows[GridSalesMan.CurrentRow.Index].Cells[0]).EditingCellFormattedValue);
                    if (editingCell == false)
                    {
                        var _ledgerId = GridArea.Rows[GridArea.CurrentRow.Index].Cells["LedgerId"];
                        DataRow[] result1 = dtAreaForLedgerMapping.Select("LedgerId ='" + _ledgerId.Value.ToString() + "'");
                        DialogResult dialog = MessageBox.Show("This Ledger is Already Tag in ...[" + result1[0]["AreaDesc"].ToString() + "]... Area. Do you want to continue?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            GridArea.Rows[GridArea.CurrentRow.Index].Cells["Tag"].Value = true;
                        }
                        else
                        {
                            var datagridView = (DataGridView)sender;
                            var cell = datagridView[0, e.RowIndex];
                            if (cell.Value == null)
                            {
                                cell.Value = true;
                            }

                            cell.Value = false;
                            datagridView.EndEdit();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Area Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtArea.Focus();
                return;
            }
        }

        private void BtnMapToCompanyUnitOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCompanyUnit.Text))
            {
                MessageBox.Show("Company Unit Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCompanyUnit.Focus();
                return;
            }
            LedgerMappingList ObjLedgerMappingList = null;
            foreach (DataGridViewRow ro in GridCompanyUnit.Rows)
            {
                ObjLedgerMappingList = new LedgerMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjLedgerMappingList.LedgerId = Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString());
                    ObjLedgerMappingList.CompanyUnitId = Convert.ToInt32(TxtCompanyUnit.Tag.ToString());
                    ObjLedgerMappingList.BranchId = Convert.ToInt32(LblBranch.Tag.ToString());                 
                    _objGeneralLedger.ModelLedgerMappingList.Add(ObjLedgerMappingList);
                }
            }

            _objGeneralLedger.SaveLedgerMapping("CompanyUnit");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CompanyUnitListForLedgerMapping();
        }

        private void BtnMapToSalesManOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSalesMan.Text))
            {
                MessageBox.Show("Sales Man Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesMan.Focus();
                return;
            }
            LedgerMappingList ObjLedgerMappingList = null;
            foreach (DataGridViewRow ro in GridSalesMan.Rows)
            {
                ObjLedgerMappingList = new LedgerMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjLedgerMappingList.LedgerId = Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString());
                    ObjLedgerMappingList.SalesmanId = Convert.ToInt32(TxtSalesMan.Tag.ToString());                  
                    _objGeneralLedger.ModelLedgerMappingList.Add(ObjLedgerMappingList);
                }
            }
            _objGeneralLedger.SaveLedgerMapping("Salesman");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SalesManListForLedgerMapping();
        }

        private void BtnMapToAreaOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtArea.Text))
            {
                MessageBox.Show("Area Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtArea.Focus();
                return;
            }
            LedgerMappingList ObjLedgerMappingList = null;
            foreach (DataGridViewRow ro in GridArea.Rows)
            {
                ObjLedgerMappingList = new LedgerMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjLedgerMappingList.LedgerId = Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString());
                    ObjLedgerMappingList.AreaId = Convert.ToInt32(TxtArea.Tag.ToString());                  
                    _objGeneralLedger.ModelLedgerMappingList.Add(ObjLedgerMappingList);
                }
            }

            _objGeneralLedger.SaveLedgerMapping("Area");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AreaListForLedgerMapping();
        }

        private void BtnMapToAccSubGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAccGroup.Text))
            {
                MessageBox.Show("Account  Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccGroup.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtAccountSubGroup.Text))
            {
                MessageBox.Show("Account Sub Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountSubGroup.Focus();
                return;
            }
            LedgerMappingList ObjLedgerMappingList = null;
            foreach (DataGridViewRow ro in GridAccSubGroup.Rows)
            {
                ObjLedgerMappingList = new LedgerMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjLedgerMappingList.LedgerId = Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString());
                    ObjLedgerMappingList.AccountGrpId = Convert.ToInt32(TxtAccGroup.Tag.ToString());
                    ObjLedgerMappingList.AccountSubGrpId = Convert.ToInt32(TxtAccountSubGroup.Tag.ToString());                   
                    _objGeneralLedger.ModelLedgerMappingList.Add(ObjLedgerMappingList);
                }
            }
            _objGeneralLedger.SaveLedgerMapping("AccountSubGroup");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AccountSubGroupListForLedgerMapping();
        }

        private void BtnSearchBranch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Branch", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtBranch.Text = frmPickList.SelectedList[0]["BranchName"].ToString().Trim();
                    TxtBranch.Tag = frmPickList.SelectedList[0]["BranchId"].ToString().Trim();
                    BranchListForLedgerMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Branch !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBranch.Focus();
                return;
            }
            TxtBranch.Focus();
        }

        private void TxtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchBranch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtBranch, BtnSearchBranch, true);
            }
        }

        private void BtnMapToBranchOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBranch.Text))
            {
                MessageBox.Show("Branch Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBranch.Focus();
                return;
            }
            LedgerMappingList ObjLedgerMappingList = null;
            foreach (DataGridViewRow ro in GridBranch.Rows)
            {
                ObjLedgerMappingList = new LedgerMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjLedgerMappingList.LedgerId = Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString());
                    ObjLedgerMappingList.BranchId = Convert.ToInt32(TxtBranch.Tag.ToString());                    
                    _objGeneralLedger.ModelLedgerMappingList.Add(ObjLedgerMappingList);
                }
            }

            _objGeneralLedger.SaveLedgerMapping("Branch");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BranchListForLedgerMapping();
        }

        private void BtnSearchCompanyUnit_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("CompanyUnit", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtCompanyUnit.Text = frmPickList.SelectedList[0]["CmpUnitName"].ToString().Trim();
                    TxtCompanyUnit.Tag = frmPickList.SelectedList[0]["CompanyUnitId"].ToString().Trim();
                    LblBranch.Text = frmPickList.SelectedList[0]["BranchName"].ToString().Trim();
                    LblBranch.Tag = frmPickList.SelectedList[0]["BranchId"].ToString().Trim();                    
                    CompanyUnitListForLedgerMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Company Unit !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCompanyUnit.Focus();
                return;
            }
            TxtCompanyUnit.Focus();
        }

        private void TxtCompanyUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchCompanyUnit.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtCompanyUnit, BtnSearchCompanyUnit, true);
            }
        }

        private void LblBranch_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TabCompanyUnit_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearchAccGroup_Click(object sender, EventArgs e)
        {
            TxtAccountSubGroup.Text = "";
            TxtAccountSubGroup.Tag = 0;
            Common.PickList frmPickList = new Common.PickList("AccountGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtAccGroup.Text = frmPickList.SelectedList[0]["AccountGrpDesc"].ToString().Trim();
                    TxtAccGroup.Tag = frmPickList.SelectedList[0]["AccountGrpId"].ToString().Trim();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Account Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccGroup.Focus();
                return;
            }
            TxtAccGroup.Focus();
        }

        private void TxtAccGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchAccGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtAccGroup, BtnSearchAccGroup, true);
            }
        }

        private void BtnMapToAccSubGroupCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMapToSalesManCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMapToAreaCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMapToBranchCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMapToCompanyUnitCancel_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private void BtnSearchArea_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SubArea", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtArea.Text = frmPickList.SelectedList[0]["AreaDesc"].ToString().Trim();
                    TxtArea.Tag = frmPickList.SelectedList[0]["AreaId"].ToString().Trim();
                    AreaListForLedgerMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Area !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtArea.Focus();
                return;
            }
            TxtArea.Focus();
        }
    }
}
