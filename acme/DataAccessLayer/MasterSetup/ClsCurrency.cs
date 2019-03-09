using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Interface.MasterSetup;
using System.Windows.Forms;

namespace DataAccessLayer.MasterSetup
{
    public class ClsCurrency : ICurrency
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public CurrencyViewModel Model { get; set; }
        public ClsCurrency()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CurrencyViewModel();
        }
        public string SaveCurrency()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @CurrencyId int=(select ISNULL((Select Top 1 max(cast(CurrencyId as int))  from ERP.Currency),0)+1) \n");
                strSql.Append("Insert into ERP.Currency(CurrencyId, CurrencyDesc, CurrencyShortName, CurrencyUnit, CurrencyRate, Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @CurrencyId,N'" + Model.CurrencyDesc.Trim().Replace("'", "''") + "',N'" + Model.CurrencyShortName.Trim().Replace("'", "''") + "',N'" + Model.CurrencyUnit.Trim().Replace("'", "''") + "'," + Model.CurrencyRate + ",'" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),Gadget='"+Model.Gadget+ "' \n");
                strSql.Append("SET @VNo =@CurrencyId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Currency SET CurrencyDesc=N'" + Model.CurrencyDesc.Trim().Replace("'", "''") + "',CurrencyShortName = N'" + Model.CurrencyShortName.Trim().Replace("'", "''") + "',CurrencyUnit = N'" + Model.CurrencyUnit.Trim().Replace("'", "''") + "',CurrencyRate = " + Model.CurrencyRate + ",[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='"+ Model.Gadget + "'  WHERE CurrencyId = '" + Model.CurrencyId + "' \n");
                strSql.Append("SET @VNo ='" + Model.CurrencyId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Currency WHERE CurrencyId = '" + Model.CurrencyId + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25)
            {
                Direction = ParameterDirection.Output
            };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }
        public DataTable GetDataCurrency(int CurrencyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ERP.Currency");
            if (CurrencyId != 0)
                strSql.Append(" WHERE CurrencyId='" + CurrencyId + "' ");
            return DAL.ExecuteDataset(CommandType.Text,strSql.ToString ()).Tables[0];
        }
        
    }
    public class CurrencyViewModel
    {
        public string Tag { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyDesc { get; set; }
        public string CurrencyShortName { get; set; }
        public string CurrencyUnit { get; set; }
        public decimal CurrencyRate { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }
}
