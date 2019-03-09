using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IAccountSubGroup
    {
        AccountSubGroupViewModel Model { get; set; }
        string SaveAccountSubGroup();
        DataTable GetDataAccountSubGroup(int AccountSubGrpId);
        List<AccountSubGroupViewModel> GetDataAccountSubGroupList(int AccountSubGrpId, string Tag = "ALL");
    }
}
