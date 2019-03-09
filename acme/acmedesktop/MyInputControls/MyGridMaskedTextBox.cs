using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    class MyGridMaskedTextBox : MaskedTextBox
    {
        public event EnterKeyPressHandler EnterKeyPress;
        public delegate void EnterKeyPressHandler();
        public MyGridMaskedTextBox(DataGridView grid)
        {
            this.Mask = "99/99/9999";
            this.TextAlign = HorizontalAlignment.Left;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GotFocus += new EventHandler(PickListTextBox_GotFocus);
            this.LostFocus += new EventHandler(PickListTextBox_LostFocus);
            // this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.Enter += GridMaskedTextBox_Enter;
            //this.Leave += GridMaskedTextBox_Leave; 

            grid.Controls.Add(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (EnterKeyPress != null)
                {
                    EnterKeyPress();
                    return true; ///Or false??? return to override the basic behavior
                }
                else
                {
                    SendKeys.Send("{Tab}");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        //void GridMaskedTextBox_Leave(object sender, EventArgs e)
        //{
        //    this.BackColor = System.Drawing.Color.White;
        //}

        //void GridMaskedTextBox_Enter(object sender, EventArgs e)
        //{
        //    this.BackColor = System.Drawing.Color.FromArgb(244, 177, 104);
        //}
        public void PickListTextBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.NavajoWhite;
        }

        private void PickListTextBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

    }
}
