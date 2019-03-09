using DataAccessLayer.Interface.ARAPReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ARAPReport
{
    public class ClsRptSalesRegister : IRptSalesRegister
    {
        ActiveDataAccess.ActiveDataAccess DAL;

        public ClsRptSalesRegister()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
        }

        #region ----- Sales Invoice -----------
        public DataSet SalesRegisterSummary(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select SM.VoucherNo as [Voucher No], Convert(nvarchar(10), VDate, 103) [Date],VMiti AS Miti,SM.OrderNo,\n");
            strSql.Append("PartyName as [Customer Name], \n");
            strSql.Append("sum(SD.Qty) as Qty, \n");
            strSql.Append("sum(SD.BasicAmount) as [Basic Amt], \n");
            strSql.Append("Sm.NetAmount as [Net Amt] \n");
            strSql.Append("from ERP.SalesInvoiceDetails AS SD  inner join ERP.SalesInvoiceMaster AS SM on SD.VoucherNo = SM.VoucherNo left outer join \n");
            strSql.Append("ERP.GeneralLedger AS Gl on SM.LedgerId = Gl.LedgerId \n");
            strSql.Append("Where VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and(SM.VoucherNo Like '%%' or '' = '') \n");
            strSql.Append("--and(SM.Unit = '' or '' = '' or SM.Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("group by SM.VoucherNo,VDate,VMiti,Sm.NetAmount,Gldesc,PartyName,SM.OrderNo \n");
            strSql.Append("Order by VDate, SM.VoucherNo \n\n");

            strSql.Append("DECLARE @terms AS NVARCHAR(MAX),@query AS NVARCHAR(MAX),@term AS NVARCHAR(MAX) \n");
            strSql.Append("set @terms = (SELECT SUBSTRING((SELECT ', ISNULL([' + TermDesc + '],0) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' and TermType<>'R' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @term = (SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @query = 'select [Voucher No],' + @terms + ' from (  \n");
            strSql.Append("SELECT SM.VoucherNo as [Voucher No],CASE WHEN SIT.STSign = ''+'' then TermAmt else -TermAmt end as TermAmt,SBT.TermDesc FROM ERP.SalesInvoiceTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId  inner join ERP.SalesInvoiceMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in(''P'',''BT'')  \n");
            strSql.Append("AND VDate between ''" + fromDate.ToString("yyyy-MM-dd") + "'' and ''" + toDate.ToString("yyyy-MM-dd") + "'' \n");
            strSql.Append("--and(SOT.VNo Like '' %% '' or '''' = '''') and(SM.Unit = '''' or '''' = '''' or SM.Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append(") as d Pivot(Sum(TermAmt) for TermDesc in (' + @term + ') ) as pid'  \n");
            strSql.Append("execute(@query); \n\n");

            strSql.Append("set @terms = (SELECT SUBSTRING((SELECT ', SUM(ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' and TermType<>'R' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @query = 'select ' + @terms + ' from (  \n");
            strSql.Append("SELECT SM.VoucherNo as [Voucher No],CASE WHEN SIT.STSign = ''+'' then TermAmt else -TermAmt end as TermAmt,SBT.TermDesc FROM ERP.SalesInvoiceTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId  inner join ERP.SalesInvoiceMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in(''P'',''BT'')  \n");
            strSql.Append("AND VDate between ''" + fromDate.ToString("yyyy-MM-dd") + "'' and ''" + toDate.ToString("yyyy-MM-dd") + "'' \n");
            strSql.Append("--and(SOT.VNo Like '' %% '' or '''' = '''') and(SM.Unit = '''' or '''' = '''' or SM.Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append(") as d Pivot(Sum(TermAmt) for TermDesc in (' + @term + ') ) as pid'  \n");
            strSql.Append("execute(@query); \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet SalesRegisterSummaryDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesRegisterSummary(fromDate, toDate, BranchId, CompanyUnitId);
            DataSet dsResutl = new DataSet();
            if (ds.Tables.Count > 1)
            {
                DataTable dtTerm = ds.Tables[2].Copy();
                DataTable dt = SalesRegisterJoinDataTable(ds.Tables[0], ds.Tables[1], dtTerm, "Voucher No");
                dsResutl.Tables.Add(dt);
                dsResutl.Tables.Add(dtTerm);
            }
            else
            {
                DataTable dt = ds.Tables[0];
                DataRow addNewdr;
                dt.Columns.Add("IsBold", typeof(string));
                decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                foreach (DataRow item in dt.Rows)
                {
                    _Qty = _Qty + Convert.ToDecimal(item["Qty"].ToString());
                    _BasicAmt = _BasicAmt + Convert.ToDecimal(item["Basic Amt"].ToString());
                    _NetAmt = _NetAmt + Convert.ToDecimal(item["Net Amt"].ToString());
                }
                addNewdr = dt.NewRow();
                addNewdr["Customer Name"] = "Total :";
                addNewdr["Qty"] = _Qty.ToString("0.00");
                addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
                addNewdr["IsBold"] = "Y";
                dt.Rows.InsertAt(addNewdr, dt.Rows.Count + 1);
                dt.AcceptChanges();
                dsResutl = ds;
            }
            return dsResutl;
        }
        public DataTable SalesRegisterJoinDataTable(DataTable dataTable1, DataTable dataTable2, DataTable dtSumTerm, string joinField)
        {
            var dt = new DataTable();
            var joinTable = from t1 in dataTable1.AsEnumerable()
                            join t2 in dataTable2.AsEnumerable()
                                on t1[joinField] equals t2[joinField]
                            select new { t1, t2 };
            foreach (DataColumn col in dataTable1.Columns)
                dt.Columns.Add(col.ColumnName, typeof(string));
            // dt.Columns.Remove(joinField);
            foreach (DataColumn col in dtSumTerm.Columns)
            {
                dt.Columns.Add(col.ColumnName, typeof(string));
            }

            foreach (var row in joinTable)
            {
                var newRow = dt.NewRow();
                newRow.ItemArray = row.t1.ItemArray.Concat(row.t2.ItemArray.Skip(1).ToArray()).ToArray();
                dt.Rows.Add(newRow);
            }
            dt.Columns["Net Amt"].SetOrdinal(dt.Columns.Count - 1);
            DataRow addNewdr;
            dt.Columns.Add("IsBold", typeof(string));
            decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
            foreach (DataRow item in dt.Rows)
            {
                _Qty = _Qty + Convert.ToDecimal(item["Qty"].ToString());
                _BasicAmt = _BasicAmt + Convert.ToDecimal(item["Basic Amt"].ToString());
                _NetAmt = _NetAmt + Convert.ToDecimal(item["Net Amt"].ToString());
            }
            addNewdr = dt.NewRow();
            addNewdr["Customer Name"] = "Total :";
            addNewdr["Qty"] = _Qty.ToString("0.00");
            addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
            addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            foreach (DataColumn col in dtSumTerm.Columns)
            {
                addNewdr[col.ColumnName] = dtSumTerm.Rows[0][col.ColumnName].ToString();
            }
            dt.Rows.InsertAt(addNewdr, dt.Rows.Count + 1);

            for (int j= 0; j < dt.Rows.Count; j++)
            {
                for (int i = 5; i < dt.Columns.Count-1; i++)
                {
                    //string aa = dt.Rows[j][i].ToString();
                    dt.Rows[j][i] = Convert.ToDecimal(dt.Rows[j][i].ToString()).ToString("0.00");
                }
            }
            
            return dt;
        }
        public DataSet SalesRegisterDetailsHorizontal(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SalesINvoiceQueryOne(fromDate,toDate).ToString());
            strSql.Append("DECLARE @terms AS NVARCHAR(MAX),@query AS NVARCHAR(MAX),@term AS NVARCHAR(MAX) \n");
            strSql.Append("set @terms = (SELECT SUBSTRING((SELECT ', ISNULL([' + TermDesc + '],0) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @term = (SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @query = 'select [Voucher No],SNo,ProductId,' + @terms + ' from (  \n");
            strSql.Append("SELECT SM.VoucherNo as [Voucher No],SNo,ProductId,CASE WHEN SIT.STSign = ''+'' then TermAmt else -TermAmt end as TermAmt,SBT.TermDesc FROM ERP.SalesInvoiceTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId  inner join ERP.SalesInvoiceMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in(''P'',''BT'')  \n");
            strSql.Append("AND VDate between ''" + fromDate.ToString("yyyy-MM-dd") + "'' and ''" + toDate.ToString("yyyy-MM-dd") + "'' \n");
            strSql.Append("--and(SOT.VNo Like '' %% '' or '''' = '''') and(SM.Unit = '''' or '''' = '''' or SM.Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append(") as d Pivot(Sum(TermAmt) for TermDesc in (' + @term + ') ) as pid'  \n");
            strSql.Append("execute(@query); \n\n");
            strSql.Append(SalesINvoiceQueryTwo(fromDate, toDate).ToString());
            strSql.Append(SalesINvoiceQueryThree(fromDate, toDate).ToString());
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet SalesRegisterDetailsHorizontalDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesRegisterDetailsHorizontal(fromDate, toDate, BranchId, CompanyUnitId);
            DataTable dtResult = new DataTable();
            DataTable dtTerm = new DataTable();
            dtResult.Columns.Add("Date", typeof(string));
            dtResult.Columns.Add("Particular", typeof(string));
            dtResult.Columns.Add("Qty", typeof(string));
            dtResult.Columns.Add("Rate", typeof(string));
            dtResult.Columns.Add("Basic Amt", typeof(string));
            if (ds.Tables.Count > 3)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    dtResult.Columns.Add(dr["TermDesc"].ToString(), typeof(string));
                    dtTerm.Columns.Add(dr["TermDesc"].ToString(), typeof(string));
                }
            }
            dtResult.Columns.Add("Net Amt", typeof(string));
            dtResult.Columns.Add("IsBold", typeof(string));
            DataView view = new DataView(ds.Tables[0]);
            DataTable DistinctVoucher = view.ToTable(true, "Voucher No", "Customer Name", "Date", "Miti");
            DataRow addNewdr;
            decimal _GQty = 0, _GBasicAmt = 0, _GNetAmt = 0;
            foreach (DataRow item in DistinctVoucher.Rows)
            {
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = item["Date"].ToString();
                addNewdr["Particular"] = "Inv. No. : " + item["Voucher No"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = "Customer";
                addNewdr["Particular"] = item["Customer Name"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                int i = 0;
                DataRow[] result = ds.Tables[0].Select("[Voucher No] = '" + item["Voucher No"].ToString() + "'");
                if (result.Length > 0)
                {
                    decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                    foreach (DataRow row in result)
                    {
                        addNewdr = dtResult.NewRow();
                        addNewdr["Date"] = row["ProductShortName"].ToString();
                        addNewdr["Particular"] = row["ProductDesc"].ToString();
                        addNewdr["Qty"] = Convert.ToDecimal(row["Qty"].ToString()).ToString("0.00") + " " + row["ProductUnitDesc"].ToString();
                        addNewdr["Rate"] = Convert.ToDecimal(row["Rate"].ToString()).ToString("0.00");
                        addNewdr["Basic Amt"] = Convert.ToDecimal(row["Basic Amt"].ToString()).ToString("0.00");
                        decimal _Term = 0;
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataTable copy = ds.Tables[1].Clone();
                            foreach (DataRow o in ds.Tables[1].Select("[Voucher No] = '" + row["Voucher No"].ToString() + "' AND SNo ='" + row["SNo"].ToString() + "' "))
                            {
                                copy.LoadDataRow(o.ItemArray, true);
                            }
                            if (copy.Rows.Count > 0)
                            {
                                foreach (DataColumn col1 in dtTerm.Columns)
                                {
                                    _Term = _Term + Convert.ToDecimal(copy.Rows[0][col1.ColumnName].ToString());
                                }
                            }
                        }
                        addNewdr["Net Amt"] = (Convert.ToDecimal(row["Basic Amt"].ToString()) + _Term).ToString("0.00");

                        _Qty = _Qty + Convert.ToDecimal(row["Qty"].ToString());
                        _BasicAmt = _BasicAmt + Convert.ToDecimal(row["Basic Amt"].ToString());
                        _NetAmt = _NetAmt + Convert.ToDecimal(row["Basic Amt"].ToString()) + _Term;
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataRow[] result1 = ds.Tables[1].Select("[Voucher No] = '" + row["Voucher No"].ToString() + "' AND [ProductId] = '" + row["ProductId"].ToString() + "' AND [SNo] = '" + row["SNo"].ToString() + "'");
                            if (result1.Length > 0)
                            {
                                DataTable dt1 = result1.CopyToDataTable();
                                foreach (DataColumn col1 in dtTerm.Columns)
                                {
                                    addNewdr[col1.ColumnName] = Convert.ToDecimal(dt1.Rows[0][col1.ColumnName].ToString()).ToString("0.00");
                                }
                            }
                        }
                        dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        i++;
                        if (i == result.Count())
                        {
                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = "Total :";
                            addNewdr["Qty"] = _Qty.ToString("0.00");
                            addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                            addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
                            addNewdr["IsBold"] = "Y";
                            _GQty = _GQty + _Qty;
                            _GBasicAmt = _GBasicAmt + _BasicAmt;
                            _GNetAmt = _GNetAmt + _NetAmt;
                            foreach (DataColumn col1 in dtTerm.Columns)
                            {
                                DataTable ddd = ds.Tables[2].AsEnumerable().Where(
                                    rows => rows.Field<string>("VoucherNo") == row["Voucher No"].ToString()
                                    && rows.Field<string>("TermDesc") == col1.ColumnName
                                    ).CopyToDataTable();
                                addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
                            }
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                    }
                }
            }

            addNewdr = dtResult.NewRow();
            addNewdr["Particular"] = "Grand Total :";
            addNewdr["Qty"] = _GQty.ToString("0.00");
            addNewdr["Basic Amt"] = _GBasicAmt.ToString("0.00");
            addNewdr["Net Amt"] = _GNetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            foreach (DataColumn col1 in dtTerm.Columns)
            {
                DataTable ddd = ds.Tables[3].AsEnumerable().Where(rows => rows.Field<string>("TermDesc") == col1.ColumnName).CopyToDataTable();
                addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
            }
            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
            DataSet dsResutl = new DataSet();
            dsResutl.Tables.Add(dtResult);
            dsResutl.Tables.Add(dtTerm);
            return dsResutl;
        }
        public DataSet SalesRegisterDetailsVerticle(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SalesINvoiceQueryOne(fromDate, toDate).ToString());
            strSql.Append("select SIT.VoucherNo,SIT.Sno,SIT.ProductId,SIT.TermRate, CASE WHEN SIT.STSign = '+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt,SBT.TermDesc,SBT.TermPosition  from erp.SalesInvoiceTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId \n");
            strSql.Append("inner join ERP.SalesInvoiceMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in('P','B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("order by VoucherNo,Sno,TermPosition \n\n");
            strSql.Append(SalesINvoiceQueryTwo(fromDate, toDate).ToString());
            strSql.Append(SalesINvoiceQueryThree(fromDate, toDate).ToString());
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet SalesRegisterDetailsVerticleDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesRegisterDetailsVerticle(fromDate, toDate, BranchId, CompanyUnitId);
            DataTable dtResult = new DataTable();
            DataTable dtTerm = new DataTable();
            dtResult.Columns.Add("Date", typeof(string));
            dtResult.Columns.Add("Particular", typeof(string));
            dtResult.Columns.Add("Qty", typeof(string));
            dtResult.Columns.Add("Rate", typeof(string));
            dtResult.Columns.Add("Basic Amt", typeof(string));
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                dtTerm.Columns.Add(dr["TermDesc"].ToString(), typeof(string));
            }
            dtResult.Columns.Add("IsBold", typeof(string));
            DataView view = new DataView(ds.Tables[0]);
            DataTable DistinctVoucher = view.ToTable(true, "Voucher No", "Customer Name", "Date", "Miti");
            DataRow addNewdr;
            decimal _GQty = 0, _GBasicAmt = 0, _GNetAmt = 0;
            foreach (DataRow item in DistinctVoucher.Rows)
            {
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = item["Date"].ToString();
                addNewdr["Particular"] = "Inv. No. : " + item["Voucher No"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = "Customer";
                addNewdr["Particular"] = item["Customer Name"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                int i = 0;
                DataRow[] result = ds.Tables[0].Select("[Voucher No] = '" + item["Voucher No"].ToString() + "'");
                if (result.Length > 0)
                {
                    decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                    foreach (DataRow row in result)
                    {
                        addNewdr = dtResult.NewRow();
                        addNewdr["Date"] = row["ProductShortName"].ToString();
                        addNewdr["Particular"] = row["ProductDesc"].ToString();
                        addNewdr["Qty"] =Convert.ToDecimal(row["Qty"].ToString()).ToString("0.00") + " " + row["ProductUnitDesc"].ToString();
                        addNewdr["Rate"] = Convert.ToDecimal(row["Rate"].ToString()).ToString("0.00");
                        addNewdr["Basic Amt"] = Convert.ToDecimal(row["Basic Amt"].ToString()).ToString("0.00");
                        _Qty = _Qty + Convert.ToDecimal(row["Qty"].ToString());
                        _BasicAmt = _BasicAmt + Convert.ToDecimal(row["Basic Amt"].ToString());
                        addNewdr["IsBold"] = "Y";
                        dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        // ADD TERMS
                        foreach (DataRow o in ds.Tables[1].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "' AND SNo ='" + row["SNo"].ToString() + "' "))
                        {
                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = o["TermDesc"].ToString();
                            addNewdr["Rate"] = Convert.ToDecimal(o["TermRate"].ToString()).ToString("0.00") + " %";
                            addNewdr["Basic Amt"] = Convert.ToDecimal(o["LocalTermAmt"].ToString()).ToString("0.00");
                            _BasicAmt = _BasicAmt + Convert.ToDecimal(o["LocalTermAmt"].ToString());
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                        i++;
                        if (i == result.Count())
                        {
                            foreach (DataRow o in ds.Tables[1].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "' AND SNo ='0' "))
                            {
                                addNewdr = dtResult.NewRow();
                                addNewdr["Particular"] = o["TermDesc"].ToString();
                                addNewdr["Rate"] = Convert.ToDecimal(o["TermRate"].ToString()).ToString("0.00") + " %";
                                addNewdr["Basic Amt"] = Convert.ToDecimal(o["LocalTermAmt"].ToString()).ToString("0.00");
                                _BasicAmt = _BasicAmt + Convert.ToDecimal(o["LocalTermAmt"].ToString());
                                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                            }

                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = "Total :";
                            addNewdr["Qty"] = _Qty.ToString("0.00");
                            addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                            addNewdr["IsBold"] = "Y";
                            _GQty = _GQty + _Qty;
                            _GBasicAmt = _GBasicAmt + _BasicAmt;
                            _GNetAmt = _GNetAmt + _NetAmt;
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                    }
                }
            }

            addNewdr = dtResult.NewRow();
            addNewdr["Particular"] = "Grand Total :";
            addNewdr["Qty"] = _GQty.ToString("0.00");
            addNewdr["Basic Amt"] = _GBasicAmt.ToString("0.00");
            //addNewdr["Net Amt"] = _GNetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            //foreach (DataColumn col1 in dtTerm.Columns)
            //{
            //    DataTable ddd = ds.Tables[3].AsEnumerable().Where(rows => rows.Field<string>("TermDesc") == col1.ColumnName).CopyToDataTable();
            //    addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
            //}
            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
            DataSet dsResutl = new DataSet();
            dsResutl.Tables.Add(dtResult);
            dsResutl.Tables.Add(dtTerm);
            return dsResutl;
        }

        public DataSet SalesRegisterDetailsProductHorizontalBillVerticleDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesRegisterDetailsVerticle(fromDate, toDate, BranchId, CompanyUnitId);
            DataTable dtResult = new DataTable();
            DataTable dtTerm = new DataTable();
            dtResult.Columns.Add("Date", typeof(string));
            dtResult.Columns.Add("Particular", typeof(string));
            dtResult.Columns.Add("Qty", typeof(string));
            dtResult.Columns.Add("Rate", typeof(string));
            dtResult.Columns.Add("Basic Amt", typeof(string));
            DataRow[] result1 = ds.Tables[3].Select("Billwise = 'N'");
            if (result1.Length > 0)
            {
                foreach (DataRow row in result1)
                {
                    dtResult.Columns.Add(row["TermDesc"].ToString(), typeof(string));
                    dtTerm.Columns.Add(row["TermDesc"].ToString(), typeof(string));
                }
            }
            dtResult.Columns.Add("Net Amt", typeof(string));
            dtResult.Columns.Add("IsBold", typeof(string));
            DataView view = new DataView(ds.Tables[0]);
            DataTable DistinctVoucher = view.ToTable(true, "Voucher No", "Customer Name", "Date", "Miti");
            DataRow addNewdr;
            decimal _GQty = 0, _GBasicAmt = 0, _GNetAmt = 0;
            foreach (DataRow item in DistinctVoucher.Rows)
            {
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = item["Date"].ToString();
                addNewdr["Particular"] = "Inv. No. : " + item["Voucher No"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = "Customer";
                addNewdr["Particular"] = item["Customer Name"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                int i = 0;
                DataRow[] result = ds.Tables[0].Select("[Voucher No] = '" + item["Voucher No"].ToString() + "'");
                if (result.Length > 0)
                {
                    decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                    foreach (DataRow row in result)
                    {
                        addNewdr = dtResult.NewRow();
                        addNewdr["Date"] = row["ProductShortName"].ToString();
                        addNewdr["Particular"] = row["ProductDesc"].ToString();
                        addNewdr["Qty"] = Convert.ToDecimal(row["Qty"].ToString()).ToString("0.00") + " " + row["ProductUnitDesc"].ToString();
                        addNewdr["Rate"] = Convert.ToDecimal(row["Rate"].ToString()).ToString("0.00");
                        addNewdr["Basic Amt"] = Convert.ToDecimal(row["Basic Amt"].ToString()).ToString("0.00");
                        // ADD TERMS
                        foreach (DataRow o in ds.Tables[1].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "' AND SNo ='" + row["SNo"].ToString() + "' "))
                        {
                            addNewdr[o["TermDesc"].ToString()] = Convert.ToDecimal(o["LocalTermAmt"].ToString()).ToString("0.00");
                        }
                        addNewdr["Net Amt"] = Convert.ToDecimal(row["Local Net Amt"].ToString()).ToString("0.00");
                        _Qty = _Qty + Convert.ToDecimal(row["Qty"].ToString());
                        _BasicAmt = _BasicAmt + Convert.ToDecimal(row["Basic Amt"].ToString());
                        _NetAmt = _NetAmt + Convert.ToDecimal(row["Local Net Amt"].ToString());
                        dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

                        i++;
                        if (i == result.Count())
                        {
                            DataRow[] k = ds.Tables[1].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "' AND SNo ='0' ");
                            if (k.Count() > 0)
                            {
                                addNewdr = dtResult.NewRow();
                                addNewdr["Particular"] = "Sub Total :";
                                addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                                foreach (DataRow o in ds.Tables[2].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "'  AND Billwise ='N' "))
                                {
                                    addNewdr[o["TermDesc"].ToString()] = Convert.ToDecimal(o["LocalTermAmt"].ToString()).ToString("0.00");
                                }
                                addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
                                addNewdr["IsBold"] = "Y";
                                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                                foreach (DataRow o in ds.Tables[1].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "' AND SNo ='0' "))
                                {
                                    addNewdr = dtResult.NewRow();
                                    addNewdr["Particular"] = o["TermDesc"].ToString() + " (" + Convert.ToDecimal(o["TermRate"].ToString()).ToString("0.00") + " %)";
                                    addNewdr["Net Amt"] = Convert.ToDecimal(o["LocalTermAmt"].ToString()).ToString("0.00");
                                    _NetAmt = _NetAmt + Convert.ToDecimal(o["LocalTermAmt"].ToString());
                                    dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                                }
                            }
                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = "Total :";
                            addNewdr["Qty"] = _Qty.ToString("0.00");
                            if (k.Count() == 0)
                            {
                                addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                            }
                            addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
                            addNewdr["IsBold"] = "Y";
                            _GQty = _GQty + _Qty;
                            _GBasicAmt = _GBasicAmt + _BasicAmt;
                            _GNetAmt = _GNetAmt + _NetAmt;
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                    }
                }
            }

            addNewdr = dtResult.NewRow();
            addNewdr["Particular"] = "Grand Total :";
            addNewdr["Qty"] = _GQty.ToString("0.00");
            addNewdr["Basic Amt"] = _GBasicAmt.ToString("0.00");
            foreach (DataRow o in ds.Tables[3].Select("Billwise ='N' "))
            {
                addNewdr[o["TermDesc"].ToString()] = Convert.ToDecimal(o["LocalTermAmt"].ToString()).ToString("0.00");
            }
            addNewdr["Net Amt"] = _GNetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            //foreach (DataColumn col1 in dtTerm.Columns)
            //{
            //    DataTable ddd = ds.Tables[3].AsEnumerable().Where(rows => rows.Field<string>("TermDesc") == col1.ColumnName).CopyToDataTable();
            //    addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
            //}
            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
            DataSet dsResutl = new DataSet();
            dsResutl.Tables.Add(dtResult);
            dsResutl.Tables.Add(dtTerm);
            return dsResutl;
        }

        public StringBuilder SalesINvoiceQueryOne(DateTime fromDate, DateTime toDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CONVERT(varchar(10), SM.VDate,103) as [Date],SM.VMiti as [Miti],PartyName AS[Customer Name], \n");
            strSql.Append("GL.LedgerId,SD.SNo,SD.ProductId,P.ProductDesc,P.ProductShortName,PUnit.ProductUnitDesc, SD.VoucherNo as [Voucher No], \n");
            strSql.Append("SD.SalesRate as Rate,Qty, \n");
            strSql.Append("SD.BasicAmount as [Basic Amt],SD.LocalNetAmount as [Local Net Amt] \n");
            strSql.Append("from ERP.SalesInvoiceDetails AS SD \n");
            strSql.Append("inner join ERP.SalesInvoiceMaster AS SM on SD.VoucherNo = SM.VoucherNo \n");
            strSql.Append("left outer join ERP.Product AS P on SD.ProductId = P.ProductId \n");
            strSql.Append("left outer join ERP.ProductUnit as PUnit on P.ProductUnitId = PUnit.ProductUnitId \n");
            strSql.Append("left outer join ERP.GeneralLedger AS GL on SM.LedgerId = GL.LedgerId \n");
            strSql.Append("Where VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and(SM.[VNo] Like '%%' or '' = '') and(SM.Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append("Order by VDate,SD.VoucherNo \n\n");
            return strSql;
        }
        public StringBuilder SalesINvoiceQueryTwo(DateTime fromDate, DateTime toDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SIT.VoucherNo,SUM(CASE WHEN SBT.STSign = '+' then LocalTermAmt else -LocalTermAmt end) as LocalTermAmt,SBT.TermDesc,SBT.Billwise,TermPosition FROM ERP.SalesBillingTerm as SBT \n");
            strSql.Append("Left Outer join ERP.SalesInvoiceTerm as SIT on SIT.TermId = SBT.TermId \n");
            strSql.Append("INNER JOIN ERP.SalesInvoiceMaster as SIM on SIM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType IN('P', 'B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("GROUP BY SIT.VoucherNo,TermDesc,SBT.Billwise,TermPosition \n");
            strSql.Append("order by VoucherNo,TermPosition \n\n");
            return strSql;
        }
        public StringBuilder SalesINvoiceQueryThree(DateTime fromDate, DateTime toDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(CASE WHEN SBT.STSign = '+' then LocalTermAmt else -LocalTermAmt end) as LocalTermAmt,SBT.TermDesc,SBT.TermId,SBT.Billwise,TermPosition FROM ERP.SalesBillingTerm as SBT \n");
            strSql.Append("Left Outer join ERP.SalesInvoiceTerm as SIT on SIT.TermId = SBT.TermId \n");
            strSql.Append("INNER JOIN ERP.SalesInvoiceMaster as SIM on SIM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType IN('P', 'B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("GROUP BY TermDesc,SBT.TermId,SBT.Billwise,TermPosition \n");
            strSql.Append("ORDER BY SBT.TermPosition");
            return strSql;
        }
        #endregion

        #region ----- Sales Order -----------
        public DataSet SalesOrderRegisterSummary(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select SM.VoucherNo as [Voucher No], Convert(nvarchar(10), VDate, 103) [Date],VMiti AS Miti,\n");
            strSql.Append("PartyName as [Customer Name], \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), sum(SD.Qty)) as Qty, \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), sum(SD.BasicAmount)) as [Basic Amt], \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), Sm.NetAmount) as [Net Amt] \n");
            strSql.Append("from ERP.SalesOrderDetails AS SD  inner join ERP.SalesOrderMaster AS SM on SD.VoucherNo = SM.VoucherNo left outer join \n");
            strSql.Append("ERP.GeneralLedger AS Gl on SM.LedgerId = Gl.LedgerId \n");
            strSql.Append("Where VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and(SM.VoucherNo Like '%%' or '' = '') \n");
            strSql.Append("--and(SM.Unit = '' or '' = '' or SM.Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("group by SM.VoucherNo,VDate,VMiti,Sm.NetAmount,Gldesc,PartyName \n");
            strSql.Append("Order by VDate, SM.VoucherNo \n\n");

            strSql.Append("DECLARE @terms AS NVARCHAR(MAX),@query AS NVARCHAR(MAX),@term AS NVARCHAR(MAX) \n");
            strSql.Append("set @terms = (SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @term = (SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @query = 'select [Voucher No],' + @terms + ' from (  \n");
            strSql.Append("SELECT SM.VoucherNo as [Voucher No],CASE WHEN SIT.STSign = ''+'' then TermAmt else -TermAmt end as TermAmt,SBT.TermDesc FROM ERP.SalesOrderTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId  inner join ERP.SalesOrderMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in(''P'',''BT'')  \n");
            strSql.Append("AND VDate between ''" + fromDate.ToString("yyyy-MM-dd") + "'' and ''" + toDate.ToString("yyyy-MM-dd") + "'' \n");
            strSql.Append("--and(SOT.VNo Like '' %% '' or '''' = '''') and(SM.Unit = '''' or '''' = '''' or SM.Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append(") as d Pivot(Sum(TermAmt) for TermDesc in (' + @term + ') ) as pid'  \n");
            strSql.Append("execute(@query); \n\n");

            strSql.Append("set @terms = (SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), SUM(ISNULL([' + TermDesc + '],0))) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @query = 'select ' + @terms + ' from (  \n");
            strSql.Append("SELECT SM.VoucherNo as [Voucher No],CASE WHEN SIT.STSign = ''+'' then TermAmt else -TermAmt end as TermAmt,SBT.TermDesc FROM ERP.SalesOrderTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId  inner join ERP.SalesOrderMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in(''P'',''BT'')  \n");
            strSql.Append("AND VDate between ''" + fromDate.ToString("yyyy-MM-dd") + "'' and ''" + toDate.ToString("yyyy-MM-dd") + "'' \n");
            strSql.Append("--and(SOT.VNo Like '' %% '' or '''' = '''') and(SM.Unit = '''' or '''' = '''' or SM.Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append(") as d Pivot(Sum(TermAmt) for TermDesc in (' + @term + ') ) as pid'  \n");
            strSql.Append("execute(@query); \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet SalesOrderRegisterSummaryDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesOrderRegisterSummary(fromDate, toDate, BranchId, CompanyUnitId);
            DataSet dsResutl = new DataSet();
            if (ds.Tables.Count > 1)
            {
                DataTable dtTerm = ds.Tables[2].Copy();
                DataTable dt = SalesOrderRegisterJoinDataTable(ds.Tables[0], ds.Tables[1], dtTerm, "Voucher No");
                dsResutl.Tables.Add(dt);
                dsResutl.Tables.Add(dtTerm);
            }
            else
            {
                DataTable dt = ds.Tables[0];
                DataRow addNewdr;
                dt.Columns.Add("IsBold", typeof(string));
                decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                foreach (DataRow item in dt.Rows)
                {
                    _Qty = _Qty + Convert.ToDecimal(item["Qty"].ToString());
                    _BasicAmt = _BasicAmt + Convert.ToDecimal(item["Basic Amt"].ToString());
                    _NetAmt = _NetAmt + Convert.ToDecimal(item["Net Amt"].ToString());
                }
                addNewdr = dt.NewRow();
                addNewdr["Customer Name"] = "Total :";
                addNewdr["Qty"] = _Qty.ToString("0.00");
                addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
                addNewdr["IsBold"] = "Y";
                dt.Rows.InsertAt(addNewdr, dt.Rows.Count + 1);
                dt.AcceptChanges();
                dsResutl = ds;
            }
            return dsResutl;
        }
        public DataTable SalesOrderRegisterJoinDataTable(DataTable dataTable1, DataTable dataTable2, DataTable dtSumTerm, string joinField)
        {
            var dt = new DataTable();
            var joinTable = from t1 in dataTable1.AsEnumerable()
                            join t2 in dataTable2.AsEnumerable()
                                on t1[joinField] equals t2[joinField]
                            select new { t1, t2 };
            foreach (DataColumn col in dataTable1.Columns)
                dt.Columns.Add(col.ColumnName, typeof(string));
            // dt.Columns.Remove(joinField);
            foreach (DataColumn col in dtSumTerm.Columns)
            {
                dt.Columns.Add(col.ColumnName, typeof(string));
            }

            foreach (var row in joinTable)
            {
                var newRow = dt.NewRow();
                newRow.ItemArray = row.t1.ItemArray.Concat(row.t2.ItemArray.Skip(1).ToArray()).ToArray();
                dt.Rows.Add(newRow);
            }
            dt.Columns["Net Amt"].SetOrdinal(dt.Columns.Count - 1);
            DataRow addNewdr;
            dt.Columns.Add("IsBold", typeof(string));
            decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
            foreach (DataRow item in dt.Rows)
            {
                _Qty = _Qty + Convert.ToDecimal(item["Qty"].ToString());
                _BasicAmt = _BasicAmt + Convert.ToDecimal(item["Basic Amt"].ToString());
                _NetAmt = _NetAmt + Convert.ToDecimal(item["Net Amt"].ToString());

            }
            addNewdr = dt.NewRow();
            addNewdr["Customer Name"] = "Total :";
            addNewdr["Qty"] = _Qty.ToString("0.00");
            addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
            addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            foreach (DataColumn col in dtSumTerm.Columns)
            {
                addNewdr[col.ColumnName] = dtSumTerm.Rows[0][col.ColumnName].ToString();
            }
            dt.Rows.InsertAt(addNewdr, dt.Rows.Count + 1);
            return dt;
        }
        public DataSet SalesOrderRegisterDetailsHorizontal(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CONVERT(varchar(10), SM.VDate,103) as [Date],SM.VMiti as [Miti],PartyName AS[Customer Name], \n");
            strSql.Append("GL.LedgerId,SD.SNo,SD.ProductId,P.ProductDesc,P.ProductShortName,PUnit.ProductUnitDesc, SD.VoucherNo as [Voucher No], \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), SD.SalesRate) as Rate,CONVERT(DECIMAL(18, 2), SD.Qty) as Qty, \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), SD.BasicAmount) as [Basic Amt] \n");
            strSql.Append("from ERP.SalesOrderDetails AS SD \n");
            strSql.Append("inner join ERP.SalesOrderMaster AS SM on SD.VoucherNo = SM.VoucherNo \n");
            strSql.Append("left outer join ERP.Product AS P on SD.ProductId = P.ProductId \n");
            strSql.Append("left outer join ERP.ProductUnit as PUnit on P.ProductUnitId = PUnit.ProductUnitId \n");
            strSql.Append("left outer join ERP.GeneralLedger AS GL on SM.LedgerId = GL.LedgerId \n");
            strSql.Append("Where VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and(SM.[VNo] Like '%%' or '' = '') and(SM.Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append("Order by VDate,SD.VoucherNo \n\n");

            strSql.Append("DECLARE @terms AS NVARCHAR(MAX),@query AS NVARCHAR(MAX),@term AS NVARCHAR(MAX) \n");
            strSql.Append("set @terms = (SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @term = (SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y', 'N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms )  \n");
            strSql.Append("set @query = 'select [Voucher No],SNo,ProductId,' + @terms + ' from (  \n");
            strSql.Append("SELECT SM.VoucherNo as [Voucher No],SNo,ProductId,CASE WHEN SIT.STSign = ''+'' then TermAmt else -TermAmt end as TermAmt,SBT.TermDesc FROM ERP.SalesOrderTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId  inner join ERP.SalesOrderMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in(''P'',''BT'')  \n");
            strSql.Append("AND VDate between ''" + fromDate.ToString("yyyy-MM-dd") + "'' and ''" + toDate.ToString("yyyy-MM-dd") + "'' \n");
            strSql.Append("--and(SOT.VNo Like '' %% '' or '''' = '''') and(SM.Unit = '''' or '''' = '''' or SM.Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append(") as d Pivot(Sum(TermAmt) for TermDesc in (' + @term + ') ) as pid'  \n");
            strSql.Append("execute(@query); \n\n");

            strSql.Append("SELECT SIT.VoucherNo,SUM(CASE WHEN SBT.STSign = '+' then LocalTermAmt else -LocalTermAmt end) as LocalTermAmt,SBT.TermDesc FROM ERP.SalesBillingTerm as SBT \n");
            strSql.Append("Left Outer join ERP.SalesOrderTerm as SIT on SIT.TermId = SBT.TermId \n");
            strSql.Append("INNER JOIN ERP.SalesOrderMaster as SIM on SIM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType IN('P', 'B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("GROUP BY SIT.VoucherNo,TermDesc \n\n");

            strSql.Append("SELECT SUM(CASE WHEN SBT.STSign = '+' then LocalTermAmt else -LocalTermAmt end) as LocalTermAmt,SBT.TermDesc FROM ERP.SalesBillingTerm as SBT \n");
            strSql.Append("Left Outer join ERP.SalesOrderTerm as SIT on SIT.TermId = SBT.TermId \n");
            strSql.Append("INNER JOIN ERP.SalesOrderMaster as SIM on SIM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType IN('P', 'B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("GROUP BY TermDesc \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet SalesOrderRegisterDetailsHorizontalDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesOrderRegisterDetailsHorizontal(fromDate, toDate, BranchId, CompanyUnitId);
            DataTable dtResult = new DataTable();
            DataTable dtTerm = new DataTable();
            dtResult.Columns.Add("Date", typeof(string));
            dtResult.Columns.Add("Particular", typeof(string));
            dtResult.Columns.Add("Qty", typeof(string));
            dtResult.Columns.Add("Rate", typeof(string));
            dtResult.Columns.Add("Basic Amt", typeof(string));
            if (ds.Tables.Count > 3)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    dtResult.Columns.Add(dr["TermDesc"].ToString(), typeof(string));
                    dtTerm.Columns.Add(dr["TermDesc"].ToString(), typeof(string));
                }
            }
            dtResult.Columns.Add("Net Amt", typeof(string));
            dtResult.Columns.Add("IsBold", typeof(string));
            DataView view = new DataView(ds.Tables[0]);
            DataTable DistinctVoucher = view.ToTable(true, "Voucher No", "Customer Name", "Date", "Miti");
            DataRow addNewdr;
            decimal _GQty = 0, _GBasicAmt = 0, _GNetAmt = 0;
            foreach (DataRow item in DistinctVoucher.Rows)
            {
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = item["Date"].ToString();
                addNewdr["Particular"] = "Inv. No. : " + item["Voucher No"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = "Customer";
                addNewdr["Particular"] = item["Customer Name"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                int i = 0;
                DataRow[] result = ds.Tables[0].Select("[Voucher No] = '" + item["Voucher No"].ToString() + "'");
                if (result.Length > 0)
                {
                    decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                    foreach (DataRow row in result)
                    {
                        addNewdr = dtResult.NewRow();
                        addNewdr["Date"] = row["ProductShortName"].ToString();
                        addNewdr["Particular"] = row["ProductDesc"].ToString();
                        addNewdr["Qty"] = row["Qty"].ToString() + " " + row["ProductUnitDesc"].ToString();
                        addNewdr["Rate"] = row["Rate"].ToString();
                        addNewdr["Basic Amt"] = row["Basic Amt"].ToString();
                        decimal _Term = 0;
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataTable copy = ds.Tables[1].Clone();
                            foreach (DataRow o in ds.Tables[1].Select("[Voucher No] = '" + row["Voucher No"].ToString() + "' AND SNo ='" + row["SNo"].ToString() + "' "))
                            {
                                copy.LoadDataRow(o.ItemArray, true);
                            }
                            if (copy.Rows.Count > 0)
                            {
                                foreach (DataColumn col1 in dtTerm.Columns)
                                {
                                    _Term = _Term + Convert.ToDecimal(copy.Rows[0][col1.ColumnName].ToString());
                                }
                            }
                        }
                        addNewdr["Net Amt"] = (Convert.ToDecimal(row["Basic Amt"].ToString()) + _Term).ToString("0.00");

                        _Qty = _Qty + Convert.ToDecimal(row["Qty"].ToString());
                        _BasicAmt = _BasicAmt + Convert.ToDecimal(row["Basic Amt"].ToString());
                        _NetAmt = _NetAmt + Convert.ToDecimal(row["Basic Amt"].ToString()) + _Term;
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataRow[] result1 = ds.Tables[1].Select("[Voucher No] = '" + row["Voucher No"].ToString() + "' AND [ProductId] = '" + row["ProductId"].ToString() + "' AND [SNo] = '" + row["SNo"].ToString() + "'");
                            if (result1.Length > 0)
                            {
                                DataTable dt1 = result1.CopyToDataTable();
                                foreach (DataColumn col1 in dtTerm.Columns)
                                {
                                    addNewdr[col1.ColumnName] = dt1.Rows[0][col1.ColumnName].ToString();
                                }
                            }
                        }
                        dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        i++;
                        if (i == result.Count())
                        {
                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = "Total :";
                            addNewdr["Qty"] = _Qty.ToString("0.00");
                            addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                            addNewdr["Net Amt"] = _NetAmt.ToString("0.00");
                            addNewdr["IsBold"] = "Y";
                            _GQty = _GQty + _Qty;
                            _GBasicAmt = _GBasicAmt + _BasicAmt;
                            _GNetAmt = _GNetAmt + _NetAmt;
                            foreach (DataColumn col1 in dtTerm.Columns)
                            {
                                DataTable ddd = ds.Tables[2].AsEnumerable().Where(
                                    rows => rows.Field<string>("VoucherNo") == row["Voucher No"].ToString()
                                    && rows.Field<string>("TermDesc") == col1.ColumnName
                                    ).CopyToDataTable();
                                addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
                            }
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                    }
                }
            }

            addNewdr = dtResult.NewRow();
            addNewdr["Particular"] = "Grand Total :";
            addNewdr["Qty"] = _GQty.ToString("0.00");
            addNewdr["Basic Amt"] = _GBasicAmt.ToString("0.00");
            addNewdr["Net Amt"] = _GNetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            foreach (DataColumn col1 in dtTerm.Columns)
            {
                DataTable ddd = ds.Tables[3].AsEnumerable().Where(rows => rows.Field<string>("TermDesc") == col1.ColumnName).CopyToDataTable();
                addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
            }
            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
            DataSet dsResutl = new DataSet();
            dsResutl.Tables.Add(dtResult);
            dsResutl.Tables.Add(dtTerm);
            return dsResutl;
        }
        public DataSet SalesOrderRegisterDetailsVerticle(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CONVERT(varchar(10), SM.VDate,103) as [Date],SM.VMiti as [Miti],PartyName AS[Customer Name], \n");
            strSql.Append("GL.LedgerId,SD.SNo,SD.ProductId,P.ProductDesc,P.ProductShortName,PUnit.ProductUnitDesc, SD.VoucherNo as [Voucher No], \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), SD.SalesRate) as Rate,CONVERT(DECIMAL(18, 2), SD.Qty) as Qty, \n");
            strSql.Append("CONVERT(DECIMAL(18, 2), SD.BasicAmount) as [Basic Amt] \n");
            strSql.Append("from ERP.SalesOrderDetails AS SD \n");
            strSql.Append("inner join ERP.SalesOrderMaster AS SM on SD.VoucherNo = SM.VoucherNo \n");
            strSql.Append("left outer join ERP.Product AS P on SD.ProductId = P.ProductId \n");
            strSql.Append("left outer join ERP.ProductUnit as PUnit on P.ProductUnitId = PUnit.ProductUnitId \n");
            strSql.Append("left outer join ERP.GeneralLedger AS GL on SM.LedgerId = GL.LedgerId \n");
            strSql.Append("Where VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and(SM.[VNo] Like '%%' or '' = '') and(SM.Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("-- and InterBranch is null \n");
            strSql.Append("Order by VDate,SD.VoucherNo \n\n");

            strSql.Append("select SIT.VoucherNo,SIT.Sno,SIT.ProductId,CONVERT(DECIMAL(18, 2), SIT.TermRate) AS TermRate , CASE WHEN SIT.STSign = '+' then CONVERT(DECIMAL(18, 2),LocalTermAmt) else -CONVERT(DECIMAL(18, 2),LocalTermAmt) end as LocalTermAmt,SBT.TermDesc  from erp.SalesOrderTerm as SIT \n");
            strSql.Append("inner join ERP.SalesBillingTerm as SBT on SIT.TermId = SBT.TermId \n");
            strSql.Append("inner join ERP.SalesOrderMaster as SM on SM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType in('P','BT') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n\n");

            strSql.Append("SELECT SIT.VoucherNo,SUM(CASE WHEN SBT.STSign = '+' then LocalTermAmt else -LocalTermAmt end) as LocalTermAmt,SBT.TermDesc FROM ERP.SalesBillingTerm as SBT \n");
            strSql.Append("Left Outer join ERP.SalesOrderTerm as SIT on SIT.TermId = SBT.TermId \n");
            strSql.Append("INNER JOIN ERP.SalesOrderMaster as SIM on SIM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType IN('P', 'B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("GROUP BY SIT.VoucherNo,TermDesc \n\n");

            strSql.Append("SELECT SUM(CASE WHEN SBT.STSign = '+' then LocalTermAmt else -LocalTermAmt end) as LocalTermAmt,SBT.TermDesc FROM ERP.SalesBillingTerm as SBT \n");
            strSql.Append("Left Outer join ERP.SalesOrderTerm as SIT on SIT.TermId = SBT.TermId \n");
            strSql.Append("INNER JOIN ERP.SalesOrderMaster as SIM on SIM.VoucherNo = SIT.VoucherNo \n");
            strSql.Append("WHERE SIT.TermType IN('P', 'B') \n");
            strSql.Append("AND VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
            strSql.Append("--and( SIT.[VoucherNo] Like '%%' or '' = '') and (Unit = '' or '' = '' or Unit is null) \n");
            strSql.Append("--and IsBillCancel = 0 \n");
            strSql.Append("--and InterBranch is null \n");
            strSql.Append("GROUP BY TermDesc \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet SalesOrderRegisterDetailsVerticleDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            DataSet ds = SalesOrderRegisterDetailsVerticle(fromDate, toDate, BranchId, CompanyUnitId);
            DataTable dtResult = new DataTable();
            DataTable dtTerm = new DataTable();
            dtResult.Columns.Add("Date", typeof(string));
            dtResult.Columns.Add("Particular", typeof(string));
            dtResult.Columns.Add("Qty", typeof(string));
            dtResult.Columns.Add("Rate", typeof(string));
            dtResult.Columns.Add("Basic Amt", typeof(string));
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                dtTerm.Columns.Add(dr["TermDesc"].ToString(), typeof(string));
            }
            dtResult.Columns.Add("IsBold", typeof(string));
            DataView view = new DataView(ds.Tables[0]);
            DataTable DistinctVoucher = view.ToTable(true, "Voucher No", "Customer Name", "Date", "Miti");
            DataRow addNewdr;
            decimal _GQty = 0, _GBasicAmt = 0, _GNetAmt = 0;
            foreach (DataRow item in DistinctVoucher.Rows)
            {
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = item["Date"].ToString();
                addNewdr["Particular"] = "Inv. No. : " + item["Voucher No"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                addNewdr = dtResult.NewRow();
                addNewdr["Date"] = "Customer";
                addNewdr["Particular"] = item["Customer Name"].ToString();
                addNewdr["IsBold"] = "Y";
                dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                int i = 0;
                DataRow[] result = ds.Tables[0].Select("[Voucher No] = '" + item["Voucher No"].ToString() + "'");
                if (result.Length > 0)
                {
                    decimal _Qty = 0, _BasicAmt = 0, _NetAmt = 0;
                    foreach (DataRow row in result)
                    {
                        addNewdr = dtResult.NewRow();
                        addNewdr["Date"] = row["ProductShortName"].ToString();
                        addNewdr["Particular"] = row["ProductDesc"].ToString();
                        addNewdr["Qty"] = row["Qty"].ToString() + " " + row["ProductUnitDesc"].ToString();
                        addNewdr["Rate"] = row["Rate"].ToString();
                        addNewdr["Basic Amt"] = row["Basic Amt"].ToString();
                        _Qty = _Qty + Convert.ToDecimal(row["Qty"].ToString());
                        _BasicAmt = _BasicAmt + Convert.ToDecimal(row["Basic Amt"].ToString());
                        dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        // ADD TERMS
                        foreach (DataRow o in ds.Tables[1].Select("[VoucherNo] = '" + row["Voucher No"].ToString() + "' AND SNo ='" + row["SNo"].ToString() + "' "))
                        {
                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = o["TermDesc"].ToString();
                            addNewdr["Rate"] = o["TermRate"].ToString() + " %";
                            addNewdr["Basic Amt"] = o["LocalTermAmt"].ToString();
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                        i++;
                        if (i == result.Count())
                        {
                            addNewdr = dtResult.NewRow();
                            addNewdr["Particular"] = "Total :";
                            addNewdr["Qty"] = _Qty.ToString("0.00");
                            addNewdr["Basic Amt"] = _BasicAmt.ToString("0.00");
                            addNewdr["IsBold"] = "Y";
                            _GQty = _GQty + _Qty;
                            _GBasicAmt = _GBasicAmt + _BasicAmt;
                            _GNetAmt = _GNetAmt + _NetAmt;
                            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
                        }
                    }
                }
            }

            addNewdr = dtResult.NewRow();
            addNewdr["Particular"] = "Grand Total :";
            addNewdr["Qty"] = _GQty.ToString("0.00");
            addNewdr["Basic Amt"] = _GBasicAmt.ToString("0.00");
            //addNewdr["Net Amt"] = _GNetAmt.ToString("0.00");
            addNewdr["IsBold"] = "Y";
            //foreach (DataColumn col1 in dtTerm.Columns)
            //{
            //    DataTable ddd = ds.Tables[3].AsEnumerable().Where(rows => rows.Field<string>("TermDesc") == col1.ColumnName).CopyToDataTable();
            //    addNewdr[col1.ColumnName] = Convert.ToDecimal(ddd.Rows[0]["LocalTermAmt"].ToString()).ToString("0.00");
            //}
            dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
            DataSet dsResutl = new DataSet();
            dsResutl.Tables.Add(dtResult);
            dsResutl.Tables.Add(dtTerm);
            return dsResutl;
        }
        #endregion
    }
}
