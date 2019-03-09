using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace acmeweb
{
    public class ClsGlobalSession
    {
        //public static string _ServerName
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["_ServerName"] == null)
        //            return string.Empty;
        //        else
        //            return HttpContext.Current.Session["_ServerName"].ToString();
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["_ServerName"] = value;
        //    }
        //}
        //public static string _ServerUserName
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["_ServerUserName"] == null)
        //            return string.Empty;
        //        else
        //            return HttpContext.Current.Session["_ServerUserName"].ToString();
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["_ServerUserName"] = value;
        //    }
        //}
        //public static string _ServerPassword
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["_ServerPassword"] == null)
        //            return string.Empty;
        //        else
        //            return HttpContext.Current.Session["_ServerPassword"].ToString();
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["_ServerPassword"] = value;
        //    }
        //}
        public static string _APIUrl
        {
            get
            {
                if (HttpContext.Current.Session["_APIUrl"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_APIUrl"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_APIUrl"] = value;
            }
        }
        public static string _DbName
        {
            get
            {
                if (HttpContext.Current.Session["_DbName"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_DbName"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_DbName"] = value;
            }
        }
        public static string _CompIniTial
        {
            get
            {
                if (HttpContext.Current.Session["_CompIniTial"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_CompIniTial"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_CompIniTial"] = value;
            }
        }
        public static string _CompName
        {
            get
            {
                if (HttpContext.Current.Session["_CompName"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_CompName"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_CompName"] = value;
            }
        }
        public static string _CompStartDate
        {
            get
            {
                if (HttpContext.Current.Session["_CompStartDate"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_CompStartDate"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_CompStartDate"] = value;
            }
        }
        public static string _CompEndDate
        {
            get
            {
                if (HttpContext.Current.Session["_CompEndDate"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_CompEndDate"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_CompEndDate"] = value;
            }
        }
        public static string _LoginUserCode
        {
            get
            {
                if (HttpContext.Current.Session["_LoginUserCode"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_LoginUserCode"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_LoginUserCode"] = value;
            }
        }
        public static string _LoginUserName
        {
            get
            {
                if (HttpContext.Current.Session["_LoginUserName"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_LoginUserName"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_LoginUserName"] = value;
            }
        }
        public static string _CustomerCode
        {
            get
            {
                if (HttpContext.Current.Session["_CustomerCode"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_CustomerCode"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_CustomerCode"] = value;
            }
        }

        public static string _UserType
        {
            get
            {
                if (HttpContext.Current.Session["_UserType"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["_UserType"].ToString();
            }
            set
            {
                HttpContext.Current.Session["_UserType"] = value;
            }
        }
    }
}