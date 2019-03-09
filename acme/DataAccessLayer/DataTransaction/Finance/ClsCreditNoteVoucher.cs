﻿using DataAccessLayer.Interface.DataTransaction.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTransaction.Finance
{
    public class ClsCreditNoteVoucher : ICreditNoteVoucher
    {

        ActiveDataAccess.ActiveDataAccess DAL;
        public CreditNoteMsaterViewModel Model { get; set; }
        public List<CreditNoteDetailsViewModel> ModelDetails { get; set; }

        public ClsCreditNoteVoucher()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CreditNoteMsaterViewModel();
            ModelDetails = new List<CreditNoteDetailsViewModel>();
        }

		public string IsExistsVNumber(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.CreditNoteMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["VoucherNo"].ToString();
		}

        public string SaveCreditNote()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "' \n");

            if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO [ERP].[CreditNoteMaster]([VoucherNo],[VDate],[VTime],[VMiti],[CurrencyId],[CurrencyRate],[LedgerId],[SubLedgerId],[DepartmentId1] \n");
                strSql.Append(",[DepartmentId2],[DepartmentId3],[DepartmentId4],[SalesmanId],[BranchId],[CompanyUnitId],[ReferenceNo]\n");
                strSql.Append(",[ReferenceDate],[EnterBy],[EnterDate],[Remarks],[IsReconcile],[ReconcileBy],[ReconcileDate],[IsPosted],[PostedBy] \n");
                strSql.Append(",[PostedDate],[IsAuthorized],[AuthorizedBy],[AuthorizedDate],[AuthorizeRemarks],[Gadget])\n");
                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', \n");
                strSql.Append("" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + Model.CurrencyRate + "', " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + "," + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + "," + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ",  \n");
                strSql.Append("" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + "," + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ",  \n");
                strSql.Append("" + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ", " + ((Model.ReferenceDate.ToString() == "") ? "null" : "'" + Model.ReferenceDate.ToString() + "'") + "," + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",GETDATE()," + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + ",\n");
                strSql.Append(" '" + Model.IsReconcile + "'," + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("  " + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + ((Model.AuthorizeRemarks == "") ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "' \n");

                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE [ERP].[CreditNoteMaster] SET [VDate] = '" + Model.VDate.ToString("yyyy-MM-dd") + "',[VTime] = '" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "',[VMiti] = '" + Model.VMiti.ToString() + "', \n");
                strSql.Append("[CurrencyId] = " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",[CurrencyRate] = '" + Model.CurrencyRate + "',[LedgerId] = " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ",[SubLedgerId] = " + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ", \n");
                strSql.Append("[DepartmentId1] = " + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ",[DepartmentId2] =" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ",[DepartmentId3] = " + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ",[DepartmentId4] = " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", \n");
                strSql.Append("[SalesmanId] = " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ",[BranchId] = " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",[CompanyUnitId] = " + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ",[ReferenceNo] = " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ",[ReferenceDate] = " + ((Model.ReferenceDate.ToString() == "") ? "null" : "'" + Convert.ToDateTime(Model.ReferenceDate).ToString("yyyy-MM-dd") + "'") + ", \n");
                strSql.Append("[EnterBy] = " + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",[EnterDate] = GETDATE(),[Remarks] = " + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + "   \n");
                strSql.Append("WHERE [VoucherNo]= @VoucherNo \n");
                strSql.Append("DELETE FROM [ERP].[CreditNoteDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM [ERP].[CreditNoteDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[CreditNoteMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
				strSql.Append("Delete from[ERP].[FinanceTransaction]  Where [VoucherNo] = @VoucherNo and[Source] = 'CN' \n");
				strSql.Append("SET @VoucherNo ='1'");
                ModelDetails.Clear();
            }

            foreach (CreditNoteDetailsViewModel det in ModelDetails)
            {
                strSql.Append("INSERT INTO [ERP].[CreditNoteDetails]([VoucherNo],[Sno],[LedgerId],[SubledgerId],[DepartmentIdDet1],[DepartmentIdDet2],[DepartmentIdDet3],[DepartmentIdDet4],[Naration],[Amount],[LocalAmount]) \n");
                strSql.Append("Select @VoucherNo,'" + det.Sno + "','" + det.LedgerId + "'," + ((det.SubledgerId == 0) ? "null" : "'" + det.SubledgerId + "'") + ",\n");
                strSql.Append(" " + ((det.DepartmentIdDet1 == 0) ? "null" : "'" + det.DepartmentIdDet1 + "'") + "," + ((det.DepartmentIdDet2 == 0) ? "null" : "'" + det.DepartmentIdDet2 + "'") + "," + ((det.DepartmentIdDet3 == 0) ? "null" : "'" + det.DepartmentIdDet3 + "'") + "," + ((det.DepartmentIdDet4 == 0) ? "null" : "'" + det.DepartmentIdDet4 + "'") + ", \n");
                strSql.Append(" '" + det.Naration + "','" + det.Amount + "','" + det.LocalAmount + "' \n");
            }
            ModelDetails.Clear();

            if (Model.Tag == "EDIT")
            {
                strSql.Append("Delete from[ERP].[FinanceTransaction]  Where [VoucherNo] = @VoucherNo and[Source] = 'CN' \n");
            }

            strSql.Append("INSERT INTO[ERP].[FinanceTransaction] ([VoucherNo],[VDate],[VMiti],[VTime],[CurrencyId],[CurrencyRate],[DepartmentId1],[DepartmentId2],[DepartmentId3],[DepartmentId4] \n");
            strSql.Append(",[BranchId],[CompanyUnitId],[SalesmanId],[LedgerId],[SubLedgerId],[DrAmt],[CrAmt],[LocalDrAmt],[LocalCrAmt] \n");
            strSql.Append(",[ReconcileDate],[SNO],[CbCode],[EffecDate],[TDueDate],[RefVNo],[ClearingDate],[ClearedBy] \n");
            strSql.Append(",[EnterBy],[Naration],[Remarks],[Source],[chequeNo],[ChequeDate],IsBillCancel) \n");
            strSql.Append("( \n");
            strSql.Append("select[VoucherNo],[VDate],[VMiti],[VTime],[CurrencyId],[CurrencyRate],[DepartmentId1],[DepartmentId2],[DepartmentId3],[DepartmentId4] \n");
            strSql.Append(",[BranchId],[CompanyUnitId],[SalesmanId],[LedgerId],[SubLedgerId],[DrAmt],[CrAmt],[LocalDrAmt],[LocalCrAmt] \n");
            strSql.Append(",[ReconcileDate],[SNO],[CbCode],[EffecDate],[TDueDate],[RefVNo],[ClearingDate],[ClearedBy] \n");
            strSql.Append(",[EnterBy],[Naration],[Remarks],[Source],[chequeNo],[ChequeDate] ,IsBillCancel \n");
            strSql.Append("from (Select CM.VoucherNo, CM.VDate,CM.VMiti ,CM.VTime,CM.CurrencyId,CM.CurrencyRate, \n");
            strSql.Append("(case when CD.DepartmentIdDet1 is not null then CD.DepartmentIdDet1 else CM.DepartmentId1 end) as DepartmentId1, \n");
            strSql.Append("(case when CD.DepartmentIdDet2 is not null then CD.DepartmentIdDet2 else CM.DepartmentId2 end) as DepartmentId2, \n");
            strSql.Append("(case when CD.DepartmentIdDet3 is not null then CD.DepartmentIdDet3 else CM.DepartmentId3 end) as DepartmentId3, \n");
            strSql.Append("(case when CD.DepartmentIdDet4 is not null then CD.DepartmentIdDet4 else CM.DepartmentId4 end) as DepartmentId4, \n");
            strSql.Append("CM.BranchId,CM.CompanyUnitId,CM.SalesmanId, CD.LedgerId,CD.SubLedgerId, \n");
            strSql.Append("Amount as DrAmt, 0 as CrAmt, LocalAmount as LocalDrAmt,0 as LocalCrAmt, \n");
            strSql.Append("CM.ReconcileDate,CD.Sno,null as CbCode,null  as EffecDate,null  as TDueDate,null as RefVNo, \n");
            strSql.Append("null as [ClearingDate],null as[ClearedBy],EnterBy,Naration,Remarks,'CN' as Source,null as chequeNo, null as ChequeDate,NULL as IsBillCancel \n");
            strSql.Append("from ERP.CreditNoteMaster CM left Join ERP.CreditNoteDetails CD On CD.VoucherNo = CM.VoucherNo \n");
            strSql.Append("where CM.VoucherNo =@VoucherNo \n");
            strSql.Append("Union All \n");
            strSql.Append("select VoucherNo, VDate,VMiti ,VTime, CurrencyId, CurrencyRate, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4, \n");
            strSql.Append("BranchId, CompanyUnitId, SalesmanId, LedgerId, SubLedgerId, \n");
            strSql.Append("Case when amt< 0 then Abs(Amt) else 0 end as DrAmt, \n");
            strSql.Append("Case when amt >= 0 then Amt else 0 end as CrAmt, \n");
            strSql.Append("Case when LocalAmt< 0 then Abs(LocalAmt) else 0 end as LocalDrAmt, \n");
            strSql.Append("Case when LocalAmt >= 0 then LocalAmt else 0 end as LocalCrAmt, \n");
            strSql.Append("ReconcileDate,Sno,CbCode,EffecDate, TDueDate,RefVNo, \n");
            strSql.Append("[ClearingDate],[ClearedBy],EnterBy,Naration,Remarks, Source,chequeNo,ChequeDate,IsBillCancel \n");
            strSql.Append("from( Select CM.VoucherNo as VoucherNo, CM.VDate as VDate,VMiti, CM.VTime as VTime, CM.CurrencyId, CM.CurrencyRate, \n");
            strSql.Append("(case when CD.DepartmentIdDet1 is not null then CD.DepartmentIdDet1 else CM.DepartmentId1 end) as DepartmentId1, \n");
            strSql.Append("(case when CD.DepartmentIdDet2 is not null then CD.DepartmentIdDet2 else CM.DepartmentId2 end) as DepartmentId2, \n");
            strSql.Append("(case when CD.DepartmentIdDet3 is not null then CD.DepartmentIdDet3 else CM.DepartmentId3 end) as DepartmentId3, \n");
            strSql.Append("(case when CD.DepartmentIdDet4 is not null then CD.DepartmentIdDet4 else CM.DepartmentId4 end) as DepartmentId4, \n");
            strSql.Append("CM.BranchId,CM.CompanyUnitId,CM.SalesmanId, CD.LedgerId,CD.SubLedgerId, \n");
            strSql.Append("sum(Amount) as Amt, sum(LocalAmount) as LocalAmt, \n");
            strSql.Append("CM.ReconcileDate,CD.Sno,null as CbCode,null  as EffecDate,null  as TDueDate,null as RefVNo, \n");
            strSql.Append("null as [ClearingDate],null as[ClearedBy],EnterBy,Naration,Remarks,'CN' as Source,null  as chequeNo, null as ChequeDate,NULL as IsBillCancel \n");
            strSql.Append("from ERP.CreditNoteMaster CM left Join ERP.CreditNoteDetails CD On CD.VoucherNo = CM.VoucherNo \n");
            strSql.Append("where CM.VoucherNo =@VoucherNo \n");
            strSql.Append("Group By CM.VoucherNo , CM.VDate , CM.VTime ,VMiti, CM.CurrencyId, CM.CurrencyRate, \n");
            strSql.Append("CD.DepartmentIdDet1, CD.DepartmentIdDet2, CD.DepartmentIdDet3, CD.DepartmentIdDet4 , CM.DepartmentId1, CM.DepartmentId2, CM.DepartmentId3, CM.DepartmentId4, \n");
            strSql.Append("CM.BranchId, CM.CompanyUnitId, CM.SalesmanId, CD.LedgerId, CD.SubLedgerId, \n");
            strSql.Append("ReconcileDate, Sno, EnterBy, Naration, Remarks \n");
            strSql.Append(") as CNMaster )as FinanceTran \n");
            strSql.Append(") \n");

            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VoucherNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VoucherNo", SqlDbType.VarChar, 25) { Direction = ParameterDirection.Output };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }

        public DataSet GetDataCreditNoteVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select CNM.*,GL.GlDesc, Gl.GlCategory,Gl.IsDocAdjustment,GL.PanNo,SGL.SubledgerDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4,Cur.CurrencyDesc, SalesmanDesc \n");
            strSql.Append("from ERP.CreditNoteMaster as CNM \n");
            strSql.Append("Left join ERP.GeneralLedger as GL on CNM.LedgerId = GL.LedgerId \n");
            strSql.Append("Left join ERP.Subledger as SGL on CNM.SubledgerId = SGL.SubledgerId \n");
            strSql.Append("Left join ERP.Currency as Cur on cur.CurrencyId = CNM.CurrencyId \n");
            strSql.Append("Left Join ERP.Department as D1 on CNM.DepartmentId1 = D1.DepartmentId \n");
            strSql.Append("Left Join ERP.Department as D2 on CNM.DepartmentId2 = D2.DepartmentId \n");
            strSql.Append("Left Join ERP.Department as D3 on CNM.DepartmentId3 = D3.DepartmentId \n");
            strSql.Append("Left Join ERP.Department as D4 on CNM.DepartmentId4 = D4.DepartmentId \n");
            strSql.Append("Left join ERP.SalesMan on CNM.SalesmanId = Salesman.salesmanId  \n");
            strSql.Append("Where CNM.VoucherNo = '" + VoucherNo.Trim() + "'  \n\n");
            strSql.Append("Select CND.*,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentDesc as DepartmentDesc4,\n");
            strSql.Append("SubLeg.SubledgerDesc,GL.GlDesc, Gl.GlCategory \n");
            strSql.Append("from ERP.CreditNoteDetails as CND \n");
            strSql.Append("Left Join ERP.Department as D1 on CND.DepartmentIdDet1 = D1.DepartmentId \n");
            strSql.Append("Left Join ERP.Department as D2 on CND.DepartmentIdDet2 = D2.DepartmentId \n");
            strSql.Append("Left Join ERP.Department as D3 on CND.DepartmentIdDet3 = D3.DepartmentId \n");
            strSql.Append("Left Join ERP.Department as D4 on CND.DepartmentIdDet4 = D4.DepartmentId \n");
            strSql.Append("Left join ERP.SubLedger as SubLeg on SubLeg.SubledgerId = CND.SubledgerId \n");
            strSql.Append("Left join ERP.GeneralLedger as GL on GL.LedgerId = CND.LedgerId \n");
            strSql.Append("Where VoucherNo = '" + VoucherNo.Trim() + "'");
            strSql.Append("order by CND.SNo \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
    }

    public class CreditNoteMsaterViewModel
    {
        public string Tag { get; set; }
        public string VoucherNo { get; set; }
        public int DocId { get; set; }
        public DateTime VDate { get; set; }
        public DateTime VTime { get; set; }
        public string VMiti { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyRate { get; set; }
        public int LedgerId { get; set; }
        public int SubLedgerId { get; set; }
        public int DepartmentId1 { get; set; }
        public int DepartmentId2 { get; set; }
        public int DepartmentId3 { get; set; }
        public int DepartmentId4 { get; set; }
        public int SalesmanId { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<DateTime> ReferenceDate { get; set; }
        public string EnterBy { get; set; }
        public Nullable<DateTime> EnterDate { get; set; }
        public string Remarks { get; set; }
        public int IsReconcile { get; set; }
        public string ReconcileBy { get; set; }
        public Nullable<DateTime> ReconcileDate { get; set; }
        public int IsPosted { get; set; }
        public string PostedBy { get; set; }
        public Nullable<DateTime> PostedDate { get; set; }
        public int IsAuthorized { get; set; }
        public string AuthorizedBy { get; set; }
        public Nullable<DateTime> AuthorizedDate { get; set; }
        public string AuthorizeRemarks { get; set; }
        public string Gadget { get; set; }
    }

    public class CreditNoteDetailsViewModel
    {
        public string VoucherNo { get; set; }
        public int Sno { get; set; }
        public int LedgerId { get; set; }
        public int SubledgerId { get; set; }
        public int DepartmentIdDet1 { get; set; }
        public int DepartmentIdDet2 { get; set; }
        public int DepartmentIdDet3 { get; set; }
        public int DepartmentIdDet4 { get; set; }
        public string Naration { get; set; }
        public decimal Amount { get; set; }
        public decimal LocalAmount { get; set; }
    }

}