using DataAccessLayer.Interface.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MasterSetup
{
   
    public class ClsTable : ITableMaster
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public TableViewModel Model { get; set; }
        public ClsTable()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new TableViewModel();
        }

        public string SaveTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @TableId int=(select ISNULL((Select Top 1 max(cast(TableId as int))  from ERP.TableMaster),0)+1) \n");
                strSql.Append("INSERT INTO [ERP].[TableMaster]([TableId],[TableDesc],[TableShortName],[FloorId],[TableType],[TableStatus],[Status],[EnterBy],[EnterDate],Gadget)\n");
                strSql.Append("Select @TableId,N'" + Model.TableDesc.Trim().Replace("'", "''") + "',N'" + Model.TableShortName.Trim().Replace("'", "''") + "' ,'" + Model.FloorId + "' ,'"+ Model.TableType + "','"+ Model.TableStatus + "','" + Model.Status.ToString() + "','" + Model.EnterBy + "',GETDATE(),'" + Model.Gadget + "'\n");
                strSql.Append("SET @VNo =@TableId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.TableMaster SET TableDesc=N'" + Model.TableDesc.Trim().Replace("'", "''") + "',TableShortName = N'" + Model.TableShortName.Trim().Replace("'", "''") + "',FloorId='"+ Model.FloorId + "',TableType='" + Model.TableType + "',TableStatus='"+Model.TableStatus+"',[Status]='" + Model.Status.ToString().ToLower() + "' WHERE TableId = '" + Model.TableId + "' \n");
                strSql.Append("SET @VNo ='" + Model.TableId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.TableMaster WHERE TableId = '" + Model.TableId + "' \n");
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
        public DataTable GetDataTable(int TableId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.TableMaster.*,FloorDesc from  ERP.TableMaster LEFT OUTER JOIN ERP.Floor ON ERP.Floor.FloorId=ERP.TableMaster.FloorId ");
            if (TableId != 0)
                strSql.Append("WHERE TableId='" + TableId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable GetSplitTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from   ERP.TableMaster where TableDesc like 'Split%' and TableStatus ='A' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public DataTable GetMergeTable(int TableId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from   ERP.TableMaster where TableId <> "+ TableId + "and TableStatus ='O'  order by TableDesc,floorId");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable GetTransferTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from   ERP.TableMaster where TableDesc not like 'Split%' and TableStatus ='A' order by TableDesc, FloorId ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        
    }
    public class TableViewModel
    {
        public string Tag { get; set; }
        public  int TableId { get; set; }
        public  string TableDesc { get; set; }
        public  string TableShortName { get; set; }
        public  int FloorId { get; set; }
        public  string TableType { get; set; }
        public  string TableStatus { get; set; }
        public  bool Status { get; set; }
        public  string EnterBy { get; set; }
        public  DateTime EnterDate { get; set; }
        public string Gadget { get; set; }

    }
}
