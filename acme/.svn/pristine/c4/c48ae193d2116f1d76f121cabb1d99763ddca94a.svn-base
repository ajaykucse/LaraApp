using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataTransaction.Purchase.clsPurchaseReturn;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseReturn
    {
        string IsExistsVNumber(string VoucherNo);
        PurchaseInvoiceReturnMasterViewModel Model { get; set; }
        List<PurchaseInvoiceReturnDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SavePurchaseReturn();
        DataSet GetDataPurchaseReturnVoucher(string VoucherNo);
        DataSet GetDataPurchaseInvoiceVoucherDataToReturn(string VoucherNo, string BillNo);
    }
}
