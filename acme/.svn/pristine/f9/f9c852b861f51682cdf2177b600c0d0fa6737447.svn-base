using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.Common
{
   
    public static class ClsButtonClick
    {
       
        #region -------- BUTTON CLICK ------------
        public static void SalesManBtnClick(string _SearchKey, TextBox txtBoxName, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesMan", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    txtBoxName.Text = frmPickList.SelectedList[0]["SalesmanDesc"].ToString().Trim();
                    txtBoxName.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SalesmanId"].ToString().Trim());
                    txtBoxName.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Salesman !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxName.Focus();
                return;
            }
            
            txtBoxName.Focus();
        }
        public static void SubledgerBtnClick(string _SearchKey, TextBox txtBoxName, int LedgerId, EventArgs e)
        {
            ClsGlobal.LedgerId = LedgerId;
            PickList frmPickList = new PickList("Subledger", _SearchKey);
            if (PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    txtBoxName.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
                    txtBoxName.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
                    txtBoxName.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Subledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxName.Focus();
                return;
            }
            txtBoxName.Focus();
        }
        public static void DepartmentBtnClick(string _SearchKey, TextBox txtBoxName, EventArgs e)
        {
            if (_SearchKey == "Escape") _SearchKey = "";
             IDepartment _objDepartment = new ClsDepartment();
            DataTable dt = _objDepartment.DepartmentLevel();
            if (dt.Rows.Count > 0)
            {
                DataRow[] result1 = dt.Select("Departmentlevel = 'I'");
                if (result1.Length > 0)
                {
                    PickList frmPickList = new PickList("DepartmentI", _SearchKey);
                    frmPickList.ShowDialog();
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        txtBoxName.Text = frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        txtBoxName.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        txtBoxName.Text = "";
                        txtBoxName.Tag = "";
                    }
                    frmPickList.Dispose();
                }
                
                DataRow[] result2 = dt.Select("Departmentlevel = 'II'");
                if (result2.Length > 0)
                {
                    _SearchKey = "";
                    PickList frmPickList = new PickList("DepartmentII", _SearchKey);
                    frmPickList.ShowDialog();
                    txtBoxName.Text = txtBoxName.Text.Trim() + '|';
                    txtBoxName.Tag = txtBoxName.Tag.ToString().Trim() + '|';
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        txtBoxName.Text = txtBoxName.Text + frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        txtBoxName.Tag = txtBoxName.Tag.ToString() + Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        string[] _arr1 = txtBoxName.Text.Split('|');
                        string[] _arr2 = txtBoxName.Tag.ToString().Split('|');
                        txtBoxName.Text = _arr1[0] + "|";
                        txtBoxName.Tag = _arr2[0] + "|";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    string[] _arr1 = txtBoxName.Text.Split('|');
                    string[] _arr2 = txtBoxName.Tag.ToString().Split('|');
                    txtBoxName.Text = _arr1[0] + "|";
                    txtBoxName.Tag = _arr2[0] + "|";
                }
                
                DataRow[] result3 = dt.Select("Departmentlevel = 'III'");
                if (result3.Length > 0)
                {
                    _SearchKey = "";
                    PickList frmPickList = new PickList("DepartmentIII", _SearchKey);
                    frmPickList.ShowDialog();
                    txtBoxName.Text = txtBoxName.Text.Trim() + '|';
                    txtBoxName.Tag = txtBoxName.Tag.ToString().Trim() + '|';
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        txtBoxName.Text = txtBoxName.Text + frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        txtBoxName.Tag = txtBoxName.Tag.ToString() + Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        string[] _arr1 = txtBoxName.Text.Split('|');
                        string[] _arr2 = txtBoxName.Tag.ToString().Split('|');
                        txtBoxName.Text = _arr1[0] + "|" + _arr1[1] + "|";
                        txtBoxName.Tag = _arr2[0] + "|" + _arr2[1] + "|";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    string[] _arr1 = txtBoxName.Text.Split('|');
                    string[] _arr2 = txtBoxName.Tag.ToString().Split('|');
                    txtBoxName.Text = _arr1[0] + "|" + _arr1[1] + "|";
                    txtBoxName.Tag = _arr2[0] + "|" + _arr2[1] + "|";
                }
                
                DataRow[] result4 = dt.Select("Departmentlevel = 'IV'");
                if (result4.Length > 0)
                {
                    _SearchKey = "";
                    PickList frmPickList = new PickList("DepartmentIV", _SearchKey);
                    frmPickList.ShowDialog();
                    txtBoxName.Text = txtBoxName.Text.Trim() + '|';
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        txtBoxName.Text = txtBoxName.Text + frmPickList.SelectedList[0]["DepartmentDesc"].ToString().Trim();
                        txtBoxName.Tag = txtBoxName.Tag.ToString() + Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim());
                    }
                    else
                    {
                        string[] _arr1 = txtBoxName.Text.Split('|');
                        string[] _arr2 = txtBoxName.Tag.ToString().Split('|');
                        txtBoxName.Text = _arr1[0] + "|" + _arr1[1] + "|" + _arr1[2] + "|";
                        txtBoxName.Tag = _arr2[0] + "|" + _arr2[1] + "|" + _arr2[2] + "|";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    string[] _arr1 = txtBoxName.Text.Split('|');
                    string[] _arr2 = txtBoxName.Tag.ToString().Split('|');
                    txtBoxName.Text = _arr1[0] + "|" + _arr1[1] + "|" + _arr1[2] + "|";
                    txtBoxName.Tag = _arr2[0] + "|" + _arr2[1] + "|" + _arr2[2] + "|";
                }
            }
        }
        public static void CurrencyBtnClick(string _SearchKey, TextBox txtBoxName, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Currency", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    txtBoxName.Text = frmPickList.SelectedList[0]["CurrencyDesc"].ToString().Trim();
                    txtBoxName.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["CurrencyId"].ToString().Trim());
                    txtBoxName.SelectAll();

                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Currency !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxName.Focus();
                return;
            }
            txtBoxName.Focus();
        }

        public static void SalesVoucherBtnClick(string _SearchKey,string _Tag, TextBox txtBoxName, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesVoucher", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    txtBoxName.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();                  
                    txtBoxName.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Sales VoucherNo !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxName.Focus();
                return;
            }
            txtBoxName.Focus();
        }
        public static void SalesOrderVoucherBtnClick(string _SearchKey, string _Tag, TextBox txtBoxName, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesOrderVoucher", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    txtBoxName.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                    txtBoxName.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Sales Order VoucherNo !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxName.Focus();
                return;
            }
            txtBoxName.Focus();
        }


        public static void PartyInfoBtnClick(string _SearchKey, TextBox txtBoxName,string ModuleName, EventArgs e)
        {

            Common.PickList frmPickList = new Common.PickList("PartyInfo."+ ModuleName, _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    txtBoxName.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    txtBoxName.Tag = frmPickList.SelectedList[0]["LedgerId"].ToString().Trim();
                    txtBoxName.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Party.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxName.Focus();
                return;
            }
            txtBoxName.Focus();
        }

        #endregion

        #region ------------ VALIDATING ---------
        public static void CurrencyValidating(TextBox TxtCurrency, TextBox TxtCurrencyRate, TextBox LblNetAmt, TextBox LblLocalNetAmt,string ModuleName, CancelEventArgs e)
        {
            if (TxtCurrency.Enabled == false) return;
            if ((ModuleName== "SALES" ? ClsGlobal.SalesMCurrencyControlVal == 'Y': ClsGlobal.PurchaseMCurrencyControlVal=='Y') && string.IsNullOrEmpty(TxtCurrency.Text))
            {
                MessageBox.Show("Currency Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCurrency.Focus();
            }

            if (string.IsNullOrEmpty(TxtCurrency.Text))
            {
                TxtCurrencyRate.Text = "";
                decimal.TryParse(LblNetAmt.Text, out decimal _NetAmt);
                LblLocalNetAmt.Text = ClsGlobal.DecimalFormate((_NetAmt * 1), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
        }
        public static void CurrencyRateValidating(TextBox TxtCurrency,TextBox TxtCurrencyRate, TextBox LblNetAmt, TextBox LblLocalNetAmt, CancelEventArgs e)
        {
            if (TxtCurrencyRate.Enabled == false) return;

            if (!string.IsNullOrEmpty(TxtCurrency.Text) && string.IsNullOrEmpty(TxtCurrencyRate.Text))
            {
                MessageBox.Show("Currency Rate Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCurrencyRate.Focus();
                return;
            }
            decimal.TryParse(TxtCurrencyRate.Text, out decimal CurrencyRate);
            if (!string.IsNullOrEmpty(TxtCurrency.Text) && CurrencyRate <= 0)
            {
                MessageBox.Show("Currency Rate Cannot Zero Value.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCurrencyRate.Focus();
            }
            else if (!string.IsNullOrEmpty(TxtCurrency.Text) && CurrencyRate > 0)
            {
                decimal.TryParse(LblNetAmt.Text, out decimal _NetAmt);
                LblLocalNetAmt.Text = ClsGlobal.DecimalFormate((_NetAmt * CurrencyRate), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
        }

        public static void SalesmanValidating(TextBox TxtSalesman, CancelEventArgs e)
        {
            if (TxtSalesman.Enabled == false) return;
            if (ClsGlobal.PurchaseMSalesmanControlVal == 'Y' && string.IsNullOrEmpty(TxtSalesman.Text))
            {
                MessageBox.Show("Salesman Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesman.Focus();
            }
        }

        public static void SubledgerValidating(TextBox TxtSubledger, bool _isSubledgerRequired, string ModuleName, CancelEventArgs e)
        {
            if (TxtSubledger.Enabled == false) return;
            if (((ModuleName == "SALES" ? ClsGlobal.SalesMSubledgerControlVal == 'Y' : ClsGlobal.PurchaseMSubledgerControlVal == 'Y') || _isSubledgerRequired == true) && string.IsNullOrEmpty(TxtSubledger.Text))
            {
                MessageBox.Show("Sub Ledger Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSubledger.Focus();
            }
        }

        public static void VoucherNumberValidating(TextBox txtVoucherNumber, CancelEventArgs e)
        {
            if (txtVoucherNumber.Enabled == false) return;
            if (string.IsNullOrEmpty(txtVoucherNumber.Text.Trim()))
            {
                MessageBox.Show("Voucher Number Cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                txtVoucherNumber.Focus();
                return;
            }
        }

        public static void RemarksValidating(TextBox TxtRemarks,string ModuleName, CancelEventArgs e)
        {
            if (TxtRemarks.Enabled == false) return;
            if ((ModuleName == "SALES" ? ClsGlobal.SalesMRemarksControlVal == 'Y' : ClsGlobal.SalesMRemarksControlVal == 'Y') && string.IsNullOrEmpty(TxtRemarks.Text.Trim()))
            {
                MessageBox.Show("Remarks Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtRemarks.Focus();
            }
        }
        #endregion
    }
}
