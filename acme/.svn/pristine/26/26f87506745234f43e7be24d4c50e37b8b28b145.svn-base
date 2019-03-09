using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acmeweb.Controllers
{
    public class ResTabOrderController : BaseController
    {
        IRestaurantBilling _objRestaurantBilling = new ClsRestaurantBilling();
        // GET: ResTabOrder
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult TableList()
        {
            return PartialView("TableList");
        }

        public JsonResult TableListing(string TableStatus,int FloorId)
        {
            DataTable dtTableList = _objRestaurantBilling.TableList(FloorId);
            List<Dictionary<string, object>> rows = DataTableToDictionaryList(dtTableList);
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FloorListing()
        {
            DataTable dtTableList = _objRestaurantBilling.FloorList();
            List<Dictionary<string, object>> rows = DataTableToDictionaryList(dtTableList);
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProductList()
        {
            DataTable dtTableList = _objRestaurantBilling.ProductList();
            List<Dictionary<string, object>> rows = DataTableToDictionaryList(dtTableList);
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSalesOrderByVoucherTableId(string TableId)
        {
            DataSet ds = _objRestaurantBilling.GetSalesOrderByVoucherTableId(TableId);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            List<Dictionary<string, object>> lsts = new List<Dictionary<string, object>>();
            Dictionary<string, object> MasterLst;
            Dictionary<string, object> DetailLst;
            foreach (System.Data.DataRow dr in dt1.Rows)
            {
                MasterLst = new Dictionary<string, object>();
                List<Dictionary<string, object>> lstDetails = new List<Dictionary<string, object>>();

                IEnumerable<DataRow> query =
                from order in dt2.AsEnumerable()
                where order.Field<String>("VoucherNo") == dr["VoucherNo"].ToString()
                select order;

                // Create a table from the query.
                DataTable boundTable = query.CopyToDataTable<DataRow>();
                foreach (System.Data.DataRow dr1 in boundTable.Rows)
                {
                    DetailLst = new Dictionary<string, object>();
                    foreach (System.Data.DataColumn col1 in boundTable.Columns)
                    {
                        DetailLst.Add(col1.ColumnName, dr1[col1]);
                    }
                    lstDetails.Add(DetailLst);
                }

                foreach (System.Data.DataColumn col in dt1.Columns)
                {
                    MasterLst.Add(col.ColumnName, dr[col]);
                }
                MasterLst.Add("Details", lstDetails);
                lsts.Add(MasterLst);
            }
            return Json(lsts, JsonRequestBehavior.AllowGet);
        }

        public List<Dictionary<string, object>> DataTableToDictionaryList(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return rows;
        }
    }
}