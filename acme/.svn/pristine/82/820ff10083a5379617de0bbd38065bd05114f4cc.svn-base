using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IProductScheme
    {       
         ProductSchemeViewModel Model { get; set; }
         List<ProductSchemeDetailsViewModel> DetailsSchemeModel { get; set; }
        string SaveProductScheme();
        DataSet GetDataProductScheme(int SchemeId);
        DataTable GetProduct(String ProductGrpId, String ProductSubGrpId);
        DataTable CurrentProductScheme(Int32 ProductId, Int32 branchId, Int32 CompanyUnitId);
    }
}
