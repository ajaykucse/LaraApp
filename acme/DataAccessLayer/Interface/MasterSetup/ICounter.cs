using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface ICounter
    {
        DataAccessLayer.MasterSetup.CounterViewModel Model { get; set; }
        string SaveCounter();
        DataTable GetDataCounter(int CounterId);
        DataTable GetDataCounterList();
    }
}
