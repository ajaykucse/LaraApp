using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.SystemSetting.ClsDocPrintSetting;

namespace DataAccessLayer.Interface.SystemSetting
{
    public interface IDocPrintSetting
    {
        List<PrintSettingModel> PrintSettingList { get; set; }
        List<MapUserPrintSetting> PrintSettingUserMapList { get; set; }
        List<MapBranchPrintSetting> PrintSettingBranchMapList { get; set; }
        DataTable PrintDesignList(string ModuleName);
        DataTable GetPrintDesignList(string ModuleName, string DesignType);
        void UpdatePrintStatus(string VoucherNo, string PrintedBy, DateTime PrintedDate);
        DataSet SalesInvoiceDataSet(string VoucherNo);
        DataSet SalesOrderDataSet(string VoucherNo);
        int CheckIsSaveAndPrint(string ModuleName);
        void SavePrintSetting(string Tag);
        void DeletePrintSetting(int DesignId);
        int CheckExitingDesign(string ModuleName, string DesignName);
        string GetOrginalDllDesignName(int DesinId);
        void SaveUserPrintSettingMap(int PrintDesignId);
        void SaveBranchPrintSettingMap(int PrintDesignId);
        DataTable GetUserPrintSettingMap(int PrintDesignId);
        DataTable GetBranchPrintSettingMap(int PrintDesignId);
    }
}
