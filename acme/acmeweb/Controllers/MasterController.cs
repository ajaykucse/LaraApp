using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
namespace acmeweb.Controllers
{
    public class MasterController : BaseController
    {
        IAccountGroup _objAccountGroup = new ClsAccountGroup();
        IAccountSubGroup _objAccountSubGroup = new ClsAccountSubGroup();
        ClsCommon _objCommon = new ClsCommon();

        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region ------- ACCOUNT GROUP -------------
        [System.Web.Http.HttpPost]
        public ActionResult ListAccountGroup()
        {
            return PartialView("ListAccountGroup", _objAccountGroup.GetDataAccountGroupList(0));
        }

        [System.Web.Http.HttpPost]
        public PartialViewResult FrmAccountGroup()
        {
            string _Id = string.IsNullOrEmpty(Request.QueryString["Id"]) ? "0" : Request.QueryString["Id"];
            string _Tag = string.IsNullOrEmpty(Request.QueryString["Tag"]) ? "NEW" : Request.QueryString["Tag"];
            return PartialView("FrmAccountGroup", _objAccountGroup.GetDataAccountGroupList(Convert.ToInt32(_Id), _Tag));
        }

        [System.Web.Http.HttpPost]
        public ActionResult SaveAccountGroup([FromBody] AccountGroupViewModel model)
        {
            _objAccountGroup.Model = model;
            ViewBag._Result = _objAccountGroup.SaveAccountGroup();
            return PartialView("Result");
        }
        #endregion

        #region ------- ACCOUNT SUB GROUP -------------
        [System.Web.Http.HttpPost]
        public ActionResult ListAccountSubGroup()
        {
            return PartialView("ListAccountSubGroup", _objAccountSubGroup.GetDataAccountSubGroupList(0));
        }
        [System.Web.Http.HttpPost]
        public PartialViewResult FrmAccountSubGroup()
        {
            string _Id = string.IsNullOrEmpty(Request.QueryString["Id"]) ? "0" : Request.QueryString["Id"];
            string _Tag = string.IsNullOrEmpty(Request.QueryString["Tag"]) ? "NEW" : Request.QueryString["Tag"];
            return PartialView("FrmAccountSubGroup", _objAccountSubGroup.GetDataAccountSubGroupList(Convert.ToInt32(_Id), _Tag));
        }

        [System.Web.Http.HttpPost]
        public ActionResult SaveAccountSubGroup([FromBody] AccountSubGroupViewModel model)
        {
            _objAccountSubGroup.Model = model;
            ViewBag._Result = _objAccountSubGroup.SaveAccountSubGroup();
            return PartialView("Result");
        }
        #endregion

        public ActionResult ListGeneralLedger()
        {
            return View("ListGeneralLedger");
        }
    }
}
