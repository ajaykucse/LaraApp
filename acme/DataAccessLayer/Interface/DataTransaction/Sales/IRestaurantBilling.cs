using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.DataTransaction.Sales
{
    public interface IRestaurantBilling
    {
        DataTable TableList(int FloorId = 0, string TableStatus = "" , string TableType="");
        DataTable FloorList();
        DataTable ProductList();
        DataSet GetSalesOrderByVoucherTableId(string TableId);
    }
}
