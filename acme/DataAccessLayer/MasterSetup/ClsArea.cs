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
    public class ClsArea : IArea
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public AreaViewModel Model { get; set; }
        public ClsArea()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new AreaViewModel();
        }
        public string SaveArea()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @AreaId int=(select ISNULL((Select Top 1 max(cast(AreaId as int))  from ERP.Area),0)+1) \n");
                strSql.Append("Insert into ERP.Area([AreaId],[AreaDesc],[AreaShortName],[Country],[Location],[MainAreaId],[Status],[EnterBy],[EnterDate],Gadget) \n");
                strSql.Append("select @AreaId,N'" + Model.AreaDesc.Trim().Replace("'", "''") + "',N'" + Model.AreaShortName.Trim().Replace("'", "''") + "',N'" + Model.Country.Trim().Replace("'", "''") + "',N'" + Model.Location.Trim().Replace("'", "''") + "'," + ((Model.MainAreaId == 0) ? "null" : "'" + Model.MainAreaId + "'") + ",'" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),'"+Model.Gadget+"' \n");
                strSql.Append("SET @VNo =@AreaId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Area SET AreaDesc=N'" + Model.AreaDesc.Trim().Replace("'", "''") + "',AreaShortName = N'" + Model.AreaShortName.Trim().Replace("'", "''") + "',Country = N'" + Model.Country.Trim().Replace("'", "''") + "',Location = N'" + Model.Location.Trim().Replace("'", "''") + "',MainAreaId = " + ((Model.MainAreaId == 0) ? "null" : "'" + Model.MainAreaId + "'") + ",[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='"+Model.Gadget+"'  WHERE AreaId = '" + Model.AreaId + "' \n");
                strSql.Append("SET @VNo ='" + Model.AreaId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Area WHERE AreaId = '" + Model.AreaId + "' \n");
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

        public DataTable GetDataArea(int AreaId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.Area.*,MainAreaDesc from  ERP.Area LEFT OUTER JOIN ERP.MainArea ON ERP.MainArea.MainAreaId=ERP.Area.MainAreaId  ");
            if (AreaId != 0)
                strSql.Append("  WHERE AreaId='" + AreaId + "' ");           
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
    public class AreaViewModel
    {
        public string Tag { get; set; }
        public int AreaId { get; set; }
        public string AreaDesc { get; set; }
        public string AreaShortName { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public int MainAreaId { get; set; }
        public string MainAreaDesc { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }
}
