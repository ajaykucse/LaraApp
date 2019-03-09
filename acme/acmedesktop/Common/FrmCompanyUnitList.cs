using DataAccessLayer.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.Common
{
    public partial class FrmCompanyUnitList : Form
    {
        DataAccessLayer.SystemSetting.ClsCompanyUnit _objCompanyUnit = new DataAccessLayer.SystemSetting.ClsCompanyUnit();

        public FrmCompanyUnitList()
        {
            InitializeComponent();
        }

        private void FrmBranchList_Load(object sender, EventArgs e)
        {
            ListCompany();
        }

        private void ListCompany()
        {
            DataTable dt = _objCompanyUnit.CompanyUnitListByUserCode(DataAccessLayer.Common.ClsGlobal.LoginUserCode);
            Grid.DataSource = dt;
            Grid.Columns["CompanyUnitId"].Visible = false;
            Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grid.Columns["ShortName"].Width = 150;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CompanyUnitSelect();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            CompanyUnitSelect();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CompanyUnitSelect()
        {
            if (Grid.Rows.Count > 0)
            {
                ClsGlobal.CompanyUnitId = Convert.ToInt32(Grid.Rows[Grid.CurrentRow.Index].Cells["CompanyUnitId"].Value.ToString());
                ClsGlobal.CompanyUnitDesc = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Description"].Value.ToString();
                this.Close();
            }
        }
    }
}