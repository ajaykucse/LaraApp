using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace acmedesktop.MasterSetup
{
    public partial class FrmUser : Form
    {
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
       
        public FrmUser()
        {
            InitializeComponent();
        }

        private void FrmUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void TxtUserCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserCode.Text))
            {
                MessageBox.Show("User Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtUserCode.Focus();
                return;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Username = TxtUserCode.Text;
            MobileNo = TxtMobileNo.Text;
            EmailId = TxtEmailId.Text;
            Password = TxtUserPassword.Text;
            Close();
        }

        private void TxtMobileNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMobileNo.Text))
            {
                MessageBox.Show("User MobileNo Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtMobileNo.Focus();
                return;
            }
        }

        private void TxtEmailId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtEmailId.Text))
            {
                MessageBox.Show("User EmailId Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtEmailId.Focus();
                return;
            }
        }

        private void TxtUserPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserPassword.Text))
            {
                MessageBox.Show("User Password Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtUserPassword.Focus();
                return;
            }else if (TxtUserPassword.TextLength<6)
            {
                MessageBox.Show("User Password Must be six character...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtUserPassword.Focus();
                return;
            }
        }
    }
}
