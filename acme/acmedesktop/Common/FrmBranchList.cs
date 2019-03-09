using DataAccessLayer.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.Common
{
    public partial class FrmBranchList : Form
    {
        DataAccessLayer.SystemSetting.ClsBranch _objBranch = new DataAccessLayer.SystemSetting.ClsBranch();

        public FrmBranchList()
        {
            InitializeComponent();
        }

        private void FrmBranchList_Load(object sender, EventArgs e)
        {
            ListBranch();
        }

        private void ListBranch()
        {
            DataTable dt = _objBranch.BranchListByUserCode(DataAccessLayer.Common.ClsGlobal.LoginUserCode);
            Grid.DataSource = dt;
            Grid.Columns["BranchId"].Visible = false;
            Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grid.Columns["ShortName"].Width = 150;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                BranchSelect();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            BranchSelect();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BranchSelect()
        {
            if (Grid.Rows.Count > 0)
            {
                ClsGlobal.BranchId = Convert.ToInt32(Grid.Rows[Grid.CurrentRow.Index].Cells["BranchId"].Value.ToString());
                ClsGlobal.BranchDesc = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Description"].Value.ToString();
                this.Close();
            }
        }
    }
}