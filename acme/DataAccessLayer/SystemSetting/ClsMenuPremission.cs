using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SystemSetting
{
    public class ClsMenuPremission
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public MenuPremissionViewModel Model { get; set; }

        public ClsMenuPremission()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new MenuPremissionViewModel();
        }
    }

    public class MenuPremissionViewModel
    {
        public int ID { get; set; }
        public string UserCode { get; set; }
        public string FormName { get; set; }
        public string DisplayName { get; set; }
        public int Odr { get; set; }
        public int Access { get; set; }
        public string MenuId { get; set; }
        public string Module { get; set; }
        public string PageUrl { get; set; }
        public string PageId { get; set; }
        public string CompanyIniTial { get; set; }
    }
}
