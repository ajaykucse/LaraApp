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

namespace acmedesktop.Common
{
    public partial class CompanyList : Form
    {
        DataAccessLayer.SystemSetting.ClsCompany _objCompany = new DataAccessLayer.SystemSetting.ClsCompany();
 
        public CompanyList()
        {
            InitializeComponent();
        }

        private void CompanyList_Load(object sender, EventArgs e)
        {
            ListCompany();
        }

        private void ListCompany()
        {
            DataTable dt = _objCompany.CompanyListByUserCode(DataAccessLayer.Common.ClsGlobal.LoginUserCode);
            Grid.DataSource = dt;
            Grid.Columns["IniTial"].Width = 100;
            Grid.Columns["Company Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grid.Columns["Start Date"].Width = 100;
            Grid.Columns["End Date"].Width = 100;
            Grid.Columns["Db Name"].Visible = false;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CompanySelect();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            CompanySelect();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CompanySelect()
        {
            if (Grid.Rows.Count > 0)
            {
                ClsGlobal.Initial = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["IniTial"].Value.ToString();
                ClsGlobal.CompanyName = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Company Name"].Value.ToString();
                ClsGlobal.CompanyStartDate = Convert.ToDateTime(Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Start Date"].Value.ToString()).ToShortDateString();
                ClsGlobal.CompanyEndDate = Convert.ToDateTime(Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["End Date"].Value.ToString()).ToShortDateString();
                ClsGlobal.DatabaseName = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Db Name"].Value.ToString();
                DataAccessLayer.Database._CompDatabaseName = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Db Name"].Value.ToString();
                this.Close();

                DataAccessLayer.SystemSetting.ClsCompany _objCompany = new DataAccessLayer.SystemSetting.ClsCompany();
                DataTable dt = _objCompany.GetDataCompany(ClsGlobal.Initial);
                StringBuilder strSql = new StringBuilder();
                strSql.Append(dt.Rows[0]["Address"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["City"].ToString()))
                    strSql.Append(", " + dt.Rows[0]["City"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["Country"].ToString()))
                    strSql.Append(", " + dt.Rows[0]["Country"].ToString());
                ClsGlobal.CompanyAddress = strSql.ToString();
                strSql.Clear();
                if (!string.IsNullOrEmpty(dt.Rows[0]["PhoneNo"].ToString()))
                    strSql.Append("Phone No : " + dt.Rows[0]["PhoneNo"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["AltPhoneNo"].ToString()))
                    strSql.Append(", " + dt.Rows[0]["AltPhoneNo"].ToString());
                ClsGlobal.CompanyPhoneNo = strSql.ToString();

                ClsDateMiti _objDate = new ClsDateMiti();
                if (ClsGlobal.DateType == "D")
                {
                    ClsGlobal.CompanyFiscalYear = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString()).ToShortDateString() + " - " + Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString()).ToShortDateString();
                }
                else
                {
                    ClsGlobal.CompanyStartMiti = _objDate.GetMiti(Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString()));
                    ClsGlobal.CompanyEndMiti = _objDate.GetMiti(Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString()));
                    ClsGlobal.CompanyFiscalYear = ClsGlobal.CompanyStartMiti + " - " + ClsGlobal.CompanyEndMiti;
                }

                //---------START UPDATE COMPANY ------------
                Version versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                ClsUpdateCompany _objUpdateCompany = new ClsUpdateCompany();
                if (_objUpdateCompany.GetCompanyVersionNo() != versionInfo.ToString())
                {
                    _objUpdateCompany.UpdateCompanyVersionNo(versionInfo.ToString());
                    _objUpdateCompany.CreateView();
                    _objUpdateCompany.InsertDefaultData();
                }
                //---------END UPDATE COMPANY ------------

                ClsGlobal.TodayDateTime = _objDate.GetServerDateTime();
                ClsGlobal.TodayDate = _objDate.GetServerDate();
                ClsGlobal.EntryControl("");
                ClsGlobal.UserRestriction(ClsGlobal.LoginUserCode, ClsGlobal.Initial);
            }
        }
    }
}