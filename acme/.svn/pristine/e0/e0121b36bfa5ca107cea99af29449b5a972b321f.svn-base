using DataAccessLayer.Common;
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

namespace acmedesktop.MasterSetup
{
    public partial class FrmProductMapping : Form
    { public ClsProduct _objProduct = new ClsProduct();
        ClsCommon _objCommon = new ClsCommon();
        string _Tag = "", _SearchKey = ""; 
        DataRow[] PDataRows; 
        DataTable dtProductGroupListForProductMapping = new DataTable();
        DataTable dtProductSubGroupListForProductMapping = new DataTable();      
        DataTable dtBranchForProductMapping = new DataTable();
        DataTable dtCopanyUnitForProductMapping = new DataTable();

        public FrmProductMapping()
        {
            InitializeComponent();
        }      

        private void FrmProductMapping_Load(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ProductGroupListForProductMapping();
            ProductSubGroupListForProductMapping();
            BranchListForProductMapping();
            CompanyUnitListForProductMapping();
            ProductCounterMapList();
        }
        public void ProductGroupListForProductMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Group");
            dt.Columns.Add("ProductId");
            //dt.Columns.Add("ProductGrpId");
            dtProductGroupListForProductMapping = _objProduct.ProductGroupListForProductMapping(TxtProductGroup.Tag.ToString());
            PDataRows = dtProductGroupListForProductMapping.Select("Tag='True'");
            foreach (DataRow row in dtProductGroupListForProductMapping.Rows)
            {
                if (dtProductGroupListForProductMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["ProductShortName"].ToString();
                    dr["Description"] = row["ProductDesc"].ToString();
                    dr["Group"] = row["ProductGrpDesc"].ToString();
                    dr["ProductId"] = row["ProductId"].ToString();
                   // dr["ProductGrpId"] = row["ProductGrpId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridProductGroup.DataSource = dt;
            GridProductGroup.Columns["Tag"].Width = 40;
            GridProductGroup.Columns["Short Name"].Width = 100;
            GridProductGroup.Columns["Short Name"].ReadOnly = true;
            GridProductGroup.Columns["Description"].ReadOnly = true;
            GridProductGroup.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridProductGroup.Columns["Group"].Width = 180;
            GridProductGroup.Columns["Group"].ReadOnly = true;
            GridProductGroup.Columns["ProductId"].Visible = false;
            //GridProductGroup.Columns["ProductGrpId"].Visible = false;
            GridProductGroup.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridProductGroup.Rows)
            {
                if (GridProductGroup.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void ProductCounterMapList()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Group");
            dt.Columns.Add("ProductId");
            dtProductGroupListForProductMapping = _objProduct.ProductListForCounterMapping(TxtCounterName.Tag.ToString());
            PDataRows = dtProductGroupListForProductMapping.Select("Tag='True'");
            foreach (DataRow row in dtProductGroupListForProductMapping.Rows)
            {
                if (dtProductGroupListForProductMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["ProductShortName"].ToString();
                    dr["Description"] = row["ProductDesc"].ToString();
                    dr["Group"] = row["ProductGrpDesc"].ToString();
                    dr["ProductId"] = row["ProductId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridCounterProuctMapping.DataSource = dt;
            GridCounterProuctMapping.Columns["Tag"].Width = 40;
            GridCounterProuctMapping.Columns["Short Name"].Width = 100;
            GridCounterProuctMapping.Columns["Short Name"].ReadOnly = true;
            GridCounterProuctMapping.Columns["Description"].ReadOnly = true;
            GridCounterProuctMapping.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridCounterProuctMapping.Columns["Group"].Width = 180;
            GridCounterProuctMapping.Columns["Group"].ReadOnly = true;
            GridCounterProuctMapping.Columns["ProductId"].Visible = false;
            //GridProductGroup.Columns["ProductGrpId"].Visible = false;
            GridCounterProuctMapping.AutoGenerateColumns = false;
            //foreach (DataGridViewRow ro in GridCounterProuctMapping.Rows)
            //{
            //    if (GridCounterProuctMapping.RowCount > 0)
            //    {
            //        if (Convert.ToBoolean(ro.Cells[0].Value) == true)
            //        {
            //            ro.Cells[0].ReadOnly = true;
            //        }
            //    }
            //}
        }
        public void ProductSubGroupListForProductMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Group");
            dt.Columns.Add("SubGroup");
            dt.Columns.Add("ProductId");
            dtProductSubGroupListForProductMapping = _objProduct.ProductSubGroupListForProductMapping(TxtProductSubGroup.Tag.ToString());
            PDataRows = dtProductSubGroupListForProductMapping.Select("Tag='True'");
            foreach (DataRow row in dtProductSubGroupListForProductMapping.Rows)
            {
                if (dtProductSubGroupListForProductMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["ProductShortName"].ToString();
                    dr["Description"] = row["ProductDesc"].ToString();
                    dr["Group"] = row["ProductGrpDesc"].ToString();
                    dr["SubGroup"] = row["ProductSubGrpDesc"].ToString();
                    dr["ProductId"] = row["ProductId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridProductSubGroup.DataSource = dt;
            GridProductSubGroup.Columns["Tag"].Width = 40;
            GridProductSubGroup.Columns["Short Name"].Width = 100;
            GridProductSubGroup.Columns["Short Name"].ReadOnly = true;
            GridProductSubGroup.Columns["Description"].ReadOnly = true;
            GridProductSubGroup.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridProductSubGroup.Columns["Group"].Width = 180;
            GridProductSubGroup.Columns["Group"].ReadOnly = true;
            GridProductSubGroup.Columns["SubGroup"].Width = 180;
            GridProductSubGroup.Columns["SubGroup"].ReadOnly = true;
            GridProductSubGroup.Columns["ProductId"].Visible = false;
            GridProductSubGroup.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridProductSubGroup.Rows)
            {
                if (GridProductSubGroup.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }      

        public void BranchListForProductMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Branch");
            dt.Columns.Add("ProductId");
            dt.Columns.Add("BranchId");
            dtBranchForProductMapping = _objProduct.BranchListForProductMapping(TxtBranch.Tag.ToString());
            PDataRows = dtBranchForProductMapping.Select("Tag='True'");
            foreach (DataRow row in dtBranchForProductMapping.Rows)
            {
                if (dtBranchForProductMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["ProductShortName"].ToString();
                    dr["Description"] = row["ProductDesc"].ToString();
                    dr["Branch"] = row["BranchName"].ToString();
                    dr["ProductId"] = row["ProductId"].ToString();
                    dr["BranchId"] = row["BranchId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridBranch.DataSource = dt;
            GridBranch.Columns["Tag"].Width = 40;
            GridBranch.Columns["Short Name"].Width = 100;
            GridBranch.Columns["Short Name"].ReadOnly = true;
            GridBranch.Columns["Description"].ReadOnly = true;
            GridBranch.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridBranch.Columns["Branch"].Width = 180;
            GridBranch.Columns["Branch"].ReadOnly = true;
            GridBranch.Columns["ProductId"].Visible = false;
            GridBranch.Columns["BranchId"].Visible = false;
            GridBranch.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridBranch.Rows)
            {
                if (GridBranch.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }

        public void CompanyUnitListForProductMapping()
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Tag", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Short Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Company Unit");
            dt.Columns.Add("ProductId");
            dtCopanyUnitForProductMapping = _objProduct.CompanyUnitListForProductMapping(TxtCompanyUnit.Tag.ToString());
            PDataRows = dtCopanyUnitForProductMapping.Select("Tag='True'");
            foreach (DataRow row in dtCopanyUnitForProductMapping.Rows)
            {
                if (dtCopanyUnitForProductMapping.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Tag"] = row["Tag"].ToString();
                    dr["Short Name"] = row["ProductShortName"].ToString();
                    dr["Description"] = row["ProductDesc"].ToString();
                    dr["Company Unit"] = row["CmpUnitName"].ToString();
                    dr["ProductId"] = row["ProductId"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridCompanyUnit.DataSource = dt;
            GridCompanyUnit.Columns["Tag"].Width = 40;
            GridCompanyUnit.Columns["Short Name"].Width = 100;
            GridCompanyUnit.Columns["Short Name"].ReadOnly = true;
            GridCompanyUnit.Columns["Description"].ReadOnly = true;
            GridCompanyUnit.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridCompanyUnit.Columns["Company Unit"].Width = 180;
            GridCompanyUnit.Columns["Company Unit"].ReadOnly = true;
            GridCompanyUnit.Columns["ProductId"].Visible = false;
            GridCompanyUnit.AutoGenerateColumns = false;
            foreach (DataGridViewRow ro in GridCompanyUnit.Rows)
            {
                if (GridCompanyUnit.RowCount > 0)
                {
                    if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                    {
                        ro.Cells[0].ReadOnly = true;
                    }
                }
            }
        }


        private void FrmProductMapping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchProductGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtProductGroup, BtnSearchProductGroup, true);
            }
        }

        private void BtnMapToProductGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtProductGroup.Text))
            {
                MessageBox.Show("Poduct Group Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductGroup.Focus();
                return;
            }

            ProductMappingList ObjProductMappingList = null;
            foreach (DataGridViewRow ro in GridProductGroup.Rows)
            {
                ObjProductMappingList = new ProductMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjProductMappingList.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
                    ObjProductMappingList.ProductGrpId = Convert.ToInt32(TxtProductGroup.Tag.ToString());                   
                    _objProduct.ModelProductMappingList.Add(ObjProductMappingList);
                }
            }

            _objProduct.SaveProductMapping("ProductGroup");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductGroupListForProductMapping();

        }

        private void BtnMapToProductGroupCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSearchProGroup_Click(object sender, EventArgs e)
        {
            TxtProductSubGroup.Text = "";
            TxtProductSubGroup.Tag = 0;
            Common.PickList frmPickList = new Common.PickList("ProductGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtProGroup.Text = frmPickList.SelectedList[0]["ProductGrpDesc"].ToString().Trim();
                    TxtProGroup.Tag = frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProGroup.Focus();
                return;
            }
            TxtProGroup.Focus();
        }

        private void TxtProGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchProGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtProGroup, BtnSearchProGroup, true);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchProductSubGroup.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtProductSubGroup, BtnSearchProductSubGroup, true);
            }
        }

        private void BtnSearchProductSubGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductSubGroup." + TxtProGroup.Tag, _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtProductSubGroup.Text = frmPickList.SelectedList[0]["ProductSubGrpDesc"].ToString().Trim();
                    TxtProductSubGroup.Tag = frmPickList.SelectedList[0]["ProductSubGrpId"].ToString().Trim();
                    ProductSubGroupListForProductMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Sub Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductSubGroup.Focus();
                return;
            }
            TxtProductSubGroup.Focus();
        }

        private void BtnMapToProductSubGroupCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMapToProductSubGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtProGroup.Text))
            {
                MessageBox.Show("Product Group  Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProGroup.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtProductSubGroup.Text))
            {
                MessageBox.Show("Product Sub Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductSubGroup.Focus();
                return;
            }
            ProductMappingList ObjProductMappingList = null;
            foreach (DataGridViewRow ro in GridProductSubGroup.Rows)
            {
                ObjProductMappingList = new ProductMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjProductMappingList.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
                    ObjProductMappingList.ProductGrpId = Convert.ToInt32(TxtProGroup.Tag.ToString());
                    ObjProductMappingList.ProductSubGrpId = Convert.ToInt32(TxtProductSubGroup.Tag.ToString());                   
                    _objProduct.ModelProductMappingList.Add(ObjProductMappingList);
                }
            }
            _objProduct.SaveProductMapping("ProductSubGroup");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductSubGroupListForProductMapping();
        }

        private void BtnSearchBranch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Branch", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtBranch.Text = frmPickList.SelectedList[0]["BranchName"].ToString().Trim();
                    TxtBranch.Tag = frmPickList.SelectedList[0]["BranchId"].ToString().Trim();
                    BranchListForProductMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Branch !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBranch.Focus();
                return;
            }
            TxtBranch.Focus();
        }

        private void TxtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchBranch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtBranch, BtnSearchBranch, true);
            }
        }

        private void BtnMapToBranchOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBranch.Text))
            {
                MessageBox.Show("Branch Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBranch.Focus();
                return;
            }
            ProductMappingList ObjProductMappingList = null;
            foreach (DataGridViewRow ro in GridBranch.Rows)
            {
                ObjProductMappingList = new ProductMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjProductMappingList.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
                    ObjProductMappingList.BranchId = Convert.ToInt32(TxtBranch.Tag.ToString());                  
                    _objProduct.ModelProductMappingList.Add(ObjProductMappingList);
                }
            }

            _objProduct.SaveProductMapping("Branch");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BranchListForProductMapping();
        }

        private void BtnMapToBranchCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSearchCompanyUnit_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("CompanyUnit", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtCompanyUnit.Text = frmPickList.SelectedList[0]["CmpUnitName"].ToString().Trim();
                    TxtCompanyUnit.Tag = frmPickList.SelectedList[0]["CompanyUnitId"].ToString().Trim();
                    LblBranch.Text = frmPickList.SelectedList[0]["BranchName"].ToString().Trim();
                    LblBranch.Tag = frmPickList.SelectedList[0]["BranchId"].ToString().Trim();
                    CompanyUnitListForProductMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Company Unit !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCompanyUnit.Focus();
                return;
            }
            TxtCompanyUnit.Focus();
        }

        private void TxtCompanyUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchCompanyUnit.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtCompanyUnit, BtnSearchCompanyUnit, true);
            }
        }

        private void BtnMapToCompanyUnitCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMapToCompanyUnitOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCompanyUnit.Text))
            {
                MessageBox.Show("Company Unit Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCompanyUnit.Focus();
                return;
            }
            ProductMappingList ObjProductMappingList = null;
            foreach (DataGridViewRow ro in GridCompanyUnit.Rows)
            {
                ObjProductMappingList = new ProductMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjProductMappingList.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
                    ObjProductMappingList.CompanyUnitId = Convert.ToInt32(TxtCompanyUnit.Tag.ToString());
                    ObjProductMappingList.BranchId = Convert.ToInt32(LblBranch.Tag.ToString());                
                    _objProduct.ModelProductMappingList.Add(ObjProductMappingList);
                }
            }

            _objProduct.SaveProductMapping("CompanyUnit");
            MessageBox.Show("Your Data Has Been Updated Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CompanyUnitListForProductMapping();
        }

        private void TxtCounterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchCounter.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtCounterName, BtnSearchCounter, true);
            }
        }

        private void BtnSearchCounter_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Counter", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtCounterName.Text = frmPickList.SelectedList[0]["CounterDesc"].ToString().Trim();
                    TxtCounterName.Tag = frmPickList.SelectedList[0]["CounterId"].ToString().Trim();
                    ProductCounterMapList();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No list available in counter !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductGroup.Focus();
                return;
            }
            TxtCounterName.Focus();
        }

        private void btnSaveCounterMap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCounterName.Text))
            {
                MessageBox.Show("Counter is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCounterName.Focus();
                return;
            }

            _objProduct.ModelProductCounterMappingList.Clear();
            ProductCounterMappingList ObjProducCounterMappingList = null;
            foreach (DataGridViewRow ro in GridCounterProuctMapping.Rows)
            {
                ObjProducCounterMappingList = new ProductCounterMappingList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    ObjProducCounterMappingList.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value.ToString());
                    ObjProducCounterMappingList.ProductGrpId = Convert.ToInt32(TxtProductGroup.Tag.ToString());
                    _objProduct.ModelProductCounterMappingList.Add(ObjProducCounterMappingList);
                }
            }

            _objProduct.SaveProductCounterMapping(TxtCounterName.Tag.ToString());
            MessageBox.Show("Data Update Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductCounterMapList();
        }

        private void btnCancelCounterMap_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSearchProductGroup_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtProductGroup.Text = frmPickList.SelectedList[0]["ProductGrpDesc"].ToString().Trim();
                    TxtProductGroup.Tag = frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim();
                    ProductGroupListForProductMapping();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductGroup.Focus();
                return;
            }
            TxtProductGroup.Focus();
        }

    }
}
