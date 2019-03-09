using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseIndent;

namespace DataAccessLayer.Interface.DataTransaction.Purchase
{
    public interface IPurchaseIndent
    {

        string IsExistsVNumber(string VoucherNo);
		string IsIndentUsedInOrder(string VoucherNo);
		string IsIndentUsedInQuotation(string VoucherNo);

		PurchaseIndentMasterViewModel Model { get; set; }
        List<PurchaseIndentDetailsViewModel> ModelDetails { get; set; }
        string SavePurchaseIndent();
        DataSet GetDataPurchaseIndentVoucher(string VoucherNo);
    }
}
