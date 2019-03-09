using DataAccessLayer.ARAPReport;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.ARAPReport;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acmeweb.Controllers
{
    public class ARAPReportController : BaseController
    {
        IAccountGroup _objAccountGroup = new ClsAccountGroup();
        IRptSalesRegister _objRptSalesRegister = new ClsRptSalesRegister();
        ClsCommon _objCommon = new ClsCommon();

        // GET: ARAPReport
        public ActionResult Index()
        {
            return View();
        }

        #region ------- ACCOUNT GROUP -------------
        [System.Web.Http.HttpPost]
        public ActionResult RptSalesRegister()
        {
            ViewBag._ShowModal = "Yes";
            return PartialView("RptSalesRegister", _objAccountGroup.GetDataAccountGroupList(0));
        }
        #endregion
    }
}