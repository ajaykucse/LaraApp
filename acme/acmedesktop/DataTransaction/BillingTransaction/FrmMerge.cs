using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.BillingTransaction
{
    public partial class FrmMerge : Form
    {
        string _TableId = "",_TableDesc="";
        ITableMaster _objTable = new ClsTable();
        public String MergeTableId = "", MergerTableDesc = "" , clickButton="";
        public FrmMerge(string TableId, string TableDesc, string FormName)
        {
            InitializeComponent();
            _TableId = TableId;
            _TableDesc = TableDesc;
            this.Text  = FormName;
        }
        private void BindTableList(DataTable dtTable)
        {
            int x = 5;
            int y = 7;
            List<Button> buttons = new List<Button>();
            DataTable dtTableList = dtTable;
            int i = 1; int j = 6;
            foreach (DataRow item in dtTableList.Rows)
            {
                if (i == 1)
                {
                    x = 5;
                }
                else if (i == j)
                {
                    x = 5; y = y + 40; j = j + 5;
                }
                else
                {
                    x = x + 72;
                }

                Button newButton = new Button();
                newButton.Location = new System.Drawing.Point(x, y);
                newButton.Size = new System.Drawing.Size(67, 35);
                newButton.TabIndex = 0;
                newButton.TabStop = false;
                newButton.CausesValidation = false;
                if (item["TableStatus"].ToString() == "O")
                {
                    newButton.BackColor = System.Drawing.Color.Brown;
                }
                else if (item["TableStatus"].ToString() == "A")
                {
                    newButton.BackColor = System.Drawing.Color.ForestGreen;
                }
                else if (item["TableStatus"].ToString() == "R")
                {
                    newButton.BackColor = System.Drawing.Color.MidnightBlue;
                }
                newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newButton.ForeColor = System.Drawing.Color.White;
                newButton.UseVisualStyleBackColor = false;
                newButton.Tag = item["TableStatus"].ToString();
                newButton.Name = "Table" + item["TableId"].ToString();
                newButton.Text = item["TableDesc"].ToString();
                newButton.Click += new EventHandler(OnTableButtonClick);
                buttons.Add(newButton);
                PnlTableList.Controls.Add(newButton);
                i++;
            }
        }

      
        private void FrmMerge_Load(object sender, EventArgs e)
        {
            if (this.Text == "Merge Table")
            {
                DataTable dt = _objTable.GetMergeTable(Convert.ToInt32(_TableId));
                BindTableList(dt);
            }
            else if (this.Text =="Transfer Table")
            {
                DataTable dt = _objTable.GetTransferTable();
                BindTableList(dt);
            }
        }

		private void FrmMerge_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
			else if (e.KeyCode == Keys.Escape)
			{
				if (BtnCancel.Enabled == true)
				{
					BtnCancel.PerformClick();
				}
				DialogResult = DialogResult.Cancel;
				return;
			}
		}

		private void OnTableButtonClick(object sender, EventArgs e)
        {
         
            Button btnTable = (Button)sender;
            TableFocusIndicate.Location = new System.Drawing.Point(btnTable.Location.X + 1, btnTable.Location.Y+30);
            TableFocusIndicate.Visible = true;
            TableFocusIndicate.BringToFront();
            lblMergInfo.ForeColor  = System.Drawing.Color.White;
            if (this.Text == "Merge Table")
                lblMergInfo.Text = "Table:" + btnTable.Text + " will Merge with Table:" + _TableDesc;
            else if (this.Text == "Transfer Table")
                lblMergInfo.Text = "Table:" + _TableDesc + " will Transfer to Table:" + btnTable.Text;

            MergeTableId = btnTable.Name.Substring(5, btnTable.Name.Length - 5);
            MergerTableDesc = btnTable.Text;
            btnOk.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            clickButton = "Cancel";
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var dialogResult = DialogResult;
            if (this.Text == "Merge Table")
            
                 dialogResult = MessageBox.Show("Are you sure want to Merge Table :" + MergerTableDesc + " with Table :"+_TableDesc+"..??", "Mr.Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            else if (this.Text == "Transfer Table")
                dialogResult = MessageBox.Show("Are you sure want to Transfer Table :" + _TableDesc + " to Table :" + MergerTableDesc + "..??", "Mr.Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                clickButton = "Conform";
            }
            else return;
            this.Close();
        }
    }
}
