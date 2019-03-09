using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.SystemSetting
{
    public interface IUserRestriction
    {
        List<UserRestrictionViewModel> Model { get; set; }
        string SaveUserRestriction(string usercode);
        DataTable GetUserRestriction(string UserCode, string IniTial);
        DataTable GetUserCompany(string Usercode);
    }
}
