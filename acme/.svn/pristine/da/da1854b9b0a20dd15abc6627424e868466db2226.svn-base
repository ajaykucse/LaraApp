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
    public class ClsAccountGroup : IAccountGroup
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public AccountGroupViewModel Model { get; set; }
        public ClsAccountGroup()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new AccountGroupViewModel();
        }
        public string SaveAccountGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @AccountGrpId int=(select ISNULL((Select Top 1 max(cast(AccountGrpId as int))  from ERP.AccountGroup),0)+1) \n");
                strSql.Append("Insert into ERP.AccountGroup(AccountGrpId, AccountGrpDesc, AccountGrpShortName, Schedule, PrimaryGrp, GrpType, [Status], EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @AccountGrpId,N'" + Model.AccountGrpDesc.Trim().Replace("'", "''") + "',N'" + Model.AccountGrpShortName.Trim().Replace("'", "''") + "','" + Model.Schedule + "','" + Model.PrimaryGrp.Trim() + "','" + Model.GrpType.Trim() + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),'" + Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@AccountGrpId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.AccountGroup SET AccountGrpDesc=N'" + Model.AccountGrpDesc.Trim().Replace("'", "''") + "',AccountGrpShortName = N'" + Model.AccountGrpShortName.Trim().Replace("'", "''") + "',Schedule = '" + Model.Schedule + "',PrimaryGrp = '" + Model.PrimaryGrp.Trim() + "',GrpType = '" + Model.GrpType.Trim() + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='" + Model.Gadget + "' WHERE AccountGrpId = '" + Model.AccountGrpId + "' \n");
                strSql.Append("SET @VNo ='" + Model.AccountGrpId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.AccountGroup WHERE AccountGrpId = '" + Model.AccountGrpId + "' \n");
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
        public string GetSchedule()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL((Select Top 1 max(cast(Schedule as int))  from ERP.AccountGroup),0)+1 As Schedule \n");
            // DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return dt.Rows[0]["Schedule"].ToString();
        }
        public DataTable GetDataAccountGroup(int AccountGrpId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccountGrpId,AccountGrpDesc,AccountGrpShortName,Schedule,GrpType,PrimaryGrp,[Status],EnterBy,EnterDate,Gadget from ERP.AccountGroup");
            if (AccountGrpId != 0)
                strSql.Append(" WHERE AccountGrpId='" + AccountGrpId + "' ");
            strSql.Append(" ORDER BY AccountGrpDesc");

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public List<AccountGroupViewModel> GetDataAccountGroupList(int AccountGrpId, string Tag = "ALL")
        {
            List<AccountGroupViewModel> _List = new List<AccountGroupViewModel>();
            DataTable dt = new DataTable();
            if (Tag != "NEW")
                dt = GetDataAccountGroup(AccountGrpId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _List.Add(new AccountGroupViewModel
                    {
                        Tag = Tag,
                        AccountGrpId = Convert.ToInt32(dr["AccountGrpId"].ToString()),
                        AccountGrpDesc = (dr["AccountGrpDesc"].ToString()),
                        AccountGrpShortName = dr["AccountGrpShortName"].ToString(),
                        Schedule = Convert.ToInt32(dr["Schedule"].ToString()),
                        GrpType = dr["GrpType"].ToString(),
                        PrimaryGrp = dr["PrimaryGrp"].ToString(),
                        Status = Convert.ToBoolean(dr["Status"].ToString()),
                        EnterBy = dr["EnterBy"].ToString(),
                        EnterDate = Convert.ToDateTime(dr["EnterDate"].ToString()),
                        Gadget = dr["Gadget"].ToString(),
                    });
                }
                return _List;
            }
            else
            {
                _List.Add(new AccountGroupViewModel
                {
                    Tag = Tag,
                    AccountGrpId = AccountGrpId,
                    AccountGrpDesc = string.Empty,
                    AccountGrpShortName = string.Empty,
                    Schedule = Convert.ToInt32(GetSchedule()),
                    GrpType = string.Empty,
                    PrimaryGrp = string.Empty,
                    Status = false,
                    EnterBy = string.Empty,
                    EnterDate = null,
                    Gadget = string.Empty,
                });
                return _List;
            }
        }
    }

    public class AccountGroupViewModel
    {
        public string Tag { get; set; }
        public int AccountGrpId { get; set; }
        public string AccountGrpDesc { get; set; }
        public string AccountGrpShortName { get; set; }
        public int Schedule { get; set; }
        public string PrimaryGrp { get; set; }
        public string GrpType { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public Nullable<DateTime> EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
