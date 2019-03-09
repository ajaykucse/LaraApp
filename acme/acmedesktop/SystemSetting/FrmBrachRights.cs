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
    public partial class FrmBrachRights : Form
    {
        DataAccessLayer.Common.ClsUserMaster _objUser = new DataAccessLayer.Common.ClsUserMaster();
        public FrmBrachRights()
        {
            InitializeComponent();
            GridUser.Focus();
        }

        private void FrmBrachRights_Load(object sender, EventArgs e)
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

            GridBranchName(GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString(), ClsGlobal.Initial);
            GridBranch.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            GridBranch.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void FrmBrachRights_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void GridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridUser.CurrentRow.Cells["UserCode"].Value != null)
                GridBranchName(GridUser.CurrentRow.Cells["UserCode"].Value.ToString(), ClsGlobal.Initial);
        }

        private void GridUser_Click(object sender, EventArgs e)
        {
            GridBranch.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            GridBranch.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void GridUser_SelectionChanged(object sender, EventArgs e)
        {
            if (GridUser.CurrentRow.Cells["UserCode"].Value != null)
                GridBranchName(GridUser.CurrentRow.Cells["UserCode"].Value.ToString(),ClsGlobal.Initial);
        }

        private void GridBranch_Click(object sender, EventArgs e)
        {
            GridBranch.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            GridBranch.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }

        private void GridBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (GridBranch.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(GridBranch.Rows[GridBranch.CurrentRow.Index].Cells["Access"].Value) == true)
                    {
                        GridBranch.Rows[GridBranch.CurrentRow.Index].Cells["Access"].Value = false;
                    }
                    else
                    {
                        GridBranch.Rows[GridBranch.CurrentRow.Index].Cells["Access"].Value = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Enter && GridBranch.CurrentRow.Index == GridBranch.Rows.Count - 1)
            {
                e.SuppressKeyPress = true;
                BtnSave.Focus();
            }
        }

        private void GridBranch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GridBranch.Rows.Count > 0)
            {
                if (Convert.ToBoolean(GridBranch.Rows[GridBranch.CurrentRow.Index].Cells["Access"].Value) == true)
                {
                    GridBranch.Rows[GridBranch.CurrentRow.Index].Cells["Access"].Value = false;
                }
                else
                {
                    GridBranch.Rows[GridBranch.CurrentRow.Index].Cells["Access"].Value = true;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataAccessLayer.Common.CompanyRightList CompanyRigtList = null;
            foreach (DataGridViewRow ro in GridBranch.Rows)
            {
                CompanyRigtList = new DataAccessLayer.Common.CompanyRightList();
                if (Convert.ToBoolean(ro.Cells[0].Value) == true)
                {
                    CompanyRigtList.UserCode = GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString();
                    CompanyRigtList.BranchId = ro.Cells["BranchId"].Value.ToString();
                    _objUser.CompanyList.Add(CompanyRigtList);
                }
            }
            _objUser.SaveBranchRights(GridUser.Rows[Convert.ToInt32(GridUser.CurrentRow.Index)].Cells[0].Value.ToString(),ClsGlobal.Initial);
            MessageBox.Show("Data has been updated successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void GridBranchName(string UserCode,string Initial)
        {
            DataTable dt = new DataTable();
            DataRow dr = default(DataRow);

            dt.Columns.Add("Access", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("BranchId");
            dt.Columns.Add("BranchName");

            DataTable dt1 = _objUser.BranchListForUserRights(UserCode,Initial);
            foreach (DataRow row in dt1.Rows)
            {
                if (dt1.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Access"] = row["Tag"].ToString();
                    dr["BranchId"] = row["BranchId"].ToString();
                    dr["BranchName"] = row["BranchName"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            GridBranch.DataSource = dt;
            GridBranch.Columns["Access"].Width = 50;
            GridBranch.Columns["BranchId"].Width = 60;
            GridBranch.Columns["BranchId"].ReadOnly = true;
            GridBranch.Columns["BranchName"].Width = 300;
            GridBranch.Columns["BranchName"].ReadOnly = true;
        }
    }
}
