using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace acmeweb.Controllers
{
    public class SelectionController : BaseController
    {
        DataAccessLayer.SystemSetting.ClsCompany _company = new DataAccessLayer.SystemSetting.ClsCompany();
        // GET: Selection
        public ActionResult Index()
        {
            ViewBag._CompanyList = _company.CompanyListByUserCode(ClsGlobalSession._LoginUserCode);
            return PartialView("CompanyList");
        }

        [HttpGet]
        public ActionResult ChooseCompany()
        {
            DataTable dataTable = _company.CompanyListByUserCode(ClsGlobalSession._LoginUserCode);
            DataRow[] result = dataTable.Select("IniTial='" + Request.QueryString["IniTial"] + "'");
            foreach (DataRow row in result)
            {
                ClsGlobalSession._CompName = row["Company Name"].ToString();
                ClsGlobalSession._CompStartDate = Convert.ToDateTime(row["Start Date"].ToString()).ToShortDateString();
                ClsGlobalSession._CompEndDate = Convert.ToDateTime(row["End Date"].ToString()).ToShortDateString();
            }
            ClsGlobalSession._DbName = Request.QueryString["DbName"];
            DataAccessLayer.Database._CompDatabaseName = Request.QueryString["DbName"];
            ClsGlobalSession._CompIniTial = Request.QueryString["IniTial"];

            // ClsGlobal.EntryControl("");

            if (ClsGlobalSession._UserType == "Waiter")
            {
                return RedirectToAction("TableList", "ResTabOrder");
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("<div class=\"collapse navbar-collapse js-navbar-collapse\"> \n");
                strSql.Append("<ul class=\"nav navbar-nav\"> \n");
                strSql.Append("<li class=\"dropdown\"> \n");

                #region ---------- HOME -----------
                strSql.Append("<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Home <b class=\"caret\"></b></a> \n");
                strSql.Append("<ul class=\"dropdown-menu\"> \n");
                strSql.Append("<li><a href=\"/dashboard/salesdashboard\">Dashboard</a></li> \n");
                strSql.Append("<li><a href=\"/opencompany/frmcompany\">Company Master</a></li> \n");
                strSql.Append("<li><a href=\"/opencompany\">Company Open</a></li> \n");
                strSql.Append("<li><a href=\"/opencompany/exit\">Exit</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                strSql.Append("</ul> \n");
                #endregion

                #region ---------- MASTER -----------
                strSql.Append("<ul class=\"nav navbar-nav\"> \n");
                strSql.Append("<li class=\"dropdown mega-dropdown\"> \n");
                strSql.Append("<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Master <span class=\"caret\"></span></a> \n");
                strSql.Append("<ul class=\"dropdown-menu mega-dropdown-menu megamenuBottomBrder\"> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Chart of Account</li> \n");
                strSql.Append("<li><a href=\"#\" url=\"/master/listaccountgroup\" class=\"mylayoutpage\">Account Group</a></li> \n");
                strSql.Append("<li><a href=\"#\" url=\"/master/listaccountsubgroup\" class=\"mylayoutpage\">Account Sub Group</a></li> \n");
                strSql.Append("<li><a href=\"/master/listgeneralledger\">General Ledger</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/subledger\">Subledger</a></li> \n");
                strSql.Append("<li><a href=\"#\">Ledger Unit Allocation</a></li> \n");
                strSql.Append("<li><a href=\"#\">Ledger Mapping</a></li> \n");
                strSql.Append("<li><a href=\"/FinanceEntry/LedgerOpeningBillWise\">Billwise Opeing</a></li> \n");
                strSql.Append("<li><a href=\"/FinanceEntry/LedgerOpening\">Ledger Opening</a></li> \n");

                strSql.Append("<li class=\"dropdown-header\">Division</li> \n");
                strSql.Append("<li><a href=\"/masterentry/divisiontype\">Type</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/divisionmaster\">Master</a></li> \n");

                strSql.Append("<li class=\"dropdown-header\">Restaurant</li> \n");
                strSql.Append("<li><a href=\"/masterentry/restaurantfloor\">Floor</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/restauranttablemaster\">Table Master</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Product</li> \n");
                strSql.Append("<li><a href=\"/itemproduct\">Item Product</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/productunit\">Unit</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/levels\">Level</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/subject\">Subject</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/language\">Language</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/bookslist\">Books</a></li> \n");

                strSql.Append("<li><a href=\"/masterentry/Advertisement\">Advertisements</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/OrderList\">Order Tracking</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/ReviewList\">Review Comments</a></li> \n");
                strSql.Append("<li><a href=\"/InventoryEntry/ProductOpening\">Product Opening</a></li> \n");


                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");

                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Billing Term</li> \n");
                strSql.Append("<li><a href=\"/masterentry/purchasebillingterm\">Purchase Term</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/salesbillingterm\">Sales Term</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Area/Salesman</li> \n");
                strSql.Append("<li><a href=\"/masterentry/region\">Region</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/mainarea\">Main Area</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/area\">Area</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/mainSalesman\">Main Salesman</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/Salesman\">Salesman</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Others</li> \n");
                strSql.Append("<li><a href=\"/masterentry/godown\">Godown</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/costcenter\">Cost Center</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/currency\">Currency</a></li> \n");
                strSql.Append("<li><a href=\"#\">Additional Fields</a></li> \n");
                strSql.Append("<li><a href=\"/masterentry/narrationmaster\">Narration/Remarks</a></li> \n");
                strSql.Append("<li><a href=\"#\">Copy Master</a></li> \n");
                strSql.Append("<li><a href=\"/listreport/listinggeneralledger\">Master Listing</a></li> \n");
                strSql.Append("<li><a href=\"/listreport/productaudit\">Product Audit</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">SMS</li> \n");
                strSql.Append("<li><a href=\"/utility/contactmaster\">Contact Master</a></li> \n");
                strSql.Append("<li><a href=\"/utility/smsapisetting\">SMS API Setting</a></li> \n");
                strSql.Append("<li><a href=\"/utility/sendsinglesms\">Send Single SMS</a></li> \n");
                strSql.Append("<li><a href=\"/utility/groupsmstemplate\">Group SMS Template</a></li> \n");
                strSql.Append("<li><a href=\"/utility/sendgroupsms\">Send Group SMS</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");

                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                #endregion

                #region ---------- AR/AP -----------
                strSql.Append("<ul class=\"nav navbar-nav\"> \n");
                strSql.Append("<li class=\"dropdown mega-dropdown\"> \n");
                strSql.Append("<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">AR/AP <span class=\"caret\"></span></a> \n");
                strSql.Append("<ul class=\"dropdown-menu mega-dropdown-menu megamenuBottomBrder\"> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Purchase Register</li> \n");
                strSql.Append("<li><a href=\"#############\">Indent</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Quotation</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Order</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Challan</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Quantity Control</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Invoice</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Return</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Additional Invoice</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Expiry & Breakage</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Inter Branch Invoice</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");

                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Sales Register</li> \n");
                strSql.Append("<li><a href=\"#############\">Quotation</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Order</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Order Dispatch</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Challan</a></li> \n");
                strSql.Append("<li><a href=\"#\" url=\"/arapreport/rptsalesregister\" class=\"mylayoutpage\">Invoice</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Goods Dispatch</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Return</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Additional Invoice</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Expiry & Breakage</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Inter Branch Invoice</a></li> \n");

                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");

                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Notes Register</li> \n");
                strSql.Append("<li><a href=\"#############\">Debit Notes</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Credit Notes</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Receipt & Payment Register</li> \n");
                strSql.Append("<li><a href=\"#############\">Vendor</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Party Ledger</li> \n");
                strSql.Append("<li><a href=\"#############\">Vendor</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Ageing Report</li> \n");
                strSql.Append("<li><a href=\"#############\">Vendor</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Ledger</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Outstanding Report</li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase Indent</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase Quotation</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase Order</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase Challan</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Sales Quotation</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Sales Order</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Dispatch Order</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Sales Challan</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Vendor</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Party Reconcile</li> \n");
                strSql.Append("<li><a href=\"#############\">Vendor</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Ledger</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Purchase Anaylsis</li> \n");
                strSql.Append("<li><a href=\"#############\">Area Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Salesman Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Product Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Company Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer Wise</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Sales Anaylsis</li> \n");
                strSql.Append("<li><a href=\"#############\">Area Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Salesman Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Product Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Company Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer Wise</a></li> \n");
                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");


                strSql.Append("<li class=\"col-sm-2\"> \n");
                strSql.Append("<ul> \n");
                strSql.Append("<li class=\"dropdown-header\">Price History</li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Sales</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">Profitability</li> \n");
                strSql.Append("<li><a href=\"#############\">Bill Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Customer Wise</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Vendor Wise</a></li> \n");
                strSql.Append("<li class=\"dropdown-header\">VAT Register</li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase VAT Register</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Purchase Return VAT Register</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Sales VAT Register</a></li> \n");
                strSql.Append("<li><a href=\"#############\">Sales Return VAT Register</a></li> \n");
                strSql.Append("<li><a href=\"#############\">VAT Register</a></li> \n");

                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");

                strSql.Append("</ul> \n");
                strSql.Append("</li> \n");
                #endregion

                strSql.Append("<li><a href=\"/Dashboard/Help\" tabindex=\"-1\">Help</a></li> \n");

                strSql.Append("<li><a href=\"/Dashboard/Help\" tabindex=\"-1\"><span class=\"glyphicon glyphicon-bell\" aria-hidden=\"true\" style=\"color:yellow\"></span></a></li> \n");

                strSql.Append("</ul> \n");
                strSql.Append("</div> \n");
                Session["MenuList"] = strSql.ToString();
                return RedirectToAction("SalesDashBoard", "Dashboard");
            }
        }
    }
}