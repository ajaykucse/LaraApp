﻿using DataAccessLayer.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Sales
{
    public interface ISalesOrder
    {
        SalesOrderMasterViewModel Model { get; set; }
        List<SalesOrderDetailsViewModel> ModelDetails { get; set; }
        BillingAddressViewModel ModelBillAddress { get; set; }
        OtherDetailsViewModel ModelOtherDetails { get; set; }
        List<TermViewModel> ModelTerms { get; set; }
        string IsExistsVNumber(string VoucherNo);
		string IsOrderUsedInChallan(string VoucherNo);
		string IsOrderUsedInSalesBill(string VoucherNo);
		DataSet GetDataOrderVoucher(string VoucherNo);
		DataSet  GetDataOrderForSales(string VoucherNo, string BillNo, string module);

		string SaveSalesOrder();
        string GetOrderVoucherNo(int tableId);
        void DeleteOrderDetails(string voucherNo, string canceltype = "", string Sno = "");
        void UpdateOrderOnBillTermChange(string voucherNo);
        void CancelOrder(string voucherNo, int tableId, string remarks = "");
        void UpdateTransferTable(string voucherNo, int tableId, int transferTableId, string remarks = "");
    }
}
