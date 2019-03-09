using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DataTransaction.Purchase
{
    public class ClsPurchaseIndent : IPurchaseIndent
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public PurchaseIndentMasterViewModel Model { get; set; }
        public List<PurchaseIndentDetailsViewModel> ModelDetails { get; set; }

        public ClsPurchaseIndent()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new PurchaseIndentMasterViewModel();
            ModelDetails = new List<PurchaseIndentDetailsViewModel>();
        }

        public string SavePurchaseIndent()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "' \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO ERP.PurchaseIndentMaster(VoucherNo, VDate, VTime, VMiti,RequestedBy, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4,Remarks, \n");
                strSql.Append("  BranchId, CompanyUnitId, EnterBy, EnterDate, IsReconcile, ReconcileBy, ReconcileDate, IsPosted, PostedBy, PostedDate, \n");
                strSql.Append("  IsAuthorized, AuthorizedBy, AuthorizedDate, AuthorizeRemarks, Gadget)  \n");
                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "','"+Model.RequestedBy+"', \n");
                strSql.Append("" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ",'"+Model.Remarks + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("'" + Model.EnterBy + "', GETDATE(),'" + Model.IsReconcile + "'," + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("" + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "' \n");

                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");

            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.PurchaseIndentMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VTime='" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "',VMiti='" + Model.VMiti.ToString() + "',RequestedBy='" + Model.RequestedBy.ToString() + "', \n");
                strSql.Append(" DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", DepartmentId2=" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", Remarks='" + Model.Remarks + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append(" EnterBy=" + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",EnterDate= GETDATE(),IsReconcile='" + Model.IsReconcile + "', ReconcileBy= " + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("AuthorizedDate= " + ((string.IsNullOrEmpty(Model.AuthorizedDate.ToString())) ? "null" : "'" + Model.AuthorizedDate.Value.ToString("yyyy-MM-dd") + "'") + ", AuthorizeRemarks= " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "' Where VoucherNo = '" + Model.VoucherNo + "'\n");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM [ERP].[PurchaseIndentDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseIndentMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");

                strSql.Append("SET @VoucherNo ='1'");
                ModelDetails.Clear();
            }

            if (Model.Tag == "EDIT")
            {
                strSql.Append("DELETE FROM [ERP].[PurchaseIndentDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
            }

            foreach (PurchaseIndentDetailsViewModel det in ModelDetails)
            {
                strSql.Append("INSERT INTO ERP.PurchaseIndentDetails(VoucherNo, Sno, ProductId, ProductAltUnit, ProductUnit, AltQty, Qty, ConversionRatio, Narration) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnitId == 0) ? "null" : "'" + det.ProductAltUnitId + "'") + ", " + ((det.ProductUnitId == 0) ? "null" : "'" + det.ProductUnitId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "','"+det.ConversionRatio+"'," + (string.IsNullOrEmpty(det.Narration) ? "null" : "'" + det.Narration + "'") + "  \n");
            }

            ModelDetails.Clear();

            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VoucherNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VoucherNo", SqlDbType.VarChar, 25)
            { Direction = ParameterDirection.Output };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }

        public string IsExistsVNumber(string VoucherNo)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.PurchaseIndentMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["VoucherNo"].ToString();
            }
        }
		public string IsIndentUsedInOrder(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select TOP 1 IndentNo from ERP.PurchaseOrderDetails where IndentNo='" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["IndentNo"].ToString();
		}

		public string IsIndentUsedInQuotation(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select TOP 1 IndentNo from ERP.PurchaseQuotationDetails  where IndentNo='" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["IndentNo"].ToString();
		}
		public DataSet GetDataPurchaseIndentVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select PIM.*,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4  \n");
            strSql.Append(",BranchName,CU.CmpUnitName  \n");
            strSql.Append("from erp.PurchaseIndentMaster PIM  \n");
            strSql.Append("left Join erp.Department D1 on PIM.DepartmentId1 = D1.DepartmentID  \n");
            strSql.Append("left Join erp.Department D2  on PIM.DepartmentId2 = D2.DepartmentID  \n");
            strSql.Append("left Join erp.Department D3 on PIM.DepartmentId3 = D3.DepartmentID  \n");
            strSql.Append("left Join erp.Department D4 on PIM.DepartmentId4 = D4.DepartmentID  \n");
            strSql.Append("left Join erp.Branch BR on PIM.BranchId = BR.BranchId  \n");
            strSql.Append("left Join erp.CompanyUnit CU on PIM.CompanyUnitId = CU.CompanyUnitId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
            {
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");
            }

            strSql.Append("Select[PID].*,ProductShortName, ProductDesc,BuyRate as PurchaseRate,PD.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc from erp.PurchaseIndentDetails[PID] \n");
            strSql.Append("left join erp.Product PD on[PID].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on[PID].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on[PID].ProductAltUnit = PAU.ProductUnitId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
            {
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");
            }

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        public class PurchaseIndentMasterViewModel
        {
            public string Tag { get; set; }
            public int DocId { get; set; }
            public string EntryFromProject { get; set; }
            public string VoucherNo { get; set; }
            public DateTime VDate { get; set; }
            public DateTime VTime { get; set; }
            public string VMiti { get; set; }
            public string RequestedBy { get; set; }
            public int DepartmentId1 { get; set; }
            public int DepartmentId2 { get; set; }
            public int DepartmentId3 { get; set; }
            public int DepartmentId4 { get; set; }
            public string Remarks { get; set; }
            public int BranchId { get; set; }
            public int CompanyUnitId { get; set; }
            public string EnterBy { get; set; }
            public string EnterDate { get; set; }
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

        public class PurchaseIndentDetailsViewModel
        {
            public string VoucherNo { get; set; }
            public int Sno { get; set; }
            public int ProductId { get; set; }
            public int ProductAltUnitId { get; set; }
            public int ProductUnitId { get; set; }
            public decimal AltQty { get; set; }
            public decimal Qty { get; set; }
            public decimal ConversionRatio { get; set; }
            public string Narration { get; set; }
        }
    }
}
