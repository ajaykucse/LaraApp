using acmedesktop.Common;
using acmedesktop.DataTransaction.BillingTransaction;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.SystemSetting;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static DataAccessLayer.SystemSetting.ClsDocPrintSetting;

namespace acmedesktop.SystemSetting
{
	public partial class FrmPrintSetting : Form
	{
		private IDocPrintSetting _objDocPrintSetting = new ClsDocPrintSetting();
		private ClsUserMaster _objUser = new ClsUserMaster();
		private ClsCompanyUnit _objComUnit = new ClsCompanyUnit();
		private ClsBranch _objBranch = new ClsBranch();
		private string ModuleName = "", DesignTypeSelected = "", _SearchKey = "", DesingName = "", DesignPath = "";

		public FrmPrintSetting()
		{
			InitializeComponent();
			Grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
		}

		private void FrmPrintSetting_Load(object sender, EventArgs e)
		{
			ClearFld();
			TxtModuleName.Focus();
			LoadGridComboBox();
			BtnBrowseDesign.Visible = false;
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			if (ClsGlobal.ConfirmFormClose == 1)
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure want to Close Form..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
				if (dialogResult == DialogResult.Yes)
				{
					Close();
				}
			}
			else
			{
				Close();
			}
		}

		public void ClearFld()
		{
			foreach (Control control in PanelContainer.Controls)
			{
				if (control is System.Windows.Forms.TextBox)
				{
					control.Text = "";
				}
			}
			TxtModuleName.Focus();
		}

		private void FrmPrintSetting_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
			else if (e.KeyCode == Keys.Escape)
			{
				if (BtnExit.Enabled == true)
				{
					BtnExit.PerformClick();
					return;
				}

				DialogResult = DialogResult.Cancel;
				return;
			}
		}

		private void BtnSearchModuleName_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("ModuleName", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0)
				{
					TxtModuleName.Text = frmPickList.SelectedList[0]["ModuleName"].ToString().Trim();
					TxtModuleName.Tag = frmPickList.SelectedList[0]["ModuleCode"].ToString().Trim();
				}
				frmPickList.Dispose();
			}
			TxtModuleName_Validating(null, null);
		}

		private void TxtModuleName_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
			{
				_SearchKey = string.Empty;
				BtnSearchModuleName.PerformClick();
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
			}
		}

		private void TxtModuleName_Validating(object sender, CancelEventArgs e)
		{
			if (ActiveControl == TxtModuleName || string.IsNullOrEmpty(ActiveControl.ToString())) return;
			if (string.IsNullOrEmpty(TxtModuleName.Text.Trim()))
			{
				MessageBox.Show("Module Name Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				e.Cancel = true;
			}
			else
			{
				ModuleName = TxtModuleName.Tag.ToString();
			}
		}

		public void LoadExistingDesigns()
		{
			Grid.Rows.Clear();
			Grid.Rows.Add();
			DataTable dtExistingDesign = new DataTable();
			dtExistingDesign = _objDocPrintSetting.GetPrintDesignList(ModuleName, DesignTypeSelected);
			int i = 1;
			if (dtExistingDesign.Rows.Count > 0)
			{
				foreach (DataRow drDetails in dtExistingDesign.Rows)
				{
					Grid.Rows[Grid.Rows.Count - 1].Cells["PrintDesignId"].Value = drDetails["PrintDesignId"].ToString();
					Grid.Rows[Grid.Rows.Count - 1].Cells["Module"].Value = drDetails["Module"].ToString();
					Grid.Rows[Grid.Rows.Count - 1].Cells["DesignName"].Value = drDetails["DesignName"].ToString();
					Grid.Rows[Grid.Rows.Count - 1].Cells["DesignType"].Value = drDetails["DesignType"].ToString();

					Grid.Rows[Grid.Rows.Count - 1].Cells["Path"].Value = drDetails["DesignPath"].ToString();

					foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
					{
						if (drDetails["DefaultPrinter"].ToString() == printer.ToString())
						{
							Grid.Rows[Grid.Rows.Count - 1].Cells["Printer"].Value = drDetails["DefaultPrinter"].ToString();
                            break;
						}
						else
						{
							Grid.Rows[Grid.Rows.Count - 1].Cells["Printer"].Value = "";
						}
					}
                    Grid.Rows[Grid.Rows.Count - 1].Cells["NumberOfCopy"].Value = drDetails["NoofCopy"].ToString();
					if (Convert.ToBoolean(drDetails["SaveAndPrint"]).ToString() == "True")
					{
						Grid.Rows[Grid.Rows.Count - 1].Cells["DirectPrint"].Value = 1;
					}
					else
					{
						Grid.Rows[Grid.Rows.Count - 1].Cells["DirectPrint"].Value = 0;
					}

					if (Convert.ToBoolean(drDetails["IsEnable"]).ToString() == "True")
					{
						Grid.Rows[Grid.Rows.Count - 1].Cells["Active"].Value = 1;
					}
					else
					{
						Grid.Rows[Grid.Rows.Count - 1].Cells["Active"].Value = 0;
					}

					Grid.Rows[Grid.Rows.Count - 1].Cells["Remarks"].Value = drDetails["Remarks"].ToString();
					if (i != dtExistingDesign.Rows.Count)
						Grid.Rows.Add();
					i++;
				}
			}
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			if (Grid.Rows.Count > 0)
			{
				DialogResult Ds = MessageBox.Show("Are you sure to update the changes ?", "Mr. Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (Ds == DialogResult.Yes)
				{
					_objDocPrintSetting.PrintSettingList.Clear();
					PrintSettingModel ObjPtintSetting = null;
					foreach (DataGridViewRow ro in Grid.Rows)
					{
						if (ro.Cells["DesignName"].Value != null && ro.Cells["Module"].Value != null)
						{
							ObjPtintSetting = new PrintSettingModel
							{
								PrintDesignId = Convert.ToInt32(ro.Cells["PrintDesignId"].Value),
								DesignName = ro.Cells["DesignName"].Value.ToString(),
								Module = ro.Cells["Module"].Value.ToString(),
								Remarks = ro.Cells["Remarks"].Value.ToString(),
								DefaultPrinter = ro.Cells["Printer"].Value.ToString(),
								DesignPath = ro.Cells["Path"].Value.ToString(),
								NoOfCopy = Convert.ToInt32(ro.Cells["NumberOfCopy"].Value)
							};
							if (Convert.ToBoolean(ro.Cells["DirectPrint"].Value).ToString() == "True")
								ObjPtintSetting.SaveAndPrint = 1;
							else
								ObjPtintSetting.SaveAndPrint = 0;

							if (Convert.ToBoolean(ro.Cells["Active"].Value).ToString() == "True")
								ObjPtintSetting.IsEnable = 1;
							else
								ObjPtintSetting.IsEnable = 0;
							ObjPtintSetting.DesignType = ro.Cells["DesignType"].Value.ToString();
							_objDocPrintSetting.PrintSettingList.Add(ObjPtintSetting);
						}
					}
				}
				_objDocPrintSetting.SavePrintSetting("UPDATE");
				MessageBox.Show("Update Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadExistingDesigns();
			}
			else
			{
				MessageBox.Show("No change are available for save.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

		}

		private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (Grid.Rows.Count > 0)
			{
				if (Grid.Columns[e.ColumnIndex].Name == "Action")
				{
					if (Grid.Rows[Grid.CurrentRow.Index].Cells["DesignType"].Value.ToString() == "DLL")
					{
						MessageBox.Show("Can not delete fixed design ?", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					else if(Grid.Rows[Grid.CurrentRow.Index].Cells["Module"].Value != null)
					{
						DialogResult DR = MessageBox.Show("Are you sure to delete the design ?", "Mr. Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (DR == DialogResult.Yes)
						{
							int DesignId =Convert.ToInt32(Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value);

							_objDocPrintSetting.DeletePrintSetting(DesignId);
							if ((System.IO.File.Exists(Grid.Rows[Grid.CurrentRow.Index].Cells["Path"].Value.ToString())))
							{
								System.IO.File.Delete(Grid.Rows[Grid.CurrentRow.Index].Cells["Path"].Value.ToString());
							}
							MessageBox.Show("Design deleted successfully.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
							LoadExistingDesigns();
						}
					}
				}
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			Grid.EndEdit();
			int rowindex = Grid.CurrentCell.RowIndex;
			int columnindex = Grid.CurrentCell.ColumnIndex;
			if (e.ColumnIndex == 6)
			{
				if (!int.TryParse(Convert.ToString(e.FormattedValue), out int i) && Grid.Rows[rowindex].Cells[columnindex].Value != null && Grid.Rows[rowindex].Cells[columnindex].Value != null)
				{
					e.Cancel = true;
					MessageBox.Show("Please enter numeric value only.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			//if (e.ColumnIndex == 2)
			//{
			//	if (Grid.Rows[rowindex].Cells[2].Value != null && Grid.Rows[rowindex].Cells[3].Value.ToString() == "DLL")
			//	{
			//		e.Cancel = false;
			//		string OrginalValue = _objDocPrintSetting.GetOrginalDllDesignName(ModuleName, Convert.ToInt32(Grid.Rows[rowindex].Cells[0].Value));
			//		string ChangedValue = Grid.Rows[rowindex].Cells[2].Value.ToString();
			//		if (Grid.Rows[rowindex].Cells[2].Value.ToString() != OrginalValue)
			//		{
			//			Grid.Rows[rowindex].Cells[2].Value = OrginalValue;
			//			Grid.Refresh();
			//			MessageBox.Show("Can not change the design name.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//		}
			//	}
			//}
		}

		private void BtnTagUser_Click(object sender, EventArgs e)
		{
			if (Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value == null || Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value.ToString() == "")
			{
				MessageBox.Show("Please select design first.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else
			{
				FrmDialogBoxTag frm = new FrmDialogBoxTag("User List", "UserList", Convert.ToInt32(Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value));
				frm.ShowDialog();
			}
		}

		private void BtnTagBranch_Click(object sender, EventArgs e)
		{
			if (_objBranch.GetDataBranchList().Rows.Count==0)
			{
				MessageBox.Show("No branch found.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value == null || Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value.ToString() == "")
			{
				MessageBox.Show("Please select design first.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else
			{
				FrmDialogBoxTag frm = new FrmDialogBoxTag("Branch List", "BranchList", Convert.ToInt32(Grid.Rows[Grid.CurrentRow.Index].Cells["PrintDesignId"].Value));
				frm.ShowDialog();
			}
		}

		public void LoadGridComboBox()
		{
			//Load Available Printer List
			ComboBox CB = new ComboBox();
			ClsPrinterList.GetPrinterList(CB);
			((DataGridViewComboBoxColumn)Grid.Columns["Printer"]).Items.Insert(0, new ListItem(string.Empty, string.Empty));
			((DataGridViewComboBoxColumn)Grid.Columns["Printer"]).Selected = true;
			((DataGridViewComboBoxColumn)Grid.Columns["Printer"]).DataSource = CB.Items;
		}

		private void CmbDesignType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CmbDesignType.SelectedIndex == 0)
			{
				DesignTypeSelected = "DLL";
				BtnBrowseDesign.Visible = false;
			}
			else
			{
				DesignTypeSelected = "Crystal";
				BtnBrowseDesign.Visible = true;
			}
			LoadExistingDesigns();
		}

		private void BtnBrowseDesign_Click(object sender, EventArgs e)
		{
			OpenFileDialog fdSelectDesign = new OpenFileDialog();
			fdSelectDesign.Filter = "Crystal files (*.rpt)|*.rpt|All files (*.*)|*.*";
			fdSelectDesign.InitialDirectory = @"C:\";
			fdSelectDesign.Title = "Please select an Crystal Design file to add.";

			if (fdChooseDesign.ShowDialog() == DialogResult.OK)
			{
				DesignPath = fdChooseDesign.FileName;
				FrmDialogBox frm = new FrmDialogBox("Name", "Design Name:", fdChooseDesign.SafeFileName.Split('.')[0].ToString());
				frm.LblDialog.Font = new Font("Arial", 8, FontStyle.Regular);
				frm.LblDialog.Location = new Point(25, 33);
				frm.TxtDialog.Font = new Font("Arial", 9, FontStyle.Regular);
				frm.TxtDialog.Location = new Point(97, 29);
				frm.ShowDialog();
				if (!string.IsNullOrEmpty(frm._textDialog))
				{
					DesingName = (frm._textDialog != "") ? frm._textDialog : fdChooseDesign.SafeFileName.Split('.')[0].ToString();
					AddNewDesign();
				}
				else
				{
					MessageBox.Show("Design name can not left blank.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					//return;
				}
			}
		}

		private void AddNewDesign()
		{
			DialogResult Ds = MessageBox.Show("Are you sure to add new design ?", "Mr. Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (Ds == DialogResult.Yes)
			{
				_objDocPrintSetting.PrintSettingList.Clear();
				PrintSettingModel ObjPtintSetting = new PrintSettingModel
				{
					DesignName = DesingName,
					DesignPath = DesignPath,
					DesignUrl = "",
					Module = ModuleName,
					Remarks = "",
					DefaultPrinter = "",
					NoOfCopy = 1,
					SaveAndPrint = 0,
					IsEnable = 1,
					DesignType = "Crystal"
				};

				_objDocPrintSetting.PrintSettingList.Add(ObjPtintSetting);
				_objDocPrintSetting.SavePrintSetting("ADD");
				MessageBox.Show("Design added Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			LoadExistingDesigns();
		}


		//private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		//{
		//	Grid.EndEdit();
		//	int rowindex = Grid.CurrentCell.RowIndex;
		//	int columnindex = Grid.CurrentCell.ColumnIndex;
		//	if (e.ColumnIndex == 10)
		//	{
		//		int i = 0;
		//		foreach (DataGridViewRow ro in Grid.Rows)
		//		{
		//			if (ro.Cells["DesignName"].Value != null)
		//			{
		//				if (Convert.ToBoolean(ro.Cells["DirectPrint"].Value) == true || ro.Cells["DirectPrint"].Value.ToString() == "1")
		//				{
		//					i++;
		//					if (i > 1)
		//					{
		//						MessageBox.Show("Only one design can be select for singile module.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//						ro.Cells["DirectPrint"].Value = 0;
		//						Grid.Refresh();
		//					}
		//				}
		//			}
		//		}
		//	}
		//}
	}
}
