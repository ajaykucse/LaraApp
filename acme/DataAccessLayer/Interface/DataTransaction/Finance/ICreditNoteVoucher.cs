using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Finance
{
    public interface ICreditNoteVoucher
    {
        string IsExistsVNumber(string VoucherNo);
        CreditNoteMsaterViewModel Model { get; set; }
        List<CreditNoteDetailsViewModel> ModelDetails { get; set; }
        string SaveCreditNote();
        DataSet GetDataCreditNoteVoucher(string VoucherNo);
    }
}
