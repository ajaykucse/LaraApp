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

namespace acmedesktop.Common
{
    public partial class FrmCounterList : Form
    {
        DataAccessLayer.Interface.MasterSetup.ICounter _objCounter = new DataAccessLayer.MasterSetup.ClsCounter();
        public FrmCounterList()
        {
            InitializeComponent();
            ListCounter();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            CounterSelect();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmCounterList_Load(object sender, EventArgs e)
        {
            ListCounter();
        }

        private void ListCounter()
        {
            DataTable dt = _objCounter.GetDataCounterList();
            Grid.DataSource = dt;
            Grid.Columns["CounterId"].Visible = false;
            Grid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grid.Columns["ShortName"].Width = 150;
        }
        private void CounterSelect()
        {
            if (Grid.Rows.Count > 0)
            {
                ClsGlobal.CounterId = Convert.ToInt32(Grid.Rows[Grid.CurrentRow.Index].Cells["CounterId"].Value.ToString());
                ClsGlobal.CounterDesc = Grid.Rows[Convert.ToInt32(Grid.CurrentRow.Index)].Cells["Description"].Value.ToString();
                this.Close();
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CounterSelect();
            }
        }
    }
}
