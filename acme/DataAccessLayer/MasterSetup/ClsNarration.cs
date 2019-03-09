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
    public class ClsNarration : INarration
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public NarrationViewModel Model { get; set; }
        public ClsNarration()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new NarrationViewModel();
        }
        public string SaveNarration()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @NarrationId int=(select ISNULL((Select Top 1 max(cast(NarrationId as int))  from ERP.NarrationMaster),0)+1) \n");
                strSql.Append("Insert into ERP.NarrationMaster(NarrationId, NarrationDesc, NarrationType,Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @NarrationId,N'" + Model.NarrationDesc.Trim().Replace("'", "''") + "',N'" + Model.NarrationType.Trim().Replace("'", "''") + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),'"+ Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@NarrationId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.NarrationMaster SET NarrationDesc=N'" + Model.NarrationDesc.Trim().Replace("'", "''") + "',NarrationType = N'" + Model.NarrationType.Trim().Replace("'", "''") + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='"+ Model.Gadget + "'  WHERE NarrationId = '" + Model.NarrationId + "' \n");
                strSql.Append("SET @VNo ='" + Model.NarrationId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.NarrationMaster WHERE NarrationId = '" + Model.NarrationId + "' \n");
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
        public DataTable GetDataNarration(int NarrationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ERP.NarrationMaster ");
            if (NarrationId != 0)
                strSql.Append("  WHERE NarrationId='" + NarrationId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
    public class NarrationViewModel
    {
        public string Tag { get; set; }
        public int NarrationId { get; set; }
        public string NarrationDesc { get; set; }
        public string NarrationType { get; set; }       
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }
}
