using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IAccountGroup
    {
        AccountGroupViewModel Model { get; set; }
        string SaveAccountGroup();
        string GetSchedule();
        DataTable GetDataAccountGroup(int AccountGrpId);
        List<AccountGroupViewModel> GetDataAccountGroupList(int AccountGrpId,string Tag="ALL");
    }
}
