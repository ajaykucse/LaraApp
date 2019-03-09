using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.MyInputControls
{
    class MyGridSubledgerTextBox : TextBox
    {
        public event EnterKeyPressHandler EnterKeyPress;
        public delegate void EnterKeyPressHandler();

        string searchKey = "";
        public string Value { get; set; }

        DataGridView Gridview = new DataGridView();
        public TextBox TxtValue { get; set; }

        public string GlDesc = "";

        public MyGridSubledgerTextBox()
        {
            this.ReadOnly = true;
            this.BackColor = System.Drawing.Color.White;
        }
        public MyGridSubledgerTextBox(DataGridView grid)
        {
            this.ReadOnly = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GotFocus += new EventHandler(PickListTextBox_GotFocus);
            this.LostFocus += new EventHandler(PickListTextBox_LostFocus);
            Gridview = grid;
            if (grid != null)
                grid.Controls.Add(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            searchKey = keyData.ToString();
            if (keyData == Keys.D0 || keyData == Keys.NumPad0) searchKey = "0";
            if (keyData == Keys.D1 || keyData == Keys.NumPad1) searchKey = "1";
            if (keyData == Keys.D2 || keyData == Keys.NumPad2) searchKey = "2";
            if (keyData == Keys.D3 || keyData == Keys.NumPad3) searchKey = "3";
            if (keyData == Keys.D4 || keyData == Keys.NumPad4) searchKey = "4";
            if (keyData == Keys.D5 || keyData == Keys.NumPad5) searchKey = "5";
            if (keyData == Keys.D6 || keyData == Keys.NumPad6) searchKey = "6";
            if (keyData == Keys.D7 || keyData == Keys.NumPad7) searchKey = "7";
            if (keyData == Keys.D8 || keyData == Keys.NumPad8) searchKey = "8";
            if (keyData == Keys.D9 || keyData == Keys.NumPad0) searchKey = "9";

            if (keyData == Keys.F1 || keyData == Keys.A || keyData == Keys.B || keyData == Keys.C || keyData == Keys.D || keyData == Keys.E || keyData == Keys.F || keyData == Keys.G || keyData == Keys.H || keyData == Keys.I || keyData == Keys.J || keyData == Keys.J || keyData == Keys.L || keyData == Keys.M || keyData == Keys.N || keyData == Keys.O || keyData == Keys.P || keyData == Keys.Q || keyData == Keys.R || keyData == Keys.S || keyData == Keys.T || keyData == Keys.U || keyData == Keys.V || keyData == Keys.W || keyData == Keys.X || keyData == Keys.Y || keyData == Keys.Z || keyData == Keys.D0 || keyData == Keys.D1 || keyData == Keys.D2 || keyData == Keys.D3 || keyData == Keys.D4 || keyData == Keys.D5 || keyData == Keys.D6 || keyData == Keys.D7 || keyData == Keys.D8 || keyData == Keys.D9 || keyData == Keys.NumPad0 || keyData == Keys.NumPad1 || keyData == Keys.NumPad2 || keyData == Keys.NumPad3 || keyData == Keys.NumPad4 || keyData == Keys.NumPad5 || keyData == Keys.NumPad6 || keyData == Keys.NumPad7 || keyData == Keys.NumPad8 || keyData == Keys.NumPad9)
            {
                this.Text = "";
                ShowList();
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(keyData.ToString(), @"^D?[a-zA-Z0-9]{1}$"))
            {
                this.Text = "";
                ShowList();
            }
            else if (keyData == (Keys.N | Keys.Control))
            {
                CreateNew();
            }
            else if (keyData == Keys.Delete)
            {
                this.Text = "";
            }
            else if (keyData == Keys.Enter)
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
            else if (keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;///Or false??? return to override the basic behavior
            }
            else
            {
                //HandleCmdKey(keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowList()
        {
            SubLedger();
        }

        private void CreateNew()
        {
            //clsGlobal.CtrlNewData = "";
            //switch (PickListType)
            //{
            //    case ListType.SubLedger:
            //        SwastikPOS.Master.Ledger.frmSubLedger frm1 = new SwastikPOS.Master.Ledger.frmSubLedger('Y');
            //        frm1.ShowDialog();
            //        break;
            //}
            //this.Text = clsGlobal.CtrlNewData;
        }

        public void PickListTextBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.NavajoWhite;
        }

        private void PickListTextBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        public void SubLedger()
        {
            Common.PickList frm = new Common.PickList("Subledger", searchKey);
            frm.ShowDialog();
            if (frm.SelectedList.Count > 0)
            {
                this.Text = frm.SelectedList[0]["SubledgerDesc"].ToString();
                this.Tag = frm.SelectedList[0]["SubledgerId"].ToString();
                if (this.TxtValue != null) this.TxtValue.Text = frm.SelectedList[0]["SubledgerShortName"].ToString();
                this.Value = frm.SelectedList[0]["SubledgerShortName"].ToString();
            }
            frm.Dispose();
        }
    }
}