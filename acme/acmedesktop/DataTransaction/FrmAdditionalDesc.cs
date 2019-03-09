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

namespace acmedesktop.DataTransaction
{
    public partial class FrmAdditionalDesc : Form
    {
        string _ProductId = "";
        public string _AdditionalDesc = "";
        IProduct _objProeduct = new ClsProduct();
        public FrmAdditionalDesc(string ProductId, string AdditionalDesc)
        {
            InitializeComponent();
            if (AdditionalDesc == "<SPACE>")
            {
                TxtAdditionalDesc.Text = "";
                _AdditionalDesc = AdditionalDesc;
            }
            else
            {
                TxtAdditionalDesc.Text = AdditionalDesc;
            }
            _ProductId = ProductId;
        }

        private void FrmAdditionalDesc_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAdditionalDesc.Text.Trim()) && _AdditionalDesc != "<SPACE>")
                TxtAdditionalDesc.Text = _objProeduct.ProductAdditionalDesc(_ProductId);

            TxtAdditionalDesc.SelectionStart = TxtAdditionalDesc.Text.Length;
            TxtAdditionalDesc.DeselectAll();
        }

        private void FrmAdditionalDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOK.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (string.IsNullOrEmpty(TxtAdditionalDesc.Text.Trim().ToString()))
                    _AdditionalDesc = "<SPACE>";
                else
                    _AdditionalDesc = TxtAdditionalDesc.Text.Trim().ToString();
                this.Close();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAdditionalDesc.Text.Trim().ToString()))
                _AdditionalDesc = "<SPACE>";
            else
                _AdditionalDesc = TxtAdditionalDesc.Text.Trim().ToString();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAdditionalDesc.Text.Trim().ToString()))
                _AdditionalDesc = "<SPACE>";
            else
                _AdditionalDesc = TxtAdditionalDesc.Text.Trim().ToString();
            this.Close();
        }
    }
}
