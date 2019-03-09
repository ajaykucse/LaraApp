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
    public partial class FrmCompanyRights : Form
    {
        DataAccessLayer.Common.ClsUserMaster _objUser = new DataAccessLayer.Common.ClsUserMaster();
        public FrmCompanyRights()
        {
            InitializeComponent();
            GridUser.Focus();
        }
        private void FrmCompanyRights_Load(object sender, EventArgs e)
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

            GridCompanyName(GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString());
            GridCompany.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            GridCompany.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void FrmCompanyRights_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void GridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridUser.CurrentRow.Cells["UserCode"].Value != null)
                GridCompanyName(GridUser.CurrentRow.Cells["UserCode"].Value.ToString());
        }
        private void GridUser_Click(object sender, EventArgs e)
        {
            GridCompany.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            GridCompany.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
        private void GridUser_SelectionChanged(object sender, EventArgs e)
        {
            if (GridUser.CurrentRow.Cells["UserCode"].Value != null)
                GridCompanyName(GridUser.CurrentRow.Cells["UserCode"].Value.ToString());
        }
        private void GridCompany_Click(object sender, EventArgs e)
        {
            GridCompany.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            GridCompany.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }
        private void GridCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (GridCompany.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value) == true)
                    {
                        GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value = false;
                    }
                    else
                    {
                        GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Enter && GridCompany.CurrentRow.Index == GridCompany.Rows.Count - 1)
            {
                e.SuppressKeyPress = true;
                BtnSave.Focus();
            }
        }
        private void GridCompany_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GridCompany.Rows.Count > 0)
            {
                if (Convert.ToBoolean(GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value) == true)
                {
                    GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value = false;
                }
                else
                {
                    GridCompany.Rows[GridCompany.CurrentRow.Index].Cells["Access"].Value = true;
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataAccessLayer.Common.CompanyRightList CompanyRigtList = null;
            foreach (DataGridViewRow ro in GridCompany.Rows)
            {
                CompanyRigtList = new DataAccessLayer.Common.CompanyRightList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    CompanyRigtList.UserCode = GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString();
                    CompanyRigtList.IniTial = ro.Cells["IniTial"].Value.ToString();
                    _objUser.CompanyList.Add(CompanyRigtList);
                }
            }
            _objUser.SaveCompanyRights(GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString());
            MessageBox.Show("Data has been updated successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void GridCompanyName(string UserCode)
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);

            dt.Columns.Add("Access", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("IniTial");
            dt.Columns.Add("CompanyName");

            DataTable dt1 = _objUser.CompanyListForUserRights(UserCode);
            foreach (DataRow row in dt1.Rows)
            {
                if (dt1.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Access"] = row["Tag"].ToString();
                    dr["IniTial"] = row["IniTial"].ToString();
                    dr["CompanyName"] = row["CompanyName"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridCompany.DataSource = dt;
            GridCompany.Columns["Access"].Width = 50;
            GridCompany.Columns["IniTial"].Width = 60;
            GridCompany.Columns["IniTial"].ReadOnly = true;
            GridCompany.Columns["CompanyName"].Width =300;
            GridCompany.Columns["CompanyName"].ReadOnly = true;
        }
    }
}
