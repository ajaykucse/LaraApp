﻿using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.Common
{
	public partial class PickList : Form
	{
		public List<DataRow> SelectedList = new List<DataRow>();
		public string SearchCol, _SearchKey = "";
		public static DataTable dt;
		private ClsPickList _objPickList = new ClsPickList();
		private string _SplitedValue = string.Empty;
        public PickList(string ListType, string SearchKey)
        {
            InitializeComponent();
            GetList(ListType);
            if (SearchKey == "Return" || SearchKey == "\r")
                SearchKey = string.Empty;
            _SearchKey = SearchKey;
        }

		#region --------------- NOT CHNAGE ---------------------
		private void PickList_Load(object sender, EventArgs e)
		{
			Search(_SearchKey);
		}
		private void PickList_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 8)
			{
				if (TxtSearch.Text.Length > 0)
				{
					TxtSearch.Text = TxtSearch.Text.Substring(0, TxtSearch.Text.Length - 1);
				}
			}
			else if (e.KeyChar == 27)
			{
				//this._searchKey = ((int)e.KeyChar).ToString();
				Close();
			}
			else if (e.KeyChar == 13)
			{
				if (Grid.CurrentRow != null)
				{
					DataTable dt1 = GetDataTable();
					SelectedList.Add(dt1.Rows[Grid.CurrentRow.Index]);
				}
				Close();
			}
			else
			{
				TxtSearch.Text += e.KeyChar.ToString();
			}
		}
		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			Grid.Focus();
			Search(TxtSearch.Text);
		}

		private void Search(string SearchText)
		{
			int i;
			string searchCol;
			string[] strArrays;
			int num = 0;
			int rowIndex = 0;
			BindingSource bindingSources = new BindingSource();
			if ((string.IsNullOrEmpty(SearchText) ? true : !(SearchText != "F1")))
			{
				try
				{
					bindingSources.DataSource = Grid.DataSource;
					i = 0;
					SearchCol = "";
					if (Grid.RowCount > 0)
					{
						for (i = 0; i <= Grid.Columns.Count - 1; i++)
						{
							if (i == Grid.Columns.Count - 1)
							{
								PickList _frmPicklist = this;
								searchCol = _frmPicklist.SearchCol;
								strArrays = new string[] { searchCol, string.Format(string.Concat("Convert(", Grid.Columns[i].DataPropertyName, ", 'System.String')"), new object[0]), " like '%", TxtSearch.Text, "%'" };
								_frmPicklist.SearchCol = string.Concat(strArrays);
							}
							else
							{
								PickList _frmPicklist1 = this;
								searchCol = _frmPicklist1.SearchCol;
								strArrays = new string[] { searchCol, string.Format(string.Concat("Convert(", Grid.Columns[i].DataPropertyName, ", 'System.String')"), new object[0]), " like '%", TxtSearch.Text, "%' or " };
								_frmPicklist1.SearchCol = string.Concat(strArrays);
							}
						}
						bindingSources.Filter = SearchCol;
						Grid.DataSource = bindingSources;
						rowIndex = Grid.CurrentCell.RowIndex;
						Grid.Rows[0].Cells[num].Selected = true;
					}
				}
				catch
				{
				}
			}
			else
			{
				try
				{
					TxtSearch.Text = SearchText;
					bindingSources.DataSource = Grid.DataSource;
					i = 0;
					SearchCol = "";
					for (i = 0; i <= Grid.Columns.Count - 1; i++)
					{
						if (i == Grid.Columns.Count - 1)
						{
							PickList _frmPicklist2 = this;
							searchCol = _frmPicklist2.SearchCol;
							strArrays = new string[] { searchCol, string.Format(string.Concat("Convert([", Grid.Columns[i].DataPropertyName, "], 'System.String')"), new object[0]), " like '%", TxtSearch.Text, "%'" };
							_frmPicklist2.SearchCol = string.Concat(strArrays);
						}
						else
						{
							PickList _frmPicklist3 = this;
							searchCol = _frmPicklist3.SearchCol;
							strArrays = new string[] { searchCol, string.Format(string.Concat("Convert([", Grid.Columns[i].DataPropertyName, "], 'System.String')"), new object[0]), " like '%", TxtSearch.Text, "%' or " };
							_frmPicklist3.SearchCol = string.Concat(strArrays);
						}
					}
					bindingSources.Filter = SearchCol;
					Grid.DataSource = bindingSources;
					DataGridViewRow dataGridViewRow = new DataGridViewRow();
					Grid.Rows[0].Cells[num].Selected = true;
				}
				catch
				{
				}
			}

		}

		private void SearchOld(string SearchText)
		{
			int colIndex = 0, rowIndex = 0;
			BindingSource bs = new BindingSource();
			if (!string.IsNullOrEmpty(SearchText) && SearchText != "F1")
			{
				try
				{
					TxtSearch.Text = SearchText;
					bs.DataSource = Grid.DataSource;

					bs.Filter = string.Format("Convert(" + SearchCol + ", 'System.String')") + " like '%" + TxtSearch.Text + "%'";
					//bs.Filter = string.Format("Convert(AccountGrpDesc, 'System.String')") + " like '%" + TxtSearch.Text + "%' OR  " + string.Format("Convert(AccountGrpShortName, 'System.String')") + " like '%" + TxtSearch.Text + "%'"; //"AccountGrpDesc = " + TxtSearch.Text + " or  AccountGrpShortName = '" + TxtSearch.Text + "'";
					Grid.DataSource = bs;


					DataGridViewRow row = new DataGridViewRow();
					Grid.Rows[0].Cells[colIndex].Selected = true;
				}
				catch
				{ }
			}
			else
			{
				try
				{
					bs.DataSource = Grid.DataSource;
					bs.Filter = string.Format("Convert(" + SearchCol + ", 'System.String')") + " like '%" + TxtSearch.Text + "%'";
					Grid.DataSource = bs;
					rowIndex = Grid.CurrentCell.RowIndex;
					Grid.Rows[0].Cells[colIndex].Selected = true;
				}
				catch
				{ }
			}
		}
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			//SelectedList = new List<DataRow>();
			_SearchKey = "";
			Close();
		}
		private void BtnOk_Click(object sender, EventArgs e)
		{
			if (Grid.CurrentRow != null)
			{
				DataTable dt1 = GetDataTable();
				SelectedList.Add(dt1.Rows[Grid.CurrentRow.Index]);
			}
			Close();
		}
		private void Grid_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = false;
				BtnOk.PerformClick();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				BtnCancel.PerformClick();
			}
		}
		private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BtnOk.PerformClick();
		}
		public DataTable GetDataTable()
		{
			DataTable dtLocal = new DataTable();
			dtLocal = dt.Clone();
			string colname = Grid.Columns[Grid.CurrentCell.ColumnIndex].Name;
			DataRow drLocal = null;
			foreach (DataGridViewRow dr in Grid.Rows)
			{
				drLocal = dtLocal.NewRow();
				for (int i = 0; i < Grid.Columns.Count; i++)
				{
					string item = Grid.Columns[i].DataPropertyName;
					drLocal[item] = dr.Cells[i].Value;
				}
				dtLocal.Rows.Add(drLocal);
			}
			return dtLocal;
		}
		//protected override void OnClosing(CancelEventArgs e)
		//{
		//    _searchKey = string.Empty;
		//}
		#endregion

		public void GetList(string ListType)
		{
			if (ListType.Contains("."))
			{
				string[] _ListType = ListType.Split('.');
				ListType = _ListType[0];
				_SplitedValue = _ListType[1];
			}

			switch (ListType)
			{
				case "AccountGroup":
					AccountGroupList();
					SearchCol = "AccountGrpDesc";
					break;
				case "AccountSubGroup":
					AccountSubGroupList();
					SearchCol = "AccountSubGrpDesc";
					break;
				case "Generalledger":
					GeneralledgerList();
					SearchCol = "GlDesc";
					break;
				case "PartyInfo":
					PartyInfoList();
					SearchCol = "GlDesc";
					break;
				case "Subledger":
					SubledgerList();
					SearchCol = "SubledgerDesc";
					break;
				case "FloorMaster":
					FloorList();
					SearchCol = "FloorDesc";
					break;
				case "TableMaster":
					TableList();
					SearchCol = "TableDesc";
					break;
				case "MainSalesman":
					MainSalesManList();
					SearchCol = "MainSalesmanDesc";
					break;
				case "SalesMan":
					SalesManList();
					SearchCol = "SalesmanDesc";
					break;
				case "MemberType":
					MemberTypeList();
					SearchCol = "MemberTypeDesc";
					break;
				case "MainArea":
					MainAreaList();
					SearchCol = "MainAreaDesc";
					break;
				case "SubArea":
					SubAreaList();
					SearchCol = "AreaDesc";
					break;
				case "Product":
					ProductList();
					SearchCol = "ProductDesc";
					break;
				case "RestaurantProduct":
					ProductrRestaurantList();
					SearchCol = "ProductDesc";
					break;
				case "ProductGroup":
					ProductGroupList();
					SearchCol = "ProductGrpDesc";
					break;
				case "ProductGroup1":
					ProductGroupList1();
					SearchCol = "ProductGrpDesc";
					break;
				case "ProductGroup2":
					ProductGroupList2();
					SearchCol = "ProductGrpDesc";
					break;
				case "ProductSubGroup":
					ProductSubGroupList();
					SearchCol = "ProductSubGrpDesc";
					break;
				case "ProductUnit":
					ProductUnitList();
					SearchCol = "ProductUnitDesc";
					break;
				case "Godown":
					GodownList();
					SearchCol = "GodownDesc";
					break;
				case "CostCenter":
					CostCenterList();
					SearchCol = "CostCenterDesc";
					break;
				case "Currency":
					CurrencyList();
					SearchCol = "CurrencyDesc";
					break;
				case "Department":
					DepartmentList("");
					SearchCol = "DepartmentDesc";
					break;
				case "DepartmentI":
					DepartmentList("I");
					SearchCol = "DepartmentDesc";
					break;
				case "DepartmentII":
					DepartmentList("II");
					SearchCol = "DepartmentDesc";
					break;
				case "DepartmentIII":
					DepartmentList("III");
					SearchCol = "DepartmentDesc";
					break;
				case "DepartmentIV":
					DepartmentList("IV");
					SearchCol = "DepartmentDesc";
					break;
				case "DepartmentV":
					DepartmentList("V");
					SearchCol = "DepartmentDesc";
					break;
				case "Counter":
					CounterList();
					SearchCol = "CounterDesc";
					break;
				case "Narration":
					NarrationList();
					SearchCol = "NarrationDesc";
					break;
				case "ModuleName":
					ModuleNameList();
					SearchCol = "ModuleName";
					break;
				case "DocumentDesign":
					DocumentDesignList();
					SearchCol = "DocDesc";
					break;
				case "Branch":
					BranchList();
					SearchCol = "BranchName";
					break;
				case "CompanyUnit":
					CompanyUnitList();
					SearchCol = "CmpUnitName";
					break;
				case "SalesBillingTerm":
					SalesBillingTermList();
					SearchCol = "TermDesc";
					break;
				case "PurchaseBillingTerm":
					PurchaseBillingTermList();
					SearchCol = "TermDesc";
					break;
				case "MenuPermissionGroup":
					MenuPermissionGroupList();
					SearchCol = "PremissionGroupName";
					break;
				case "UaserMaster":
					UserMasterList();
					SearchCol = "UserCode";
					break;
				case "DocumentNumber":
					DocumentNumberList();
					SearchCol = "DocDesc";
					break;
				case "UDFMaster":
					UDFMasterList();
					SearchCol = "FieldName";
					break;
				case "CashBankVoucher":
					CashBankVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "JournalVoucher":
					JournalVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "DebitNoteVoucher":
					DebitNoteVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "CreditNoteVoucher":
					CreditNoteVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "ProductScheme":
					ProductSchemeList();
					SearchCol = "SchemeId";
					break;
				case "SalesVoucher":
					SalesVoucherList();
					SearchCol = "VoucherNo";
					break;
                case "SalesVoucherForSalesReturn":
                    SalesVoucherListForSalesReturn();
                    SearchCol = "VoucherNo";
                    break;
                case "SalesChallanVoucherForChallanReturn":
                    SalesChallanVoucherListForChallanReturn();
                    SearchCol = "VoucherNo";
                    break;
                case "SalesReturnVoucher":
					SalesReturnVoucherList();
					SearchCol = "VoucherNo";
					break;
                case "SalesChallanReturnVoucher":
                    SalesChallanReturnVoucherList();
                    SearchCol = "VoucherNo";
                    break;
                case "SalesChallanVoucher":
					SalesChallanVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "SalesChallanOutstandingList":
					SalesChallanOutstandingList();
					SearchCol = "VoucherNo";
					break;
				case "PurchaseChallanOutstandingVoucher":
					PurchaseChallanOutstandingVoucher();
					SearchCol = "VoucherNo";
					break;
					
				case "PurchaseVoucher":
					PurchaseVoucherList();
					SearchCol = "VoucherNo";
					break;
                case "PurchaseVoucherForPurchaseReturn":
                    PurchaseVoucherListForPurchaseReturn();
                    SearchCol = "VoucherNo";
                    break;
                case "PurchaseChallanForChallanReturn":
                    PurchaseChallanVoucherListForPurchaseChallanReturn();
                    SearchCol = "VoucherNo";
                    break;
                case "PurchaseReturnVoucher":
					PurchaseReturnVoucherList();
					SearchCol = "VoucherNo";
					break;
                case "PurchaseChallanReturnVoucher":
                    PurchaseChallanReturnVoucherList();
                    SearchCol = "VoucherNo";
                    break;
                case "PurchaseOrderVoucher":
					PurchaseOrderVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "PurchaseOrderOutstanding":
					PurchaseOrderOutstandingVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "PurchaseChallanVoucher":
					PurchaseChallanVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "PurchaseQuotation":
					PurchaseQuotationVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "PurchaseIndent":
					PurchaseIndentVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "SalesOrderVoucher":
					SalesOrderVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "SalesOrderOutstandingList":
					SalesOrderOutstandingList();
					SearchCol = "VoucherNo";
					break;
				case "SalesQuotationVoucherList":
					SalesQuotationVoucherList();
					SearchCol = "VoucherNo";
					break;
				case "SalesQuotationOutstandingList":
					SalesQuotationOutstandingList();
					SearchCol = "VoucherNo";
					break;
				case "Waiter":
					WaiterList();
					SearchCol = "UserCode";
					break;
				case "PageName":
					PageNameList();
					SearchCol = "PageName";
					break;
				case "BOMVoucher":
					BOMVoucherList();
					SearchCol = "BillOfMaterialDesc";
					break;
			}
		}
		private void AccountGroupList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.AccountGroupList();
			Grid.DataSource = dt;

			DataTable dataTable = _objPickList.PickListTemplate("Master", "Account Group");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
		}
		private void AccountSubGroupList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.AccountSubGroupList(_SplitedValue);
			Grid.DataSource = dt;

			DataTable dataTable = _objPickList.PickListTemplate("Master", "Account Sub Group");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
		}
		private void GeneralledgerList()
		{
			Size = new System.Drawing.Size(900, 416);
			Grid.Size = new System.Drawing.Size(880, 339);

			Grid.AutoGenerateColumns = false;
			dt = _objPickList.GeneralLedgerList(_SplitedValue, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			DataTable dataTable = _objPickList.PickListTemplate("Master", "General Ledger");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
		}

		private void PartyInfoList()
		{
			Size = new System.Drawing.Size(900, 416);
			Grid.Size = new System.Drawing.Size(880, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PartyInfoList(_SplitedValue, ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;
			Grid.Columns.Add("LedgerId", "LedgerId");
			Grid.Columns["LedgerId"].DataPropertyName = "LedgerId";
			Grid.Columns["LedgerId"].Visible = false;
			Grid.Columns["LedgerId"].Width = 0;

			Grid.Columns.Add("GlDesc", "Party Name");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("GlShortName", "Shor tName");
			Grid.Columns["GlShortName"].DataPropertyName = "GlShortName";
			Grid.Columns["GlShortName"].Visible = true;
			Grid.Columns["GlShortName"].Width = 100;

			Grid.Columns.Add("GlPanNo", "Pan No");
			Grid.Columns["GlPanNo"].DataPropertyName = "GlPanNo";
			Grid.Columns["GlPanNo"].Width = 90;

			Grid.Columns.Add("Address", "Address");
			Grid.Columns["Address"].DataPropertyName = "Address";
			Grid.Columns["Address"].Width = 100;

			Grid.Columns.Add("MobileNo", "Mobile No");
			Grid.Columns["MobileNo"].DataPropertyName = "MobileNo";
			Grid.Columns["MobileNo"].Width = 100;
		}

		private void SubledgerList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SubLedgerListByLedgerId(ClsGlobal.LedgerId);
			Grid.DataSource = dt;
			Grid.Columns.Add("SubledgerId", "SubledgerId");
			Grid.Columns["SubledgerId"].DataPropertyName = "SubledgerId";
			Grid.Columns["SubledgerId"].Visible = false;
			Grid.Columns["SubledgerId"].Width = 0;

			Grid.Columns.Add("SubledgerDesc", "SubledgerDesc");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerShortName", "Code");
			Grid.Columns["SubledgerShortName"].DataPropertyName = "SubledgerShortName";
			Grid.Columns["SubledgerShortName"].Width = 120;

			Grid.Columns.Add("SubledgerType", "Type");
			Grid.Columns["SubledgerType"].DataPropertyName = "SubledgerType";
			Grid.Columns["SubledgerType"].Width = 120;
			Grid.Columns["SubledgerType"].Visible = true;
		}
		private void CostCenterList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.CostCenterListByLedgerId(ClsGlobal.LedgerId);
			Grid.DataSource = dt;

			Grid.Columns.Add("CostCenterId", "CostCenterId");
			Grid.Columns["CostCenterId"].DataPropertyName = "CostCenterId";
			Grid.Columns["CostCenterId"].Visible = false;
			Grid.Columns["CostCenterId"].Width = 0;

			Grid.Columns.Add("CostCenterDesc", "CostCenterDesc");
			Grid.Columns["CostCenterDesc"].DataPropertyName = "CostCenterDesc";
			Grid.Columns["CostCenterDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("CostCenterShortName", "Code");
			Grid.Columns["CostCenterShortName"].DataPropertyName = "CostCenterShortName";
			Grid.Columns["CostCenterShortName"].Width = 120;
		}
		private void GodownList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.GodownList();
			Grid.DataSource = dt;
			Grid.Columns.Add("GodownId", "GodownId");
			Grid.Columns["GodownId"].DataPropertyName = "GodownId";
			Grid.Columns["GodownId"].Visible = false;
			Grid.Columns["GodownId"].Width = 0;

			Grid.Columns.Add("GodownDesc", "GodownDesc");
			Grid.Columns["GodownDesc"].DataPropertyName = "GodownDesc";
			Grid.Columns["GodownDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("GodownShortname", "Code");
			Grid.Columns["GodownShortname"].DataPropertyName = "GodownShortname";
			Grid.Columns["GodownShortname"].Width = 120;
		}
		private void WaiterList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.WaiterList();
			Grid.DataSource = dt;
			Grid.Columns.Add("UserCode", "Waiter Code");
			Grid.Columns["UserCode"].DataPropertyName = "UserCode";
			Grid.Columns["UserCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("MobileNo", "MobileNo");
			Grid.Columns["MobileNo"].DataPropertyName = "MobileNo";
			Grid.Columns["MobileNo"].Width = 120;

		}
		private void FloorList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.FloorList();
			Grid.DataSource = dt;
			Grid.Columns.Add("FloorId", "FloorId");
			Grid.Columns["FloorId"].DataPropertyName = "FloorId";
			Grid.Columns["FloorId"].Visible = false;
			Grid.Columns["FloorId"].Width = 0;

			Grid.Columns.Add("FloorDesc", "FloorDesc");
			Grid.Columns["FloorDesc"].DataPropertyName = "FloorDesc";
			Grid.Columns["FloorDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("FloorShortName", "Code");
			Grid.Columns["FloorShortName"].DataPropertyName = "FloorShortName";
			Grid.Columns["FloorShortName"].Width = 120;
		}
		private void TableList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.TableList();
			Grid.DataSource = dt;
			Grid.Columns.Add("TableId", "TableId");
			Grid.Columns["TableId"].DataPropertyName = "TableId";
			Grid.Columns["TableId"].Visible = false;
			Grid.Columns["TableId"].Width = 0;

			Grid.Columns.Add("TableDesc", "TableDesc");
			Grid.Columns["TableDesc"].DataPropertyName = "TableDesc";
			Grid.Columns["TableDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("TableShortName", "Code");
			Grid.Columns["TableShortName"].DataPropertyName = "TableShortName";
			Grid.Columns["TableShortName"].Width = 120;
		}
		private void CurrencyList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.CurrencyList();
			Grid.DataSource = dt;
			Grid.Columns.Add("CurrencyId", "CurrencyId");
			Grid.Columns["CurrencyId"].DataPropertyName = "CurrencyId";
			Grid.Columns["CurrencyId"].Visible = false;
			Grid.Columns["CurrencyId"].Width = 0;

			Grid.Columns.Add("CurrencyDesc", "CurrencyDesc");
			Grid.Columns["CurrencyDesc"].DataPropertyName = "CurrencyDesc";
			Grid.Columns["CurrencyDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("CurrencyShortname", "Code");
			Grid.Columns["CurrencyShortname"].DataPropertyName = "CurrencyShortname";
			Grid.Columns["CurrencyShortname"].Width = 120;
		}
		private void DepartmentList(string Level)
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.DepartmentList(Level);
			Grid.DataSource = dt;
			Grid.Columns.Add("DepartmentId", "DepartmentId");
			Grid.Columns["DepartmentId"].DataPropertyName = "DepartmentId";
			Grid.Columns["DepartmentId"].Visible = false;
			Grid.Columns["DepartmentId"].Width = 0;

			Grid.Columns.Add("DepartmentDesc", "DepartmentDesc");
			Grid.Columns["DepartmentDesc"].DataPropertyName = "DepartmentDesc";
			Grid.Columns["DepartmentDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("DepartmentShortname", "Code");
			Grid.Columns["DepartmentShortname"].DataPropertyName = "DepartmentShortname";
			Grid.Columns["DepartmentShortname"].Width = 120;
		}
		private void CounterList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.CounterList();
			Grid.DataSource = dt;
			Grid.Columns.Add("CounterId", "CounterId");
			Grid.Columns["CounterId"].DataPropertyName = "CounterId";
			Grid.Columns["CounterId"].Visible = false;
			Grid.Columns["CounterId"].Width = 0;

			Grid.Columns.Add("CounterDesc", "CounterDesc");
			Grid.Columns["CounterDesc"].DataPropertyName = "CounterDesc";
			Grid.Columns["CounterDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("CounterShortname", "Code");
			Grid.Columns["CounterShortname"].DataPropertyName = "CounterShortname";
			Grid.Columns["CounterShortname"].Width = 120;
		}
		private void NarrationList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.NarrationList();
			Grid.DataSource = dt;
			Grid.Columns.Add("NarrationId", "NarrationId");
			Grid.Columns["NarrationId"].DataPropertyName = "NarrationId";
			Grid.Columns["NarrationId"].Visible = false;
			Grid.Columns["NarrationId"].Width = 0;

			Grid.Columns.Add("NarrationDesc", "NarrationDesc");
			Grid.Columns["NarrationDesc"].DataPropertyName = "NarrationDesc";
			Grid.Columns["NarrationDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("NarrationType", "Narration Type");
			Grid.Columns["NarrationType"].DataPropertyName = "NarrationType";
			Grid.Columns["NarrationType"].Width = 120;
		}
		private void MainSalesManList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.MainSalesManList();
			Grid.DataSource = dt;
			Grid.Columns.Add("MainSalesmanId", "MainSalesmanId");
			Grid.Columns["MainSalesmanId"].DataPropertyName = "MainSalesmanId";
			Grid.Columns["MainSalesmanId"].Visible = false;
			Grid.Columns["MainSalesmanId"].Width = 0;

			Grid.Columns.Add("MainSalesmanDesc", "MainSalesmanDesc");
			Grid.Columns["MainSalesmanDesc"].DataPropertyName = "MainSalesmanDesc";
			Grid.Columns["MainSalesmanDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("MainSalesmanShortName", "Code");
			Grid.Columns["MainSalesmanShortName"].DataPropertyName = "MainSalesmanShortName";
			Grid.Columns["MainSalesmanShortName"].Width = 120;
		}
		private void SalesManList()
		{
			Grid.AutoGenerateColumns = false;
			if (ClsGlobal.SalesmanType == "Member")
			{
				dt = _objPickList.MemberList();
			}
			else
			{
				dt = _objPickList.SalesManList();
			}

			Grid.DataSource = dt;
			Grid.Columns.Add("SalesmanId", "SalesmanId");
			Grid.Columns["SalesmanId"].DataPropertyName = "SalesmanId";
			Grid.Columns["SalesmanId"].Visible = false;
			Grid.Columns["SalesmanId"].Width = 0;

			Grid.Columns.Add("SalesmanDesc", "SalesmanDesc");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SalesmanShortName", "Code");
			Grid.Columns["SalesmanShortName"].DataPropertyName = "SalesmanShortName";
			Grid.Columns["SalesmanShortName"].Width = 120;
		}
		private void MemberTypeList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.MemberTypeList();
			Grid.DataSource = dt;
			Grid.Columns.Add("MemberTypeId", "MemberTypeId");
			Grid.Columns["MemberTypeId"].DataPropertyName = "MemberTypeId";
			Grid.Columns["MemberTypeId"].Visible = false;
			Grid.Columns["MemberTypeId"].Width = 0;

			Grid.Columns.Add("MemberTypeDesc", "MemberTypeDesc");
			Grid.Columns["MemberTypeDesc"].DataPropertyName = "MemberTypeDesc";
			Grid.Columns["MemberTypeDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("DiscountPercent", "DiscountPercent");
			Grid.Columns["DiscountPercent"].DataPropertyName = "DiscountPercent";
			Grid.Columns["DiscountPercent"].Width = 150;
		}
		private void MainAreaList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.MainAreaList();
			Grid.DataSource = dt;
			Grid.Columns.Add("MainAreaId", "MainAreaId");
			Grid.Columns["MainAreaId"].DataPropertyName = "MainAreaId";
			Grid.Columns["MainAreaId"].Visible = false;
			Grid.Columns["MainAreaId"].Width = 0;

			Grid.Columns.Add("MainAreaDesc", "Main Area Desc");
			Grid.Columns["MainAreaDesc"].DataPropertyName = "MainAreaDesc";
			Grid.Columns["MainAreaDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("MainAreaShortName", "Short Name");
			Grid.Columns["MainAreaShortName"].DataPropertyName = "MainAreaShortName";
			Grid.Columns["MainAreaShortName"].Width = 120;
		}
		private void SubAreaList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.AreaList();
			Grid.DataSource = dt;
			Grid.Columns.Add("AreaId", "AreaId");
			Grid.Columns["AreaId"].DataPropertyName = "AreaId";
			Grid.Columns["AreaId"].Visible = false;
			Grid.Columns["AreaId"].Width = 0;

			Grid.Columns.Add("AreaDesc", "AreaDesc");
			Grid.Columns["AreaDesc"].DataPropertyName = "AreaDesc";
			Grid.Columns["AreaDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("AreaShortName", "Short Name");
			Grid.Columns["AreaShortName"].DataPropertyName = "AreaShortName";
			Grid.Columns["AreaShortName"].Width = 120;
		}
		private void ProductrRestaurantList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(830, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductList(ClsGlobal.billingType);
			Grid.DataSource = dt;


			DataTable dataTable = _objPickList.PickListTemplate("Master", "ProductRestaurant");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					if (item["ColumnWidth"].ToString() == "0")
					{
						Grid.Columns[item["FieldName"].ToString()].Visible = false;
					}
					else
					{
						Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
					}
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
		}
		private void ProductList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductList(ClsGlobal.billingType);
			Grid.DataSource = dt;

			DataTable dataTable = _objPickList.PickListTemplate("Master", "Product");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					if (item["ColumnWidth"].ToString() == "0")
					{
						Grid.Columns[item["FieldName"].ToString()].Visible = false;
					}
					else
					{
						Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
					}
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
		}
		private void ProductGroupList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductGroupList();
			Grid.DataSource = dt;
			Grid.Columns.Add("ProductGrpId", "ProductGrpId");
			Grid.Columns["ProductGrpId"].DataPropertyName = "ProductGrpId";
			Grid.Columns["ProductGrpId"].Visible = false;
			Grid.Columns["ProductGrpId"].Width = 0;

			Grid.Columns.Add("ProductGrpDesc", "Group Desc");
			Grid.Columns["ProductGrpDesc"].DataPropertyName = "ProductGrpDesc";
			Grid.Columns["ProductGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("ProductGrpShortName", "Short Name");
			Grid.Columns["ProductGrpShortName"].DataPropertyName = "ProductGrpShortName";
			Grid.Columns["ProductGrpShortName"].Width = 120;

			Grid.Columns.Add("Margin", "Margin");
			Grid.Columns["Margin"].DataPropertyName = "Margin";
			Grid.Columns["Margin"].Width = 90;

			Grid.Columns.Add("PrinterName", "Printer Name");
			Grid.Columns["PrinterName"].DataPropertyName = "PrinterName";
			Grid.Columns["PrinterName"].Width = 120;
			Grid.Columns["PrinterName"].Visible = true;
		}
		private void ProductGroupList1()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductGroupList1();
			Grid.DataSource = dt;
			Grid.Columns.Add("ProductGrpId", "ProductGrpId");
			Grid.Columns["ProductGrpId"].DataPropertyName = "ProductGrpId";
			Grid.Columns["ProductGrpId"].Visible = false;
			Grid.Columns["ProductGrpId"].Width = 0;

			Grid.Columns.Add("ProductGrpDesc", "Group Desc");
			Grid.Columns["ProductGrpDesc"].DataPropertyName = "ProductGrpDesc";
			Grid.Columns["ProductGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("ProductGrpShortName", "Short Name");
			Grid.Columns["ProductGrpShortName"].DataPropertyName = "ProductGrpShortName";
			Grid.Columns["ProductGrpShortName"].Width = 120;

			Grid.Columns.Add("Margin", "Margin");
			Grid.Columns["Margin"].DataPropertyName = "Margin";
			Grid.Columns["Margin"].Width = 90;

			Grid.Columns.Add("PrinterName", "Printer Name");
			Grid.Columns["PrinterName"].DataPropertyName = "PrinterName";
			Grid.Columns["PrinterName"].Width = 120;
			Grid.Columns["PrinterName"].Visible = true;
		}
		private void ProductGroupList2()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductGroupList2();
			Grid.DataSource = dt;
			Grid.Columns.Add("ProductGrpId", "ProductGrpId");
			Grid.Columns["ProductGrpId"].DataPropertyName = "ProductGrpId";
			Grid.Columns["ProductGrpId"].Visible = false;
			Grid.Columns["ProductGrpId"].Width = 0;

			Grid.Columns.Add("ProductGrpDesc", "Group Desc");
			Grid.Columns["ProductGrpDesc"].DataPropertyName = "ProductGrpDesc";
			Grid.Columns["ProductGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("ProductGrpShortName", "Short Name");
			Grid.Columns["ProductGrpShortName"].DataPropertyName = "ProductGrpShortName";
			Grid.Columns["ProductGrpShortName"].Width = 120;

			Grid.Columns.Add("Margin", "Margin");
			Grid.Columns["Margin"].DataPropertyName = "Margin";
			Grid.Columns["Margin"].Width = 90;

			Grid.Columns.Add("PrinterName", "Printer Name");
			Grid.Columns["PrinterName"].DataPropertyName = "PrinterName";
			Grid.Columns["PrinterName"].Width = 120;
			Grid.Columns["PrinterName"].Visible = true;
		}
		private void ProductSubGroupList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductSubGroupList(_SplitedValue);
			Grid.DataSource = dt;
			Grid.Columns.Add("ProductSubGrpId", "ProductSubGrpId");
			Grid.Columns["ProductSubGrpId"].DataPropertyName = "ProductSubGrpId";
			Grid.Columns["ProductSubGrpId"].Visible = false;
			Grid.Columns["ProductSubGrpId"].Width = 0;

			Grid.Columns.Add("ProductSubGrpDesc", "ProductSubGrpDesc");
			Grid.Columns["ProductSubGrpDesc"].DataPropertyName = "ProductSubGrpDesc";
			Grid.Columns["ProductSubGrpDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("ProductSubGrpShortName", "Code");
			Grid.Columns["ProductSubGrpShortName"].DataPropertyName = "ProductSubGrpShortName";
			Grid.Columns["ProductSubGrpShortName"].Width = 120;

			Grid.Columns.Add("ProductGrpDesc", "Product Group");
			Grid.Columns["ProductGrpDesc"].DataPropertyName = "ProductGrpDesc";
			Grid.Columns["ProductGrpDesc"].Width = 120;

			Grid.Columns.Add("ProductGrpId", "ProductGrpId");
			Grid.Columns["ProductGrpId"].DataPropertyName = "ProductGrpId";
			Grid.Columns["ProductGrpId"].Width = 0;
			Grid.Columns["ProductGrpId"].Visible = false;
		}
		private void ProductUnitList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductUnitList();
			Grid.DataSource = dt;
			Grid.Columns.Add("ProductUnitId", "ProductUnitId");
			Grid.Columns["ProductUnitId"].DataPropertyName = "ProductUnitId";
			Grid.Columns["ProductUnitId"].Visible = false;
			Grid.Columns["ProductUnitId"].Width = 0;

			Grid.Columns.Add("ProductUnitDesc", "Unit Desc");
			Grid.Columns["ProductUnitDesc"].DataPropertyName = "ProductUnitDesc";
			Grid.Columns["ProductUnitDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("ProductUnitShortName", "Short Name");
			Grid.Columns["ProductUnitShortName"].DataPropertyName = "ProductUnitShortName";
			Grid.Columns["ProductUnitShortName"].Width = 120;
		}
		private void ModuleNameList()
		{
			Grid.AutoGenerateColumns = false;
			dt = ClsGlobal.ModuleCode();
			Grid.DataSource = dt;
			Grid.Columns.Add("ModuleCode", "ModuleCode");
			Grid.Columns["ModuleCode"].DataPropertyName = "ModuleCode";
			Grid.Columns["ModuleCode"].Visible = false;
			Grid.Columns["ModuleCode"].Width = 0;

			Grid.Columns.Add("ModuleName", "ModuleName");
			Grid.Columns["ModuleName"].DataPropertyName = "ModuleName";
			Grid.Columns["ModuleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
		private void DocumentDesignList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.DocumrntNumberList();
			Grid.DataSource = dt;
			Grid.Columns.Add("DocId", "DocId");
			Grid.Columns["DocId"].DataPropertyName = "DocId";
			Grid.Columns["DocId"].Visible = false;
			Grid.Columns["DocId"].Width = 0;

			Grid.Columns.Add("DocModule", "Module Name");
			Grid.Columns["DocModule"].DataPropertyName = "DocModule";
			Grid.Columns["DocModule"].Width = 120;

			Grid.Columns.Add("DocDesc", "Document Desc");
			Grid.Columns["DocDesc"].DataPropertyName = "DocDesc";
			Grid.Columns["DocDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
		private void BranchList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.BranchList();
			Grid.DataSource = dt;
			Grid.Columns.Add("BranchId", "BranchId");
			Grid.Columns["BranchId"].DataPropertyName = "BranchId";
			Grid.Columns["BranchId"].Visible = false;
			Grid.Columns["BranchId"].Width = 0;

			Grid.Columns.Add("BranchName", "Branch Name");
			Grid.Columns["BranchName"].DataPropertyName = "BranchName";
			Grid.Columns["BranchName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("BranchShortName", "Branch ShortName");
			Grid.Columns["BranchShortName"].DataPropertyName = "BranchShortName";
			Grid.Columns["BranchShortName"].Width = 120;
		}
		private void CompanyUnitList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.CompanyUnitList();
			Grid.DataSource = dt;
			Grid.Columns.Add("CompanyUnitId", "CompanyUnitId");
			Grid.Columns["CompanyUnitId"].DataPropertyName = "CompanyUnitId";
			Grid.Columns["CompanyUnitId"].Visible = false;
			Grid.Columns["CompanyUnitId"].Width = 0;
			Grid.Columns.Add("CmpUnitName", "Company Unit Name");
			Grid.Columns["CmpUnitName"].DataPropertyName = "CmpUnitName";
			Grid.Columns["CmpUnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			Grid.Columns.Add("CmpUnitShortName", "Company Unit ShortName");
			Grid.Columns["CmpUnitShortName"].DataPropertyName = "CmpUnitShortName";
			Grid.Columns["CmpUnitShortName"].Width = 120;
			Grid.Columns.Add("BranchName", "BranchName");
			Grid.Columns["BranchName"].DataPropertyName = "BranchName";
			Grid.Columns["BranchName"].Width = 120;
			Grid.Columns.Add("BranchId", "BranchId");
			Grid.Columns["BranchId"].DataPropertyName = "BranchId";
			Grid.Columns["BranchId"].Visible = false;
		}
		private void SalesBillingTermList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesBillingTermList(ClsGlobal.IsBillWise);
			Grid.DataSource = dt;

			DataTable dataTable = _objPickList.PickListTemplate("Master", "Sales Term");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
			ClsGlobal.IsBillWise = "";
		}
		private void PurchaseBillingTermList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseBillingTermList();
			Grid.DataSource = dt;

			DataTable dataTable = _objPickList.PickListTemplate("Master", "Purchase Term");
			foreach (DataRow item in dataTable.Rows)
			{
				Grid.Columns.Add(item["FieldName"].ToString(), item["DisplayName"].ToString());
				Grid.Columns[item["FieldName"].ToString()].DataPropertyName = item["FieldName"].ToString();
				if (Convert.ToInt32(item["ShowHide"].ToString()) == 0)
				{
					Grid.Columns[item["FieldName"].ToString()].Visible = false;
				}

				if (!string.IsNullOrEmpty(item["ColumnWidth"].ToString()))
				{
					Grid.Columns[item["FieldName"].ToString()].Width = Convert.ToInt32(item["ColumnWidth"].ToString());
				}
				else
				{
					Grid.Columns[item["FieldName"].ToString()].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
		}
		private void MenuPermissionGroupList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.MenuPermissionGroupList();
			Grid.DataSource = dt;

			Grid.Columns.Add("PremissionGroupName", "Premission Group Name");
			Grid.Columns["PremissionGroupName"].DataPropertyName = "PremissionGroupName";
			Grid.Columns["PremissionGroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
		private void UserMasterList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.UserList();
			Grid.DataSource = dt;
			Grid.Columns.Add("UserCode", "UserCode");
			Grid.Columns["UserCode"].DataPropertyName = "UserCode";
			Grid.Columns["UserCode"].Visible = false;
			Grid.Columns["UserCode"].Width = 0;

			Grid.Columns.Add("UserName", "UserName");
			Grid.Columns["UserName"].DataPropertyName = "UserName";
			Grid.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("MobileNo", "MobileNo");
			Grid.Columns["MobileNo"].DataPropertyName = "MobileNo";
			Grid.Columns["MobileNo"].Width = 120;

			Grid.Columns.Add("EmailId", "EmailId");
			Grid.Columns["EmailId"].DataPropertyName = "EmailId";
			Grid.Columns["EmailId"].Width = 120;
		}
		private void ProductSchemeList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.ProductSchemeList();
			Grid.DataSource = dt;
			Grid.Columns.Add("SchemeId", "Scheme Id");
			Grid.Columns["SchemeId"].DataPropertyName = "SchemeId";
			Grid.Columns["SchemeId"].Width = 100;

			Grid.Columns.Add("SchemeName", "Scheme Name");
			Grid.Columns["SchemeName"].DataPropertyName = "SchemeName";
			Grid.Columns["SchemeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
		private void DocumentNumberList()
		{
			Size = new System.Drawing.Size(702, 416);
			Grid.Size = new System.Drawing.Size(690, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.DocumentNumberList(_SplitedValue, ClsGlobal.CompanyStartDate, ClsGlobal.CompanyEndDate, ClsGlobal.LoginUserCode, ClsGlobal.BranchId.ToString(), ClsGlobal.CompanyUnitId.ToString());
			Grid.DataSource = dt;
			Grid.Columns.Add("DocId", "DocId");
			Grid.Columns["DocId"].DataPropertyName = "DocId";
			Grid.Columns["DocId"].Visible = false;

			Grid.Columns.Add("DocDesc", "Doc Desc");
			Grid.Columns["DocDesc"].DataPropertyName = "DocDesc";
			Grid.Columns["DocDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("DocType", "Doc Type");
			Grid.Columns["DocType"].DataPropertyName = "DocType";
			Grid.Columns["DocType"].Width = 80;
			Grid.Columns["DocType"].Visible = _SplitedValue == "Cash Bank" ? true : false;

			Grid.Columns.Add("DocPrefix", "Prefix");
			Grid.Columns["DocPrefix"].DataPropertyName = "DocPrefix";
			Grid.Columns["DocPrefix"].Width = 60;

			Grid.Columns.Add("DocSufix", "Sufix");
			Grid.Columns["DocSufix"].DataPropertyName = "DocSufix";
			Grid.Columns["DocSufix"].Width = 50;

			Grid.Columns.Add("DocCurrentNo", "Current No");
			Grid.Columns["DocCurrentNo"].DataPropertyName = "DocCurrentNo";
			Grid.Columns["DocCurrentNo"].Width = 85;

			Grid.Columns.Add("DocEndNo", "End No");
			Grid.Columns["DocEndNo"].DataPropertyName = "DocEndNo";
			Grid.Columns["DocEndNo"].Width = 70;

			Grid.Columns.Add("NumericalStyle", "Numerical Style");
			Grid.Columns["NumericalStyle"].DataPropertyName = "NumericalStyle";
			Grid.Columns["NumericalStyle"].Width = 110;
		}
		private void UDFMasterList()
		{
			Size = new System.Drawing.Size(702, 416);
			Grid.Size = new System.Drawing.Size(690, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.UDFMasterList();
			Grid.DataSource = dt;
			Grid.Columns.Add("UDFCode", "UDFCode");
			Grid.Columns["UDFCode"].DataPropertyName = "UDFCode";
			Grid.Columns["UDFCode"].Visible = false;
			Grid.Columns["UDFCode"].Width = 0;

			Grid.Columns.Add("FieldName", "Field Name");
			Grid.Columns["FieldName"].DataPropertyName = "FieldName";
			Grid.Columns["FieldName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("FieldType", "Field Type");
			Grid.Columns["FieldType"].DataPropertyName = "FieldType";
			Grid.Columns["FieldType"].Width = 90;

			Grid.Columns.Add("FieldWidth", "Field Width");
			Grid.Columns["FieldWidth"].DataPropertyName = "FieldWidth";
			Grid.Columns["FieldWidth"].Width = 90;

			Grid.Columns.Add("EntryModule", "Entry Module");
			Grid.Columns["EntryModule"].DataPropertyName = "EntryModule";
			Grid.Columns["EntryModule"].Width = 200;
		}
		private void CashBankVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.CashBankVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;
			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("ChequeNo", "Chq No");
			Grid.Columns["ChequeNo"].DataPropertyName = "ChequeNo";
			Grid.Columns["ChequeNo"].Width = 150;

			Grid.Columns.Add("ChequeDate", "Chq Date");
			Grid.Columns["ChequeDate"].DataPropertyName = "ChequeDate";
			Grid.Columns["ChequeDate"].Width = 80;

			Grid.Columns.Add("ChequeMiti", "Chq Miti");
			Grid.Columns["ChequeMiti"].DataPropertyName = "ChequeMiti";
			Grid.Columns["ChequeMiti"].Width = 80;
		}

		private void JournalVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.JournalVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;
			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void DebitNoteVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.DebitNoteVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;
			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
		private void CreditNoteVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.CreditNoteVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;
			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void SalesVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("DueDay", "DueDay");
			Grid.Columns["DueDay"].DataPropertyName = "DueDay";
			Grid.Columns["DueDay"].Width = 80;

			Grid.Columns.Add("DueDate", "DueDate");
			Grid.Columns["DueDate"].DataPropertyName = "DueDate";
			Grid.Columns["DueDate"].Width = 80;

			Grid.Columns.Add("ChallanNo", "ChallanNo");
			Grid.Columns["ChallanNo"].DataPropertyName = "ChallanNo";
			Grid.Columns["ChallanNo"].Width = 80;

			Grid.Columns.Add("OrderNo", "OrderNo");
			Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
			Grid.Columns["OrderNo"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;
		}

        private void SalesVoucherListForSalesReturn()
        {
            Size = new System.Drawing.Size(852, 416);
            Grid.Size = new System.Drawing.Size(840, 339);
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.SalesVoucherListForSalesReturn(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;

            Grid.Columns.Add("VoucherNo", "Voucher No");
            Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
            Grid.Columns["VoucherNo"].Width = 100;

            Grid.Columns.Add("VDate", "Date");
            Grid.Columns["VDate"].DataPropertyName = "VDate";
            Grid.Columns["VDate"].Width = 80;

            Grid.Columns.Add("VMiti", "Miti");
            Grid.Columns["VMiti"].DataPropertyName = "VMiti";
            Grid.Columns["VMiti"].Width = 80;

            Grid.Columns.Add("GlDesc", "Ledger");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
            Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
            Grid.Columns["SubledgerDesc"].Width = 150;

            Grid.Columns.Add("SalesmanDesc", "Sales Man");
            Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
            Grid.Columns["SalesmanDesc"].Width = 80;

            Grid.Columns.Add("DueDay", "DueDay");
            Grid.Columns["DueDay"].DataPropertyName = "DueDay";
            Grid.Columns["DueDay"].Width = 80;

            Grid.Columns.Add("DueDate", "DueDate");
            Grid.Columns["DueDate"].DataPropertyName = "DueDate";
            Grid.Columns["DueDate"].Width = 80;

            Grid.Columns.Add("ChallanNo", "ChallanNo");
            Grid.Columns["ChallanNo"].DataPropertyName = "ChallanNo";
            Grid.Columns["ChallanNo"].Width = 80;

            Grid.Columns.Add("OrderNo", "OrderNo");
            Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
            Grid.Columns["OrderNo"].Width = 80;

            Grid.Columns.Add("QuotationNo", "QuotationNo");
            Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
            Grid.Columns["QuotationNo"].Width = 80;
        }
        private void SalesChallanVoucherListForChallanReturn()
        {
            Size = new System.Drawing.Size(852, 416);
            Grid.Size = new System.Drawing.Size(840, 339);
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.SalesChallanVoucherListForChallanReturn(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;

            Grid.Columns.Add("VoucherNo", "Voucher No");
            Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
            Grid.Columns["VoucherNo"].Width = 100;

            Grid.Columns.Add("VDate", "Date");
            Grid.Columns["VDate"].DataPropertyName = "VDate";
            Grid.Columns["VDate"].Width = 80;

            Grid.Columns.Add("VMiti", "Miti");
            Grid.Columns["VMiti"].DataPropertyName = "VMiti";
            Grid.Columns["VMiti"].Width = 80;

            Grid.Columns.Add("GlDesc", "Ledger");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
            Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
            Grid.Columns["SubledgerDesc"].Width = 150;

            Grid.Columns.Add("SalesmanDesc", "Sales Man");
            Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
            Grid.Columns["SalesmanDesc"].Width = 80;

            Grid.Columns.Add("OrderNo", "OrderNo");
            Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
            Grid.Columns["OrderNo"].Width = 80;

            Grid.Columns.Add("QuotationNo", "QuotationNo");
            Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
            Grid.Columns["QuotationNo"].Width = 80;
        }
        
        private void SalesReturnVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesReturnVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

		}

        private void SalesChallanReturnVoucherList()
        {
            Size = new System.Drawing.Size(852, 416);
            Grid.Size = new System.Drawing.Size(840, 339);
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.SalesChallanReturnVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;

            Grid.Columns.Add("VoucherNo", "Voucher No");
            Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
            Grid.Columns["VoucherNo"].Width = 100;

            Grid.Columns.Add("VDate", "Date");
            Grid.Columns["VDate"].DataPropertyName = "VDate";
            Grid.Columns["VDate"].Width = 80;

            Grid.Columns.Add("VMiti", "Miti");
            Grid.Columns["VMiti"].DataPropertyName = "VMiti";
            Grid.Columns["VMiti"].Width = 80;

            Grid.Columns.Add("GlDesc", "Ledger");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
            Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
            Grid.Columns["SubledgerDesc"].Width = 150;

            Grid.Columns.Add("SalesmanDesc", "Sales Man");
            Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
            Grid.Columns["SalesmanDesc"].Width = 80;

        }
   
        private void SalesChallanVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesChallanVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("OrderNo", "OrderNo");
			Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
			Grid.Columns["OrderNo"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;
		}

		private void SalesChallanOutstandingList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesChallanOutstandingList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("OrderNo", "OrderNo");
			Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
			Grid.Columns["OrderNo"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;
		}

		private void PurchaseChallanOutstandingVoucher()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseChallanOutstandingVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("OrderNo", "OrderNo");
			Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
			Grid.Columns["OrderNo"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;
		}
		
		private void PurchaseVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("DueDay", "DueDay");
			Grid.Columns["DueDay"].DataPropertyName = "DueDay";
			Grid.Columns["DueDay"].Width = 80;

			Grid.Columns.Add("DueDate", "DueDate");
			Grid.Columns["DueDate"].DataPropertyName = "DueDate";
			Grid.Columns["DueDate"].Width = 80;

			Grid.Columns.Add("ChallanNo", "ChallanNo");
			Grid.Columns["ChallanNo"].DataPropertyName = "ChallanNo";
			Grid.Columns["ChallanNo"].Width = 80;

			Grid.Columns.Add("OrderNo", "OrderNo");
			Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
			Grid.Columns["OrderNo"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;
		}

        private void PurchaseVoucherListForPurchaseReturn()
        {
            Size = new System.Drawing.Size(852, 416);
            Grid.Size = new System.Drawing.Size(840, 339);
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.PurchaseVoucherListForPurchaseReturn(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;

            Grid.Columns.Add("VoucherNo", "Voucher No");
            Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
            Grid.Columns["VoucherNo"].Width = 100;

            Grid.Columns.Add("VDate", "Date");
            Grid.Columns["VDate"].DataPropertyName = "VDate";
            Grid.Columns["VDate"].Width = 80;

            Grid.Columns.Add("VMiti", "Miti");
            Grid.Columns["VMiti"].DataPropertyName = "VMiti";
            Grid.Columns["VMiti"].Width = 80;

            Grid.Columns.Add("GlDesc", "Ledger");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
            Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
            Grid.Columns["SubledgerDesc"].Width = 150;

            Grid.Columns.Add("SalesmanDesc", "Sales Man");
            Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
            Grid.Columns["SalesmanDesc"].Width = 80;

            Grid.Columns.Add("DueDay", "DueDay");
            Grid.Columns["DueDay"].DataPropertyName = "DueDay";
            Grid.Columns["DueDay"].Width = 80;

            Grid.Columns.Add("DueDate", "DueDate");
            Grid.Columns["DueDate"].DataPropertyName = "DueDate";
            Grid.Columns["DueDate"].Width = 80;

            Grid.Columns.Add("ChallanNo", "ChallanNo");
            Grid.Columns["ChallanNo"].DataPropertyName = "ChallanNo";
            Grid.Columns["ChallanNo"].Width = 80;

            Grid.Columns.Add("OrderNo", "OrderNo");
            Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
            Grid.Columns["OrderNo"].Width = 80;

            Grid.Columns.Add("QuotationNo", "QuotationNo");
            Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
            Grid.Columns["QuotationNo"].Width = 80;
        }

        private void PurchaseChallanVoucherListForPurchaseChallanReturn()
        {
            Size = new System.Drawing.Size(852, 416);
            Grid.Size = new System.Drawing.Size(840, 339);
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.PurchaseChallanListForPurchaseChallanReturn(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;

            Grid.Columns.Add("VoucherNo", "Voucher No");
            Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
            Grid.Columns["VoucherNo"].Width = 100;

            Grid.Columns.Add("VDate", "Date");
            Grid.Columns["VDate"].DataPropertyName = "VDate";
            Grid.Columns["VDate"].Width = 80;

            Grid.Columns.Add("VMiti", "Miti");
            Grid.Columns["VMiti"].DataPropertyName = "VMiti";
            Grid.Columns["VMiti"].Width = 80;

            Grid.Columns.Add("GlDesc", "Ledger");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
            Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
            Grid.Columns["SubledgerDesc"].Width = 150;

            Grid.Columns.Add("SalesmanDesc", "Sales Man");
            Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
            Grid.Columns["SalesmanDesc"].Width = 80;

            Grid.Columns.Add("OrderNo", "OrderNo");
            Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
            Grid.Columns["OrderNo"].Width = 80;

            Grid.Columns.Add("QuotationNo", "QuotationNo");
            Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
            Grid.Columns["QuotationNo"].Width = 80;
        }

        private void PurchaseReturnVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseReturnVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;


		}

        private void PurchaseChallanReturnVoucherList()
        {
            Size = new System.Drawing.Size(852, 416);
            Grid.Size = new System.Drawing.Size(840, 339);
            Grid.AutoGenerateColumns = false;
            dt = _objPickList.PurchaseChallanReturnVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
            Grid.DataSource = dt;

            Grid.Columns.Add("VoucherNo", "Voucher No");
            Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
            Grid.Columns["VoucherNo"].Width = 100;

            Grid.Columns.Add("VDate", "Date");
            Grid.Columns["VDate"].DataPropertyName = "VDate";
            Grid.Columns["VDate"].Width = 80;

            Grid.Columns.Add("VMiti", "Miti");
            Grid.Columns["VMiti"].DataPropertyName = "VMiti";
            Grid.Columns["VMiti"].Width = 80;

            Grid.Columns.Add("GlDesc", "Ledger");
            Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
            Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
            Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
            Grid.Columns["SubledgerDesc"].Width = 150;

            Grid.Columns.Add("SalesmanDesc", "Sales Man");
            Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
            Grid.Columns["SalesmanDesc"].Width = 80;


        }
        private void PurchaseOrderVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseOrderVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;

			Grid.Columns.Add("IndentNo", "IndentNo");
			Grid.Columns["IndentNo"].DataPropertyName = "IndentNo";
			Grid.Columns["IndentNo"].Width = 80;
		}

		private void PurchaseOrderOutstandingVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseOrderOutstandingList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;
		}

		private void PurchaseChallanVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseChallanVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;

			Grid.Columns.Add("OrderNo", "OrderNo");
			Grid.Columns["OrderNo"].DataPropertyName = "OrderNo";
			Grid.Columns["OrderNo"].Width = 80;
		}

		private void PurchaseQuotationVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseQuotationVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;
		}

		private void PurchaseIndentVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PurchaseIndentVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("RequestedBy", "RequestedBy");
			Grid.Columns["RequestedBy"].DataPropertyName = "RequestedBy";
			Grid.Columns["RequestedBy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void SalesOrderVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesOrderVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

			Grid.Columns.Add("QuotationNo", "QuotationNo");
			Grid.Columns["QuotationNo"].DataPropertyName = "QuotationNo";
			Grid.Columns["QuotationNo"].Width = 80;
		}

		private void SalesOrderOutstandingList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesOrderOutstandingList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;

		}
		private void SalesQuotationVoucherList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesQuotationVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;
		}

		private void SalesQuotationOutstandingList()
		{
			Size = new System.Drawing.Size(852, 416);
			Grid.Size = new System.Drawing.Size(840, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.SalesQuotationOutstandingList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("VoucherNo", "Voucher No");
			Grid.Columns["VoucherNo"].DataPropertyName = "VoucherNo";
			Grid.Columns["VoucherNo"].Width = 100;

			Grid.Columns.Add("VDate", "Date");
			Grid.Columns["VDate"].DataPropertyName = "VDate";
			Grid.Columns["VDate"].Width = 80;

			Grid.Columns.Add("VMiti", "Miti");
			Grid.Columns["VMiti"].DataPropertyName = "VMiti";
			Grid.Columns["VMiti"].Width = 80;

			Grid.Columns.Add("GlDesc", "Ledger");
			Grid.Columns["GlDesc"].DataPropertyName = "GlDesc";
			Grid.Columns["GlDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			Grid.Columns.Add("SubledgerDesc", "Sub Ledger");
			Grid.Columns["SubledgerDesc"].DataPropertyName = "SubledgerDesc";
			Grid.Columns["SubledgerDesc"].Width = 150;

			Grid.Columns.Add("SalesmanDesc", "Sales Man");
			Grid.Columns["SalesmanDesc"].DataPropertyName = "SalesmanDesc";
			Grid.Columns["SalesmanDesc"].Width = 80;
		}
		private void PageNameList()
		{
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.PageNameList();
			Grid.DataSource = dt;
			Grid.Columns.Add("PageName", "Page Name");
			Grid.Columns["PageName"].DataPropertyName = "PageName";
			Grid.Columns["PageName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void BOMVoucherList()
		{
			Size = new System.Drawing.Size(552, 416);
			Grid.Size = new System.Drawing.Size(540, 339);
			Grid.AutoGenerateColumns = false;
			dt = _objPickList.BOMVoucherList(ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
			Grid.DataSource = dt;

			Grid.Columns.Add("BillOfMaterialId", "Voucher No");
			Grid.Columns["BillOfMaterialId"].DataPropertyName = "BillOfMaterialId";
			Grid.Columns["BillOfMaterialId"].Width = 180;

			Grid.Columns.Add("BillOfMaterialDesc", "Description");
			Grid.Columns["BillOfMaterialDesc"].DataPropertyName = "BillOfMaterialDesc";
			Grid.Columns["BillOfMaterialDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
	}
}
