using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseQuotation;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseQuotation
    {
        string IsExistsVNumber(string VoucherNo);
		string IsQuotationUsedInChallan(string VoucherNo);
		string IsQuotationUsedInOrder(string VoucherNo);

		PurchaseQuotationMasterViewModel Model { get; set; }
        List<PurchaseQuotationDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SavePurchaseQuotation();
        DataSet GetDataPurchaseQuotationVoucher(string VoucherNo);
		DataSet GetDataPurchaseQuotationForOrder(string VoucherNo, string BillNo, string module);

	}
}
