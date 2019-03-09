using DataAccessLayer.Common;
using acmedesktop.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.SystemSetting
{
    public partial class FrmUserMaster : Form
    {
        ClsUserMaster _objUserMaster = new ClsUserMaster();       
        public string _UserId; 
        string _Tag = "", _SearchKey = "", result ="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;
        public FrmUserMaster()
        {
            InitializeComponent();
        }
        private void FrmUserMaster_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objUserMaster.GetDataUser("");
            ControlEnableDisable(true, false);
            ClearFld();
            TxtStartDate.Text = Convert.ToDateTime(ClsGlobal.CompanyStartDate).ToString("dd/MM/yyyy");
            TxtEndDate.Text = Convert.ToDateTime(ClsGlobal.CompanyEndDate).ToString("dd/MM/yyyy");
        }
        private void FrmUserMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
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
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            this.Text = "User Master [NEW]";           
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "User Master [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "User Master [DELETE]";
            TxtUserCode.Enabled = true;
            BtnSearchUser.Enabled = true;
            TxtUserCode.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
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
            
            BtnSearchUser.Enabled = fld;
            TxtUserCode.Enabled = fld;
            Utility.EnableDesibleColor(TxtUserCode, fld);
            TxtUserName.Enabled = fld;
            Utility.EnableDesibleColor(TxtUserName, fld);
            TxtMobileNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtMobileNo, fld);
            TxtEmailId.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmailId, fld);
            TxtStartDate.Enabled = fld;
          //  Utility.EnableDesibleColor(TxtStartDate, fld);
            TxtEndDate.Enabled = fld;
            //Utility.EnableDesibleColor(TxtEndDate, fld);
            TxtUserPassword.Enabled = fld;
            Utility.EnableDesibleColor(TxtUserPassword, fld);
            TxtConUserPassword.Enabled = fld;
            Utility.EnableDesibleColor(TxtConUserPassword, fld);
            TxtLedger.Enabled = fld;
            BtnSearchLedger.Enabled = fld;
            Utility.EnableDesibleColor(TxtLedger, fld);

            CmbUserType.Enabled = fld;

            //  CbActive.Enabled = fld;
            BtnSave.Enabled = fld;
            BtnCancel.Enabled = fld;

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtUserCode.Enabled == true)
            {
                TxtUserCode.Focus();
            }
        }       
        private void BtnSearchUser_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("UaserMaster", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    this._UserId =frmPickList.SelectedList[0]["UserCode"].ToString().Trim();
                    DataTable dt = _objUserMaster.GetDataUser(this._UserId);
                    SetData(dt);
                }
                else
                {
                    TxtUserCode.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in User Master !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUserCode.Focus();
                return;
            }
            TxtUserCode.Focus();
        }
        private void SetData(DataTable dt)
        {
            TxtUserCode.Text = dt.Rows[0]["UserCode"].ToString();
            TxtUserName.Text = dt.Rows[0]["UserName"].ToString();
            TxtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            TxtEmailId.Text = dt.Rows[0]["EmailId"].ToString();
            TxtStartDate.Text = dt.Rows[0]["StartDate"].ToString();
            TxtEndDate.Text = dt.Rows[0]["EndDate"].ToString();
            TxtUserPassword.Text = dt.Rows[0]["UserPassword"].ToString();
            TxtConUserPassword.Text = dt.Rows[0]["UserPassword"].ToString();
            TxtLedger.Text = dt.Rows[0]["GlDesc"].ToString();
            TxtLedger.Tag = ((dt.Rows[0]["LedgerId"].ToString() == "") ? 0 : Convert.ToInt32(dt.Rows[0]["LedgerId"].ToString()));
            CmbUserType.Text= dt.Rows[0]["UserType"].ToString();
            TxtUserCode.SelectAll();
        }
        private void TxtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearchUser.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtUserCode, BtnSearchUser, true);
            }
        }
        private void TxtUserCode_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtUserCode) return;
            if (TxtUserCode.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtUserCode.Text))
            {
                MessageBox.Show("User Code Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtUserCode.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objUserMaster.CheckDuplicateUserCode(TxtUserCode.Text) == 1)
                {
                    MessageBox.Show("User Code No Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtUserCode.Focus();
                    return;
                }
            }           
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _objUserMaster.Model.Tag = _Tag;        
            _objUserMaster.Model.UserCode = this._UserId;
            if ((_Tag == "EDIT" || _Tag == "DELETE") && _UserId =="")
            {
                ClearFld();
                return;
            }
            _objUserMaster.Model.UserCode = TxtUserCode.Text;
            _objUserMaster.Model.UserName = TxtUserName.Text;
            _objUserMaster.Model.MobileNo = TxtMobileNo.Text;
            _objUserMaster.Model.EmailId = TxtEmailId.Text;
            _objUserMaster.Model.UserPassword = TxtUserPassword.Text;
            if (TxtStartDate.Text == "  /  /")
                _objUserMaster.Model.StartDate = DateTime.Now;
            else
            _objUserMaster.Model.StartDate =Convert.ToDateTime (TxtStartDate.Text);
            if (TxtStartDate.Text == "  /  /")
                _objUserMaster.Model.EndDate = DateTime.Now;
            else
            _objUserMaster.Model.EndDate = Convert.ToDateTime(TxtEndDate.Text);

            _objUserMaster.Model.CreateBy = ClsGlobal.LoginUserCode;
            _objUserMaster.Model.CreateDate = Convert.ToDateTime(DateTime.Now);
            _objUserMaster.Model.LedgerId = ((TxtLedger.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtLedger.Tag.ToString()));
            _objUserMaster.Model.UserType = CmbUserType.Text;
            _objUserMaster.Model.CompanyIniTial = ClsGlobal.Initial;
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = _objUserMaster.SaveUserMaster();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = _objUserMaster.SaveUserMaster();
                }
            }
            else
            {
                result = _objUserMaster.SaveUserMaster();
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
            _Tag = "";
            ControlEnableDisable(true, false);
            Text = "User Master";
            ClearFld();
        }
        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtUserName) return;
            if (string.IsNullOrEmpty(TxtUserName.Text))
            {
                MessageBox.Show("User Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtUserName.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objUserMaster.CheckDuplicateUserName(TxtUserName.Text) == 1)
                {
                    MessageBox.Show("User Name No Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtUserName.Focus();
                    return;
                }
            }
        }
        private void TxtMobileNo_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtMobileNo) return;
            if (string.IsNullOrEmpty(TxtMobileNo.Text))
            {
                MessageBox.Show("Mobile No Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtMobileNo.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objUserMaster.CheckDuplicateMobileNo(TxtMobileNo.Text) == 1)
                {
                    MessageBox.Show("Mobile No Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtMobileNo.Focus();
                    return;
                }
                if (TxtMobileNo.TextLength != 10)
                {
                    MessageBox.Show("Mobile No Must be ten character...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtMobileNo.Focus();
                    return;
                }
            }
        }
        private void TxtEmailId_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtEmailId) return;
            if (string.IsNullOrEmpty(TxtEmailId.Text))
            {
                MessageBox.Show("Email Id Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtEmailId.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objUserMaster.CheckDuplicateEmail(TxtEmailId.Text) == 1)
                {
                    MessageBox.Show("Email Id Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtEmailId.Focus();
                    return;
                }
                else
                {
                    string email = TxtEmailId.Text;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);
                    if (!match.Success)
                    {
                        MessageBox.Show(email + " is incorrect...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        TxtEmailId.Focus();
                        return;
                    }
                }
            }           
        }
        private void TxtConUserPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtUserPassword) return;
            if (TxtUserPassword.Text!=TxtConUserPassword.Text)
            {
                MessageBox.Show("Confirm Password Not Match With Password...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtConUserPassword.Focus();
                return;
            }
        }
        private void BtnSearchLedger_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtLedger.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtLedger.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtLedger.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in User Master !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtLedger.Focus();
                return;
            }
            TxtLedger.Focus();
        }
        private void TxtLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtLedger.Text = frm._NewLedger;
                TxtLedger.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtLedger, BtnSearchLedger, false);
            }
        }
        private void TxtUserPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtUserPassword) return;
            if (string.IsNullOrEmpty(TxtUserPassword.Text))
            {
                MessageBox.Show("Password Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtUserPassword.Focus();
                return;
            }
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;
                this._UserId =NavMenuDataList.Rows[NavMenuDataRowPosition]["UserCode"].ToString();
                DataTable dt = _objUserMaster.GetDataUser(this._UserId);
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
                this._UserId = NavMenuDataList.Rows[NavMenuDataRowPosition]["UserCode"].ToString();
                DataTable dt = _objUserMaster.GetDataUser(this._UserId);
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
                this._UserId = NavMenuDataList.Rows[NavMenuDataRowPosition]["UserCode"].ToString();
                DataTable dt = _objUserMaster.GetDataUser(this._UserId);
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
            this._UserId = NavMenuDataList.Rows[NavMenuDataRowPosition]["UserCode"].ToString();
            DataTable dt = _objUserMaster.GetDataUser(this._UserId);
            SetData(dt);
        }
        private void ClearFld()
        {
            _UserId = "";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CmbUserType.SelectedIndex = 0;
            TxtUserCode.Focus();
        }
    }
}
