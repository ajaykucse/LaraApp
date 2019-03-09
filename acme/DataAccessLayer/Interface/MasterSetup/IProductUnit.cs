using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IProductUnit
    {
        ProductUnitViewModel Model { get; set; }
        string SaveProductUnit();
        DataTable GetDataProductUnit(int ProductUnitId);
        DataTable ComboBindProductUnit(int ProductUnitId);
    }
}
