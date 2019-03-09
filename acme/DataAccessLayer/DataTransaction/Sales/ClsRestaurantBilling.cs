using DataAccessLayer.Interface.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTransaction.Sales
{
    public class ClsRestaurantBilling : IRestaurantBilling
    {
        ActiveDataAccess.ActiveDataAccess DAL;

        public ClsRestaurantBilling()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
        }

        public DataTable TableList(int FloorId = 0, string TableStatus="", string TableType = "")
        {
            if (FloorId == 0)
            {
                if (!string.IsNullOrEmpty(TableStatus))
                    return DAL.ExecuteDataset(CommandType.Text, "select 0 as Tag, TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc like 'SPlit%' and TableStatus='" + TableStatus + "'  union all select 1 as Tag ,TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc not like 'SPlit%' and TableStatus='" + TableStatus + "'  order by Tag,FloorId,TableDesc ").Tables[0];
                else if (!string.IsNullOrEmpty(TableType))
                    return DAL.ExecuteDataset(CommandType.Text, "select 0 as Tag, TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc like 'SPlit%' and TableType='" + TableType + "'  union all select 1 as Tag ,TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc not like 'SPlit%' and TableType='" + TableType + "'  order by Tag,FloorId,TableDesc ").Tables[0];
                else
                    return DAL.ExecuteDataset(CommandType.Text, "select 0 as Tag, TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc like 'SPlit%' union all select 1 as Tag ,TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc not like 'SPlit%'  order by Tag,FloorId,TableDesc ").Tables[0];
            }
            else
            {
                if (!string.IsNullOrEmpty(TableStatus))
                    return DAL.ExecuteDataset(CommandType.Text, "select 0 as Tag, TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc like 'SPlit%' and TableStatus='" + TableStatus + "' union all select 1 as Tag ,TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc not like 'SPlit%' and  FloorId='" + FloorId + "' and TableStatus='" + TableStatus + "'  order by Tag,TableDesc ").Tables[0];
                else if (!string.IsNullOrEmpty(TableType))
                    return DAL.ExecuteDataset(CommandType.Text, "select 0 as Tag, TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc like 'SPlit%' and TableType='" + TableType + "' union all select 1 as Tag ,TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc not like 'SPlit%' and  FloorId='" + FloorId + "' and TableType='" + TableType + "'  order by Tag,TableDesc ").Tables[0];
                else
                    return DAL.ExecuteDataset(CommandType.Text, "select 0 as Tag, TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc like 'SPlit%' and TableStatus='" + TableStatus + "' union all select 1 as Tag ,TableId,TableDesc,TableStatus,FloorId from ERP.TableMaster where TableDesc not like 'SPlit%' and  FloorId='" + FloorId + "'  order by Tag,TableDesc ").Tables[0];
            }
        }

        public DataTable FloorList()
        {
            return DAL.ExecuteDataset(CommandType.Text, "select FloorId,FloorDesc from ERP.[Floor] ORDER BY FloorId").Tables[0];
        }

        public DataTable ProductList()
        {
            return DAL.ExecuteDataset(CommandType.Text, "select ProductId,ProductDesc,ProductShortName,CONVERT(DECIMAL(10,2),SalesRate) as SalesRate from ERP.Product WHERE PGrpId2 in(select ProductGrpId from erp.productgroup2 where ProductGrpDesc='Restaurant Item')").Tables[0];
        }

        public DataSet GetSalesOrderByVoucherTableId(string TableId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @VoucherNo varchar(15) = (select VoucherNo from ERP.SalesOrderMaster WHERE TableId='" + TableId + "' and ResIsCurrentOrder='Y') \n");
            strSql.Append("Select VoucherNo FROM ERP.SalesOrderMaster where VoucherNo=@VoucherNo \n");
            strSql.Append("Select [SOD].VoucherNo,[SOD].Qty,[SOD].ProductId,ProductShortName,ProductDesc from ERP.SalesOrderDetails[SOD] \n");
            strSql.Append("left join ERP.Product PD on[SOD].ProductId = PD.ProductId \n");
            strSql.Append("where VoucherNo=@VoucherNo \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
    }
}
