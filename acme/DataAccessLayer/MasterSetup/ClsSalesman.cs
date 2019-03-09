using DataAccessLayer.Interface.MasterSetup;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.MasterSetup
{
    public class ClsSalesman : ISalesman
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public SalesmanViewModel Model { get; set; }
        public MemberTypeViewModel MemberTypeModel { get; set; }

        public ClsSalesman()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new SalesmanViewModel();
            MemberTypeModel = new MemberTypeViewModel();
        }
        public string SaveSalesman()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @SalesmanId int=(select ISNULL((Select Top 1 max(cast(SalesmanId as int))  from ERP.Salesman),0)+1) \n");
                strSql.Append("Insert into ERP.Salesman(SalesmanId, SalesmanDesc, SalesmanShortName, SalesmanPicture, SalesmanPictureUrl, Address, Country, PhoneNo, MobileNo, EmailId, Fax, CommissionRate, CreditLimit, CreditDays, CreditType, ExpiryDate, LedgerId, MainSalesmanId, SalesmanType, Status, EnterBy, EnterDate,MemberTypeId, MembershipId, MemberFromDate, MemberToDate,Gadget) \n");
                strSql.Append("Select @SalesmanId,N'" + Model.SalesmanDesc.Trim().Replace("'", "''") + "',N'" + Model.SalesmanShortName.Trim().Replace("'", "''") + "', null,null, " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + "," + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + "," + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + "," + ((Model.EmailId == "") ? "null" : "N'" + Model.EmailId.Trim().Replace("'", "''") + "'") + "," + ((Model.Fax == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + "," + Model.CommissionRate + "," + Model.CreditLimit + "," + Model.CreditDays + ",null,null," + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + "," + ((Model.MainSalesmanId == 0) ? "null" : "'" + Model.MainSalesmanId + "'") + "," + ((Model.SalesmanType == "") ? "null" : "'" + Model.SalesmanType + "'") + ", '" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "', GETDATE(),\n");
                strSql.Append(" " + ((Model.MemberTypeId == 0) ? "null" : "N'" + Model.MemberTypeId + "'") + " ," + ((Model.MembershipId == "") ? "null" : "N'" + Model.MembershipId.Trim() + "'") + "," + ((Model.MemberFromDate == null) ? "null" : "'" + Convert.ToDateTime(Model.MemberFromDate).ToString("yyyy-MM-dd") + "'") + "," + ((Model.MemberToDate == null) ? "null" : "'" + Convert.ToDateTime(Model.MemberToDate).ToString("yyyy-MM-dd") + "'") + ",'" + Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@SalesmanId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Salesman SET SalesmanDesc=N'" + Model.SalesmanDesc.Trim().Replace("'", "''") + "',SalesmanShortName = N'" + Model.SalesmanShortName.Trim().Replace("'", "''") + "', Address=" + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",Country=" + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",PhoneNo=" + "" + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ", \n");
                strSql.Append("Fax =" + ((Model.Fax == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ",MobileNo=" + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + ",EmailId=" + ((Model.EmailId == "") ? "null" : "N'" + Model.EmailId.Trim().Replace("'", "''") + "'") + ",LedgerId=" + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ",MainSalesmanId=" + ((Model.MainSalesmanId == 0) ? "null" : "'" + Model.MainSalesmanId + "'") + ",SalesmanType=" + ((Model.SalesmanType == "") ? "null" : "'" + Model.SalesmanType + "'") + ",CommissionRate=" + Model.CommissionRate + ",\n");
                strSql.Append(" CreditLimit =" + Model.CreditLimit + ",CreditDays=" + Model.CreditDays + ", Status='" + Model.Status.ToString().ToLower() + "',EnterBy= '" + Model.EnterBy + "',Gadget='" + Model.Gadget + "' WHERE SalesmanId = '" + Model.SalesmanId + "' \n");
                strSql.Append("SET @VNo ='" + Model.SalesmanId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                if (Model.SalesmanType == "Member")
                {
                    strSql.Append("DELETE FROM ERP.GeneralLedger WHERE SalesmanId = '" + Model.SalesmanId + "' \n");
                }
                strSql.Append("DELETE FROM ERP.Salesman WHERE SalesmanId = '" + Model.SalesmanId + "' \n");
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
        public string SaveLedger()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");

            strSql.Append("declare @LedgerId int=(select ISNULL((Select Top 1 max(cast(LedgerId as int))  from ERP.GeneralLedger),0)+1) \n");
            strSql.Append("Insert into ERP.GeneralLedger(LedgerId, GlDesc, GlShortName, GlPrintingName, GlAlias,GlCategory, AccountGrpId,SalesmanId, Status,EnterBy, EnterDate,Gadget,CustomerType) \n");
            strSql.Append("Select @LedgerId,'" + Model.SalesmanDesc.Trim() + "-" + Model.SalesmanShortName.Trim() + "','" + Model.GLShortName.Trim() + "','" + Model.SalesmanDesc.Trim() + "','" + Model.SalesmanDesc.Trim() + "','Customer',(select AccountGrpId from  ERP.AccountGroup where AccountGrpDesc='SUNDRY DEBTORS'),'" + Model.GSalesmanId + "','" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "', GETDATE(),'" + Model.Gadget + "' ,'" + Model.CustomerType + "'\n");
            strSql.Append("SET @VNo =@LedgerId");

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
        public string SaveMemberType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (MemberTypeModel.Tag == "NEW")
            {
                strSql.Append("declare @MemberTypeId int=(select ISNULL((Select Top 1 max(cast(MemberTypeId as int))  from ERP.MemberType),0)+1) \n");
                strSql.Append("Insert into ERP.MemberType ([MemberTypeId], [MemberTypeDesc], [DiscountPercent], [Status], [EnterBy], [EnterDate],Gadget) \n");
                strSql.Append("Select @MemberTypeId,'" + MemberTypeModel.MemberTypeDesc.Trim() + "','" + MemberTypeModel.DiscountPercent + "', '" + MemberTypeModel.Status.ToString().ToLower() + "', '" + MemberTypeModel.EnterBy + "', GETDATE(),'" + MemberTypeModel.Gadget + "' \n");
                strSql.Append("SET @VNo =@MemberTypeId");
            }
            else if (MemberTypeModel.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.MemberType SET MemberTypeDesc=N'" + MemberTypeModel.MemberTypeDesc.Trim().Replace("'", "''") + "',DiscountPercent = '" + MemberTypeModel.DiscountPercent + "',Status='" + MemberTypeModel.Status.ToString().ToLower() + "',EnterBy= '" + MemberTypeModel.EnterBy + "',EnterDate=GETDATE(), Gadget='" + MemberTypeModel.Gadget + "' WHERE MemberTypeId = '" + MemberTypeModel.MemberTypeId + "' \n");
                strSql.Append("SET @VNo ='" + MemberTypeModel.MemberTypeId + "'");
            }
            else if (MemberTypeModel.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.MemberType WHERE MemberTypeId = '" + MemberTypeModel.MemberTypeId + "' \n");
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
        public DataTable GetDataSalesman(int SalesmanId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.Salesman.*,GlDesc,MainSalesmanDesc  from ERP.Salesman left join ERP.GeneralLedger on ERP.Salesman.LedgerId=ERP.GeneralLedger.LedgerId left join ERP.MainSalesman on ERP.Salesman.MainSalesmanId=ERP.MainSalesman.MainSalesmanId ");
            if (SalesmanId != 0)
            {
                strSql.Append("  WHERE ERP.Salesman.SalesmanId='" + SalesmanId + "'");
            }

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public void GetSingleSalesman(string SalesmanDesc)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select SalesmanId,SalesmanDesc,SalesmanShortName from ERP.Salesman WHERE SalesmanDesc='" + SalesmanDesc + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow ro = dt.Rows[0];
                if (ro["SalesmanId"] != DBNull.Value)
                {
                    Model.SalesmanId = Convert.ToInt32(ro["SalesmanId"].ToString());
                }

                if (ro["SalesmanDesc"] != DBNull.Value)
                {
                    Model.SalesmanDesc = ro["SalesmanDesc"].ToString();
                }

                if (ro["SalesmanShortName"] != DBNull.Value)
                {
                    Model.SalesmanShortName = ro["SalesmanShortName"].ToString();
                }
            }
        }
        public DataTable GetDataMember(int SalesmanId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.Salesman.*,MemberTypeDesc  from ERP.Salesman left join ERP.MemberType on ERP.Salesman.MemberTypeId=ERP.MemberType.MemberTypeId  ");
            if (SalesmanId != 0)
            {
                strSql.Append("  WHERE ERP.Salesman.SalesmanId='" + SalesmanId + "'");
            }

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public DataTable GetDataMemberType(int MemberTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * froM [ERP].[MemberType] ");
            if (MemberTypeId != 0)
            {
                strSql.Append("  WHERE MemberTypeId='" + MemberTypeId + "'");
            }

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
    public class SalesmanViewModel
    {
        public string Tag { get; set; }
        public int SalesmanId { get; set; }
        public string SalesmanDesc { get; set; }
        public string SalesmanShortName { get; set; }
        public string SalesmanPicture { get; set; }
        public string SalesmanPictureUrl { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Fax { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public string CreditType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int LedgerId { get; set; }
        public int MainSalesmanId { get; set; }
        public string SalesmanType { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public int MemberTypeId { get; set; }
        public string MembershipId { get; set; }
        public Nullable<DateTime> MemberFromDate { get; set; }
        public Nullable<DateTime> MemberToDate { get; set; }
        public string Gadget { get; set; }
        public string CustomerType { get; set; }
        public string GLShortName { get; set; }
        public int GSalesmanId { get; set; }

    }
    public class MemberTypeViewModel
    {
        public string Tag { get; set; }
        public int MemberTypeId { get; set; }
        public string MemberTypeDesc { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
