using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Sales
{
    public interface ISalesChallan
    {
        string IsExistsVNumber(string VoucherNo);
		string IsChallanUsedInBill(string VoucherNo);

		SalesChallanMasterViewModel Model { get; set; }
        List<SalesChallanDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SaveSalesChallan();
        DataSet GetDataSalesChallanVoucher(string VoucherNo);
    }
}
