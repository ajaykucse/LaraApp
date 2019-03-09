using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.BillingTransaction
{
    public partial class FrmDialogBox : Form
    {
        public string _formname = "", _labelname = "", _textDialog = "";

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _textDialog = "";
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDialog.Text))
            {
               if( _formname == "Discount" || _formname == "Service Charge" || _formname == "Quantity" || _formname == "Rate")
                _textDialog = "0";
               else
                _textDialog = "";
            }
            else
                _textDialog = TxtDialog.Text;
            this.Close();
        }

        private void FrmDialogBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    BtnCancel.PerformClick();
                }
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void TxtDialog_Validating(object sender, CancelEventArgs e)
        {
            if (_labelname == "Quantity:")
            {
                decimal dialogval = 1;
                decimal.TryParse(TxtDialog.Text, out dialogval);
                if (dialogval <= 0)
                {
                    MessageBox.Show("Value must be greater then Zero ...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtDialog.Focus();
                    return;
                }
            }
        }

        public FrmDialogBox(string formName, string labelName, string textDialog)
        {
            InitializeComponent();
            _formname = formName;
            _labelname = labelName;
            _textDialog = textDialog;
           
        }
        private void FrmDialogBox_Load(object sender, EventArgs e)
        {
            this.Text = _formname.ToString();
            LblDialog.Text  = _labelname.ToString();
            TxtDialog.Text = _textDialog.ToString();
            if (_labelname == "Note:" || _labelname == "Product:")
            {
                TxtDialog.Multiline = true;
                TxtDialog.Font = new Font("Microsoft Sans Serif", 8.5f);
                TxtDialog.Height = 50;
                //TxtDialog.Text = "";
            }
               
            TxtDialog.Focus();
            TxtDialog.SelectAll();
        }

    }
}
