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
    public class ClsUdfMaster : IUdfMaster
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public UdfMasterViewModel Model { get; set; }
        public List<UDFDetailsEntryViewModel> ModelUDFDetailsEntry { get; set; }
        public ClsUdfMaster()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new UdfMasterViewModel();
            ModelUDFDetailsEntry = new List<UDFDetailsEntryViewModel>();
        }
        public DataSet GetDataUDFMaster(int UDFCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ERP.UDFMasterEntry");
            if (UDFCode != 0)
                strSql.Append(" WHERE UDFCode='" + UDFCode + "' ");

            strSql.Append(" select * from ERP.UDFDetailsEntry");
            if (UDFCode != 0)
                strSql.Append(" WHERE UDFCode='" + UDFCode + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public string SaveUdfMaster()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @UDFCode int =(select ISNULL((Select Top 1 max(cast(UDFCode as int))  from ERP.UDFMasterEntry),0)+1 ) \n");
                strSql.Append("INSERT INTO ERP.UDFMasterEntry(UDFCode, EntryModule, FieldName, FieldType, FieldWidth, MandotaryOpt, DateFormat, FieldDecimal, UdfPosition,AllowDuplicate,EnterBy,EnterDate,Gadget) \n");
                strSql.Append("Select @UDFCode,'" + Model.EntryModule.Trim() + "','" + Model.FieldName.Trim() + "','" + Model.FieldType.Trim() + "','" + Model.FieldWidth + "','" + Model.MandotaryOpt + "','" + Model.DateFormat + "','" + Model.FieldDecimal + "','" + Model.UdfPosition + "','" + Model.AllowDuplicate + "','" + Model.EnterBy.Trim() + "',GETDATE(),'" + Model.Gadget + "'\n");
                strSql.Append("DELETE FROM ERP.UDFDetailsEntry WHERE UDFCode=@UDFCode \n");
                foreach (UDFDetailsEntryViewModel dr in this.ModelUDFDetailsEntry)
                {
                    strSql.Append("INSERT INTO ERP.UDFDetailsEntry(UDFCode,EntryModule,FieldName,ListName) \n");
                    strSql.Append("Select @UDFCode,'" + Model.EntryModule + "','" + Model.FieldName + "','" + dr.ListName + "'\n");
                }
                strSql.Append("SET @VNo =@UDFCode");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("DELETE FROM ERP.UDFDetailsEntry WHERE UDFCode='" + Model.UDFCode + "' \n");
                strSql.Append("Update ERP.UDFMasterEntry set FieldName='" + Model.FieldName.Trim() + "', FieldType='" + Model.FieldType.Trim() + "', FieldWidth='" + Model.FieldWidth + "', MandotaryOpt='" + Model.MandotaryOpt + "', DateFormat='" + Model.DateFormat + "', FieldDecimal='" + Model.FieldDecimal + "', UdfPosition='" + Model.UdfPosition + "', AllowDuplicate='" + Model.AllowDuplicate + "',Gadget='"+ Model.Gadget + "' where UDFCode='" + Model.UDFCode + "' \n");
                foreach (UDFDetailsEntryViewModel dr in this.ModelUDFDetailsEntry)
                {
                    strSql.Append("INSERT INTO ERP.UDFDetailsEntry(UDFCode,EntryModule,FieldName,ListName) \n");
                    strSql.Append("Select '" + Model.UDFCode + "','" + Model.EntryModule.Trim() + "','" + Model.FieldName.Trim() + "','" + dr.ListName.Trim() + "'\n");
                }
                strSql.Append("SET @VNo ='" + Model.UDFCode + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.UDFDetailsEntry WHERE UDFCode = '" + Model.UDFCode + "' \n");
                strSql.Append("DELETE FROM ERP.UDFMasterEntry WHERE UDFCode = '" + Model.UDFCode + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
            this.ModelUDFDetailsEntry.Clear();
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
        public int CheckDuplicatePosition(string Position, string EntryModule)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "SELECT TOP 1 UdfPosition FROM ERP.UDFMasterEntry WHERE UdfPosition='" + Position + "' AND EntryModule='" + EntryModule + "'").Tables[0];
            return dt.Rows.Count;
        }
        //--------------------
       
        public DataSet Get(string UDFCode = "", string FieldName = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from [ERP].[UDFMasterEntry]  \n");
            if (!string.IsNullOrEmpty(UDFCode)) strSql.Append("where UDFCode = '" + UDFCode + "' \n");

            if (!string.IsNullOrEmpty(UDFCode))
                strSql.Append("select ListName from [ERP].[UDFDetailsEntry] WHERE UDFCode='" + UDFCode + "'  \n");

            if (!string.IsNullOrEmpty(FieldName))
                strSql.Append("select ListName from [ERP].[UDFDetailsEntry] WHERE FieldName='" + FieldName + "'  \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public void GetSingle(string UDFCode = "")
        {
            DataSet dtset = Get(UDFCode);
            DataTable dtMaster = dtset.Tables[0];
            DataTable dtDetail = dtset.Tables[1];

            UDFDetailsEntryViewModel UDFDetls = null;

            foreach (DataRow ro in dtMaster.Rows)
            {
                //if (ro["UDFCode"] != DBNull.Value) this.UDFDetails.UDFCode = ro["UDFCode"].ToString();
                //if (ro["EntryModule"] != DBNull.Value) this.EntryModule = ro["EntryModule"].ToString();
                //if (ro["FieldName"] != DBNull.Value) this.FieldName = ro["FieldName"].ToString();
                //if (ro["FieldType"] != DBNull.Value) this.FieldType = ro["FieldType"].ToString();
                //if (ro["TotalWidth"] != DBNull.Value) this.TotalWidth = ro["TotalWidth"].ToString();
                //if (ro["MandotaryOpt"] != DBNull.Value) this.MandotaryOpt = ro["MandotaryOpt"].ToString();
                //if (ro["DateFormat"] != DBNull.Value) this.DateFormat = ro["DateFormat"].ToString();
                //if (ro["FieldDecimal"] != DBNull.Value) this.FieldDecimal = ro["FieldDecimal"].ToString();
                //if (ro["UdfSchedule"] != DBNull.Value) this.UdfSchedule = int.Parse(ro["UdfSchedule"].ToString());
                //if (ro["DuplicateOpt"] != DBNull.Value) this.DuplicateOpt = ro["DuplicateOpt"].ToString();

                //foreach (DataRow rodet in dtDetail.Rows)
                //{
                //    UDFDetls = new UDFDetails();
                //    if (rodet["List_Name"] != DBNull.Value) UDFDetails.List_Name = rodet["List_Name"].ToString();
                //    this.Model.Add(UDFDetls);
                //}
            }
        }
        public DataTable GetByEntryModule(string UDFEntryModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [ERP].[UDFMasterEntry] where EntryModule='" + UDFEntryModule + "' order by UdfPosition");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable GetCodeByEntryModule(string UDFEntryModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UDFCode from [ERP].[UDFMasterEntry] where EntryModule='" + UDFEntryModule + "' order by UdfPosition");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable GetByFieldName(string fieldName, string UDFEntryModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [ERP].[UDFMasterEntry] where FieldName='" + fieldName + "' and EntryModule='" + UDFEntryModule + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public int CheckDuplicateRecord(string FieldName, string EntryModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 FieldName from [ERP].[UDFMasterEntry] where FieldName='" + FieldName + "' and EntryModule='" + EntryModule + "' \n");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }
        public int CheckDuplicateSchedule(string Schedule, string EntryModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 UdfSchedule FROM [ERP].[UDFMasterEntry] WHERE UdfSchedule='" + Schedule + "' AND EntryModule='" + EntryModule + "' \n");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }
        public string GetId(string UDF_Desc, string EntryModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 UDFCode from [ERP].[UDFMasterEntry] where [FieldName]='" + UDF_Desc + "' and EntryModule='" + EntryModule + "' \n");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return dt.Rows[0]["UDFCode"].ToString();
        }
        public int Delete(string UDFCode)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Delete from [ERP].[UDFDetailsEntry] Where UDFCode = '" + UDFCode + "' \n");
                strSql.Append("Delete from [ERP].[UDFMasterEntry] Where UDFCode = '" + UDFCode + "' \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int CheckUDFExists(string EntryModule)

        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select UDFCode from [ERP].[UDFMasterEntry] where EntryModule='" + EntryModule + "'").Tables[0];
            return dt.Rows.Count > 0 ? 1 : 0;
        }
        public DataTable GetUDF(string UDFType, string VoucherNo)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT UDFCode,UDFData FROM ERP.UDFDataEntry WHERE EntryModule='" + UDFType + "' AND SNO='0'  AND VoucherNo='" + VoucherNo + "'").Tables[0];
        }

        public DataTable GetUDFDataByCode(string UDFType, string UDFCode)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT UDFCode,UDFData FROM ERP.UDFDataEntry WHERE EntryModule='" + UDFType + "' AND SNO='0'  AND UDFCode='" + UDFCode + "'").Tables[0];
        }
    }

    public class UdfMasterViewModel
    {
        public string Tag { get; set; }
        public int UDFCode { get; set; }
        public string EntryModule { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldWidth { get; set; }
        public string MandotaryOpt { get; set; }
        public int UdfPosition { get; set; }
        public string AllowDuplicate { get; set; }
        public string DateFormat { get; set; }
        public string FieldDecimal { get; set; }
        public string EnterBy { get; set; }
        public string Gadget { get; set; }
    }

    public class UDFDetailsEntryViewModel
    {
        public string ListName { get; set; }
    }
}
