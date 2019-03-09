using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.Common;
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

namespace acmedesktop.MasterSetup
{
    public partial class FrmProductScheme : Form
    {
        IProductScheme _objProductScheme = new ClsProductScheme(); 
        ICommon _objCommon = new ClsCommon();
        ClsDateMiti _objDate = new ClsDateMiti();
        public int _SchemeId = 0;
        public int _ProductGrpId, _ProductSubGrpId;
        private string _Tag = "", _SearchKey = "", result = "";
        MyGridNumericTextBox TxtGridPercent;
        MyGridNumericTextBox TxtGridRate;
        public FrmProductScheme()
        {
            InitializeComponent();
            TxtGridRate = new MyGridNumericTextBox(Grid);
            TxtGridPercent = new MyGridNumericTextBox(Grid);
            TxtGridRate.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridRate_Validating);
            TxtGridPercent.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridPercent_Validating);
            GridControlMode(false);
        }
        public void ControlEnableDisable(bool trb, bool fld)
        {
            BtnNew.Enabled = trb;
            BtnEdit.Enabled = trb;
            BtnDelete.Enabled = trb;
            BtnExit.Enabled = trb;
           
            TxtDescription.Enabled = fld;
            BtnSearchDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            BtnSearchDescription.Enabled = fld;
            TxtDateFrom.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtDateFrom, fld);
            TxtDateTo.Enabled = fld;
            Utility.EnableDesibleDateColor(TxtDateTo, fld);    
            
            TxtPercentRate.Enabled = fld;          
            Utility.EnableDesibleColor(TxtPercentRate, fld);

            ControlRadioButton(false);

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
            TxtDescription.Tag = "";           
            TxtDescription.Text = "";
            TxtDateFrom.Text = DateTime.Now.ToString();
            TxtDateTo.Text = DateTime.Now.AddDays(365).ToString();
            TxtPercentRate.Text = "";

            ControlRadioButton(false );
            RdoProduct.Checked = false;
            RdoProductGroup.Checked = false;
            RdoProductSubGroup.Checked = false;
            RdoGroupWiseGroup.Checked = false;
            RdoSubGroupWiseGroup.Checked = false;
            RdoSubGroupWiseSubGroup.Checked = false;
           // LoadProduct();
            TxtDescription.Focus();

            Grid.Rows.Clear();
            Grid.Rows.Add();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            this.Text = "Product Rate Scheme  [NEW]";

            if (ClsGlobal.DateType == "M")
            {
                TxtDateFrom.Text = _objDate.GetMiti(_objDate.GetServerDate());
                TxtDateTo.Text = _objDate.GetMiti(_objDate.GetServerDate());
            }
            else
            {
                TxtDateFrom.Text = _objDate.GetServerDate().ToShortDateString();
                TxtDateTo.Text = _objDate.GetServerDate().ToShortDateString();
            }

        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Product Rate Scheme [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Product Rate Scheme [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchDescription.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnSearchDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("ProductScheme", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    _SchemeId = Convert.ToInt32(frmPickList.SelectedList[0]["SchemeId"].ToString().Trim());
                    DataSet ds = _objProductScheme.GetDataProductScheme(this._SchemeId);
                    SetData(ds);
                }
                else
                {
                    TxtDescription.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Scheme !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void FrmProductScheme_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && this.ActiveControl != Grid )
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
                else if (BtnCancel.Enabled == false)
                    BtnExit.PerformClick();

                DialogResult = DialogResult.Cancel;
                return;
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
                    Text = "Product Rate Scheme";
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
                Text = "Product Rate Scheme";
            }
         
        }
        private void RdoProduct_CheckedChanged(object sender, EventArgs e)
        {
            _SearchKey = "";
            if (RdoProduct.Checked==true)
            {
                if(this._Tag =="NEW")
                LoadProduct();
            }
        }
        private void RdoProductGroup_CheckedChanged(object sender, EventArgs e)
        {
            _SearchKey = "";
            if (RdoProductGroup.Checked == true)
            {
                string GroupId = GroupSearch();
                LoadProduct(GroupId);
            }
        }

        private string  GroupSearch()
        {
            Common.PickList frmPickList = new Common.PickList("ProductGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    this._ProductGrpId = Convert.ToInt32(frmPickList.SelectedList[0]["ProductGrpId"].ToString().Trim());
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return "";
            }

           return _ProductGrpId.ToString();
        }
        private string SubGroupSearch()
        {
         
            Common.PickList frmPickList = new Common.PickList("ProductSubGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    this._ProductSubGrpId = Convert.ToInt32(frmPickList.SelectedList[0]["ProductSubGrpId"].ToString().Trim());
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }

            return _ProductSubGrpId.ToString();
        }
        private void RdoProductSubGroup_CheckedChanged(object sender, EventArgs e)
        {
            _SearchKey = "";
            if (RdoProductSubGroup.Checked == true)
            {
                RdoProduct.Checked = false;
                RdoProductGroup.Checked = false;
                RdoSubGroupWiseSubGroup.Checked = false;
                RdoSubGroupWiseGroup.Checked = false;
                RdoGroupWiseGroup.Checked = false;
               string GroupId= GroupSearch();
                ClsGlobal.ProductGroup = GroupId;
                string SubGroupId= SubGroupSearch();
                LoadProduct(GroupId, SubGroupId);
                ClsGlobal.ProductGroup = "";
            }
        }
        private void FrmProductScheme_Load(object sender, EventArgs e)
        {
            ControlEnableDisable(true, false);
            ClearFld();
        }
        private void TxtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Scheme Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtDescription.Focus();
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text, "Product", "ProductDesc", "ProductId") == 1)
                {
                    MessageBox.Show("Scheme Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtDescription.Focus();
                    return;
                }              
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text, "Product", "ProductDesc", "ProductId", _SchemeId) != 0)
                {
                    MessageBox.Show("Scheme Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
       
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Product Scheme Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtDateFrom.Text))
            {
                MessageBox.Show("Date from  Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDateFrom.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtDateTo.Text))
            {
                MessageBox.Show("Date  To Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDateTo.Focus();
                return;
            }
           

            _objProductScheme.Model.Tag = _Tag;
            _objProductScheme.Model.SchemeId = this._SchemeId;
            if ((_Tag == "EDIT" || _Tag == "DELETE") && _SchemeId == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }

            _objProductScheme.Model.SchemeName = TxtDescription.Text;
            _objProductScheme.Model.EnterBy = ClsGlobal.LoginUserCode;
        

            if(RdoProduct.Checked ==true)
            _objProductScheme.Model.SchemeWise = "Product";
            else if (RdoProductGroup.Checked==true)
                _objProductScheme.Model.SchemeWise = "ProductGroup";
            else if (RdoProductSubGroup.Checked == true)
                _objProductScheme.Model.SchemeWise = "ProductSubGroup";
            else if (RdoGroupWiseGroup.Checked == true)
                _objProductScheme.Model.SchemeWise = "Group";
            else if (RdoSubGroupWiseGroup.Checked == true)
                _objProductScheme.Model.SchemeWise = "SubGroupGroup";
            else if (RdoSubGroupWiseSubGroup.Checked == true)
                _objProductScheme.Model.SchemeWise = "SubGroupSubGroup";


            ProductSchemeDetailsViewModel DetailsModel = null; 

            foreach (DataGridViewRow ro in Grid.Rows)
            {
                DetailsModel = new ProductSchemeDetailsViewModel();           
                DetailsModel.ProductId = Convert.ToInt16(ro.Cells["ProductId"].Value.ToString());
                DetailsModel.ProductGrpId = Convert.ToInt16(ro.Cells["ProductGrpId"].Value.ToString());
                DetailsModel.ProductSubGrpId =string.IsNullOrEmpty(ro.Cells["ProductSubGrpId"].Value.ToString()) ? 0: Convert.ToInt16(ro.Cells["ProductSubGrpId"].Value.ToString());
                DetailsModel.StartDate = Convert.ToDateTime(TxtDateFrom.Text);
                DetailsModel.EndDate = Convert.ToDateTime(TxtDateTo.Text);
                DetailsModel.DiscountPercent = Convert.ToDecimal(ro.Cells["DisPercent"].Value.ToString());
                DetailsModel.SchemeRate = Convert.ToDecimal(ro.Cells["ProductRate"].Value.ToString());
                _objProductScheme.DetailsSchemeModel.Add(DetailsModel);
            }

            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = _objProductScheme.SaveProductScheme();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = _objProductScheme.SaveProductScheme();
                }
            }
            else
            {
                result = _objProductScheme.SaveProductScheme();
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
        private void LoadProduct(string GroupId ="", string SubGroupId="")
        {
            Grid.Rows.Clear();
            DataTable dt1 =_objProductScheme.GetProduct(GroupId, SubGroupId);
            int i = 1;
            foreach (DataRow dr in dt1.Rows)
            {
                Grid.Rows.Add(i,dr["ProductId"].ToString(), dr["ProductDesc"].ToString(), dr["ProductGrpId"].ToString(), dr["ProductGrpDesc"].ToString(), dr["ProductSubGrpId"].ToString(), dr["ProductSubGrpDesc"].ToString(), dr["Percent"].ToString(),ClsGlobal.DecimalFormate(Convert.ToDecimal ( dr["Rate"].ToString()),1,ClsGlobal._AmountDecimalFormat ).ToString (), Properties.Resources.Delete_16);
                i++;
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
                    colindex = Grid.Columns["DisPercent"].Index;
                    TxtGridPercent.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridPercent.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["ProductRate"].Index;
                    TxtGridRate.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridRate.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                }
                SetGridValueToTextBox(currRo);
            }

            TxtGridPercent.Enabled = mode;
            TxtGridPercent.Visible = mode;

            TxtGridRate.Enabled = false;
            TxtGridRate.Visible = false;

            if (mode == true)
                BtnSave.Enabled = false;
            else
                BtnSave.Enabled = true;
           

            if (mode == true)
            {
                TxtGridPercent.Focus();
            }
        }
        private void SetGridValueToTextBox(int row)
        {            
            TxtPercentRate.Text = "";
            TxtGridRate.Text = "";

            if (Grid["DisPercent", row].Value != null) TxtGridPercent.Text = Grid["DisPercent", row].Value.ToString().Replace(",", string.Empty);
            if (Grid["ProductRate", row].Value != null) TxtGridRate.Text = Grid["ProductRate", row].Value.ToString().Replace(",", string.Empty);
        }
        private bool SetTextBoxValueToGrid()
        {
            DataGridViewRow ro = new DataGridViewRow();
            ro = Grid.Rows[Grid.CurrentRow.Index];
            ro.Cells["SNo"].Value = Grid.CurrentRow.Index + 1;

            if (!string.IsNullOrEmpty(TxtGridPercent.Text))
            {
                ro.Cells["DisPercent"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridPercent.Text), 1, ClsGlobal._AmountDecimalFormat);
                TxtGridPercent.Text = "";
            }
            if (!string.IsNullOrEmpty(TxtGridRate.Text))
            {
                ro.Cells["ProductRate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtGridRate.Text), 1, ClsGlobal._AmountDecimalFormat);
                TxtGridRate.Text = "";
            }
            return true;

        }
        private void TxtGridRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int indx = Grid.CurrentRow.Index;
            if (SetTextBoxValueToGrid() == true)
            {
                GridControlMode(false);
                if (Grid.Rows.Count - 1 == indx)
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index].Cells["ProductRate"];
                    GridControlMode(false);
                }
                else
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["ProductRate"];
                    GridControlMode(true);
                   // TxtGridRate.Focus();
                }
            }
        }
        private void TxtGridPercent_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int indx = Grid.CurrentRow.Index;
            if (SetTextBoxValueToGrid() == true)
            {
                GridControlMode(false);
                if (Grid.Rows.Count - 1 == indx)
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index].Cells["DisPercent"];
                    GridControlMode(false);
                }
                else
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["DisPercent"];
                    GridControlMode(true);
                }
            }
        }

        private void RdoGroupWiseGroup_CheckedChanged(object sender, EventArgs e)
        {
            _SearchKey = "";
            if (RdoGroupWiseGroup.Checked == true)
            {
                RdoProduct.Checked = false;
                RdoProductGroup.Checked = false;
                RdoProductSubGroup.Checked = false;
                RdoSubGroupWiseGroup.Checked = false;
                RdoSubGroupWiseSubGroup.Checked = false;
                string GroupId = GroupSearch();
                LoadProduct(GroupId);
            }
        }

        private void RdoSubGroupWiseGroup_CheckedChanged(object sender, EventArgs e)
        {
            _SearchKey = "";
            if (RdoSubGroupWiseGroup.Checked == true)
            {
                RdoProduct.Checked = false;
                RdoProductGroup.Checked = false;
                RdoProductSubGroup.Checked = false;
                RdoSubGroupWiseSubGroup.Checked = false;
                RdoGroupWiseGroup.Checked = false;
                string GroupId = GroupSearch();
                LoadProduct(GroupId);
            }
        }

        private void RdoSubGroupWiseSubGroup_CheckedChanged(object sender, EventArgs e)
        {
            _SearchKey = "";
            if (RdoSubGroupWiseSubGroup.Checked == true)
            {
                RdoProduct.Checked = false;
                RdoProductGroup.Checked = false;
                RdoProductSubGroup.Checked = false;
                RdoSubGroupWiseGroup.Checked = false;
                RdoGroupWiseGroup.Checked = false;
                string GroupId = GroupSearch();
                ClsGlobal.ProductGroup = GroupId;
                string SubGroupId = SubGroupSearch();
                LoadProduct(GroupId, SubGroupId);
                ClsGlobal.ProductGroup = "";
            }
        }

        private void TxtPercentRate_Validating(object sender, CancelEventArgs e)
        {
            foreach (DataGridViewRow ro in Grid.Rows )
            {

                ro.Cells["DisPercent"].Value = TxtPercentRate.Text;
            }
        }

        private void Grid_Leave(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
            BtnSave.TabStop = true;
        }

        private void ControlRadioButton(bool rdo)
        {
            RdoProduct.Enabled = rdo;
            RdoProductGroup.Enabled = rdo;
            RdoProductSubGroup.Enabled = rdo;
            RdoGroupWiseGroup.Enabled = rdo;
            RdoSubGroupWiseGroup.Enabled = rdo;
            RdoSubGroupWiseSubGroup.Enabled = rdo;
        }
        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            ControlRadioButton(true);
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GridControlMode(true);
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
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, "", TxtDescription, BtnSearchDescription, true);
            }
        }

        private void SetData(DataSet ds)
        {
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];          
            _SchemeId =Convert.ToInt32( dtMaster.Rows[0]["SchemeId"].ToString());
            TxtDescription.Text = dtMaster.Rows[0]["SchemeName"].ToString();
            if (dtMaster.Rows[0]["SchemeWise"].ToString() == "Product")
            {
                RdoProduct.Enabled = true;
                RdoProduct.Checked = true;
                
                RdoProductGroup.Enabled = false;
                RdoProductSubGroup.Enabled = false;
                RdoGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseSubGroup.Enabled = false;
            }
            else if (dtMaster.Rows[0]["SchemeWise"].ToString() == "ProductGroup")
            {
                RdoProductGroup.Enabled = true;
                RdoProductGroup.Checked = true;

                RdoProduct.Enabled = false;
                RdoProductSubGroup.Enabled = false;
                RdoGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseSubGroup.Enabled = false;
            }
            else if (dtMaster.Rows[0]["SchemeWise"].ToString() == "ProductSubGroup")
            {
                RdoProductSubGroup.Enabled = true;
                RdoProductSubGroup.Checked = true;

                RdoProduct.Enabled = false;
                RdoProductGroup.Enabled = false;
                RdoGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseSubGroup.Enabled = false;
            }
            else if (dtMaster.Rows[0]["SchemeWise"].ToString() == "Group")
            {
                RdoGroupWiseGroup.Enabled = true;
                RdoGroupWiseGroup.Checked = true;
             

                RdoProduct.Enabled = false;
                RdoProductGroup.Enabled = false;
                RdoProductSubGroup.Enabled = false;
                RdoSubGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseSubGroup.Enabled = false;
            }
            else if (dtMaster.Rows[0]["SchemeWise"].ToString() == "SubGroupGroup")
            {
                RdoSubGroupWiseGroup.Enabled = true;
                RdoSubGroupWiseGroup.Checked = true;
               

                RdoProduct.Enabled = false;
                RdoProductGroup.Enabled = false;
                RdoProductSubGroup.Enabled = false;
                RdoGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseSubGroup.Enabled = false;
            }
            else if (dtMaster.Rows[0]["SchemeWise"].ToString() == "SubGroupSubGroup")
            {
                RdoSubGroupWiseSubGroup.Enabled = true;
                RdoSubGroupWiseSubGroup.Checked = true;
               

                RdoProduct.Enabled = false;
                RdoProductGroup.Enabled = false;
                RdoProductSubGroup.Enabled = false;
                RdoGroupWiseGroup.Enabled = false;
                RdoSubGroupWiseGroup.Enabled = false;
            }

            if (dtDetails.Rows.Count > 0)
            {
                TxtPercentRate.Text =ClsGlobal.DecimalFormate(Convert.ToDecimal( dtDetails.Rows[0]["DiscountPercent"].ToString()),1,ClsGlobal._RateDecimalFormat).ToString();
                if (ClsGlobal.DateType == "M")
                {
                    TxtDateFrom.Text = _objDate.GetMiti(Convert.ToDateTime(dtDetails.Rows[0]["StartDate"].ToString()));
                    TxtDateTo.Text = _objDate.GetMiti(Convert.ToDateTime(dtDetails.Rows[0]["EndDate"].ToString()));
                }
                else
                {
                    TxtDateFrom.Text = Convert.ToDateTime(dtDetails.Rows[0]["StartDate"].ToString()).ToShortDateString();
                    TxtDateTo.Text = Convert.ToDateTime(dtDetails.Rows[0]["EndDate"].ToString()).ToShortDateString();
                }

                foreach (DataRow dr in dtDetails.Rows)
                {
                    Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Product"].Value = dr["ProductDesc"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = dr["ProductId"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["PGroup"].Value = dr["ProductGrpDesc"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductGrpId"].Value = dr["ProductGrpId"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["PSubGroup"].Value = dr["ProductSubGrpDesc"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductSubGrpId"].Value = dr["ProductSubGrpId"].ToString();
                    if (Convert.ToDecimal(dr["DiscountPercent"].ToString()) > 0)
                        Grid.Rows[Grid.Rows.Count - 1].Cells["DisPercent"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(dr["DiscountPercent"].ToString()), 1, ClsGlobal._AmountDecimalFormat);
                    else
                        Grid.Rows[Grid.Rows.Count - 1].Cells["DisPercent"].Value = "";

                    if (Convert.ToDecimal(dr["SchemeRate"].ToString()) > 0)
                        Grid.Rows[Grid.Rows.Count - 1].Cells["ProductRate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(dr["SchemeRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat);
                    else
                        Grid.Rows[Grid.Rows.Count - 1].Cells["ProductRate"].Value = "";

                    Grid.Rows[Grid.Rows.Count - 1].Cells["Action"].Value = Properties.Resources.Delete_16;

                    Grid.Rows.Add();
                }
            }
        }

    }
}
