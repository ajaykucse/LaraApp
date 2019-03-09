using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.FinanceReport
{
    public interface IRptAllLedger
    {
        DataSet AllLedgerSummaryLedgerWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId,string _LedgerId);
        DataSet AllLedgerDetailsLedgerWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId,bool isNarrationShow, string _LedgerId);
        DataSet DayBookDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId, bool isNarrationShow);
    }
}
