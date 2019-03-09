using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface ISalesBillingTerm
    {
        DataAccessLayer.MasterSetup.SalesBillingTermViewModel Model { get; set; }
        string SaveSalesBillingTerm();
        DataTable GetDataSalesBillingTerm(int TermId);
        DataTable GetProductTerm();
        DataTable GetBillTerm();
        string CheckTermExists(int BranchId, string ISBillwise);
        DataTable GetTermListForTermCalculation(string Module, int BranchId, int ProductId);
    }
}
