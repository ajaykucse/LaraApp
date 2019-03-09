using DataAccessLayer.DataTransaction.Normal_Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Normal_Production
{
    public interface IBillOfMaterial
    {
        BillOfMaterialMasterViewModel Model { get; set; }
        List<BillOfMaterialDetailsViewModel> ModelDetails { get; set; }
		List<BillOfMaterialFinishedViewModel> ModelFinished { get; set; }
		string SaveBillOfMaterial();
        string IsExistsVNumber(string VoucherNo);
		DataSet GetDataBillOfMaterial(string VoucherNo);

	}
}
