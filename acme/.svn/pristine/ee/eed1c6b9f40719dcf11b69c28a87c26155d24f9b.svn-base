using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IUdfMaster
    {
        UdfMasterViewModel Model { get; set; }
        List<UDFDetailsEntryViewModel> ModelUDFDetailsEntry { get; set; }
        DataSet GetDataUDFMaster(int UDFCode);
        string SaveUdfMaster();
        int CheckDuplicatePosition(string Position, string EntryModule);
        //--------------------
        DataSet Get(string UDFCode = "", string FieldName = "");
        void GetSingle(string UDFCode = "");
        DataTable GetByEntryModule(string UDFEntryModule);
        DataTable GetCodeByEntryModule(string UDFEntryModule);
        DataTable GetByFieldName(string fieldName, string UDFEntryModule);
        int CheckDuplicateRecord(string FieldName, string EntryModule);
        int CheckDuplicateSchedule(string Schedule, string EntryModule);
        string GetId(string UDF_Desc, string EntryModule);
        int Delete(string UDFCode);
        int CheckUDFExists(string EntryModule);
        DataTable GetUDF(string UDFType, string VoucherNo);
        DataTable GetUDFDataByCode(string UDFType, string UDFCode);
        //-----------------------
    }
}
