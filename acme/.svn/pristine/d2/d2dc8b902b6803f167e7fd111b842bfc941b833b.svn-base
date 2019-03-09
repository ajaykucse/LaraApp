using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IGeneralLedger
    {
        DataAccessLayer.MasterSetup.LedgerViewModel Model { get; set; }
        List<DataAccessLayer.MasterSetup.LedgerBranchCompanyUnitModel> ModelLedgerBranchCompanyUnit { get; set; }
        List<DataAccessLayer.MasterSetup.LedgerMappingList> ModelLedgerMappingList { get; set; }
        string SaveGeneralLedger();
        string SaveUserMaster();
        DataTable GetDataGeneralLedger(int LedgerId);
        string CheckGlContainsSubledger(string LedgerDesc);
        void GetSingleLedger(string GlDesc, DateTime Date, int BranchId);
        string VatEntryLedger();
        DataTable GetCurrrentBalance(int LedgerId, DateTime date, int BranchId, int CompanyUnitId);
        //------------ START LEDGER MAPPING --------
        void SaveLedgerMapping(string Module);
        DataTable AccountGroupListForLedgerMapping(string AccountGrpId);
        DataTable AccountSubGroupListForLedgerMapping(string AccountSubGrpId);
        DataTable SalesManpListForLedgerMapping(string SalesmanId);
        DataTable AreaListForLedgerMapping(string AreaId);
        DataTable BranchListForLedgerMapping(string BranchId);
        DataTable CompanyUnitListForLedgerMapping(string CompanyUnitId);
        //------------ END LEDGER MAPPING --------
    }
}
