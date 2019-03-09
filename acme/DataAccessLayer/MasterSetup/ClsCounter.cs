using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Interface.MasterSetup;

namespace DataAccessLayer.MasterSetup
{    
    public class ClsCounter : ICounter
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public CounterViewModel Model { get; set; }
        public ClsCounter()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CounterViewModel();
        }
        public string SaveCounter()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @CounterId int=(select ISNULL((Select Top 1 max(cast(CounterId as int))  from ERP.Counter),0)+1) \n");
                strSql.Append("Insert into ERP.Counter(CounterId, CounterDesc, CounterShortName, GodownId,PrinterName, Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @CounterId,N'" + Model.CounterDesc.Trim().Replace("'", "''") + "',N'" + Model.CounterShortName.Trim().Replace("'", "''") + "'," + ((Model.GodownId == 0) ? "null" : "'" + Model.GodownId + "'") + ",N'" + Model.PrinterName.Trim().Replace("'", "''") + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),Gadget='"+Model.Gadget+"' \n");
                strSql.Append("SET @VNo =@CounterId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Counter SET CounterDesc=N'" + Model.CounterDesc.Trim().Replace("'", "''") + "',CounterShortName = N'" + Model.CounterShortName.Trim().Replace("'", "''") + "',GodownId=" + ((Model.GodownId == 0) ? "null" : "'" + Model.GodownId + "'") + ",PrinterName = N'" + Model.PrinterName.Trim().Replace("'", "''") + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='"+ Model.Gadget + "'  WHERE CounterId = '" + Model.CounterId + "' \n");
                strSql.Append("SET @VNo ='" + Model.CounterId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Counter WHERE CounterId = '" + Model.CounterId + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25)
            {
                Direction = ParameterDirection.Output
            };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }
        public DataTable GetDataCounter(int CounterId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select ERP.Counter.*,GodownDesc from ERP.Counter left join ERP.Godown on ERP.Counter.GodownId=ERP.Godown.GodownId ");
            if (CounterId != 0)
                strSql.Append("  WHERE CounterId='" + CounterId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];

        }
        public DataTable GetDataCounterList()
        {
            return DAL.ExecuteDataset(CommandType.Text, "select CounterId, CounterDesc as Description, CounterShortName as ShortName from ERP.Counter order by CounterDesc ").Tables[0];
        }

    }

    public class CounterViewModel
    {
        public string Tag { get; set; }
        public int CounterId { get; set; }
        public string CounterDesc { get; set; }
        public string CounterShortName { get; set; }
        public int GodownId { get; set; }
        public string PrinterName { get; set; }       
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }

    }
}
