using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    class MyGridTextBox : TextBox
    {
        public event EnterKeyPressHandler EnterKeyPress;
        // public event TextChangedEnentHandler TextChanged; 
        public delegate void EnterKeyPressHandler();
        // public delegate void TextChangedEnentHandler(); 

        public MyGridTextBox(DataGridView grid)
        {
            this.TextAlign = HorizontalAlignment.Left;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GotFocus += new EventHandler(PickListTextBox_GotFocus);
            this.LostFocus += new EventHandler(PickListTextBox_LostFocus);
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
            else if (keyData == Keys.Tab)
            {
                return false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

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
