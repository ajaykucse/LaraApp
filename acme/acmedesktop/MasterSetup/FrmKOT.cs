using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.MasterSetup;

namespace acmedesktop.MasterSetup
{
    public partial class FrmKOT : Form
    {
        MyGridPickListTextBox TxtGridWaiter;
        MyGridNumericTextBox TxtGridStartNo;
        MyGridNumericTextBox TxtGridEndNo;
        MyGridNumericTextBox TxtGridUsedNo;

        ClsDateMiti _objDate = new ClsDateMiti();
        IKOTAssign _objKOt = new ClsKOTAssign();
        int _KotId=0;
        private bool _GridControlMode { get; set; }
        public FrmKOT()
        {
            InitializeComponent();
            TxtGridWaiter = new MyGridPickListTextBox(Grid);
            TxtGridWaiter.Validating += new System.ComponentModel.CancelEventHandler(TxtGridWaiter_Validating);
            TxtGridWaiter.PickListType = MyGridPickListTextBox.ListType.Waiter;

            TxtGridStartNo = new MyGridNumericTextBox(Grid);
            this.TxtGridStartNo.TextChanged += new System.EventHandler(this.TxtGridStartNo_TextChanged);
            TxtGridStartNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridStartNo_Validating);
            
            TxtGridEndNo = new MyGridNumericTextBox(Grid);
            this.TxtGridEndNo.TextChanged += new System.EventHandler(this.TxtGridEndNo_TextChanged);
            TxtGridEndNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridEndNo_Validating);
            
            TxtGridUsedNo = new MyGridNumericTextBox(Grid);
            this.TxtGridUsedNo.TextChanged += new System.EventHandler(this.TxtGridUsedNo_TextChanged);
            TxtGridUsedNo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGridUsedNo_Validating);

        }

        private void TxtGridUsedNo_Validating(object sender, CancelEventArgs e)
        {
            if (Tag == "" || ActiveControl == TxtGridUsedNo) return;
            if ((string.IsNullOrEmpty(TxtGridUsedNo.Text) ? false : Convert.ToInt32(TxtGridUsedNo.Text) > 0))
            {
                if ((Convert.ToInt32(TxtGridUsedNo.Text) < Convert.ToInt32(TxtGridStartNo.Text) ? true : Convert.ToInt32(this.TxtGridUsedNo.Text) > Convert.ToInt32(TxtGridEndNo.Text)))
                {
                    MessageBox.Show("Used Number must be between Start number and End Number.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TxtGridUsedNo.Focus();
                    return;
                }
            }
            if (SetTextBoxValueToGrid())
            {
                if (Grid.CurrentRow.Index != Grid.Rows.Count - 1)
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["UsedNo"];
                }
                else
                {
                    Grid.Rows.Add();
                    Grid.CurrentCell = Grid.Rows[Grid.Rows.Count - 1].Cells["Waiter"];
                }
                //if ((Grid.Rows[Grid.Rows.Count - 1].Cells["Waiter"].Value == null ? false : Grid.Rows[Grid.Rows.Count - 1].Cells["Waiter"].Value != null))
                //{
                //    GridControlMode(true);
                //}
                //else
                //{
                    GridControlMode(true);
                //}
            }
        }

        private void TxtGridUsedNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtGridEndNo_Validating(object sender, CancelEventArgs e)
        {
            if (Tag == "" || ActiveControl == TxtGridEndNo) return;
            if (TxtGridWaiter.Text == "") return;
            decimal.TryParse(TxtGridStartNo.Text, out decimal startno);
            decimal.TryParse(TxtGridEndNo.Text, out decimal endno);
            if (!string.IsNullOrEmpty(TxtGridWaiter.Text) && string.IsNullOrEmpty(TxtGridEndNo.Text))
            {
                MessageBox.Show("KOT End number cannot left blank ...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGridEndNo.Focus();
                return;
            }
            else if (Grid.Rows.Count > 1)
            {
                for (int i = 1; i < Grid.Rows.Count; i++)
                {
                    if (endno <= Convert.ToDecimal(Grid["EndNo",i-1].Value.ToString()) && endno >= Convert.ToDecimal(Grid["StartNo",i-1].Value.ToString()))
                    {
                        MessageBox.Show("'" + TxtGridEndNo.Text + "' KOT number is already assign to another waiter  '" + Grid["Waiter",i-1].Value.ToString() + "'...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtGridEndNo.Focus();
                        return;
                    }
                }
            }
            else
            {
                if (endno <= startno)
                {
                    MessageBox.Show("KOT end number should be greater then start number...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtGridEndNo.Focus();
                    return;
                }
            }
            if (SetTextBoxValueToGrid() == true)
            {
                if (Grid.CurrentRow.Index == (Grid.Rows.Count - 1))
                {
                    Grid.Rows.Add();
                    Grid.CurrentCell = Grid.Rows[Grid.Rows.Count - 1].Cells["Waiter"];
                }
                else
                {
                    Grid.CurrentCell = Grid.Rows[Grid.CurrentRow.Index + 1].Cells["Waiter"];
                }
            }
            _GridControlMode = false;
            GridControlMode(false);
            _GridControlMode = true;
            Grid.Focus();
        }

        private void TxtGridEndNo_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TxtGridStartNo_Validating(object sender, CancelEventArgs e)
        {
            if (Tag == "" || ActiveControl == TxtGridStartNo) return;
            if (Grid["Waiter", 0].Value == null) return;
            if (!string.IsNullOrEmpty(TxtGridWaiter.Text) && string.IsNullOrEmpty(TxtGridStartNo.Text))
            {
                MessageBox.Show("KOT start number cannot left blank ...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGridStartNo.Focus();
                return;
            }
            else
            {
                if (Grid.Rows.Count > 1)
                {
                   for(int i=1;i<Grid.Rows.Count;i++)
                    {
                        if (Convert.ToDecimal(TxtGridStartNo.Text) >= Convert.ToDecimal(Grid["StartNo",i-1].Value.ToString()) && Convert.ToDecimal(TxtGridStartNo.Text) <= Convert.ToDecimal(Grid["EndNo",i-1].Value.ToString()))
                        {
                            MessageBox.Show("'" + TxtGridStartNo.Text + "' KOT number is already assign to another waiter '" + Grid["Waiter",i-1].Value.ToString() + "'...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxtGridStartNo.Focus();
                            return;
                        }
                    }
                }
            }
        }

        private void TxtGridStartNo_TextChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void TxtGridWaiter_Validating(object sender, CancelEventArgs e)
        {
            if (Tag == "" || ActiveControl == TxtGridWaiter)return;
            if (TxtGridWaiter.Enabled == false) return;
       
            if (string.IsNullOrEmpty(TxtGridWaiter.Text))
            {
                if (Grid.Rows.Count <= 1)
                {
                    MessageBox.Show("Waiter Cannot Left Blank.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtGridWaiter.Focus();
                }
                else
                {
                   GridControlMode(false);
                }
            }
            else
            {
                if (Grid.Rows.Count > 1)
                {
                    if (TxtGridWaiter.Text == Grid["Waiter", Grid.CurrentRow.Index - 1].Value.ToString())
                    {
                        MessageBox.Show("KOT is already assign to waiter " + Grid["Waiter", Grid.CurrentRow.Index - 1].Value.ToString() + "...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtGridWaiter.Focus();
                        return;
                    }
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 1)
            {
                if (Grid["Waiter", 0].Value == null)
                {
                    MessageBox.Show("KOT Assign data not enter...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnNew.Focus();
                    return;
                }
            }
            _objKOt.Model.Status = true;
            _objKOt.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objKOt.Model.EnterDate = DateTime.Now;
            _objKOt.Model.Tag = this.Tag.ToString();
            _objKOt.Model.BranchId = Convert.ToInt32(ClsGlobal.BranchId);
            _objKOt.Model.CompanyUnitId = Convert.ToInt32(ClsGlobal.CompanyUnitId);
            _objKOt.Model.CounterId = Convert.ToInt32(ClsGlobal.CounterId);
            _objKOt.Model.Gadget = "Desktop";

            KOTAssignViewModel _KOTAssign = null;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                _KOTAssign = new KOTAssignViewModel();
                if (ro.Cells["Waiter"].Value != null)
                {
                    if (this.Tag == "NEW")
                        _KOTAssign.KOTId = 0;
                    else if (this.Tag == "KOTCLOSE")
                        _KOTAssign.KOTId = Convert.ToInt32(ro.Cells["KOTId"].Value.ToString());
                    _KOTAssign.Sno = Grid.Rows.IndexOf(ro) + 1;
                    _KOTAssign.Waiter = ro.Cells["Waiter"].Value.ToString();
                    _KOTAssign.StartNo = Convert.ToInt32(ro.Cells["StartNo"].Value.ToString());
                    _KOTAssign.EndNo = Convert.ToInt32(ro.Cells["EndNo"].Value.ToString());
                    _KOTAssign.UsedNo = string.IsNullOrEmpty(ro.Cells["UsedNo"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["UsedNo"].Value.ToString());

                    _KOTAssign.KOTDate = Convert.ToDateTime(TxtDate.Text);
                    _KOTAssign.KOTMiti = TxtMiti.Text;

                    _objKOt.ModelKOTAssign.Add(_KOTAssign);
                }
            }
            string result = _objKOt.SaveKOTAssign();
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data submit successfully.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFld();
                GridControlMode(false);
                BtnNew.Focus();
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearFld();
            BtnCancel.Enabled = false;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.Tag = "NEW";
            Grid.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GridControlMode(true);
            }
        }
      
        public void ControlEnableDisable(bool btn, bool fld)
        {
            BtnNew.Enabled = fld;
            BtnOk.Enabled = btn;

            TxtMiti.Enabled = false;
            Utility.EnableDesibleDateColor(TxtMiti, false);
            TxtDate.Enabled = false;
            Utility.EnableDesibleDateColor(TxtDate, false);

            //TxtGridWaiter.Enabled = fld;
            //Utility.EnableDesibleColor(TxtGridWaiter, fld);
            //TxtGridStartNo.Enabled = fld;
            //Utility.EnableDesibleColor(TxtGridStartNo, fld);
            //TxtGridEndNo.Enabled = fld;
            //Utility.EnableDesibleColor(TxtGridEndNo, fld);
            //TxtGridUsedNo.Enabled = fld;
            //Utility.EnableDesibleColor(TxtGridUsedNo, fld);

            GridControlMode(false);

        }
        private void ClearFld()
        {
            this.Tag = "";
            TxtGridWaiter.Text = "";
            TxtGridStartNo.Text = "";
            TxtGridEndNo.Text = "";
            TxtGridUsedNo.Text = "";
            TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
            TxtDate.Text = _objDate.GetServerDate().ToShortDateString();
            Grid.Rows.Clear();
            Grid.Rows.Add();
        }

        private void GridControlMode(bool mode)
        {
            if (Grid.CurrentRow != null)
            {
                int currRo = Grid.CurrentRow.Index;
                int colindex = 0;
                if (mode == true)
                {
                    colindex = Grid.Columns["Waiter"].Index;
                    TxtGridWaiter.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridWaiter.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["StartNo"].Index;
                    TxtGridStartNo.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridStartNo.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["EndNo"].Index;
                    TxtGridEndNo.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridEndNo.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;

                    colindex = Grid.Columns["UsedNo"].Index;
                    TxtGridUsedNo.Size = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Size;
                    TxtGridUsedNo.Location = this.Grid.GetCellDisplayRectangle(colindex, currRo, true).Location;
                }
                SetGridValueToTextBox(currRo);
            }

            if (this.Tag == "NEW")
            {
                TxtGridWaiter.Enabled = mode;
                TxtGridWaiter.Visible = mode;

                TxtGridStartNo.Visible = mode;
                TxtGridEndNo.Visible = mode;

                TxtGridUsedNo.Visible = false;
                if (mode == true)
                    TxtGridWaiter.Focus();
            }
            else if (this.Tag == "KOTCLOSE")
            {
                TxtGridWaiter.Enabled = false;
                TxtGridWaiter.Visible = true;
                TxtGridStartNo.Visible = true;
                TxtGridEndNo.Visible = true;

                TxtGridWaiter.Enabled = false;
                TxtGridStartNo.Enabled = false;
                TxtGridEndNo.Enabled = false ;
                TxtGridUsedNo.Visible = mode;
                if (mode == true)
                    TxtGridUsedNo.Focus();
            }
            else
            {
                TxtGridUsedNo.Visible = false;
                TxtGridWaiter.Enabled = false;
                TxtGridWaiter.Visible = false;

                TxtGridStartNo.Visible = false;
                TxtGridEndNo.Visible = false;
                if (mode == true)
                    TxtGridWaiter.Focus();
            }
            //if (mode == true)
            //    BtnOk.Enabled = false;
            //else
            //    BtnOk.Enabled = true;

           
        }

        private bool SetTextBoxValueToGrid()
        {
            if (string.IsNullOrEmpty(TxtGridWaiter.Text))
            {
                TxtGridWaiter.Focus();
                return false;
            }
            else
            {
                DataGridViewRow ro = new DataGridViewRow();
                ro = Grid.Rows[Grid.CurrentRow.Index];
                ro.Cells["SNo"].Value = Grid.CurrentRow.Index + 1;
                ro.Cells["Waiter"].Value = TxtGridWaiter.Text;
                ro.Cells["StartNo"].Value = TxtGridStartNo.Text;
                ro.Cells["EndNo"].Value = TxtGridEndNo.Text;
                ro.Cells["UsedNo"].Value = TxtGridUsedNo.Text;

                return true;
            }
            }
        private void SetGridValueToTextBox(int row)
        {
            TxtGridWaiter.Text = "";
            TxtGridStartNo.Text = "";
            TxtGridEndNo.Text = "";
            TxtGridUsedNo.Text = "";

            if (Grid["Waiter", row].Value != null)
            {
                TxtGridWaiter.Text = Grid["Waiter", row].Value.ToString();
                TxtGridStartNo.Text = Grid["StartNo", row].Value.ToString();
                TxtGridEndNo.Text = Grid["EndNo", row].Value.ToString();
                TxtGridUsedNo.Text = Grid["UsedNo", row].Value.ToString();
            }
        }
        private void FrmKOT_Load(object sender, EventArgs e)
        {
            ClearFld();
            ControlEnableDisable(false, true);
        }

        private void BtnKOTClose_Click(object sender, EventArgs e)
        {
            ClearFld();
            this.Tag = "KOTCLOSE";
            if (SetData() != null)
            {
                GridControlMode(true);
                TxtGridUsedNo.Focus();
            }
        }

        private void FrmKOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != Grid)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (TxtGridWaiter.Visible == true || TxtGridUsedNo.Visible == true)
                {
                    _GridControlMode = false;
                    GridControlMode(false);
                    _GridControlMode = true;
                    Grid.Focus();
                }
                else if (BtnCancel.Enabled == true)
                {
                   this.Tag = "";
                    BtnCancel.PerformClick();
                }
                else if (BtnCancel.Enabled == false)
                {
                    BtnExit.PerformClick();
                }

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void Grid_Leave(object sender, EventArgs e)
        {
            BtnOk.Enabled = true;
           // BtnOk.Focus();
        }
        private DataTable  SetData()
        {
            DataTable dt = _objKOt.GetDataKOTAssign(Convert.ToDateTime(TxtDate.Text));
            foreach (DataRow ro in dt.Rows)
            {
                Grid.Rows[Grid.Rows.Count - 1].Cells["Sno"].Value = ro["Sno"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["KOTId"].Value = ro["KOTId"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["Waiter"].Value = ro["Waiter"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["StartNo"].Value = ro["StartNo"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["EndNo"].Value = ro["EndNo"].ToString();
                Grid.Rows[Grid.Rows.Count - 1].Cells["UsedNo"].Value = ro["UsedNo"].ToString();
                Grid.Rows.Add();
            }
                return (dt.Rows.Count > 0) ? dt : null;
        }
    }
}
