using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.Sales
{
    public partial class ConversionQty : Form
    {
        public string _ConversionQty = "0";
        public ConversionQty(string ConversionQty)
        {
            InitializeComponent();
            _ConversionQty = ConversionQty;
        }

        private void ConversionQty_Load(object sender, EventArgs e)
        {
            TxtConversionQty.Text = _ConversionQty;
        }

        private void ConversionQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk.PerformClick();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtConversionQty.Text))
            {
                _ConversionQty = TxtConversionQty.Text;
                this.Close();
            }
        }
    }
}
