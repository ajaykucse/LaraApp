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
   public class ClsProductScheme : IProductScheme
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public ProductSchemeViewModel Model { get; set; }
        public List<ProductSchemeDetailsViewModel> DetailsSchemeModel { get; set; }      

        public ClsProductScheme()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new ProductSchemeViewModel();
            DetailsSchemeModel = new List<ProductSchemeDetailsViewModel>();
        }

        public string SaveProductScheme()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @SchemeId int=(select ISNULL((Select Top 1 max(SchemeId)  from ERP.SpecialRateSchemeMaster),0)+1) \n");
                strSql.Append("INSERT INTO [ERP].[SpecialRateSchemeMaster]([SchemeId],[SchemeName],[EnterBy],[EnterDate],[SchemeWise]) \n");
                strSql.Append("Select @SchemeId,'" + Model.SchemeName.Trim() + "'," + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",GETDATE(),'" + Model.SchemeWise + "' \n");
                                             
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE [ERP].[SpecialRateSchemeMaster] SET [SchemeName] = '" + Model.SchemeName + "', \n");
                strSql.Append("[EnterBy] = " + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",[EnterDate] = GETDATE(),[SchemeWise] = '" + Model.SchemeWise  + "'\n");
                strSql.Append("WHERE [SchemeId]= @SchemeId \n");
                strSql.Append("DELETE FROM [ERP].[[SpecialRateSchemeDetails]] WHERE SchemeId ='" + Model.SchemeId + "' \n");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM [ERP].[SpecialRateSchemeMaster] WHERE SchemeId ='" + Model.SchemeId + "' \n");
                strSql.Append("DELETE FROM [ERP].[SpecialRateSchemeDetails] WHERE SchemeId = '" + Model.SchemeId + "' \n");
                strSql.Append("SET @VoucherNo ='1'");
                DetailsSchemeModel.Clear();
            }
            foreach (ProductSchemeDetailsViewModel det in this.DetailsSchemeModel)
            {
                strSql.Append("INSERT INTO [ERP].[SpecialRateSchemeDetails]([SchemeId],[ProductId],[ProductGrpId],[ProductSubGrpId],[StartDate],[EndDate],[DiscountPercent],[SchemeRate],[BranchId],[CompanyUnitId]) \n");
                strSql.Append("Select @SchemeId,'" + det.ProductId + "'," + ((det.ProductGrpId == 0) ? "null" : "'" + det.ProductGrpId + "'") + "," + ((det.ProductSubGrpId == 0) ? "null" : "'" + det.ProductSubGrpId + "'") + ",'" + det.StartDate.ToString("yyyy-MM-dd") + "','" + det.EndDate.ToString("yyyy-MM-dd") + "','" + det.DiscountPercent + "','" + det.SchemeRate + "', " + ((det.BranchId == 0) ? "null" : "'" + det.BranchId + "'") + "," + ((det.CompanyUnitId == 0) ? "null" : "'" + det.CompanyUnitId + "'") + " \n");
            }
            this.DetailsSchemeModel.Clear();
            strSql.Append("SET @VNo =@SchemeId");

            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");


            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25)
            { Direction = ParameterDirection.Output };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }     
        public DataTable GetProduct(string  ProductGrpId,string ProductSubGrpId)  
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductId,ProductDesc,p.ProductGrpId,pg.ProductGrpDesc,p.ProductSubGrpId,PSG.ProductSubGrpDesc,0 as [Percent],P.SalesRate as Rate from  ERP.Product p Left Outer JOin ERP.ProductGroup PG on P.ProductGrpId=PG.ProductGrpId left Outer Join ERP.ProductSubGroup PSG on p.ProductSubGrpId=PSG.ProductSubGrpId where 1=1 ");
            if (ProductGrpId != "")
                strSql.Append(" and P.ProductGrpId in('" + ProductGrpId + "')");
            if (ProductSubGrpId != "")
                strSql.Append(" and P.ProductSubGrpId in('" + ProductSubGrpId + "')");

         
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
           

        }
        public DataSet GetDataProductScheme(int SchemeId) 
        {
            StringBuilder strSql = new StringBuilder();           
            strSql.Append("select * from  [ERP].[SpecialRateSchemeMaster] \n");
            strSql.Append("Where SchemeId = '" + SchemeId + "' \n\n");
            strSql.Append("select SSD.*,P.ProductDesc,PG.ProductGrpDesc,PSG.ProductSubGrpDesc from  ERP.SpecialRateSchemeDetails SSD \n");           
            strSql.Append("left outer join ERP.Product P on SSD.ProductId=P.ProductId \n");
            strSql.Append("Left Outer Join ERP.ProductGroup PG on SSD.ProductGrpId=PG.ProductGrpId \n");
            strSql.Append("Left Outer Join ERP.ProductSubGroup PSG on SSD.ProductSubGrpId=PSG.ProductSubGrpId \n");
            strSql.Append("Where SchemeId = '" + SchemeId + "'");        
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        public DataTable CurrentProductScheme(Int32 ProductId,Int32 branchId, Int32 CompanyUnitId )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [ERP].[SpecialRateSchemeDetails] where startDate < GetDate() and EndDate > GetDate() and  ProductId='"+ ProductId + "'");
            if(branchId!=0)
                strSql.Append(" and BranchId='" + branchId + "'");
            if (CompanyUnitId != 0) 
            strSql.Append(" and CompanyUnitId='" + CompanyUnitId + "'");
      
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
      
    }
    public class ProductSchemeViewModel
    {
        public string Tag { get; set; }
        public int SchemeId { get; set; }
        public string SchemeName { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }       
        public  string SchemeWise  {get;set;}
    }
    public class ProductSchemeDetailsViewModel
    {
        public int SchemeId { get; set; }
        public int ProductId { get; set; }
        public int ProductGrpId { get; set; }
        public int ProductSubGrpId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal SchemeRate { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }

    }

}
