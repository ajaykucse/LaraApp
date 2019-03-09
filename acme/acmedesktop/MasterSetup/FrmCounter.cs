using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmCounter : Form
    {
        private ICounter _objCounter = new ClsCounter();
        private ClsCommon _objCommon = new ClsCommon();
        private PrintDocument _objPrintDocument = new PrintDocument();
        public char _IsNew;
        public int _CounterId;
        private string _Tag = "", _SearchKey = "", result = "";
        private DataTable NavMenuDataList;
        private int NavMenuDataRowPosition = 0;
        public string _NewCounter = "";
        public FrmCounter()
        {
            InitializeComponent();
        }
        private void FrmCounter_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objCounter.GetDataCounter(0);

            EnableDisable(true, false);
            ClearFld();
            ClsGlobal.BindPrinter(CmbPrinterName);
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
        private void FrmCounter_KeyDown(object sender, KeyEventArgs e)
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

        public void EnableDisable(bool trb, bool fld)
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
            BtnSearchCounterDesc.Enabled = fld;
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            TxtGodown.Enabled = fld;
            Utility.EnableDesibleColor(TxtGodown, fld);
            CmbPrinterName.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbPrinterName, fld);
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
            _CounterId = 0;
            TxtDescription.Tag = "0";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CbActive.Checked = true;
            string strDefaultPrinter = _objPrintDocument.PrinterSettings.PrinterName;
            CmbPrinterName.SelectedIndex = CmbPrinterName.FindString(strDefaultPrinter);
            TxtDescription.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            EnableDisable(false, true);
            Text = "Counter [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            EnableDisable(false, true);
            Text = "Counter [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            EnableDisable(false, false);
            Text = "Counter [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchCounterDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objCounter.GetDataCounter(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CounterId"].ToString()));
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
                DataTable dt = _objCounter.GetDataCounter(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CounterId"].ToString()));
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
                DataTable dt = _objCounter.GetDataCounter(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CounterId"].ToString()));
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
            DataTable dt = _objCounter.GetDataCounter(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["CounterId"].ToString()));
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
                MessageBox.Show("Counter Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Counter ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objCounter.Model.Tag = _Tag;
            _objCounter.Model.CounterId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                return;
            }
            _objCounter.Model.CounterDesc = TxtDescription.Text;
            _objCounter.Model.CounterShortName = TxtShortName.Text;
            _objCounter.Model.PrinterName = CmbPrinterName.Text;
            _objCounter.Model.GodownId = ((TxtGodown.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtGodown.Tag.ToString()));
            _objCounter.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objCounter.Model.Status = CbActive.Checked == true ? true : false;
            _objCounter.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    if (MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        result = _objCounter.SaveCounter();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = _objCounter.SaveCounter();
                }
            }
            else
            {
                result = _objCounter.SaveCounter();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewCounter = TxtDescription.Text.Trim();
                    _CounterId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objCounter.GetDataCounter(0);
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
                    EnableDisable(true, false);
                    ClearFld();
                    Text = "Counter Setup";
                }
                else
                {
                    return;
                }
            }
            else if (ClsGlobal.ConfirmFormClear == 0)
            {
                _Tag = "";
                EnableDisable(true, false);
                ClearFld();
                Text = "Counter Setup";
            }
        }

        private void BtnDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Counter", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objCounter.GetDataCounter(Convert.ToInt32(frmPickList.SelectedList[0]["CounterId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Counter !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSearchCounterDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchCounterDesc, true);
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
                MessageBox.Show("Counter Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Counter", "CounterDesc", "CounterId") == 1)
                {
                    MessageBox.Show("Counter Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "CounterDesc", "CounterShortName", "Counter");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Counter", "CounterDesc", "CounterId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Counter Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
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
                MessageBox.Show("Counter ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Counter", "CounterShortName", "CounterId") == 1)
                {
                    MessageBox.Show("Counter ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Counter", "CounterShortName", "CounterId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Counter ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BtnSearchGodown_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Godown", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtGodown.Text = frmPickList.SelectedList[0]["GodownDesc"].ToString().Trim();
                    TxtGodown.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["GodownId"].ToString().Trim());
                    TxtGodown.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Godown !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGodown.Focus();
                return;
            }
            TxtGodown.Focus();
        }

        private void TxtGodown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGodown frm = new FrmGodown
                {
                    _IsNew = 'Y'
                };
                frm.ShowDialog();
                TxtGodown.Text = frm._NewGodown;
                TxtGodown.Tag = frm._GodownId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtGodown, BtnSearchGodown, false);
            }
        }

        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["CounterId"].ToString();
            TxtDescription.Text = dt.Rows[0]["CounterDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["CounterShortName"].ToString();
            TxtGodown.Text = dt.Rows[0]["GodownDesc"].ToString();
            CmbPrinterName.SelectedIndex = CmbPrinterName.FindString(dt.Rows[0]["PrinterName"].ToString());
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }

    }
}
