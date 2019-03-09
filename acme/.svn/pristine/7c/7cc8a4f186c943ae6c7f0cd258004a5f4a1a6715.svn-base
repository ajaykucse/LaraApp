using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
  public  interface ITableMaster
    {
        TableViewModel Model { get; set; }
        string SaveTable();
        DataTable GetDataTable(int TableId);
        DataTable GetSplitTable();
        DataTable GetTransferTable();
        DataTable GetMergeTable(int TableId);
    }
}
