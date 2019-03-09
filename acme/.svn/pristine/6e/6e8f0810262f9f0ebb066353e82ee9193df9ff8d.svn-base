using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.BillingTransaction
{
    public partial class FrmSplit : Form
    {

        ISalesOrder _objSalesOrder = new ClsSalesOrder();
        ITableMaster _objTableMaster = new ClsTable();
        public DataTable dtSplitProduct = new DataTable();
        public DataTable dtOrderProduct = new DataTable();
        public string SplitTableId = "", SplitTableDesc = "", buttonClick="", _tableDesc="";
        public FrmSplit(string OrderNo, string tableDesc)
        {
            InitializeComponent();
            lblOrderNo.Text = OrderNo;
            _tableDesc = tableDesc;

            dtSplitProduct.Columns.Add("SNo");
            dtSplitProduct.Columns.Add("ProductId");
            dtSplitProduct.Columns.Add("ProductDesc");
            dtSplitProduct.Columns.Add("Qty");
            dtSplitProduct.Columns.Add("RateSplit");
            dtSplitProduct.Columns.Add("TermDetails");
            dtSplitProduct.Columns.Add("Notes");

            dtOrderProduct.Columns.Add("SNo");
            dtOrderProduct.Columns.Add("ProductId");
            dtOrderProduct.Columns.Add("ProductDesc");
            dtOrderProduct.Columns.Add("Qty");
            dtOrderProduct.Columns.Add("Rate");
            dtOrderProduct.Columns.Add("TermDetails");
            dtOrderProduct.Columns.Add("Notes");
        }

        private void FrmSplit_Load(object sender, EventArgs e)
        {
            GetOrderData();
            BtnConform.Enabled = false;
        }

        private void GetOrderData()
        {
            DataSet ds = _objSalesOrder.GetDataOrderVoucher(lblOrderNo.Text);
            DataTable dtdetails = ds.Tables[1];
            int j = 1;
           decimal.TryParse( lblTotalQtyPrimary.Text ,out decimal primaryQty);
            foreach (DataRow drDetails in dtdetails.Rows)
            {
                for(int i=0; i< Convert.ToDecimal(drDetails["Qty"].ToString());i++)
                {
                    Grid.Rows.Add();
                    Grid.Rows[Grid.Rows.Count -1].Cells["SNo"].Value =j ;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductDesc"].Value = drDetails["ProductDesc"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = "1";
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Rate"].Value = drDetails["SalesRate"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Note"].Value = drDetails["ResOrderNotes"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["TermDetails"].Value= drDetails["TermDetails"].ToString();
                    j++;
                }
                primaryQty += Convert.ToDecimal(drDetails["Qty"].ToString());
            }
            lblTotalQtyPrimary.Text =ClsGlobal.DecimalFormate( primaryQty,1,ClsGlobal._CurrencyDecimalFormat).ToString();

        }

        private void BtnSendRight_Click(object sender, EventArgs e)
        {

            Grid_CellDoubleClick(null, null);
        }

        private void BtnSendLeft_Click(object sender, EventArgs e)
        {
           GridSplit_CellDoubleClick(null, null);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            buttonClick = "Cancel";
            this.Close();
            this.Dispose();
        }

		private void FrmSplit_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
			else if (e.KeyCode == Keys.Escape)
			{
				if (BtnCancel.Enabled == true)
				{
					BtnCancel.PerformClick();
				}
				DialogResult = DialogResult.Cancel;
				return;
			}
		}

		private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Grid.Rows[Grid.CurrentRow.Index].Cells["ProductId"].Value.ToString() != null)
                {
                    if (Grid.Rows.Count >1)
                    {
                        GridSplit.Rows.Add();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["SNoSplit"].Value = GridSplit.Rows.Count;
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["PSNo"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["SNo"].Value.ToString();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["ParticularsSplit"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["ProductDesc"].Value.ToString();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["ProductIdSplit"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["ProductId"].Value.ToString();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["QtySplit"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["Qty"].Value.ToString();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["RateSplit"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["Rate"].Value.ToString();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["NoteSplit"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["Note"].Value.ToString();
                        GridSplit.Rows[GridSplit.Rows.Count - 1].Cells["TermDetailsSplit"].Value = Grid.Rows[Grid.CurrentRow.Index].Cells["TermDetails"].Value.ToString();
                        Grid.Rows.RemoveAt(Grid.CurrentRow.Index);
                    }
                }
                lblTotalQtySplit.Text = "0";
                lblTotalQtyPrimary.Text = "0";
                foreach (DataGridViewRow ro in Grid.Rows)
                {
                    lblTotalQtyPrimary.Text = (Convert.ToDecimal(lblTotalQtyPrimary.Text)+   Convert.ToDecimal(ro.Cells["Qty"].Value.ToString())).ToString ();
                }
                foreach (DataGridViewRow ro in GridSplit.Rows)
                {
                    
                    lblTotalQtySplit.Text = (Convert.ToDecimal(lblTotalQtySplit.Text) + Convert.ToDecimal(ro.Cells["QtySplit"].Value.ToString())).ToString();
                    
                }
                if (Convert.ToDecimal(lblTotalQtySplit.Text) > 0)
                    BtnConform.Enabled = true;
                else
                    BtnConform.Enabled = false;

            }
            catch { }
        }

        private void GridSplit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["ProductIdSplit"].Value.ToString() != null)
                {
                    Grid.Rows.Add();
                    //Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["PSNo"].Value.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductDesc"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["ParticularsSplit"].Value.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["ProductIdSplit"].Value.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["QtySplit"].Value.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Rate"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["RateSplit"].Value.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Note"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["NoteSplit"].Value.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["TermDetails"].Value = GridSplit.Rows[GridSplit.CurrentRow.Index].Cells["TermDetailsSplit"].Value.ToString();
                    GridSplit.Rows.RemoveAt(GridSplit.CurrentRow.Index);
                }
                lblTotalQtySplit.Text = "0";
                lblTotalQtyPrimary.Text = "0";
                foreach (DataGridViewRow ro in GridSplit.Rows)
                {
                    lblTotalQtySplit.Text = (Convert.ToDecimal(lblTotalQtySplit.Text) + Convert.ToDecimal(ro.Cells["QtySplit"].Value.ToString())).ToString();
                }
                foreach (DataGridViewRow ro in Grid.Rows)
                {
                    lblTotalQtyPrimary.Text = (Convert.ToDecimal(lblTotalQtyPrimary.Text) + Convert.ToDecimal(ro.Cells["Qty"].Value.ToString())).ToString();
                }
                if (Convert.ToDecimal(lblTotalQtySplit.Text) > 0)
                    BtnConform.Enabled = true;
                else
                    BtnConform.Enabled = false;
            }
            catch {
                //GridSplit.Rows.RemoveAt(Grid.CurrentRow.Index);
            }
        }

        private void BtnConform_Click(object sender, EventArgs e)
        {

            var dialogResult = MessageBox.Show("Are you sure want to Split Table No: " + _tableDesc + " ..??", "Mr.Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable dtSplitTable = _objTableMaster.GetSplitTable();
                string sno = "", ProductId = "", ProductDesc = "", Qty = "", Rate="", TermDetails = "", Notes = "";
                bool isUpdate = false;
                if (dtSplitTable.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtSplitTable.Rows[0]["TableId"].ToString()))
                    {
                        SplitTableId = dtSplitTable.Rows[0]["TableId"].ToString();
                        SplitTableDesc = dtSplitTable.Rows[0]["TableDesc"].ToString();

                        foreach (DataGridViewRow ro in GridSplit.Rows)
                        {
                            sno = ro.Cells["PSNo"].Value.ToString();
                            ProductDesc = ro.Cells["ParticularsSplit"].Value.ToString();
                            ProductId = ro.Cells["ProductIdSplit"].Value.ToString();
                            Qty = ro.Cells["QtySplit"].Value.ToString();
                            Rate = ro.Cells["RateSplit"].Value.ToString();
                            TermDetails = ro.Cells["TermDetailsSplit"].Value.ToString();
                            Notes = ro.Cells["NoteSplit"].Value.ToString();

                            if (dtSplitProduct.Rows.Count > 0)
                            {
                                isUpdate = false;
                                foreach (DataRow dr in dtSplitProduct.Rows)
                                {
                                    if (dr["ProductId"].ToString() == ProductId)
                                    {
                                        dr["Qty"] = Convert.ToDecimal(dr["Qty"]) + Convert.ToDecimal(Qty);
                                        isUpdate = true;
                                        break;
                                    }
                                }
                                if(isUpdate==false)
                                    dtSplitProduct.Rows.Add(sno, ProductId, ProductDesc, Qty, Rate, TermDetails, Notes);
                            }
                            else
                                dtSplitProduct.Rows.Add(sno, ProductId, ProductDesc, Qty, Rate, TermDetails, Notes);

                        }
                    }
                }
                foreach (DataGridViewRow ro in Grid.Rows)
                {
                    sno = ro.Cells["SNo"].Value.ToString();
                    ProductDesc = ro.Cells["ProductDesc"].Value.ToString();
                    ProductId = ro.Cells["ProductId"].Value.ToString();
                    Qty = ro.Cells["Qty"].Value.ToString();
                    Rate = ro.Cells["Rate"].Value.ToString();
                    TermDetails = ro.Cells["TermDetails"].Value.ToString();
                    Notes = ro.Cells["Note"].Value.ToString();

                    if (dtOrderProduct.Rows.Count > 0)
                    {
                        isUpdate = false;
                        foreach (DataRow dr in dtOrderProduct.Rows)
                        {
                            if (dr["ProductId"].ToString() == ProductId)
                            {
                                dr["Qty"] = Convert.ToDecimal(dr["Qty"]) + Convert.ToDecimal(Qty);
                                isUpdate = true;
                                break;
                            }
                        }
                        if (isUpdate == false)
                            dtOrderProduct.Rows.Add(sno, ProductId, ProductDesc, Qty, Rate, TermDetails, Notes);
                    }
                    else
                    dtOrderProduct.Rows.Add(sno, ProductId, ProductDesc, Qty, Rate, TermDetails, Notes);
                }
                buttonClick = "Conform";
            }
            else return;
          
            this.Close();
            this.Dispose();
        }
    }
}
