using DataAccessLayer.Common;
using DataAccessLayer.Interface.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acmeweb.Controllers
{
    public class LoginController : Controller
    {

        public IUserMaster _objUserMaster = new ClsUserMaster();
        public static string physicalWebRootPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ServerConnection.txt");
        public static string[] fileContents = System.IO.File.ReadAllLines(physicalWebRootPath);
        private readonly string _servername = fileContents[0].ToString();
        private readonly string _serverusername = fileContents[1].ToString();
        private readonly string _serverpass = fileContents[2].ToString();
        private readonly string _apiUrl = fileContents[3].ToString();
        // GET: Login
        
        public ActionResult Index()
        {
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
                return RedirectToAction("Index", "Server");
            }
        }

        public ActionResult UserLogin()
        {
            ViewData["msg"] = "";
            return PartialView("Index");
        }

        public ActionResult CheckUser()
        {
            string username = Request.Form["txtUserName"];
            string password = Request.Form["txtUserPassword"];
            DataTable dt = _objUserMaster.CheckUser(username, password);
            if (dt.Rows.Count == 1)
            {
                ClsGlobal.LoginUserCode = dt.Rows[0]["UserCode"].ToString();
                ClsGlobalSession._LoginUserCode = dt.Rows[0]["UserCode"].ToString();
                ClsGlobalSession._LoginUserName = username;
                ClsGlobalSession._CustomerCode = dt.Rows[0]["LedgerId"].ToString();
                ClsGlobalSession._UserType = dt.Rows[0]["UserType"].ToString();

                //TempData["LoginAddress"] = Request.Form["txtLoginAddress"];
                //TempData["IPAddress"] = Request.Form["txtIPAddress"];
                //TempData["NetworkName"] = Request.Form["txtNetworkName"];
                //TempData["Latitude"] = Request.Form["txtLatitude"];
                //TempData["Longitude"] = Request.Form["txtLongitude"];

                return RedirectToAction("Index", "Selection");
            }
            else
            {
                ViewData["msg"] = "Invalid User Name Or Password";
            }

            return PartialView("Index");
        }
    }
}