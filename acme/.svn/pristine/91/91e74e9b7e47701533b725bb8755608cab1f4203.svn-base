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
    public partial class UserLogin : Form
    {
        DataAccessLayer.Common.ClsUserMaster _objUserMaster = new DataAccessLayer.Common.ClsUserMaster();
        public UserLogin()
        {
            InitializeComponent();
        }
		private void UserLogin_Load(object sender, EventArgs e)
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				TxtUserName.Text = "Admin";
			}
		}
        private void UserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to Close Form..??", "Close Form", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (BtnCancel.Enabled == true)
                    {
                        BtnCancel.PerformClick();
                    }
                    else
                    {
                        Application.Exit();
                    }
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
        }

        private void UserLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //e.Cancel = true;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = _objUserMaster.CheckUser(TxtUserName.Text, TxtPassword.Text);
            if (dt.Rows.Count > 0)
            {
                DataAccessLayer.Common.ClsGlobal.LoginUserCode = dt.Rows[0]["UserCode"].ToString();
                DataAccessLayer.Common.ClsGlobal.ShowCompanyList = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid user");
                TxtUserName.Focus();
            }
			if(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))> Convert.ToDateTime("2019-05-30"))
			{
				MessageBox.Show("Your software is expired, for detail information please contact Mr.Solution 01-4469676...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Application.Exit();
			}

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
