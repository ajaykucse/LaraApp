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
    public interface IJournalVoucher
    {
        string IsExistsVNumber(string VoucherNo);
        JournalMsaterViewModel Model { get; set; }
        List<JournalDetailsViewModel> ModelDetails { get; set; }
        string SaveJournal();
        DataSet GetDataJournal(string VoucherNo);
    }
}
