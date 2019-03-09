using DataAccessLayer.Interface.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public class ClsDateMiti : IDateMiti
    {
        public DateTime MDate { get; set; }
        public string MMiti { get; set; }
        public string MonthName { get; set; }
        public string Days { get; set; }

        ActiveDataAccess.ActiveDataAccess DAL;

        public ClsDateMiti()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
        }

        public DataTable Get(DateTime? date = null, string miti = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ERP.DateMiti Where 1= 1 \n");
            if (date != null)
            {
                strSql.Append("and MDate = '" + Convert.ToDateTime(date).ToString("MM/dd/yyyy") + "'");
            }

            if (!string.IsNullOrEmpty(miti))
            {
                strSql.Append("and MMiti = '" + miti + "'");
            }
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DateTime? GetDate(string miti)
        {
            DataTable dt = Get(null, miti);
            if (dt.Rows.Count > 0)
                return Convert.ToDateTime(dt.Rows[0]["Mdate"]);
            else
                return null;
        }

        public DateTime GetDate1(string miti)
        {
            DateTime? dttime = GetDate(miti);
            if (dttime != null)
                return Convert.ToDateTime(dttime);
            else
                return new DateTime();
        }

        public string GetMiti(DateTime date)
        {
            DataTable dt = Get(date, "");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["MMiti"].ToString();
            else
                return "";
        }

        public DateTime GetServerDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select convert(varchar(10),GETDATE(),103) as ServerDate");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return Convert.ToDateTime(dt.Rows[0]["ServerDate"].ToString());
        }

        public DateTime GetServerDateTime()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select getDate() As ServerDateTime");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return Convert.ToDateTime(dt.Rows[0]["ServerDateTime"].ToString());
        }

        public string DateFormateymd(string date)
        {
            string[] s = date.Split('/');
            return s[2] + '-' + s[1] + '-' + s[0];
        }
        
    }
}