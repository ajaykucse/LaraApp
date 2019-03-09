using DataAccessLayer.Interface.DataTransaction.Normal_Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataTransaction.Normal_Production
{

    public class ClsBillOfMaterial : IBillOfMaterial
    {
        ActiveDataAccess.ActiveDataAccess DAL;

        public BillOfMaterialMasterViewModel Model { get; set; }
        public List<BillOfMaterialDetailsViewModel> ModelDetails { get; set; }
		public List<BillOfMaterialFinishedViewModel> ModelFinished { get; set; }

		public ClsBillOfMaterial()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new BillOfMaterialMasterViewModel();
            ModelDetails = new List<BillOfMaterialDetailsViewModel>();
			ModelFinished = new List<BillOfMaterialFinishedViewModel>();

		}
		public string SaveBillOfMaterial()
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("BEGIN TRANSACTION \n");
			strSql.Append("BEGIN TRY \n");
			strSql.Append("Set @VoucherNo ='" + Model.BillOfMaterialId + "' \n");
			if (Model.Tag == "NEW")
			{
				strSql.Append("INSERT INTO ERP.BillOfMaterialMaster(BillOfMaterialId, BillOfMaterialDesc, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4, BranchId, CompanyUnitId, Remarks, EnterBy, EnterDate, Gadget, EntryFromProject) \n");
				strSql.Append("Select @VoucherNo,N'" + Model.BillOfMaterialDesc + "'," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + "," + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", '" + Model.EnterBy + "', GETDATE(),'" + Model.Gadget + "', '" + Model.EntryFromProject + "'  \n");

				strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");

			}
			else if (Model.Tag == "EDIT")
			{
				strSql.Append("DELETE FROM [ERP].[BillOfMaterialFinished] WHERE BillOfMaterialId ='" + Model.BillOfMaterialId + "' \n");
				strSql.Append("DELETE FROM [ERP].[BillOfMaterialDetails] WHERE BillOfMaterialId ='" + Model.BillOfMaterialId + "' \n");
				strSql.Append("UPDATE ERP.BillOfMaterialMaster SET BillOfMaterialDesc= N'" + Model.BillOfMaterialDesc + "',DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ",DepartmentId2= " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " , DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ",DepartmentId4= " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ",BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", Remarks=" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ",EnterBy= '" + Model.EnterBy + "',EnterDate= GETDATE(),Gadget='" + Model.Gadget + "',EntryFromProject= '" + Model.EntryFromProject + "' Where BillOfMaterialId='" + Model.BillOfMaterialId + "' \n");

			}
			else if (Model.Tag == "DELETE")
			{
				strSql.Append("DELETE FROM [ERP].[BillOfMaterialFinished] WHERE BillOfMaterialId ='" + Model.BillOfMaterialId + "' \n");
				strSql.Append("DELETE FROM [ERP].[BillOfMaterialDetails] WHERE BillOfMaterialId ='" + Model.BillOfMaterialId + "' \n");
				strSql.Append("DELETE FROM [ERP].[BillOfMaterialMaster] WHERE BillOfMaterialId ='" + Model.BillOfMaterialId + "' \n");

				strSql.Append("SET @VoucherNo ='1'");

			}
			if (Model.Tag != "DELETE")
			{
				foreach (BillOfMaterialDetailsViewModel det in ModelDetails)
				{
					strSql.Append("INSERT INTO ERP.BillOfMaterialDetails(BillOfMaterialId, SNO, ProductId, GodownId, CostCenterDetailId, AltQty, AltProductUnitId, Qty, ProductUnitId) \n");
					strSql.Append("Select @VoucherNo, '" + det.SNO + "', '" + det.ProductId + "', " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ", " + ((det.CostCenterDetailId == 0) ? "null" : "'" + det.CostCenterDetailId + "'") + ",'" + det.AltQty + "'," + ((det.AltProductUnitId == 0) ? "null" : "'" + det.AltProductUnitId + "'") + ", '" + det.Qty + "', " + ((det.ProductUnitId == 0) ? "null" : "'" + det.ProductUnitId + "'") + " \n");
				}
				foreach (BillOfMaterialFinishedViewModel det in ModelFinished)
				{
					strSql.Append("INSERT INTO ERP.BillOfMaterialFinished(BillOfMaterialId, SNO, ProductId, GodownId, CostCenterId, AltQty, AltProductUnitId, Qty, ProductUnitId,FinishedCosting) \n");
					strSql.Append("Select @VoucherNo, '" + det.SNO + "', '" + det.ProductId + "', " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ", " + ((det.CostCenterId == 0) ? "null" : "'" + det.CostCenterId + "'") + ",'" + det.AltQty + "'," + ((det.AltProductUnitId == 0) ? "null" : "'" + det.AltProductUnitId + "'") + ", '" + det.Qty + "', " + ((det.ProductUnitId == 0) ? "null" : "'" + det.ProductUnitId + "'") + " ,'" + det.FinishedCosting + "'\n");
				}
			}

			ModelDetails.Clear();
			ModelFinished.Clear();
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
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select BillOfMaterialId from erp.BillOfMaterialMaster WHERE BillOfMaterialId='" + VoucherNo.Trim() + "'").Tables[0];
            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0]["BillOfMaterialId"].ToString();
        }

        public DataSet GetDataBillOfMaterial(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select BOMM.*, \n");
			strSql.Append("D1.DepartmentId as DepartmentId1, D1.DepartmentDesc as DepartmentDesc1, D2.DepartmentId as DepartmentId2, D2.DepartmentDesc as DepartmentDesc2, D3.DepartmentId as DepartmentId3, D3.DepartmentDesc as DepartmentDesc3, D4.DepartmentId as DepartmentId4, D4.DepartmentDesc as DepartmentDesc4, \n");
			strSql.Append("BranchName, CU.CmpUnitName \n");
			strSql.Append("from erp.BillOfMaterialMaster BOMM \n");
			strSql.Append("left Join erp.Department D1 on BOMM.DepartmentId1 = D1.DepartmentID  \n");
			strSql.Append("left Join erp.Department D2  on BOMM.DepartmentId2 = D2.DepartmentID  \n");
			strSql.Append("left Join erp.Department D3 on BOMM.DepartmentId3 = D3.DepartmentID  \n");
			strSql.Append("left Join erp.Department D4 on BOMM.DepartmentId4 = D4.DepartmentID  \n");
			strSql.Append("left Join erp.Branch BR on BR.BranchId = BOMM.BranchId \n");
			strSql.Append("left Join erp.CompanyUnit CU on BOMM.CompanyUnitId = CU.CompanyUnitId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where BillOfMaterialId='" + VoucherNo + "' \n");

            strSql.Append("Select BOMD.*,ProductDesc,ProductShortName,PD.AltConv,Pu.ProductUnitDesc as ProductUnit , Apu.ProductUnitDesc as AltProductUnit,GodownDesc,CostCenterDesc from erp.BillOfMaterialDetails as BOMD \n");
			strSql.Append("left Join erp.product PD on PD.ProductId = BOMD.ProductId \n");
			strSql.Append("left Join erp.CostCenter CC on CC.CostCenterId = BOMD.CostCenterDetailId \n");
			strSql.Append("left Join erp.Godown GD on GD.GodownId = BOMD.GodownId \n");
			strSql.Append("left Join erp.ProductUnit PU on PU.ProductUnitId = BOMD.ProductUnitId \n");
			strSql.Append("left Join erp.ProductUnit APU on APU.ProductUnitId = BOMD.AltProductUnitId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where BillOfMaterialId='" + VoucherNo + "' \n");

			strSql.Append("Select BOMD.*,ProductDesc,ProductShortName,PD.AltConv,Pu.ProductUnitDesc as ProductUnit , Apu.ProductUnitDesc as AltProductUnit,GodownDesc,CostCenterDesc from erp.BillOfMaterialFinished as BOMD \n");
			strSql.Append("left Join erp.product PD on PD.ProductId = BOMD.ProductId \n");
			strSql.Append("left Join erp.CostCenter CC on CC.CostCenterId = BOMD.CostCenterId \n");
			strSql.Append("left Join erp.Godown GD on GD.GodownId = BOMD.GodownId \n");
			strSql.Append("left Join erp.ProductUnit PU on PU.ProductUnitId = BOMD.ProductUnitId \n");
			strSql.Append("left Join erp.ProductUnit APU on APU.ProductUnitId = BOMD.AltProductUnitId \n");
			if (!string.IsNullOrEmpty(VoucherNo))
				strSql.Append(" where BillOfMaterialId='" + VoucherNo + "' \n");

			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

    }


    public class BillOfMaterialMasterViewModel
    {
        public string Tag { get; set; }
        public int DocId { get; set; }
        public  string BillOfMaterialId { get; set; }
        public  string BillOfMaterialDesc { get; set; }
        public  int CostCenterId { get; set; }
        public  int ProductId { get; set; }
        public  int DepartmentId1 { get; set; }
        public  int DepartmentId2 { get; set; }
        public  int DepartmentId3 { get; set; }
        public  int DepartmentId4 { get; set; }
        public  int BranchId { get; set; }
        public  int CompanyUnitId { get; set; }
        public  decimal AltQty { get; set; }
        public  int AltProductUnitId { get; set; }
        public  decimal ConvFactor { get; set; }
        public  decimal Qty { get; set; }
        public  int ProductUnitId { get; set; }
        public  string Remarks { get; set; }
        public  string EnterBy { get; set; }
        public  DateTime? EnterDate { get; set; }
        public  string Gadget { get; set; }
        public  string EntryFromProject { get; set; }
    }

    public class BillOfMaterialDetailsViewModel
    {
        public  string BillOfMaterialId { get; set; }
        public  int SNO { get; set; }
        public  int ProductId { get; set; }
        public  int GodownId { get; set; }
        public  int CostCenterDetailId { get; set; }
        public  decimal AltQty { get; set; }
        public  int AltProductUnitId { get; set; }
        public  decimal Qty { get; set; }
        public  int ProductUnitId { get; set; }
    }

	public class BillOfMaterialFinishedViewModel
	{
		public string BillOfMaterialId { get; set; }
		public int SNO { get; set; }
		public int ProductId { get; set; }
		public int GodownId { get; set; }
		public int CostCenterId { get; set; }
		public decimal AltQty { get; set; }
		public int AltProductUnitId { get; set; }
		public decimal Qty { get; set; }
		public int ProductUnitId { get; set; }
		public decimal FinishedCosting { get; set; }
	}
}
