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
    public class ClsProductUnit : IProductUnit
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public ProductUnitViewModel Model { get; set; }
        public ClsProductUnit()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new ProductUnitViewModel();
        }
        public string SaveProductUnit()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @ProductUnitId int=(select ISNULL((Select Top 1 max(cast(ProductUnitId as int))  from ERP.ProductUnit),0)+1) \n");
                strSql.Append("Insert into ERP.ProductUnit(ProductUnitId, ProductUnitDesc, ProductUnitShortName, [Status], EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @ProductUnitId,'" + Model.ProductUnitDesc.Trim() + "','" + Model.ProductUnitShortName.Trim() + "','" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE() ,'" + Model.Gadget + "'\n");
                strSql.Append("SET @VNo =@ProductUnitId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.ProductUnit SET ProductUnitDesc='" + Model.ProductUnitDesc.Trim() + "',ProductUnitShortName = '" + Model.ProductUnitShortName.Trim() + "',[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='" + Model.Gadget + "'  WHERE ProductUnitId = '" + Model.ProductUnitId + "' \n");
                strSql.Append("SET @VNo ='" + Model.ProductUnitId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.ProductUnit WHERE ProductUnitId = '" + Model.ProductUnitId + "' \n");
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
        public DataTable GetDataProductUnit(int ProductUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ERP.ProductUnit ");
            if (ProductUnitId != 0)
                strSql.Append(" WHERE ProductUnitId='" + ProductUnitId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString ()).Tables[0];
        }
        public DataTable ComboBindProductUnit(int ProductUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select  '' as ProductUnitId, '' as ProductUnitShortName  Union all  select ProductUnitId, ProductUnitShortName from erp.ProductUnit  ");
            if (ProductUnitId != 0)
                strSql.Append(" WHERE ProductUnitId<>'" + ProductUnitId + "' ");
            strSql.Append("Order by ProductUnitShortName ");

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString ()).Tables[0];
        }
    }

    public class ProductUnitViewModel
    {
        public string Tag { get; set; }
        public int ProductUnitId { get; set; }
        public string ProductUnitDesc { get; set; }
        public string ProductUnitShortName { get; set; }        
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
