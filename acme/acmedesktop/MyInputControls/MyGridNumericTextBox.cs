using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    class MyGridNumericTextBox : TextBox
    {
        public event EnterKeyPressHandler EnterKeyPress;
        // public event TextChangedEnentHandler TextChanged; 
        public delegate void EnterKeyPressHandler();
        // public delegate void TextChangedEnentHandler(); 

        public MyGridNumericTextBox(DataGridView grid)
        {
            this.TextAlign = HorizontalAlignment.Right;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GotFocus += new EventHandler(PickListTextBox_GotFocus);
            this.LostFocus += new EventHandler(PickListTextBox_LostFocus);
            grid.Controls.Add(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char key = (char)keyData;
            if ((keyData == Keys.Enter || char.IsLetter(key) || key == 191 || key == 187 || key == 188 || key == 189) && (key != 96 && key != 97 && key != 98 && key != 99 && key != 100 && key != 101 && key != 102 && key != 103 && key != 104 && key != 105 && key != 110))
            {
                if (key == 191 || key == 187 || key == 188 || key == 189)
                {
                    this.Focus();
                    return true;
                }
                else if (char.IsLetter(key))
                {
                    return true;
                }
                else
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
                    //SendKeys.Send("{Tab}");
                    //return true;
                }
            }
            else if (keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;//Or false??? return to override the basic behavior
            }

            if (this.Text.Split('.').Length - 1 > 0 && key == 110)
                return true;

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