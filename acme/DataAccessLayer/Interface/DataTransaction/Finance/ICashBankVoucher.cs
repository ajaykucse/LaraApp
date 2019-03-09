using DataAccessLayer.DataTransaction.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Finance
{
    public interface ICashBankVoucher
    {
        string IsExistsVNumber(string VoucherNo);
        CashBankMsaterViewModel Model { get; set; }
        List<CashBankDetailsViewModel> ModelDetails { get; set; }
        string SaveCashBank();
        DataSet GetDataCashBankVoucher(string VoucherNo);
    }
}
