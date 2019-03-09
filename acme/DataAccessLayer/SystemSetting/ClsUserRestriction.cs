using DataAccessLayer.Interface.SystemSetting;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.SystemSetting
{
    public class ClsUserRestriction : IUserRestriction
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public List<UserRestrictionViewModel> Model { get; set; }

        public ClsUserRestriction()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new List<UserRestrictionViewModel>();
        }

        public string SaveUserRestriction(string usercode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("DELETE FROM [MyMaster].[dbo].[UserRestriction] WHERE UserCode = '" + usercode + "' \n");

            foreach (UserRestrictionViewModel det in Model)
            {
                strSql.Append("INSERT INTO [MyMaster].[dbo].[UserRestriction]([UserCode],[IniTial],[AccessSalesRateChange],[AccessSalesTermChange],[AccessPurchaseRateChange],[AccessPurchaseTermChange]) \n");
                strSql.Append("Select '" + det.UserCode.Trim() + "','" + det.IniTial.Trim() + "','" + det.AccessSalesRateChange + "','" + det.AccessSalesTermChange + "','" + det.AccessPurchaseRateChange + "','" + det.AccessPurchaseTermChange + "' \n");
            }
            Model.Clear();
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25);
            p[0].Direction = ParameterDirection.Output;
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }

        public DataTable GetUserRestriction(string UserCode, string IniTial)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM MyMaster.DBO.UserRestriction WHERE 1=1 ");
            if (string.IsNullOrEmpty(UserCode))
            {
                strSql.Append(" AND UserCode = '" + UserCode + "'");
            }

            if (string.IsNullOrEmpty(IniTial))
            {
                strSql.Append(" AND IniTial = '" + IniTial + "'");
            }

            strSql.Append(" ORDER BY IniTial");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable GetCompanyName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from MyMaster.dbo.CompanyMaster ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable GetUserCompany(string Usercode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  cm.IniTial, CompanyName,isnull(AccessSalesRateChange,0) as AccessSalesRateChange ,isnull(AccessSalesTermChange,0) as AccessSalesTermChange,isnull(AccessPurchaseRateChange,0) as AccessPurchaseRateChange,isnull(AccessPurchaseTermChange,0) as AccessPurchaseTermChange  from MyMaster.dbo.CompanyMaster cm inner join  MyMaster.dbo.UserRestriction ur on cm.IniTial=ur.IniTial where CM.IniTial in (select CompanyInitial from MyMaster.dbo.CompanyRights)  ");
            if (Usercode != "")
            {
                strSql.Append("  And UserCode='" + Usercode + "'");
            }

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }

    public class UserRestrictionViewModel
    {
        public string Tag { get; set; }
        public string UserCode { get; set; }
        public string IniTial { get; set; }
        public int AccessSalesRateChange { get; set; }
        public int AccessSalesTermChange { get; set; }
        public int AccessPurchaseRateChange { get; set; }
        public int AccessPurchaseTermChange { get; set; }
    }
}
