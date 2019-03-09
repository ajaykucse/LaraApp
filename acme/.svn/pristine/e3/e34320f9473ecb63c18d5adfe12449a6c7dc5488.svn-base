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
    public class ClsProductSubGroup : IProductSubGroup
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public ProductSubGroupViewModel Model { get; set; }
        public ClsProductSubGroup()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new ProductSubGroupViewModel();
        }
        public string SaveProductSubGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @ProductSubGrpId int=(select ISNULL((Select Top 1 max(cast(ProductSubGrpId as int))  from ERP.ProductSubGroup),0)+1) \n");
                strSql.Append("Insert into ERP.ProductSubGroup(ProductSubGrpId, ProductSubGrpDesc, ProductSubGrpShortName,ProductGrpId, [Status], EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @ProductSubGrpId,'" + Model.ProductSubGrpDesc.Trim() + "','" + Model.ProductSubGrpShortName.Trim() + "','" + Model.ProductGrpId + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE() ,'"+ Model.Gadget + "' \n");
                strSql.Append("SET @VNo =@ProductSubGrpId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.ProductSubGroup SET ProductSubGrpDesc='" + Model.ProductSubGrpDesc.Trim() + "',ProductSubGrpShortName = '" + Model.ProductSubGrpShortName.Trim() + "',ProductGrpId = '" + Model.ProductGrpId + "',[Status]='" + Model.Status.ToString().ToLower() + "' ,Gadget='" + Model.Gadget + "'  WHERE ProductSubGrpId = '" + Model.ProductSubGrpId + "' \n");
                strSql.Append("SET @VNo ='" + Model.ProductSubGrpId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.ProductSubGroup WHERE ProductSubGrpId = '" + Model.ProductSubGrpId + "' \n");
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
        public DataTable GetDataProductSubGroup(int ProductSubGrpId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select erp.ProductSubGroup.*,ProductGrpDesc from erp.ProductSubGroup left join erp.ProductGroup on erp.ProductSubGroup.ProductGrpId= erp.ProductGroup.ProductGrpId");
            if (ProductSubGrpId != 0)
                strSql.Append(" WHERE ProductSubGrpId='" + ProductSubGrpId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString ()).Tables[0];
        }
        
    }

    public class ProductSubGroupViewModel
    {
        public string Tag { get; set; }
        public int ProductSubGrpId { get; set; }
        public string ProductSubGrpDesc { get; set; }
        public string ProductSubGrpShortName { get; set; }
        public int ProductGrpId { get; set; }
        public string ProductGrpDesc { get; set; }
        public string ProductGrpShortName { get; set; }       
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }
}
