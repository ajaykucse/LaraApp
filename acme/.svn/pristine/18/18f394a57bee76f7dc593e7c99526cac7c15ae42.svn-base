using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using DataAccessLayer.SystemSetting;

namespace acmedesktop.SystemSetting
{
    public partial class FrmBranch : Form
    {

        private ClsBranch _objBranch = new ClsBranch();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _BranchId;
        private string _Tag = "", _SearchKey = "", result ="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;
        public string _NewBranch = "";
        public FrmBranch()
        {
            InitializeComponent();
        }
        private void FrmBranch_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objBranch.GetDataBranch(0);
            ControlEnableDisable(true, false);
            ClearFld();
            if (_IsNew == 'Y')
            {
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnFirstData.Enabled = false;
                BtnNextData.Enabled = false;
                BtnPreviousData.Enabled = false;
                BtnLastData.Enabled = false;
            }
            BtnNew.Focus();
        }
        private void FrmBranch_KeyDown(object sender, KeyEventArgs e)
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
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);

            TxtCity.Enabled = fld;
            Utility.EnableDesibleColor(TxtCity, fld);

            TxtContactPerson .Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPerson, fld);

            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);

            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);
            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);
            TxtFax.Enabled = fld;
            Utility.EnableDesibleColor(TxtFax, fld);
            TxtContactPersonMobileNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPersonMobileNo, fld);
            TxtContactPersonPhoneNo .Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPersonPhoneNo, fld);
            TxtContactPerson.Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPerson, fld);
            TxtContactPersonAdd .Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPersonAdd, fld);

            TxtState.Enabled = fld;
            Utility.EnableDesibleColor(TxtState, fld);
            TxtCity .Enabled = fld;
            Utility.EnableDesibleColor(TxtCity, fld);

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
            this._BranchId = 0;
            TxtDescription.Tag = "0";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            TxtDescription.Focus();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Branch [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Branch [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Branch [DELETE]";
            TxtDescription.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;
                DataTable dt = _objBranch.GetDataBranch(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["BranchId"].ToString()));
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
                DataTable dt = _objBranch.GetDataBranch(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["BranchId"].ToString()));
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
                DataTable dt = _objBranch.GetDataBranch(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["BranchId"].ToString()));
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
            DataTable dt = _objBranch.GetDataBranch(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["BranchId"].ToString()));
            SetData(dt);
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _objBranch.Model.Tag = _Tag;
            _objBranch.Model.BranchId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                return;
            }
            _objBranch.Model.BranchName = TxtDescription.Text;
            _objBranch.Model.BranchShortName = TxtShortName.Text;
            _objBranch.Model.Address = TxtAddress.Text;
            _objBranch.Model.PhoneNo = TxtPhoneNo.Text;
            _objBranch.Model.ContactPersonMobileNo = TxtContactPersonMobileNo.Text;
            _objBranch.Model.ContactPerson  = TxtContactPerson.Text ;
            _objBranch.Model.ContactPersonPhone  =TxtContactPersonPhoneNo.Text;
            _objBranch.Model.ContactPersonAdd  = TxtContactPersonAdd.Text;
            _objBranch.Model.Country  = TxtCountry.Text ;
            _objBranch.Model.City  = TxtCity.Text;
            _objBranch.Model.Email  = TxtEmail.Text;
            _objBranch.Model.PhoneNo  = TxtPhoneNo.Text;
            _objBranch.Model.Fax = TxtFax.Text;
            _objBranch.Model.State = TxtState.Text;
            _objBranch.Model.EnterBy = ClsGlobal.LoginUserCode;
			_objBranch.Model.Gadget = "Desktop";


			if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objBranch.SaveBranch();
                    else
                        return;
                }
                else
                {
                    result = _objBranch.SaveBranch();
                }
            }
            else
            {
                result = _objBranch.SaveBranch();
            }
          
            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewBranch = TxtDescription.Text.Trim();
                    _BranchId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objBranch.GetDataBranch(0);
                    MessageBox.Show("Data Submit Successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFld();
                    TxtDescription.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Tag = "";
            ControlEnableDisable(true, false);
            Text = "Branch";
            ClearFld();
        }
        private void BtnDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Branch", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objBranch.GetDataBranch(Convert.ToInt32(frmPickList.SelectedList[0]["BranchId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Branch !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            _SearchKey = "";
            TxtDescription.Focus();
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["BranchId"].ToString();
            TxtDescription.Text = dt.Rows[0]["BranchName"].ToString();
            TxtShortName.Text = dt.Rows[0]["BranchShortName"].ToString();
            TxtCity.Text = dt.Rows[0]["City"].ToString();
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtFax.Text = dt.Rows[0]["Fax"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtEmail.Text = dt.Rows[0]["Email"].ToString();
            TxtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            TxtContactPersonAdd.Text = dt.Rows[0]["ContactPersonAdd"].ToString();
            TxtContactPersonMobileNo.Text = dt.Rows[0]["ContactPersonMobileNo"].ToString();
            TxtContactPersonPhoneNo.Text = dt.Rows[0]["ContactPersonPhone"].ToString();
            TxtState.Text = dt.Rows[0]["State"].ToString();
            TxtDescription.SelectAll();
        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchDescription.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchDescription, true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Branch Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Branch", "BranchName", "BranchId") == 1)
                {
                    MessageBox.Show("Branch Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "BranchName", "BranchShortName", "Branch");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Branch", "BranchName", "BranchId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Branch Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Branch ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Branch", "BranchShortName", "BranchId") == 1)
                {
                    MessageBox.Show("Branch ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Branch", "BranchShortName", "BranchId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Branch ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
