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
    public class ClsPurchaseBillingTerm : IPurchaseBillingTerm
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public PurchaseBillingTermViewModel Model { get; set; }
        public ClsPurchaseBillingTerm()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new PurchaseBillingTermViewModel();
        }
        public string SavePurchaseBillingTerm()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @TermId int=(select ISNULL((Select Top 1 max(cast(TermId as int))  from ERP.PurchaseBillingTerm),0)+1) \n");
                strSql.Append("Insert into ERP.PurchaseBillingTerm([TermId],[TermPosition],[TermType],[TermDesc],[Category],[LedgerId],[Basis],[PTSign],[Billwise],[TermRate],[StockValuation],[SupressZero],[Formula],[Status],[EnterBy],[EnterDate],Gadget) \n");
                strSql.Append("select @TermId," + Model.TermPosition + ",'" + Model.TermType.Trim() + "',N'" + Model.TermDesc.Trim().Replace("'", "''") + "','" + Model.Category.Trim() + "','" + Model.LedgerId + "','" + Model.Basis.Trim() + "','" + Model.PTSign.Trim() + "','" + Model.Billwise.Trim() + "','" + Model.TermRate + "','" + Model.StockValuation + "','" + Model.SupressZero + "','" + Model.Formula.Trim() + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE() ,'"+ Model.Gadget + "'\n");
                strSql.Append("SET @VNo =@TermId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.PurchaseBillingTerm SET [TermPosition] = '" + Model.TermPosition + "',[TermType] = '" + Model.TermType.Trim() + "',[TermDesc] = '" + Model.TermDesc.Trim() + "',[Category] = '" + Model.Category.Trim() + "',[LedgerId] = '" + Model.LedgerId + "',[Basis] = '" + Model.Basis.Trim() + "',[PTSign] = '" + Model.PTSign.Trim() + "',[Billwise] = '" + Model.Billwise.Trim() + "',[TermRate] = '" + Model.TermRate + "',[StockValuation] = '" + Model.StockValuation + "',[SupressZero] = '" + Model.SupressZero + "',[Formula] = '" + Model.Formula.Trim() + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='"+Model.Gadget + "' WHERE TermId = '" + Model.TermId + "' \n");
                strSql.Append("SET @VNo ='" + Model.TermId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.PurchaseBillingTerm WHERE TermId = '" + Model.TermId + "' \n");
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
        public DataTable GetDataPurchaseBillingTerm(int TermId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select TermId, TermPosition,case when TermType='I' then 'Invoice' when TermType='B' then 'Both' else 'Return'end as TermType, TermDesc,Category,ERP.PurchaseBillingTerm.LedgerId, GlDesc as LedgerDesc,Case when Billwise='Y' then 'Bill Wise' else 'Product Wise' end as Billwise,Case when Basis='Q' then 'Quantity' else 'Value' end as Basis, PTSign,  TermRate, StockValuation, SupressZero, Formula, ERP.PurchaseBillingTerm.Status, ERP.PurchaseBillingTerm.EnterBy, ERP.PurchaseBillingTerm.EnterDate from ERP.PurchaseBillingTerm left join ERP.GeneralLedger on ERP.PurchaseBillingTerm.LedgerId=ERP.GeneralLedger.LedgerId ");
            if (TermId != 0)
                strSql.Append("where TermId ='" + TermId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];          
        }
        public DataTable GetProductTerm()
        {
            return DAL.ExecuteDataset(CommandType.Text, "Select TermId, TermDesc,GlDesc,case when TermType='I' then 'Invoice' else 'Return'end as TermType,   Basis, PTSign as [Sign], CONVERT(DECIMAL(10,2),TermRate) as [Rate]  from ERP.PurchaseBillingTerm PBT left join erp.GeneralLedger GL on GL.LedgerId = PBT.LedgerId WHERE Category='General' and Billwise='N' order by TermId").Tables[0];

        }

        public DataTable GetBillTerm()
        {
            return DAL.ExecuteDataset(CommandType.Text, "Select TermId, TermDesc,GlDesc,case when TermType='I' then 'Invoice' else 'Return'end as TermType,   Basis, PTSign as [Sign],CONVERT(DECIMAL(10,2),TermRate) as [Rate] from ERP.PurchaseBillingTerm PBT left join erp.GeneralLedger GL on GL.LedgerId  =PBT.LedgerId  WHERE  Category='General' and Billwise='Y' order by TermId").Tables[0];
        }
        public string CheckTermExists(int BranchId, string ISBillwise)
        {
            StringBuilder strSql = new StringBuilder();
            if (BranchId != 0)
            {
                strSql.Append("Select TermId from ERP.PurchaseBillingTerm  where Billwise = '" + ISBillwise + "' and Category <> 'Additional' and TermId IN(SELECT TermId FROM ERP.SalesBillingTermBranchMapping WHERE BranchId='" + BranchId + "') \n");
            }
            else
            {
                strSql.Append("Select TermId from ERP.PurchaseBillingTerm  where Billwise = '" + ISBillwise + "' and Category <> 'Additional' \n");
            }
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return dt.Rows.Count > 0 ? "Yes" : "";
        }

        public DataTable GetTermListForTermCalculation(string Module, int BranchId, int ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            switch (Module)
            {
                case "Purchase":
                    if (BranchId == 0)
                    {
                        if (ProductId > 0) //----- PRODUCT WISE
                        {
                            strSql.Append("SELECT PBT.TermId,TermDesc,Basis,PTSign as Sign, CASE WHEN PT.Rate is null THEN TermRate ELSE PT.Rate END AS TermRate, TermPosition, Formula from ERP.PurchaseBillingTerm PBT \n");
                            strSql.Append("Left outer join ERP.PurchaseProductTerm PT ON PT.TermId = PBT.TermId and PT.ProductId = '" + ProductId + "' \n");
                            strSql.Append("WHERE Billwise = 'N' and Category <> 'Additional' ORDER BY TermPosition");
                        }
                        else  //----- BILL WISE
                        {
                            strSql.Append("SELECT TermId, TermDesc, Basis, PTSign as Sign, TermRate, TermPosition, Formula FROM ERP.PurchaseBillingTerm  WHERE Billwise = 'Y' AND Category<> 'Additional' ORDER BY TermPosition");
                        }
                    }
                    else
                    {
                        if (ProductId > 0) //----- PRODUCT WISE
                        {
                            strSql.Append("SELECT PBT.TermId,TermDesc,Basis,STSign as Sign, CASE WHEN PT.Rate is null THEN TermRate ELSE PT.Rate END AS TermRate, TermPosition, Formula from ERP.PurchaseBillingTerm PBT \n");
                            strSql.Append("Left outer join ERP.PurchaseProductTerm PT ON PT.TermId = PBT.TermId and PT.ProductId = '" + ProductId + "' \n");
                            strSql.Append("WHERE Billwise = 'N'  and Category<> 'Additional' \n");
                            strSql.Append("AND PBT.TermId IN(SELECT TermId FROM ERP.PurchaseBillingTermBranchMapping WHERE BranchId= '" + BranchId + "') \n");
                            strSql.Append("ORDER BY TermPosition");
                        }
                        else  //----- BILL WISE
                        {
                            strSql.Append("SELECT TermId, TermDesc, Basis, PTSign as Sign, TermRate, TermPosition, Formula FROM ERP.PurchaseBillingTerm  WHERE Billwise = 'Y' AND Category<> 'Additional' AND PBT.TermId IN(SELECT TermId FROM ERP.PurchaseBillingTermBranchMapping WHERE BranchId= '" + BranchId + "') ORDER BY TermPosition");
                        }
                    }
                    break;
            }
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }

    public class PurchaseBillingTermViewModel
    {
        public string Tag { get; set; }
        public int TermId { get; set; }
        public int TermPosition { get; set; }
        public string TermType { get; set; }
        public string TermDesc { get; set; }
        public string Category { get; set; }
        public int LedgerId { get; set; }
        public string Basis { get; set; }
        public string PTSign { get; set; }
        public string Billwise { get; set; }
        public decimal TermRate { get; set; }
        public bool StockValuation { get; set; }
        public bool SupressZero { get; set; }
        public string Formula { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
