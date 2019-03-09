using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acmedesktop.MyInputControls;
using System.Windows.Forms;

namespace acmedesktop.MasterSetup
{
    public partial class FrmUdfMaster : Form
    {
        ClsUdfMaster _objUdfMaster = new ClsUdfMaster();
        ClsCommon _objCommon = new ClsCommon();

        public char _IsNew;
        public int _UDFCode;
        string _Tag = "", _SearchKey = "", result ="";
        MyGridTextBox TxtListDescription;
        public FrmUdfMaster()
        {
            InitializeComponent();
            _Tag = "";
            TxtListDescription = new MyGridTextBox(GridList);
            TxtListDescription.Validating += new System.ComponentModel.CancelEventHandler(this.TxtListDescription_Validating);
            if (GridList.Rows.Count == 0) GridList.Rows.Add();
            GridControlMode(false);
            GridModule.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            GridList.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }
        
        private void FrmUdfMaster_Load(object sender, EventArgs e)
        {
            GridModule.Focus();
            ControlEnableDisable(true, false);
            AddFieldTypeList();
            ClearFld();
            CmbFieldType.SelectedIndex = 0;
            LoadModules();
        }

        private void FrmUdfMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl != GridList)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtListDescription.Visible == true)
                {
                    GridControlMode(false);
                    GridList.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                    this.Tag = "";
                    BtnCancel.PerformClick();
                }
                else if (BtnCancel.Enabled == false)
                    BtnExit.PerformClick();

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            this.Text = "Account Group [NEW]";
            this.Text = "User Defined Field Entry [NEW]";
           
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            this.Text = "User Defined Field Entry [EDIT]";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            TxtDescription.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            BtnSearchDescription.Enabled = true;
            this.Text = "User Defined Field Entry [DELETE]";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Please Enter Description !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtPosition.Text.Trim()))
            {
                MessageBox.Show("Please Enter Schedule !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPosition.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtFieldWidth.Text.Trim()))
            {
                MessageBox.Show("Please Enter Total Width !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFieldWidth.Focus();
                return;
            }

            if (CmbFieldType.Text == "List")
            {
                if (GridList.Rows.Count <= 0)
                {
                    MessageBox.Show("Please Enter Description !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridList.Focus();
                    return;
                }
                if (GridList.Rows.Count == 1 && GridList.Rows[0].Cells["Description"].Value == null && GridList.Visible==true)
                {
                    MessageBox.Show("Please Enter Description !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridList.Focus();
                    return;
                }
            }

            _objUdfMaster.Model.Tag = _Tag;
            _objUdfMaster.Model.UDFCode = this._UDFCode;
            if ((_Tag == "EDIT" || _Tag == "DELETE") && _UDFCode == 0)
            {
                ClearFld();
                return;
            }

            _objUdfMaster.Model.EntryModule = GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString();
            _objUdfMaster.Model.FieldName = TxtDescription.Text;
            _objUdfMaster.Model.FieldType = CmbFieldType.Text;
            _objUdfMaster.Model.FieldWidth = TxtFieldWidth.Text;
            _objUdfMaster.Model.MandotaryOpt = ChkMandatoryOption.Checked == true ? "Y" : "N";
            if (TxtDateFormat.Visible == true)
                _objUdfMaster.Model.DateFormat = TxtDateFormat.SelectedItem.ToString();
            else
                _objUdfMaster.Model.DateFormat = "YYYY";
            _objUdfMaster.Model.FieldDecimal = TxtFieldDecimal.Text;
            _objUdfMaster.Model.UdfPosition = Convert.ToInt32(TxtPosition.Text);
            _objUdfMaster.Model.AllowDuplicate = ChkAllowDuplicate.Checked == true ? "Y" : "N";

            if (CmbFieldType.Text == "List")
            {
                UDFDetailsEntryViewModel UDFEntryDetails = null;
                foreach (DataGridViewRow ro in GridList.Rows)
                {
                    if (ro.Cells["Description"].Value != null)
                    {
                        UDFEntryDetails = new UDFDetailsEntryViewModel();
                        if (ro.Cells["Description"].Value != null) UDFEntryDetails.ListName = ro.Cells["Description"].Value.ToString();
                        _objUdfMaster.ModelUDFDetailsEntry.Add(UDFEntryDetails);
                    }
                }
            }
            _objUdfMaster.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objUdfMaster.Model.Gadget = "Desktop";

            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objUdfMaster.SaveUdfMaster();
                    else
                        return;
                }
                else
                {
                    result = _objUdfMaster.SaveUdfMaster();
                }
            }
            else
            {
                result = _objUdfMaster.SaveUdfMaster();
            }
            
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFld();
            }
            else
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    TxtDescription.Text = "";
                    this.Text = "User Defined Field Entry";
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
                TxtDescription.Text = "";
                this.Text = "User Defined Field Entry";
            }
          
        }

        private void TxtListDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtListDescription.Text))
            {
                if (GridList.Rows.Count <= 1)
                {
                    MessageBox.Show("Description Cannot Left Blank !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtListDescription.Focus();
                }
                else
                    GridControlMode(false);
            }
            else
            {
                if (SetTextBoxValueToGrid() == true)
                {
                    if (GridList.CurrentRow.Index == (GridList.Rows.Count - 1))
                    {
                        GridList.Rows.Add();
                        GridList.CurrentCell = GridList.Rows[GridList.Rows.Count - 1].Cells["Description"];
                    }
                    else
                    {
                        GridList.CurrentCell = GridList.Rows[GridList.CurrentRow.Index + 1].Cells["Description"];
                    }
                    GridControlMode(true);
                }
                else
                {
                    if (this.ActiveControl != TxtListDescription)
                        SendKeys.Send("{Tab}");
                }
            }
        }

        private void GridControlMode(bool mode)
        {
            if (GridList.CurrentRow != null)
            {
                int currRo = GridList.CurrentRow.Index;
                int colindex = 0;
                if (mode == true)
                {
                    colindex = GridList.Columns["Description"].Index;
                    TxtListDescription.Size = this.GridList.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtListDescription.Location = this.GridList.GetCellDisplayRectangle(colindex, currRo, true).Location;
                    SetGridValueToTextBox(currRo);
                }
            }

            TxtListDescription.Enabled = mode;
            TxtListDescription.Visible = mode;

            if (mode == true)
            {
                TxtListDescription.Focus();
            }
        }

        private bool SetTextBoxValueToGrid()
        {
            if (string.IsNullOrEmpty(TxtListDescription.Text))
            {
                TxtListDescription.Focus();
                return false;
            }
            else
            {
                if (GridList.Rows.Count > 1)
                {
                    for (int i = 0; i < GridList.Rows.Count - 1; i++)
                    {
                        if (GridList.Rows[i].Cells["Description"].Value.ToString() == TxtListDescription.Text && i != GridList.CurrentCell.RowIndex)
                        {
                            MessageBox.Show("Same Record Cannot be repeated in the List !");
                            TxtListDescription.Focus();
                            return false;
                        }
                    }
                }

                DataGridViewRow ro = new DataGridViewRow();
                ro = GridList.Rows[GridList.CurrentRow.Index];
                ro.Cells["SNo"].Value = GridList.CurrentRow.Index + 1;
                ro.Cells["Description"].Value = TxtListDescription.Text;
            }
            return true;
        }

        private void SetGridValueToTextBox(int row)
        {
            TxtListDescription.Text = "";
            if (GridList["Description", row].Value != null) TxtListDescription.Text = GridList["Description", row].Value.ToString();
        }
        
        private void GridModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                PanelHeader.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                BtnNew.Focus();
            }
        }

        private void GridList_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewRow ro in GridList.Rows)
            {
                ro.Cells["SNo"].Value = GridList.Rows.IndexOf(ro) + 1;
            }
        }

        private void GridList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GridControlMode(true);
            }
        }

        private void ControlEnableDisable(bool btn, bool fld)
        {
            GridList.Visible = false;
            BtnNew.Enabled = btn;
            BtnEdit.Enabled = btn;
            BtnDelete.Enabled = btn;
            BtnExit.Enabled = btn;

            if (BtnNew.Enabled == true) BtnNew.Focus();
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            CmbFieldType.Enabled = fld;
            CmbFieldType.Enabled = fld;
            ChkMandatoryOption.Enabled = fld;
            ChkAllowDuplicate.Enabled = fld;
            TxtFieldWidth.Enabled = fld;
            Utility.EnableDesibleColor(TxtFieldWidth, fld);
            TxtPosition.Enabled = fld;
            Utility.EnableDesibleColor(TxtPosition, fld);
            TxtFieldDecimal.Enabled = false;
            Utility.EnableDesibleColor(TxtFieldDecimal, fld);

            BtnSearchDescription.Enabled = fld;
            BtnSave.Enabled = fld;
            BtnCancel.Enabled = fld;
            if (BtnNew.Enabled == true)
                BtnNew.Focus();
            else if (TxtDescription.Enabled == true)
                TxtDescription.Focus();
        }

        private void ClearFld()
        {
            TxtDescription.Text = "";
            CmbFieldType.SelectedIndex = 0;
            ChkMandatoryOption.Checked = false;
            ChkAllowDuplicate.Checked = true;
            TxtFieldWidth.Text = "";
            TxtPosition.Text = "";
            TxtFieldDecimal.Text = "";
            TxtDateFormat.Visible = false;
            LblDateFormate.Visible = false;
            GridList.Rows.Clear();
            GridList.Rows.Add();
            GridList.Visible = false;
            TxtDescription.Focus();
        }

        private void CmbFieldType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbFieldType.Text == "String")
                ChkAllowDuplicate.Visible = true;
            else
                ChkAllowDuplicate.Visible = false;

            if (CmbFieldType.Text == "List")
            {
                this.GridList.Location = new System.Drawing.Point(230, 130);
                this.GridList.Size = new System.Drawing.Size(392, 240);
                GridList.Visible = true;
                LblFldDecimal.Visible = false;
                TxtFieldDecimal.Visible = false;
            }
            else
            {
                GridList.Visible = false;
                LblFldDecimal.Visible = true;
                TxtFieldDecimal.Visible = true;
            }

            if (CmbFieldType.Text == "Date")
            {
                TxtFieldWidth.Text = "8";
                TxtFieldWidth.Enabled = false;
                TxtDateFormat.Visible = true;
                LblDateFormate.Visible = true;
                this.TxtDateFormat.Location = new System.Drawing.Point(510, 70);
                this.LblDateFormate.Location = new System.Drawing.Point(427, 70);
                TxtDateFormat.SelectedIndex = 0;
            }
            else
            {
                TxtFieldWidth.Text = "";
                TxtFieldWidth.Enabled = true;
                TxtDateFormat.Visible = false;
                LblDateFormate.Visible = false;
            }
            Selection_Change();
        }

        public void LoadModules()
        {
            GridModule.Rows.Add("Ledger Master");
            GridModule.Rows.Add("Product Master");
            GridModule.Rows.Add("Product Batch");
            GridModule.Rows.Add("Cash Bank Master");
            GridModule.Rows.Add("Cash Bank Details");
            GridModule.Rows.Add("Journal Voucher Master");
            GridModule.Rows.Add("Journal Voucher Details");
            GridModule.Rows.Add("Debit Note Master");
            GridModule.Rows.Add("Debit Note Details");
            GridModule.Rows.Add("Credit Note Master");
            GridModule.Rows.Add("Credit Note Details");
            GridModule.Rows.Add("Sales Master Global");
            GridModule.Rows.Add("Sales Details Global");
            GridModule.Rows.Add("Purchase Master Global");
            GridModule.Rows.Add("Purchase Details Global");
            GridModule.Rows.Add("Stock Master Global");
            GridModule.Rows.Add("Stock Details Global");
            GridModule.Rows.Add("InventoryMaster Global");
            GridModule.Rows.Add("InventoryDetails Global");
            GridModule.Rows.Add("Finished Master Global");
            GridModule.Rows.Add("Finished Details Global");
        }

        private void TxtFieldWidth_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Tag.ToString()))
            {
                int TotalWidth = 0;
                int.TryParse(TxtFieldWidth.Text, out TotalWidth);

                if (CmbFieldType.Text == "String")
                {
                    if (TotalWidth < 8 || TotalWidth > 255)
                    {
                        MessageBox.Show("Total Width Should be between 8 to 255", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtFieldWidth.SelectAll();
                        TxtFieldWidth.Focus();
                    }
                }
                else if (CmbFieldType.Text == "Number")
                {
                    if (TotalWidth < 1 || TotalWidth > 18)
                    {
                        MessageBox.Show("Total Width Should be between 1 to 18", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtFieldWidth.SelectAll();
                        TxtFieldWidth.Focus();
                    }
                }
                else if (CmbFieldType.Text == "Yes/No")
                {
                    if (TotalWidth != 1)
                    {
                        MessageBox.Show("Total Width Should be between 1", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtFieldWidth.SelectAll();
                        TxtFieldWidth.Focus();
                    }
                }
                else if (CmbFieldType.Text == "Memo")
                {
                    if (TotalWidth < 1 || TotalWidth > 199)
                    {
                        MessageBox.Show("Total Width Should be between 1 to 199", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtFieldWidth.SelectAll();
                        TxtFieldWidth.Focus();
                    }
                }
                else if (CmbFieldType.Text == "List")
                {
                    if (TotalWidth < 8 || TotalWidth > 255)
                    {
                        MessageBox.Show("Total Width Should be between 8 to 255", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtFieldWidth.SelectAll();
                        TxtFieldWidth.Focus();
                    }
                }
            }
        }

        private void TxtPosition_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Tag.ToString()))
            {
                if (string.IsNullOrEmpty(TxtPosition.Text))
                {
                    MessageBox.Show("Field Name Cannot Left Blank", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtPosition.Focus();
                    return;
                }
                else if (_Tag == "NEW")
                {
                    if (_objUdfMaster.CheckDuplicatePosition(TxtPosition.Text, GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString()) == 1)
                    {
                        MessageBox.Show("Udf Position for the UDF Module ___[" + GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString() + "]___ cannot be duplicate", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtPosition.SelectAll();
                        TxtPosition.Focus();
                        return;
                    }
                }
            }
        }

        private void BtnSearchDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("UDFMaster", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    this._UDFCode = Convert.ToInt32(frmPickList.SelectedList[0]["UDFCode"].ToString().Trim());
                    DataSet ds = _objUdfMaster.GetDataUDFMaster(this._UDFCode);
                    SetData(ds);
                }
                else
                {
                    TxtDescription.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in UDF !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }

        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearchDescription.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchDescription, true);
            }
        }

        private void SetData(DataSet ds)
        {
            DataTable dt1 = ds.Tables[0];
            
            ChkMandatoryOption.Checked = dt1.Rows[0]["MandotaryOpt"].ToString() == "Y" ? true : false;
            ChkAllowDuplicate.Checked = dt1.Rows[0]["AllowDuplicate"].ToString() == "Y" ? true : false;
            TxtDescription.Text = dt1.Rows[0]["FieldName"].ToString();
            CmbFieldType.SelectedItem = dt1.Rows[0]["FieldType"].ToString();
            TxtFieldWidth.Text = dt1.Rows[0]["FieldWidth"].ToString();
            TxtPosition.Text = dt1.Rows[0]["UdfPosition"].ToString();
            TxtFieldDecimal.Text = dt1.Rows[0]["FieldDecimal"].ToString();
            TxtDateFormat.SelectedItem = dt1.Rows[0]["DateFormat"].ToString();

            if (dt1.Rows[0]["FieldType"].ToString() == "List")
            {
                DataTable dt2 = ds.Tables[1];
                GridList.Visible = true;
                int i = 1;
                foreach (DataRow  dr in dt2.Rows)
                {
                    GridList.Rows[GridList.Rows.Count - 1].Cells["SNo"].Value = i;
                    GridList.Rows[GridList.Rows.Count - 1].Cells["Description"].Value = dr["ListName"].ToString();
                    GridList.Rows.Add();
                    i++;
                }
            }
            TxtDescription.SelectAll();
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Field Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckUDFDuplicateRecord(TxtDescription.Text.Trim(), GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString()) == 1)
                {
                    MessageBox.Show("Field Name Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckUDFDuplicateRecord(TxtDescription.Text.Trim(), GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString(), _UDFCode) != 0)
                {
                    MessageBox.Show("Field Name Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void CmbFieldType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                SendKeys.Send("{F4}");
        }

        private void GridModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString() == "Product Batch")
                AddFieldTypeListForBatch();
            else
                AddFieldTypeList();
        }

        private void GridModule_SelectionChanged(object sender, EventArgs e)
        {
            if (GridModule.Rows[Convert.ToInt32(GridModule.CurrentRow.Index)].Cells[0].Value.ToString() == "Product Batch")
                AddFieldTypeListForBatch();
            else
                AddFieldTypeList();
        }

        public void Selection_Change()
        {
            if (CmbFieldType.Text == "String" || CmbFieldType.Text == "Date" || CmbFieldType.Text == "Yes/No" || CmbFieldType.Text == "Memo")
                TxtFieldDecimal.Enabled = false;
            else
                TxtFieldDecimal.Enabled = true;
        }

        private void AddFieldTypeList()
        {
            Dictionary<string, string> _CmbType = new Dictionary<string, string>();
            _CmbType.Add("String", "String");
            _CmbType.Add("Number", "Number");
            _CmbType.Add("Date", "Date");
            _CmbType.Add("Yes/No", "Yes/No");
            _CmbType.Add("Memo", "Memo");
            _CmbType.Add("List", "List");
            CmbFieldType.DataSource = new BindingSource(_CmbType, null);
            CmbFieldType.DisplayMember = "Value";
            CmbFieldType.ValueMember = "Key";
            CmbFieldType.SelectedIndex = 0;
        }

        private void AddFieldTypeListForBatch()
        {
            Dictionary<string, string> _CmbType = new Dictionary<string, string>();
            _CmbType.Add("String", "String");
            _CmbType.Add("Number", "Number");
            _CmbType.Add("Date", "Date");
            _CmbType.Add("Yes/No", "Yes/No");
            _CmbType.Add("Memo", "Memo");
            CmbFieldType.DataSource = new BindingSource(_CmbType, null);
            CmbFieldType.DisplayMember = "Value";
            CmbFieldType.ValueMember = "Key";
            CmbFieldType.SelectedIndex = 0;
        }
    }
}
