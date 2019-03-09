using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer.Common
{
    public class ClsFormControl
    {
        public ClsFormControl(Form form)
        {
            form.KeyPress += Form_KeyPress;
            form.BackColor= System.Drawing.SystemColors.InactiveCaption;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.KeyPreview = true;
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Space)
            {
                SendKeys.Send("{F4}");
            }
        }
    }
}
