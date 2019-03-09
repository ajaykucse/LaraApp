using DataAccessLayer.Common;
using DataAccessLayer.SystemSetting;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace acmedesktop.SystemSetting
{
    public partial class FrmCompany : Form
    {
        private ClsCompany _objCompany = new ClsCompany();
        private ClsCommon _objCommon = new ClsCommon();
        private char _IsNew;
        public int _CompanyId;
        public string _Initial;
        private string _Tag = "", _SearchKey = "";
        private string Query = "";
        public FrmCompany()
        {
            InitializeComponent();
        }
        private void FrmCompany_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClsGlobal.BindDrivePath(CmbDataDrive);
            ClsGlobal.BindDrivePath(CmbBackupDrive);
            ClearFld();
            BtnNew.Focus();
        }
        private void FrmCompany_KeyDown(object sender, KeyEventArgs e)
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

        #region --------------------------------- Button ---------------------------------
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Company Setup [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Company Setup [EDIT]";

            _Initial = ClsGlobal.Initial;
            DataTable dt = _objCompany.GetDataCompany(_Initial);
            TxtInitial.Text = dt.Rows[0]["Initial"].ToString();
            TxtInitial.Enabled = false;
            TxtName.Text = dt.Rows[0]["CompanyName"].ToString();
            TxtStartDate.Text = dt.Rows[0]["StartDate"].ToString();
            TxtEndDate.Text = dt.Rows[0]["EndDate"].ToString();
            TxtFiscalYear.Text = dt.Rows[0]["FiscalYear"].ToString();
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtDistrict.Text = dt.Rows[0]["District"].ToString();
            TxtCity.Text = dt.Rows[0]["City"].ToString();
            TxtState.Text = dt.Rows[0]["State"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtFax.Text = dt.Rows[0]["Fax"].ToString();
            TxtEmail.Text = dt.Rows[0]["Email"].ToString();
            TxtWebSite.Text = dt.Rows[0]["Website"].ToString();
            TxtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
            //CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtName.SelectAll();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Company Setup [DELETE]";
            TxtInitial.Enabled = true;
            TxtInitial.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClose == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to Close Form..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            if (TxtInitial.Text == "")
            {
                MessageBox.Show("Company Initial is not Blank..!!", "Mr. Solution");
                TxtInitial.Focus();
                return;
            }
            if (TxtName.Text == "")
            {
                MessageBox.Show("Company Name is not Blank..!!", "Mr. Solution");
                TxtName.Focus();
                return;
            }

            //_objCompany.Model.DatabaseName = "ERP" + Convert.ToString((Regex.Replace(TxtInitial.Text.Trim(), @"[^0-9a-zA-Z]+", "").Length >= 4) ? ((Regex.Replace(TxtInitial.Text.Trim(), @"[^0-9a-zA-Z]+", "")).Substring(0, 4)).ToUpper() : Regex.Replace(TxtInitial.Text.Trim().ToUpper(), @"[^0-9a-zA-Z]+", "").PadLeft(4, '0'));
            //_objCompany.Model.DatabaseName = _objCompany.Model.DatabaseName.Trim().PadRight(7, '0') + "01";
            //Query = "SELECT * FROM CompanyMaster Where Initial ='" + _objCompany.Model.DatabaseName.Substring(0, 7) + "' ";                          
            //DataTable dt = DataAccessLayer.Database.FetchingMasterData(Query);
            //if (dt.Rows.Count > 0)
            //{
            //    _objCompany.Model.DatabaseName = _objCompany.Model.DatabaseName.Substring(0, 7) + (dt.Rows.Count + 1).ToString().PadLeft(2, '0');
            //}

            _objCompany.Model.DatabaseName = "ERP" + TxtInitial.Text.Trim() + "01";
            string DrivePath = CmbDataDrive.SelectedItem.ToString() + "ERP\\";
            if (!Directory.Exists(DrivePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(DrivePath);
            }
            _objCompany.Model.DatabasePath = DrivePath;
            string BackupPath = CmbBackupDrive.SelectedItem.ToString() + "ERP\\";
            if (!Directory.Exists(BackupPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(BackupPath);
            }
            _objCompany.Model.DataBackupPath = BackupPath;

            _objCompany.Model.Tag = _Tag;
            _objCompany.Model.CompanyId = _CompanyId;
            _objCompany.Model.Initial = _Initial;
            if ((_Tag == "EDIT" || _Tag == "DELETE") && _Initial == "")
            {
                ClearFld();
                TxtInitial.Focus();
                return;
            }
            _objCompany.Model.CompanyLogo = null; //ClsGlobal.ReadFile(pb_CompanyLogo.ImageLocation);
            _objCompany.Model.Initial = TxtInitial.Text.Trim();
            _objCompany.Model.CompanyName = TxtName.Text.Trim();
            _objCompany.Model.StartDate = Convert.ToDateTime(TxtStartDate.Text);
            _objCompany.Model.EndDate = Convert.ToDateTime(TxtEndDate.Text);
            _objCompany.Model.FiscalYear = TxtFiscalYear.Text.Trim();
            _objCompany.Model.Address = TxtAddress.Text.Trim();
            _objCompany.Model.District = TxtDistrict.Text.Trim();
            _objCompany.Model.City = TxtCity.Text.Trim();
            _objCompany.Model.State = TxtState.Text.Trim();
            _objCompany.Model.Country = TxtCountry.Text.Trim();
            _objCompany.Model.PhoneNo = TxtPhoneNo.Text.Trim();
            _objCompany.Model.Fax = TxtFax.Text.Trim();
            _objCompany.Model.Email = TxtEmail.Text.Trim();
            _objCompany.Model.Website = TxtWebSite.Text.Trim();
            _objCompany.Model.PanNo = TxtPanNo.Text.Trim();
            _objCompany.Model.VersionNo = 0;
            _objCompany.Model.AltPhoneNo = "";
            _objCompany.Model.DefaultData = chkDefaultData.Checked == true ? true : false;
            _objCompany.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objCompany.Model.Status = true; //CbActive.Checked == true ? true : false;
            string result =_objCompany.SaveCompany();
            //_objCompany.RestoreDatabase();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Data Submit Successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFld();
                TxtInitial.Focus();
            }
            else
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Tag = "";
            ControlEnableDisable(true, false);
            Text = "Company";
            ClearFld();
        }
        #endregion

        #region ----------------- Event  ---------------------
        private void TxtInitial_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtInitial)
            {
                return;
            }

            TxtInitial.Text = TxtInitial.Text.ToUpper();
            if (string.IsNullOrEmpty(TxtInitial.Text.Trim()))
            {
                MessageBox.Show("Company initial cannot be left blank.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtInitial.Focus();
                return;
            }
            if (TxtInitial.Text.Length < 4)
            {
                MessageBox.Show("Company initial must be four character.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtInitial.Focus();
                return;
            }
        }
        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtName)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtName.Text.Trim()))
            {
                MessageBox.Show("Please Enter Company Name!", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtName.Focus();
                return;
            }
        }
        private void TxtStartDate_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtStartDate)
            {
                return;
            }

            if (TxtStartDate.Text.Trim() != "/  /")
            {
                int day; int month;
                day = Convert.ToInt32(Convert.ToString(TxtStartDate.Text).Substring(0, 2));
                month = Convert.ToInt32(Convert.ToString(TxtStartDate.Text).Substring(3, 2));

                if (day > 32 || day < 1)
                {
                    MessageBox.Show("Please Enter Valid Day !", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtStartDate.Focus();
                    return;
                }
                else if (month > 12 || month < 1)
                {
                    MessageBox.Show("Please Enter Valid Month !", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtStartDate.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Start date cannot be left blank.", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtStartDate.Focus();
                return;
            }
        }
        private void TxtEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtEndDate)
            {
                return;
            }

            if (TxtEndDate.Text.Trim() != "/  /")
            {
                int day; int month;
                day = Convert.ToInt32(Convert.ToString(TxtEndDate.Text).Substring(0, 2));
                month = Convert.ToInt32(Convert.ToString(TxtEndDate.Text).Substring(3, 2));

                if (day > 32 || day < 1)
                {
                    MessageBox.Show("Please Enter Valid Day !", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtEndDate.Focus();
                    return;
                }
                else if (month > 12 || month < 1)
                {
                    MessageBox.Show("Please Enter Valid Month !", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtEndDate.Focus();
                    return;
                }
                else if (Convert.ToDateTime(TxtEndDate.Text) < Convert.ToDateTime(TxtStartDate.Text))
                {
                    MessageBox.Show("End Date Cannot be less then Start Date !", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtEndDate.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Company Register Date Cannot be Left Blank!");
                TxtEndDate.Focus();
                return;
            }
            //string fyStart = TxtStartDate.Text.Substring(6, 4);
            //string fyEnd = TxtEndDate.Text.Substring(6, 4);
            //TxtFiscalYear.Text = fyStart + "." + fyEnd;

        }
        private void TxtFiscalYear_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtFiscalYear)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtFiscalYear.Text.Trim()))
            {
                MessageBox.Show("Please Enter Fiscal Year!", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFiscalYear.Focus();
                return;
            }
        }
        private void TxtWebSite_Validating(object sender, CancelEventArgs e)
        {
            if (!ClsGlobal.ValidateUrl(TxtWebSite.Text.Trim()))
            {
                if (TxtWebSite.Text != "")
                {
                    MessageBox.Show("The url address you have entered is incorrect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtWebSite.Text = "";
                    TxtWebSite.Focus();
                }
            }
        }

        //private void lbl_CompanyLogo_DoubleClick(object sender, EventArgs e)
        //{
        //    pb_CompanyLogo_DoubleClick(sender, e);
        //}
        //private void pb_CompanyLogo_DoubleClick(object sender, EventArgs e)
        //{

        //}
        #endregion

        #region ----------------- Method ------------------
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

            TxtInitial.Enabled = fld;
            Utility.EnableDesibleColor(TxtInitial, fld);
            TxtName.Enabled = fld;
            Utility.EnableDesibleColor(TxtName, fld);
            TxtFiscalYear.Enabled = fld;
            Utility.EnableDesibleColor(TxtFiscalYear, fld);
            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);
            TxtDistrict.Enabled = fld;
            Utility.EnableDesibleColor(TxtDistrict, fld);
            TxtCity.Enabled = fld;
            Utility.EnableDesibleColor(TxtCity, fld);
            TxtState.Enabled = fld;
            Utility.EnableDesibleColor(TxtState, fld);
            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);
            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);
            TxtFax.Enabled = fld;
            Utility.EnableDesibleColor(TxtFax, fld);
            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);
            TxtWebSite.Enabled = fld;
            Utility.EnableDesibleColor(TxtWebSite, fld);
            TxtPanNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPanNo, fld);

            TxtStartDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtStartDate, fld);
            TxtEndDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtEndDate, fld);

            CmbDataDrive.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbDataDrive, fld);
            CmbBackupDrive.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbBackupDrive, fld);
            //CbActive.Enabled = fld;
            BtnSave.Enabled = fld;
            BtnCancel.Enabled = fld;

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtInitial.Enabled == true)
            {
                TxtInitial.Focus();
            }
        }

        private void CmbDataDrive_Validating(object sender, CancelEventArgs e)
        {

        }

        private void CmbBackupDrive_Validating(object sender, CancelEventArgs e)
        {

        }

        private void ClearFld()
        {
            _CompanyId = 0;
            _Initial = "";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }

            CmbDataDrive.SelectedIndex = 0;
            CmbBackupDrive.SelectedIndex = 0;
            TxtStartDate.Text = DateTime.Now.ToString();
            TxtEndDate.Text = DateTime.Now.AddDays(365).ToString();
            chkDefaultData.Checked = true;
            TxtInitial.Focus();
        }
        #endregion

    }
}
