using acmedesktop.MyInputControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.Inventory
{
    public partial class FrmPhysicalStock : Form
    {
        private MyGridPickListTextBox TxtGridProductList;
        private MyGridPickListTextBox TxtGridGodown;
        private MyGridComboBox TxtAdjType;
        private MyGridNumericTextBox TxtGridAltQty;
        private MyGridTextBox TxtGridAltUnit;
        private MyGridNumericTextBox TxtGridQty;
        private MyGridTextBox TxtGridQtyUnit;
        private MyGridTextBox TxtGridDiffQty;
        private MyGridNumericTextBox TxtGridRate;
        private MyGridNumericTextBox TxtGridAmount;
        private MyGridNumericTextBox TxtGridFreeQty;

        public FrmPhysicalStock()
        {
            InitializeComponent();
        }

        private void FrmPhysicalStock_Load(object sender, EventArgs e)
        {

        }
    }
}
