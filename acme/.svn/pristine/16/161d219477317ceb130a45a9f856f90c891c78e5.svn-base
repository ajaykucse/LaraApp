using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmProduct : Form
    {
        private ClsProduct _objProduct = new ClsProduct();
        private ClsProductUnit _objProductUnit = new ClsProductUnit();
        private ClsSalesBillingTerm _objSalesTerm = new ClsSalesBillingTerm();
        private ClsPurchaseBillingTerm _objPurchaseTerm = new ClsPurchaseBillingTerm();
        ClsCommon _objCommon = new ClsCommon();
        private char _IsNew;
        public int _ProductId = 0;
        private string _Tag = "", _SearchKey = "", result = "";
        DataSet NavMenuDataList; int NavMenuDataRowPosition = 0; public string _NewProduct = "";
        DataTable NavMenuDataList1;
        MyGridNumericTextBox TxtSalesTermRate;
        MyGridNumericTextBox TxtPurchaseTermRate;
        private char _IsSalesTermAvilable = 'N';
        private char _IsPurchaseTermAvilable = 'N';
        public FrmProduct()
        {
            InitializeComponent();
            _Tag = "";
            TxtSalesTermRate = new MyGridNumericTextBox(GridSalesTerm);
            TxtSalesTermRate.Validating += new System.ComponentModel.CancelEventHandler(TxtSalesTermRate_Validating);
            TxtPurchaseTermRate = new MyGridNumericTextBox(GridPurchaseTerm);
            TxtPurchaseTermRate.Validating += new System.ComponentModel.CancelEventHandler(TxtPurchaseTermRate_Validating);

            GridSalesTermControlMode(false);
            GridPurchaseTermControlMode(false);

            GridSalesTerm.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            GridPurchaseTerm.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            GridSalesTerm.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            GridSalesTerm.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            GridPurchaseTerm.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            GridPurchaseTerm.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objProduct.GetDataProduct(0);
            NavMenuDataList1 = NavMenuDataList.Tables[0];
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

            if (ClsGlobal.SoftwareFocus == "Restaurant")
            {
                LblGroup1.Text = "Used/UnUsed";
                LblGroup2.Text = "Preparation Center";
            }
        }
        private void FrmProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != GridSalesTerm && ActiveControl != GridPurchaseTerm)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtSalesTermRate.Visible == true)
                {
                    GridSalesTermControlMode(false);
                    GridSalesTerm.Focus();
                }
                else if (TxtPurchaseTermRate.Visible == true)
                {
                    GridPurchaseTermControlMode(false);
                    GridPurchaseTerm.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
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
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Product [NEW]";
            CmbAltUnit.Enabled = false;
            TxtQty.Enabled = false;
            TxtAltQty.Enabled = false;
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Product [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Product [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchDescription.Enabled = true;
            TxtDescription.Focus();
            BtnUdf.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList1.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataSet dt = _objProduct.GetDataProduct(Convert.ToInt32(NavMenuDataList1.Rows[NavMenuDataRowPosition]["ProductId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnNextData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList1.Rows.Count == 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (NavMenuDataRowPosition < NavMenuDataList1.Rows.Count - 1)
            {
                NavMenuDataRowPosition++;
                DataSet dt = _objProduct.GetDataProduct(Convert.ToInt32(NavMenuDataList1.Rows[NavMenuDataRowPosition]["ProductId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("This is the last record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnPreviousData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList1.Rows.Count == 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (NavMenuDataList1.Rows.Count == 1)
            {
                MessageBox.Show("This is the frist record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (NavMenuDataRowPosition == NavMenuDataList1.Rows.Count - 1 || NavMenuDataRowPosition != 0)
            {
                NavMenuDataRowPosition--;
                DataSet dt = _objProduct.GetDataProduct(Convert.ToInt32(NavMenuDataList1.Rows[NavMenuDataRowPosition]["ProductId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("This is the frist record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnLastData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList1.Rows.Count <= 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NavMenuDataRowPosition = NavMenuDataList1.Rows.Count - 1;
            DataSet ds = _objProduct.GetDataProduct(Convert.ToInt32(NavMenuDataList1.Rows[NavMenuDataRowPosition]["ProductId"].ToString()));
            SetData(ds);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Product Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if(string.IsNullOrEmpty(TxtPrintingName.Text))
            {
                MessageBox.Show("Product PrintingName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPrintingName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Product ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objProduct.Model.Tag = _Tag;
            _objProduct.Model.ProductId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }

            _objProduct.Model.ProductDesc = TxtDescription.Text;
            _objProduct.Model.ProductShortName = TxtShortName.Text;
            _objProduct.Model.ProductPrintingName = TxtPrintingName.Text;
            _objProduct.Model.GenericName = TxtGenericName.Text;
            _objProduct.Model.ProductAlias = TxtAlias.Text;
            _objProduct.Model.ProductDescription = TxtProductDesc.Text;
            _objProduct.Model.ProductCategory = CmbCategory.Text;
            _objProduct.Model.ProductModel = CmbProductModel.Text;
            _objProduct.Model.ProductType = CmbType.Text;
            _objProduct.Model.ValuationTech = CmbValTech.Text;
            _objProduct.Model.ProductGrpId = ((TxtGroup.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtGroup.Tag.ToString()));
            _objProduct.Model.PGrpId1 = ((TxtGroup1.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtGroup1.Tag.ToString()));
            _objProduct.Model.PGrpId2 = ((TxtGroup2.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtGroup2.Tag.ToString()));
            _objProduct.Model.ProductSubGrpId = ((TxtSubGroup.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSubGroup.Tag.ToString()));
            _objProduct.Model.IsBatchwise = ChkBatch.Checked == true ? true : false;
            _objProduct.Model.IsSerialWise = ChkSerialNo.Checked == true ? true : false;
            _objProduct.Model.IsSizewise = false;
            _objProduct.Model.IsExpiryDate = false;
            _objProduct.Model.IsManufacturingDate = false;
            _objProduct.Model.SerialNo = "";
            _objProduct.Model.PartsNo = "";
            _objProduct.Model.ProductUnitId = ((CmbUnit.Text.ToString() == "") ? 0 : Convert.ToInt32(((KeyValuePair<string, string>)CmbUnit.SelectedItem).Key));
            _objProduct.Model.QtyConv = ((TxtQty.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtQty.Text));
            _objProduct.Model.ProductAltUnitId = ((CmbAltUnit.Text.ToString() == "") ? 0 : Convert.ToInt32(((KeyValuePair<string, string>)CmbAltUnit.SelectedItem).Key));
            _objProduct.Model.AltConv = ((TxtAltQty.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtAltQty.Text));
            _objProduct.Model.BuyRate = ((TxtPurchaseRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtPurchaseRate.Text));
            _objProduct.Model.SalesRate = ((TxtSalesRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtSalesRate.Text));
            _objProduct.Model.Margin1 = ((TxtPurchaseMargin.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtPurchaseMargin.Text));
            _objProduct.Model.TradeRate = ((TxtTradeRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtTradeRate.Text));
            _objProduct.Model.Margin2 = ((TxtMrpMargin.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtMrpMargin.Text));
            _objProduct.Model.MRP = ((TxtMrp.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtMrp.Text));
            _objProduct.Model.MRRate = 0;
            _objProduct.Model.MaxStock = ((TxtMaxStock.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtMaxStock.Text));
            _objProduct.Model.MinStock = ((TxtMinStock.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtMinStock.Text));
            _objProduct.Model.ReorderLevel = ((TxtReorderLevel.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtReorderLevel.Text));
            _objProduct.Model.ReorderQty = ((TxtReorderQty.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtReorderQty.Text));
            _objProduct.Model.PercentDisc = 0;
            _objProduct.Model.MinQty = 0;
            _objProduct.Model.MinDisc = 0;
            _objProduct.Model.MaxQty = 0;
            _objProduct.Model.MaxDisc = 0;
            _objProduct.Model.IsTaxable = CmbVat.Text == "Yes" ? true : false;
			decimal.TryParse(TxtVatPercent.Text, out decimal _VatPercent);
            _objProduct.Model.TaxRate = CmbVat.Text == "No" ? 0 : _VatPercent;

            _objProduct.Model.PurchaseLedgerId = ((TxtPurchase.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPurchase.Tag.ToString()));
            _objProduct.Model.PurchaseReturnLedgerId = ((TxtPurchaseReturn.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPurchaseReturn.Tag.ToString()));
            _objProduct.Model.SalesLedgerId = ((TxtSales.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSales.Tag.ToString()));
            _objProduct.Model.SalesReturnLedgerId = ((TxtSalesReturn.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSalesReturn.Tag.ToString()));
            _objProduct.Model.PLOpeningLedgerId = ((TxtOpeningStockPL.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtOpeningStockPL.Tag.ToString()));
            _objProduct.Model.PLClosingLedgerId = ((TxtClosingStockPL.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtClosingStockPL.Tag.ToString()));
            _objProduct.Model.BSClosingLedgerId = ((TxtClosingStockBS.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtClosingStockBS.Tag.ToString()));
            _objProduct.Model.DepreciationType = "";
            _objProduct.Model.DepreciationLedgerId = 0;
            _objProduct.Model.DepreciationRate = 0;
            //_objProduct.Model.PImage = 0;
            _objProduct.Model.DepartmentId = 0;
            _objProduct.Model.DepartmentId1 = 0;
            _objProduct.Model.DepartmentId2 = 0;
            _objProduct.Model.DepartmentId3 = 0;
            _objProduct.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objProduct.Model.Status = CbActive.Checked == true ? true : false;
            _objProduct.Model.BarCodeNo2 = "";
            _objProduct.Model.BarCodeNo1 = TxtBarcode1.Text;
            _objProduct.Model.Gadget = "Desktop";
            DataAccessLayer.MasterSetup.PurchaseProductTerm ModelPurchaseProductTerm = null;
            DataAccessLayer.MasterSetup.SalesProductTerm ModelSalesProductTerm = null;

            foreach (DataGridViewRow ro in GridSalesTerm.Rows)
            {
                ModelSalesProductTerm = new DataAccessLayer.MasterSetup.SalesProductTerm();
                ModelSalesProductTerm.TermId = Convert.ToInt16(ro.Cells["SalesTermId"].Value.ToString());
                ModelSalesProductTerm.Rate = Convert.ToDecimal(ro.Cells["SalesTermRate"].Value.ToString());
                _objProduct.ModelSalesProductTerm.Add(ModelSalesProductTerm);
            }

            foreach (DataGridViewRow ro in GridPurchaseTerm.Rows)
            {
                ModelPurchaseProductTerm = new DataAccessLayer.MasterSetup.PurchaseProductTerm();
                ModelPurchaseProductTerm.TermId = Convert.ToInt16(ro.Cells["PurchaseTermId"].Value.ToString());
                ModelPurchaseProductTerm.Rate = Convert.ToDecimal(ro.Cells["PurchaseTermRate"].Value.ToString());
                _objProduct.ModelPurchaseProductTerm.Add(ModelPurchaseProductTerm);
            }

            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objProduct.SaveProduct();
                    else
                        return;
                }
                else
                {
                    result = _objProduct.SaveProduct();
                }
            }
            else
            {
                result = _objProduct.SaveProduct();
            }


            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFld();
                TxtDescription.Focus();
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
                    Text = "Product";
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
                Text = "Product";
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
            CmbProductModel.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbProductModel, fld);
            BtnSearchGroup.Enabled = fld;
            Utility.EnableDesibleColor(TxtGroup, fld);
            BtnSearchGroup1.Enabled = fld;
            Utility.EnableDesibleColor(TxtGroup1, fld);
            BtnSearchGroup2.Enabled = fld;
            Utility.EnableDesibleColor(TxtGroup2, fld);
            TxtSubGroup.Enabled = fld;
            BtnSearchSubGroup.Enabled = fld;
            Utility.EnableDesibleColor(TxtSubGroup, fld);
            TxtQty.Enabled = fld;
            Utility.EnableDesibleColor(TxtQty, fld);

            TxtAltQty.Enabled = fld;
            Utility.EnableDesibleColor(TxtAltQty, fld);
            TxtPurchaseRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtPurchaseRate, fld);
            TxtPurchaseMargin.Enabled = fld;
            Utility.EnableDesibleColor(TxtPurchaseMargin, fld);
            TxtMrp.Enabled = fld;
            Utility.EnableDesibleColor(TxtMrp, fld);
            TxtSalesRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtSalesRate, fld);
            TxtTradeRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtTradeRate, fld);
            TxtAlias.Enabled = fld;
            Utility.EnableDesibleColor(TxtAlias, fld);
            TxtVatPercent.Enabled = fld;
            Utility.EnableDesibleColor(TxtVatPercent, fld);
            TxtMrpMargin.Enabled = fld;
            Utility.EnableDesibleColor(TxtMrpMargin, fld);

            TxtMaxStock.Enabled = fld;
            Utility.EnableDesibleColor(TxtMaxStock, fld);
            TxtMinStock.Enabled = fld;
            Utility.EnableDesibleColor(TxtMinStock, fld);
            TxtReorderLevel.Enabled = fld;
            Utility.EnableDesibleColor(TxtReorderLevel, fld);
            TxtReorderQty.Enabled = fld;
            Utility.EnableDesibleColor(TxtReorderQty, fld);

            CmbAltUnit.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbAltUnit, fld);

            CmbUnit.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbUnit, fld);
            CmbType.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbType, fld);
            CmbValTech.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbValTech, fld);

            ChkBatch.Enabled = fld;
            ChkSerialNo.Enabled = fld;

            TxtPurchase.Enabled = fld;
            Utility.EnableDesibleColor(TxtPurchase, fld);
            TxtPurchaseReturn.Enabled = fld;
            Utility.EnableDesibleColor(TxtPurchaseReturn, fld);
            TxtSales.Enabled = fld;
            Utility.EnableDesibleColor(TxtSales, fld);
            TxtSalesReturn.Enabled = fld;
            Utility.EnableDesibleColor(TxtSalesReturn, fld);
            TxtOpeningStockPL.Enabled = fld;
            Utility.EnableDesibleColor(TxtOpeningStockPL, fld);
            TxtClosingStockPL.Enabled = fld;
            Utility.EnableDesibleColor(TxtClosingStockPL, fld);
            TxtClosingStockBS.Enabled = fld;
            Utility.EnableDesibleColor(TxtClosingStockBS, fld);
            TxtBarcode1.Enabled = fld;
            Utility.EnableDesibleColor(TxtBarcode1, fld);
            TxtPrintingName.Enabled = fld;
            Utility.EnableDesibleColor(TxtPrintingName, fld);
            TxtGenericName.Enabled = fld;
            Utility.EnableDesibleColor(TxtGenericName, fld);

            BtnUdf.Enabled = _objProduct.UdfCheck() > 0 && fld == true ? true : false;

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
            _ProductId = 0;
            TxtDescription.Tag = "0";
            TxtGroup.Tag = "";
            TxtGroup1.Tag = "";
            TxtGroup2.Tag = "";
            TxtSubGroup.Tag = "";
            TxtDescription.Text = "";
            TxtGroup.Text = "";
            TxtGroup1.Text = "";
            TxtGroup2.Text = "";
            TxtSubGroup.Text = "";
            TxtShortName.Text = "";
            TxtSalesReturn.Text = "";
            TxtQty.Text = "";
            TxtSales.Text = "";
            TxtPurchaseRate.Text = "";
            TxtAlias.Text = "";
            TxtGenericName.Text = "";
            TxtBarcode1.Text = "";
            TxtProductDesc.Text = "";
            TxtTradeRate.Text = "";
            TxtSalesReturn.Text = "";
            TxtMrp.Text = "";
            TxtMrpMargin.Text = "";
            TxtVatPercent.Text = "13";
            TxtMaxStock.Text = "";
            TxtMinStock.Text = "";
            TxtReorderLevel.Text = "";
            TxtReorderQty.Text = "";
            TxtAltQty.Text = "";
            LblAltUnit.Text = "";
            LblUnit.Text = "";
            TxtPurchaseMargin.Text = "";
            TxtSalesRate.Text = "";
            TxtTradeRate.Text = "";
            TxtOpeningStockPL.Text = "";
            TxtPurchase.Text = "";
            TxtPurchaseReturn.Text = "";
            TxtClosingStockBS.Text = "";
            TxtClosingStockPL.Text = "";
            TxtSales.Text = "";
            TxtSalesReturn.Text = "";
            TxtOpeningStockPL.Tag = "0";
            TxtPurchase.Tag = "0";
            TxtPurchaseReturn.Tag = "0";
            TxtClosingStockBS.Tag = "0";
            TxtClosingStockPL.Tag = "0";
            TxtSales.Tag = "0";
            TxtSalesReturn.Tag = "0";
            TxtPrintingName.Text = "";
            ChkBatch.Checked = false;
            ChkSerialNo.Checked = false;
            LoadUnit();
            LoadAltUnit();
            LoadSalesTerm();
            LoadPurchaseTerm();
            CbActive.Checked = true;
            CmbCategory.SelectedIndex = 0;
            CmbProductModel.SelectedIndex = 0;
            CmbType.SelectedIndex = 0;
            CmbValTech.SelectedIndex = 0;
            CmbVat.SelectedIndex = 0;
            tabControl1.SelectedIndex = 0;
            TxtDescription.Focus();
        }
        private void SetData(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            TxtDescription.Tag = dt.Rows[0]["ProductId"].ToString();
            TxtDescription.Text = dt.Rows[0]["ProductDesc"].ToString();
            TxtProductDesc.Text = dt.Rows[0]["ProductDesc"].ToString();
            TxtGroup.Tag = dt.Rows[0]["ProductGrpId"].ToString();
            TxtGroup.Text = dt.Rows[0]["ProductGrpDesc"].ToString();
            TxtSubGroup.Tag = dt.Rows[0]["ProductSubGrpId"].ToString();
            TxtSubGroup.Text = dt.Rows[0]["ProductSubGrpDesc"].ToString();
            TxtGroup1.Tag = dt.Rows[0]["PGrpId1"].ToString();
            TxtGroup1.Text = dt.Rows[0]["ProductGrpDesc1"].ToString();
            TxtGroup2.Tag = dt.Rows[0]["PGrpId2"].ToString();
            TxtGroup2.Text = dt.Rows[0]["ProductGrpDesc2"].ToString();

            TxtPrintingName.Text = dt.Rows[0]["ProductPrintingName"].ToString();
            TxtAlias.Text = dt.Rows[0]["ProductAlias"].ToString();
            TxtProductDesc.Text = dt.Rows[0]["ProductDescription"].ToString();
            TxtShortName.Text = dt.Rows[0]["ProductShortName"].ToString();
            TxtGenericName.Text = dt.Rows[0]["GenericName"].ToString();
            TxtBarcode1.Text = dt.Rows[0]["BarCodeNo1"].ToString();

            CmbCategory.Text = dt.Rows[0]["ProductCategory"].ToString();
            CmbProductModel.Text = dt.Rows[0]["ProductModel"].ToString();
            CmbType.Text = dt.Rows[0]["ProductType"].ToString();
            CmbValTech.Text = dt.Rows[0]["ValuationTech"].ToString();

            CmbUnit.SelectedValue = dt.Rows[0]["ProductUnitId"].ToString();
            string aa = dt.Rows[0]["ProductAltUnitId"].ToString();
            CmbAltUnit.SelectedValue = aa;
            if (!string.IsNullOrEmpty(aa))
            {
                LblAltUnit.Enabled = true;
                LblUnit.Enabled = true;
                LblUnit.Text = CmbAltUnit.Text;
                LblAltUnit.Text = CmbUnit.Text;
            }

            CmbVat.Text = (Convert.ToBoolean(dt.Rows[0]["IsTaxable"].ToString()) == true) ? "Yes" : "NO";
            if (CmbVat.Text == "Yes")
                TxtVatPercent.Enabled = false;
            TxtVatPercent.Text = (Convert.ToDecimal(dt.Rows[0]["TaxRate"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["TaxRate"].ToString()), 1, ClsGlobal._QtyDecimalFormat);

            TxtQty.Text = (Convert.ToDecimal(dt.Rows[0]["QtyConv"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["QtyConv"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtAltQty.Text = (Convert.ToDecimal(dt.Rows[0]["AltConv"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["AltConv"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtPurchaseRate.Text = (Convert.ToDecimal(dt.Rows[0]["BuyRate"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["BuyRate"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtPurchaseMargin.Text = (Convert.ToDecimal(dt.Rows[0]["Margin1"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["Margin1"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtMrp.Text = (Convert.ToDecimal(dt.Rows[0]["BuyRate"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["BuyRate"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtMrpMargin.Text = (Convert.ToDecimal(dt.Rows[0]["Margin2"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["Margin2"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtSalesRate.Text = (Convert.ToDecimal(dt.Rows[0]["SalesRate"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["SalesRate"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtTradeRate.Text = (Convert.ToDecimal(dt.Rows[0]["TradeRate"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["TradeRate"].ToString()), 1, ClsGlobal._QtyDecimalFormat);

            TxtMaxStock.Text = (Convert.ToDecimal(dt.Rows[0]["MaxStock"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["MaxStock"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtMinStock.Text = (Convert.ToDecimal(dt.Rows[0]["MinStock"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["MinStock"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtReorderLevel.Text = (Convert.ToDecimal(dt.Rows[0]["ReorderLevel"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["ReorderLevel"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            TxtReorderQty.Text = (Convert.ToDecimal(dt.Rows[0]["ReorderQty"].ToString()) == 0) ? "" : ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["ReorderQty"].ToString()), 1, ClsGlobal._QtyDecimalFormat);
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());

            TxtPurchase.Text = dt.Rows[0]["Purchase"].ToString();
            TxtPurchaseReturn.Text = dt.Rows[0]["PurchaseReturn"].ToString();
            TxtSales.Text = dt.Rows[0]["Sales"].ToString();
            TxtSalesReturn.Text = dt.Rows[0]["SalesRerurn"].ToString();
            TxtOpeningStockPL.Text = dt.Rows[0]["PLOpening"].ToString();
            TxtClosingStockPL.Text = dt.Rows[0]["PLClosing"].ToString();
            TxtClosingStockBS.Text = dt.Rows[0]["BSClosing"].ToString();

            TxtPurchase.Tag = dt.Rows[0]["PurchaseLedgerId"].ToString();
            TxtPurchaseReturn.Tag = dt.Rows[0]["PurchaseReturnLedgerId"].ToString();
            TxtSales.Tag = dt.Rows[0]["SalesLedgerId"].ToString();
            TxtSalesReturn.Tag = dt.Rows[0]["SalesReturnLedgerId"].ToString();
            TxtOpeningStockPL.Tag = dt.Rows[0]["PLOpeningLedgerId"].ToString();
            TxtClosingStockPL.Tag = dt.Rows[0]["PLClosingLedgerId"].ToString();
            TxtClosingStockBS.Tag = dt.Rows[0]["BSClosingLedgerId"].ToString();

            ChkBatch.Checked = (Convert.ToBoolean(dt.Rows[0]["IsBatchwise"].ToString()) == true) ? true : false;
            ChkSerialNo.Checked = (Convert.ToBoolean(dt.Rows[0]["IsSerialWise"].ToString()) == true) ? true : false;

            if (ds.Tables[1].Rows.Count > 0)
            {
                GridSalesTerm.Rows.Clear();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    GridSalesTerm.Rows.Add(dr["TermId"].ToString(), dr["TermDesc"].ToString(), dr["GlDesc"].ToString(), dr["TermType"].ToString(), dr["Basis"].ToString(), dr["Sign"].ToString(), dr["Rate"].ToString());
                }
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                GridPurchaseTerm.Rows.Clear();
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    GridPurchaseTerm.Rows.Add(dr["TermId"].ToString(), dr["TermDesc"].ToString(), dr["GlDesc"].ToString(), dr["TermType"].ToString(), dr["Basis"].ToString(), dr["Sign"].ToString(), dr["Rate"].ToString());
                }
            }
            TxtDescription.SelectAll();
        }
        private void LoadUnit()
        {
            DataTable dtProductUnit = _objProductUnit.ComboBindProductUnit(0);
            if (dtProductUnit.Rows.Count > 0)
            {
                CmbUnit.Enabled = true;
                Dictionary<string, string> _CmbType = new Dictionary<string, string>();
                foreach (DataRow ro in dtProductUnit.Rows)
                {
                    _CmbType.Add(ro["ProductUnitId"].ToString(), ro["ProductUnitShortName"].ToString());
                }
                CmbUnit.DataSource = new BindingSource(_CmbType, null);
                CmbUnit.DisplayMember = "Value";
                CmbUnit.ValueMember = "Key";
            }
        }
        private void LoadAltUnit()
        {
            DataTable dtProductUnit = _objProductUnit.ComboBindProductUnit(0);
            if (dtProductUnit.Rows.Count > 0)
            {
                CmbAltUnit.Enabled = true;
                Dictionary<string, string> _CmbType = new Dictionary<string, string>();
                foreach (DataRow ro in dtProductUnit.Rows)
                {
                    _CmbType.Add(ro["ProductUnitId"].ToString(), ro["ProductUnitShortName"].ToString());
                }
                CmbAltUnit.DataSource = new BindingSource(_CmbType, null);
                CmbAltUnit.DisplayMember = "Value";
                CmbAltUnit.ValueMember = "Key";
            }
        }
        private void LoadSalesTerm()
        {
            GridSalesTerm.Rows.Clear();
            DataTable dt1 = _objSalesTerm.GetProductTerm();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    GridSalesTerm.Rows.Add(dr["TermId"].ToString(), dr["TermDesc"].ToString(), dr["GlDesc"].ToString(), dr["TermType"].ToString(), dr["Basis"].ToString(), dr["Sign"].ToString(), dr["Rate"].ToString());
                }
                this._IsSalesTermAvilable = 'Y';
            }
            else
            {
                this._IsSalesTermAvilable = 'N';
            }
        }
        private void LoadPurchaseTerm()
        {
            GridPurchaseTerm.Rows.Clear();
            DataTable dt1 = _objPurchaseTerm.GetProductTerm();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    GridPurchaseTerm.Rows.Add(dr["TermId"].ToString(), dr["TermDesc"].ToString(), dr["GlDesc"].ToString(), dr["TermType"].ToString(), dr["Basis"].ToString(), dr["Sign"].ToString(), dr["Rate"].ToString());
                }
                this._IsPurchaseTermAvilable = 'Y';
            }
            else
            {
                this._IsPurchaseTermAvilable = 'N';
            }
        }
        private void BtnSearchDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Product", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataSet ds = _objProduct.GetDataProduct(Convert.ToInt32(frmPickList.SelectedList[0]["ProductId"].ToString().Trim()));
                    SetData(ds);
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
                MessageBox.Show("No List Available in Product !"+ Common.PickList.dt.Rows.Count, "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;
            
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Product Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Product", "ProductDesc", "ProductId") == 1)
                {
                    MessageBox.Show("Product Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(TxtPrintingName.Text.Trim()))
                    {
                        TxtPrintingName.Text = TxtDescription.Text.Trim();
                    }

                    if (string.IsNullOrEmpty(TxtAlias.Text.Trim()))
                    {
                        TxtAlias.Text = TxtDescription.Text.Trim();
                    }

                    if (string.IsNullOrEmpty(TxtGenericName.Text.Trim()))
                    {
                        TxtGenericName.Text = TxtDescription.Text.Trim();
                    }

                    if (string.IsNullOrEmpty(TxtProductDesc.Text.Trim()))
                    {
                        TxtProductDesc.Text = TxtDescription.Text.Trim();
                    }

                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "ProductDesc", "ProductShortName", "Product");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Product", "ProductDesc", "ProductId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Product Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
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
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtShortName)return;
            if (TxtShortName.Enabled == false)return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Product ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Product", "ProductShortName", "ProductId") == 1)
                {
                    MessageBox.Show("Product ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }

            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Product", "ProductShortName", "ProductId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Product ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void BtnSearchGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSubGroup.Text = "";
                    TxtSubGroup.Tag = "0";
                    TxtGroup.Text = frmPickList.SelectedList[0]["ProductGrpDesc"].ToString().Trim();
                    TxtGroup.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim());
                    TxtGroup.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGroup.Focus();
                return;
            }
            TxtGroup.Focus();
        }
        private void TxtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmProductGroup frm = new FrmProductGroup();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtGroup.Text = frm._NewProductGroup;
                TxtGroup.Tag = frm._ProductGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtGroup, BtnSearchGroup, false);
            }
        }
        private void BtnSearchSubGroup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtGroup.Text))
            {
                MessageBox.Show("First Select Product Group then Select Sub Group  !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSubGroup.Focus();
                return;
            }
            Common.PickList frmPickList = new Common.PickList("ProductSubGroup." + TxtGroup.Tag, _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSubGroup.Text = frmPickList.SelectedList[0]["ProductSubGrpDesc"].ToString().Trim();
                    TxtSubGroup.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ProductSubGrpId"].ToString().Trim());
                    TxtSubGroup.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product SubGroup !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSubGroup.Focus();
                return;
            }
            TxtSubGroup.Focus();
        }
        private void TxtSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmProductSubGroup frm = new FrmProductSubGroup();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSubGroup.Text = frm._NewProductSubGroup;
                TxtSubGroup.Tag = frm._ProductSubGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSubGroup, BtnSearchSubGroup, false);
            }
        }
        private void BtnSearchPurchase_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtPurchase.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtPurchase.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtPurchase.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Purchase A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPurchase.Focus();
                return;
            }
            TxtPurchase.Focus();
        }
        private void BtnSearchPurchaseReturn_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtPurchaseReturn.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtPurchaseReturn.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtPurchaseReturn.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Purchase Return A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPurchaseReturn.Focus();
                return;
            }
            TxtPurchaseReturn.Focus();
        }
        private void BtnSearchSales_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSales.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtSales.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtSales.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Sales A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSales.Focus();
                return;
            }
            TxtSales.Focus();
        }
        private void BtnSearchSalesReturn_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSalesReturn.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtSalesReturn.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtSalesReturn.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Sales Return A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSalesReturn.Focus();
                return;
            }
            TxtSalesReturn.Focus();
        }
        private void BtnSearchOpeningStockPL_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtOpeningStockPL.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtOpeningStockPL.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtOpeningStockPL.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Opening Stock PL A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtOpeningStockPL.Focus();
                return;
            }
            TxtOpeningStockPL.Focus();
        }
        private void BtnSearchClosingStockPL_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtClosingStockPL.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtClosingStockPL.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtClosingStockPL.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Closing Stock PL A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtClosingStockPL.Focus();
                return;
            }
            TxtClosingStockPL.Focus();
        }
        private void BtnSearchClosingStockBS_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtClosingStockBS.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtClosingStockBS.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtClosingStockBS.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Closing Stock BS A/C !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtClosingStockBS.Focus();
                return;
            }
            TxtClosingStockBS.Focus();
        }
        private void TxtPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtPurchase.Text = frm._NewLedger;
                TxtPurchase.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPurchase, BtnSearchPurchase, false);
            }
        }
        private void TxtPurchaseReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtPurchaseReturn.Text = frm._NewLedger;
                TxtPurchaseReturn.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPurchaseReturn, BtnSearchPurchaseReturn, false);
            }
        }
        private void TxtSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSales.Text = frm._NewLedger;
                TxtSales.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSales, BtnSearchSales, false);
            }
        }
        private void TxtSalesReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSalesReturn.Text = frm._NewLedger;
                TxtSalesReturn.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSalesReturn, BtnSearchSalesReturn, false);
            }
        }
        private void TxtOpeningStockPL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtOpeningStockPL.Text = frm._NewLedger;
                TxtOpeningStockPL.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtOpeningStockPL, BtnSearchOpeningStockPL, false);
            }
        }
        private void TxtClosingStockPL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtClosingStockBS.Text = frm._NewLedger;
                TxtClosingStockBS.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtClosingStockPL, BtnSearchClosingStockPL, false);
            }
        }
        private void TxtClosingStockBS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtClosingStockBS.Text = frm._NewLedger;
                TxtClosingStockBS.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtClosingStockBS, BtnSearchClosingStockBS, false);
            }
        }
        private void CmbVat_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TxtVatPercent.Text = CmbVat.Text == "Yes" ? "13" : "";
            if (CmbVat.Text == "Yes")
                TxtVatPercent.Enabled = false;
        }
        private void CmbCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                SendKeys.Send("{F4}");
        }
        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmProductUnit frm = new FrmProductUnit();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                LoadUnit();
				CmbUnit.Text = frm._NewProductunit;
				CmbUnit.Tag = frm._ProductUnitId;
			}
        }
        private void CmbAltUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmProductUnit frm = new FrmProductUnit();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                LoadAltUnit();
				CmbAltUnit.Text = frm._NewProductunit;
				CmbAltUnit.Tag = frm._ProductUnitId;
			}
        }
        private void CmbUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CmbUnit.Text))
            {
                CmbAltUnit.Enabled = true;
                LblUnit.Enabled = true;
                LblUnit.Text = CmbUnit.Text;
            }
            else
            {
                LblUnit.Enabled = false;
                CmbAltUnit.Enabled = false;
                TxtQty.Enabled = false;
                TxtAltQty.Enabled = false;
                CmbAltUnit.Text = "";
                CmbAltUnit.Tag = "";
                TxtQty.Text = "";
                TxtAltQty.Text = "";
            }
        }
        private void CmbAltUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CmbAltUnit.Text))
            {
                TxtQty.Enabled = true;
                TxtAltQty.Enabled = true;
                LblAltUnit.Enabled = true;
                LblEqualto.Enabled = true;
                LblAltUnit.Text = CmbAltUnit.Text;
            }
            else
            {
                LblAltUnit.Enabled = false;
                LblEqualto.Enabled = false;
                TxtQty.Enabled = false;
                TxtAltQty.Enabled = false;
                TxtQty.Text = "";
                TxtAltQty.Text = "";
            }
        }
        private void CmbVat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbVat.Text == "Yes")
            {
                TxtVatPercent.Enabled = true;
                TxtVatPercent.Text = "13";
            }
            else
            {
                TxtVatPercent.Enabled = false;
                TxtVatPercent.Text = "";
            }
        }
        private void BtnUdf_Click(object sender, EventArgs e)
        {
            Common.FrmUDFMasterEntry frm = new Common.FrmUDFMasterEntry("Product Master", TxtDescription.Tag.ToString(), "Product Master");
            frm.ShowDialog();
        }
        #region ----------- GRID TERM --------------
        private void GridSalesTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GridSalesTermControlMode(true);
            }
        }
        private void GridSalesTermControlMode(bool mode)
        {
            if (this._IsSalesTermAvilable == 'Y')
            {
                if (GridSalesTerm.CurrentRow != null)
                {
                    int currRo = GridSalesTerm.CurrentRow.Index;
                    int colindex = 0;
                    if (mode == true)
                    {
                        colindex = GridSalesTerm.Columns["SalesTermRate"].Index;
                        TxtSalesTermRate.Size = GridSalesTerm.GetCellDisplayRectangle(colindex, currRo, true).Size;
                        TxtSalesTermRate.Location = GridSalesTerm.GetCellDisplayRectangle(colindex, currRo, true).Location;
                    }
                    SetSalesTermGridValueToTextBox(currRo);
                }
                TxtSalesTermRate.Enabled = mode;
                TxtSalesTermRate.Visible = mode;

                if (mode == true)
                {
                    TxtSalesTermRate.Focus();
                }
            }
            else
            {
                TxtSalesTermRate.Visible = false;
            }
        }
        private void TxtSalesTermRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int indx = GridSalesTerm.CurrentRow.Index;
            if (SetTextBoxValueToGridSalesTerm() == true)
            {
                GridSalesTermControlMode(false);

                if (GridSalesTerm.Rows.Count - 1 == indx)
                {
                    GridSalesTerm.CurrentCell = GridSalesTerm.Rows[GridSalesTerm.CurrentRow.Index].Cells["SalesTermRate"];
                    GridSalesTermControlMode(false);
                }
                else
                {
                    GridSalesTerm.CurrentCell = GridSalesTerm.Rows[GridSalesTerm.CurrentRow.Index + 1].Cells["SalesTermRate"];
                    GridSalesTermControlMode(true);
                }
            }
        }
        private void SetSalesTermGridValueToTextBox(int row)
        {
            TxtSalesTermRate.Text = "";
            if (GridSalesTerm["SalesTermRate", row].Value != null)
            {
                TxtSalesTermRate.Text = GridSalesTerm["SalesTermRate", row].Value.ToString();
            }
        }
        private bool SetTextBoxValueToGridSalesTerm()
        {
            DataGridViewRow ro = new DataGridViewRow();
            ro = GridSalesTerm.Rows[GridSalesTerm.CurrentRow.Index];
            ro.Cells["SalesTermRate"].Value = TxtSalesTermRate.Text.Trim();
            return true;
        }
        private void GridPurchaseTermControlMode(bool mode)
        {
            if (this._IsPurchaseTermAvilable == 'Y')
            {
                if (GridPurchaseTerm.CurrentRow != null)
                {
                    int currRo = GridPurchaseTerm.CurrentRow.Index;
                    int colindex = 0;
                    if (mode == true)
                    {
                        colindex = GridPurchaseTerm.Columns["PurchaseTermRate"].Index;
                        TxtPurchaseTermRate.Size = GridPurchaseTerm.GetCellDisplayRectangle(colindex, currRo, true).Size;
                        TxtPurchaseTermRate.Location = GridPurchaseTerm.GetCellDisplayRectangle(colindex, currRo, true).Location;
                    }
                    SetPurchaseTermGridValueToTextBox(currRo);
                }
                TxtPurchaseTermRate.Enabled = mode;
                TxtPurchaseTermRate.Visible = mode;

                if (mode == true)
                {
                    TxtPurchaseTermRate.Focus();
                }
            }
            else
            {
                TxtPurchaseTermRate.Visible = false;
            }
        }
        private void TxtPurchaseTermRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int indx = GridPurchaseTerm.CurrentRow.Index;
            if (SetTextBoxValueToGridPurchaseTerm() == true)
            {
                GridPurchaseTermControlMode(false);

                if (GridPurchaseTerm.Rows.Count - 1 == indx)
                {
                    GridPurchaseTerm.CurrentCell = GridPurchaseTerm.Rows[GridPurchaseTerm.CurrentRow.Index].Cells["PurchaseTermRate"];
                    GridPurchaseTermControlMode(false);
                }
                else
                {
                    GridPurchaseTerm.CurrentCell = GridPurchaseTerm.Rows[GridPurchaseTerm.CurrentRow.Index + 1].Cells["PurchaseTermRate"];
                    GridPurchaseTermControlMode(true);
                }
            }
        }
        private void SetPurchaseTermGridValueToTextBox(int row)
        {
            TxtPurchaseTermRate.Text = "";
            if (GridPurchaseTerm["PurchaseTermRate", row].Value != null)
            {
                TxtPurchaseTermRate.Text = GridPurchaseTerm["PurchaseTermRate", row].Value.ToString();
            }
        }
        private void GridPurchaseTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GridPurchaseTermControlMode(true);
            }
        }
        private void BtnSearchGroup2_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductGroup2", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtGroup2.Text = frmPickList.SelectedList[0]["ProductGrpDesc"].ToString().Trim();
                    TxtGroup2.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim());
                    TxtGroup2.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group2 !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGroup2.Focus();
                return;
            }
            TxtGroup2.Focus();
        }
        private void BtnSearchGroup1_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductGroup1", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtGroup1.Text = frmPickList.SelectedList[0]["ProductGrpDesc"].ToString().Trim();
                    TxtGroup1.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim());
                    TxtGroup1.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGroup1.Focus();
                return;
            }
            TxtGroup1.Focus();
        }
        private void TxtGroup1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmProductGroup1 frm = new FrmProductGroup1();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtGroup1.Text = frm._NewProductGroup;
                TxtGroup1.Tag = frm._ProductGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtGroup1, BtnSearchGroup1, false);
            }
        }
        private void TxtGroup2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmProductGroup2 frm = new FrmProductGroup2();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtGroup2.Text = frm._NewProductGroup;
                TxtGroup2.Tag = frm._ProductGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtGroup2, BtnSearchGroup2, false);
            }
        }
        private void TxtPurchaseMargin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal.TryParse(TxtPurchaseRate.Text, out decimal PurRate);
            decimal.TryParse(TxtPurchaseMargin.Text, out decimal PurMarPer);
            if (!string.IsNullOrEmpty(TxtPurchaseMargin.Text) && !string.IsNullOrEmpty(TxtPurchaseRate.Text))
            {
                TxtSalesRate.Text = Convert.ToString(PurRate + ((PurRate * PurMarPer) / 100));
            }
        }
        private void TxtPrintingName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
			if (_Tag == "" || ActiveControl == TxtPrintingName) return;
			if (TxtPrintingName.Enabled == false) return;
			if (string.IsNullOrEmpty(TxtPrintingName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Product PrintingName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPrintingName.Focus();
                return;
            }
        }
		private void CmbAltUnit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (CmbAltUnit.Text != "")
			{
				if (CmbUnit.Text == CmbAltUnit.Text)
				{
					MessageBox.Show("Unit and alt unit not same.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					CmbAltUnit.Focus();
					return;
				}
			}
		}
		private void TxtGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtGroup)return;
            if (TxtGroup.Enabled == false)return;
            if (string.IsNullOrEmpty(TxtGroup.Text))
            {
                TxtSubGroup.Text = "";
                TxtSubGroup.Tag = "0";
            }
        }
        private bool SetTextBoxValueToGridPurchaseTerm()
        {
            DataGridViewRow ro = new DataGridViewRow();
            ro = GridPurchaseTerm.Rows[GridPurchaseTerm.CurrentRow.Index];
            ro.Cells["PurchaseTermRate"].Value = TxtPurchaseTermRate.Text.Trim();
            return true;
        }
        #endregion
    }
}
