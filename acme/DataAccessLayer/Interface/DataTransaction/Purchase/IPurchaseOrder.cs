using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseOrder;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseOrder
    {
        string IsOrderNumberExists(string VoucherNo);
        PurchaseOrderMasterViewModel Model { get; set; }

        List<PurchaseOrderDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SavePurchaseOrder();
        DataSet GetDataPurchaseOrder(string VoucherNo);
		DataSet  GetDataOrderForPurchase(string OrderNo, string BillNo, string module);
		string IsOrderUsedInBill(string VoucherNo);
		string IsOrderUsedInChallan(string VoucherNo);

	}
}
