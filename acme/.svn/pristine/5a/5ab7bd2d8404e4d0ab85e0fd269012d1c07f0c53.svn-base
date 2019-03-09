using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
namespace acmedesktop.MasterSetup
{
    public partial class FrmMainSalesMan : Form
    {
        private IMainSalesman _objMainSalesman = new ClsMainSalesman();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _MainSalesmanId = 0;
        private string _Tag = "", _SearchKey = "", result = "";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0; public string _NewMainSalesMan = "";
        public FrmMainSalesMan()
        {
            InitializeComponent();
        }
        private void FrmMainSalesMan_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objMainSalesman.GetDataMainSalesman(0);
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
        private void FrmMainSalesMan_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Main Salesman [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Main Salesman [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Main Salesman [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcAccountDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objMainSalesman.GetDataMainSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["MainSalesmanId"].ToString()));
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
                DataTable dt = _objMainSalesman.GetDataMainSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["MainSalesmanId"].ToString()));
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
                DataTable dt = _objMainSalesman.GetDataMainSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["MainSalesmanId"].ToString()));
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
            DataTable dt = _objMainSalesman.GetDataMainSalesman(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["MainSalesmanId"].ToString()));
            SetData(dt);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _objMainSalesman.Model.Tag = _Tag;
            _objMainSalesman.Model.MainSalesmanId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                if (string.IsNullOrEmpty(TxtDescription.Text))
                {
                    MessageBox.Show("Main SalesMan Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtDescription.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(TxtShortName.Text))
                {
                    MessageBox.Show("Main SalesMan ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtShortName.Focus();
                    return;
                }

                ClearFld();
                return;
            }

            _objMainSalesman.Model.MainSalesmanDesc = TxtDescription.Text;
            _objMainSalesman.Model.MainSalesmanShortName = TxtShortName.Text;
            _objMainSalesman.Model.LedgerId = ((TxtLedger.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtLedger.Tag.ToString()));
            _objMainSalesman.Model.Address = TxtAddress.Text;
            _objMainSalesman.Model.PhoneNo = TxtPhoneNo.Text;
            _objMainSalesman.Model.MobileNo = TxtMobileNo.Text;
            _objMainSalesman.Model.CommissionRate = ((TxtCommissionRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtCommissionRate.Text.ToString()));
            _objMainSalesman.Model.BranchId = ClsGlobal.BranchId;
            _objMainSalesman.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;
            _objMainSalesman.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objMainSalesman.Model.Status = CbActive.Checked == true ? true : false;
            _objMainSalesman.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objMainSalesman.SaveMainSalesman();
                    else
                        return;
                }
                else
                {
                    result = _objMainSalesman.SaveMainSalesman();
                }
            }
            else
            {
                result = _objMainSalesman.SaveMainSalesman();
            }
         
            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewMainSalesMan = TxtDescription.Text.Trim();
                    _MainSalesmanId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objMainSalesman.GetDataMainSalesman(0);
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
                    Text = "Main Salesman";
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
                Text = "Main Salesman";
            }
        
        }
        private void BtnDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("MainSalesman", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objMainSalesman.GetDataMainSalesman(Convert.ToInt32(frmPickList.SelectedList[0]["MainSalesmanId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Main Salesman !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSearcAccountDesc.PerformClick();
            }           
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcAccountDesc, true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Main Salesman Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "MainSalesman", "MainSalesmanDesc", "MainSalesmanId") == 1)
                {
                    MessageBox.Show("Main Salesman Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "MainSalesmanDesc", "MainSalesmanShortName", "MainSalesman");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "MainSalesman", "MainSalesmanDesc", "MainSalesmanId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Main Salesman Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Main Salesman ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "MainSalesman", "MainSalesmanShortName", "MainSalesmanId") == 1)
                {
                    MessageBox.Show("Main Salesman ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "MainSalesman", "MainSalesmanShortName", "MainSalesmanId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Main Salesman ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["MainSalesmanId"].ToString();
            TxtDescription.Text = dt.Rows[0]["MainSalesmanDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["MainSalesmanShortName"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtLedger.Text = dt.Rows[0]["GlDesc"].ToString();
            TxtLedger.Tag = dt.Rows[0]["LedgerId"].ToString();
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            TxtCommissionRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CommissionRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtDescription.SelectAll();
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
            BtnSearcAccountDesc.Enabled = fld;
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

            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);

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
            this._MainSalesmanId = 0;
            TxtDescription.Tag = "0";
            TxtLedger.Tag = "";
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
    }
}
