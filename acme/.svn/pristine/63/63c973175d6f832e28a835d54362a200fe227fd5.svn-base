using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using acmedesktop.Common;
using acmedesktop.DataTransaction.Sales;
using acmedesktop.MasterSetup;
using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction.Normal_Production;
using DataAccessLayer.Interface.DataTransaction.Normal_Production;

namespace acmedesktop.DataTransaction.NormalProduction
{
    public partial class FrmBOM : Form
    {

        MyGridPickListTextBox TxtGridRawProduct;
        MyGridPickListTextBox TxtGridGodown;
        MyGridPickListTextBox TxtGridCostCenter;
        MyGridNumericTextBox TxtGridAltQty;
        MyGridPickListTextBox TxtGridAltUOM;
        MyGridNumericTextBox TxtGridQty;
        MyGridPickListTextBox TxtGridQtyUOM;

		MyGridPickListTextBox TxtGridFinishedProduct;
		MyGridPickListTextBox TxtGridFinishedGodown;
		MyGridPickListTextBox TxtGridFinishedCostCenter;
		MyGridNumericTextBox TxtGridFinishedAltQty;
		MyGridPickListTextBox TxtGridFinishedAltUOM;
		MyGridNumericTextBox TxtGridFinishedQty;
		MyGridPickListTextBox TxtGridFinishedQtyUOM;
		//MyGridNumericTextBox TxtGridFinishedRate;
		//MyGridNumericTextBox TxtGridFinishedAmount;
		MyGridNumericTextBox TxtGridFinishedCosting;
		Boolean _GridControlMode { get; set; }
        string _Tag = "", _SearchKey="", _VoucherNo = "";
		int Indexcount;

		IBillOfMaterial _objBillOfMaterial = new ClsBillOfMaterial();

        public FrmBOM()
        {
            InitializeComponent();

            TxtGridRawProduct = new MyGridPickListTextBox(Grid);
            TxtGridRawProduct.Validating += new System.ComponentModel.CancelEventHandler(TxtGridRawProduct_Validating);
            TxtGridRawProduct.PickListType = MyGridPickListTextBox.ListType.Product;

            TxtGridCostCenter = new MyGridPickListTextBox(Grid);
            TxtGridCostCenter.Validating += new System.ComponentModel.CancelEventHandler(TxtGridCostCenter_Validating);
            TxtGridCostCenter.PickListType = MyGridPickListTextBox.ListType.CostCenter;

            TxtGridGodown = new MyGridPickListTextBox(Grid);
            TxtGridGodown.Validating += new System.ComponentModel.CancelEventHandler(TxtGridGodown_Validating);
            TxtGridGodown.PickListType = MyGridPickListTextBox.ListType.GoDown;

            TxtGridAltQty = new MyGridNumericTextBox(Grid);
            TxtGridAltQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridAltQty_Validating);
            TxtGridAltQty.TextChanged += new System.EventHandler(TxtGridAltQty_TextChanged);

            TxtGridAltUOM = new MyGridPickListTextBox(Grid);
            TxtGridAltUOM.PickListType = MyGridPickListTextBox.ListType.ProductUnit;
            // TxtGridGodown.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridGodown_Validating);

            TxtGridQty = new MyGridNumericTextBox(Grid);
            TxtGridQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridQty_Validating);
            TxtGridQty.TextChanged += new System.EventHandler(TxtGridQty_TextChanged);

            TxtGridQtyUOM = new MyGridPickListTextBox(Grid);
            TxtGridQtyUOM.PickListType = MyGridPickListTextBox.ListType.ProductUnit;

			TxtGridFinishedProduct = new MyGridPickListTextBox(GridFinished);
			TxtGridFinishedProduct.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedProduct_Validating);
			TxtGridFinishedProduct.PickListType = MyGridPickListTextBox.ListType.Product;

			TxtGridFinishedCostCenter = new MyGridPickListTextBox(GridFinished);
			TxtGridFinishedCostCenter.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedCostCenter_Validating);
			TxtGridFinishedCostCenter.PickListType = MyGridPickListTextBox.ListType.CostCenter;

			TxtGridFinishedGodown = new MyGridPickListTextBox(GridFinished);
			TxtGridFinishedGodown.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedGodown_Validating);
			TxtGridFinishedGodown.PickListType = MyGridPickListTextBox.ListType.GoDown;

			TxtGridFinishedAltQty = new MyGridNumericTextBox(GridFinished);
			TxtGridFinishedAltQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedAltQty_Validating);
			TxtGridFinishedAltQty.TextChanged += new System.EventHandler(TxtGridFinishedAltQty_TextChanged);

			TxtGridFinishedAltUOM = new MyGridPickListTextBox(GridFinished);
			TxtGridFinishedAltUOM.PickListType = MyGridPickListTextBox.ListType.ProductUnit;
			// TxtGridGodown.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridGodown_Validating);

			TxtGridFinishedQty = new MyGridNumericTextBox(GridFinished);
			TxtGridFinishedQty.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedQty_Validating);
			TxtGridFinishedQty.TextChanged += new System.EventHandler(TxtGridFinishedQty_TextChanged);

			TxtGridFinishedQtyUOM = new MyGridPickListTextBox(GridFinished);
			TxtGridFinishedQtyUOM.PickListType = MyGridPickListTextBox.ListType.ProductUnit;

			//TxtGridFinishedRate = new MyGridNumericTextBox(GridFinished);
			//TxtGridFinishedRate.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedRate_Validating);
			//TxtGridFinishedRate.TextChanged += new System.EventHandler(TxtGridFinishedRate_TextChanged);

			//TxtGridFinishedAmount = new MyGridNumericTextBox(GridFinished);
			//TxtGridFinishedAmount.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedAmount_Validating);
			//TxtGridFinishedAmount.TextChanged += new System.EventHandler(TxtGridFinishedAmount_TextChanged);

			TxtGridFinishedCosting = new MyGridNumericTextBox(GridFinished);
			TxtGridFinishedCosting.Validating += new System.ComponentModel.CancelEventHandler(TxtGridFinishedCosting_Validating);
			TxtGridFinishedCosting.TextChanged += new System.EventHandler(TxtGridFinishedCosting_TextChanged);

		}

		private void TxtGridFinishedCosting_TextChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void TxtGridFinishedCosting_Validating(object sender, CancelEventArgs e)
		{

			if (SetTextBoxValueToGridFinished() == true)
			{
				if (GridFinished.CurrentRow.Index == (GridFinished.Rows.Count - 1))
				{
					GridFinished.Rows.Add();
					GridFinished.CurrentCell = GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedGoods"];
				}
				else
				{
					GridFinished.CurrentCell = GridFinished.Rows[GridFinished.CurrentRow.Index + 1].Cells["FinishedGoods"];
				}

				GridFinishedControlMode(true);
			}
		}

		private void TxtGridFinishedAmount_TextChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void TxtGridFinishedCostCenter_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtGridFinishedCostCenter) return;
			if (TxtGridFinishedCostCenter.Enabled == false) return;

			if (!string.IsNullOrEmpty(TxtGridFinishedProduct.Text))
			{
				if (string.IsNullOrEmpty(TxtGridFinishedCostCenter.Text))
				{
					MessageBox.Show("Cost Center cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtGridFinishedCostCenter.Focus();
					return;
				}
			}
		}

		private void TxtGridFinishedGodown_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtGridFinishedGodown) return;
			if (TxtGridFinishedGodown.Enabled == false) return;

			if (!string.IsNullOrEmpty(TxtGridFinishedProduct.Text))
			{
				if (string.IsNullOrEmpty(TxtGridFinishedGodown.Text))
				{
					MessageBox.Show("Godown cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtGridFinishedGodown.Focus();
					return;
				}
			}
		}

		private void TxtGridFinishedAltQty_Validating(object sender, CancelEventArgs e)
		{
			decimal _convRatio = TxtGridFinishedProduct.AltConversion;
			if (ClsGlobal.InventoryAltQtyConversionRatioChange == "Y" && !string.IsNullOrEmpty(TxtGridFinishedAltQty.Text))
			{
				ConversionQty frm = new ConversionQty(ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridFinishedProduct.ProductQtyConversion), 1, ClsGlobal._QtyDecimalFormat));
				frm.ShowDialog();
				TxtGridFinishedProduct.ProductQtyConversion = frm._ConversionQty;
			}

			if (ClsGlobal.InventoryAltQtyConversion == "Y" && Convert.ToDecimal(TxtGridFinishedProduct.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
			{
				TxtGridFinishedQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridFinishedAltQty.Text) ? "0" : TxtGridFinishedAltQty.Text) * Convert.ToDecimal(TxtGridFinishedProduct.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
			}
			else if (ClsGlobal.InventoryAltQtyConversion == "N" && Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
			{
				TxtGridFinishedQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridFinishedAltQty.Text) ? "0" : TxtGridFinishedAltQty.Text) * Convert.ToDecimal(TxtGridFinishedProduct.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
			}
		}

		private void TxtGridFinishedAltQty_TextChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void TxtGridFinishedQty_Validating(object sender, CancelEventArgs e)
		{
			decimal.TryParse(TxtGridFinishedQty.Text, out decimal _Qty);
			if (_Qty <= 0)
			{
				TxtGridFinishedQty.Focus();
				return;
			}
			decimal _convRatio = TxtGridFinishedProduct.AltConversion;
			if (ClsGlobal.InventoryAltQtyConversion == "Y" && TxtGridFinishedAltQty.Enabled == true && Convert.ToDecimal(TxtGridFinishedProduct.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
			{
				TxtGridFinishedAltQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridFinishedQty.Text) ? "0" : TxtGridFinishedQty.Text) / Convert.ToDecimal(TxtGridFinishedProduct.ProductQtyConversion.ToString()) * _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
			}

		}

		private void TxtGridFinishedQty_TextChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void TxtGridFinishedProduct_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtGridFinishedProduct) return;
			if (TxtGridFinishedProduct.Enabled == false) return;

			if (string.IsNullOrEmpty(TxtGridFinishedProduct.Text))
			{
				if (Grid.Rows.Count <= 1)
				{
					MessageBox.Show("Finished goods cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtGridFinishedProduct.Focus();
					return;
				}
				else
				{
					GridFinishedControlMode(false);
				}
			}

			if (!string.IsNullOrEmpty(TxtGridFinishedProduct.Text))
			{
				Indexcount = GridFinished.Rows.Count;
				if (TxtGridFinishedProduct.ProductDetails.Count > 0)
				{
					if (!GridFinished.Columns["FinishedGodown"].Visible)
					{
						TxtGridFinishedGodown.Text = "";
					}
					else if ((GridFinished.Rows[0].Cells["FinishedGodown"].Value == null || Indexcount <= 0 ? false : TxtGridFinishedGodown.Text == ""))
					{
						if (Indexcount != 1)
						{
							TxtGridFinishedGodown.Text = GridFinished.Rows[Indexcount - 2].Cells["FinishedGodown"].Value.ToString();
						}
						else
						{
							TxtGridFinishedGodown.Text = GridFinished.Rows[0].Cells["FinishedGodown"].Value.ToString();
						}
					}

					//LblProductShortName.Text = TxtGridRawProduct.ProductDetails["ProductShortName"].ToString();
					TxtGridFinishedAltUOM.Text = TxtGridFinishedProduct.ProductDetails["ProductAltUnit"].ToString();
					TxtGridFinishedAltUOM.Tag = TxtGridFinishedProduct.ProductDetails["ProductAltUnitId"].ToString();
					TxtGridFinishedQtyUOM.Text = TxtGridFinishedProduct.ProductDetails["ProductUnit"].ToString();
					TxtGridFinishedQtyUOM.Tag = TxtGridFinishedProduct.ProductDetails["ProductUnitId"].ToString();
					TxtGridFinishedProduct.ProductDetails.Clear();

					if (Indexcount == 1)
						TxtGridFinishedCosting.Text = "100";
				}
				if (!string.IsNullOrEmpty(TxtGridFinishedAltUOM.Text))
				{
					TxtGridFinishedAltUOM.Enabled = false;
					TxtGridFinishedAltQty.Enabled = true;
					Utility.EnableDesibleColor(TxtGridFinishedAltUOM, false);
					Utility.EnableDesibleColor(TxtGridFinishedAltQty, true);
				}
				else
				{
					TxtGridFinishedAltUOM.Enabled = false;
					TxtGridFinishedAltQty.Enabled = false;
					Utility.EnableDesibleColor(TxtGridFinishedAltUOM, false);
					Utility.EnableDesibleColor(TxtGridFinishedAltQty, false);
					if (TxtGridFinishedGodown.Visible == false)
						TxtGridFinishedQty.Focus();
				}
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
            LblStockAltQty.Text = "";
            LblStockQty.Text = "";

			TxtGridRawProduct.Text ="";
			TxtGridGodown.Text = "";
			TxtGridCostCenter.Text = "";
			TxtGridAltQty.Text = "";
			TxtGridAltUOM.Text = "";
			TxtGridQty.Text = "";
			TxtGridQtyUOM.Text = "";

			TxtGridFinishedProduct.Text = "";
			TxtGridFinishedGodown.Text = "";
			TxtGridFinishedCostCenter.Text = "";
			TxtGridFinishedAltQty.Text = "";
			TxtGridFinishedAltUOM.Text = "";
			TxtGridFinishedQty.Text = "";
			TxtGridFinishedQtyUOM.Text = "";
		    TxtGridFinishedCosting.Text = "";

			Grid.Rows.Clear();
            Grid.Rows.Add();
			GridFinished.Rows.Clear();
			GridFinished.Rows.Add();

		}

        public void ControlEnableDisable(bool btn, bool fld)
        {
            BtnNew.Enabled = btn;
            BtnEdit.Enabled = btn;
            BtnDelete.Enabled = btn;
            BtnExit.Enabled = btn;
            BtnCopy.Enabled = btn;
            BtnPrint.Enabled = btn;
            BtnFirstData.Enabled = btn;
            BtnNextData.Enabled = btn;
            BtnPreviousData.Enabled = btn;
            BtnLastData.Enabled = btn;
            //if (BtnNew.Enabled == true) { BtnNew.Focus(); }
            TxtVoucherNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtVoucherNo, fld);
            BtnVoucherNoSearch.Enabled = fld;

            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtDepartment.Enabled = fld;
            Utility.EnableDesibleColor(TxtDepartment, fld);

            TxtRemarks.Enabled = fld;
            Utility.EnableDesibleColor(TxtRemarks, fld);

            BtnOk.Enabled = fld;
            BtnCancel.Enabled = fld;

            Grid.Enabled = true;

            if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
            {
                if (ClsGlobal.InventoryDepartmentControlVal == 'Y')
                {
                    TxtDepartment.Enabled = true;
                    Utility.EnableDesibleColor(TxtDepartment, true);
                }
                else
                {
                    TxtDepartment.Enabled = false;
                    Utility.EnableDesibleColor(TxtDepartment, false);
                }

                if (ClsGlobal.InventoryRemarksControlVal == 'Y')
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

            if (TxtGridRawProduct.Visible == true)
            {
                GridControlMode(false);
                Grid.Focus();
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
                    TxtGridRawProduct.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridRawProduct.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
                    {
                        if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y')
                        {
                            colindex = Grid.Columns["CostCenter"].Index;
                            TxtGridCostCenter.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                            TxtGridCostCenter.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                            Utility.EnableDesibleColor(TxtGridCostCenter, true);
                        }

                        if (ClsGlobal.InventoryGodownItemControlVal  == 'Y')
                        {
                            colindex = Grid.Columns["GodownDesc"].Index;
                            TxtGridGodown.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                            TxtGridGodown.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                            Utility.EnableDesibleColor(TxtGridGodown, true);
                        }
                    }
                    colindex = Grid.Columns["AltQty"].Index;
                    TxtGridAltQty.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridAltQty.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["AltUOM"].Index;
                    TxtGridAltUOM.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridAltUOM.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["Qty"].Index;
                    TxtGridQty.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridQty.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["UOM"].Index;
                    TxtGridQtyUOM.Size = Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridQtyUOM.Location = Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                }
                SetGridValueToTextBox(currRo);
            }

            TxtGridRawProduct.Enabled = mode;
            TxtGridRawProduct.Visible = mode;

            BtnOk.Enabled = (mode==true)?false:true;

            if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y')
                Grid.Columns["CostCenter"].Visible = true;
            else
                Grid.Columns["CostCenter"].Visible = false;

            if (ClsGlobal.InventoryGodownItemControlVal == 'Y')
                Grid.Columns["GodownDesc"].Visible = true;
            else
                Grid.Columns["GodownDesc"].Visible = false;


            if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
                TxtGridCostCenter.Visible = mode;
            else
                TxtGridCostCenter.Visible = false;

            if (ClsGlobal.InventoryGodownItemControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
                TxtGridGodown.Visible = mode;
            else
                TxtGridGodown.Visible = false;

            TxtGridAltQty.Enabled = mode;
            TxtGridAltQty.Visible = mode;

            TxtGridAltUOM.Visible = mode;
            TxtGridAltUOM.Enabled = false;

            TxtGridQty.Enabled = mode;
            TxtGridQty.Visible = mode;

            TxtGridQtyUOM.Visible = mode;
            TxtGridQtyUOM.Enabled = false;

            if (mode == true)
                TxtGridRawProduct.Focus();
        }

		private void GridFinishedControlMode(bool mode)
		{
			if (GridFinished.CurrentRow != null)
			{
				int currRo = GridFinished.CurrentRow.Index;
				int colindex = 0;
				if (mode == true)
				{
					colindex = GridFinished.Columns["FinishedGoods"].Index;
					TxtGridFinishedProduct.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
					TxtGridFinishedProduct.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;

					if (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT")
					{
						if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y')
						{
							colindex = GridFinished.Columns["FinishedCostCenter"].Index;
							TxtGridFinishedCostCenter.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
							TxtGridFinishedCostCenter.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;
							Utility.EnableDesibleColor(TxtGridFinishedCostCenter, true);
						}

						if (ClsGlobal.InventoryGodownItemControlVal == 'Y')
						{
							colindex = GridFinished.Columns["FinishedGodown"].Index;
							TxtGridFinishedGodown.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
							TxtGridFinishedGodown.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;
							Utility.EnableDesibleColor(TxtGridFinishedGodown, true);
						}
					}
					colindex = GridFinished.Columns["FinishedAltQty"].Index;
					TxtGridFinishedAltQty.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
					TxtGridFinishedAltQty.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;

					colindex = GridFinished.Columns["FinishedAltUnit"].Index;
					TxtGridFinishedAltUOM.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
					TxtGridFinishedAltUOM.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;

					colindex = GridFinished.Columns["FinishedQty"].Index;
					TxtGridFinishedQty.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
					TxtGridFinishedQty.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;

					colindex = GridFinished.Columns["FinishedUnit"].Index;
					TxtGridFinishedQtyUOM.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
					TxtGridFinishedQtyUOM.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;

					colindex = GridFinished.Columns["FinishedCosting"].Index;
					TxtGridFinishedCosting.Size = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Size;
					TxtGridFinishedCosting.Location = GridFinished.GetCellDisplayRectangle(colindex, currRo, true).Location;

					//if (currRo == 0)
					//	TxtGridFinishedCosting.Text = "100";


				}
				SetGridFinishedValueToTextBox(currRo);
			}

			TxtGridFinishedProduct.Enabled = mode;
			TxtGridFinishedProduct.Visible = mode;

			BtnOk.Enabled = (mode == true) ? false : true;

			if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y')
				GridFinished.Columns["FinishedCostCenter"].Visible = true;
			else
				GridFinished.Columns["FinishedCostCenter"].Visible = false;

			if (ClsGlobal.InventoryGodownItemControlVal == 'Y')
				GridFinished.Columns["FinishedGodown"].Visible = true;
			else
				GridFinished.Columns["FinishedGodown"].Visible = false;


			if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
				TxtGridFinishedCostCenter.Visible = mode;
			else
				TxtGridFinishedCostCenter.Visible = false;

			if (ClsGlobal.InventoryGodownItemControlVal == 'Y' && (_Tag.ToString() == "NEW" || _Tag.ToString() == "EDIT"))
				TxtGridFinishedGodown.Visible = mode;
			else
				TxtGridFinishedGodown.Visible = false;

			TxtGridFinishedAltQty.Enabled = mode;
			TxtGridFinishedAltQty.Visible = mode;

			TxtGridFinishedAltUOM.Visible = mode;
			TxtGridFinishedAltUOM.Enabled = false;

			TxtGridFinishedQty.Enabled = mode;
			TxtGridFinishedQty.Visible = mode;

			TxtGridFinishedQtyUOM.Visible = mode;
			TxtGridFinishedQtyUOM.Enabled = false;

			TxtGridFinishedCosting.Enabled = mode;
			TxtGridFinishedCosting.Visible = mode;


			if (mode == true)
				TxtGridFinishedProduct.Focus();
		}
		private bool SetTextBoxValueToGrid()
        {
            if (string.IsNullOrEmpty(TxtGridRawProduct.Text))
            {
                TxtGridRawProduct.Focus();
                return false; // return false for not add grid new 1 row
            }
            else
            {
                Utility.EnableDesibleColor(TxtGridAltUOM, true);
                Utility.EnableDesibleColor(TxtGridAltQty, true);
                DataGridViewRow ro = new DataGridViewRow();
                ro = Grid.Rows[Grid.CurrentRow.Index];
                ro.Cells["SNo"].Value = Grid.CurrentRow.Index + 1;
                ro.Cells["Particular"].Value = TxtGridRawProduct.Text;
                ro.Cells["ProductId"].Value = TxtGridRawProduct.Tag.ToString();
                ro.Cells["AltConversion"].Value = TxtGridRawProduct.AltConversion.ToString();
                ro.Cells["ProductShortName"].Value = TxtGridRawProduct.ProductShortName.ToString();
                ro.Cells["QtyConversion"].Value = TxtGridRawProduct.ProductQtyConversion.ToString();
				// ro.Cells["TermDetails"].Value = TxtGridRawProduct.Text;

				if (TxtGridCostCenter.Visible == true)
				{
					ro.Cells["CostCenter"].Value = TxtGridCostCenter.Text;
					if (string.IsNullOrEmpty(TxtGridCostCenter.Text.Trim()))
						ro.Cells["CostCenterID"].Value = "0";
					else
						ro.Cells["CostCenterID"].Value = TxtGridCostCenter.Tag != null ? TxtGridCostCenter.Tag.ToString() : "0";
				}

				if (TxtGridGodown.Visible == true)
                {
                    ro.Cells["GodownDesc"].Value = TxtGridGodown.Text;
                    if (string.IsNullOrEmpty(TxtGridGodown.Text.Trim()))
                        ro.Cells["GodownId"].Value = "0";
                    else
                        ro.Cells["GodownId"].Value = TxtGridGodown.Tag != null ? TxtGridGodown.Tag.ToString() : "0";
                }

                if (!string.IsNullOrEmpty(TxtGridAltQty.Text))
                {
                    ro.Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridAltQty.Text), 1, ClsGlobal._AltQtyDecimalFormat);
                }

                ro.Cells["AltUOM"].Value = TxtGridAltUOM.Text;

                if (string.IsNullOrEmpty(TxtGridAltUOM.Text.Trim()))
                    ro.Cells["AltProductUnitId"].Value = "0";
                else
                    ro.Cells["AltProductUnitId"].Value = !string.IsNullOrEmpty(TxtGridAltUOM.Tag.ToString()) ? TxtGridAltUOM.Tag.ToString() : "0";

                if (!string.IsNullOrEmpty(TxtGridQty.Text))
                {
                    ro.Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridQty.Text), 1, ClsGlobal._QtyDecimalFormat);
                }
                ro.Cells["UOM"].Value = TxtGridQtyUOM.Text;

                if (string.IsNullOrEmpty(TxtGridQtyUOM.Text.Trim()))
                    ro.Cells["ProductUnitId"].Value = "0";
                else
                    ro.Cells["ProductUnitId"].Value = !string.IsNullOrEmpty(TxtGridQtyUOM.Tag.ToString()) ? TxtGridQtyUOM.Tag.ToString() : "0";


                if (!string.IsNullOrEmpty(LblStockAltQty.Text))
                {
                    ro.Cells["AltStockQty"].Value = LblStockAltQty.Text;
                }
                if (!string.IsNullOrEmpty(LblStockQty.Text))
                {
                    ro.Cells["StockQty"].Value = LblStockQty.Text;
                }
                CalTotal();
            }
            return true; // return true for add grid new row
        }
		private bool SetTextBoxValueToGridFinished()
		{
			if (string.IsNullOrEmpty(TxtGridFinishedProduct.Text))
			{
				TxtGridFinishedProduct.Focus();
				return false; // return false for not add grid new 1 row
			}
			else
			{
				Utility.EnableDesibleColor(TxtGridAltUOM, true);
				Utility.EnableDesibleColor(TxtGridAltQty, true);
				DataGridViewRow ro = new DataGridViewRow();
				ro = GridFinished.Rows[GridFinished.CurrentRow.Index];
				ro.Cells["FinishedSNo"].Value = GridFinished.CurrentRow.Index + 1;
				ro.Cells["FinishedGoods"].Value = TxtGridFinishedProduct.Text;
				ro.Cells["FinishedProductId"].Value = TxtGridFinishedProduct.Tag.ToString();
				//ro.Cells["AltConversion"].Value = TxtGridFinishedProduct.AltConversion.ToString();
				ro.Cells["FinishedProductShortName"].Value = TxtGridFinishedProduct.ProductShortName.ToString();
				//ro.Cells["QtyConversion"].Value = TxtGridFinishedProduct.ProductQtyConversion.ToString();
				// ro.Cells["TermDetails"].Value = TxtGridRawProduct.Text;

				if (TxtGridFinishedCostCenter.Visible == true)
				{
					ro.Cells["FinishedCostCenter"].Value = TxtGridFinishedCostCenter.Text;
					if (string.IsNullOrEmpty(TxtGridFinishedCostCenter.Text.Trim()))
						ro.Cells["FinishedCostCenterID"].Value = "0";
					else
						ro.Cells["FinishedCostCenterID"].Value = TxtGridFinishedCostCenter.Tag != null ? TxtGridFinishedCostCenter.Tag.ToString() : "0";
				}

				if (TxtGridFinishedGodown.Visible == true)
				{
					ro.Cells["FinishedGodown"].Value = TxtGridFinishedGodown.Text;
					if (string.IsNullOrEmpty(TxtGridFinishedGodown.Text.Trim()))
						ro.Cells["FinishedGodownId"].Value = "0";
					else
						ro.Cells["FinishedGodownId"].Value = TxtGridFinishedGodown.Tag != null ? TxtGridFinishedGodown.Tag.ToString() : "0";
				}

				if (!string.IsNullOrEmpty(TxtGridFinishedAltQty.Text))
				{
					ro.Cells["FinishedAltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridFinishedAltQty.Text), 1, ClsGlobal._AltQtyDecimalFormat);
				}

				ro.Cells["FinishedAltUnit"].Value = TxtGridFinishedAltUOM.Text;

				if (string.IsNullOrEmpty(TxtGridFinishedAltUOM.Text.Trim()))
					ro.Cells["FinishedAltProductUnitId"].Value = "0";
				else
					ro.Cells["FinishedAltProductUnitId"].Value = !string.IsNullOrEmpty(TxtGridFinishedAltUOM.Tag.ToString()) ? TxtGridFinishedAltUOM.Tag.ToString() : "0";

				if (!string.IsNullOrEmpty(TxtGridFinishedQty.Text))
				{
					ro.Cells["FinishedQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridFinishedQty.Text), 1, ClsGlobal._QtyDecimalFormat);
				}
				ro.Cells["FinishedUnit"].Value = TxtGridFinishedQtyUOM.Text;

				if (string.IsNullOrEmpty(TxtGridFinishedAltUOM.Text.Trim()))
					ro.Cells["FinishedUnitId"].Value = "0";
				else
					ro.Cells["FinishedUnitId"].Value = !string.IsNullOrEmpty(TxtGridFinishedQtyUOM.Tag.ToString()) ? TxtGridFinishedQtyUOM.Tag.ToString() : "0";

				if (string.IsNullOrEmpty(TxtGridFinishedCosting.Text.Trim()))
					ro.Cells["FinishedCosting"].Value = "0";
				else
					ro.Cells["FinishedCosting"].Value = !string.IsNullOrEmpty(TxtGridFinishedCosting.Text.ToString()) ? TxtGridFinishedCosting.Text.ToString() : "0";

			}
			return true; // return true for add grid new row
		}
		private void CalTotal()
        {
            decimal totalAltqty = 0;
            decimal totalQty = 0;
          
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                // BasicAmt,TermsAmt,NetAmt
                if (ro.Cells["AltQty"].Value != null)
                {
                    totalAltqty += (string.IsNullOrEmpty(ro.Cells["AltQty"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["AltQty"].Value.ToString()));
                }
                if (ro.Cells["Qty"].Value != null)
                {
                    totalQty += (string.IsNullOrEmpty(ro.Cells["Qty"].Value.ToString()) ? 0 : Convert.ToDecimal(ro.Cells["Qty"].Value.ToString()));
                }
                ro.Cells["SNo"].Value = Grid.Rows.IndexOf(ro) + 1;
            }

            LblTotalAltQty.Text = ClsGlobal.DecimalFormate(totalAltqty, 1, ClsGlobal._AltQtyDecimalFormat);
            LblTotalQty.Text = ClsGlobal.DecimalFormate(totalQty, 1, ClsGlobal._QtyDecimalFormat);
        }
        private void SetGridValueToTextBox(int row)
        {
            TxtGridRawProduct.Text = "";
            TxtGridRawProduct.Tag = "0";
            TxtGridRawProduct.ProductShortName = "";
            TxtGridRawProduct.ProductQtyConversion = "0";
            //TxtGridGodown.Text = "";
            //TxtGridGodown.Tag = "0";
            TxtGridAltQty.Text = "";
            TxtGridAltUOM.Text = "";
            TxtGridAltUOM.Tag = "0";
            TxtGridQty.Text = "";
            TxtGridQtyUOM.Text = "";
            TxtGridQtyUOM.Tag = "0";
           

            if (Grid["Particular", row].Value != null)
            {
                TxtGridRawProduct.Text = Grid["Particular", row].Value.ToString();
                TxtGridRawProduct.Tag = Grid["ProductId", row].Value.ToString();
                TxtGridRawProduct.AltConversion = Convert.ToDecimal(Grid["AltConversion", row].Value.ToString());
                TxtGridRawProduct.ProductShortName = Grid["ProductShortName", row].Value.ToString();
                //TxtGridRawProduct.ProductQtyConversion = Grid["AltConversion", row].Value.ToString();
                //TxtGridRawProduct.Text = Grid["TermDetails", row].Value.ToString();
            }
            else
            {
                LblProductShortName.Text = "";
                LblStockAltQty.Text = "";
                LblStockQty.Text = "";
                LblTotalAltQty.Text = "";
                LblTotalQty.Text = "";
            }
			if (ClsGlobal.InventoryCostCenterItemControlVal  == 'Y')
			{
				if (Grid["CostCenter", row].Value != null)
				{
					TxtGridCostCenter.Text = Grid["CostCenter", row].Value.ToString();
					TxtGridCostCenter.Tag = Grid["CostCenterID", row].Value.ToString();
				}
			}

			if (ClsGlobal.InventoryGodownItemControlVal == 'Y')
            {
                if (Grid["GodownDesc", row].Value != null)
                {
                    TxtGridGodown.Text = Grid["GodownDesc", row].Value.ToString();
                    TxtGridGodown.Tag = Grid["GodownId", row].Value.ToString();
                }
            }

            if (Grid["AltQty", row].Value != null)
            {
                TxtGridAltQty.Text = Grid["AltQty", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["AltUOM", row].Value != null)
            {
                TxtGridAltUOM.Text = Grid["AltUOM", row].Value.ToString();
                TxtGridAltUOM.Tag = Grid["AltProductUnitId", row].Value.ToString();
            }

            if (Grid["Qty", row].Value != null)
            {
                TxtGridQty.Text = Grid["Qty", row].Value.ToString().Replace(",", string.Empty);
            }

            if (Grid["UOM", row].Value != null)
            {
                TxtGridQtyUOM.Text = Grid["UOM", row].Value.ToString();
                TxtGridQtyUOM.Tag = Grid["ProductUnitId", row].Value.ToString();
            }

			if (Grid["AltStockQty", row].Value != null)
				LblStockAltQty.Text = Grid["AltStockQty", row].Value.ToString().Replace(",", string.Empty);
			else
				LblStockAltQty.Text = "";
			if (Grid["StockQty", row].Value != null)
				LblStockQty.Text = Grid["StockQty", row].Value.ToString().Replace(",", string.Empty);
			else
				LblStockQty.Text = "";
		}

		private void SetGridFinishedValueToTextBox(int row)
		{
			TxtGridFinishedProduct.Text = "";
			TxtGridFinishedProduct.Tag = "0";
			TxtGridFinishedProduct.ProductShortName = "";
			TxtGridFinishedProduct.ProductQtyConversion = "0";
			//TxtGridFinishedGodown.Text = "";
			//TxtGridFinishedGodown.Tag = "0";
			TxtGridFinishedAltQty.Text = "";
			TxtGridFinishedAltUOM.Text = "";
			TxtGridFinishedAltUOM.Tag = "0";
			TxtGridFinishedQty.Text = "";
			TxtGridFinishedQtyUOM.Text = "";
			TxtGridFinishedQtyUOM.Tag = "0";
			TxtGridFinishedCosting.Text = "";

			if (GridFinished["FinishedGoods", row].Value != null)
			{
				TxtGridFinishedProduct.Text = GridFinished["FinishedGoods", row].Value.ToString();
				TxtGridFinishedProduct.Tag = GridFinished["FinishedProductId", row].Value.ToString();
				//TxtGridFinishedProduct.AltConversion = Convert.ToDecimal(GridFinished["AltConversion", row].Value.ToString());
				TxtGridFinishedProduct.ProductShortName = GridFinished["FinishedProductShortName", row].Value.ToString();
				//TxtGridRawProduct.ProductQtyConversion = Grid["AltConversion", row].Value.ToString();
				//TxtGridRawProduct.Text = Grid["TermDetails", row].Value.ToString();
			}
			else
			{
				//LblProductShortName.Text = "";
				//LblStockAltQty.Text = "";
				//LblStockQty.Text = "";
				//LblTotalAltQty.Text = "";
				//LblTotalQty.Text = "";
			}
			if (ClsGlobal.InventoryCostCenterItemControlVal == 'Y')
			{
				if (GridFinished["FinishedCostCenter", row].Value != null)
				{
					TxtGridFinishedCostCenter.Text = GridFinished["FinishedCostCenter", row].Value.ToString();
					TxtGridFinishedCostCenter.Tag = GridFinished["FinishedCostCenterID", row].Value.ToString();
				}
			}

			if (ClsGlobal.InventoryGodownItemControlVal == 'Y')
			{
				if (GridFinished["FinishedGodown", row].Value != null)
				{
					TxtGridFinishedGodown.Text = GridFinished["FinishedGodown", row].Value.ToString();
					TxtGridFinishedGodown.Tag = GridFinished["FinishedGodownId", row].Value.ToString();
				}
			}

			if (GridFinished["FinishedAltQty", row].Value != null)
			{
				TxtGridFinishedAltQty.Text = GridFinished["FinishedAltQty", row].Value.ToString();
			}

			if (GridFinished["FinishedAltUnit", row].Value != null)
			{
				TxtGridFinishedAltUOM.Text = GridFinished["FinishedAltUnit", row].Value.ToString();
				TxtGridFinishedAltUOM.Tag = GridFinished["FinishedAltProductUnitId", row].Value.ToString();
			}

			if (GridFinished["FinishedQty", row].Value != null)
			{
				TxtGridFinishedQty.Text = GridFinished["FinishedQty", row].Value.ToString();
			}

			if (GridFinished["FinishedUnit", row].Value != null)
			{
				TxtGridFinishedQtyUOM.Text = GridFinished["FinishedUnit", row].Value.ToString();
				TxtGridFinishedQtyUOM.Tag = GridFinished["FinishedUnitId", row].Value.ToString();
			}

			if (GridFinished["FinishedCosting", row].Value != null)
			{
				TxtGridFinishedCosting.Text = GridFinished["FinishedCosting", row].Value.ToString();
			}



		}
		private void TxtGridQty_TextChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void TxtGridQty_Validating(object sender, CancelEventArgs e)
        {
            decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
            if (_Qty <= 0)
            {
                TxtGridQty.Focus();
                return;
            }
            decimal _convRatio = TxtGridRawProduct.AltConversion;
            if (ClsGlobal.InventoryAltQtyConversion == "Y" && TxtGridAltQty.Enabled == true && Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridAltQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridQty.Text) ? "0" : TxtGridQty.Text) / Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) * _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }

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

                GridControlMode(true);
            }
        }

        private void TxtGridAltQty_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtGridAltQty_Validating(object sender, CancelEventArgs e)
        {
            decimal _convRatio = TxtGridRawProduct.AltConversion;
            if (ClsGlobal.InventoryAltQtyConversionRatioChange == "Y" && !string.IsNullOrEmpty(TxtGridAltQty.Text))
            {
                ConversionQty frm = new ConversionQty(ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion), 1, ClsGlobal._QtyDecimalFormat));
                frm.ShowDialog();
                TxtGridRawProduct.ProductQtyConversion = frm._ConversionQty;
            }

            if (ClsGlobal.InventoryAltQtyConversion == "Y" && Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridAltQty.Text) ? "0" : TxtGridAltQty.Text) * Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }
            else if (ClsGlobal.InventoryAltQtyConversion == "N" && Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) > 0 && _convRatio > 0)
            {
                TxtGridQty.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(string.IsNullOrEmpty(TxtGridAltQty.Text) ? "0" : TxtGridAltQty.Text) * Convert.ToDecimal(TxtGridRawProduct.ProductQtyConversion.ToString()) / _convRatio), 1, ClsGlobal._QtyDecimalFormat).ToString();
            }
        }

		private void TxtGridCostCenter_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtGridCostCenter) return;
			if (TxtGridCostCenter.Enabled == false) return;

			if (!string.IsNullOrEmpty(TxtGridRawProduct.Text))
			{
				if (string.IsNullOrEmpty(TxtGridCostCenter.Text))
				{
					MessageBox.Show("Cost Center cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtGridCostCenter.Focus();
					return;
				}
			}
		}

        private void TxtGridGodown_Validating(object sender, CancelEventArgs e)
        {
			if (_Tag == "" || ActiveControl == TxtGridGodown) return;
			if (TxtGridGodown.Enabled == false) return;

			if (!string.IsNullOrEmpty(TxtGridRawProduct.Text))
			{
				if (string.IsNullOrEmpty(TxtGridGodown.Text))
				{
					MessageBox.Show("Godown cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtGridGodown.Focus();
					return;
				}
			}
		}

        private void TxtGridRawProduct_Validating(object sender, CancelEventArgs e)
        {
			if (_Tag == "" || ActiveControl == TxtGridRawProduct) return;
			if (TxtGridRawProduct.Enabled == false) return;

			if (string.IsNullOrEmpty(TxtGridRawProduct.Text))
			{
				if (Grid.Rows.Count <= 1)
				{
					MessageBox.Show("Raw Product name cannot left blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtGridRawProduct.Focus();
					return;
				}
				else
				{
					GridControlMode(false);
				}
			}

			if (!string.IsNullOrEmpty(TxtGridRawProduct.Text))
			{
				Indexcount = Grid.Rows.Count;
				if (TxtGridRawProduct.ProductDetails.Count > 0)
				{
					if (!Grid.Columns["GodownDesc"].Visible)
					{
						TxtGridGodown.Text = "";
					}
					else if ((Grid.Rows[0].Cells["GodownDesc"].Value == null || Indexcount <= 0 ? false : TxtGridGodown.Text == ""))
					{
						if (Indexcount != 1)
						{
							TxtGridGodown.Text = Grid.Rows[Indexcount - 2].Cells["GodownDesc"].Value.ToString();
						}
						else
						{
							TxtGridGodown.Text = Grid.Rows[0].Cells["GodownDesc"].Value.ToString();
						}
					}

					LblProductShortName.Text = TxtGridRawProduct.ProductDetails["ProductShortName"].ToString();
					TxtGridAltUOM.Text = TxtGridRawProduct.ProductDetails["ProductAltUnit"].ToString();
					TxtGridAltUOM.Tag = TxtGridRawProduct.ProductDetails["ProductAltUnitId"].ToString();
					TxtGridQtyUOM.Text = TxtGridRawProduct.ProductDetails["ProductUnit"].ToString();
					TxtGridQtyUOM.Tag = TxtGridRawProduct.ProductDetails["ProductUnitId"].ToString();
					LblStockAltQty .Text = TxtGridRawProduct.ProductDetails["AltStockQty"].ToString();
					LblStockQty.Text = TxtGridRawProduct.ProductDetails["StockQty"].ToString();
					TxtGridRawProduct.ProductDetails.Clear();
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
					if (TxtGridGodown.Visible == false)
						TxtGridQty.Focus();
				}
			}
		
		}

        private void BtnVoucherNoSearch_Click(object sender, EventArgs e)
        {
            if (_SearchKey.Length > 1)
                _SearchKey = "";

            PickList frmPickList = new PickList("BOMVoucher", _SearchKey);
            if (PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
					_VoucherNo = frmPickList.SelectedList[0]["BillOfMaterialId"].ToString().Trim();
					DataSet ds = _objBillOfMaterial.GetDataBillOfMaterial(_VoucherNo);
					ClearFld();
					SetData(ds);
				}
				frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Purchase Voucher !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            TxtVoucherNo.Focus();
        }

        private void BtnDepartmentSearch_Click(object sender, EventArgs e)
        {
            ClsButtonClick.DepartmentBtnClick(_SearchKey, TxtDepartment, e);
            _SearchKey = string.Empty;
        }

        

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Bill Of Material(BOM) [NEW]";
            if (TxtVoucherNo.Enabled == true)
            {
                Utility.GetVoucherNo2("BOM", TxtVoucherNo, TxtDescription, _Tag, "");
            }
        }

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            ClearFld();
            ControlEnableDisable(true, false);
			GridControlMode(false);
			GridFinishedControlMode(false);
		}

        private void FrmBOM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != Grid && ActiveControl != GridFinished)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridRawProduct.Visible == true )
                {
                    _GridControlMode = false;
                    GridControlMode(false);
					
					_GridControlMode = true;
                    Grid.Focus();
                }
				else if (TxtGridFinishedProduct.Visible == true)
				{
					_GridControlMode = false;
					GridFinishedControlMode(false);
					_GridControlMode = true;
					GridFinished.Focus();
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
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtDepartment, BtnDepartmentSearch, false);
            }
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

     

        private void TxtDescription_Validating(object sender, CancelEventArgs e)
        {
			if (_Tag == "" || ActiveControl == TxtDescription) return;
			if (TxtDescription.Enabled == false) return;
			if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Description cannot left blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
        }

     

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtVoucherNo.Text))
            {
                MessageBox.Show("Voucher number cannot be left blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Description cannot left blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
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
			if (GridFinished.Rows.Count <= 0)
			{
				MessageBox.Show("Finished Goods not found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				GridFinished.Focus();
				return;
			}
			if (GridFinished.Rows.Count == 1 && GridFinished.Rows[0].Cells["FinishedGoods"].Value == null)
			{
				MessageBox.Show("Finished Goods not found.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				BtnOk.Enabled = false;
				GridFinished.Focus();
				return;
			}
			decimal totalCosting = 0;

			_objBillOfMaterial.Model.Tag = this._Tag;
            _objBillOfMaterial.Model.Gadget = "Desktop";
            _objBillOfMaterial.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objBillOfMaterial.Model.BillOfMaterialDesc = TxtDescription.Text;
            _objBillOfMaterial.Model.BillOfMaterialId = TxtVoucherNo.Text;
            if (!string.IsNullOrEmpty(TxtDepartment.Text))
            {
                string[] dept = TxtDepartment.Tag.ToString().Split('|');
                _objBillOfMaterial.Model.DepartmentId1 = ((dept[0].ToString() == "") ? 0 : Convert.ToInt32(dept[0].ToString()));
                _objBillOfMaterial.Model.DepartmentId2 = ((dept[1].ToString() == "") ? 0 : Convert.ToInt32(dept[1].ToString()));
                _objBillOfMaterial.Model.DepartmentId3 = ((dept[2].ToString() == "") ? 0 : Convert.ToInt32(dept[2].ToString()));
                _objBillOfMaterial.Model.DepartmentId4 = ((dept[3].ToString() == "") ? 0 : Convert.ToInt32(dept[3].ToString()));
            }
			//_objBillOfMaterial.Model.ConvFactor = string.IsNullOrEmpty(TxtConversionFactor.Text.ToString()) ? 0 : Convert.ToDecimal(TxtConversionFactor.Text);
            _objBillOfMaterial.Model.EnterDate = DateTime.Now;
            _objBillOfMaterial.Model.EntryFromProject = ClsGlobal.SoftwareFocus;

            BillOfMaterialDetailsViewModel _BillOfMaterialDetails = null;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                if (ro.Cells["Particular"].Value != null)
                {
                    _BillOfMaterialDetails = new BillOfMaterialDetailsViewModel();
                    _BillOfMaterialDetails.BillOfMaterialId = _objBillOfMaterial.Model.BillOfMaterialId;
                    _BillOfMaterialDetails.SNO = Grid.Rows.IndexOf(ro) + 1;
                    _BillOfMaterialDetails.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());

                    if (ro.Cells["CostCenterID"].Value != null)
                        _BillOfMaterialDetails.CostCenterDetailId = string.IsNullOrEmpty(ro.Cells["CostCenterID"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["CostCenterID"].Value.ToString());
                    else
                        _BillOfMaterialDetails.CostCenterDetailId = 0;
                    if (ro.Cells["GodownId"].Value != null)
                        _BillOfMaterialDetails.GodownId = string.IsNullOrEmpty(ro.Cells["GodownId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["GodownId"].Value.ToString());
                    else
                        _BillOfMaterialDetails.GodownId = 0;

                    _BillOfMaterialDetails.Qty = ro.Cells["Qty"].Value != null ? Convert.ToDecimal(ro.Cells["Qty"].Value.ToString().Trim()) : 0;
                    if (ro.Cells["UOM"].Value != null)
                        _BillOfMaterialDetails.ProductUnitId = string.IsNullOrEmpty(ro.Cells["ProductUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["ProductUnitId"].Value.ToString());
                    else
                        _BillOfMaterialDetails.ProductUnitId = 0;
                    if (ro.Cells["AltQty"].Value != null)
                    {
                        decimal.TryParse(ro.Cells["AltQty"].Value.ToString().Trim(), out decimal _AltQty);
                        _BillOfMaterialDetails.AltQty = _AltQty;
                    }
                    else
                        _BillOfMaterialDetails.AltQty = 0;

                    if (ro.Cells["AltUOM"].Value != null)
                        _BillOfMaterialDetails.AltProductUnitId = string.IsNullOrEmpty(ro.Cells["AltProductUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["AltProductUnitId"].Value.ToString());
                    else
                        _BillOfMaterialDetails.AltProductUnitId = 0;

                    _objBillOfMaterial.ModelDetails.Add(_BillOfMaterialDetails);
                }
            }

			BillOfMaterialFinishedViewModel _BillOfMaterialFinished = null;
			foreach (DataGridViewRow ro in GridFinished.Rows)
			{
				if (ro.Cells["FinishedGoods"].Value != null)
				{
					_BillOfMaterialFinished = new BillOfMaterialFinishedViewModel();
					_BillOfMaterialFinished.BillOfMaterialId = _objBillOfMaterial.Model.BillOfMaterialId;
					_BillOfMaterialFinished.SNO = GridFinished.Rows.IndexOf(ro) + 1;
					_BillOfMaterialFinished.ProductId = Convert.ToInt32(ro.Cells["FinishedProductId"].Value.ToString());

					if (ro.Cells["FinishedCostCenterID"].Value != null)
						_BillOfMaterialFinished.CostCenterId = string.IsNullOrEmpty(ro.Cells["FinishedCostCenterID"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["FinishedCostCenterID"].Value.ToString());
					else
						_BillOfMaterialFinished.CostCenterId = 0;
					if (ro.Cells["FinishedGodownId"].Value != null)
						_BillOfMaterialFinished.GodownId = string.IsNullOrEmpty(ro.Cells["FinishedGodownId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["FinishedGodownId"].Value.ToString());
					else
						_BillOfMaterialFinished.GodownId = 0;

					_BillOfMaterialFinished.Qty = ro.Cells["FinishedQty"].Value != null ? Convert.ToDecimal(ro.Cells["FinishedQty"].Value.ToString().Trim()) : 0;
					if (ro.Cells["FinishedUnit"].Value != null)
						_BillOfMaterialFinished.ProductUnitId = string.IsNullOrEmpty(ro.Cells["FinishedUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["FinishedUnitId"].Value.ToString());
					else
						_BillOfMaterialFinished.ProductUnitId = 0;
					if (ro.Cells["FinishedAltQty"].Value != null)
					{
						decimal.TryParse(ro.Cells["FinishedAltQty"].Value.ToString().Trim(), out decimal _AltQty);
						_BillOfMaterialFinished.AltQty = _AltQty;
					}
					else
						_BillOfMaterialFinished.AltQty = 0;

					if (ro.Cells["FinishedAltUnit"].Value != null)
						_BillOfMaterialFinished.AltProductUnitId = string.IsNullOrEmpty(ro.Cells["FinishedAltProductUnitId"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["FinishedAltProductUnitId"].Value.ToString());
					else
						_BillOfMaterialFinished.AltProductUnitId = 0;

					if (ro.Cells["FinishedCosting"].Value != null)
					{
						decimal.TryParse(ro.Cells["FinishedCosting"].Value.ToString().Trim(), out decimal _Costing);
						_BillOfMaterialFinished.FinishedCosting = _Costing;
						totalCosting = totalCosting + _Costing;
					}
					else
						_BillOfMaterialFinished.FinishedCosting = 0;


					_objBillOfMaterial.ModelFinished.Add(_BillOfMaterialFinished);
				}
			}

			if(totalCosting !=100)
			{
				MessageBox.Show("Finished Goods costing must be 100 %.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				BtnOk.Enabled = false;
				GridFinished.Focus();
				return;
			}
			_objBillOfMaterial.Model.DocId = Convert.ToInt32(TxtVoucherNo.Tag.ToString());
            string output = _objBillOfMaterial.SaveBillOfMaterial();

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
				if (_Tag == "NEW")
				{
					BtnNew.Enabled = true;
					BtnNew.PerformClick();
				}
				else
				{
					BtnEdit.Enabled = true;
					BtnEdit.PerformClick();
				}
			}
            
        }

		private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (Grid.Columns[e.ColumnIndex].Name == "Action")
			{
				if (TxtGridRawProduct.Visible == true)
				{
					GridControlMode(false);
					Grid.Focus();
				}

				if (Grid.Rows.Count > 1)
				{
					Grid.Rows.RemoveAt(e.RowIndex);
					CalTotal();
				}
			}
		}

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Bill Of Material(BOM) [EDIT]";
        }

        private void TxtVoucherNo_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtVoucherNo)return;
            if (TxtVoucherNo.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtVoucherNo.Text))
                ClsButtonClick.VoucherNumberValidating(TxtVoucherNo, e);

            if (_Tag == "NEW")
            {
                if (!string.IsNullOrEmpty(_objBillOfMaterial.IsExistsVNumber(TxtVoucherNo.Text)))
                {
                    MessageBox.Show("Voucher Number Already Exist...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {

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
					Text = "Bill Of Material(BOM)";
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
				Text = "Bill Of Material(BOM)";
			}
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			_Tag = "DELETE";
			ControlEnableDisable(false, false);
			Text = "Bill Of Material(BOM) [DELETE]";
			TxtVoucherNo.Enabled = true;
			BtnVoucherNoSearch.Enabled = true;
			TxtVoucherNo.Focus();
			BtnOk.Enabled = true;
			BtnCancel.Enabled = true;
			Grid.Enabled = false;
			GridFinished.Enabled = false;
		}

		private void GridFinished_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (GridFinished.Rows.Count == 0)
					GridFinished.Rows.Add();
				e.Handled = true;
				GridFinishedControlMode(true);
			}
		}

		private void GridFinished_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (GridFinished.Columns[e.ColumnIndex].Name == "FinishedAction")
			{
				if (TxtGridFinishedProduct.Visible == true)
				{
					GridFinishedControlMode(false);
					GridFinished.Focus();
				}

				if (GridFinished.Rows.Count > 1)
				{
					GridFinished.Rows.RemoveAt(e.RowIndex);
				}
			}
		}


		private void SetData(DataSet ds)
		{
			DataTable dtMaster = ds.Tables[0];
			DataTable dtDetails = ds.Tables[1];
			DataTable dtFinished = ds.Tables[2];

			TxtVoucherNo.Text = dtMaster.Rows[0]["BillOfMaterialId"].ToString();
			_VoucherNo = dtMaster.Rows[0]["BillOfMaterialId"].ToString();
			TxtDescription.Text = dtMaster.Rows[0]["BillOfMaterialDesc"].ToString();

			if (string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc1"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc2"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc3"].ToString()) || string.IsNullOrEmpty(dtMaster.Rows[0]["DepartmentDesc4"].ToString()))
			{
				string[] Dept = new string[] { dtMaster.Rows[0]["DepartmentDesc1"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc2"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString(), "|", dtMaster.Rows[0]["DepartmentDesc3"].ToString() };
				TxtDepartment.Text = string.Concat(Dept);
				string[] Depttag = new string[] { dtMaster.Rows[0]["DepartmentId1"].ToString(), "|", dtMaster.Rows[0]["DepartmentId2"].ToString(), "|", dtMaster.Rows[0]["DepartmentId3"].ToString(), "|", dtMaster.Rows[0]["DepartmentId4"].ToString() };
				TxtDepartment.Tag = string.Concat(Depttag);
			}
			
			foreach (DataRow drDetails in dtDetails.Rows)
			{
				Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltConversion"].Value = drDetails["AltConv"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["CostCenter"].Value = drDetails["CostCenterDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["CostCenterID"].Value = drDetails["CostCenterDetailId"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["GodownDesc"].Value = drDetails["GodownDesc"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["GodownId"].Value = drDetails["GodownId"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltUOM"].Value = drDetails["AltProductUnit"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["AltProductUnitId"].Value = string.IsNullOrEmpty (drDetails["AltProductUnitId"].ToString()) ?"0":drDetails["AltProductUnitId"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["UOM"].Value = drDetails["ProductUnit"].ToString();
				Grid.Rows[Grid.Rows.Count - 1].Cells["ProductUnitId"].Value = string.IsNullOrEmpty(drDetails["ProductUnitId"].ToString()) ? "0" : drDetails["ProductUnitId"].ToString();

				Grid.Rows.Add();
			}

			foreach (DataRow drDetails in dtFinished.Rows)
			{
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedSNo"].Value = GridFinished.Rows.Count.ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedProductShortName"].Value = drDetails["ProductShortName"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedGoods"].Value = drDetails["ProductDesc"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedProductId"].Value = drDetails["ProductId"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedAltConversion"].Value = drDetails["AltConv"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedCostCenter"].Value = drDetails["CostCenterDesc"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedCostCenterID"].Value = drDetails["CostCenterId"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedGodown"].Value = drDetails["GodownDesc"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedGodownId"].Value = drDetails["GodownId"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedAltQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["AltQty"].ToString()), 1, ClsGlobal._AltQtyDecimalFormat).ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedAltUnit"].Value = drDetails["AltProductUnit"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedAltProductUnitId"].Value = string.IsNullOrEmpty(drDetails["AltProductUnitId"].ToString()) ? "0" : drDetails["AltProductUnitId"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedQty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedUnit"].Value = drDetails["ProductUnit"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedUnitId"].Value = string.IsNullOrEmpty(drDetails["ProductUnitId"].ToString()) ? "0" : drDetails["ProductUnitId"].ToString();
				GridFinished.Rows[GridFinished.Rows.Count - 1].Cells["FinishedCosting"].Value = string.IsNullOrEmpty(drDetails["FinishedCosting"].ToString()) ? "0" : ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["FinishedCosting"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();

				GridFinished.Rows.Add();
			}
			CalTotal();
			//LblTotalAltQty.Text = ClsGlobal.DecimalFormate(TotalAltQty, 1, ClsGlobal._AltQtyDecimalFormat).ToString();
			//LblTotalQty.Text = ClsGlobal.DecimalFormate(TotalQty, 1, ClsGlobal._QtyDecimalFormat).ToString();
		}
	}
}
