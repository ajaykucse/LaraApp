using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using acmedesktop.Common;
using acmedesktop.MyInputControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.DataTransaction;
using acmedesktop.MasterSetup;
using DataAccessLayer.Interface.DataTransaction.Finance;
using DataAccessLayer.DataTransaction.Finance;

namespace acmedesktop.DataTransaction.Finance
{
    public partial class FrmDebitNoteVoucher : Form
    {
        MyGridPickListTextBox TxtGridGeneralLedger;
        MyGridSubledgerTextBox TxtGridSubLedger;      
        MyGridPickListTextBox TxtGridDepartment;
        MyGridNumericTextBox TxtGridAmount;
        MyGridPickListTextBox TxtGridNarration;


        ClsCommon _objCommon = new ClsCommon();
        ClsGeneralLedger _objLedger = new ClsGeneralLedger();
        ClsSubledger _objSubLedger = new ClsSubledger();
        ISalesman _objSalesman = new ClsSalesman();
        ClsDateMiti _objDate = new ClsDateMiti();
        ClsUdfMaster _objUDF = new ClsUdfMaster();
        IDebitNoteVoucher _objDebitNoteVoucher = new ClsDebitNoteVoucher(); 
        char DocType = 'B';
        char _IsVatReg = 'N';
        string _VoucherNo = "";
        string _Tag = "";
        string _SearchKey = "", result ="";

        DateTime date; int _DocId = 0;

		public FrmDebitNoteVoucher()
        {
            InitializeComponent();
            _Tag = "";
            TxtGridGeneralLedger = new MyGridPickListTextBox(Grid);
            TxtGridGeneralLedger.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridGeneralLedger_Validating);
            TxtGridGeneralLedger.PickListType = MyGridPickListTextBox.ListType.GeneralLedger;
            
            TxtGridSubLedger = new MyGridSubledgerTextBox(Grid);
            TxtGridSubLedger.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridSubLedger_Validating);           

            TxtGridDepartment = new MyGridPickListTextBox(Grid);
            TxtGridDepartment.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridDepartment_Validating);
            TxtGridDepartment.PickListType = MyGridPickListTextBox.ListType.Department;

            TxtGridAmount = new MyGridNumericTextBox(Grid);
            TxtGridAmount.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridAmount_Validating);

            TxtGridNarration = new MyGridPickListTextBox(Grid);
            TxtGridNarration.PickListType = MyGridPickListTextBox.ListType.Narration;

            TxtGridNarration.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridNarration_Validating);
            //this.TxtGridNarration.EnterKeyPress += new MyGridPickListTextBox.EnterKeyPressHandler(TxtGridNarration_EnterKeyPress);
            this.TxtGridNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGridNarration_KeyPress);

            GridControlMode(false);
            ClsGlobal.FilterGlCategory = "";
        }

        private void FrmDebitNoteVoucher_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();
            ClsGlobal.FilterGlCategory = "Customer,Vendor,Both,LC,Other";
			if (Grid.Columns["SubLedger"].Visible == false & Grid.Columns["Department"].Visible == false)
				Grid.Columns["Narration"].Width = 400;
			else if (Grid.Columns["SubLedger"].Visible == false || Grid.Columns["Department"].Visible == false)
				Grid.Columns["Narration"].Width = 300;
		}

        private void FrmDebitNoteVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl != Grid)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridGeneralLedger.Visible == true)
                {
                    GridControlMode(false);
                    Grid.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    BtnCancel.PerformClick();
                }
                else if (BtnCancel.Enabled == false)
                    BtnExit.PerformClick();

                DialogResult = DialogResult.Cancel;
                return;
            }

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);

            this.Text = "Debit Note Voucher [NEW]";

			if (ClsGlobal.DateType == "M")
			{
				TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
				TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
				date =Convert.ToDateTime ( TxtDate.Text);
			}
			else
			{
				TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtDate.Text));
				date = Convert.ToDateTime(TxtDate.Text);
			}
			if (TxtDate.Enabled == false)
				Utility.GetVoucherNo2("Debit Note", TxtVoucherNo, TxtReferenceNo, _Tag, "", _DocId);
			else
				Utility.GetVoucherNo1("Debit Note", TxtVoucherNo, TxtMiti, _Tag, "", _DocId);
			
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Debit Note Voucher [EDIT]";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Debit Note Voucher [DELETE]";
            TxtVoucherNo.Enabled = true;
            BtnVoucherNoSearch.Enabled = true;
            TxtVoucherNo.Focus();
            BtnUDF.Enabled = false;
            BtnOk.Enabled = true;
            BtnCancel.Enabled = true;
            Grid.Enabled = false;
        }

        private void BtnFirstData_Click(object sender, EventArgs e)
        {

        }

        private void BtnNextData_Click(object sender, EventArgs e)
        {

        }

        private void BtnPreviousData_Click(object sender, EventArgs e)
        {

        }

        private void BtnLastData_Click(object sender, EventArgs e)
        {

        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }

        private void BtnUDF_Click(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPartyName.Text))
            {
                MessageBox.Show("Party Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPartyName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtDate.Text))
            {
                MessageBox.Show("Date Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDate.Focus();
                return;
            }
            if (Grid.Rows.Count == 1 && Grid.Rows[0].Cells["GeneralLedger"].Value == null)
            {
                MessageBox.Show("Debit Note Voucher Details Not Found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Grid.Focus();
                GridControlMode(true);
                return;
            }

            _objDebitNoteVoucher.Model.Tag = _Tag;
        
            if ((_Tag == "EDIT" || _Tag == "DELETE") && _VoucherNo == "")
            {
                ClearFld();
                TxtPartyName.Focus();
                return;
            }
			if (_Tag == "NEW")
			{
				string[] VoucherNoDetails = _objCommon.GetVoucherNo(TxtVoucherNo.Tag.ToString(), "Debit Note", ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
				_objDebitNoteVoucher.Model.DocId = ((TxtVoucherNo.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtVoucherNo.Tag.ToString()));
				_objDebitNoteVoucher.Model.VoucherNo = VoucherNoDetails[0];
			}
			else
				_objDebitNoteVoucher.Model.VoucherNo = TxtVoucherNo.Text.Trim();
			_objDebitNoteVoucher.Model.VDate = Convert.ToDateTime(TxtDate.Text.ToString());

            _objDebitNoteVoucher.Model.VTime = Convert.ToDateTime(TxtDate.Text.ToString());
            _objDebitNoteVoucher.Model.VMiti = TxtMiti.Text;
            _objDebitNoteVoucher.Model.CurrencyId = ((TxtCurrency.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtCurrency.Tag.ToString()));
            _objDebitNoteVoucher.Model.CurrencyRate = ((TxtCurrencyRate.Text.ToString() == "" || Convert.ToDecimal(TxtCurrencyRate.Text.ToString()) == 0) ? 1 : Convert.ToDecimal(TxtCurrencyRate.Text.ToString()));
            _objDebitNoteVoucher.Model.LedgerId = ((TxtPartyName.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPartyName.Tag.ToString()));
            _objDebitNoteVoucher.Model.SalesmanId = ((TxtSalesman.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSalesman.Tag.ToString()));
            _objDebitNoteVoucher.Model.SubLedgerId = ((TxtSubledger.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSubledger.Tag.ToString()));

            if (!string.IsNullOrEmpty(this.TxtDepartment.Text))
            {
                string[] dept = TxtDepartment.Tag.ToString().Split('|');
                _objDebitNoteVoucher.Model.DepartmentId1 = ((dept[0].ToString() == "") ? 0 : Convert.ToInt32(dept[0].ToString()));
                _objDebitNoteVoucher.Model.DepartmentId2 = ((dept[1].ToString() == "") ? 0 : Convert.ToInt32(dept[1].ToString()));
                _objDebitNoteVoucher.Model.DepartmentId3 = ((dept[2].ToString() == "") ? 0 : Convert.ToInt32(dept[2].ToString()));
                _objDebitNoteVoucher.Model.DepartmentId4 = ((dept[3].ToString() == "") ? 0 : Convert.ToInt32(dept[3].ToString()));
            }
          
            _objDebitNoteVoucher.Model.BranchId = ClsGlobal.BranchId;
            _objDebitNoteVoucher.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;
            _objDebitNoteVoucher.Model.ReferenceNo = TxtReferenceNo.Text;
            if (TxtReferenceDate.Text == "  /  /")
                _objDebitNoteVoucher.Model.ReferenceDate = null;
            else
                _objDebitNoteVoucher.Model.ReferenceDate = Convert.ToDateTime(TxtReferenceDate.Text.ToString());
            _objDebitNoteVoucher.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objDebitNoteVoucher.Model.Remarks = TxtRemarks.Text;
            _objDebitNoteVoucher.Model.IsReconcile = 0;
            _objDebitNoteVoucher.Model.ReconcileBy = "";
            _objDebitNoteVoucher.Model.ReconcileDate = null;
            _objDebitNoteVoucher.Model.IsPosted = 0;
            _objDebitNoteVoucher.Model.PostedBy = "";
            _objDebitNoteVoucher.Model.PostedDate = null;
            _objDebitNoteVoucher.Model.IsAuthorized = 0;
            _objDebitNoteVoucher.Model.AuthorizedBy = "";
            _objDebitNoteVoucher.Model.AuthorizedDate = null;
            _objDebitNoteVoucher.Model.AuthorizeRemarks = "";
            _objDebitNoteVoucher.Model.Gadget = "Desktop";

            DebitNoteDetailsViewModel DetailsModel = null;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                if (ro.Cells["GeneralLedger"].Value != null)
                {
                    DetailsModel = new DebitNoteDetailsViewModel();
                    DetailsModel.VoucherNo = _objDebitNoteVoucher.Model.VoucherNo;
                    DetailsModel.Sno = Grid.Rows.IndexOf(ro) + 1;
                    DetailsModel.LedgerId = ro.Cells["LedgerId"].Value != null ? Convert.ToInt32(ro.Cells["LedgerId"].Value.ToString()) : 0;
                    DetailsModel.SubledgerId = (ro.Cells["SubledgerId"].Value != null) ? Convert.ToInt32(ro.Cells["SubledgerId"].Value.ToString()) : 0;

                    if (ro.Cells["DepartmentId"].Value!=null)
                    {
                        string[] dept = ro.Cells["DepartmentId"].Value.ToString().Split('|');
                        DetailsModel.DepartmentIdDet1 = ((dept[0].ToString() == "") ? 0 : Convert.ToInt32(dept[0].ToString()));
                        DetailsModel.DepartmentIdDet2 = ((dept[1].ToString() == "") ? 0 : Convert.ToInt32(dept[1].ToString()));
                        DetailsModel.DepartmentIdDet3 = ((dept[2].ToString() == "") ? 0 : Convert.ToInt32(dept[2].ToString()));
                        DetailsModel.DepartmentIdDet4 = ((dept[3].ToString() == "") ? 0 : Convert.ToInt32(dept[3].ToString()));
                    }
                           
                    if (ro.Cells["Amount"].Value != null)
                    {
                        DetailsModel.Amount = ro.Cells["Amount"].Value.ToString() != "" ? Convert.ToDecimal(ro.Cells["Amount"].Value.ToString()) : 0;
                        DetailsModel.LocalAmount = (ro.Cells["Amount"].Value.ToString() != "" ? Convert.ToDecimal(ro.Cells["Amount"].Value.ToString()) : 0) * _objDebitNoteVoucher.Model.CurrencyRate;
                    }
                    else
                    {
                        DetailsModel.Amount = 0;
                        DetailsModel.LocalAmount = 0;
                    }
                    DetailsModel.Naration = ro.Cells["Narration"].Value != null ? ro.Cells["Narration"].Value.ToString() : "";

                    _objDebitNoteVoucher.ModelDetails.Add(DetailsModel);
                }
            }

            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to save new record...?", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objDebitNoteVoucher.SaveDebitNote();
                    else
                        return;
                }
                else
                {
                    result = _objDebitNoteVoucher.SaveDebitNote();
                }
            }
            else
            {
                result = _objDebitNoteVoucher.SaveDebitNote();
            }         
            if (!string.IsNullOrEmpty(result))
            {
				if (_Tag == "NEW")
					MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been generated.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else if (_Tag == "EDIT")
					MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been updated.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else if (_Tag == "DELETE")
					MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been deleted.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);

				ClearFld();
				if (_Tag == "NEW")
				{
					this._DocId = Convert.ToInt32(TxtVoucherNo.Tag.ToString());
					BtnNew.Enabled = true;
					BtnNew.PerformClick();
				}
				else if (_Tag == "EDIT")
				{
					BtnEdit.Enabled = true;
					BtnEdit.PerformClick();
				}
				else if (_Tag == "DELETE")
				{
					BtnDelete.Enabled = true;
					BtnDelete.PerformClick();
				}
			}
            else
            {
                MessageBox.Show("Error occured during data submit.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClear ==1)
            {
                DialogResult dialog = ClsGlobal.ConfirmFormClearing(); 
                if (dialog == DialogResult.Yes)
                {
                    _Tag = "";
                    ControlEnableDisable(true, false);
                    ClearFld();
                    TxtVoucherNo.Text = "";
                    this.Text = "Debit Note Voucher";
                }
                else
                    return;
            }
            else if (ClsGlobal.ConfirmFormClear == 0)
            {
                _Tag = "";
                ControlEnableDisable(true, false);
                ClearFld();
                TxtVoucherNo.Text = "";
                this.Text = "Debit Note Voucher";
            }
        }

        public void ControlEnableDisable(bool btn, bool fld)
        {
            BtnNew.Enabled = btn;
            BtnEdit.Enabled = btn;
            BtnDelete.Enabled = btn;
            BtnExit.Enabled = btn;

            BtnCopy.Enabled = btn;
            BtnPrint.Enabled = btn;

            if (BtnNew.Enabled == true) BtnNew.Focus();

            TxtVoucherNo.Enabled = fld;
            BtnVoucherNoSearch.Enabled = fld;

            Utility.EnableDesibleColor(TxtVoucherNo, fld);
            TxtMiti.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtMiti, fld);
            TxtDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtDate, fld);
           
            TxtReferenceNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtReferenceNo, fld);
            TxtReferenceDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtReferenceDate, fld);

            TxtPartyName.Enabled = fld;
            Utility.EnableDesibleColor(TxtPartyName, fld);
            BtnSearchPartyName.Enabled = fld;

            TxtSalesman.Enabled = fld;
            Utility.EnableDesibleColor(TxtSalesman, fld);
            BtnSearchSalesman.Enabled = fld;

            TxtSubledger.Enabled = fld;
            Utility.EnableDesibleColor(TxtSubledger, fld);
            BtnSearchSubledger.Enabled = fld;

            TxtDepartment.Enabled = fld;
            Utility.EnableDesibleColor(TxtDepartment, fld);
            BtnSearchDepartment.Enabled = fld;

            TxtReferenceNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtReferenceNo, fld);
            TxtReferenceDate.Enabled = fld;

            TxtRemarks.Enabled = fld;
            Utility.EnableDesibleColor(TxtRemarks, fld);

            BtnOk.Enabled = fld;
            BtnCancel.Enabled = fld;

            Grid.Enabled = fld;

            if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
            {
                if (ClsGlobal.FinanceVoucherDateControlVal == 'Y')
                {
                    TxtMiti.Enabled = true;
                    Utility.EnableDesibleDateColor(TxtMiti, true);
                    TxtDate.Enabled = true;
                    Utility.EnableDesibleDateColor(TxtDate, true);
                }
                else
                {
                    TxtMiti.Enabled = false;
                    Utility.EnableDesibleDateColor(TxtMiti, false);
                    TxtDate.Enabled = false;
                    Utility.EnableDesibleDateColor(TxtDate, false);
                }

                if (ClsGlobal.FinanceCurrencyControlVal == 'Y')
                {
                    TxtCurrency.Enabled = true;
                    Utility.EnableDesibleColor(TxtCurrency, true);
                    BtnCurrencySearch.Enabled = true;
                    TxtCurrencyRate.Enabled = true;
                    Utility.EnableDesibleColor(TxtCurrencyRate, true);
                }
                else
                {

                    TxtCurrency.Enabled = false;
                    Utility.EnableDesibleColor(TxtCurrency, false);
                    BtnCurrencySearch.Enabled = false;
                    TxtCurrencyRate.Enabled = false;
                    Utility.EnableDesibleColor(TxtCurrencyRate, false);
                }

				if (ClsGlobal.FinanceSubledgerControlVal == 'Y')
				{
					TxtSubledger.Enabled = true;
					TxtSubledger.BackColor = Color.White;
					BtnSearchSubledger.Enabled = true;
				}
				else
				{
					TxtSubledger.Enabled = false;
					TxtSubledger.BackColor = SystemColors.Control;
					BtnSearchSubledger.Enabled = false;
				}

				if (ClsGlobal.FinanceDepartmentControlVal == 'Y')
                {
                    TxtDepartment.Enabled = true;
                    TxtDepartment.BackColor = Color.White;
                    BtnSearchDepartment.Enabled = true;
                }
                else
                {
                    TxtDepartment.Enabled = false;
                    TxtDepartment.BackColor = SystemColors.Control;
                    BtnSearchDepartment.Enabled = false;
                }

                if (ClsGlobal.FinanceRemarksControlVal == 'Y')
                {
                    TxtRemarks.Enabled = true;
                    Utility.EnableDesibleColor(TxtRemarks, true);
                }
                else
                {
                    TxtRemarks.Enabled = false;
                    Utility.EnableDesibleColor(TxtRemarks, false);
                }
            }
            else
            {
                TxtMiti.Enabled = fld;
                TxtDate.Enabled = fld;
                TxtCurrency.Enabled = fld;
                Utility.EnableDesibleColor(TxtCurrency, fld);
                TxtCurrencyRate.Enabled = fld;
                Utility.EnableDesibleColor(TxtCurrencyRate, fld);
                TxtDepartment.Enabled = fld;
				TxtSubledger.Enabled = fld;
                TxtRemarks.Enabled = fld;
            }

            if (BtnNew.Enabled == true)
                BtnNew.Focus();
            else if (TxtVoucherNo.Enabled == true)
                TxtVoucherNo.Focus();

            if (TxtGridGeneralLedger.Visible == true)
            {
                GridControlMode(false);
                Grid.Focus();
            }

            if (_objUDF.CheckUDFExists("Debit Note") == 0)
            {
                BtnUDF.Visible = false;
            }
            else
            {
                BtnUDF.Visible = true;
                BtnUDF.Enabled = false;
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
            LblBalance.Text = "";
            LblCreditLimit.Text = "";
            LblNetAmount.Text = "";
            LblLocalNetAmount.Text = "";
            LblCurrentBalance.Text = "";
            Grid.Rows.Clear();
            Grid.Rows.Add();
			TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
			TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
		}

        #region ------------------ GRID EVENT -------------------------

        private void TxtGridGeneralLedger_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtGridGeneralLedger) return;
            if (TxtGridGeneralLedger.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtGridGeneralLedger.Text))
            {
                if (Grid.Rows.Count <= 1)
                {
                    MessageBox.Show("General ledger cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtGridGeneralLedger.Focus();
                }
                else
                    GridControlMode(false);
            }

            if (!string.IsNullOrEmpty(TxtGridGeneralLedger.Text))
            {
                ClsGlobal.GLDesc = TxtGridGeneralLedger.Text;
                if (ClsGlobal.BranchId != 0)
                    _objLedger.GetSingleLedger(TxtGridGeneralLedger.Text, date, ClsGlobal.BranchId);
                else
                    _objLedger.GetSingleLedger(TxtGridGeneralLedger.Text, date, 0);

                if (_objLedger.Model.CurrentBal >= 0)
                    LblBalance.Text = ClsGlobal.DecimalFormate(_objLedger.Model.CurrentBal, 1, ClsGlobal._AmountDecimalFormat).ToString() + " Dr";
                else
                    LblBalance.Text = ClsGlobal.DecimalFormate(Math.Abs(_objLedger.Model.CurrentBal), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Cr";
                LblLedgerCode.Text = _objLedger.Model.GlShortName;

                TxtGridSubLedger.GlDesc = TxtGridGeneralLedger.Text;
            }
        }

        private void TxtGridSubLedger_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtGridSubLedger) return;
            LblSubLedgerCode.Text = "";

            if ((ClsGlobal.FinanceMSubledgerControlVal == 'Y' || _objLedger.CheckGlContainsSubledger(TxtGridGeneralLedger.Text) == "Y") && (string.IsNullOrEmpty(TxtGridSubLedger.Text)) && (!string.IsNullOrEmpty(TxtGridGeneralLedger.Text)))
            {
                ClsGlobal.MandatoryMsg("Sub Ledger");
                TxtGridSubLedger.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(TxtGridSubLedger.Text))
            {
                _objSubLedger.GetSingleSubledger(TxtGridSubLedger.Text);
                LblSubLedgerCode.Text = _objSubLedger.Model.SubledgerShortName;
            }
        }

        private void TxtGridDepartment_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Tag.ToString()))
            {
                if (ClsGlobal.FinanceMDepartmentItemControlVal == 'Y' && (string.IsNullOrEmpty(TxtGridDepartment.Text) || TxtGridDepartment.Text == "||"))
                {
                    ClsGlobal.MandatoryMsg("Department");
                    TxtGridDepartment.Focus();
                    return;
                }
            }
        }     

        private void TxtGridAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string partyname = TxtGridGeneralLedger.Text;

            decimal.TryParse(TxtGridAmount.Text, out decimal Amt);
            if (TxtGridNarration.Visible != true)
            {
                if (!string.IsNullOrEmpty(TxtGridAmount.Text) )
                {
                    if (Amt > 0 )
                    {
                        this._IsVatReg = 'N';
                        if (TxtGridGeneralLedger.Text == _objLedger.VatEntryLedger())
                        {
                            DialogResult dialog = MessageBox.Show("Do You Want This Entry In Vat Register ?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                                this._IsVatReg = 'Y';
                            else
                                this._IsVatReg = 'N';
                        }

                        if (SetTextBoxValueToGrid() == true)
                        {
                            if (Grid.CurrentRow.Index == (Grid.Rows.Count - 1))
                            {
                                Grid.Rows.Add();
                                Grid.CurrentCell = Grid.Rows[Grid.Rows.Count - 1].Cells["GeneralLedger"];
                            }
                            else
                            {
                                Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["GeneralLedger"];
                            }

                            //#region ---------------- UDF --------------------

                            //int _sn = int.Parse(Grid.Rows[Grid.CurrentRow.Index - 1].Cells["SNo"].Value.ToString());

                            //if (ClsGlobal.UDFDetailsDataTable.Rows.Count > 0)
                            //{
                            //    DataRow[] rows = ClsGlobal.UDFDetailsDataTable.Select("SNO ='" + _sn + "'");

                            //    if (rows.Count() > 0)
                            //    {
                            //        ClsGlobal.UDFExistingDataTableDetails.Reset();
                            //        ClsGlobal.UDFExistingDataTableDetails = ClsGlobal.UDFDetailsDataTable.Clone();
                            //        foreach (DataRow item in rows)
                            //        {
                            //            ClsGlobal.UDFExistingDataTableDetails.ImportRow(item);
                            //        }

                            //        foreach (var row in rows) { row.Delete(); }
                            //    }
                            //}

                            //DataTable dt = _objUDF.GetByEntryModule("Debit Note Details");
                            //if (dt.Rows.Count > 0)
                            //{
                            //    FrmUDFDetailEntry frm = new FrmUDFDetailEntry("Debit Note Details", _VoucherNo, 0);
                            //    frm.ShowDialog();
                            //}

                            //ClsGlobal.UDFExistingDataTableDetails.Rows.Clear();

                            //DataRow dr = ClsGlobal.UDFDetailsDataTable.NewRow();
                            //if (ClsGlobal.UDFCodeArrayDetails.Count() > 0)
                            //{
                            //    dr[0] = _sn;
                            //    for (int i = 0; i < ClsGlobal.UDFCodeArrayDetails.Count(); i++)
                            //    {
                            //        if (i == 0)
                            //        {
                            //            dr[i + 1] = ClsGlobal.UDFCodeArrayDetails[i];
                            //            dr[i + 2] = ClsGlobal.UDFDataArrayDetails[i];
                            //        }
                            //        else
                            //        {
                            //            dr[i + 2] = ClsGlobal.UDFCodeArrayDetails[i];
                            //            dr[i + 3] = ClsGlobal.UDFDataArrayDetails[i];
                            //        }
                            //    }

                            //    ClsGlobal.UDFDetailsDataTable.Rows.Add(dr);
                            //}
                            //ClsGlobal.UDFCodeArrayDetails.Clear();
                            //ClsGlobal.UDFDataArrayDetails.Clear();

                            //#endregion

                            GridControlMode(true);
                        }
                        LblLedgerCode.Text = ""; LblBalance.Text = ""; LblSubLedgerCode.Text = ""; 
                    }
                }
                else
                {
                    if (TxtGridAmount.Visible == true)
                        TxtGridAmount.Focus();                  
                    return;
                }
            }
        }

        private void TxtGridNarration_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string partyname = TxtGridGeneralLedger.Text;
            decimal.TryParse(TxtGridAmount.Text, out decimal Amt);

            if (!string.IsNullOrEmpty(TxtGridAmount.Text))
            {
                if (Amt > 0)
                {
                    this._IsVatReg = 'N';
                    if (TxtGridGeneralLedger.Text == _objLedger.VatEntryLedger())
                    {
                        DialogResult dialog = MessageBox.Show("Do You Want This Entry In Vat Register ?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                            this._IsVatReg = 'Y';
                        else
                            this._IsVatReg = 'N';
                    }

                    if (SetTextBoxValueToGrid() == true)
                    {
                        if (Grid.CurrentRow.Index == (Grid.Rows.Count - 1))
                        {
                            Grid.Rows.Add();
                            Grid.CurrentCell = Grid.Rows[Grid.Rows.Count - 1].Cells["GeneralLedger"];
                        }
                        else
                        {
                            Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["GeneralLedger"];
                        }

                        //#region ---------------- UDF --------------------

                        //int _sn = int.Parse(Grid.Rows[Grid.CurrentRow.Index - 1].Cells["SNo"].Value.ToString());

                        //if (ClsGlobal.UDFDetailsDataTable.Rows.Count > 0)
                        //{
                        //    DataRow[] rows = ClsGlobal.UDFDetailsDataTable.Select("SNO ='" + _sn + "'");

                        //    if (rows.Count() > 0)
                        //    {
                        //        ClsGlobal.UDFExistingDataTableDetails.Reset();
                        //        ClsGlobal.UDFExistingDataTableDetails = ClsGlobal.UDFDetailsDataTable.Clone();
                        //        foreach (DataRow item in rows)
                        //        {
                        //            ClsGlobal.UDFExistingDataTableDetails.ImportRow(item);
                        //        }

                        //        foreach (var row in rows) { row.Delete(); }
                        //    }
                        //}

                        //DataTable dt = _objUDF.GetByEntryModule("Debit Note Details");
                        //if (dt.Rows.Count > 0)
                        //{
                        //    FrmUDFDetailEntry frm = new FrmUDFDetailEntry("Debit Note Details", _VoucherNo, 0);
                        //    frm.ShowDialog();
                        //}

                        //ClsGlobal.UDFExistingDataTableDetails.Rows.Clear();

                        //DataRow dr = ClsGlobal.UDFDetailsDataTable.NewRow();
                        //if (ClsGlobal.UDFCodeArrayDetails.Count() > 0)
                        //{
                        //    dr[0] = _sn;
                        //    for (int i = 0; i < ClsGlobal.UDFCodeArrayDetails.Count(); i++)
                        //    {
                        //        if (i == 0)
                        //        {
                        //            dr[i + 1] = ClsGlobal.UDFCodeArrayDetails[i];
                        //            dr[i + 2] = ClsGlobal.UDFDataArrayDetails[i];
                        //        }
                        //        else
                        //        {
                        //            dr[i + 2] = ClsGlobal.UDFCodeArrayDetails[i];
                        //            dr[i + 3] = ClsGlobal.UDFDataArrayDetails[i];
                        //        }
                        //    }

                        //    ClsGlobal.UDFDetailsDataTable.Rows.Add(dr);
                        //}
                        //ClsGlobal.UDFCodeArrayDetails.Clear();
                        //ClsGlobal.UDFDataArrayDetails.Clear();

                        //#endregion

                        //#region--------------Vouchers Adjustment---------
                        //DataTable dtt = clsGlobal.FetchDataTable("Select * from General_Ledger where Gl_Desc = '" + txtGridGeneralLedger.Text + "' and DocAdjust='Y'");
                        //if (dtt.Rows.Count > 0)
                        //{
                        //    DataTable dtvoucher = new DataTable();
                        //    decimal vamount = 0;
                        //    if (!string.IsNullOrEmpty(txtGridPayAmount.Text))
                        //        decimal.TryParse(txtGridPayAmount.Text, out vamount);
                        //    else
                        //        decimal.TryParse(txtGridRecAmount.Text, out vamount);

                        //    if (txtVoucherNo.Text == "Auto")
                        //    {
                        //        txtVoucherNo.Text = objDocNumScheme.GetNewVoucherNo(DocumentScheme);
                        //    }
                        //    string vouchertype = "";
                        //    if (Grid.Rows[Grid.CurrentRow.Index - 1].Cells["RecAmt"].Value.ToString() != "")
                        //        vouchertype = "CR";
                        //    else
                        //        vouchertype = "DR";

                        //    SwastikPOS.Entry.Vouchers.frmVoucherAdjustment frmAdj = new SwastikPOS.Entry.Vouchers.frmVoucherAdjustment(txtVoucherNo.Text, "CB", partyname, vamount, vouchertype, Grid.CurrentRow.Index);

                        //    if (_Tag == "EDIT")
                        //    {
                        //        dtVAdj.Rows.Clear();
                        //        #region-------------Get Voucher Adjustment Data-------------------
                        //        POSDAL.Entry.Vouchers.VoucherAdjustment voucherAdj = new POSDAL.Entry.Vouchers.VoucherAdjustment(SwastikPOS.Util.Database.DBConnection);

                        //        voucherAdj.voucherAdjustment.Clear();
                        //        voucherAdj.GetByInvNumber(txtVoucherNo.Text, "CB");

                        //        foreach (POSDAL.Entry.Vouchers.VoucherAdjustmentDetail Vdetail in voucherAdj.voucherAdjustment)
                        //        {
                        //            dtVAdj.Rows.Add(Vdetail.Ref_type, Vdetail.DrV_No, Vdetail.DrV_Source, Vdetail.Gl_Code, Vdetail.Br_Code, Vdetail.Adj_Amount, Vdetail.CrV_No, Vdetail.DrSno, Vdetail.CrSno, Vdetail.CrV_Source);
                        //        }
                        //        #endregion
                        //        frmAdj.dtvAdj.Rows.Clear();
                        //        frmAdj.dtvAdj = dtVAdj;
                        //    }
                        //    else if (dtVoucherAdj.Rows.Count > 0)
                        //    {
                        //        dtVAdj.Rows.Clear();
                        //        foreach (DataRow ro in dtVoucherAdj.Select("DrSno ='" + Grid.CurrentRow.Index + "' or  CrSno ='" + Grid.CurrentRow.Index + "'"))
                        //        {
                        //            dtVAdj.Rows.Add(ro["Ref_type"], ro["DrV_No"], ro["DrV_Source"], ro["Gl_Code"], ro["Br_Code"], ro["Adj_Amount"], ro["CrV_No"], ro["DrSno"], ro["CrSno"], ro["CrV_Source"]);
                        //        }
                        //        frmAdj.dtvAdj = dtVAdj;
                        //    }


                        //    frmAdj.Tag = _Tag.ToString();
                        //    frmAdj.ShowDialog();
                        //    if (frmAdj.dtvAdj.Rows.Count > 0)
                        //    {
                        //        if (dtVoucherAdj.Rows.Count > 0)
                        //        {
                        //            foreach (DataRow ro in dtVoucherAdj.Select("DrSno ='" + Grid.CurrentRow.Index + "' or  CrSno ='" + Grid.CurrentRow.Index + "'"))
                        //            {
                        //                if (ro["DrSno"].ToString() == Grid.CurrentRow.Index.ToString() || ro["CrSno"].ToString() == Grid.CurrentRow.Index.ToString())
                        //                {
                        //                    ro.Delete();

                        //                }
                        //            }
                        //            dtVoucherAdj.AcceptChanges();
                        //        }
                        //        try
                        //        {
                        //            foreach (DataRow ro in frmAdj.dtvAdj.Rows)
                        //            {
                        //                dtVoucherAdj.Rows.Add(ro["Ref_type"], ro["DrV_No"], ro["DrV_Source"], ro["Gl_Code"], ro["Br_Code"], ro["Adj_Amount"], ro["CrV_No"], ro["DrSno"], ro["CrSno"], ro["CrV_Source"]);
                        //            }
                        //        }
                        //        catch { }
                        //    }
                        //}
                        //#endregion

                        GridControlMode(true);
                    }
                    LblLedgerCode.Text = ""; LblBalance.Text = ""; LblSubLedgerCode.Text = ""; 
                }
            }
            else
            {
                if (TxtGridAmount.Visible == true)
                    TxtGridAmount.Focus();               
                return;
            }
        }

        private void TxtGridNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8)
            {
                if (TxtGridNarration.Text.Length > 0)
                {
                    int selStart = TxtGridNarration.SelectionStart;
                    string before = TxtGridNarration.Text.Substring(0, selStart);
                    TxtGridNarration.Text = TxtGridNarration.Text.Substring(0, TxtGridNarration.Text.Length - 1);
                    TxtGridNarration.SelectionStart = before.Length + 1;
                    e.Handled = true;
                }
            }
            else
            {
                if (char.IsControl(e.KeyChar)) return;

                int selStart = TxtGridNarration.SelectionStart;
                string before = TxtGridNarration.Text.Substring(0, selStart);
                string after = TxtGridNarration.Text.Substring(before.Length);
                TxtGridNarration.Text = string.Concat(before, e.KeyChar.ToString(), after);
                TxtGridNarration.SelectionStart = before.Length + 1;
                e.Handled = true;
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //LblShortName.Text = ""; LblAltStockQty.Text = ""; LblStockQty.Text = "";
            //if (Grid.CurrentRow.Cells["Particular"].Value != null)
            //{
            //    _objProduct.GetSingleProduct(Grid.CurrentRow.Cells["Particular"].Value.ToString());
            //    LblShortName.Text = _objProduct.Model.ProductShortName;
            //}

            //if (Grid.CurrentRow.Cells["Godown"].Value != null)
            //{
            //    if (Grid.CurrentRow.Cells["Godown"].Value.ToString() != "")
            //    {
            //        _objGodown.GetSingleGodown(Grid.CurrentRow.Cells["Godown"].Value.ToString());
            //    }
            //}

            //-------- START DELETE ROW --------------
            if (Grid.Columns[e.ColumnIndex].Name == "Action")
            {
                if (TxtGridGeneralLedger.Visible == true)
                {
                    GridControlMode(false);
                    Grid.Focus();
                }
                if (Grid.Rows[Grid.CurrentRow.Index].Cells["SNo"].Value != null)
                {
                    //int _sn = int.Parse(Grid.Rows[Grid.CurrentRow.Index].Cells["SNo"].Value.ToString());
                    //DataRow[] rows = ClsGlobal.UDFDtDtl.Select("SNO ='" + _sn + "'");
                    //foreach (var row in rows) { row.Delete(); } // delete row from clsGlobal.UDFDtDtl againest _sn

                    //ClsGlobal.UDFDtDtl.DefaultView.Sort = "SNO ASC";
                    //ClsGlobal.UDFDtDtl = ClsGlobal.UDFDtDtl.DefaultView.ToTable();

                    //re set sn in clsGlobal.UDFDtDtl
                    //for (int i = 0; i < ClsGlobal.UDFDtDtl.Rows.Count; i++)
                    //{
                    //    ClsGlobal.UDFDtDtl.Rows[i]["SNO"] = (i + 1).ToString();
                    //}
                }
                Grid.Rows.RemoveAt(e.RowIndex);
                //CalTotal();
            }
            //-------- END DELETE ROW --------------
        //}

        //    //if (Grid.CurrentRow.Cells["SubLedger"].Value != null)
            //{
            //    if (Grid.CurrentRow.Cells["SubLedger"].Value.ToString() != "")
            //    {

            //        _objSubLedger.GetSingleSubledger(Grid.CurrentRow.Cells["SubLedger"].Value.ToString());
            //        LblSubLedgerCode.Text = _objSubLedger.Model.SubledgerShortName;
            //    }
            //}
        }
        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            LblLedgerCode.Text = ""; LblBalance.Text = ""; LblSubLedgerCode.Text = "";
            if (Grid.Rows.Count > 0)
            {
                if (Grid.CurrentRow.Cells["GeneralLedger"].Value != null)
                {
                    if (!string.IsNullOrEmpty(Grid.CurrentRow.Cells["GeneralLedger"].Value.ToString()))
                    {
                       // LblLedgerCode.Text = Grid.CurrentRow.Cells["ProductShortName"].Value.ToString();
                        //LblBalance.Text = Grid.CurrentRow.Cells["AltStockQty"].Value.ToString();
                        //LblStockQty.Text = Grid.CurrentRow.Cells["StockQty"].Value.ToString();
                    }
                }
            }
        }

        private void Grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (TxtGridGeneralLedger.Visible == true)
            {
                GridControlMode(false);
                Grid.Focus();
            }
            CalTotal();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
				if (Grid.Rows.Count == 0)
					Grid.Rows.Add();
				e.Handled = true;
                GridControlMode(true);
            }
        }

        private void CalTotal()
        {
            if (Grid.Rows.Count == 0)
            {
                Grid.Rows.Add();
                GridControlMode(false);
            }

            decimal totalAmount = 0;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                if (ro.Cells["Amount"].Value != null)
                    totalAmount += (string.IsNullOrEmpty(ro.Cells["Amount"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["Amount"].Value.ToString()));
              
                ro.Cells["SNo"].Value = Grid.Rows.IndexOf(ro) + 1;
            }
            LblNetAmount.Text = ClsGlobal.DecimalFormate(totalAmount, 1, 2);
            decimal CurrencyRate = (string.IsNullOrEmpty(TxtCurrencyRate.Text) ? 1 : Convert.ToDecimal(TxtCurrencyRate.Text)); 
            LblLocalNetAmount.Text = ClsGlobal.DecimalFormate((totalAmount * CurrencyRate), 1, 2);            
        }

        private bool SetTextBoxValueToGrid()
        {
            if (string.IsNullOrEmpty(TxtGridGeneralLedger.Text))
            {
                TxtGridGeneralLedger.Focus();
                return false;
            }
            else
            {
                DataGridViewRow ro = new DataGridViewRow();
                ro = Grid.Rows[Grid.CurrentRow.Index];
                ro.Cells["SNo"].Value = Grid.CurrentRow.Index + 1;

                ro.Cells["GeneralLedger"].Value = TxtGridGeneralLedger.Text;
                ro.Cells["LedgerId"].Value = TxtGridGeneralLedger.Tag.ToString();

                if (ClsGlobal.FinanceSubledgerControlVal == 'Y')
                {
                    ro.Cells["SubLedger"].Value = TxtGridSubLedger.Text;
                    ro.Cells["SubLedgerId"].Value = TxtGridSubLedger.Tag != null ? TxtGridSubLedger.Tag.ToString() : "0";
                }

                if (ClsGlobal.FinanceDepartmentItemControlVal == 'Y')
                {
                    ro.Cells["Department"].Value = TxtGridDepartment.Text;
                    ro.Cells["DepartmentId"].Value = TxtGridDepartment.Tag.ToString();
                }
               
                if (!string.IsNullOrEmpty(TxtGridAmount.Text))
                {
                    ro.Cells["Amount"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridAmount.Text), 1, 2);                    
                }                  
               
                ro.Cells["Narration"].Value = TxtGridNarration.Text;
                //ro.Cells["NarrationCode"].Value = TxtGridNarration.Value;
                ro.Cells["IsVatReg"].Value = _IsVatReg;
                CalTotal();
            }
            return true;
        }
        private void SetGridValueToTextBox(int row)
        {
            TxtGridGeneralLedger.Text = "";
            TxtGridGeneralLedger.Tag = "0";
            TxtGridSubLedger.Text = "";
            TxtGridSubLedger.Tag = "0";
            TxtGridDepartment.Text = "";
            TxtGridAmount.Text = "";
           
            TxtGridNarration.Text = "";

            if (Grid["GeneralLedger", row].Value != null)
            {
                TxtGridGeneralLedger.Text = Grid["GeneralLedger", row].Value.ToString();
                TxtGridGeneralLedger.Tag = Grid["LedgerId", row].Value.ToString();
            }

            if (ClsGlobal.FinanceSubledgerControlVal == 'Y')
            {
                if (Grid["SubLedger", row].Value != null)
                {
                    TxtGridSubLedger.Text = Grid["SubLedger", row].Value.ToString();
                    TxtGridSubLedger.Tag = Grid["SubLedgerId", row].Value.ToString();
                }
            }

            if (ClsGlobal.FinanceDepartmentItemControlVal == 'Y')
            {
                if (Grid["Department", row].Value != null) TxtGridDepartment.Text = Grid["Department", row].Value.ToString();
                if (Grid["DepartmentId", row].Value != null) TxtGridDepartment.Tag = Grid["DepartmentId", row].Value.ToString();
            }

            if (Grid["Amount", row].Value != null) TxtGridAmount.Text = Grid["Amount", row].Value.ToString().Replace(",", string.Empty);
            if (Grid["Narration", row].Value != null) TxtGridNarration.Text = Grid["Narration", row].Value.ToString();
        }
        private void GridControlMode(bool mode)
        {
            if (Grid.CurrentRow != null)
            {
                int currRo = Grid.CurrentRow.Index;
                int colindex = 0;
                if (mode == true)
                {
                    colindex = Grid.Columns["GeneralLedger"].Index;
                    TxtGridGeneralLedger.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridGeneralLedger.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
                    {
                        if (ClsGlobal.FinanceItemSubledgerControlVal == 'Y')
                        {
                            colindex = Grid.Columns["SubLedger"].Index;
                            TxtGridSubLedger.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                            TxtGridSubLedger.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                            Utility.EnableDesibleColor(TxtGridSubLedger, true);
                        }

                        if (ClsGlobal.FinanceDepartmentItemControlVal == 'Y')
                        {
                            colindex = Grid.Columns["Department"].Index;
                            TxtGridDepartment.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                            TxtGridDepartment.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                            Utility.EnableDesibleColor(TxtGridDepartment, true);
                        }
                        if (ClsGlobal.FinanceNarrationControlVal == 'Y')
                        {
                            colindex = Grid.Columns["Narration"].Index;
                            TxtGridNarration.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                            TxtGridNarration.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                            Utility.EnableDesibleColor(TxtGridNarration, true);
                        }

                    }
                        colindex = Grid.Columns["Amount"].Index;
                        TxtGridAmount.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                        TxtGridAmount.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                }
                SetGridValueToTextBox(currRo);
            }

            TxtGridGeneralLedger.Enabled = mode;
            TxtGridGeneralLedger.Visible = mode;

            if (mode == true)
                BtnOk.Enabled = false;
            else
                BtnOk.Enabled = true;

            if (ClsGlobal.FinanceItemSubledgerControlVal == 'Y')
                Grid.Columns["SubLedger"].Visible = true;
            else
                Grid.Columns["SubLedger"].Visible = false;

            if (ClsGlobal.FinanceDepartmentItemControlVal == 'Y')
                Grid.Columns["Department"].Visible = true;
            else
                Grid.Columns["Department"].Visible = false;

            if (ClsGlobal.FinanceNarrationControlVal == 'Y')
                Grid.Columns["Narration"].Visible = true;
            else
                Grid.Columns["Narration"].Visible = false;

            if (ClsGlobal.FinanceItemSubledgerControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
            {
                //TxtGridSubLedger.Enabled = mode;
                TxtGridSubLedger.Visible = mode;
            }
            else
            {
                // TxtGridSubLedger.Enabled = false;
                //Utility.EnableDesibleColor(TxtGridSubLedger, false);
                TxtGridSubLedger.Visible = false;
            }

            if (ClsGlobal.FinanceDepartmentItemControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
            {
                //TxtGridDepartment.Enabled = mode;
                TxtGridDepartment.Visible = mode;
            }
            else
            {
                //TxtGridDepartment.Enabled = false;
                //Utility.EnableDesibleColor(TxtGridDepartment, false);
                TxtGridDepartment.Visible = false;
            }
            if (ClsGlobal.FinanceNarrationControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
            {
                TxtGridNarration.Visible = mode;
            }
            else
            {
                TxtGridNarration.Visible = false;
            }
                TxtGridAmount.Visible = mode;
               
            if (mode == true)
            {
                TxtGridGeneralLedger.Focus();
            }
        }

        #endregion

        private void SetData(DataSet ds)
        {
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];
            TxtVoucherNo.Text = dtMaster.Rows[0]["VoucherNo"].ToString();
            _VoucherNo = dtMaster.Rows[0]["VoucherNo"].ToString();
            TxtDate.Text = dtMaster.Rows[0]["VDate"].ToString();
            date = Convert.ToDateTime(dtMaster.Rows[0]["VDate"].ToString());
            TxtMiti.Text = dtMaster.Rows[0]["VMiti"].ToString();
            TxtPartyName.Text = dtMaster.Rows[0]["GlDesc"].ToString();
            TxtPartyName.Tag = dtMaster.Rows[0]["LedgerId"].ToString();
            TxtSalesman.Text = dtMaster.Rows[0]["SalesmanDesc"].ToString();
            TxtSalesman.Tag = dtMaster.Rows[0]["SalesmanId"].ToString();
            TxtSubledger.Text = dtMaster.Rows[0]["SubledgerDesc"].ToString();
            TxtSubledger.Tag = dtMaster.Rows[0]["SubledgerId"].ToString();
            if (string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc4"].ToString()))
            {
                string[] Dept = new string[] { dtMaster.Rows[0]["DepartmentDesc1"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc2"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString() };
                TxtDepartment.Text = string.Concat(Dept);
                string[] Depttag = new string[] { dtMaster.Rows[0]["DepartmentId1"].ToString(), "|", dtMaster.Rows[0]["DepartmentId2"].ToString(), "|", dtMaster.Rows[0]["DepartmentId3"].ToString(), "|", dtMaster.Rows[0]["DepartmentId4"].ToString() };
                TxtDepartment.Tag = string.Concat(Depttag);
            }
            TxtCurrency.Text = dtMaster.Rows[0]["CurrencyDesc"].ToString();
            TxtCurrency.Tag = dtMaster.Rows[0]["CurrencyId"].ToString();
            if (!string.IsNullOrEmpty(dtMaster.Rows[0]["CurrencyDesc"].ToString()))
            {
                if (Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()) != 1)
                    TxtCurrencyRate.Text = dtMaster.Rows[0]["CurrencyRate"].ToString();
                else
                    TxtCurrencyRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtMaster.Rows[0]["CurrencyRate"].ToString()), 1, ClsGlobal._CurrencyDecimalFormat);
            }
            else
            {
                TxtCurrencyRate.Text = "";
            }
            TxtReferenceNo.Text = dtMaster.Rows[0]["ReferenceNo"].ToString();
            TxtReferenceDate.Text = dtMaster.Rows[0]["ReferenceDate"].ToString();
            TxtRemarks.Text = dtMaster.Rows[0]["Remarks"].ToString();

            foreach (DataRow dr in dtDetails.Rows)
            {
                Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["GeneralLedger"].Value = dr["GlDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["LedgerId"].Value = dr["LedgerId"].ToString();

                Grid.Rows[Grid.Rows.Count - 1].Cells["SubLedger"].Value = (dr["SubledgerDesc"].ToString() == "") ? null : dr["SubledgerDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["SubledgerId"].Value = (dr["SubledgerId"].ToString() == "") ? null : dr["SubledgerId"].ToString();

                if (string.IsNullOrEmpty(dr["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dr["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dr["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dr["DepartmentDesc4"].ToString()))
                {
                    string[] Dept = new string[] { dr["DepartmentDesc1"].ToString(), "|", dr["DepartmentDesc2"].ToString(), "|", dr["DepartmentDesc3"].ToString(), "|", dr["DepartmentDesc4"].ToString() };
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Department"].Value = string.Concat(Dept);
                    string[] Depttag = new string[] { dr["DepartmentIdDet1"].ToString(), "|", dr["DepartmentIdDet2"].ToString(), "|", dr["DepartmentIdDet3"].ToString(), "|", dr["DepartmentIdDet4"].ToString() };
                    Grid.Rows[Grid.Rows.Count - 1].Cells["DepartmentId"].Value = string.Concat(Depttag);
                }

                if (Convert.ToDecimal(dr["Amount"].ToString()) > 0)
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Amount"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(dr["Amount"].ToString()), 1, ClsGlobal._AmountDecimalFormat);
                else
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Amount"].Value = "";
                
                Grid.Rows[Grid.Rows.Count - 1].Cells["Narration"].Value = dr["Naration"].ToString();

                Grid.Rows.Add();
            }
        }
        private void TxtVoucherNo_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtVoucherNo) return;
            if (TxtVoucherNo.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtVoucherNo.Text))
            {
                MessageBox.Show("Voucher number cannot be left blank.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            if (_Tag == "NEW")
            {
                if (!string.IsNullOrEmpty(_objDebitNoteVoucher.IsExistsVNumber(TxtVoucherNo.Text)))
                {
                    MessageBox.Show("Voucher number already exist.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
			else
			{
				if (this._VoucherNo != TxtVoucherNo.Text.Trim())
				{
					this._VoucherNo = TxtVoucherNo.Text.Trim();
					DataSet ds = _objDebitNoteVoucher.GetDataDebitNoteVoucher(this._VoucherNo);
					ClearFld();
					SetData(ds);
				}
			}

		}

        private void TxtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnVoucherNoSearch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtVoucherNo, BtnVoucherNoSearch, true);
            }
        }

        private void BtnVoucherNoSearch_Click(object sender, EventArgs e)
        {
            PickList frmPickList = new PickList("DebitNoteVoucher", _SearchKey);
            if (PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    this._VoucherNo = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                    DataSet ds = _objDebitNoteVoucher.GetDataDebitNoteVoucher(this._VoucherNo);
                    ClearFld();
                    SetData(ds);
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in debit note voucher.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            TxtVoucherNo.Focus();
        }

        private void BtnSearchDepartment_Click(object sender, EventArgs e)
        {
            ClsButtonClick.DepartmentBtnClick(_SearchKey, TxtDepartment, e);
        }

        private void BtnCurrencySearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Currency", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtCurrency.Text = frmPickList.SelectedList[0]["CurrencyDesc"].ToString().Trim();
                    TxtCurrency.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["CurrencyId"].ToString().Trim());
                    TxtCurrency.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in currency.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCurrency.Focus();
                return;
            }
            _SearchKey = "";
            TxtCurrency.Focus();
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
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtCurrency, BtnCurrencySearch, false);
            }
        }

        private void TxtCurrency_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtCurrency) return;
            ClsButtonClick.CurrencyRateValidating(TxtCurrency, TxtCurrencyRate, LblNetAmount, LblLocalNetAmount, e);
        }

        private void TxtRemarks_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtRemarks) return;
            if (ClsGlobal.FinanceMRemarksControlVal == 'Y' && string.IsNullOrEmpty(TxtRemarks.Text))
            {
                MessageBox.Show("Remarks Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtRemarks.Focus();
            }
        }

        private void BtnSearchPartyName_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger.Customer,Both,LC,Vendor", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtPartyName.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtPartyName.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    _objLedger.GetSingleLedger(TxtPartyName.Text, date, ClsGlobal.BranchId);
                    if (_objLedger.Model.CurrentBal >= 0)
                    {
                        LblCurrentBalance.Text = ClsGlobal.DecimalFormate(_objLedger.Model.CurrentBal, 1, ClsGlobal._AmountDecimalFormat).ToString() + " Dr";
                    }
                    else
                    {
                        LblCurrentBalance.Text = ClsGlobal.DecimalFormate(Math.Abs(_objLedger.Model.CurrentBal), 1, ClsGlobal._AmountDecimalFormat).ToString() + " Cr";
                    }

                    TxtPartyName.SelectAll();

                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in ledger.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPartyName.Focus();
                return;
            }
            _SearchKey = "";
            TxtPartyName.Focus();
        }

        private void TxtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtPartyName.Text = frm._NewLedger;
                TxtPartyName.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPartyName, BtnSearchPartyName, false);
            }
        }

        private void BtnSearchSubledger_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSubledger.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
                    TxtSubledger.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
                    TxtSubledger.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Subledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesman.Focus();
                return;
            }
            _SearchKey = "";
            TxtSubledger.Focus();
        }

        private void TxtSubledger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmSubledger frm = new FrmSubledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSubledger.Text = frm._NewSubLedger;
                TxtSubledger.Tag = frm._SubledgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSubledger, BtnSearchSubledger, false);
            }
        }

        private void TxtSubledger_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtSubledger) return;
            if (TxtSubledger.Enabled == false) return;
            if (ClsGlobal.FinanceMSubledgerControlVal == 'Y' && string.IsNullOrEmpty(TxtSubledger.Text))
            {
                MessageBox.Show("Subledger cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSubledger.Focus();
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
                MessageBox.Show("No List Available in SalesMan !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesman.Focus();
                return;
            }
            _SearchKey = "";
            TxtSalesman.Focus();
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
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSalesman, BtnSearchSalesman, false);
            }
        }

        private void TxtSalesman_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtCurrencyRate) return;
            if (TxtCurrencyRate.Enabled == false) return;
            if (ClsGlobal.FinanceMSalesmanControlVal == 'Y' && string.IsNullOrEmpty(TxtSalesman.Text))
            {
                MessageBox.Show("Salesman cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesman.Focus();
            }
        }

        private void TxtPartyName_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtPartyName) return;
            if (TxtPartyName.Enabled == false) return;

            if (TxtPartyName.Text.Trim() == "")
            {
                MessageBox.Show("Party Name cannot be left blank.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
        }

        private void TxtDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDepartment) return;
            if (TxtDepartment.Enabled == false) return;
            if (ClsGlobal.FinanceMDepartmentControlVal == 'Y' && string.IsNullOrEmpty(TxtDepartment.Text))
            {
                MessageBox.Show("Department cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDepartment.Focus();
            }
        }

        private void TxtCurrencyRate_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtCurrencyRate) return;
            ClsButtonClick.CurrencyRateValidating(TxtCurrency, TxtCurrencyRate, LblNetAmount, LblLocalNetAmount, e);
        }
        
        private void TxtMiti_Validating(object sender, CancelEventArgs e)
        {
			if (_Tag == "" || ActiveControl == TxtMiti) return;
			ClsGlobal.MitiValidation(TxtMiti, TxtDate);
		}

        private void TxtDate_Validating(object sender, CancelEventArgs e)
        {
			if (_Tag == "" || ActiveControl == TxtDate) return;
			ClsGlobal.DateValidation(TxtDate, TxtMiti);
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
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtDepartment, BtnSearchDepartment, false);
            }
        }
    }
}
