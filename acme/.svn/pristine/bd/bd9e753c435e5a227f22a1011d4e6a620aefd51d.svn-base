using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IPurchaseBillingTerm
    {
        DataAccessLayer.MasterSetup.PurchaseBillingTermViewModel Model { get; set; }
        string SavePurchaseBillingTerm();
        DataTable GetDataPurchaseBillingTerm(int TermId);
        DataTable GetProductTerm();
        string CheckTermExists(int BranchId, string ISBillwise);
    }
}
