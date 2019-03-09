using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    class MyGridComboBox : ComboBox
    {
        public event EnterKeyPressHandler EnterKeyPress;
        public delegate void EnterKeyPressHandler();

        public MyGridComboBox(DataGridView grid)
        {
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
    }
}
