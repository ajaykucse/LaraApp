using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
namespace acmedesktop.MasterSetup
{
    public partial class FrmSalesMan : Form
    {
        ISalesman _objSalesman = new ClsSalesman();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _SalesmanId;
        private string _Tag = "", _SearchKey = "", result = "";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0; public string _NewSubSalesMan = "";

        public FrmSalesMan()
        {
            InitializeComponent();
        }
       
        private void FrmSubSalesMan_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objSalesman.GetDataSalesman(0);
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
        }
        private void FrmSubSalesMan_KeyDown(object sender, KeyEventArgs e)
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
            BtnSubSalesManDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CbActive.Enabled = fld;
            TxtCommissionRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtCommissionRate, fld);
            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);

            TxtMobileNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtMobileNo, fld);
            TxtLedger.Enabled = fld;
            BtnLedgerSearch.Enabled = fld;
            Utility.EnableDesibleColor(TxtLedger, fld);

            TxtMainSalesMan.Enabled = fld;
            BtnMainSalesManSearch.Enabled = fld;
            Utility.EnableDesibleColor(TxtMainSalesMan, fld);

            TxtFax.Enabled = fld;
            Utility.EnableDesibleColor(TxtFax, fld);

            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);

            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);

            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);

            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);

            TxtCreditLimit.Enabled = fld;
            Utility.EnableDesibleColor(TxtCreditLimit, fld);

            TxtCreditDays.Enabled = fld;
            Utility.EnableDesibleColor(TxtCreditDays, fld);

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
            this._SalesmanId = 0;
            TxtDescription.Tag = "0";
            TxtLedger.Tag = "0";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CbActive.Checked = true;
            TxtDescription.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Sub Salesman [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Sub Salesman [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Sub Salesman [DELETE]";
            TxtDescription.Enabled = true;
            BtnSubSalesManDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {

            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objSalesman.GetDataSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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
                DataTable dt = _objSalesman.GetDataSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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
                DataTable dt = _objSalesman.GetDataSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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
            DataTable dt = _objSalesman.GetDataSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SalesmanId"].ToString()));
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
                MessageBox.Show("SalesMan Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("SalesMan ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            _objSalesman.Model.LedgerId = ((TxtLedger.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtLedger.Tag.ToString()));
            _objSalesman.Model.MainSalesmanId = ((TxtMainSalesMan.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtMainSalesMan.Tag.ToString()));
            _objSalesman.Model.Address = TxtAddress.Text;
            _objSalesman.Model.PhoneNo = TxtPhoneNo.Text;
            _objSalesman.Model.MobileNo = TxtMobileNo.Text;
            _objSalesman.Model.EmailId = TxtEmail.Text;
            _objSalesman.Model.Fax = TxtFax.Text;
            _objSalesman.Model.Country = TxtCountry.Text;
            _objSalesman.Model.CommissionRate = ((TxtCommissionRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtCommissionRate.Text.ToString()));
            _objSalesman.Model.CreditLimit = ((TxtCreditLimit.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtCreditLimit.Text.ToString()));
            _objSalesman.Model.CreditDays =Convert.ToInt32 ((TxtCreditDays.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtCreditDays.Text.ToString()));
            _objSalesman.Model.BranchId = ClsGlobal.BranchId;
            _objSalesman.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;
            _objSalesman.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objSalesman.Model.Status = CbActive.Checked == true ? true : false;
            _objSalesman.Model.Gadget = "Desktop";
            _objSalesman.Model.SalesmanType = "";
            _objSalesman.Model.MembershipId = "";
            _objSalesman.Model.MemberFromDate = null;
            _objSalesman.Model.MemberToDate = null;
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                    _NewSubSalesMan = TxtDescription.Text.Trim();
                    _SalesmanId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objSalesman.GetDataSalesman(0);
                    MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (ClsGlobal.ConfirmFormClear == 1)
            {
                DialogResult dialog = ClsGlobal.ConfirmFormClearing();
                if (dialog == DialogResult.Yes)
                {
                    _Tag = "";
                    ControlEnableDisable(true, false);
                    ClearFld();
                    Text = "Sub Salesman";
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
                Text = "Sub Salesman";
            }
        }
       

        private void BtnDescription_Click(object sender, EventArgs e)
        {
            ClsGlobal.SalesmanType = "";
            Common.PickList frmPickList = new Common.PickList("SalesMan", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objSalesman.GetDataSalesman(Convert.ToInt32(frmPickList.SelectedList[0]["SalesmanId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in SalesMan !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSubSalesManDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSubSalesManDesc, true);
            }
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("SalesMan Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "SalesMan", "SalesManDesc", "SalesmanId") == 1)
                {
                    MessageBox.Show("SalesMan Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "SalesManDesc", "SalesManShortName", "SalesMan");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "SalesMan", "SalesManDesc", "SalesmanId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("SalesMan Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BtnLedgerSearch_Click(object sender, EventArgs e)
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
                MessageBox.Show("No List Available in SalesMan !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtLedger, BtnLedgerSearch, false);
            }
        }

        private void BtnMainSalesManSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("MainSalesman", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 )
                {
                    TxtMainSalesMan.Tag  = Convert.ToInt32(frmPickList.SelectedList[0]["MainSalesmanId"].ToString().Trim());
                    TxtMainSalesMan.Text = frmPickList.SelectedList[0]["MainSalesManDesc"].ToString().Trim();
                    TxtMainSalesMan.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in MainSalesMan !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMainSalesMan.Focus();
                return;
            }
            TxtMainSalesMan.Focus();
        }

        private void TxtMainSalesMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {               
                FrmMainSalesMan frm = new FrmMainSalesMan();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtMainSalesMan.Text = frm._NewMainSalesMan;
                TxtMainSalesMan.Tag = frm._MainSalesmanId;               
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtLedger, BtnMainSalesManSearch, false);
            }
        }

        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("SalesMan ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "SalesMan", "SalesManShortName", "SalesmanId") == 1)
                {
                    MessageBox.Show("SalesMan ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "SalesMan", "SalesManShortName", "SalesmanId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("SalesMan ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["SalesmanId"].ToString();
            TxtDescription.Text = dt.Rows[0]["SalesManDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["SalesManShortName"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtLedger.Text = dt.Rows[0]["GlDesc"].ToString();
            TxtLedger.Tag = dt.Rows[0]["LedgerId"].ToString();
            TxtMainSalesMan.Text = dt.Rows[0]["MainSalesManDesc"].ToString();
            TxtMainSalesMan.Tag = dt.Rows[0]["MainSalesmanId"].ToString();
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            TxtFax.Text = dt.Rows[0]["Fax"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtEmail.Text = dt.Rows[0]["EmailId"].ToString();
            TxtCreditLimit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CreditLimit"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtCreditDays.Text = Convert.ToInt32(dt.Rows[0]["CreditDays"].ToString()).ToString();
            TxtCommissionRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CommissionRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtDescription.SelectAll();
        }

    }
}
