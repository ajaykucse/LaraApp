using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Sales
{
    public interface ISalesChallanReturn
    {
        string IsExistsVNumber(string VoucherNo);
        SalesChallanReturnMasterViewModel Model { get; set; }
        List<SalesChallanReturnDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SaveSalesChallanReturn();
        DataSet GetDataSalesChallanReturnVoucher(string VoucherNo);
        DataSet GetDataSalesChallanVoucherDataForReturn(string VoucherNo);
    }
}
