using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmMembership : Form
    {
        private ISalesman _objSalesman = new ClsSalesman();
        private ClsCommon _objCommon = new ClsCommon();
        private ClsDateMiti _objDate = new ClsDateMiti();
        public char _IsNew;
        public int _SalesmanId;
        private string _Tag = "", _SearchKey = "", result = "";
        private DataTable NavMenuDataList;
        private int NavMenuDataRowPosition = 0; public string _NewSubSalesman = "";
        private DateTime Fromdate;
        private DateTime Todate;
        public FrmMembership()
        {
            InitializeComponent();
        }

        private void FrmMembership_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objSalesman.GetDataMember(0);
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
            LoadMemberType();

        }
        private void LoadMemberType()
        {
            DataTable dtMemberType = _objSalesman.GetDataMemberType(0);
            if (dtMemberType.Rows.Count > 0)
            {
                CmbMemberType.Enabled = true;
                Dictionary<string, string> _CmbMemberType = new Dictionary<string, string>();
                foreach (DataRow ro in dtMemberType.Rows)
                {
                    _CmbMemberType.Add(ro["MemberTypeId"].ToString(), ro["MemberTypeDesc"].ToString());
                }
                CmbMemberType.DataSource = new BindingSource(_CmbMemberType, null);
                CmbMemberType.DisplayMember = "Value";
                CmbMemberType.ValueMember = "Key";
            }
        }
        private void FrmMembership_KeyDown(object sender, KeyEventArgs e)
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

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }

            TxtDescription.Enabled = fld;
            BtnSalesmanDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CbActive.Enabled = fld;

            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);

            TxtMobileNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtMobileNo, fld);

            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);

            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);

            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);

            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);

            CmbMemberType.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbMemberType, fld);
            TxtMembershipId.Enabled = fld;
            Utility.EnableDesibleColor(TxtMembershipId, fld);

            TxtFromDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtFromDate, fld);
            TxtFromMiti.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtFromMiti, fld);
            TxtToDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtToDate, fld);
            TxtToMiti.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtToMiti, fld);

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
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
			_SalesmanId = 0;
			TxtDescription.Tag = "0";
			TxtFromDate.Text = DateTime.Now.ToString();
            TxtFromMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtFromDate.Text));
            TxtToDate.Text = DateTime.Now.AddDays(365).ToString();
            TxtToMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtToDate.Text));
            CbActive.Checked = true;
            TxtDescription.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Membership [NEW]";
            if (ClsGlobal.DateType == "M")
            {
                TxtFromMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtFromDate.Text = _objDate.GetServerDate().ToShortDateString();
                Fromdate = Convert.ToDateTime(TxtFromDate.Text.ToString());
                Todate = Fromdate.AddYears(1);
                TxtToDate.Text = Todate.ToString();
                TxtToMiti.Text = _objDate.GetMiti(Todate);

            }
            else
            {
                TxtFromDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtFromMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtFromDate.Text));
                Fromdate = Convert.ToDateTime(TxtFromDate.Text);
                Todate = Fromdate.AddYears(1);
                TxtToDate.Text = Todate.ToString();
                TxtToMiti.Text = _objDate.GetMiti(Todate);
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Membership [EDIT]";
            if (!string.IsNullOrEmpty(TxtMembershipId.Text))
            {
                TxtMembershipId.Enabled = false;
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Membership [DELETE]";
            TxtDescription.Enabled = true;
            BtnSalesmanDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objSalesman.GetDataMember(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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

            if (NavMenuDataRowPosition < NavMenuDataList.Rows.Count - 1)
            {
                NavMenuDataRowPosition++;
                DataTable dt = _objSalesman.GetDataMember(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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

            if (NavMenuDataRowPosition == NavMenuDataList.Rows.Count - 1 || NavMenuDataRowPosition != 0)
            {
                NavMenuDataRowPosition--;
                DataTable dt = _objSalesman.GetDataMember(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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
            NavMenuDataRowPosition = NavMenuDataList.Rows.Count - 1;
            DataTable dt = _objSalesman.GetDataMember(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
            SetData(dt);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Membership Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()))
            {
                MessageBox.Show("Membership ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objSalesman.Model.Tag = _Tag;
            _objSalesman.Model.SalesmanId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                return;
            }
            _objSalesman.Model.SalesmanDesc = TxtDescription.Text;
            _objSalesman.Model.SalesmanShortName = TxtShortName.Text;
            _objSalesman.Model.Address = TxtAddress.Text;
            _objSalesman.Model.PhoneNo = TxtPhoneNo.Text;
            _objSalesman.Model.MobileNo = TxtMobileNo.Text;
            _objSalesman.Model.EmailId = TxtEmail.Text;
            _objSalesman.Model.Fax = "";
            _objSalesman.Model.Country = TxtCountry.Text;
            _objSalesman.Model.CommissionRate = 0;
            _objSalesman.Model.CreditLimit = 0;
            _objSalesman.Model.CreditDays = 0;
            _objSalesman.Model.BranchId = ClsGlobal.BranchId;
            _objSalesman.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;
            _objSalesman.Model.MemberTypeId = ((CmbMemberType.Text.ToString() == "") ? 0 : Convert.ToInt32(((KeyValuePair<string, string>)CmbMemberType.SelectedItem).Key));
            _objSalesman.Model.MemberFromDate = Convert.ToDateTime(TxtFromDate.Text.ToString());
            _objSalesman.Model.MemberToDate = Convert.ToDateTime(TxtToDate.Text.ToString());
            _objSalesman.Model.MembershipId = TxtMembershipId.Text.ToString();
            _objSalesman.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objSalesman.Model.Status = CbActive.Checked == true ? true : false;
            _objSalesman.Model.Gadget = "Desktop";
            _objSalesman.Model.CustomerType = "Normal";
            _objSalesman.Model.SalesmanType = "Member";
            _objSalesman.Model.GLShortName = _objCommon.GenerateShortName(TxtDescription.Text, "GlDesc", "GlShortName", "GeneralLedger");
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objSalesman.SaveSalesman();
                    else
                        return;
                }
                else
                {
                    result = _objSalesman.SaveSalesman();
                }
            }
            else
            {
                result = _objSalesman.SaveSalesman();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewSubSalesman = TxtDescription.Text.Trim();
                    _SalesmanId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objSalesman.GetDataSalesman(0);
                    ClearFld();
                }
                _objSalesman.Model.GSalesmanId = Convert.ToInt32(result);

                if (_Tag == "NEW")
                {
                    string Res = _objSalesman.SaveLedger();
                    if (string.IsNullOrEmpty(Res))
                    {
                        _objSalesman.Model.Tag = "DELETE";
                        _objSalesman.Model.SalesmanId = Convert.ToInt32(result);
                        _objSalesman.SaveSalesman();
                        MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                    Text = "Membership";
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
                Text = "Membership";
            }
        }

        private void BtnDescription_Click(object sender, EventArgs e)
        {
            ClsGlobal.SalesmanType = "Member";
            Common.PickList frmPickList = new Common.PickList("SalesMan", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objSalesman.GetDataMember(Convert.ToInt32(frmPickList.SelectedList[0]["SalesmanId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Membership !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSalesmanDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSalesmanDesc, true);
            }
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Membership Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Salesman", "SalesmanDesc", "SalesmanId") == 1)
                {
                    MessageBox.Show("Membership Name Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text, "SalesmanDesc", "SalesmanShortName", "Salesman");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Salesman", "SalesmanDesc", "SalesmanId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Membership Name Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void TxtFromMiti_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtFromMiti) return;
            ClsGlobal.MitiValidation(TxtFromMiti, TxtFromDate);
        }

        private void TxtFromDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtFromDate) return;
            ClsGlobal.DateValidation(TxtFromDate, TxtFromMiti);
        }

        private void TxtToDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtToDate)
            {
                return;
            }

            if (TxtToDate.Text != "  /  /")
            {
                TxtToMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtToDate.Text));
            }
            else
            {
                MessageBox.Show("Please enter valid date.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtToDate.Focus();
            }           
        }

        private void TxtToMiti_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtToMiti)
            {
                return;
            }

            if (TxtToMiti.Text != "  /  /")
            {
                DateTime dt = Convert.ToDateTime(_objDate.GetDate(TxtToMiti.Text).Value.ToString());
                TxtToDate.Text = dt.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Please enter valid miti.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtToMiti.Focus();
            }
        }

		private void CmbMemberType_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Space)
				SendKeys.Send("{F4}");
		}

		private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Membership ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Salesman", "SalesmanShortName", "SalesmanId") == 1)
                {
                    MessageBox.Show("Membership ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Salesman", "SalesmanShortName", "SalesmanId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Membership ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["SalesmanId"].ToString();
            TxtDescription.Text = dt.Rows[0]["SalesmanDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["SalesmanShortName"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtEmail.Text = dt.Rows[0]["EmailId"].ToString();
            CmbMemberType.SelectedValue = dt.Rows[0]["MemberTypeId"].ToString();
            TxtMembershipId.Text = dt.Rows[0]["MembershipId"].ToString();
            TxtFromDate.Text = dt.Rows[0]["MemberFromDate"].ToString();
            TxtToDate.Text = dt.Rows[0]["MemberToDate"].ToString();
            TxtDescription.SelectAll();
        }
    }
}
