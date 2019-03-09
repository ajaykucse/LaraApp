using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface ISalesman
    {
        SalesmanViewModel Model { get; set; }
        MemberTypeViewModel MemberTypeModel { get; set; }
        string SaveSalesman();
        string SaveLedger();
        string SaveMemberType();
        DataTable GetDataSalesman(int SalesmanId);
        DataTable GetDataMemberType(int MemberTypeId);
        DataTable GetDataMember(int SalesmanId);
        void GetSingleSalesman(string SalesmanDesc);
    }
}
