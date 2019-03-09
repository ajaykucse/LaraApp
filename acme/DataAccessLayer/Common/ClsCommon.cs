using DataAccessLayer.Interface.Common;
using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer.Common
{
    public class ClsCommon : ICommon
    {
        System.Data.OleDb.OleDbConnection oledbConn;
        ActiveDataAccess.ActiveDataAccess DAL;
        public ClsCommon()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
        }
        public string GenerateShortName(string Val, string Description, string ShortName, string TableName, string Category = "")
        {
            string _ShortName = "";
            Val = Val.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(Val))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("declare @c int \n");
                strSql.Append("set @c=(SELECT TOP 1 (Right(" + ShortName + ",5)+1) AS D  FROM ERP." + TableName + " where left(" + ShortName.Trim() + ",2) =  Left('" + Val.Trim().Replace("'", "''") + "', 2)  and len(" + ShortName + ") = 7  AND ISNUMERIC(Right(" + ShortName + ",5))=1 ORDER BY D DESC ) \n");
                strSql.Append("Select top(1) Left(" + Description + ",2)+CASE WHEN ISNULL(LEN(@c),1)=1 THEN '0000' WHEN LEN(@c)=2 THEN '000' WHEN LEN(@c)=3 THEN '00' WHEN LEN(@c)=4 THEN '0' WHEN LEN(@c)=5 THEN '' END+ convert(varchar(5),(Right(" + ShortName + ",5))+1) as ShortName   \n");
                strSql.Append("from ERP." + TableName + " where left(" + ShortName.Trim() + ",2) =  Left('" + Val.Trim().Replace("'", "''") + "', 2)  and len(" + ShortName + ") = 7   AND ISNUMERIC(Right(" + ShortName + ",5))=1 \n");
                strSql.Append("order by " + ShortName + " Desc");
                DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];

                if (dt.Rows.Count > 0)
                    _ShortName = dt.Rows[0]["ShortName"].ToString();
                if (_ShortName != "")
                {
                    return _ShortName.ToUpper();
                }

                if (Val.Length == 1)
                {
                    return Val.Substring(0, 1).ToUpper() + "00001";
                }
                else
                {
                    return Val.Substring(0, 2).ToUpper() + "00001";
                }
            }
            return _ShortName.ToUpper();
        }
        public int CheckDescriptionDuplicateRecord(string Desc, string TableName, string RetColumnName, string IdColumnName, int Id = 0)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select top 1 " + RetColumnName + " from ERP." + TableName + " where " + RetColumnName + " = '" + Desc.Trim().Replace("'","''") + "' AND " + IdColumnName + " <> " + Id + "").Tables[0];
            return dt.Rows.Count;
        }
        public int CheckShortNameDuplicateRecord(string ShortName,string TableName, string RetColumnName, string IdColumnName, int Id = 0)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select top 1 " + RetColumnName + " from ERP." + TableName + " where " + RetColumnName + " = '" + ShortName.Trim().Replace("'", "''") + "' AND " + IdColumnName + " <> " + Id + "").Tables[0];
            return dt.Rows.Count;
        }
        public int CheckUDFDuplicateRecord(string Desc, string EntryModule, int Id = 0)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select top 1 FieldName from ERP.UDFMasterEntry where FieldName='" + Desc.Trim().Replace("'", "''") + "' and EntryModule='" + EntryModule + "' AND UDFCode <> " + Id + "").Tables[0];
            return dt.Rows.Count;
        }
        //public DataTable Exists(string Control, string Source)
        //{
        //    string Query = "";
        //    if (Source == "ACG") // Account Group
        //    {

        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "select AccountGrpId,AccountGrpDesc,AccountGrpShortName from ERP.AccountGroup WHERE AccountGrpShortName='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select AccountGrpId,AccountGrpDesc,AccountGrpShortName from ERP.AccountGroup WHERE AccountGrpDesc='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CACG") // Common Account Group Data
        //    {
        //        Query = "Select  * from ERP.AccountGroup " + Control + "";
        //    }
        //    else if (Source == "ACSG") // Account SubGroup
        //    {

        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "select AccountSubGrpId,AccountSubGrpDesc,AccountSubGrpShortName from ERP.AccountSubGroup WHERE AccountSubGrpShortName='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select AccountSubGrpId,AccountSubGrpDesc,AccountSubGrpShortName from ERP.AccountSubGroup WHERE AccountSubGrpDesc='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CACSG") // Common Account SubGroup Data
        //    {
        //        Query = "Select  * from ERP.AccountSubGroup " + Control + "";
        //    }
        //    if (Source == "GL") // GeneralLedger
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "Select Ledger_Code from ERP.GeneralLedger where GlShortName = '" + Control + "' and Status=1";
        //        }
        //        else
        //        {
        //            Query = "Select Ledger_Code from ERP.GeneralLedger where GlDesc = '" + Control + "' and Status=1";
        //        }
        //    }
        //    else if (Source == "GLSN") // Ledger ShortName wise
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "Select Ledger_Code fromERP.GeneralLedger where GlShortName = '" + Control + "' and Status=1";
        //        }
        //        else
        //        {
        //            Query = "Select Ledger_Code from ERP.GeneralLedger where GlDesc = '" + Control + "' and Status=1";
        //        }
        //    }
        //    else if (Source == "CGL") // Common Ledger Data
        //    {
        //        Query = "Select  * from ERP.GeneralLedger " + Control + " and Status=1";
        //    }

        //    else if (Source == "SL") // SubLedger
        //    {

        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "select SubledgerId,SubledgerDesc,SubledgerShortName from ERP.SubLedger WHERE SubledgerShortName='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select SubledgerId,SubledgerDesc,SubledgerShortName from ERP.SubLedger WHERE SubledgerDesc='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CSL") // Common SubLedger Data
        //    {
        //        Query = "Select  * from ERP.SubLedger " + Control + "";
        //    }
        //    else if (Source == "MAR") // Main Area
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "select MainAreaId,MainAreaDesc,MainAreaShortName from ERP.MainArea WHERE MainAreaShortName='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select MainAreaId,MainAreaDesc,MainAreaShortName from ERP.MainArea WHERE MainAreaDesc='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CAR") // Common Area Data
        //    {
        //        Query = "Select  *from ERP.MainArea " + Control + "";
        //    }
        //    else if (Source == "AR") // Area
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "select AreaId,AreaDesc,AreaShortName from ERP.Area WHERE AreaShortName='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select AreaId,AreaDesc,AreaShortName from ERP.Area WHERE AreaDesc='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CAR") // Common Area Data
        //    {
        //        Query = "Select  *from ERP.Area " + Control + "";
        //    }

        //    else if (Source == "CUR") // Currency
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //        {
        //            Query = "select CurrencyId,CurrencyDesc,CurrencyShortName from ERP.Currency WHERE CurrencyShortName='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select CurrencyId ,CurrencyDesc,CurrencyShortName from ERP.Currency WHERE CurrencyDesc ='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CCUR") // Common Currency Data
        //    {
        //        Query = "Select  * from ERP.Currency " + Control + "";
        //    }
        //    else if (Source == "GDN") // Godown
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //            Query = "select GodownId,GodownDesc,GodownShortName from ERP.Godown WHERE GodownShortName = '" + Control + "'";
        //        else
        //            Query = "select GodownId,GodownDesc,GodownShortName from ERP.Godown WHERE GodownDesc = '" + Control + "'";
        //    }
        //    else if (Source == "CGDN") // Common Godown Data
        //    {
        //        Query = "Select  * from ERP.Godown " + Control + "";
        //    }
        //    else if (Source == "COC") // Cost Center
        //    {
        //        if (ClsGlobal._Transby_Code == true)
        //            Query = "select CostCenterId,CostCenterDesc,CostCenterShortName from ERP.CostCenter WHERE CostCenterShortName='" + Control + "'";
        //        else
        //            Query = "select CostCenterId,CostCenterDesc,CostCenterShortName from ERP.CostCenter WHERE CostCenterDesc='" + Control + "'";
        //    }
        //    else if (Source == "CCOC") // Common Cost Center Data
        //    {
        //        Query = "Select  * from ERP.CostCenter " + Control + "";
        //    }
        //    else if (Source == "PG") // Product  GROUP
        //    {
        //        if (ClsGlobal._Product_Code == true)
        //        {
        //            Query = "select PG_Id  from ERP.ProductGroup  WHERE PG_Id='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select PG_Id  from ERP.ProductGroup  WHERE PG_Name='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "PSG") // Product  SUB GROUP
        //    {
        //        if (ClsGlobal._Product_Code == true)
        //        {
        //            Query = "select PSG_Id  from ERP.ProductSubGroup  WHERE PSG_Id='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select PSG_Id  from ERP.ProductSubGroup  WHERE PSG_Name='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "P") // Product 
        //    {
        //        if (ClsGlobal._Product_Code == true)
        //        {
        //            Query = "select Product_Id  from ERP.Product  WHERE Product_Code='" + Control + "'";
        //        }
        //        else
        //        {
        //            Query = "select Product_Id  from ERP.Product  WHERE Product_Name='" + Control + "'";
        //        }
        //    }
        //    else if (Source == "CP") // Common Product Data
        //    {
        //        Query = "Select  *from ERP.Product " + Control + "";
        //    }

        //    else if (Source == "U") // Unit
        //    {
        //        Query = "select Unit_Id  from ERP.Unit  WHERE Unit_Code='" + Control + "'";
        //    }
        //    else if (Source == "CU") // Common Unit Data
        //    {
        //        Query = "Select  *from ERP.Unit " + Control + "";
        //    }
        //    else if (Source == "B")   ///Branch
        //    {
        //        Query = "Select * From ERP.Branch ";
        //    }
        //    else if (Source == "BI")   ////Branch Id
        //    {
        //        Query = "Select Branch_Id From ERP.Branch Where  (Branch_Code='" + Control + "' Or Branch_Name='" + Control + "')";
        //    }
        //    DataTable dt = DAL.ExecuteDataset(CommandType.Text, Query).Tables[0];
        //    if (dt.Rows.Count > 0)
        //        return dt;
        //    else
        //        return dt;
        //}
        public string[] GetVoucherNo(string DocId, string Module, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 ISNULL(DocPrefix,'')+ REPLICATE(DocFillCharacter,DocBodyLength -LEN(CONVERT(BIGINT,DocCurrentNo))) + convert(varchar(50),DocCurrentNo)+ISNULL(DocSufix,'')  As VoucherNo,DocId,NumericalStyle FROM ERP.Documentnumbering where DocModule='" + Module + "' \n");
            if (!string.IsNullOrEmpty(DocId))
                strSql.Append(" AND DocId='" + DocId + "' \n");

            //if (BranchId != 0)
            //{
            //    strSql.Append("AND (BranchId IS NULL OR BranchId = '" + BranchId + "') \n");
            //}
            //else
            //{
            //    strSql.Append("AND (BranchId IS NULL) \n");
            //}

            //if (CompanyUnitId != 0)
            //{
            //    strSql.Append("AND (CompanyUnitId IS NULL OR CompanyUnitId = '' OR CompanyUnitId = '" + CompanyUnitId + "') \n");
            //}
            //else
            //{
            //    strSql.Append("AND (CompanyUnitId IS NULL) \n");
            //}

            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            string[] stringArray = new string[3];
            if (dt.Rows.Count > 0)
            {
                stringArray[0] = dt.Rows[0]["VoucherNo"].ToString();
                stringArray[1] = dt.Rows[0]["DocId"].ToString();
                stringArray[2] = dt.Rows[0]["NumericalStyle"].ToString();
            }
            else
            {
                stringArray[0] = "";
                stringArray[1] = "";
                stringArray[2] = "";
            }

            return stringArray;
        }
        public int CountVoucherNoByModule(string Module)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DocId FROM ERP.Documentnumbering where DocModule='" + Module + "'");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            return dt.Rows.Count;
        }
        public DataTable ReadExcelFile(string path, string SheetName)
        {
            if (System.IO.Path.GetExtension(path) == ".xls")
            {
                oledbConn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
            }
            else if (System.IO.Path.GetExtension(path) == ".xlsx")
            {
                oledbConn = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
            }
            oledbConn.Open();
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            System.Data.OleDb.OleDbDataAdapter oleda = new System.Data.OleDb.OleDbDataAdapter();
            DataSet ds = new DataSet();
            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ["+ SheetName + "$]";
            oleda = new System.Data.OleDb.OleDbDataAdapter(cmd);
            oleda.Fill(ds, "Table1");
            oledbConn.Close();
            return ds.Tables[0];
        }
        public void GridToExcel(DataGridView Grid, string SheetName)
        {
            //Creating a Excel object.
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = SheetName;
                //storing Each row and column value to excel sheet
                for (int i = 1; i < Grid.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = Grid.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < Grid.Rows.Count; i++)
                {
                    for (int j = 0; j < Grid.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = Grid.Rows[i].Cells[j].Value.ToString();
                    }
                }

                //Getting the location and file name of the excel to save from user.
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                     workbook.SaveAs(saveDialog.FileName);

                    MessageBox.Show("Export Successful", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        public void DataTableToExcel(DataTable dataTable, string SheetName)
        {
            //Creating a Excel object.
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = SheetName;
                //storing Each row and column value to excel sheet
                for (int i = 1; i < dataTable.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName.ToString();
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                    }
                }

                //Getting the location and file name of the excel to save from user.
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
    }
}
