using DataAccessLayer.Common;
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
    public partial class FrmCompanyUnitRights : Form
    {
        DataAccessLayer.Common.ClsUserMaster _objUser = new DataAccessLayer.Common.ClsUserMaster();
        public FrmCompanyUnitRights()
        {
            InitializeComponent();
            GridUser.Focus();
        }
        private void FrmCompanyUnitRights_Load(object sender, EventArgs e)
        {
            GridUser.ReadOnly = true;
            DataTable dt = _objUser.UserListForRights();
            foreach (DataRow row in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    var index = GridUser.Rows.Add();
                    GridUser.Rows[index].Cells["UserCode"].Value = row["UserCode"].ToString();
                }
            }

            GridCompanyUnithName(GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString(), ClsGlobal.Initial);
            GridCompanyUnit.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            GridCompanyUnit.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void FrmCompanyUnitRights_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void GridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridUser.CurrentRow.Cells["UserCode"].Value != null)
                GridCompanyUnithName(GridUser.CurrentRow.Cells["UserCode"].Value.ToString(), ClsGlobal.Initial);
        }
        private void GridUser_Click(object sender, EventArgs e)
        {
            GridCompanyUnit.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            GridCompanyUnit.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void GridUser_SelectionChanged(object sender, EventArgs e)
        {
            if (GridUser.CurrentRow.Cells["UserCode"].Value != null)
                GridCompanyUnithName(GridUser.CurrentRow.Cells["UserCode"].Value.ToString(), ClsGlobal.Initial);
        }
        private void GridCompanyUnit_Click(object sender, EventArgs e)
        {
            GridCompanyUnit.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            GridCompanyUnit.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }
        private void GridCompanyUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (GridCompanyUnit.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(GridCompanyUnit.Rows[GridCompanyUnit.CurrentRow.Index].Cells["Access"].Value) == true)
                    {
                        GridCompanyUnit.Rows[GridCompanyUnit.CurrentRow.Index].Cells["Access"].Value = false;
                    }
                    else
                    {
                        GridCompanyUnit.Rows[GridCompanyUnit.CurrentRow.Index].Cells["Access"].Value = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Enter && GridCompanyUnit.CurrentRow.Index == GridCompanyUnit.Rows.Count - 1)
            {
                e.SuppressKeyPress = true;
                BtnSave.Focus();
            }
        }
        private void GridCompanyUnit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GridCompanyUnit.Rows.Count > 0)
            {
                if (Convert.ToBoolean(GridCompanyUnit.Rows[GridCompanyUnit.CurrentRow.Index].Cells["Access"].Value) == true)
                {
                    GridCompanyUnit.Rows[GridCompanyUnit.CurrentRow.Index].Cells["Access"].Value = false;
                }
                else
                {
                    GridCompanyUnit.Rows[GridCompanyUnit.CurrentRow.Index].Cells["Access"].Value = true;
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataAccessLayer.Common.CompanyRightList CompanyRigtList = null;
            foreach (DataGridViewRow ro in GridCompanyUnit.Rows)
            {
                CompanyRigtList = new DataAccessLayer.Common.CompanyRightList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    CompanyRigtList.UserCode = GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString();
                    CompanyRigtList.BranchId = ro.Cells["BranchId"].Value.ToString();
                    CompanyRigtList.CompanyUnitId = ro.Cells["CompanyUnitId"].Value.ToString();
                    _objUser.CompanyList.Add(CompanyRigtList);
                }
            }
            _objUser.SaveCompanyUnitRights(GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString(), ClsGlobal.Initial);
            MessageBox.Show("Data has been updated successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void GridCompanyUnithName(string UserCode, string Initial)
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);
            dt.Columns.Add("Access", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("CompanyUnitId");
            dt.Columns.Add("Company Unit Name");
            dt.Columns.Add("BranchId");
            dt.Columns.Add("Branch Name");
            DataTable dt1 = _objUser.CompanyUnitListForUserRights(UserCode, Initial);
            foreach (DataRow row in dt1.Rows)
            {
                if (dt1.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Access"] = row["Tag"].ToString();
                    dr["CompanyUnitId"] = row["CompanyUnitId"].ToString();
                    dr["Company Unit Name"] = row["CmpUnitName"].ToString();
                    dr["BranchId"] = row["BranchId"].ToString();
                    dr["Branch Name"] = row["BranchName"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridCompanyUnit.DataSource = dt;
            GridCompanyUnit.Columns["Access"].Width = 50;
            GridCompanyUnit.Columns["CompanyUnitId"].Visible = false;
            GridCompanyUnit.Columns["BranchId"].Visible = false;

            GridCompanyUnit.Columns["Company Unit Name"].Width = 180;
            GridCompanyUnit.Columns["Company Unit Name"].ReadOnly = true;

            GridCompanyUnit.Columns["Branch Name"].Width = 180;
            GridCompanyUnit.Columns["Branch Name"].ReadOnly = true;
        }
    }
}
