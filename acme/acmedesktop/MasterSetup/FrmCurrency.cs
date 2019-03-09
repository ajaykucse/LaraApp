using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmCurrency : Form
    {
        private ClsCurrency _objCurrency = new ClsCurrency();
        private ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _CurrencyId;
        private string _Tag = "", _SearchKey = "", result = "";
        private DataTable NavMenuDataList;
        private int NavMenuDataRowPosition = 0; public string _NewCurrency = "";
        private ClsFormControl ClsForm = null;
        public FrmCurrency()
        {
            InitializeComponent();
            ClsForm = new ClsFormControl(this);
        }
        private void FrmCurrency_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objCurrency.GetDataCurrency(0);
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
        private void FrmCurrency_KeyDown(object sender, KeyEventArgs e)
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
            Text = "Currency [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Currency [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Currency [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcCurrencyDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objCurrency.GetDataCurrency(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CurrencyId"].ToString()));
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
                DataTable dt = _objCurrency.GetDataCurrency(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CurrencyId"].ToString()));
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
                DataTable dt = _objCurrency.GetDataCurrency(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CurrencyId"].ToString()));
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
            DataTable dt = _objCurrency.GetDataCurrency(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CurrencyId"].ToString()));
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
                MessageBox.Show("Currency Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Currency ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objCurrency.Model.Tag = _Tag;
            _objCurrency.Model.CurrencyId = Convert.ToInt32(TxtDescription.Tag.ToString());

            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }
            _objCurrency.Model.CurrencyDesc = TxtDescription.Text;
            _objCurrency.Model.CurrencyShortName = TxtShortName.Text;
            _objCurrency.Model.CurrencyRate = ((TxtCurrRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtCurrRate.Text.ToString()));
            _objCurrency.Model.CurrencyUnit = TxtCurrUnit.Text;
            _objCurrency.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objCurrency.Model.Status = CbActive.Checked == true ? true : false;
            _objCurrency.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    if (MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        result = _objCurrency.SaveCurrency();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = _objCurrency.SaveCurrency();
                }
            }
            else
            {
                result = _objCurrency.SaveCurrency();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewCurrency = TxtDescription.Text.Trim();
                    _CurrencyId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objCurrency.GetDataCurrency(0);
                    ClsGlobal.SaveMessage(_Tag);
                    ClearFld();

                }
            }
            else
            {
                ClsGlobal.ErrorMessage("");
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
                    Text = "Currency";
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
                Text = "Currency";
            }
        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearcCurrencyDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcCurrencyDesc, true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription)
            {
                return;
            }

            if (TxtDescription.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Currency Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Currency", "CurrencyDesc", "CurrencyId") == 1)
                {
                    MessageBox.Show("Currency Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "CurrencyDesc", "CurrencyShortName", "Currency");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Currency", "CurrencyDesc", "CurrencyId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Currency Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void BtnSearcCurrencyDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Currency", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objCurrency.GetDataCurrency(Convert.ToInt32(frmPickList.SelectedList[0]["CurrencyId"].ToString().Trim()));
                    SetData(dt);
                }
                else
                {
                    TxtDescription.Text = "";
                    TxtDescription.Tag = "0";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Currency !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtShortName)
            {
                return;
            }

            if (TxtShortName.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Currency ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Currency", "CurrencyShortName", "CurrencyId") == 1)
                {
                    MessageBox.Show("Currency ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Currency", "CurrencyShortName", "CurrencyId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Currency ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["CurrencyId"].ToString();
            TxtDescription.Text = dt.Rows[0]["CurrencyDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["CurrencyShortName"].ToString();
            TxtCurrUnit.Text = dt.Rows[0]["CurrencyUnit"].ToString();
            TxtCurrRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["CurrencyRate"].ToString()), 1, ClsGlobal._CurrencyDecimalFormat).ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
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
            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            BtnSearcCurrencyDesc.Enabled = fld;
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            TxtCurrUnit.Enabled = fld;
            Utility.EnableDesibleColor(TxtCurrUnit, fld);
            TxtCurrRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtCurrRate, fld);
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
            _CurrencyId = 0;
            TxtDescription.Tag = "0";
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
