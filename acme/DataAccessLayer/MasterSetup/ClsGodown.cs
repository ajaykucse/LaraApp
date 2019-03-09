using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Interface.MasterSetup;

namespace DataAccessLayer.MasterSetup
{    
    public class ClsGodown : IGodown
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public GodownViewModel Model { get; set; }
        public ClsGodown()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new GodownViewModel();
        }

        public string SaveGodown()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @GodownId int=(select ISNULL((Select Top 1 max(cast(GodownId as int))  from ERP.Godown),0)+1) \n");
                strSql.Append("Insert into ERP.Godown(GodownId, GodownDesc, GodownShortName, Address, Country, PhoneNo, Fax, ContactPerson, ContactPersonAdd, ContPersonPhoneNo, LedgerId, Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("Select @GodownId,N'" + Model.GodownDesc.Trim().Replace("'", "''") + "',N'" + Model.GodownShortName.Trim().Replace("'", "''") + "',  " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + "," + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + "," + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.Fax == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + "," + ((Model.ContactPerson == "") ? "null" : "N'" + Model.ContactPerson.Trim().Replace("'", "''") + "'") + " , " + ((Model.ContactPersonAdd.Trim() == "") ? "null" : "N'" + Model.ContactPersonAdd.Trim().Replace("'", "''") + "'") + "," + ((Model.ContPersonPhoneNo.Trim() == "") ? "null" : "N'" + Model.ContPersonPhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", '" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "', GETDATE(),'" + Model.Gadget + "' \n");

                strSql.Append("SET @VNo =@GodownId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Godown SET GodownDesc=N'" + Model.GodownDesc.Trim().Replace("'", "''") + "',GodownShortName = N'" + Model.GodownShortName.Trim().Replace("'", "''") + "', Address=" + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",Country=" + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",PhoneNo=" + "" + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ",Fax=" + ((Model.Fax == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ",ContactPerson=" + ((Model.ContactPerson == "") ? "null" : "N'" + Model.ContactPerson.Trim().Replace("'", "''") + "'") + " , ContactPersonAdd=" + ((Model.ContactPersonAdd.Trim() == "") ? "null" : "N'" + Model.ContactPersonAdd.Trim().Replace("'", "''") + "'") + ",ContPersonPhoneNo=" + ((Model.ContPersonPhoneNo.Trim() == "") ? "null" : "N'" + Model.ContPersonPhoneNo.Trim().Replace("'", "''") + "'") + ",LedgerId=" + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", Status='" + Model.Status.ToString().ToLower() + "',EnterBy= '" + Model.EnterBy + "',Gadget='" + Model.Gadget + "' WHERE GodownId = '" + Model.GodownId + "' \n");
                strSql.Append("SET @VNo ='" + Model.GodownId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Godown WHERE GodownId = '" + Model.GodownId + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25);
            p[0].Direction = ParameterDirection.Output;
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }

        public DataTable GetDataGodown(int GodownId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.Godown.*,GLDesc from ERP.Godown left outer join ERP.Generalledger on ERP.Godown.ledgerId=ERP.Generalledger.LedgerId");
            if (GodownId != 0)
                strSql.Append(" WHERE GodownId='" + GodownId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString ()).Tables[0];
        }
        public void GetSingleGodown(string GodownDesc)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select GodownId,GodownDesc,GodownShortName from  ERP.Godown where GodownDesc='" + GodownDesc.Replace("'", "''") + "'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow ro in dt.Rows)
                {
                    Model.GodownId = Convert.ToInt32(ro["GodownId"].ToString());
                    Model.GodownDesc = ro["GodownDesc"].ToString(); if (ro["GodownId"] != DBNull.Value) Model.GodownId = Convert.ToInt32(ro["GodownId"].ToString());
                    if (ro["GodownDesc"] != DBNull.Value) Model.GodownDesc = ro["GodownDesc"].ToString();
                    if (ro["GodownShortName"] != DBNull.Value) Model.GodownShortName = ro["GodownShortName"].ToString();
                }
            }
        }
    }
    public class GodownViewModel
    {
        public string Tag { get; set; }
        public int GodownId { get; set; }
        public string GodownDesc { get; set; }
        public string GodownShortName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonAdd { get; set; }
        public string ContPersonPhoneNo { get; set; }
        public int LedgerId { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
