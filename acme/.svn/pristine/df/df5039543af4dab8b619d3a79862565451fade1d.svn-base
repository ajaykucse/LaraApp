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
    public partial class FrmChangePassword : Form
    {
        ClsUserMaster _objUserMaster = new ClsUserMaster();
        public FrmChangePassword()
        {
            InitializeComponent();
        }
        private void ClearFld()
        {
            TxtPassword.Text = "";
            TxtNewPassword.Text = "";
            TxtConfirmPassword.Text = "";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _objUserMaster.Model.Tag = "ChangePassword";
            _objUserMaster.Model.UserCode = ClsGlobal.LoginUserCode;
            _objUserMaster.Model.UserPassword = TxtNewPassword.Text;
            string result = _objUserMaster.SaveUserMaster();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Password Changed successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFld();
            }
            else
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {           
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("Password Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtPassword.Focus();
                return;
            }
            else 
            {
                if (_objUserMaster.CheckOldPassword(TxtPassword.Text) == 1)
                {
                    MessageBox.Show("Old Password Not Valid...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtPassword.Focus();
                    return;
                }
            }
        }
        private void TxtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNewPassword.Text))
            {
                MessageBox.Show("New Password Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtNewPassword.Focus();
                return;
            }
        }
        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNewPassword.Text != TxtConfirmPassword.Text)
            {
                MessageBox.Show("Confirm Password Not Match With Password...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtConfirmPassword.Focus();
                return;
            }
        }
        private void FrmChangePassword_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmChangePassword_Load_1(object sender, EventArgs e)
        {

        }
    }
}
