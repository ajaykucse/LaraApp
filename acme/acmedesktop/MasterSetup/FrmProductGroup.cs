﻿using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmProductGroup : Form
    {
        private ClsProductGroup _objProductGroup = new ClsProductGroup();
        ClsCommon _objCommon = new ClsCommon();
        public  char _IsNew;
        public int _ProductGrpId;
        private string _Tag = "", _SearchKey = "", result ="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0; public string _NewProductGroup = "";

        public FrmProductGroup()
        {
            InitializeComponent();
        }

        private void FrmProductGroup_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objProductGroup.GetDataProductGroup(0,"ProductGroup");
            ControlEnableDisable(true, false);
            ClsGlobal.BindPrinter(CmbPrinter);           

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
        private void FrmProductGroup_KeyDown(object sender, KeyEventArgs e)
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
            Text = "Product Group [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Product Group [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Product Group [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;
                DataTable dt = _objProductGroup.GetDataProductGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["ProductGrpId"].ToString()), "ProductGroup");
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
                DataTable dt = _objProductGroup.GetDataProductGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["ProductGrpId"].ToString()), "ProductGroup");
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
                DataTable dt = _objProductGroup.GetDataProductGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["ProductGrpId"].ToString()), "ProductGroup");
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
            DataTable dt = _objProductGroup.GetDataProductGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["ProductGrpId"].ToString()), "ProductGroup");
            SetData(dt);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("ProductGroup Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()))
            {
                MessageBox.Show("ProductGroup ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objProductGroup.Model.Tag = _Tag;
            _objProductGroup.Model.ProductGrpId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                return;
            }
            _objProductGroup.Model.ProductGrpDesc = TxtDescription.Text;
            _objProductGroup.Model.ProductGrpShortName = TxtShortName.Text;
            _objProductGroup.Model.ProductGrpMargin = ClsGlobal.ReturnDecimalVal(TxtMargin.Text);
            _objProductGroup.Model.ProductGrpPrinterName = CmbPrinter.Text;
            _objProductGroup.Model.Status = CbActive.Checked == true ? true : false;
            _objProductGroup.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objProductGroup.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave ==1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objProductGroup.SaveProductGroup("ProductGroup");
                    else
                        return;
                }
                else
                {
                    result = _objProductGroup.SaveProductGroup("ProductGroup");
                }
            }
            else
            {
                result = _objProductGroup.SaveProductGroup("ProductGroup");
            }
            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewProductGroup = TxtDescription.Text.Trim();
                    this._ProductGrpId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objProductGroup.GetDataProductGroup(0,"ProductGroup");
                    MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFld();
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
                    Text = "Product Group";
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
                Text = "Product Group";
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
            BtnSearchDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);

            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);

            TxtMargin.Enabled = fld;
            Utility.EnableDesibleColor(TxtMargin, fld);

            CbActive.Enabled = fld;

            CmbPrinter.Enabled = fld;
            //Utility.EnableDesibleColor(CmbPrinter, fld);
            
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
            _ProductGrpId = 0;
            TxtDescription.Tag = "0";
            CbActive.Checked = true;
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            CmbPrinter.SelectedIndex = CmbPrinter.FindString(strDefaultPrinter);
            TxtDescription.Focus();
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["ProductGrpId"].ToString();
            TxtDescription.Text = dt.Rows[0]["ProductGrpDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["ProductGrpShortName"].ToString();
            CmbPrinter.SelectedValue = dt.Rows[0]["PrinterName"].ToString();
            TxtMargin.Text = Convert.ToDecimal(ClsGlobal.Val(dt.Rows[0]["Margin"].ToString())).ToString("0.00");
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }

        private void BtnSearchDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objProductGroup.GetDataProductGroup(Convert.ToInt32(frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim()), "ProductGroup");
                    SetData(dt);
                    TxtDescription.SelectAll();
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
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSearchDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchDesc,true);
            }
        }

        private void CmbPrinter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                SendKeys.Send("{F4}");
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Product Group Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "ProductGroup", "ProductGrpDesc", "ProductGrpId") == 1)
                {
                    MessageBox.Show("Product Group Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "ProductGrpDesc", "ProductGrpShortName", "ProductGroup");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "ProductGroup", "ProductGrpDesc", "ProductGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Product Group Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Product Group ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "ProductGroup", "ProductGrpShortName", "ProductGrpId") == 1)
                {
                    MessageBox.Show("Product Group ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "ProductGroup", "ProductGrpShortName", "ProductGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Product Group ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
