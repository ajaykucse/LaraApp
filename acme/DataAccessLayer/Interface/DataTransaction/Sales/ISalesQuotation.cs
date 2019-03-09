using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Sales
{
   public  interface ISalesQuotation
    {
        string IsExistsVNumber(string VoucherNo);
		string IsQuotationUsedInOrder(string VoucherNo);
		string IsQuotationUsedInChallan(string VoucherNo);
		SalesQuotationMasterViewModel Model { get; set; }
        List<SalesQuotationDetailsViewModel> ModelDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        string SaveSalesQuotation();
        DataSet GetDataSalesQuotationVoucher(string VoucherNo);
		DataSet GetDataSalesQuotationForOrder(string VoucherNo, string BillNo, string module);

	}
}
