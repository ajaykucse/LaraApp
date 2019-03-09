using DataAccessLayer.DataTransaction.Sales;
using System.Collections.Generic;
using System.Data;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseChallanReturn;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseChallanReturn
    {
        string IsExistsVNumber(string VoucherNo);
        PurchaseChallanReturnMasterViewModel Model { get; set; }
        List<PurchaseChallanReturnDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SavePurchaseChallanReturn();
        DataSet GetDataPurchaseChallanReturnVoucher(string VoucherNo);
        DataSet GetDataPurchaseChallanVoucherDataForReturn(string VoucherNo);
    }
}
