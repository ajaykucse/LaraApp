using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IProduct
    {
        DataAccessLayer.MasterSetup.ProductViewModel Model { get; set; }
        List<DataAccessLayer.MasterSetup.PurchaseProductTerm> ModelPurchaseProductTerm { get; set; }
        List<DataAccessLayer.MasterSetup.SalesProductTerm> ModelSalesProductTerm { get; set; }
        List<DataAccessLayer.MasterSetup.ProductMappingList> ModelProductMappingList { get; set; }
        string SaveProduct();
        DataSet GetDataProduct(int ProductId);
        int UdfCheck();
        DataTable ProductListForImportFormat();
        void GetSingleProduct(string ProductDesc);
        string ProductAdditionalDesc(string ProductId);
        void UpdateProductPrintingName(string ProductId, string ProductPrintingName);
        //------------ START PRODUCT MAPPING --------
        void SaveProductMapping(string Module);
        DataTable ProductGroupListForProductMapping(string ProductGrpId);
        DataTable ProductSubGroupListForProductMapping(string ProductSubGrpId);
        DataTable BranchListForProductMapping(string BranchId);
        DataTable CompanyUnitListForProductMapping(string CompanyUnitId);
        DataTable ProductBranchRate(string ProductId, string BranchId);
        DataTable GetProductFromShortName(string ProductShortname);
        //------------ END PRODUCT MAPPING --------
    }
}
