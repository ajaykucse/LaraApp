using DataAccessLayer.Interface.FinanceReport;
using System;
using System.Data;
using System.Text;

namespace DataAccessLayer.FinanceReport
{
	public class ClsRptAllLedger : IRptAllLedger
	{
		private ActiveDataAccess.ActiveDataAccess DAL;

		public ClsRptAllLedger()
		{
			DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
		}

		public DataSet AllLedgerSummary(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId, string _LedgerId)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("With LedgerReport(LedgerId , OpeningDebit, OpeningCredit,PerodicDebit,PerodicCredit) \n");
			strSql.Append("as ( \n");
			strSql.Append("Select LedgerId,CASE WHEN SUM(LocalDrAmt -LocalCrAmt) > 0 THEN SUM(LocalDrAmt -LocalCrAmt) ELSE 0 END OpeningDebit, \n");
			strSql.Append("CASE WHEN SUM(LocalDrAmt -LocalCrAmt) > 0 THEN 0 else abs(SUM(LocalDrAmt -LocalCrAmt)) END OpeningCredit, 0 PerodicDebit, 0 PerodicCredit \n");
			strSql.Append("from ERP.FinanceTransaction  \n");
			strSql.Append("where VDate < '" + fromDate.ToString("yyyy-MM-dd") + "' \n");
			if (!string.IsNullOrEmpty(_LedgerId))
				strSql.Append("and LedgerId IN (SELECT Value FROM fn_Splitstring('" + _LedgerId + "', ','))\n");
			strSql.Append("Group By LedgerId\n");
			strSql.Append("Union All\n");
			strSql.Append("Select LedgerId,0 OpeningDebit, 0 OpeningCredit,Sum(LocalDrAmt) PerodicDebit,Sum(LocalCrAmt) PerodicCredit\n");
			strSql.Append("from ERP.FinanceTransaction \n");
			strSql.Append("where VDate Between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "' \n");
			if (!string.IsNullOrEmpty(_LedgerId))
				strSql.Append("and LedgerId IN (SELECT Value FROM fn_Splitstring('" + _LedgerId + "', ','))\n");
			strSql.Append("Group By LedgerId\n");
			strSql.Append(")\n");
			strSql.Append("Select GlShortName, GlDesc, Sum(OpeningDebit) OpeningDebit, Sum(OpeningCredit) OpeningCredit,Sum(PerodicDebit) PerodicDebit,SUm(PerodicCredit)  PerodicCredit,Sum(PerodicDebit-PerodicCredit) Balance, \n");
			strSql.Append("case when Sum(((OpeningDebit-OpeningCredit) + (PerodicDebit-PerodicCredit))) >= 0 then Sum(((OpeningDebit-OpeningCredit) + ( PerodicDebit-PerodicCredit))) else 0 end ClosingDebit,\n");
			strSql.Append("case when Sum((OpeningCredit-OpeningDebit) + (PerodicCredit-PerodicDebit)) <= 0 then  0 else abs(Sum((OpeningCredit-OpeningDebit) + (PerodicCredit-PerodicDebit))) end ClosingCredit\n");
			strSql.Append("from LedgerReport as LR\n");
			strSql.Append("inner Join ERP.GeneralLedger Gl on Lr.LedgerId=Gl.LedgerId\n");
			strSql.Append("Group By GlDesc,GlShortName\n");
			strSql.Append("Order By GlDesc,GlShortName");
			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		public DataSet AllLedgerSummaryLedgerWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId, string _LedgerId)
		{
			DataSet ds = AllLedgerSummary(fromDate, toDate, BranchId, CompanyUnitId, _LedgerId);
			DataSet dsResutl = new DataSet();
			DataTable dtResult = new DataTable();
			dtResult.Columns.Add("Code", typeof(string));
			dtResult.Columns.Add("Description", typeof(string));
			dtResult.Columns.Add("O Dr", typeof(string));
			dtResult.Columns.Add("O Cr", typeof(string));
			dtResult.Columns.Add("P Dr", typeof(string));
			dtResult.Columns.Add("P Cr", typeof(string));
			dtResult.Columns.Add("Balance", typeof(string));
			dtResult.Columns.Add("C Dr", typeof(string));
			dtResult.Columns.Add("C Cr", typeof(string));
			dtResult.Columns.Add("IsBold", typeof(string));
			DataRow addNewdr; int i = 1; decimal _TotalODr = 0, _TotalOCr = 0, _TotalPDr = 0, _TotalPCr = 0, _TotalBalance = 0, _TotalCDr = 0, _TotalCCr = 0;
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				_TotalODr = _TotalODr + Convert.ToDecimal(item["OpeningDebit"].ToString());
				_TotalOCr = _TotalOCr + Convert.ToDecimal(item["OpeningCredit"].ToString());
				_TotalPDr = _TotalPDr + Convert.ToDecimal(item["PerodicDebit"].ToString());
				_TotalPCr = _TotalPCr + Convert.ToDecimal(item["PerodicCredit"].ToString());
				_TotalBalance = _TotalBalance + Convert.ToDecimal(item["Balance"].ToString());
				_TotalCDr = _TotalCDr + Convert.ToDecimal(item["ClosingDebit"].ToString());
				_TotalCCr = _TotalCCr + Convert.ToDecimal(item["ClosingCredit"].ToString());
				addNewdr = dtResult.NewRow();
				addNewdr["Code"] = item["GlShortName"].ToString();
				addNewdr["Description"] = item["GlDesc"].ToString();
				addNewdr["O Dr"] = Convert.ToDecimal(item["OpeningDebit"].ToString()) > 0 ? Convert.ToDecimal(item["OpeningDebit"].ToString()).ToString("0.00") : "";
				addNewdr["O Cr"] = Convert.ToDecimal(item["OpeningCredit"].ToString()) > 0 ? Convert.ToDecimal(item["OpeningCredit"].ToString()).ToString("0.00") : "";
				addNewdr["P Dr"] = Convert.ToDecimal(item["PerodicDebit"].ToString()) > 0 ? Convert.ToDecimal(item["PerodicDebit"].ToString()).ToString("0.00") : "";
				addNewdr["P Cr"] = Convert.ToDecimal(item["PerodicCredit"].ToString()) > 0 ? Convert.ToDecimal(item["PerodicCredit"].ToString()).ToString("0.00") : "";
				addNewdr["Balance"] = Convert.ToDecimal(item["Balance"].ToString()) != 0 ? Convert.ToDecimal(item["Balance"].ToString()).ToString("0.00") : "";
				addNewdr["C Dr"] = Convert.ToDecimal(item["ClosingDebit"].ToString()) > 0 ? Convert.ToDecimal(item["ClosingDebit"].ToString()).ToString("0.00") : "";
				addNewdr["C Cr"] = Convert.ToDecimal(item["ClosingCredit"].ToString()) > 0 ? Convert.ToDecimal(item["ClosingCredit"].ToString()).ToString("0.00") : "";
				dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
				if (i == ds.Tables[0].Rows.Count)
				{
					addNewdr = dtResult.NewRow();
					addNewdr["Description"] = "Total :";
					addNewdr["P Dr"] = _TotalPDr.ToString("0.00");
					addNewdr["P Cr"] = _TotalPCr.ToString("0.00");
					addNewdr["O Dr"] = _TotalODr.ToString("0.00");
					addNewdr["O Cr"] = _TotalOCr.ToString("0.00");
					addNewdr["Balance"] = _TotalBalance.ToString("0.00");
					addNewdr["C Dr"] = _TotalCDr.ToString("0.00");
					addNewdr["C Cr"] = _TotalCCr.ToString("0.00");
					addNewdr["IsBold"] = "Y";
					dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
				}
				i++;
			}

			//DataView view = new DataView(ds.Tables[0]);
			//DataTable DistinctVoucher = view.ToTable(true, "GlShortName");
			//DataRow addNewdr; int i = 1; decimal _TotalPDr = 0, _TotalPCr=0, _TotalBalance = 0;
			//foreach (DataRow item in DistinctVoucher.Rows)
			//{
			//    DataTable _newDataTable = ds.Tables[0].Select("GlShortName = '" + item["GlShortName"].ToString() + "'").CopyToDataTable();
			//    decimal LocalDrAmt = Convert.ToDecimal(_newDataTable.Compute("SUM(LocalDrAmt)", string.Empty));
			//    decimal LocalCrAmt = Convert.ToDecimal(_newDataTable.Compute("SUM(LocalCrAmt)", string.Empty));
			//    _TotalPDr = _TotalPDr + LocalDrAmt;
			//    _TotalPCr = _TotalPCr + LocalCrAmt;
			//    _TotalBalance = _TotalBalance + (LocalDrAmt - LocalCrAmt);
			//    addNewdr = dtResult.NewRow();
			//    addNewdr["Code"] = _newDataTable.Rows[0]["GlShortName"].ToString();
			//    addNewdr["Description"] = _newDataTable.Rows[0]["GlDesc"].ToString();
			//    addNewdr["O Dr"] = "0";
			//    addNewdr["O Cr"] = "0";
			//    addNewdr["P Dr"] = LocalDrAmt.ToString("0.00");
			//    addNewdr["P Cr"] = LocalCrAmt.ToString("0.00");
			//    if ((LocalDrAmt - LocalCrAmt) >= 0)
			//        addNewdr["Balance"] = (LocalDrAmt - LocalCrAmt).ToString("0.00") + " Dr";
			//    else
			//        addNewdr["Balance"] = Math.Abs((LocalDrAmt - LocalCrAmt)).ToString("0.00") + " Cr";
			//    dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
			//    if (i == DistinctVoucher.Rows.Count)
			//    {
			//        addNewdr = dtResult.NewRow();
			//        addNewdr["Description"] = "Total :";
			//        addNewdr["P Dr"] = _TotalPDr.ToString("0.00");
			//        addNewdr["P Cr"] = _TotalPCr.ToString("0.00");
			//        addNewdr["Balance"] = _TotalBalance.ToString("0.00");
			//        addNewdr["IsBold"] = "Y";
			//        dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
			//    }
			//    i++;
			//}
			dsResutl.Tables.Add(dtResult);

			return dsResutl;
		}

		public DataSet AllLedgerDetails(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId, string _LedgerId)
		{
			StringBuilder strSql = new StringBuilder();
			//strSql.Append($@"
			strSql.Append("----OPENING DATA----\n");
			strSql.Append("Select '' AS VDate,'' AS VMiti,'' AS VocherNo, GlDesc,GlShortName,0 AS LocalDrAmt,0 AS LocalCrAmt, sum(LocalDrAmt)-sum(LocalCrAmt) as Opening,0 as Odr,'' as Naration from ERP.FinanceTransaction FT,ERP.GeneralLedger GL\n");
			strSql.Append("where FT.LedgerId=gl.LedgerId and VDate < '" + fromDate.ToString("yyyy-MM-dd") + "'\n");
			if (!string.IsNullOrEmpty(_LedgerId))
				strSql.Append("and FT.LedgerId IN(SELECT Value FROM fn_Splitstring('" + _LedgerId + "', ','))\n");
			strSql.Append("group by GlShortName, GlDesc\n");
			strSql.Append("union all\n");
			strSql.Append("----PERIODIC DATA----\n");
			strSql.Append("Select CONVERT(VARCHAR(10),VDate,103) as VDate, VMiti,\n");
			strSql.Append("Case\n");
			strSql.Append("when Source='CB' then 'CashBank Entry '+ ': ' + VoucherNo\n");
			strSql.Append("when Source='SB' then 'Sales Invoice '+ ': ' + VoucherNo\n");
			strSql.Append("when Source='SR' then 'Sales Return '+ ': ' + VoucherNo\n");
			strSql.Append("when Source='PB' then 'Purchase Invoice '+ ': ' + VoucherNo\n");
			strSql.Append("when Source='PR' then 'Purchase Return '+ ': ' + VoucherNo\n");
			strSql.Append("else 'VoucherNo' + ': ' + VoucherNo end as VocherNo,\n");
			strSql.Append("GlDesc,GlShortName,LocalDrAmt,LocalCrAmt,0 AS Opening,1 as Odr,Naration from ERP.FinanceTransaction FT,ERP.GeneralLedger GL\n");
			strSql.Append("where FT.LedgerId=gl.LedgerId  and VDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "'\n");
			if (!string.IsNullOrEmpty(_LedgerId))
				strSql.Append("and FT.LedgerId IN(SELECT Value FROM fn_Splitstring('" + _LedgerId + "', ','))\n");
			strSql.Append("Order By GlDesc,Odr");
			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		public DataSet AllLedgerDetailsLedgerWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId, bool isNarrationShow,string _LedgerId)
		{
			DataSet ds = AllLedgerDetails(fromDate, toDate, BranchId, CompanyUnitId, _LedgerId);
			DataSet dsResutl = new DataSet();
			DataTable dtResult = new DataTable();
			dtResult.Columns.Add("Date", typeof(string));
			dtResult.Columns.Add("Particular/Ledger", typeof(string));
			dtResult.Columns.Add("Dr Amount", typeof(string));
			dtResult.Columns.Add("Cr Amount", typeof(string));
			dtResult.Columns.Add("Balance", typeof(string));
			dtResult.Columns.Add(" ", typeof(string));
			dtResult.Columns.Add("IsBold", typeof(string));

			DataView view = new DataView(ds.Tables[0]);
			DataTable DistinctVoucher = view.ToTable(true, "GlDesc");
			DataRow addNewdr; decimal _TotalPDr = 0, _TotalPCr = 0, _TotalOpeningDr = 0, _TotalOpeningCr = 0, _GrandOpeningDr = 0, _GrandOpeningCr = 0, GrandPeriodicDr = 0, GrandPeriodicCr = 0, _RunningBalance = 0;
			for (int i = 0; i < DistinctVoucher.Rows.Count; i++)
			{
				DataTable _newDataTable1 = ds.Tables[0].Select("GlDesc = '" + DistinctVoucher.Rows[i]["GlDesc"].ToString() + "'").CopyToDataTable();
				for (int j = 0; j < _newDataTable1.Rows.Count; j++)
				{
					_TotalPDr = _TotalPDr + Convert.ToDecimal(_newDataTable1.Rows[j]["LocalDrAmt"].ToString());
					_TotalPCr = _TotalPCr + Convert.ToDecimal(_newDataTable1.Rows[j]["LocalCrAmt"].ToString());
					if (j == 0)
					{
						if (dtResult.Rows.Count > 0)
						{
							addNewdr = dtResult.NewRow(); dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
						}
						addNewdr = dtResult.NewRow();
						addNewdr["Particular/Ledger"] = _newDataTable1.Rows[j]["GlDesc"].ToString();
						addNewdr["IsBold"] = "Y";
						dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

						if (Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString()) != 0)  //opening
						{
							addNewdr = dtResult.NewRow();
							addNewdr["Particular/Ledger"] = "Opening Balance";
							addNewdr[Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString()) > 0 ? "Dr Amount" : "Cr Amount"] = Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString()).ToString("0.00");
							addNewdr["Balance"] = Math.Abs(Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString())).ToString("0.00");
							addNewdr[" "] = Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString()) < 0 ? "CR" : "DR";
							_RunningBalance = Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString());
							dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
							if (Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString()) > 0)
							{
								_TotalOpeningDr = Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString());
								_GrandOpeningDr = _GrandOpeningDr + Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString());
							}
							else
							{
								_TotalOpeningCr = Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString());
								_GrandOpeningCr = _GrandOpeningCr + Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString());
							}
						}
					}

					if (Convert.ToDecimal(_newDataTable1.Rows[j]["Opening"].ToString()) == 0)
					{
						_RunningBalance = _RunningBalance + (Convert.ToDecimal(_newDataTable1.Rows[j]["LocalDrAmt"].ToString()) - Convert.ToDecimal(_newDataTable1.Rows[j]["LocalCrAmt"].ToString()));
						addNewdr = dtResult.NewRow();
						addNewdr["Date"] = _newDataTable1.Rows[j]["VDate"].ToString();
						addNewdr["Particular/Ledger"] = _newDataTable1.Rows[j]["VocherNo"].ToString();
						addNewdr["Dr Amount"] = Convert.ToDecimal(_newDataTable1.Rows[j]["LocalDrAmt"].ToString()).ToString("0.00");
						addNewdr["Cr Amount"] = Convert.ToDecimal(_newDataTable1.Rows[j]["LocalCrAmt"].ToString()).ToString("0.00");
						addNewdr["Balance"] = Math.Abs(_RunningBalance).ToString("0.00");
						addNewdr[" "] = _RunningBalance < 0 ? "CR" : "DR";
						dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

						if (isNarrationShow == true && !string.IsNullOrEmpty(_newDataTable1.Rows[j]["Naration"].ToString()))
						{
							addNewdr = dtResult.NewRow();
							addNewdr["Date"] = "Narr :";
							addNewdr["Particular/Ledger"] = "    " + _newDataTable1.Rows[j]["Naration"].ToString();
							dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
						}
					}

					if (j == _newDataTable1.Rows.Count - 1)
					{
						_RunningBalance = 0;
						addNewdr = dtResult.NewRow();
						addNewdr["Particular/Ledger"] = "Periodic Total :";
						addNewdr["Dr Amount"] = _TotalPDr.ToString("0.00");
						addNewdr["Cr Amount"] = _TotalPCr.ToString("0.00");
						addNewdr["IsBold"] = "Y";
						dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

						addNewdr = dtResult.NewRow();
						addNewdr["Particular/Ledger"] = "A/C Total :";
						addNewdr["Dr Amount"] = (_TotalPDr + _TotalOpeningDr).ToString("0.00");
						addNewdr["Cr Amount"] = (_TotalPCr + _TotalOpeningCr).ToString("0.00");
						addNewdr["IsBold"] = "Y";
						dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

						GrandPeriodicDr = GrandPeriodicDr + _TotalPDr;
						GrandPeriodicCr = GrandPeriodicCr + _TotalPCr;

						_TotalPDr = 0; _TotalPCr = 0; _TotalOpeningDr = 0; _TotalOpeningCr = 0;
					}
				}

				if ((DistinctVoucher.Rows.Count - 1) == i)
				{
					addNewdr = dtResult.NewRow();
					addNewdr["Particular/Ledger"] = "Grand Opening Total :";
					addNewdr["Dr Amount"] = _GrandOpeningDr.ToString("0.00");
					addNewdr["Cr Amount"] = _GrandOpeningCr.ToString("0.00");
					addNewdr["IsBold"] = "Y";
					dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

					addNewdr = dtResult.NewRow();
					addNewdr["Particular/Ledger"] = "Grand Periodic Total :";
					addNewdr["Dr Amount"] = GrandPeriodicDr.ToString("0.00");
					addNewdr["Cr Amount"] = GrandPeriodicCr.ToString("0.00");
					addNewdr["IsBold"] = "Y";
					dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);

					addNewdr = dtResult.NewRow();
					addNewdr["Particular/Ledger"] = "Grand Total :";
					addNewdr["Dr Amount"] = (_GrandOpeningDr + GrandPeriodicDr).ToString("0.00");
					addNewdr["Cr Amount"] = (_GrandOpeningCr + GrandPeriodicCr).ToString("0.00");
					addNewdr["IsBold"] = "Y";
					dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
				}
			}
			dsResutl.Tables.Add(dtResult);

			return dsResutl;
		}

        public DataSet DayBook(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($@"
--opening
select LedgerId,sum(LocalDrAmt)-sum(LocalCrAmt) as Amt   
from ERP.FinanceTransaction where LedgerId  in (select CashLedgerId From ERP.SystemSetting)  and VDate < '{fromDate.ToString("yyyy-MM-dd")}'
group by LedgerId  Having sum(LocalDrAmt)-Sum(LocalCrAmt)<>0 

select VDate as Date,VMiti as Miti,Vtime,VoucherNo as [Voucher No],Currency.CurrencyDesc as Currency,FinanceTransaction.CurrencyRate,(ISNULL(cls.DepartmentDesc,'')+'|'+ ISNULL(cls1.DepartmentDesc,'')+'|'+ ISNULL(cls2.DepartmentDesc,'')) as Class,gl.GlDesc as Particulars, Sl.SubledgerDesc as SubLedger,Salesman.SalesmanDesc as Agent,Naration,Remarks ,
case when Source='JV' then 'Journal Voucher' 
when Source='CB' then 'Cash/Bank Voucher' 
when Source='DN' then 'Debit Note'  
when Source='CN' then 'Credit Note' 
when Source='SB' then 'Sales Bill'  
when Source='PB' then 'Purchase Bill'  
when Source='PA' then 'Purchase Bill Aditional' 
when Source='PEB' then 'Purchase Ex/Br Return ' 
when Source='IBP' then 'Inter Branch Purchase '
when Source='PR' then 'Purchase Return' 
when Source='SR' then 'Sales Return' 
when Source='SAB' then 'Sales Additional Invoice'
when Source='IBS' then 'Inter Branch Sales' 
when Source='SEB' then 'Sales Ex/Br Return'
end as Source ,chequeNo,ChequeDate, 
(case when sum(DrAmt-Cramt) >= 0 then sum(DrAmt-CrAmt) else 0  end) as [DrAmt], (case when sum(DrAmt-Cramt) < 0 then abs(sum(DrAmt-CrAmt)) else 0  end) as [CrAmt], 
(case when sum(LocalDrAmt-LocalCrAmt) >= 0 then sum(LocalDrAmt-LocalCrAmt) else 0 end) as [Dr Amount] ,  
(case when sum(LocalDrAmt-LocalCrAmt) < 0 then abs(sum(LocalDrAmt-LocalCrAmt)) else 0 end) as [Cr Amount]   
from ERP.FinanceTransaction  
left outer join ERP.GeneralLedger as GL on FinanceTransaction.LedgerId=GL.LedgerId 
left outer join ERP.SubLedger as Sl on FinanceTransaction.SubLedgerId=Sl.SubLedgerId 
left outer join ERP.Salesman  on FinanceTransaction.SalesmanId=Salesman.SalesmanId 
left outer join ERP.Department cls on FinanceTransaction.DepartmentId1=cls.DepartmentId 
left outer join ERP.Department cls1 on FinanceTransaction.DepartmentId2=cls1.DepartmentId 
left outer join ERP.Department cls2 on FinanceTransaction.DepartmentId3=cls2.DepartmentId 
left outer join ERP.Currency on FinanceTransaction.CurrencyId=Currency.CurrencyId 
where (LocalDrAmt <> 0 or LocalCrAmt <> 0)  
AND VDate between '{fromDate.ToString("yyyy-MM-dd")}' and '{toDate.ToString("yyyy-MM-dd")}' 
and Source in ('CB','JV','DN','CN','PB','PA','IBP','PR','PEB','SB','SAB','IBS','SR','SEB') 
group by VoucherNo,VDate,VMiti,VTime,Currency.CurrencyDesc,FinanceTransaction.CurrencyRate,cls.DepartmentDesc,cls1.DepartmentDesc,cls2.DepartmentDesc,FinanceTransaction.LedgerId,gl.GlDesc, Sl.SubledgerDesc,SalesmanDesc,Naration,Remarks,Source,chequeNo,ChequeDate 
Order by VDate,Source,VoucherNo,[Dr Amount] Desc,GLDesc, (Case when ERP.FinanceTransaction.LedgerId in (select CashLedgerId From ERP.SystemSetting) then 0 else VTime End),VTime asc 

--closing
select LedgerId,sum(LocalDrAmt)-sum(LocalCrAmt) as Amt 
from ERP.FinanceTransaction where LedgerId in (select CashLedgerId From ERP.SystemSetting)   and VDate <= '{fromDate.ToString("yyyy-MM-dd")}'   
group by LedgerId  Having sum(LocalDrAmt)-Sum(LocalCrAmt)<>0");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

		public DataSet DayBookDateWise(DateTime fromDate, DateTime toDate, int BranchId, int CompanyUnitId, bool isNarrationShow)
		{
			DataSet ds = DayBook(fromDate, toDate, BranchId, CompanyUnitId);
			DataSet dsResutl = new DataSet();
			DataTable dtResult = new DataTable();
			dtResult.Columns.Add("Date", typeof(string));
			dtResult.Columns.Add("Voucher No", typeof(string));
			dtResult.Columns.Add("Particulars", typeof(string));
			dtResult.Columns.Add("Dr Amount", typeof(string));
			dtResult.Columns.Add("Cr Amount", typeof(string));
			dtResult.Columns.Add("IsBold", typeof(string));

			DataView view = new DataView(ds.Tables[1]);
			DataTable DistinctDate = view.ToTable(true, "Date");
			DataRow addNewdr; 
			for (int i = 0; i < DistinctDate.Rows.Count; i++)
			{
				int _IsPrintDate = 0; decimal _DayDrAmount = 0, _DayCrAmount = 0;
				DataTable _newDataTable1 = ds.Tables[1].Select("Date = '" + DistinctDate.Rows[i]["Date"].ToString() + "'").CopyToDataTable();
				DataView view1 = new DataView(_newDataTable1);
				DataTable DistinctVoucher = view1.ToTable(true, "Voucher No");
				for (int j = 0; j < DistinctVoucher.Rows.Count; j++)
				{
					DataTable _newDataTable2 = _newDataTable1.Select("[Voucher No] = '" + DistinctVoucher.Rows[j]["Voucher No"].ToString() + "'").CopyToDataTable();
					decimal _DrAmount = 0, _CrAmount = 0;
					for (int k = 0; k < _newDataTable2.Rows.Count; k++)
					{
						addNewdr = dtResult.NewRow();
						addNewdr["Date"] = _IsPrintDate == 0 ? Convert.ToDateTime(_newDataTable2.Rows[j]["Date"].ToString()).ToShortDateString() : DBNull.Value.ToString();
						addNewdr["Particulars"] = _newDataTable2.Rows[k]["Particulars"].ToString();
						addNewdr["Voucher No"] = k == 0 ? _newDataTable2.Rows[k]["Voucher No"].ToString() : DBNull.Value.ToString();
						addNewdr["Dr Amount"] = Convert.ToDecimal(_newDataTable2.Rows[k]["Dr Amount"].ToString()).ToString("0.00");
						addNewdr["Cr Amount"] = Convert.ToDecimal(_newDataTable2.Rows[k]["Cr Amount"].ToString()).ToString("0.00");
						_DrAmount = _DrAmount + Convert.ToDecimal(_newDataTable2.Rows[k]["Dr Amount"].ToString());
						_CrAmount = _CrAmount + Convert.ToDecimal(_newDataTable2.Rows[k]["Cr Amount"].ToString());
						dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
						_IsPrintDate++;

						if (isNarrationShow == true && !string.IsNullOrEmpty(_newDataTable2.Rows[k]["Naration"].ToString()))
						{
							addNewdr = dtResult.NewRow();
							addNewdr["Voucher No"] = "Narr :";
							addNewdr["Particulars"] = "    " + _newDataTable2.Rows[k]["Naration"].ToString();
							dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
						}

						if (_newDataTable2.Rows.Count - 1 == k)
						{
							addNewdr = dtResult.NewRow();
							addNewdr["Particulars"] = "Total :";
							addNewdr["Dr Amount"] = _DrAmount.ToString("0.00");
							addNewdr["Cr Amount"] = _CrAmount.ToString("0.00");
							addNewdr["IsBold"] = "Y";
							dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
						}
						_DayDrAmount = _DayDrAmount + Convert.ToDecimal(_newDataTable2.Rows[k]["Dr Amount"].ToString());
						_DayCrAmount = _DayCrAmount + Convert.ToDecimal(_newDataTable2.Rows[k]["Cr Amount"].ToString());
					}
				}

				addNewdr = dtResult.NewRow();
				addNewdr["Particulars"] = "Day Total :";
				addNewdr["Dr Amount"] = _DayDrAmount.ToString("0.00");
				addNewdr["Cr Amount"] = _DayCrAmount.ToString("0.00");
				addNewdr["IsBold"] = "Y";
				dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
			}

			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					addNewdr = dtResult.NewRow();
					addNewdr["Particulars"] = "Opening";
					if (Convert.ToDecimal(ds.Tables[0].Rows[0]["Amt"].ToString()) > 0)
						addNewdr["Dr Amount"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["Amt"]).ToString("0.00");
					else
						addNewdr["Cr Amount"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[0]["Amt"])).ToString("0.00");
					addNewdr["IsBold"] = "Y";
					dtResult.Rows.InsertAt(addNewdr, 0);
				}
			}
			if (ds.Tables[2].Rows.Count > 0)
			{
				if (ds.Tables[2].Rows.Count > 0)
				{
					addNewdr = dtResult.NewRow();
					addNewdr["Particulars"] = "Closing";
					if (Convert.ToDecimal(ds.Tables[2].Rows[0]["Amt"].ToString()) > 0)
						addNewdr["Cr Amount"] = Math.Abs(Convert.ToDecimal(ds.Tables[2].Rows[0]["Amt"])).ToString("0.00");
					else
						addNewdr["Dr Amount"] = Math.Abs(Convert.ToDecimal(ds.Tables[2].Rows[0]["Amt"])).ToString("0.00");
					addNewdr["IsBold"] = "Y";
					dtResult.Rows.InsertAt(addNewdr, dtResult.Rows.Count + 1);
				}
			}
			dsResutl.Tables.Add(dtResult);
			return dsResutl;
		}
    }
}
