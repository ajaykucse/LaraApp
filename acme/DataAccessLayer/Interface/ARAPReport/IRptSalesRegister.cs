using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.ARAPReport
{
    public interface IRptSalesRegister
    {
        //DataSet SalesRegisterSummary(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        //DataSet SalesRegisterDetails(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        DataSet SalesRegisterSummaryDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        DataSet SalesRegisterDetailsHorizontalDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        DataSet SalesRegisterDetailsVerticleDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        DataSet SalesRegisterDetailsProductHorizontalBillVerticleDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        //--------
        DataSet SalesOrderRegisterSummaryDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        DataSet SalesOrderRegisterDetailsHorizontalDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
        DataSet SalesOrderRegisterDetailsVerticleDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId);
    }
}