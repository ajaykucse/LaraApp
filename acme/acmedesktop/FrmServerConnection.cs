using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop
{
    public partial class FrmServerConnection : Form
    {
        string _ServerName = string.Empty;
        public FrmServerConnection()
        {
            InitializeComponent();
        }
      
        private void FrmServerConnection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void FrmServerConnection_Load(object sender, EventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine(KeyData);
            _ServerName = Properties.Settings.Default.ServerName;
            TxtServerName.Text = Properties.Settings.Default.ServerName;
            TxtServerUserName.Text = Properties.Settings.Default.ServeUserName;
            TxtPassword.Text = Properties.Settings.Default.ServerPassword;
            if (!string.IsNullOrEmpty(TxtServerName.Text))
            {
                BtnConnect.PerformClick();
            }
            TxtServerName.Focus();
        }

        private void BtnConnect_Click_1(object sender, EventArgs e)
        {
            bool ConCheck = DataAccessLayer.Database.ConnectionCheck(TxtServerName.Text, TxtServerUserName.Text, TxtPassword.Text);
            if (ConCheck == true)
            {
                if (string.IsNullOrEmpty(_ServerName))
                {
                    Properties.Settings.Default.ServerName = TxtServerName.Text.Trim();
                    Properties.Settings.Default.ServeUserName = TxtServerUserName.Text.Trim();
                    Properties.Settings.Default.ServerPassword = TxtPassword.Text.Trim();
                    Properties.Settings.Default.Save();
                }

                DataAccessLayer.Common.ClsGlobal.ShowMdiForm = true;
                DataAccessLayer.Common.ClsGlobal.ShowCompanyCreate = (CheckMasterTable() == true) ? true : false;
                if (DataAccessLayer.Common.ClsGlobal.ShowCompanyCreate == false)
                {
                    DataAccessLayer.Common.ClsGlobal.ShowLoginForm = true;
                }
                this.Close();
            }
            else
            {
                _ServerName = string.Empty;
                MessageBox.Show("Invalid Server Name", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CheckMasterTable()
        {
            string checkmaster = DataAccessLayer.Database.GetSqlMasterData("select name from sys.databases where name = 'MYMASTER'");
            return (checkmaster != "") ? false : true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
