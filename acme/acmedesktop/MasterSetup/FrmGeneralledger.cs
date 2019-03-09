﻿using acmedesktop.Common;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using DataAccessLayer.SystemSetting;
using System;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.MasterSetup
{
    public partial class FrmGeneralledger : Form
    {
        IGeneralLedger _objGeneralLedger = new ClsGeneralLedger();
        private ClsBranch _objBranch = new ClsBranch();
        private ClsCompanyUnit _objCmpUnit = new ClsCompanyUnit();
        private ClsPickList _objPickList = new ClsPickList();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _LedgerId;
        private string _Tag = "", _SearchKey = "" , result ="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;
        public string _NewLedger = "";
        public string Username, UMobileNo, UEmailId, UPassword;

        public FrmGeneralledger()
        {
            InitializeComponent();
        }
        private void FrmGeneralledger_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objGeneralLedger.GetDataGeneralLedger(0);
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();
            CmbCategory.SelectedIndex = 0;
            CmbCrWarning.SelectedIndex = 0;
            CmbCrDaysWarning.SelectedIndex = 0;
            if (ClsGlobal.BranchOrCompanyUnitWise == "Branch")
            {
                tabControl1.TabPages[2].Text = "Branch";
                GridBranchList();
            }
            else if (ClsGlobal.BranchOrCompanyUnitWise == "CompanyUnit")
            {
                tabControl1.TabPages[2].Text = "CompanyUnit";
                GridCompanyUnitList();
            }
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
        private void FrmGeneralledger_KeyDown(object sender, KeyEventArgs e)
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
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "General Ledger [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            ChkOnlineCustomer.Enabled = false;
            ChkSecondarySales.Enabled = false;
            Text = "General Ledger [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "General Ledger [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchDescription.Enabled = true;
            TxtDescription.Focus();
            BtnUdf.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                _LedgerId = Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["LedgerId"].ToString());
                DataTable dt = _objGeneralLedger.GetDataGeneralLedger(_LedgerId);
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
                _LedgerId = Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["LedgerId"].ToString());
                DataTable dt = _objGeneralLedger.GetDataGeneralLedger(_LedgerId);
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
                _LedgerId = Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["LedgerId"].ToString());
                DataTable dt = _objGeneralLedger.GetDataGeneralLedger(_LedgerId);
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
            _LedgerId = Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["LedgerId"].ToString());
            DataTable dt = _objGeneralLedger.GetDataGeneralLedger(_LedgerId);
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
                MessageBox.Show("General Ledger Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("General Ledger is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtAccountGroup.Text))
            {
                MessageBox.Show("Account Group Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }
            _objGeneralLedger.Model.Tag = _Tag;
            _objGeneralLedger.Model.LedgerId = _LedgerId;
            if ((_Tag == "EDIT" || _Tag == "DELETE") && _LedgerId == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }
            _objGeneralLedger.Model.GlDesc = TxtDescription.Text.Trim();
            _objGeneralLedger.Model.GlShortName = TxtShortName.Text.Trim();
            _objGeneralLedger.Model.GlCategory = CmbCategory.Text.Trim();
            _objGeneralLedger.Model.ACCode = TxtAccountingCode.Text.Trim();
            _objGeneralLedger.Model.GlPrintingName = TxtGlPrintingName.Text.Trim();
            _objGeneralLedger.Model.GlAlias = TxtAlias.Text.Trim();
            _objGeneralLedger.Model.AccountGrpId = ((TxtAccountGroup.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtAccountGroup.Tag.ToString()));
            _objGeneralLedger.Model.AccountSubGrpId = ((TxtAccountSubGroup.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtAccountSubGroup.Tag.ToString()));
            _objGeneralLedger.Model.PanNo = TxtPanNo.Text.Trim();
            //general Info
            _objGeneralLedger.Model.AreaId = ((TxtArea.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtArea.Tag.ToString()));
            _objGeneralLedger.Model.SalesmanId = ((TxtSalesman.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSalesman.Tag.ToString()));
            _objGeneralLedger.Model.CurrencyId = ((TxtCurrency.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtCurrency.Tag.ToString()));

            if (!string.IsNullOrEmpty(TxtDepartment.Text))
            {
                string[] dept = TxtDepartment.Tag.ToString().Split('|');
                _objGeneralLedger.Model.DepartmentId1 = ((dept[0].ToString() == "") ? 0 : Convert.ToInt32(dept[0].ToString()));
                _objGeneralLedger.Model.DepartmentId2 = ((dept[1].ToString() == "") ? 0 : Convert.ToInt32(dept[1].ToString()));
                _objGeneralLedger.Model.DepartmentId3 = ((dept[2].ToString() == "") ? 0 : Convert.ToInt32(dept[2].ToString()));
                _objGeneralLedger.Model.DepartmentId4 = ((dept[3].ToString() == "") ? 0 : Convert.ToInt32(dept[3].ToString()));

            }

            _objGeneralLedger.Model.SchemeId = ((TxtScheme.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtScheme.Tag.ToString()));
            _objGeneralLedger.Model.CreditLimit = ((TxtCrLimit.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtCrLimit.Text));
            _objGeneralLedger.Model.CreditDays = ((TxtCrDays.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtCrDays.Text));
            _objGeneralLedger.Model.InterestRate = ((TxtInterestRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtInterestRate.Text));
            _objGeneralLedger.Model.CreditLimitWarning = CmbCrWarning.Text.Trim();
            _objGeneralLedger.Model.CreditDaysWarning = CmbCrDaysWarning.Text.Trim();
            _objGeneralLedger.Model.CreditType = null;

            _objGeneralLedger.Model.IsSubledger = ChkSubledger.Checked == true ? true : false;
            _objGeneralLedger.Model.IsTDSAplicable = ChkTDSApplicable.Checked == true ? true : false;
            _objGeneralLedger.Model.IsDocAdjustment = ChkDocAdjustment.Checked == true ? true : false;
            //address Info
            _objGeneralLedger.Model.Address = TxtAddress.Text.Trim();
            _objGeneralLedger.Model.Address1 = TxtAddress1.Text.Trim();
            _objGeneralLedger.Model.District = TxtDistrict.Text.Trim();
            _objGeneralLedger.Model.City = TxtCity.Text.Trim();
            _objGeneralLedger.Model.State = TxtState.Text.Trim();
            _objGeneralLedger.Model.Country = TxtCountry.Text.Trim();
            _objGeneralLedger.Model.PhoneNo = TxtPhoneNo.Text.Trim();
            _objGeneralLedger.Model.AltPhoneNo = TxtAltPhoneNo.Text.Trim();
            _objGeneralLedger.Model.MobileNo = TxtMobileNo.Text.Trim();
            _objGeneralLedger.Model.FaxNo = TxtFax.Text.Trim();
            _objGeneralLedger.Model.EmailId = TxtEmail.Text.Trim();

            _objGeneralLedger.Model.ContactPersonName = TxtContactPerson.Text.Trim();
            _objGeneralLedger.Model.CPAddress = TxtContactPersonAdd.Text.Trim();
            _objGeneralLedger.Model.CPPhoneNo = TxtContPersonPhoneNo.Text.Trim();
            _objGeneralLedger.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objGeneralLedger.Model.Status = CbActive.Checked == true ? true : false;
            _objGeneralLedger.Model.Gadget = "Desktop";
            if (ChkOnlineCustomer.Checked == true)
            {
                _objGeneralLedger.Model.CustomerType = "OnlineCustomer";
            }
            else if (ChkSecondarySales.Checked == true)
            {
                _objGeneralLedger.Model.CustomerType = "SecondarySales";
            }
            else
            {
                _objGeneralLedger.Model.CustomerType = "Normal";
            }
            _objGeneralLedger.Model.UserName = Username;
            _objGeneralLedger.Model.UMobileNo = UMobileNo;
            _objGeneralLedger.Model.UEmailId = UEmailId;
            _objGeneralLedger.Model.Password = UPassword;

            if (ClsGlobal.BranchOrCompanyUnitWise == "Branch")
            {
                DataAccessLayer.MasterSetup.LedgerBranchCompanyUnitModel ModelLedgerBranchCompanyUnit = null;
                foreach (DataGridViewRow ro in GridBranch.Rows)
                {
                    ModelLedgerBranchCompanyUnit = new DataAccessLayer.MasterSetup.LedgerBranchCompanyUnitModel();
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ModelLedgerBranchCompanyUnit.BranchId = Convert.ToInt16(ro.Cells["BranchId"].Value.ToString());
                        _objGeneralLedger.ModelLedgerBranchCompanyUnit.Add(ModelLedgerBranchCompanyUnit);
                    }
                }
            }
            else if (ClsGlobal.BranchOrCompanyUnitWise == "CompanyUnit")
            {
                DataAccessLayer.MasterSetup.LedgerBranchCompanyUnitModel ModelLedgerBranchCompanyUnit = null;
                foreach (DataGridViewRow ro in GridBranch.Rows)
                {
                    ModelLedgerBranchCompanyUnit = new DataAccessLayer.MasterSetup.LedgerBranchCompanyUnitModel();
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ModelLedgerBranchCompanyUnit.BranchId = Convert.ToInt16(ro.Cells["BranchId"].Value.ToString());
                        ModelLedgerBranchCompanyUnit.CompanyUnitId = Convert.ToInt16(ro.Cells["CompanyUnitId"].Value.ToString());
                        _objGeneralLedger.ModelLedgerBranchCompanyUnit.Add(ModelLedgerBranchCompanyUnit);
                    }
                }
            }

            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = _objGeneralLedger.SaveGeneralLedger();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = _objGeneralLedger.SaveGeneralLedger();
                }
            }
            else
            {
                result = _objGeneralLedger.SaveGeneralLedger();
            }


           
            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewLedger = TxtDescription.Text.Trim();
                    _LedgerId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objGeneralLedger.GetDataGeneralLedger(0);
                    MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFld();
                    TxtDescription.Focus();
                }
                if (_objGeneralLedger.Model.CustomerType != "Normal")
                {
                    _objGeneralLedger.Model.ULedgerId = Convert.ToInt32(result);
                    string Res = _objGeneralLedger.SaveUserMaster();
                    if (string.IsNullOrEmpty(Res))
                    {
                        _objGeneralLedger.Model.Tag = "DELETE";
                        _objGeneralLedger.Model.LedgerId = Convert.ToInt32(result);
                        _objGeneralLedger.SaveGeneralLedger();
                        MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
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
                    Text = "General Ledger Setup";
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
                Text = "General Ledger Setup";
            }
           
        }
        private void BtnSearchDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    _LedgerId = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
                    DataTable dt = _objGeneralLedger.GetDataGeneralLedger(_LedgerId);
                    SetData(dt);
                }
                else
                {
                    TxtDescription.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSearchDescription.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchDescription, true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription)  return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Ledger Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtDescription.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text, "GeneralLedger", "GlDesc", "LedgerId") == 1)
                {
                    MessageBox.Show("Ledger Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtDescription.Focus();
                    return;
                }
                else
                {

                    if (string.IsNullOrEmpty(TxtGlPrintingName.Text))
                    {
                        TxtGlPrintingName.Text = TxtDescription.Text;
                    }
                    if (string.IsNullOrEmpty(TxtAlias.Text))
                    {
                        TxtAlias.Text = TxtDescription.Text;
                    }
                }

            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text, "GeneralLedger", "GlDesc", "LedgerId", _LedgerId) != 0)
                {
                    MessageBox.Show("Ledger Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void CmbCategory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "NEW")
            {
                if (!string.IsNullOrEmpty(TxtDescription.Text) && !string.IsNullOrEmpty(CmbCategory.Text))
                {

                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text, "GlDesc", "GlShortName", "GeneralLedger", CmbCategory.Text);
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

            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Ledger ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtShortName.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text, "GeneralLedger", "GlShortName", "LedgerId") == 1)
                {
                    MessageBox.Show("Ledger ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtShortName.Focus();
                    return;
                }

            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text, "GeneralLedger", "GlShortName", "LedgerId", _LedgerId) != 0)
                {
                    MessageBox.Show("Ledger ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }

            }
        }
        private void TxtGlPrintingName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtGlPrintingName)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtGlPrintingName.Text))
            {
                MessageBox.Show("Printing Name  Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtGlPrintingName.Focus();
                return;
            }
        }
        private void TxtAlias_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtAlias)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtAlias.Text))
            {
                MessageBox.Show("Alias Name  Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtAlias.Focus();
                return;
            }

        }
        private void BtnSearchAcGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("AccountGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtAccountGroup.Text = frmPickList.SelectedList[0]["AccountGrpDesc"].ToString().Trim();
                    TxtAccountGroup.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["AccountGrpId"].ToString().Trim());
                    TxtAccountSubGroup.Text = "";
                    TxtAccountSubGroup.Tag = "0";
                    TxtAccountGroup.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Account Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }
            TxtAccountGroup.Focus();
        }
        private void TxtAccountGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmAccountGroup frm = new FrmAccountGroup();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtAccountGroup.Text = frm._NewAccountGroup;
                TxtAccountGroup.Tag = frm._AccountGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtAccountGroup, BtnSearchAcGroup, false);
            }
        }
        private void TxtAccountGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtAccountGroup)
            {
                return;
            }

            if (TxtAccountGroup.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtAccountGroup.Text))
            {
                MessageBox.Show("Account Group Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtAccountGroup.Focus();
                return;
            }
        }
        private void BtnSearchAcSubGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("AccountSubGroup." + TxtAccountGroup.Tag, _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtAccountSubGroup.Text = frmPickList.SelectedList[0]["AccountSubGrpDesc"].ToString().Trim();
                    TxtAccountSubGroup.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["AccountSubGrpId"].ToString().Trim());
                    TxtAccountSubGroup.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Account Sub Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountSubGroup.Focus();
                return;
            }
            TxtAccountSubGroup.Focus();
        }
        private void TxtAccountSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmAccountSubGroup frm = new FrmAccountSubGroup();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtAccountSubGroup.Text = frm._NewAccountSubGroup;
                TxtAccountSubGroup.Tag = frm._AccountSubGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtAccountSubGroup, BtnSearchAcSubGroup, false);
            }
        }
        private void TxtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmSubArea frm = new FrmSubArea();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtArea.Text = frm._NewArea;
                TxtArea.Tag = frm._AreaId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtArea, BtnSearchArea, false);
            }
        }
        private void BtnSearchArea_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SubArea", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtArea.Text = frmPickList.SelectedList[0]["AreaDesc"].ToString().Trim();
                    TxtArea.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["AreaId"].ToString().Trim());
                    TxtArea.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Area !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtArea.Focus();
                return;
            }
            TxtArea.Focus();
        }
        private void TxtSalesman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmSalesMan frm = new FrmSalesMan();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSalesman.Text = frm._NewSubSalesMan;
                TxtSalesman.Tag = frm._SalesmanId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSalesman, BtnSearchSalesman, false);
            }
        }
        private void BtnSearchSalesman_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesMan", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSalesman.Text = frmPickList.SelectedList[0]["SalesmanDesc"].ToString().Trim();
                    TxtSalesman.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SalesmanId"].ToString().Trim());
                    TxtSalesman.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Salesman !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesman.Focus();
                return;
            }
            TxtSalesman.Focus();
        }
        private void TxtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmDepartment frm = new FrmDepartment();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtDepartment.Text = frm._NewDepartment;
                TxtDepartment.Tag = frm._DepartmentId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtDepartment, BtnSearchDepartment, false);
            }

        }
        private void BtnSearchDepartment_Click(object sender, EventArgs e)
        {
            ClsButtonClick.DepartmentBtnClick(_SearchKey, TxtDepartment, e);
        }
        private void TxtCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmCurrency frm = new FrmCurrency();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtCurrency.Text = frm._NewCurrency;
                TxtCurrency.Tag = frm._CurrencyId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtCurrency, BtnSearchCurrency, false);
            }
        }
        private void BtnSearchCurrency_Click(object sender, EventArgs e)
        {
            ClsButtonClick.CurrencyBtnClick(_SearchKey, TxtCurrency, e);
            //_SearchKey = string.Empty;
        }
        private void TxtScheme_KeyDown(object sender, KeyEventArgs e)
        {
            _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtScheme, BtnSearchScheme, false);
        }
        private void BtnSearchScheme_Click(object sender, EventArgs e)
        {

        }
        private void TxtPanNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPanNo.Text))
            {
                if (TxtPanNo.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Pan Number should be nine digit...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtPanNo.Focus();
                    return;
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "TabBranch")
            {
                if (ClsGlobal.BranchOrCompanyUnitWise == "Branch")
                {
                    GridBranchList();
                }
                else if (ClsGlobal.BranchOrCompanyUnitWise == "CompanyUnit")
                {
                    GridCompanyUnitList();
                }
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
            tabControl1.Enabled = fld;
            TxtDescription.Enabled = fld;
            BtnSearchDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CmbCategory.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbCategory, fld);
            TxtAccountGroup.Enabled = fld;
            BtnSearchAcGroup.Enabled = fld;
            Utility.EnableDesibleColor(TxtAccountGroup, fld);
            TxtAccountSubGroup.Enabled = fld;
            BtnSearchAcSubGroup.Enabled = fld;
            Utility.EnableDesibleColor(TxtAccountSubGroup, fld);
            TxtPanNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPanNo, fld);

            TxtArea.Enabled = fld;
            BtnSearchArea.Enabled = fld;
            Utility.EnableDesibleColor(TxtArea, fld);
            TxtSalesman.Enabled = fld;
            BtnSearchSalesman.Enabled = fld;
            Utility.EnableDesibleColor(TxtSalesman, fld);
            TxtDepartment.Enabled = fld;
            BtnSearchDepartment.Enabled = fld;
            Utility.EnableDesibleColor(TxtDepartment, fld);
            TxtCurrency.Enabled = fld;
            BtnSearchCurrency.Enabled = fld;
            Utility.EnableDesibleColor(TxtCurrency, fld);
            TxtScheme.Enabled = fld;
            BtnSearchScheme.Enabled = fld;
            Utility.EnableDesibleColor(TxtScheme, fld);

            TxtCrLimit.Enabled = fld;
            Utility.EnableDesibleColor(TxtCrLimit, fld);
            TxtCrDays.Enabled = fld;
            Utility.EnableDesibleColor(TxtCrDays, fld);
            TxtInterestRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtInterestRate, fld);
            TxtOpeningDr.Enabled = fld;
            Utility.EnableDesibleColor(TxtOpeningDr, fld);
            TxtOpeningCr.Enabled = fld;
            Utility.EnableDesibleColor(TxtOpeningCr, fld);
            TxtAccountingCode.Enabled = fld;
            Utility.EnableDesibleColor(TxtAccountingCode, fld);
            TxtAlias.Enabled = fld;
            Utility.EnableDesibleColor(TxtAlias, fld);

            CmbCrDaysWarning.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbCrDaysWarning, fld);
            CmbCrWarning.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbCrWarning, fld);

            ChkSubledger.Enabled = fld;
            ChkDocAdjustment.Enabled = fld;
            ChkTDSApplicable.Enabled = fld;
            CbActive.Enabled = fld;
            //info
            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);
            TxtAddress1.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress1, fld);
            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);
            TxtState.Enabled = fld;
            Utility.EnableDesibleColor(TxtState, fld);
            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);
            TxtAltPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtAltPhoneNo, fld);
            TxtMobileNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtMobileNo, fld);
            TxtEmail.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmail, fld);
            TxtFax.Enabled = fld;
            Utility.EnableDesibleColor(TxtFax, fld);
            TxtContactPerson.Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPerson, fld);
            TxtContactPersonAdd.Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPersonAdd, fld);
            TxtContPersonPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtContPersonPhoneNo, fld);
            TxtDistrict.Enabled = fld;
            Utility.EnableDesibleColor(TxtDistrict, fld);
            TxtCity.Enabled = fld;
            Utility.EnableDesibleColor(TxtCity, fld);

            TxtGlPrintingName.Enabled = fld;
            Utility.EnableDesibleColor(TxtGlPrintingName, fld);

            BtnUdf.Enabled = fld;

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
            _LedgerId = 0;
            TxtAccountGroup.Tag = "";
            TxtAccountSubGroup.Tag = "";
            TxtSalesman.Tag = "";
            TxtArea.Tag = "";
            TxtDepartment.Tag = "";
            TxtDepartment.Text = "";
            TxtScheme.Tag = "";
            TxtCurrency.Tag = "";
            TxtCrDays.Text = "";
            TxtCrLimit.Text = "";
            TxtCurrency.Text = "";
            TxtSalesman.Text = "";
            TxtArea.Text = "";
            TxtCity.Text = "";
            TxtCountry.Text = "";
            TxtDistrict.Text = "";
            TxtAddress.Text = "";
            TxtAddress1.Text = "";
            TxtAlias.Text = "";
            TxtScheme.Text = "";
            TxtState.Text = "";
            TxtAccountingCode.Text = "";
            TxtContactPerson.Text = "";
            TxtContactPersonAdd.Text = "";
            TxtContPersonPhoneNo.Text = "";
            TxtOpeningCr.Text = "";
            TxtOpeningDr.Text = "";
            TxtPanNo.Text = "";
            TxtPhoneNo.Text = "";
            TxtEmail.Text = "";
            TxtFax.Text = "";
            TxtGlPrintingName.Text = "";
            TxtMobileNo.Text = "";
            TxtInterestRate.Text = "";
            TxtAltPhoneNo.Text = "";

            ChkDocAdjustment.Checked = false;
            ChkSubledger.Checked = false;
            ChkTDSApplicable.Checked = false;
            ChkSecondarySales.Checked = false;
            ChkOnlineCustomer.Checked = false;
            GridBranch.Columns.Clear();

            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CbActive.Checked = true;
            CmbCategory.SelectedIndex = 0;
            CmbCrWarning.SelectedIndex = 0;
            CmbCrDaysWarning.SelectedIndex = 0;
            tabControl1.SelectedIndex = 0;
            TxtDescription.Focus();
        }
        private void GridBranchList()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);

            dt.Columns.Add("Access", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("BranchId");
            dt.Columns.Add("BranchName");

            DataTable dt1 = _objBranch.BranchListForLedger(_LedgerId.ToString());
            foreach (DataRow row in dt1.Rows)
            {
                if (dt1.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Access"] = row["Tag"].ToString();
                    dr["BranchId"] = row["BranchId"].ToString();
                    dr["BranchName"] = row["BranchName"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridBranch.DataSource = dt;
            GridBranch.Columns["Access"].Width = 80;
            GridBranch.Columns["BranchId"].Width = 0;
            GridBranch.Columns["BranchId"].ReadOnly = true;
            GridBranch.Columns["BranchId"].Visible = false;
            GridBranch.Columns["BranchName"].Width = 300;
            GridBranch.Columns["BranchName"].ReadOnly = true;
        }
        private void CmbCrWarning_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void CmbCrDaysWarning_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                SendKeys.Send("{F4}");
            }
        }



        private void CmbCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void TxtCurrency_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (_Tag == "" || ActiveControl == TxtCurrency) return;
            //ClsButtonClick.CurrencyValidating(TxtCurrency, TxtCurrencyRate, LblNetAmt, LblLocalNetAmt, e);
        }

        private void ChkSecondarySales_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSecondarySales.Checked == true)
            {
                ChkOnlineCustomer.Checked = false;
                ChkOnlineCustomer.Enabled = false;
            }
            else
            {
                ChkOnlineCustomer.Enabled = true;
            }
            if (_Tag == "NEW")
            {
                if (ChkSecondarySales.Checked == true)
                {
                    FrmUser frm = new FrmUser();
                    frm.ShowDialog();
                    Username = frm.Username;
                    UMobileNo = frm.MobileNo;
                    UEmailId = frm.EmailId;
                    UPassword = frm.Password;
                }
            }
        }

        private void ChkOnlineCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkOnlineCustomer.Checked == true)
            {
                ChkSecondarySales.Checked = false;
                ChkSecondarySales.Enabled = false;
            }
            else
            {
                ChkSecondarySales.Enabled = true;
            }
            if (_Tag == "NEW")
            {
                if (ChkOnlineCustomer.Checked == true)
                {
                    FrmUser frm = new FrmUser();
                    frm.ShowDialog();
                    Username = frm.Username;
                    UMobileNo = frm.MobileNo;
                    UEmailId = frm.EmailId;
                    UPassword = frm.Password;
                }
            }
        }

        private void GridCompanyUnitList()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Access", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("CompanyUnitId");
            dt.Columns.Add("CompanyUnitName");
            dt.Columns.Add("BranchId");
            dt.Columns.Add("BranchName");
            DataTable dt1 = _objCmpUnit.CompanyUnitListForLedger(_LedgerId.ToString());
            foreach (DataRow row in dt1.Rows)
            {
                if (dt1.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Access"] = row["Tag"].ToString();
                    dr["CompanyUnitId"] = row["CompanyUnitId"].ToString();
                    dr["CompanyUnitName"] = row["CmpUnitName"].ToString();
                    dr["BranchId"] = row["BranchId"].ToString();
                    dr["BranchName"] = row["BranchName"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridBranch.DataSource = dt;
            GridBranch.Columns["Access"].Width = 80;
            GridBranch.Columns["CompanyUnitId"].Width = 0;
            GridBranch.Columns["CompanyUnitId"].ReadOnly = true;
            GridBranch.Columns["CompanyUnitId"].Visible = false;
            GridBranch.Columns["CompanyUnitName"].Width = 300;
            GridBranch.Columns["CompanyUnitName"].ReadOnly = true;
            GridBranch.Columns["BranchId"].Width = 0;
            GridBranch.Columns["BranchId"].ReadOnly = true;
            GridBranch.Columns["BranchId"].Visible = false;
            GridBranch.Columns["BranchName"].Width = 300;
            GridBranch.Columns["BranchName"].ReadOnly = true;
        }

        private void SetData(DataTable dt)
        {
            TxtDescription.Text = dt.Rows[0]["GlDesc"].ToString();
            CmbCategory.Text = dt.Rows[0]["GlCategory"].ToString();
            TxtShortName.Text = dt.Rows[0]["GlShortName"].ToString();
            TxtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
            TxtAlias.Text = dt.Rows[0]["GlAlias"].ToString();
            TxtGlPrintingName.Text = dt.Rows[0]["GlPrintingName"].ToString();

            TxtAccountGroup.Text = dt.Rows[0]["AccountGrpDesc"].ToString();
            TxtAccountGroup.Tag = dt.Rows[0]["AccountGrpId"].ToString();
            TxtAccountSubGroup.Text = dt.Rows[0]["AccountSubGrpDesc"].ToString();
            TxtAccountSubGroup.Tag = dt.Rows[0]["AccountSubGrpId"].ToString();
            TxtArea.Text = dt.Rows[0]["AreaDesc"].ToString();
            TxtArea.Tag = dt.Rows[0]["AreaId"].ToString();
            TxtSalesman.Text = dt.Rows[0]["SalesmanDesc"].ToString();
            TxtSalesman.Tag = dt.Rows[0]["SalesmanId"].ToString();
            TxtCurrency.Text = dt.Rows[0]["CurrencyDesc"].ToString();
            TxtCurrency.Tag = dt.Rows[0]["CurrencyId"].ToString();
            if (string.IsNullOrEmpty(dt.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dt.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dt.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dt.Rows[0]["DepartmentDesc4"].ToString()))
            {
                string[] Dept = new string[] { dt.Rows[0]["DepartmentDesc1"].ToString(), "|", dt.Rows[0]["DepartmentDesc2"].ToString(), "|", dt.Rows[0]["DepartmentDesc3"].ToString(), "|", dt.Rows[0]["DepartmentDesc3"].ToString() };
                TxtDepartment.Text = string.Concat(Dept);
                string[] Depttag = new string[] { dt.Rows[0]["DepartmentId1"].ToString(), "|", dt.Rows[0]["DepartmentId2"].ToString(), "|", dt.Rows[0]["DepartmentId3"].ToString(), "|", dt.Rows[0]["DepartmentId4"].ToString() };
                TxtDepartment.Tag = string.Concat(Depttag);

            }
            TxtScheme.Text = dt.Rows[0]["SchemeDesc"].ToString();
            TxtScheme.Tag = dt.Rows[0]["SchemeId"].ToString();

            TxtCrLimit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(ClsGlobal.Val(dt.Rows[0]["CreditLimit"].ToString())), 1, ClsGlobal._AmountDecimalFormat);
            CmbCrWarning.Text = dt.Rows[0]["CreditLimitWarning"].ToString();
            TxtCrDays.Text = Convert.ToInt16(ClsGlobal.Val(dt.Rows[0]["CreditDays"].ToString())).ToString();
            TxtInterestRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(ClsGlobal.Val(dt.Rows[0]["InterestRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat);

            ChkSubledger.Checked =string.IsNullOrEmpty(dt.Rows[0]["IsSubledger"].ToString())? false : Convert.ToBoolean(dt.Rows[0]["IsSubledger"].ToString());
            ChkTDSApplicable.Checked = string.IsNullOrEmpty(dt.Rows[0]["IsTDSAplicable"].ToString()) ? false : Convert.ToBoolean(dt.Rows[0]["IsTDSAplicable"].ToString());
            ChkDocAdjustment.Checked = string.IsNullOrEmpty(dt.Rows[0]["IsDocAdjustment"].ToString()) ? false : Convert.ToBoolean(dt.Rows[0]["IsDocAdjustment"].ToString());

            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtAddress1.Text = dt.Rows[0]["Address1"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtState.Text = dt.Rows[0]["State"].ToString();
            TxtDistrict.Text = dt.Rows[0]["District"].ToString();
            TxtCity.Text = dt.Rows[0]["City"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtAltPhoneNo.Text = dt.Rows[0]["AltPhoneNo"].ToString();
            TxtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            TxtFax.Text = dt.Rows[0]["FaxNo"].ToString();
            TxtEmail.Text = dt.Rows[0]["Email"].ToString();
            TxtContactPerson.Text = dt.Rows[0]["ContactPersonName"].ToString();
            TxtContactPersonAdd.Text = dt.Rows[0]["CPAddress"].ToString();
            TxtContPersonPhoneNo.Text = dt.Rows[0]["CPPhoneNo"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }
    }
}