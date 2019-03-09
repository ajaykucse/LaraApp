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
	public partial class FrmSoftwareFocus : Form
	{
		DataAccessLayer.SystemSetting.ClsCompany _company = new DataAccessLayer.SystemSetting.ClsCompany();
		public FrmSoftwareFocus()
		{
			InitializeComponent();
			ListSoftware();
		}

		private void ListSoftware()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("Software Id");
			dt.Columns.Add("Software");
			dt.Rows.Add("001", "POS");
			dt.Rows.Add("002", "Restaurant");
			dt.Rows.Add("003", "Standard");
			Grid.DataSource = dt;
			Grid.Columns["Software Id"].Width = 100;
			Grid.Columns["Software"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void SoftwareFocusSelect()
		{
			if (Grid.Rows.Count > 0)
			{
				ClsGlobal.SoftwareFocus = Grid.Rows[Grid.CurrentRow.Index].Cells["Software"].Value.ToString();
				_company.UpdateSoftwareFocus(ClsGlobal.SoftwareFocus);
				this.Close();
			}
		}
		
		private void BtnOk_Click(object sender, EventArgs e)
		{
			SoftwareFocusSelect();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Grid_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				SoftwareFocusSelect();
			}
		}

		private void FrmSoftwareFocus_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Application.Exit();
			}
		}
	}
}
