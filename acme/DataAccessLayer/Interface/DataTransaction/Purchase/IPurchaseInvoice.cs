using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using System.Collections.Generic;
using System.Data;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseInvoice;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseInvoice
    {
        string IsExistsVNumber(string VoucherNo);
        PurchaseInvoiceMasterViewModel Model { get; set; }
        List<PurchaseInvoiceDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SavePurchaseInvoice();
        DataSet GetDataPurchaseVoucher(string VoucherNo);
        int GetPurchaseQuantityProductWise(string VoucherNo, int ProductId, int Sno);
    }
}
