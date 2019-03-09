using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SystemSetting
{
    public class ClsMenuPermissionGroup
    {
        ActiveDataAccess.ActiveDataAccess DAL;
      
        public List<MenuPermissionGroupViewModel> Model { get; set; }    


        public ClsMenuPermissionGroup()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);          
            Model = new List<MenuPermissionGroupViewModel>();            
        }

        public void SaveMenuPermission(string Group)  
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM MyMaster.dbo.MenuPremissionGroup where PremissionGroupName='" + Group + "'  \n");
          
            foreach (MenuPermissionGroupViewModel det in this.Model)
            {
                strSql.Append("INSERT INTO MyMaster.dbo.MenuPremissionGroup ([MainForm],[FormName],[DisplayName],[Odr],[Access],[MenuId],[Module],[PageUrl],[PageId],[PremissionGroupName]) \n");
                strSql.Append("Select '" + det.MainForm + "','" + det.FormName + "','" + det.DisplayName + "','" + det.Odr + "','" + det.Access + "','" + det.MenuId + "', '" + det.Module + "',NULL,NULL,'" + det.PremissionGroupName + "' \n");                
            }
            DAL.ExecuteNonQuery(System.Data.CommandType.Text, strSql.ToString());
        }

        public DataTable GetMenuPermissionByName(string PremissionGroupName)
        {
            return DAL.ExecuteDataset(CommandType.Text, "select * from  MyMaster.dbo.MenuPremissionGroup  where PremissionGroupName='"+ PremissionGroupName.Trim() + "'").Tables[0];
        }

        public int CheckDuplicate(string PremissionGroupName,string Tag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PremissionGroupName from  MyMaster.dbo.MenuPremissionGroup  where PremissionGroupName='" + PremissionGroupName.Trim() + "' \n");
            if(Tag!="NEW")
                strSql.Append("and PremissionGroupName!='" + PremissionGroupName.Trim() + "' \n");
            DataTable dt= DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return dt.Rows.Count;
        }
    }

    public class MenuPermissionGroupViewModel
    {
        public string Tag { get; set; }
        public int ID { get; set; }
        public string MainForm { get; set; }
        public string FormName { get; set; }
        public string DisplayName { get; set; }
        public int Odr { get; set; }
        public int Access { get; set; }
        public string MenuId { get; set; }
        public string Module { get; set; }
        public string PageUrl { get; set; }
        public string PageId { get; set; }
        public string PremissionGroupName { get; set; }

    }


}
