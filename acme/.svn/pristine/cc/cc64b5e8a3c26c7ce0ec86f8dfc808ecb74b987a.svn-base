using DataAccessLayer.Common;
using DataAccessLayer.Interface.Common;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static DataAccessLayer.SystemSetting.ClsDocPrintSetting;

namespace acmedesktop.SystemSetting
{
    public partial class FrmDialogBoxTag : Form
    {
        private IUserMaster _objUsr = new ClsUserMaster();
        private IDocPrintSetting _objPrintSetting = new ClsDocPrintSetting();
        private ClsBranch _objBranch = new ClsBranch();
        private ClsCompanyUnit _objCompUnit = new ClsCompanyUnit();
        CheckBox CBoxUser, CBoxBranch;
		DataTable dtGetTagedBranch = new DataTable();

		public string _formname = "", _ListName = "", _SelectedValue = "", _CheckedBranchList = "", _CheckedCompUnitList="", _CheckeduserList = "";
        public int _DesignId = 0;

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (this._ListName == "UserList")
            {
                _objPrintSetting.PrintSettingUserMapList.Clear();
                MapUserPrintSetting MapPrintSetting = null;
                _SelectedValue = "";
                foreach (CheckBox itemControl in PnlMain.Controls)
                {
                    if (itemControl.Checked == true)
                    {
                        if (itemControl.Tag.ToString() != "All")
                        {
                            if (string.IsNullOrEmpty(_CheckeduserList))
                                _CheckeduserList += "" + itemControl.Tag.ToString() + "";
                            else
                                _CheckeduserList += "," + itemControl.Tag.ToString() + "";
                        }
                    }
                }
                List<string> selectedUserList = _CheckeduserList.Split(',').ToList<string>();
                selectedUserList.Remove("");
                foreach (var item in selectedUserList)
                {
                    MapPrintSetting = new MapUserPrintSetting
                    {
                        PrintDesignId = Convert.ToInt32(_DesignId),
                        UsreCode = Convert.ToString(item)
                    };
                    _objPrintSetting.PrintSettingUserMapList.Add(MapPrintSetting);
                }
                _objPrintSetting.SaveUserPrintSettingMap(_DesignId);
                MessageBox.Show("Data save successfully.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this._ListName == "BranchList")
            {
                _objPrintSetting.PrintSettingBranchMapList.Clear();
                MapBranchPrintSetting MapBranchPrintSetting = null;
                _SelectedValue = "";
                foreach (CheckBox itemControl in PnlSub.Controls)
                {
                    if (itemControl.Checked == true)
                    {
                        if (itemControl.Tag.ToString() != "All")
                        {
                            if (string.IsNullOrEmpty(_CheckedCompUnitList))
                                _CheckedCompUnitList += "" + itemControl.Tag.ToString() + "";
                            else
                                _CheckedCompUnitList += "," + itemControl.Tag.ToString() + "";
                        }
                    }
                }
                
                List<string> selectedCmpUnitList = _CheckedCompUnitList.Split(',').ToList<string>();
                selectedCmpUnitList.Remove("");
                foreach (var item in selectedCmpUnitList)
                {
                    MapBranchPrintSetting = new MapBranchPrintSetting
                    {
                        PrintDesignId = Convert.ToInt32(_DesignId),
                        BranchId = _objBranch.GetBranch_ByCompanyUnitId(Convert.ToInt32(item)),
                        CompanyUnitId= Convert.ToInt32(item)
                    };
                    _objPrintSetting.PrintSettingBranchMapList.Add(MapBranchPrintSetting);
                }
                _objPrintSetting.SaveBranchPrintSettingMap(_DesignId);
                MessageBox.Show("Data save successfully.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void FrmDialogBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    BtnCancel.PerformClick();
                }
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        public FrmDialogBoxTag(string formName, string ListName, int DesignId)
        {
            InitializeComponent();
            _formname = formName;
            _ListName = ListName;
            _DesignId = DesignId;
        }
        private void FrmDialogBox_Load(object sender, EventArgs e)
        {
			dtGetTagedBranch = null;
			this.Text = _formname.ToString();
            if (this._ListName == "UserList")
            {
                int i = 0;
                DataTable dtUserist = _objUsr.GetUserList();
                DataTable dtGetTagedUser = _objPrintSetting.GetUserPrintSettingMap(_DesignId);

                //Add 'All' row if all item are in the database.
                if (dtUserist.Rows.Count - 1 == dtGetTagedUser.Rows.Count)
                {
                    DataRow toInsert = dtGetTagedUser.NewRow();
                    toInsert[1] = _DesignId;
                    toInsert[2] = "All";
                    dtGetTagedUser.Rows.InsertAt(toInsert, 0);
                }
                foreach (DataRow itemRow in dtUserist.Rows)
                {
                    CBoxUser = new System.Windows.Forms.CheckBox();
                    CBoxUser.CheckedChanged += new System.EventHandler(CBoxUser_CheckedChanged);
                    CBoxUser.Tag = itemRow["UserCode"].ToString();
                    CBoxUser.Text = itemRow["UserName"].ToString();
                    CBoxUser.AutoSize = true;
                    if (i == 0)
                        CBoxUser.Location = new Point(10, (i * 20) + 5);
                    else
                        CBoxUser.Location = new Point(10, (i * 25));
                    this.PnlMain.Controls.Add(CBoxUser);
                    i++;
                    foreach (DataRow dr1 in dtGetTagedUser.Rows)
                    {
                        if (itemRow["UserCode"].ToString() == dr1["UserCode"].ToString())
                        {
                            CBoxUser.Checked = true;
                        }
                    }
                }
                PnlSub.Visible = false;
                PnlMain.Dock = DockStyle.Fill;
            }
            else if (this._ListName == "BranchList")
            {
                int i = 0;
                DataTable dtBranchist = _objBranch.GetDataBranchList();
                dtGetTagedBranch = _objPrintSetting.GetBranchPrintSettingMap(_DesignId);
                foreach (DataRow itemRow in dtBranchist.Rows)
                {
                    CBoxBranch = new CheckBox();
                    CBoxBranch.CheckedChanged += new System.EventHandler(CBoxBranch_CheckedChanged);
                    CBoxBranch.Tag = itemRow["BranchId"].ToString();
                    CBoxBranch.Text = itemRow["BranchName"].ToString();
                    CBoxBranch.AutoSize = true;
                    if (i == 0)
                        CBoxBranch.Location = new Point(10, (i * 20) + 5);
                    else
                        CBoxBranch.Location = new Point(10, (i * 25));
                    this.PnlMain.Controls.Add(CBoxBranch);
                    foreach (DataRow dr1 in dtGetTagedBranch.Rows)
                    {
                        if (itemRow["BranchId"].ToString() == dr1["BranchId"].ToString())
                        {
                            CBoxBranch.Checked = true;
                        }
                    }
                    i++;
                }
                PnlSub.Visible = true;
                PnlMain.Dock = DockStyle.None;
            }
            PnlMain.AutoScroll = false;
            PnlMain.HorizontalScroll.Enabled = false;
            PnlMain.HorizontalScroll.Visible = false;
            PnlMain.HorizontalScroll.Maximum = 0;
            PnlMain.AutoScroll = true;
        }
        private void CBoxBranch_CheckedChanged(object sender, EventArgs e)
        {
            _CheckedBranchList = "";
            PnlSub.Controls.Clear();
            CheckBox chkBox = (CheckBox)sender;
            Boolean IsChecked = chkBox.Checked;
            string CheckedValue = chkBox.Tag.ToString();
            string CheckedText = chkBox.Text;
            int i = 0;
            foreach (CheckBox itemControl in PnlMain.Controls)
            {
                if (itemControl.Checked == true)
                {
                    if (string.IsNullOrEmpty(_CheckedBranchList))
                        _CheckedBranchList += "'" + itemControl.Tag.ToString() + "'";
                    else
                        _CheckedBranchList += ",'" + itemControl.Tag.ToString() + "'";
                }
            }
            if (!string.IsNullOrEmpty(_CheckedBranchList))
            {
                DataTable dtListCompantUnitId = _objBranch.GetCompanyUnitId_ByBranchID(_CheckedBranchList);
                foreach (DataRow itemRow in dtListCompantUnitId.Rows)
                {
                    CBoxBranch = new CheckBox();
                    CBoxBranch.Tag = itemRow["CompanyUnitId"].ToString();
                    CBoxBranch.Text = itemRow["CmpUnitName"].ToString();
                    CBoxBranch.AutoSize = true;
                    if (i == 0)
                        CBoxBranch.Location = new Point(10, (i * 20) + 5);
                    else
                        CBoxBranch.Location = new Point(10, (i * 25));
                    this.PnlSub.Controls.Add(CBoxBranch);

                        foreach (DataRow dr1 in dtGetTagedBranch.Rows)
                        {
                            if (itemRow["CompanyUnitId"].ToString() == dr1["CompanyUnitId"].ToString())
                            {
                                CBoxBranch.Checked = true;
                            }
                        }

                    i++;
                }
            }
            PnlSub.AutoScroll = false;
            PnlSub.HorizontalScroll.Enabled = false;
            PnlSub.HorizontalScroll.Visible = false;
            PnlSub.HorizontalScroll.Maximum = 0;
            PnlSub.AutoScroll = true;
        }

        private void CBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            _CheckeduserList = "";
            PnlSub.Controls.Clear();
            CheckBox chkBox = (CheckBox)sender;
            Boolean IsChecked = chkBox.Checked;
            string CheckedValue = chkBox.Tag.ToString();
            string CheckedText = chkBox.Text;
            int i = 0;
            if (CheckedText.ToString() == "All" && IsChecked == true)
            {
                CheckAllUser(true);
            }
            else if (CheckedText.ToString() == "All" && IsChecked == false)
            {
                CheckAllUser(false);
            }
            PnlSub.AutoScroll = false;
            PnlSub.HorizontalScroll.Enabled = false;
            PnlSub.HorizontalScroll.Visible = false;
            PnlSub.HorizontalScroll.Maximum = 0;
            PnlSub.AutoScroll = true;
        }

        private void CheckAllUser(Boolean val)
        {
            foreach (CheckBox itemControl in PnlMain.Controls)
            {
                itemControl.Checked = val;
            }
        }
    }
}
