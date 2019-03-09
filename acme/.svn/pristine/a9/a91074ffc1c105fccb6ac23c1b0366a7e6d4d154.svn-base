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
    public partial class FrmServerSetting : Form
    {
        public FrmServerSetting()
        {
            InitializeComponent();
        }

        private void FrmServerSetting_Load(object sender, EventArgs e)
        {
            TxtServerName.Text = Properties.Settings.Default.ServerName;
            TxtServerUserName.Text = Properties.Settings.Default.ServeUserName;
            TxtPassword.Text = Properties.Settings.Default.ServerPassword;
        }

        private void FrmServerSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    BtnCancel.PerformClick();
                }
                else
                    BtnCancel.PerformClick();
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = TxtServerName.Text.Trim();
            Properties.Settings.Default.ServeUserName = TxtServerUserName.Text.Trim();
            Properties.Settings.Default.ServerPassword = TxtPassword.Text.Trim();
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
