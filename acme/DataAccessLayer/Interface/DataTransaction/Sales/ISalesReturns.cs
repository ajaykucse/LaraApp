using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Sales
{
	public interface ISalesReturns
	{
		string IsExistsVNumber(string VoucherNo);
		SalesReturnMasterViewModel Model { get; set; }
		List<SalesReturnDetailsViewModel> ModelDetails { get; set; }
		List<TermViewModel> ModelTerms { get; set; }
		BillingAddressViewModel ModelBillAddress { get; set; }
		OtherDetailsViewModel ModelOtherDetails { get; set; }
		SalesIrdViewModel SalesIrd { get; set; }
		string SaveSalesReturn();
		DataSet GetDataSalesReturnVoucher(string VoucherNo);
		DataSet GetDataSalesInvoiceVoucherDataToReturn(string VoucherNo, string BillNo);


	}
}
