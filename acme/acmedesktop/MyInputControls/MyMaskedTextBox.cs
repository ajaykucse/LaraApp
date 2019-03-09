using System;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    public class MyMaskedTextBox : MaskedTextBox
    {
        private bool alreadyFocused;
        public MyMaskedTextBox()
        {
            Mask = "99/99/9999";
            BorderStyle = BorderStyle.FixedSingle;
            InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            
            Enter += MyMaskedTextBox_Enter;
            Leave += MyMaskedTextBox_Leave;
            GotFocus += MyMaskedTextBox_GotFocus;
            MouseUp += MyMaskedTextBox_MouseUp;
        }
        private void MyMaskedTextBox_Leave(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.White;
            alreadyFocused = false;
        }

        private void MyMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.NavajoWhite;
            SendKeys.SendWait("{HOME}");
        }

        private void MyMaskedTextBox_GotFocus(object sender, EventArgs e)
        {
            if (MouseButtons == MouseButtons.None)
            {
                alreadyFocused = true;
            }
            this.SelectionStart = 0;
        }

        private void MyMaskedTextBox_MouseUp(object sender, EventArgs e)
        {
            if (!alreadyFocused && SelectionLength == 0)
            {
                alreadyFocused = true;
            }
        }

    }
}
