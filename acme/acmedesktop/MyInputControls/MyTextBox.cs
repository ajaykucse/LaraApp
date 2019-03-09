using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Enter += MyTextBox_Enter;
            this.Leave += MyTextBox_Leave;
            //this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyTextBox_KeyPress);
        }

        void MyTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }
        void MyTextBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.NavajoWhite;
        }

        //private void MyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if (e.KeyChar == 39)
        //    //{
        //    //    e.Handled = true;
        //    //    this.Focus();
        //    //    return;
        //    //}
        //}
    }
}
