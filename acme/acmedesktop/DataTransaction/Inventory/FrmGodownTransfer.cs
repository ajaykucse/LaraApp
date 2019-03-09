using acmedesktop.Common;
using acmedesktop.MasterSetup;
using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction;
using DataAccessLayer.Interface.Common;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.Finance
{
    public partial class FrmGodownTransfer : Form
    {
        private MyGridPickListTextBox TxtGridProductList;
        private MyGridPickListTextBox TxtGridToGodown;
        private MyGridTextBox TxtGirdFromGodown;
        private MyGridPickListTextBox TxtGridDepartment;
        private MyGridNumericTextBox TxtGridAltQty;
        private MyGridTextBox TxtGridAltUnit;
        private MyGridNumericTextBox TxtGridQty;
        private MyGridTextBox TxtGridQtyUnit;
        private MyGridNumericTextBox TxtGridRate;
        private MyGridNumericTextBox TxtGridAmount;
        private MyGridNumericTextBox TxtGridFreeQty;

        private ClsCommon _objCommon = new ClsCommon();

        private IProduct _objProduct = new ClsProduct();
        private IDepartment _objDepartment = new ClsDepartment();
        private IGodown _objGodown = new ClsGodown();
        private IDateMiti _objDate = new ClsDateMiti();
        private IUdfMaster _objUDF = (IUdfMaster)new ClsUdfMaster();

        private char DocType = 'B';
        private char _IsVatReg = 'N';
        private string _VoucherNo = "";
        private string _Tag = "";
        private string _SearchKey = "";
        private DateTime date;
        public FrmGodownTransfer()
        {
            InitializeComponent();
            _Tag = "";

            #region --------------------------------------------- Event Of Grid ---------------------------------------------
            TxtGridProductList = new MyGridPickListTextBox(Grid);
            TxtGridProductList.Validating += new System.ComponentModel.CancelEventHandler(TxtGridProductList_Validating);
            TxtGridProductList.PickListType = MyGridPickListTextBox.ListType.Product;

            TxtGridToGodown = new MyGridPickListTextBox(Grid);
            TxtGridToGodown.Validating += new System.ComponentModel.CancelEventHandler(TxtGridSubLedger_Validating);
            TxtGridToGodown.PickListType = MyGridPickListTextBox.ListType.GoDown;

            TxtGirdFromGodown = new MyGridTextBox(Grid);
            TxtGirdFromGodown.Validating += new System.ComponentModel.CancelEventHandler(TxtGirdFromGodown_Validating);
            

            TxtGridDepartment = new MyGridPickListTextBox(Grid);
            TxtGridDepartment.Validating += new System.ComponentModel.CancelEventHandler(TxtGridDepartment_Validating);
            TxtGridDepartment.PickListType = MyGridPickListTextBox.ListType.Department;

            TxtGridAltQty = new MyGridNumericTextBox(Grid);
            this.TxtGridAltQty.TextChanged += new System.EventHandler(TxtGridAltQty_TextChanged);

            TxtGridAltUnit = new MyGridTextBox(Grid);
            TxtGridAltUnit.Validating += new System.ComponentModel.CancelEventHandler(TxtGridAltUnit_Validating);

            TxtGridQty = new MyGridNumericTextBox(Grid);
            this.TxtGridQty.TextChanged += new System.EventHandler(TxtGridQty_TextChanged);

            TxtGridQtyUnit = new MyGridTextBox(Grid);
            TxtGridQtyUnit.Validating += new System.ComponentModel.CancelEventHandler(TxtGridQtyUnit_Validating);

            TxtGridAmount = new MyGridNumericTextBox(Grid);
            this.TxtGridAmount.TextChanged += new System.EventHandler(TxtGridAmount_TextChanged);

            //GridControlMode(false);
            #endregion
        }

       
        private void FrmGodownTransfer_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();
        }

        private void FrmGodownTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != Grid)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridProductList.Visible == true)
                {
                    //GridControlMode(false);
                    Grid.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    TxtDate.Text = "";
                    BtnCancel.PerformClick();
                }
                else if (BtnCancel.Enabled == false)
                {
                    BtnExit.PerformClick();
                }

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
          
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

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
            Dispose();
        }

        private void BtnUDF_Click(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
        }

        public void ControlEnableDisable(bool btn, bool fld)
        {
            
        }
        private void ClearFld()
        {
           
        }



        #region ------------------ GRID EVENT -------------------------

        private void TxtGridProductList_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtGridProductList)
            {
                return;
            }

            if (TxtGridProductList.Enabled == false)
            {
                return;
            }

            LblTotalAltQty.Text = "";
            if (string.IsNullOrEmpty(TxtGridProductList.Text))
            {
                if (Grid.Rows.Count <= 1)
                {
                    MessageBox.Show("General Ledger Description Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtGridProductList.Focus();
                }
                else
                {
                   //GridControlMode(false);
                }
            }
            else
            {
                if (TxtGridProductList.Text == TxtGodown.Text)
                {
                    TxtGridProductList.Text = "";
                    TxtGridProductList.Focus();
                }
            }

            if (!string.IsNullOrEmpty(TxtGridProductList.Text))
            {
            }
        }

        private void TxtGridSubLedger_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void TxtGridSalesman_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
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

        private void TxtGridRecAmount_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtGridPayAmount_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtGridAmount_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TxtGridQtyUnit_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TxtGridQty_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TxtGridAltUnit_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TxtGirdFromGodown_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TxtGridAltQty_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void Grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Grid_Enter(object sender, EventArgs e)
        {

        }

        private void Grid_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Grid_Leave(object sender, EventArgs e)
        {
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Grid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
          
        }
        private void CalTotal()
        {
           
        }

        #endregion

        private void TxtVoucherNo_Validating(object sender, CancelEventArgs e)
        {
        }

        private void TxtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void TxtCashBank_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void BtnCashBankSearch_Click(object sender, EventArgs e)
        {
        }

        private void TxtCashBank_Validating(object sender, CancelEventArgs e)
        {
        }

        private void BtnVoucherNoSearch_Click(object sender, EventArgs e)
        {
        }

        private void SetData(DataSet ds)
        {
        }
    }
}