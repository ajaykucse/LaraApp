using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.Common
{
    public static class ClsPrinterList
    {
        public static void GetPrinterList(ComboBox cb)
        {
            PrinterSettings setting = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                setting.PrinterName = printer;
                if (setting.IsDefaultPrinter)
                {
                    cb.Items.Add(printer);
                }
            }
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                setting.PrinterName = printer;
                if (!setting.IsDefaultPrinter)
                {
                    cb.Items.Add(printer);
                }
            }
            cb.SelectedIndex = 0;
        }
    }
}
