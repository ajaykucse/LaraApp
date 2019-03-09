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
    public class ClsDepartment : IDepartment
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public DepartmentViewModel Model { get; set; }
        public ClsDepartment()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new DepartmentViewModel();
        }
        public string SaveDepartment()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @DepartmentId int=(select ISNULL((Select Top 1 max(cast(DepartmentId as int))  from ERP.Department),0)+1) \n");
                strSql.Append("Insert into ERP.Department(DepartmentId, DepartmentDesc, DepartmentShortName, DepartmentLevel, Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @DepartmentId,N'" + Model.DepartmentDesc.Trim().Replace("'", "''") + "',N'" + Model.DepartmentShortName.Trim().Replace("'", "''") + "',N'" + Model.DepartmentLevel.Trim().Replace("'", "''") + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),Gadget='"+ Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@DepartmentId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Department SET DepartmentDesc=N'" + Model.DepartmentDesc.Trim().Replace("'", "''") + "',DepartmentShortName = N'" + Model.DepartmentShortName.Trim().Replace("'", "''") + "',DepartmentLevel = N'" + Model.DepartmentLevel.Trim().Replace("'", "''") + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='" + Model.Gadget + "'  WHERE DepartmentId = '" + Model.DepartmentId + "' \n");
                strSql.Append("SET @VNo ='" + Model.DepartmentId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Department WHERE DepartmentId = '" + Model.DepartmentId + "' \n");
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
        public DataTable GetDataDepartment(int DepartmentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ERP.Department");
            if (DepartmentId != 0)
                strSql.Append(" WHERE DepartmentId='" + DepartmentId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable DepartmentLevel()
        {
            return DAL.ExecuteDataset(CommandType.Text, "Select distinct Departmentlevel from ERP.Department").Tables[0];
        }
    }

    public class DepartmentViewModel
    {
        public string Tag { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentDesc { get; set; }
        public string DepartmentShortName { get; set; }
        public string DepartmentLevel { get; set; }        
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }
}
