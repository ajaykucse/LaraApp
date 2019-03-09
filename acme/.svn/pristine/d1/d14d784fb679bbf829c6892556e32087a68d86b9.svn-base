using DataAccessLayer.Interface.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.MasterSetup
{
    public class ClsAccountSubGroup : IAccountSubGroup
    {
        private ActiveDataAccess.ActiveDataAccess DAL;
        public AccountSubGroupViewModel Model { get; set; }
        public ClsAccountSubGroup()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new AccountSubGroupViewModel();
        }

        public string SaveAccountSubGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @AccountSubGrpId int=(select ISNULL((Select Top 1 max(cast(AccountSubGrpId as int))  from ERP.AccountSubGroup),0)+1) \n");
                strSql.Append("Insert into ERP.AccountSubGroup(AccountSubGrpId,AccountSubGrpDesc,AccountSubGrpShortName,AccountGrpId,[Status],EnterBy,EnterDate,Gadget) \n");
                strSql.Append("select @AccountSubGrpId,N'" + Model.AccountSubGrpDesc.Trim().Replace("'", "''") + "',N'" + Model.AccountSubGrpShortName.Trim().Replace("'", "''") + "','" + Model.AccountGrpId + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),'"+ Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@AccountSubGrpId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.AccountSubGroup SET AccountSubGrpDesc=N'" + Model.AccountSubGrpDesc.Trim().Replace("'", "''") + "',AccountSubGrpShortName = N'" + Model.AccountSubGrpShortName.Trim().Replace("'", "''") + "',AccountGrpId = '" + Model.AccountGrpId + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='" + Model.Gadget + "'  WHERE AccountSubGrpId = '" + Model.AccountSubGrpId + "' \n");
                strSql.Append("SET @VNo ='" + Model.AccountSubGrpId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.AccountSubGroup WHERE AccountSubGrpId = '" + Model.AccountSubGrpId + "' \n");
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
        public DataTable GetDataAccountSubGroup(int AccountSubGrpId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ASG.*,AG.AccountGrpDesc from ERP.AccountSubGroup AS ASG INNER JOIN ERP.AccountGroup AS AG ON ASG.AccountGrpId=AG.AccountGrpId ");
            if (AccountSubGrpId != 0)
                strSql.Append("WHERE AccountSubGrpId = '" + AccountSubGrpId + "' ");
            strSql.Append("ORDER BY AccountSubGrpDesc ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public List<AccountSubGroupViewModel> GetDataAccountSubGroupList(int AccountSubGrpId, string Tag = "ALL")
        {
            List<AccountSubGroupViewModel> _List = new List<AccountSubGroupViewModel>();
            DataTable dt = new DataTable();
            if (Tag != "NEW")
                dt = GetDataAccountSubGroup(AccountSubGrpId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _List.Add(new AccountSubGroupViewModel
                    {
                        Tag = Tag,
                        AccountSubGrpId = Convert.ToInt32(dr["AccountSubGrpId"].ToString()),
                        AccountSubGrpDesc = (dr["AccountSubGrpDesc"].ToString()),
                        AccountSubGrpShortName = dr["AccountSubGrpShortName"].ToString(),
                        AccountGrpId = Convert.ToInt32(dr["AccountGrpId"].ToString()),
                        AccountGrpDesc = dr["AccountGrpDesc"].ToString(),
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
                _List.Add(new AccountSubGroupViewModel
                {
                    Tag = Tag,
                    AccountSubGrpId = AccountSubGrpId,
                    AccountSubGrpDesc = string.Empty,
                    AccountSubGrpShortName = string.Empty,
                    AccountGrpId=0,
                    AccountGrpDesc = string.Empty,
                    Status = false,
                    EnterBy = string.Empty,
                    EnterDate = null,
                    Gadget = string.Empty,
                });
                return _List;
            }
        }
    }

    public class AccountSubGroupViewModel
    {
        public string Tag { get; set; }
        public int AccountSubGrpId { get; set; }
        public string AccountSubGrpDesc { get; set; }
        public string AccountSubGrpShortName { get; set; }
        public int AccountGrpId { get; set; }
        public string AccountGrpDesc { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public Nullable<DateTime> EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
