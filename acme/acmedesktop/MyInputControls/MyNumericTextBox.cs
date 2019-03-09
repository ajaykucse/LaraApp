using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    public class MyNumericTextBox : TextBox
    {
        public MyNumericTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Enter += MyNumericTextBox_Enter;
            this.Leave += MyNumericTextBox_Leave;
            this.KeyPress += MyNumericTextBox_KeyPress;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        }

        void MyNumericTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        }

        void MyNumericTextBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        }

        private void MyNumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string val = "";
            if (this.Text == "0.00") val = ""; else val = this.Text;
            if ((val.Split('.').Length - 1) >= 1 && e.KeyChar == 46)
            {
                e.Handled = true;
                this.Focus();
                return;
            }

            if (e.KeyChar != 13 && e.KeyChar != 8)
            {
                if (char.IsDigit(e.KeyChar) == false && e.KeyChar != 46)
                {
                    e.Handled = true;
                    this.Focus();
                    return;
                }
            }
        }
    }
}
