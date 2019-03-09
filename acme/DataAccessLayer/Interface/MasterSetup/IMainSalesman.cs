using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IMainSalesman
    {
        MainSalesmanViewModel Model { get; set; }
        string SaveMainSalesman();
        DataTable GetDataMainSalesman(int MainSalesmanId);
    }
}
