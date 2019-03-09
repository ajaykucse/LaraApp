using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface ICurrency
    {
        DataAccessLayer.MasterSetup.CurrencyViewModel Model { get; set; }
        string SaveCurrency();
        DataTable GetDataCurrency(int CurrencyId);
    }
}
