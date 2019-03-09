using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.SystemSetting
{
    public partial class UserRestriction : Form
    {
        MyGridTextBox TxtGridCompanyCode;
        MyGridTextBox TxtGridCompanyName;
        MyGridComboBox TxtGridSalesRateChange;
        MyGridComboBox TxtGridSalesTermChange;
        MyGridComboBox TxtGridPurchaseRateChange;
        MyGridComboBox TxtGridPurchaseTermChange;
        IUserRestriction _objUserRestriction = new ClsUserRestriction();
        ClsUserMaster _objuser = new ClsUserMaster();
        
        public UserRestriction()
        {
            InitializeComponent();
            TxtGridCompanyCode = new MyGridTextBox(Grid);
            TxtGridCompanyCode.ReadOnly = true;
            TxtGridCompanyName = new MyGridTextBox(Grid);
            TxtGridCompanyName.ReadOnly = true;
            TxtGridSalesRateChange = new MyGridComboBox(Grid);
            TxtGridSalesTermChange = new MyGridComboBox(Grid);
            TxtGridPurchaseRateChange = new MyGridComboBox(Grid);
            TxtGridPurchaseTermChange = new MyGridComboBox(Grid);
            this.TxtGridPurchaseTermChange.EnterKeyPress += new MyGridComboBox.EnterKeyPressHandler(this.TxtGridPurchaseTermChange_EnterKeyPress);
            GridControlMode(false);
        }
        private bool SetTextBoxValueToGrid()
        {
            if (!string.IsNullOrEmpty(this.TxtGridCompanyCode.Text))
            {
                DataGridViewRow ro = new DataGridViewRow();
                ro = this.Grid.Rows[this.Grid.CurrentRow.Index];
                ro.Cells["CompanyCode"].Value = this.TxtGridCompanyCode.Text;
                ro.Cells["CompanyName"].Value = this.TxtGridCompanyName.Text;
                ro.Cells["SalesRateChange"].Value = this.TxtGridSalesRateChange.Text;
                ro.Cells["SalesTermChange"].Value = this.TxtGridSalesTermChange.Text;
                ro.Cells["PurchaseRateChange"].Value = this.TxtGridPurchaseRateChange.Text;
                ro.Cells["PurchaseTermChange"].Value = this.TxtGridPurchaseTermChange.Text;
            }
            else
            {
                this.TxtGridCompanyCode.Focus();
            }
            return true;
        }
        private void SetGridValueToTextBox(int row)
        {
            TxtGridCompanyCode.Text = "";            
            TxtGridCompanyName.Text = "";
            TxtGridSalesRateChange.Tag = "0";
            TxtGridSalesTermChange.Text = "0";
            TxtGridPurchaseRateChange.Tag = "0";
            TxtGridPurchaseTermChange.Text = "0";

            if (Grid["CompanyCode", row].Value != null)
            {
                TxtGridCompanyCode.Text = Grid["CompanyCode", row].Value.ToString();               
            }
            if (Grid["CompanyName", row].Value != null)
            {
                TxtGridCompanyName.Text = Grid["CompanyName", row].Value.ToString();                    
            }
            if (Grid["SalesRateChange", row].Value != null)
            {
                TxtGridSalesRateChange.Text = Grid["SalesRateChange", row].Value.ToString();
            }
            if (Grid["SalesTermChange", row].Value != null)
            {
                TxtGridSalesTermChange.Text = Grid["SalesTermChange", row].Value.ToString();
            }
            if (Grid["PurchaseRateChange", row].Value != null)
            {
                TxtGridPurchaseRateChange.Text = Grid["PurchaseRateChange", row].Value.ToString();
            }
            if (Grid["PurchaseTermChange", row].Value != null)
            {
                TxtGridPurchaseTermChange.Text = Grid["PurchaseTermChange", row].Value.ToString();
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
                    colindex = Grid.Columns["CompanyCode"].Index;
                    TxtGridCompanyCode.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridCompanyCode.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
               
                    colindex = Grid.Columns["CompanyName"].Index;
                    TxtGridCompanyName.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridCompanyName.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                   
                    
                    colindex = Grid.Columns["SalesRateChange"].Index;
                    TxtGridSalesRateChange.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridSalesRateChange.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                  
                    colindex = Grid.Columns["SalesTermChange"].Index;
                    TxtGridSalesTermChange.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridSalesTermChange.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["PurchaseRateChange"].Index;
                    TxtGridPurchaseRateChange.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridPurchaseRateChange.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["PurchaseTermChange"].Index;
                    TxtGridPurchaseTermChange.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridPurchaseTermChange.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                }
                SetGridValueToTextBox(currRo);
            }

            TxtGridCompanyCode.Enabled = mode;
            TxtGridCompanyCode.Visible = mode;
            TxtGridCompanyName.Enabled = mode;
            TxtGridCompanyName.Visible = mode;
            TxtGridSalesRateChange.Enabled = mode;
            TxtGridSalesRateChange.Visible = mode;
            TxtGridSalesTermChange.Enabled = mode;
            TxtGridSalesTermChange.Visible = mode;
            TxtGridPurchaseRateChange.Enabled = mode;
            TxtGridPurchaseRateChange.Visible = mode;
            TxtGridPurchaseTermChange.Enabled = mode;
            TxtGridPurchaseTermChange.Visible = mode;

            if (mode == true)
                BtnOk.Enabled = false;
            else
                BtnOk.Enabled = true;

            if (mode == true)
            {
                TxtGridCompanyCode.Focus();
            }
        }


        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserRestriction_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            DataTable dtUser = _objuser.ComboBindUserName();
            if (dtUser.Rows.Count > 0)
            {
                CmbUserName.DataSource = dtUser;
                CmbUserName.DisplayMember = "UserCode";
                CmbUserName.ValueMember = "UserCode";
            }
        }

        private void TxtGridPurchaseTermChange_EnterKeyPress()
        {
            if (this.SetTextBoxValueToGrid())
            {
                this.GridControlMode(false);
                if (this.Grid.CurrentRow.Index != this.Grid.Rows.Count - 1)
                {
                    this.Grid.CurrentCell = this.Grid.Rows[this.Grid.CurrentRow.Index + 1].Cells["CompanyCode"];
                    this.SetGridValueToTextBox(this.Grid.CurrentRow.Index);
                    this.GridControlMode(true);
                }
                else
                {
                    this.Grid.Rows.Add();
                    this.Grid.CurrentCell = this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["CompanyCode"];
                    this.BtnOk.Focus();
                    this.Grid.Rows.RemoveAt(this.Grid.CurrentRow.Index);
                }
            }
        }


        private void UserRestriction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl != Grid)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridCompanyCode.Visible == true)
                {
                    GridControlMode(false);
                    Grid.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                    BtnCancel.PerformClick();
                }
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void CmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetData();
        }

        private void SetData()
        {
            this.TxtGridSalesRateChange.Items.Clear();
            this.TxtGridSalesRateChange.Items.Add("Yes");
            this.TxtGridSalesRateChange.Items.Add("No");
            this.TxtGridSalesRateChange.SelectedIndex = 0;
            this.TxtGridSalesTermChange.Items.Clear();
            this.TxtGridSalesTermChange.Items.Add("Yes");
            this.TxtGridSalesTermChange.Items.Add("No");
            this.TxtGridSalesTermChange.SelectedIndex = 0;
            this.TxtGridPurchaseRateChange.Items.Clear();
            this.TxtGridPurchaseRateChange.Items.Add("Yes");
            this.TxtGridPurchaseRateChange.Items.Add("No");
            this.TxtGridPurchaseRateChange.SelectedIndex = 0;
            this.TxtGridPurchaseTermChange.Items.Clear();
            this.TxtGridPurchaseTermChange.Items.Add("Yes");
            this.TxtGridPurchaseTermChange.Items.Add("No");
            this.TxtGridPurchaseTermChange.SelectedIndex = 0;       
            this.Grid.Rows.Clear();
            DataTable usercompany = this._objUserRestriction.GetUserCompany(CmbUserName.Text.ToString());
            if (usercompany.Rows.Count > 0)
            {
                for (int i = 0; i < usercompany.Rows.Count; i++)
                {
                    DataRow ro = usercompany.Rows[i];
                    this.Grid.Rows.Add();
                    if (ro["IniTial"] != DBNull.Value)
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["CompanyCode"].Value = ro["Initial"].ToString();
                    }
                    if (ro["CompanyName"] != DBNull.Value)
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["CompanyName"].Value = ro["CompanyName"].ToString();
                    }

                    if (!(ro["AccessSalesRateChange"].ToString() == "0"))
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["SalesRateChange"].Value = "No";
                        this.TxtGridSalesRateChange.SelectedIndex = 1;
                    }
                    else
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["SalesRateChange"].Value = "Yes";
                        this.TxtGridSalesRateChange.SelectedIndex = 0;
                    }
                    if (!(ro["AccessSalesTermChange"].ToString() == "0"))
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["SalesTermChange"].Value = "No";
                        this.TxtGridSalesTermChange.SelectedIndex = 1;
                    }
                    else
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["SalesTermChange"].Value = "Yes";
                        this.TxtGridSalesTermChange.SelectedIndex = 0;
                    }
                    if (!(ro["AccessPurchaseRateChange"].ToString() == "0"))
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["PurchaseRateChange"].Value = "No";
                        this.TxtGridPurchaseRateChange.SelectedIndex = 1;
                    }
                    else
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["PurchaseRateChange"].Value = "Yes";
                        this.TxtGridPurchaseRateChange.SelectedIndex = 0;
                    }
                    if (!(ro["AccessPurchaseTermChange"].ToString() == "0"))
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["PurchaseTermChange"].Value = "No";
                        this.TxtGridPurchaseTermChange.SelectedIndex = 1;
                    }
                    else
                    {
                        this.Grid.Rows[this.Grid.Rows.Count - 1].Cells["PurchaseTermChange"].Value = "Yes";
                        this.TxtGridPurchaseTermChange.SelectedIndex = 0;
                    }
                }
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                this.GridControlMode(true);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            UserRestrictionViewModel DetailsModel = null;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                if (ro.Cells["CompanyCode"].Value != null)
                {
                    DetailsModel = new UserRestrictionViewModel();

                    if (ro.Cells["CompanyCode"].Value.ToString() != "")
                    {
                        DetailsModel.UserCode = this.CmbUserName.Text;
                        DetailsModel.IniTial = ro.Cells["CompanyCode"].Value.ToString();
                        DetailsModel.AccessSalesRateChange = ((ro.Cells["SalesRateChange"].Value.ToString() == "Yes")) ? 1: 0;
                        DetailsModel.AccessSalesTermChange = ((ro.Cells["SalesTermChange"].Value.ToString() == "Yes")) ? 1 : 0;
                        DetailsModel.AccessPurchaseRateChange = ((ro.Cells["PurchaseRateChange"].Value.ToString() == "Yes")) ? 1 : 0;
                        DetailsModel.AccessPurchaseTermChange = ((ro.Cells["PurchaseTermChange"].Value.ToString() == "Yes")) ? 1 : 0;

                    }
                    _objUserRestriction.Model.Add(DetailsModel);
                }
            }
            this._objUserRestriction.SaveUserRestriction(this.CmbUserName.Text);
            
        }
    }
}
