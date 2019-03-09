using DataAccessLayer.Interface.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MasterSetup
{
    public class ClsFloor : IFloor
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public FloorViewModel Model { get; set; }
        public ClsFloor()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new FloorViewModel();
        }
        public string SaveFloor()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @FloorId int=(select ISNULL((Select Top 1 max(cast(FloorId as int))  from ERP.Floor),0)+1) \n");
                strSql.Append("insert into [ERP].[Floor] (FloorId, FloorDesc, FloorShortName, Status, EnterBy, EnterDate,Gadget)\n");
                strSql.Append("Select @FloorId,N'" + Model.FloorDesc.Trim().Replace("'", "''") + "',N'" + Model.FloorShortName.Trim().Replace("'", "''") + "' ,'"+Model.Status.ToString()+"','"+Model.EnterBy+ "',GETDATE(),'" + Model.Gadget + "'\n");            
                strSql.Append("SET @VNo =@FloorId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Floor SET FloorDesc=N'" + Model.FloorDesc.Trim().Replace("'", "''") + "',FloorShortName = N'" + Model.FloorShortName.Trim().Replace("'", "''") + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='" + Model.Gadget + "' WHERE FloorId = '" + Model.FloorId + "' \n");
                strSql.Append("SET @VNo ='" + Model.FloorId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Floor WHERE FloorId = '" + Model.FloorId + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
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
        public DataTable GetDataFloor(int FloorId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  ERP.Floor  ");
            if (FloorId != 0)
                strSql.Append("  WHERE FloorId='" + FloorId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

    }
    public class FloorViewModel
    {
        public string Tag { get; set; }
        public int FloorId { get; set; }
        public string FloorDesc { get; set; }
        public string FloorShortName { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }
}
