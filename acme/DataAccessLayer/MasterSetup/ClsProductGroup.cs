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
    public class ClsProductGroup : IProductGroup
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public ProductGroupViewModel Model { get; set; }
        public ClsProductGroup()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new ProductGroupViewModel();
        }
        public string SaveProductGroup(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @ProductGrpId int=(select ISNULL((Select Top 1 max(cast(ProductGrpId as int))  from ERP."+ tableName + "),0)+1) \n");
                strSql.Append("Insert into ERP."+ tableName + "(ProductGrpId, ProductGrpDesc, ProductGrpShortName,Margin,PrinterName, [Status], EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @ProductGrpId,N'" + Model.ProductGrpDesc.Trim().Replace("'", "''") + "',N'" + Model.ProductGrpShortName.Trim().Replace("'", "''") + "', " + ((Model.ProductGrpMargin == null) ? "0" : "'" + Model.ProductGrpMargin + "'") + ", '" + Model.ProductGrpPrinterName.Trim() + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),'"+ Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@ProductGrpId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP." + tableName + " SET ProductGrpDesc=N'" + Model.ProductGrpDesc.Trim().Replace("'", "''") + "',ProductGrpShortName = N'" + Model.ProductGrpShortName.Trim().Replace("'", "''") + "',Margin = " + ((Model.ProductGrpMargin == null) ? "0" : "'" + Model.ProductGrpMargin + "'") + ",PrinterName = '" + Model.ProductGrpPrinterName.Trim() + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='" + Model.Gadget + "'  WHERE ProductGrpId = '" + Model.ProductGrpId + "' \n");
                strSql.Append("SET @VNo ='" + Model.ProductGrpId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP." + tableName + " WHERE ProductGrpId = '" + Model.ProductGrpId + "' \n");
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
        public DataTable GetDataProductGroup(int ProductGrpId, string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ERP." + tableName + "");
            if (ProductGrpId != 0)
                strSql.Append(" WHERE ProductGrpId='" + ProductGrpId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }        
    }
    public class ProductGroupViewModel
    {
        public string Tag { get; set; }
        public int ProductGrpId { get; set; }
        public string ProductGrpDesc { get; set; }
        public string ProductGrpShortName { get; set; }
        public decimal ProductGrpMargin { get; set; }
        public string ProductGrpPrinterName { get; set; }        
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
