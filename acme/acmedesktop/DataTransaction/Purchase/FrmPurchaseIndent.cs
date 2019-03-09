using acmedesktop.Common;
using acmedesktop.DataTransaction.Sales;
using acmedesktop.MasterSetup;
using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction.Purchase;
using DataAccessLayer.Interface.DataTransaction.Purchase;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.MasterSetup;
using DataAccessLayer.SystemSetting;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseIndent;

namespace acmedesktop.DataTransaction.Purchase
{
    public partial class FrmPurchaseIndent : Form
    {
        private MyGridPickListTextBox TxtGridParticular;
        private MyGridNumericTextBox TxtGridAltQty;
        private MyGridPickListTextBox TxtGridAltUOM;
        private MyGridNumericTextBox TxtGridQty;
        private MyGridPickListTextBox TxtGridQtyUOM;
        private MyGridTextBox TxtGridNarration;
		private bool _GridControlMode { get; set; }

        private ClsDateMiti _objDate = new ClsDateMiti();

        //DateTime date, Refdate;
        private ClsGeneralLedger _objLedger = new ClsGeneralLedger();
        private IUdfMaster _objUDF = new ClsUdfMaster();
        private int _IsSaveAndPrint = 0;
        private int Indexcount;
        private string _Tag = "", _dtBillTermExists = "", _dtProductTermExists = "", _VoucherNo = "", _SearchKey = "";
        private bool _StartTermCalculation = false, _isSalesQuotationUsed = false;
		private IPurchaseIndent _objPurchaseIndent = new ClsPurchaseIndent();
        private IGeneralLedger _objGeneralLedger = new ClsGeneralLedger();
        private DataTable DTUDFDetails = new DataTable();
        private DataTable DtUDFMaster = new DataTable();
        private IDocPrintSetting _objDocPrintSetting = new ClsDocPrintSetting();
		private int _DocId = 0;

		public FrmPurchaseIndent()
        {
            InitializeComponent();

            TxtGridParticular = new MyGridPickListTextBox(Grid);
            TxtGridParticular.Validating += new System.ComponentModel.CancelEventHandler(TxtGridParticular_Validating);
            TxtGridParticular.PickListType = MyGridPickListTextBox.ListType.Product;


            TxtGridAltQty = new MyGridNumericTextBox(Grid);
            TxtGridAltQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridAltQty_Validating);
            TxtGridAltQty.TextChanged += new System.EventHandler(TxtGridAltQty_TextChanged);

            TxtGridAltUOM = new MyGridPickListTextBox(Grid)
            {
                PickListType = MyGridPickListTextBox.ListType.ProductUnit
            };


            TxtGridQty = new MyGridNumericTextBox(Grid);
            TxtGridQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridQty_Validating);
            TxtGridQtyUOM = new MyGridPickListTextBox(Grid)
            {
                PickListType = MyGridPickListTextBox.ListType.ProductUnit
            };

            TxtGridNarration = new MyGridTextBox(Grid);
            TxtGridNarration.Validating += new System.ComponentModel.CancelEventHandler(TxtGridNarration_Validating);

            GridControlMode(false);
            _GridControlMode = true;

            _IsSaveAndPrint = _objDocPrintSetting.CheckIsSaveAndPrint("PI");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Purchase Indent [EDIT]";
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "NEW";
            Text = "Purchase Indent [NEW]";
            ControlEnableDisable(false, true);
            TxtVoucherNo.Focus();
            if (ClsGlobal.DateType == "M")
            {
                TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
            }
            else
            {
                TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
                TxtMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtDate.Text));
            }
            if (TxtDate.Enabled == true)
            {
                Utility.GetVoucherNo1("Purchase Indent", TxtVoucherNo, TxtDate, _Tag, "",_DocId);
            }
            else
            {
                Utility.GetVoucherNo2("Purchase Indent", TxtVoucherNo, txtRequestedBy, _Tag, "",_DocId);
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Grid.Enabled = false;
            Text = "Purchase Indent [DELETE]";
            TxtVoucherNo.Enabled = true;
            BtnVoucherNoSearch.Enabled = true;
            TxtVoucherNo.Focus();
            BtnOk.Enabled = true;
            BtnCancel.Enabled = true;
        }


        #region ----------GridFunction--------------

        private void TxtGridParticular_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtGridParticular)
            {
                return;
            }

            if (TxtGridParticular.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtGridParticular.Text))
            {
                if (Grid.Rows.Count <= 1)
                {
                    MessageBox.Show("Particular name cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtGridParticular.Focus();
                    return;
                }
                else
                {
                    GridControlMode(false);
                }
            }

            if (!string.IsNullOrEmpty(TxtGridParticular.Text))
            {
                Indexcount = Grid.Rows.Count;
                if (TxtGridParticular.ProductDetails.Count > 0)
                {

                    TxtGridAltUOM.Text = TxtGridParticular.ProductDetails["ProductAltUnit"].ToString();
                    TxtGridAltUOM.Tag = TxtGridParticular.ProductDetails["ProductAltUnitId"].ToString();
                    TxtGridQtyUOM.Text = TxtGridParticular.ProductDetails["ProductUnit"].ToString();
                    TxtGridQtyUOM.Tag = TxtGridParticular.ProductDetails["ProductUnitId"].ToString();
                    TxtGridParticular.ProductDetails.Clear();
                }
                if (!string.IsNullOrEmpty(TxtGridAltUOM.Text))
                {
                    TxtGridAltUOM.Enabled = true;
                    TxtGridAltQty.Enabled = true;
                    Utility.EnableDesibleColor(TxtGridAltUOM, true);
                    Utility.EnableDesibleColor(TxtGridAltQty, true);
                }
                else
                {
                    TxtGridAltUOM.Enabled = false;
                    TxtGridAltQty.Enabled = false;
                    Utility.EnableDesibleColor(TxtGridAltUOM, false);
                    Utility.EnableDesibleColor(TxtGridAltQty, false);
                }
            }
        }

        private void TxtGridAltQty_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == TxtGridAltQty)
            {
                _StartTermCalculation = true;
            }
        }

        private void TxtGridAltQty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal _convRatio = TxtGridParticular.AltConversion;
            if (ClsGlobal.InventoryAltQtyConversionRatioChange == "Y" && !string.IsNullOrEmpty(TxtGridAltQty.Text))
            {
                ConversionQty frm = new ConversionQty(ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridParticular.ProductQtyConversion), 1, ClsGlobal._QtyDecimalFormat));
                frm.ShowDialog();
                TxtGridParticular.ProductQtyConversion = frm._ConversionQty;
            }

            if (ClsGlobal.InventoryAltQtyConversion == "Y" && Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridAltQty.Text) ? "0" : TxtGridAltQty.Text) * Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }
            else if (ClsGlobal.InventoryAltQtyConversion == "N" && _StartTermCalculation == true && Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridAltQty.Text) ? "0" : TxtGridAltQty.Text) * Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }
        }

        private void TxtGridQty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
            if (_Qty <= 0)
            {
                TxtGridQty.Focus();
                return;
            }
            decimal _convRatio = TxtGridParticular.AltConversion;
            if (ClsGlobal.InventoryAltQtyConversion == "Y" && TxtGridAltQty.Enabled == true && Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridAltQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridQty.Text) ? "0" : TxtGridQty.Text) / Convert.ToDecimal(TxtGridParticular.ProductQtyConversion.ToString()) * _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }
        }

        private void TxtGridNarration_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SetTextBoxValueToGrid() == true)
            {
                if (Grid.CurrentRow.Index == (Grid.Rows.Count - 1))
                {
                    Grid.Rows.Add();
                    Grid.CurrentCell = Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"];
                }
                else
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["Particular"];
                }

                GridControlMode(_GridControlMode);
            }
        }

        private void GridControlMode(bool mode)
        {
            if (Grid.CurrentRow != null)
            {
                int currRo = Grid.CurrentRow.Index;
                int colindex = 0;
                if (mode == true)
                {
                    colindex = Grid.Columns["Particular"].Index;
                    TxtGridParticular.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridParticular.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["AltQty"].Index;
                    TxtGridAltQty.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridAltQty.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["AltUOM"].Index;
                    TxtGridAltUOM.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridAltUOM.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["Qty"].Index;
                    TxtGridQty.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridQty.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["QtyUOM"].Index;
                    TxtGridQtyUOM.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridQtyUOM.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;


                    colindex = Grid.Columns["Narration"].Index;
                    TxtGridNarration.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridNarration.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                }
                SetGridValueToTextBox(currRo);
            }

            TxtGridParticular.Enabled = mode;
            TxtGridParticular.Visible = mode;

            if (mode == true)
            {
                BtnOk.Enabled = false;
            }
            else
            {
				if (_isSalesQuotationUsed == false)
					BtnOk.Enabled = true;
			}

            TxtGridAltQty.Enabled = mode;
            TxtGridAltQty.Visible = mode;

            TxtGridAltUOM.Visible = mode;
            TxtGridAltUOM.Enabled = mode;

            TxtGridQty.Enabled = mode;
            TxtGridQty.Visible = mode;

            TxtGridQtyUOM.Visible = mode;
            TxtGridQtyUOM.Enabled = mode;

            TxtGridNarration.Visible = mode;
            TxtGridNarration.Enabled = mode;

            if (mode == true)
            {
                TxtGridParticular.Focus();
            }

        }

        private void BtnUDF_Click(object sender, EventArgs e)
        {
            //string _odrno = ClsGlobal.GetOrderNoFrmGrid(Grid);
            //if (_Tag == "NEW" && !string.IsNullOrEmpty(TxtChallanNo.Text))
            //{
            //    GetUDFMasterDataforChallan();
            //}
            //else if (_Tag == "NEW" && !string.IsNullOrEmpty(_odrno))
            //{
            //    string[] a = _odrno.Split(',');
            //    GetUDFMasterDataforOrder(a[1]);
            //}
            //else
            //{
            //    FrmUDFMasterEntry frm = new FrmUDFMasterEntry("Purchase Master Global", _VoucherNo, "PI");
            //    frm.ShowDialog();
            //}
            BtnOk.Focus();
        }


        private void TxtDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDepartment)
            {
                return;
            }

            if (TxtDepartment.Enabled == false)
            {
                return;
            }

            if (ClsGlobal.PurchaseMDepartmentControlVal == 'Y' && string.IsNullOrEmpty(TxtDepartment.Text))
            {
                MessageBox.Show("Department cannot be left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDepartment.Focus();
            }
        }

        private void TxtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmDepartment frm = new FrmDepartment
                {
                    _IsNew = 'Y'
                };
                frm.ShowDialog();
                TxtDepartment.Text = frm._NewDepartment;
                TxtDepartment.Tag = frm._DepartmentId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtDepartment, BtnDepartmentSearch, false);
            }
        }

        private void BtnDepartmentSearch_Click(object sender, EventArgs e)
        {
            ClsButtonClick.DepartmentBtnClick(_SearchKey, TxtDepartment, e);
            _SearchKey = string.Empty;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.CheckDateInsideCompanyPeriod(Convert.ToDateTime(TxtDate.Text)) == 1)
            {
                ClsGlobal.DateMitiRangeMsg();
                return;
            }

            if (string.IsNullOrEmpty(TxtVoucherNo.Text.Trim()))
            {
                MessageBox.Show("Voucher number cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            if (TxtMiti.Text == "  /  /")
            {
                MessageBox.Show("Miti cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMiti.Focus();
                return;
            }

            if (TxtDate.Text == "  /  /")
            {
                MessageBox.Show("Date cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDate.Focus();
                return;
            }

            if (Grid.Rows.Count <= 0)
            {
                MessageBox.Show("Invoice details not found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Grid.Focus();
                return;
            }

            if (Grid.Rows.Count == 1 && Grid.Rows[0].Cells["Particular"].Value == null)
            {
                MessageBox.Show("Invoice details not found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnOk.Enabled = false;
                Grid.Focus();
                return;
            }

            _objPurchaseIndent.Model.EntryFromProject = "Normal";
            _objPurchaseIndent.Model.Gadget = "Desktop";

            _objPurchaseIndent.Model.VDate = Convert.ToDateTime(TxtDate.Text);
            _objPurchaseIndent.Model.Tag = _Tag;
            _objPurchaseIndent.Model.VoucherNo = TxtVoucherNo.Text.Trim();
            _objPurchaseIndent.Model.VTime = _objDate.GetServerDateTime();
            _objPurchaseIndent.Model.VMiti = TxtMiti.Text;
            _objPurchaseIndent.Model.RequestedBy = txtRequestedBy.Text;
            if (!string.IsNullOrEmpty(TxtDepartment.Text))
            {
                string[] dept = TxtDepartment.Tag.ToString().Split('|');
                _objPurchaseIndent.Model.DepartmentId1 = ((dept[0].ToString() == "") ? 0 : Convert.ToInt32(dept[0].ToString()));
                _objPurchaseIndent.Model.DepartmentId2 = ((dept[1].ToString() == "") ? 0 : Convert.ToInt32(dept[1].ToString()));
                _objPurchaseIndent.Model.DepartmentId3 = ((dept[2].ToString() == "") ? 0 : Convert.ToInt32(dept[2].ToString()));
                _objPurchaseIndent.Model.DepartmentId4 = ((dept[3].ToString() == "") ? 0 : Convert.ToInt32(dept[3].ToString()));
            }
            _objPurchaseIndent.Model.Remarks = TxtRemarks.Text;
            _objPurchaseIndent.Model.BranchId = ClsGlobal.BranchId;
            _objPurchaseIndent.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;

            PurchaseIndentDetailsViewModel _PurchaseIndentDetails = null;
            int dc = Grid.Rows.Count;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                if (ro.Cells["Particular"].Value != null)
                {
                    _PurchaseIndentDetails = new PurchaseIndentDetailsViewModel
                    {
                        VoucherNo = _objPurchaseIndent.Model.VoucherNo,
                        Sno = Grid.Rows.IndexOf(ro) + 1,
                        ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString())
                    };

                    if (ro.Cells["AltQty"].Value != null)
                    {
                        decimal.TryParse(ro.Cells["AltQty"].Value.ToString().Trim(), out decimal _AltQty);
                        _PurchaseIndentDetails.AltQty = _AltQty;
                    }
                    else
                    {
                        _PurchaseIndentDetails.AltQty = 0;
                    }

                    if (ro.Cells["AltQty"].Value != null)
                    {
                        _PurchaseIndentDetails.ProductAltUnitId = !string.IsNullOrEmpty(ro.Cells["ProductAltUnitId"].Value.ToString()) ? Convert.ToInt32(ro.Cells["ProductAltUnitId"].Value.ToString()) : 0;
                    }

                    _PurchaseIndentDetails.Qty = ro.Cells["Qty"].Value != null ? Convert.ToDecimal(ro.Cells["Qty"].Value.ToString().Trim()) : 0;

                    if (ro.Cells["ProductUnitId"].Value != null)
                    {
                        _PurchaseIndentDetails.ProductUnitId = string.IsNullOrEmpty(ro.Cells["ProductUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["ProductUnitId"].Value.ToString());
                    }
                    else
                    {
                        _PurchaseIndentDetails.ProductUnitId = 0;
                    }

                    _PurchaseIndentDetails.ConversionRatio = ro.Cells["QtyConversion"].Value != null ? Convert.ToDecimal(ro.Cells["QtyConversion"].Value.ToString().Trim()) : 0;

                    _PurchaseIndentDetails.Narration = ro.Cells["Narration"].Value.ToString();

                    _objPurchaseIndent.ModelDetails.Add(_PurchaseIndentDetails);

                }
            }

            _objPurchaseIndent.Model.DocId = Convert.ToInt32(TxtVoucherNo.Tag.ToString());
            string output = "";
            if (_Tag == "DELETE")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to Delete Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        output = _objPurchaseIndent.SavePurchaseIndent();
                    }
                }
                else
                {
                    output = _objPurchaseIndent.SavePurchaseIndent();
                }
            }
            else
            {
                output = _objPurchaseIndent.SavePurchaseIndent();
            }

            if (string.IsNullOrEmpty(output))
            {
                MessageBox.Show("Error occurred during data submission.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_Tag == "NEW")
                    MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been generated.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (_Tag == "EDIT")
                    MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been updated.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (_Tag == "DELETE")
                    MessageBox.Show("Voucher number : " + TxtVoucherNo.Text + " has been deleted.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFld();
				if (this._Tag == "NEW")
				{
					_DocId = Convert.ToInt32(TxtVoucherNo.Tag.ToString());
					BtnNew.Enabled = true;
					BtnNew.PerformClick();
				}
				else if (this._Tag == "EDIT")
				{
					BtnEdit.Enabled = true;
					BtnEdit.PerformClick();
				}
				else if (this._Tag == "DELETE")
				{
					BtnDelete.Enabled = true;
					BtnDelete.PerformClick();
				}
			}
        }

        private void FrmPurchaseIndent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != Grid)
            {
                SendKeys.Send("{Tab}");
                ActiveControl.Select();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridParticular.Visible == true)
                {
                    _GridControlMode = false;
                    GridControlMode(false);
                    _GridControlMode = true;
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

        private void FrmPurchaseIndent_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClearFld();
            BtnNew.Focus();
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

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //-------- START DELETE ROW --------------
            if (Grid.Columns[e.ColumnIndex].Name == "Action")
            {
                if (TxtGridParticular.Visible == true)
                {
                    GridControlMode(false);
                    Grid.Focus();
                }

                if (Grid.Rows.Count > 1)
                {
                    Grid.Rows.RemoveAt(e.RowIndex);
                }
                foreach (DataGridViewRow ro in Grid.Rows)
                {
                    ro.Cells["SNo"].Value = Grid.Rows.IndexOf(ro) + 1;
                }
            }
            //-------- END DELETE ROW --------------
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            //LblShortName.Text = ""; LblAltStockQty.Text = ""; LblStockQty.Text = "";
            //if (Grid.Rows.Count > 0)
            //{
            //    if (Grid.CurrentRow.Cells["Particular"].Value != null)
            //    {
            //        if (!string.IsNullOrEmpty(Grid.CurrentRow.Cells["Particular"].Value.ToString()))
            //        {
            //            LblShortName.Text = Grid.CurrentRow.Cells["ProductShortName"].Value.ToString();
            //            if (Grid.CurrentRow.Cells["AltStockQty"] != null)
            //                LblAltStockQty.Text = Grid.CurrentRow.Cells["AltStockQty"].Value.ToString();
            //            if (Grid.CurrentRow.Cells["StockQty"] != null)
            //                LblStockQty.Text = Grid.CurrentRow.Cells["StockQty"].Value.ToString();
            //        }
            //    }
            //}
        }

        private void Grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BtnOk.Enabled = false;
            if (TxtGridParticular.Visible == true)
            {
                Grid.Focus();
            }

            foreach (DataGridViewRow ro in Grid.Rows)
            {
                ro.Cells["SNo"].Value = Grid.Rows.IndexOf(ro) + 1;
            }
            BtnOk.Enabled = true;
        }

        private void TxtVoucherNo_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtVoucherNo) return;

            if (TxtVoucherNo.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtVoucherNo.Text))
                ClsButtonClick.VoucherNumberValidating(TxtVoucherNo, e);

            if (_Tag == "NEW")
            {
                if (!string.IsNullOrEmpty(_objPurchaseIndent.IsExistsVNumber(TxtVoucherNo.Text)))
                {
                    MessageBox.Show("Voucher Number Already Exist...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
			else if (_Tag == "EDIT" || _Tag == "DELETE")
			{
				if (string.IsNullOrEmpty(_objPurchaseIndent.IsExistsVNumber(TxtVoucherNo.Text)))
				{
					MessageBox.Show("Purchase Indent number does not exist.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					e.Cancel = true;
					return;
				}
				else
				{
					_isSalesQuotationUsed = false; BtnOk.Enabled = true;
					DataSet ds = new DataSet();
					if (this._VoucherNo != TxtVoucherNo.Text.Trim())
					{
						this._VoucherNo = TxtVoucherNo.Text.Trim();
						 ds = _objPurchaseIndent.GetDataPurchaseIndentVoucher(this._VoucherNo);
						ClearFld();
						SetData(ds);
					}

					string _vno1 = _objPurchaseIndent.IsIndentUsedInQuotation(TxtVoucherNo.Text);
					if (!string.IsNullOrEmpty(_vno1))
					{
						MessageBox.Show("This Indent is used in purchase Quotation.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
						_VoucherNo = _vno1; _isSalesQuotationUsed = true; BtnOk.Enabled = false;
						return;
					}

					string _vno2 = _objPurchaseIndent.IsIndentUsedInOrder(TxtVoucherNo.Text);
					if (!string.IsNullOrEmpty(_vno2))
					{
						MessageBox.Show("This Indent is used in purchase Order.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
						_VoucherNo = _vno2; _isSalesQuotationUsed = true; BtnOk.Enabled = false;
						return;
					}
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
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtVoucherNo, BtnVoucherNoSearch, true);
            }
        }

        private void BtnVoucherNoSearch_Click(object sender, EventArgs e)
        {
            if (_SearchKey.Length > 1)
            {
                _SearchKey = "";
            }

            PickList frmPickList = new PickList("PurchaseIndent", _SearchKey);
            if (PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    _VoucherNo = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                    DataSet ds = _objPurchaseIndent.GetDataPurchaseIndentVoucher(_VoucherNo);
                    ClearFld();
                    SetData(ds);
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Purchase Indent !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            TxtVoucherNo.Focus();
        }

        private bool SetTextBoxValueToGrid()
        {
            if (string.IsNullOrEmpty(TxtGridParticular.Text))
            {
                TxtGridParticular.Focus();
                return false; // return false for not add grid new 1 row
            }
            else
            {
                Utility.EnableDesibleColor(TxtGridAltUOM, true);
                Utility.EnableDesibleColor(TxtGridAltQty, true);
                DataGridViewRow ro = new DataGridViewRow();
                ro = Grid.Rows[Grid.CurrentRow.Index];
                ro.Cells["SNo"].Value = Grid.CurrentRow.Index + 1;
                ro.Cells["Particular"].Value = TxtGridParticular.Text;
                ro.Cells["ProductId"].Value = TxtGridParticular.Tag.ToString();
                ro.Cells["AltConversion"].Value = TxtGridParticular.AltConversion.ToString();
                ro.Cells["ProductShortName"].Value = TxtGridParticular.ProductShortName.ToString();
                ro.Cells["QtyConversion"].Value = TxtGridParticular.ProductQtyConversion.ToString();

                if (!string.IsNullOrEmpty(TxtGridAltQty.Text))
                {
                    ro.Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridAltQty.Text), 1, ClsGlobal._AltQtyDecimalFormat);
                }
                ro.Cells["AltUOM"].Value = TxtGridAltUOM.Text;
                ro.Cells["ProductAltUnitId"].Value = !string.IsNullOrEmpty(TxtGridAltUOM.Tag.ToString()) ? TxtGridAltUOM.Tag.ToString() : "0";
                if (!string.IsNullOrEmpty(TxtGridQty.Text))
                {
                    ro.Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridQty.Text), 1, ClsGlobal._QtyDecimalFormat);
                }
                ro.Cells["QtyUOM"].Value = TxtGridQtyUOM.Text;
                ro.Cells["ProductUnitId"].Value = !string.IsNullOrEmpty(TxtGridQtyUOM.Tag.ToString()) ? TxtGridQtyUOM.Tag.ToString() : "0";

                ro.Cells["Narration"].Value = TxtGridNarration.Text.ToString();
            }
            return true; // return true for add grid new row
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Dispose();
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
                    TxtVoucherNo.Text = "";
                    Text = "Purchase Indent";
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
                TxtVoucherNo.Text = "";
                Text = "Purchase Indent";
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {

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

		private void TxtRemarks_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtRemarks) return;
			ClsButtonClick.RemarksValidating(TxtRemarks, "PURCHASE", e);
			if (_isSalesQuotationUsed == false)
				BtnOk.Enabled = true;
		}

		private void txtRequestedBy_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == txtRequestedBy || string.IsNullOrEmpty(TxtVoucherNo.Text.Trim())) return;
			if (txtRequestedBy.Enabled == false) return;
			if (string.IsNullOrEmpty(txtRequestedBy.Text))
			{
				MessageBox.Show("RequestedBy Cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				e.Cancel = true;
			}
		}

		private void SetGridValueToTextBox(int row)
        {
            TxtGridParticular.Text = "";
            TxtGridParticular.Tag = "0";
            TxtGridParticular.ProductShortName = "";
            TxtGridParticular.ProductQtyConversion = "0";
            TxtGridAltQty.Text = "";
            TxtGridAltUOM.Text = "";
            TxtGridAltUOM.Tag = "0";
            TxtGridQty.Text = "";
            TxtGridQtyUOM.Text = "";
            TxtGridQtyUOM.Tag = "0";
            TxtGridNarration.Text = "";

            if (Grid["Particular", row].Value != null)
            {
                TxtGridParticular.Text = Grid["Particular", row].Value.ToString();
                TxtGridParticular.Tag = Grid["ProductId", row].Value.ToString();
                TxtGridParticular.AltConversion = Convert.ToDecimal(Grid["AltConversion", row].Value.ToString());
                TxtGridParticular.ProductShortName = Grid["ProductShortName", row].Value.ToString();
                TxtGridParticular.ProductQtyConversion = Grid["QtyConversion", row].Value.ToString();
                TxtGridNarration.Text = Grid["Narration", row].Value.ToString();
            }

            if (Grid["AltQty", row].Value != null)
            {
                TxtGridAltQty.Text = Grid["AltQty", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["AltUOM", row].Value != null)
            {
                TxtGridAltUOM.Text = Grid["AltUOM", row].Value.ToString();
                TxtGridAltUOM.Tag = Grid["ProductAltUnitId", row].Value.ToString();
            }

            if (Grid["Qty", row].Value != null)
            {
                TxtGridQty.Text = Grid["Qty", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["QtyUOM", row].Value != null)
            {
                TxtGridQtyUOM.Text = Grid["QtyUOM", row].Value.ToString();
                TxtGridQtyUOM.Tag = Grid["ProductUnitId", row].Value.ToString();
            }

            if (Grid["Narration", row].Value != null)
            {
                TxtGridNarration.Text = Grid["Narration", row].Value.ToString();
            }
        }
        #endregion



        public void ClearFld()
        {
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            Grid.Rows.Clear();
            Grid.Rows.Add();

            ClsGlobal.FieldNameArrMaster.Clear();
            ClsGlobal.UDFDataArrMaster.Clear();
            ClsGlobal.UDFExistingDataMaster.Clear();
            ClsGlobal.UDFExistingDataTableDetails.Clear();
            ClsGlobal.UDFExistingDataTableDetails.Clear();
            ClsGlobal.UDFCodeArrayDetails.Clear();
            ClsGlobal.UDFDataArrayDetails.Clear();
        }

        public void ControlEnableDisable(bool btn, bool fld)
        {
            BtnNew.Enabled = btn;
            BtnEdit.Enabled = btn;
            BtnDelete.Enabled = btn;
            BtnNextData.Enabled = btn;
            BtnPreviousData.Enabled = btn;
            BtnFirstData.Enabled = btn;
            BtnLastData.Enabled = btn;
            BtnCopy.Enabled = btn;
            BtnPrint.Enabled = btn;
            BtnExit.Enabled = btn;
            if (BtnNew.Enabled == true) { BtnNew.Focus(); }
            TxtVoucherNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtVoucherNo, fld);
            BtnVoucherNoSearch.Enabled = fld;
            TxtMiti.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtMiti, fld);
            TxtDate.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtDate, fld);

            txtRequestedBy.Enabled = fld;
            Utility.EnableDesibleColor(txtRequestedBy, fld);

            TxtRemarks.Enabled = fld;
            Utility.EnableDesibleColor(TxtRemarks, fld);

            BtnOk.Enabled = fld;
            BtnCancel.Enabled = fld;

            Grid.Enabled = true;

            if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
            {
                if (ClsGlobal.PurchaseVoucherDateControlVal == 'Y')
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

                if (ClsGlobal.PurchaseDepartmentControlVal == 'Y')
                {
                    TxtDepartment.Enabled = true;
                    TxtDepartment.BackColor = Color.White;
                    BtnDepartmentSearch.Enabled = true;
                }
                else
                {
                    TxtDepartment.Enabled = false;
                    TxtDepartment.BackColor = SystemColors.Control;
                    BtnDepartmentSearch.Enabled = false;
                }

                if (ClsGlobal.PurchaseRemarksControlVal == 'Y')
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
                TxtDepartment.Enabled = fld;
                TxtRemarks.Enabled = fld;
            }

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtVoucherNo.Enabled == true)
            {
                TxtVoucherNo.Focus();
            }

            if (TxtGridParticular.Visible == true)
            {
                GridControlMode(false);
                Grid.Focus();
            }
        }

        private void SetData(DataSet ds)
        {
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];

            TxtVoucherNo.Text = dtMaster.Rows[0]["VoucherNo"].ToString();
            _VoucherNo = dtMaster.Rows[0]["VoucherNo"].ToString();
            TxtDate.Text = dtMaster.Rows[0]["VDate"].ToString();
            TxtMiti.Text = dtMaster.Rows[0]["VMiti"].ToString();

            if (string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc4"].ToString()))
            {
                string[] Dept = new string[] { dtMaster.Rows[0]["DepartmentDesc1"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc2"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString() };
                TxtDepartment.Text = string.Concat(Dept);
                string[] Depttag = new string[] { dtMaster.Rows[0]["DepartmentId1"].ToString(), "|", dtMaster.Rows[0]["DepartmentId2"].ToString(), "|", dtMaster.Rows[0]["DepartmentId3"].ToString(), "|", dtMaster.Rows[0]["DepartmentId4"].ToString() };
                TxtDepartment.Tag = string.Concat(Depttag);
            }
            txtRequestedBy.Text = dtMaster.Rows[0]["RequestedBy"].ToString();
            TxtRemarks.Text = dtMaster.Rows[0]["Remarks"].ToString();
            foreach (DataRow drDetails in dtDetails.Rows)
            {
                Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltConversion"].Value = drDetails["AltConv"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["AltUOM"].Value = drDetails["ProductAltUnitDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductAltUnitId"].Value = drDetails["ProductAltUnit"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["QtyUOM"].Value = drDetails["ProductUnitDesc"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["QtyConversion"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["ConversionRatio"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Narration"].Value = drDetails["Narration"].ToString();
                Grid.Rows.Add();
            }
        }
    }
}
