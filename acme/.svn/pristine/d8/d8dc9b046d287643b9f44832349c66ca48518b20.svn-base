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

namespace acmedesktop.SystemSetting
{
    public partial class FrmDocumentReNumbering : Form
    {
        public FrmDocumentReNumbering()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClose == 1)
            {
                var dialogResult = MessageBox.Show("Are you sure want to Close Form..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                Close();
            }
        }
    }
}
