using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
namespace acmedesktop.MasterSetup
{
    public partial class FrmTable : Form
    {
        ITableMaster _objTable = new ClsTable();       
        private ClsFloor _objFloor = new ClsFloor();
        ClsCommon _objCommon = new ClsCommon();
        private char _IsNew;
        public int _TableId;       
        private string _Tag = "", _SearchKey = "", result = "";
        public string _NewTable = "";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;
        public FrmTable()
        {
            InitializeComponent();
        }
      
        public void ControlEnableDisable(bool trb, bool fld)
        {
            BtnNew.Enabled = trb;
            BtnEdit.Enabled = trb;
            BtnDelete.Enabled = trb;
            BtnExit.Enabled = trb;
            BtnFirstData.Enabled = trb;
            BtnNextData.Enabled = trb;
            BtnLastData.Enabled = trb;
            BtnPreviousData.Enabled = trb;
            TxtDescription.Enabled = fld;
            BtnSearcTableDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CmbFloor.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbFloor, fld);
            CmbType.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbType, fld);
            CbActive.Enabled = fld;
            BtnSave.Enabled = fld;
            BtnCancel.Enabled = fld;

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtDescription.Enabled == true)
            {
                TxtDescription.Focus();
            }
        }
        private void ClearFld()
        {
            TxtDescription.Tag = "0";
            _TableId = 0;
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CbActive.Checked = true;
            //CmbFloor.SelectedIndex = 0;
            CmbType.SelectedIndex = 0;
        }
        private void LoadFloor()
        {
            DataTable dtFloor = _objFloor.GetDataFloor(0);
            if (dtFloor.Rows.Count > 0)
            {
                CmbFloor.Enabled = true;
                Dictionary<string, string> _CmbFloor = new Dictionary<string, string>();
                foreach (DataRow ro in dtFloor.Rows)
                {
                    _CmbFloor.Add(ro["FloorId"].ToString(), ro["Floordesc"].ToString());
                }
                CmbFloor.DataSource = new BindingSource(_CmbFloor, null);
                CmbFloor.DisplayMember = "Value";
                CmbFloor.ValueMember = "Key";
            }
        }
       
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Table Master [NEW]"; 
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Table Master [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Table Master [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcTableDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;
                DataTable dt = _objTable.GetDataTable(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TableId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnNextData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count == 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.NavMenuDataRowPosition < NavMenuDataList.Rows.Count - 1)
            {
                this.NavMenuDataRowPosition++;
                DataTable dt = _objTable.GetDataTable(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TableId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("This is the last record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnPreviousData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count == 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (NavMenuDataList.Rows.Count == 1)
            {
                MessageBox.Show("This is the frist record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.NavMenuDataRowPosition == NavMenuDataList.Rows.Count - 1 || this.NavMenuDataRowPosition != 0)
            {
                this.NavMenuDataRowPosition--;
                DataTable dt = _objTable.GetDataTable(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TableId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("This is the frist record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnLastData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count <= 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.NavMenuDataRowPosition = NavMenuDataList.Rows.Count - 1;
            DataTable dt = _objTable.GetDataTable(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TableId"].ToString()));
            SetData(dt);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TxtDescription.Text))
			{
				MessageBox.Show("Table Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtDescription.Focus();
				return;
			}
			if (string.IsNullOrEmpty(TxtShortName.Text))
			{
				MessageBox.Show("Table ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtShortName.Focus();
				return;
			}
			if (string.IsNullOrEmpty(CmbFloor.Text))
			{
				MessageBox.Show("Floor cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				CmbFloor.Focus();
				return;
			}
			_objTable.Model.Tag = _Tag;
			_objTable.Model.TableId = Convert.ToInt32(TxtDescription.Tag.ToString());
			_objTable.Model.TableDesc = TxtDescription.Text;
			_objTable.Model.TableShortName = TxtShortName.Text;
			_objTable.Model.FloorId = ((CmbFloor.Text.ToString() == "") ? 0 : Convert.ToInt32(((KeyValuePair<string, string>)CmbFloor.SelectedItem).Key));
			_objTable.Model.TableType = CmbType.Text;
			_objTable.Model.TableStatus = "A";
			_objTable.Model.EnterBy = ClsGlobal.LoginUserCode;
			_objTable.Model.Status = CbActive.Checked == true ? true : false;
			_objTable.Model.Gadget = "Desktop";
			if (_Tag == "NEW")
			{
				if (ClsGlobal.ConfirmSave == 1)
				{
					var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					if (dialogResult == DialogResult.Yes)
						result = _objTable.SaveTable();
					else
						return;
				}
				else
				{
					result = _objTable.SaveTable();
				}
			}
			else
			{
				result = _objTable.SaveTable();
			}


			if (!string.IsNullOrEmpty(result))
			{
				if (_IsNew == 'Y')
				{
					_NewTable = TxtDescription.Text.Trim();
					_TableId = Convert.ToInt32(result);
					this.Close();
				}
				else
				{
					NavMenuDataList = _objTable.GetDataTable(0);
					MessageBox.Show("Data Submit Successfully", "Mr Solution");
					ClearFld();
					TxtDescription.Focus();
				}
			}
			else
			{
				MessageBox.Show("Error Occured During Data Submit", "Mr Solution");
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
                    Text = "Table Master";
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
                Text = "Table Master";
            }
           
        }  
                       
        private void BtnDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("TableMaster", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objTable.GetDataTable(Convert.ToInt32(frmPickList.SelectedList[0]["TableId"].ToString().Trim()));
                    SetData(dt);
                }
                else
                {
                    TxtDescription.Tag = "0";
                    TxtDescription.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Table Master !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["TableId"].ToString();
            TxtDescription.Text = dt.Rows[0]["TableDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["TableShortName"].ToString();
            CmbFloor.SelectedValue = dt.Rows[0]["FloorId"].ToString();
            CmbType.Text = dt.Rows[0]["TableStatus"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();
            LoadFloor();
        }

        private void FrmTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    BtnCancel.PerformClick();
                }
                else
                {
                    BtnExit.PerformClick();
                }

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Table Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "TableMaster", "TableDesc", "TableId") == 1)
                {
                    MessageBox.Show("Table Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "TableDesc", "TableShortName", "TableMaster");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "TableMaster", "TableDesc", "TableId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Table Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

		private void CmbFloor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (_Tag == "" || this.ActiveControl == CmbFloor) return;
			if (CmbFloor.Enabled == false) return;
			if (string.IsNullOrEmpty(CmbFloor.Text) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
			{
				MessageBox.Show("Floor cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				e.Cancel = true;
				return;
			}
		}

		private void CmbFloor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				FrmFloor frm = new FrmFloor();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				LoadFloor();
				CmbFloor.Text = frm._NewFloor;
				CmbFloor.Tag = frm._FloorId;
			}
		}

		private void CmbFloor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Space)
				SendKeys.Send("{F4}");
		}

		private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Table ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "TableMaster", "TableShortName", "TableId") == 1)
                {
                    MessageBox.Show("Table ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "TableMaster", "TableDesc", "TableId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Table ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearcTableDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcTableDesc, true);
            }
        }
    }
}
