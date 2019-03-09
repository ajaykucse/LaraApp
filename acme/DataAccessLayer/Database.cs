﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Database
    {
        public static string _ServerName="";
        public static string _ServerUserName="";
        public static string _ServerPassword = "";
        public static string _CompDatabaseName = "MyMaster";

        public static string DBConnection
        {
            get { return "Data Source=" + _ServerName + "; User ID=" + _ServerUserName + "; Password=" + _ServerPassword + "; Persist Security Info=True; Initial Catalog=" + _CompDatabaseName + "; Max Pool Size=100;"; }
        }
        public static bool ConnectionCheck(string sname, string suname, string spass)
        {
            try
            {
                string constr = @"Data Source=" + sname + ";Initial Catalog=MyMaster;Persist Security Info=True;User ID=" + suname + ";Password=" + spass + "";
                SqlConnection Con = new SqlConnection(constr);
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                Con.Open();
                if (Con.State == ConnectionState.Open)
                {
                    _ServerName = sname;
                    _ServerUserName = suname;
                    _ServerPassword = spass;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static SqlConnection Connection()
        {
            string constring = "data source=" + _ServerName + "; Initial Catalog=" + _CompDatabaseName + "; User Id=" + _ServerUserName + "; pwd=" + _ServerPassword + "; Integrated Security=false;pooling=false;connection lifetime=15000;";
            SqlConnection Con = new SqlConnection(constring);
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();

            return Con;
        }
        public static SqlConnection MasterConnection()
        {

            string constring = @"Data Source=" + _ServerName + ";Initial Catalog=MyMaster;Persist Security Info=True;User ID=" + _ServerUserName + ";Password=" + _ServerPassword + ";Connection Timeout=1000";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = constring;
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
            return Con;
        }
        public static string GetSqlMasterData(string Sql)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(Sql, MasterConnection());
                cmd.CommandTimeout = 500;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
