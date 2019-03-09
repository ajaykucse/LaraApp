using DataAccessLayer.DataTransaction.Sales;
using System.Collections.Generic;
using System.Data;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseChallan;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseChallan
    {
        string IsExistsVNumber(string VoucherNo);
        PurchaseChallanMasterViewModel Model { get; set; }
        List<PurchaseChallanDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SavePurchaseChallan();
		string IsChallanUsedInBill(string VoucherNo);

		DataSet GetDataPurchaseChallanVoucher(string VoucherNo);
    }
}
