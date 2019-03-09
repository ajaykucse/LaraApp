using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acmeweb.Controllers
{
    public class ServerController : Controller
    {
        public static string physicalWebRootPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ServerConnection.txt");
        public static string[] fileContents = System.IO.File.ReadAllLines(physicalWebRootPath);

        string _servername = fileContents[0].ToString();
        string _serverusername = fileContents[1].ToString();
        string _serverpass = fileContents[2].ToString();
        string _apiUrl = fileContents[3].ToString();

        // GET: Server
        public ActionResult Index()
        {
            ViewData["servername"] = _servername;
            ViewData["serverusername"] = _serverusername;
            ViewData["serverpass"] = _serverpass;
            ViewData["msg"] = "";
            return PartialView();
        }

        public ActionResult ConnectToServer()
        {
            _servername = Request.Form["txtServerName"];
            _serverusername = Request.Form["txtServerUserName"];
            _serverpass = Request.Form["txtServerPassword"];
            bool ConCheck = DataAccessLayer.Database.ConnectionCheck(_servername, _serverusername, _serverpass);
            if (ConCheck == true)
            {
                //ClsGlobalSession._ServerName = _servername;
                //ClsGlobalSession._ServerUserName = _serverusername;
                //ClsGlobalSession._ServerPassword = _serverpass;
                ClsGlobalSession._APIUrl = _apiUrl;
                //UpdateCompany updateCompany = new UpdateCompany();
                //updateCompany.CreateAlterMasterTable();
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                ViewData["servername"] = _servername;
                ViewData["serverusername"] = _serverusername;
                ViewData["serverpass"] = _serverpass;
                ViewData["msg"] = "Cannot connect to " + _servername + ".";
            }
            return PartialView("Index");
        }
    }
}