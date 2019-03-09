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

namespace acmedesktop.DataTransaction.Purchase
{
    public partial class FrmPurchaseExpBrkReturn : Form
    {
		private string _Tag = "", _dtBillTermExists = "", _dtProductTermExists = "", _VoucherNo = "", _SearchKey = "";

		private void BtnOk_Click(object sender, EventArgs e)
		{

		}

		private void FrmPurchaseExpBrkReturn_Load(object sender, EventArgs e)
		{

		}

		public FrmPurchaseExpBrkReturn()
        {
            InitializeComponent();
        }

		private void TxtMiti_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtMiti) return;
			ClsGlobal.MitiValidation(TxtMiti, TxtDate);
		}

		private void TxtDate_Validating(object sender, CancelEventArgs e)
		{
			if (_Tag == "" || ActiveControl == TxtDate) return;
			ClsGlobal.DateValidation(TxtDate, TxtMiti);
		}
	}
}
