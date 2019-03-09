using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acmeweb.Controllers
{
    public class PurchaseEntryController : BaseController
    {
        // GET: PurchaseEntry
        public ActionResult Index()
        {
            return View();
        }
    }
}