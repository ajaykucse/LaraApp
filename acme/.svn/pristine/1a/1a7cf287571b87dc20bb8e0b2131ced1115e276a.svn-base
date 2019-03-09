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
    public interface IDebitNoteVoucher
    {
        string IsExistsVNumber(string VoucherNo);
        DebitNoteMsaterViewModel Model { get; set; }
        List<DebitNoteDetailsViewModel> ModelDetails { get; set; }
        string SaveDebitNote();
        DataSet GetDataDebitNoteVoucher(string VoucherNo);
    }
}
