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
    public class ClsMainArea : IMainArea
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public MainAreaViewModel Model { get; set; }
        public ClsMainArea()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new MainAreaViewModel();
        }

        public string SaveMainArea()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @MainAreaId int=(select ISNULL((Select Top 1 max(cast(MainAreaId as int))  from ERP.MainArea),0)+1) \n");
                strSql.Append("Insert into ERP.MainArea(MainAreaId, MainAreaDesc, MainAreaShortName, Country, Location, Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("Select @MainAreaId,N'" + Model.MainAreaDesc.Trim().Replace("'", "''") + "',N'" + Model.MainAreaShortName.Trim().Replace("'", "''") + "', " + ((Model.Country  == "") ? "null" : "N'" + Model.Country + "'") + "," + ((Model.Location == "") ? "null" : "N'" + Model.Location.Trim().Replace ("'","''") + "'") + ", '" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "', GETDATE(),'"+ Model.Gadget + "' \n");

                strSql.Append("SET @VNo =@MainAreaId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.MainArea SET MainAreaDesc=N'" + Model.MainAreaDesc.Trim().Replace("'", "''") + "',MainAreaShortName = N'" + Model.MainAreaShortName.Trim().Replace("'", "''") + "', country=" + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",Location=" + "" + ((Model.Location  == "") ? "null" : "N'" + Model.Location .Trim().Replace("'", "''") + "'") + ",EnterBy= '" + Model.EnterBy + "',Gadget='"+ Model.Gadget + "' WHERE MainAreaId = '" + Model.MainAreaId + "' \n");
                strSql.Append("SET @VNo ='" + Model.MainAreaId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.MainArea WHERE MainAreaId = '" + Model.MainAreaId + "' \n");
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
        public DataTable GetDataMainArea(int MainAreaId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ERP.MainArea ");
            if (MainAreaId != 0)
                strSql.Append("  WHERE MainAreaId='" + MainAreaId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];            
        }
    }
    public class MainAreaViewModel
    {
        public string Tag { get; set; }
        public int MainAreaId { get; set; }
        public string MainAreaDesc { get; set; }
        public string MainAreaShortName { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
