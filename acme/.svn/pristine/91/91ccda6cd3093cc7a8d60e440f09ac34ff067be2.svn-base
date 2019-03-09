using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.Common
{
    public interface ICommon
    {
        string GenerateShortName(string Val, string Description, string ShortName, string TableName, string Category = "");
        int CheckDescriptionDuplicateRecord(string Desc, string TableName, string RetColumnName, string IdColumnName, int Id = 0);
        int CheckShortNameDuplicateRecord(string ShortName, string TableName, string RetColumnName, string IdColumnName, int Id = 0);
        int CheckUDFDuplicateRecord(string Desc, string EntryModule, int Id = 0);
        //DataTable Exists(string Control, string Source);
        string[] GetVoucherNo(string DocId, string Module, int BranchId, int CompanyUnitId);
        int CountVoucherNoByModule(string Module);
        DataTable ReadExcelFile(string path, string SheetName);
        void GridToExcel(System.Windows.Forms.DataGridView Grid, string SheetName);
        void DataTableToExcel(DataTable dataTable, string SheetName);
    }
}
