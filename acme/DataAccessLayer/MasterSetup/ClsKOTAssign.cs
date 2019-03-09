using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.MasterSetup;

namespace DataAccessLayer.MasterSetup
{
    public class ClsKOTAssign : IKOTAssign
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public KOTViewModel Model { get; set; }
        public List<KOTAssignViewModel> ModelKOTAssign { get; set; }
        public ClsKOTAssign()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new KOTViewModel();
            ModelKOTAssign = new List<KOTAssignViewModel>();
            
        }

        public string SaveKOTAssign()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @KOTId int=(select ISNULL((Select Top 1 max(cast(KOTId as int))  from ERP.KOTAssign),0)+1) \n");
                foreach (KOTAssignViewModel det in ModelKOTAssign)
                {
                    strSql.Append("Insert into ERP.KOTAssign(KOTId, Sno, StartNo, EndNo, Waiter, KOTDate, KOTMiti, UsedNo, BranchId, CompanyUnitId, CounterId, Gadget,Status,EnterBy,EnterDate) \n");
                    strSql.Append("select @KOTId,'" + det.Sno + "','" + det.StartNo + "','" + det.EndNo + "',N'" + det.Waiter.Trim().Replace("'", "''") + "','" + det.KOTDate.ToString("yyyy-MM-dd") + "','" + det.KOTMiti.Trim() + "'," + ((det.UsedNo == 0) ? "null" : "'" + det.UsedNo + "'") + ", " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + "," + ((Model.CounterId == 0) ? "null" : "'" + Model.CounterId + "'") + ",'" + Model.Gadget + "','" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "',GETDATE() \n");
                }
                strSql.Append("SET @VNo =@KOTId");
                
            }
            else if (Model.Tag == "KOTCLOSE")
            {
                foreach (KOTAssignViewModel det in ModelKOTAssign)
                {
                    strSql.Append("Update ERP.KOTAssign set  UsedNo='"+ det.UsedNo +"' Where sno='"+det.Sno+"' and KOTId='"+ det.KOTId+"' \n");
                    strSql.Append("SET @VNo ='" + det.KOTId + "'");
                }
            }
            //else if (Model.Tag == "DELETE")
            //{
            //    strSql.Append("DELETE FROM ERP.Counter WHERE KOTId = '" + Model.KOTId + "' \n");
            //    strSql.Append("SET @VNo ='1'");
            //}
            ModelKOTAssign.Clear();
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
        public DataTable GetDataKOTAssign(DateTime KOTDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ERP.KOTAssign where KOTDate='"+ KOTDate.ToString("yyyy-MM-dd") + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

    }
    public class KOTViewModel
    {
        public string Tag { get; set; }
       
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
        public int CounterId { get; set; }
        public string Gadget { get; set; }
    }

        public class KOTAssignViewModel
        {
        public int KOTId { get; set; }
        public string Waiter { get; set; }
            public int Sno { get; set; }
            public int StartNo { get; set; }
            public int EndNo { get; set; }
            public int UsedNo { get; set; }
           
            public DateTime KOTDate { get; set; }
            public string KOTMiti { get; set; }
         }
    }
