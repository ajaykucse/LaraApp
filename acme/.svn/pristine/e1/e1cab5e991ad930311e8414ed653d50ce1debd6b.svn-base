using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.Common
{
    public interface IUserMaster
    {
        UserMasterViewModel Model { get; set; }
        List<CompanyRightList> CompanyList { get; set; }
        string SaveUserMaster();
        DataTable CheckUser(string username, string pass);
        DataTable GetUserList();
        DataTable GetDataUser(string UserId);
        DataTable UserListForRights();
        int CheckOldPassword(string password);
        int CheckDuplicateUserCode(string UserCode);
        int CheckDuplicateUserName(string UserName);
        int CheckDuplicateMobileNo(string mobileno);
        int CheckDuplicateEmail(string EmailId);
        DataTable CompanyListForUserRights(string UserCode);
        void SaveCompanyRights(string UserCode);
        DataTable BranchListForUserRights(string UserCode, string Initial);
        void SaveBranchRights(string UserCode, string Initial);
        DataTable CompanyUnitListForUserRights(string UserCode, string Initial);
        void SaveCompanyUnitRights(string UserCode, string Initial);
    }
}
