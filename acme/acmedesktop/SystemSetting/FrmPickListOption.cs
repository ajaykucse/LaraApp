using DataAccessLayer.Common;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static DataAccessLayer.Common.ClsPickList;

namespace acmedesktop.SystemSetting
{
    public partial class FrmPickListOption : Form
    {
        string _Tag = "", _SearchKey = "";
        public ClsPickList _objPickLst = new ClsPickList();
        DataTable dtPageNameList = new DataTable();
        public FrmPickListOption()
        {
            InitializeComponent();
            Grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void FrmPickListOption_Load(object sender, EventArgs e)
        {

        }

        private void BtnSearchPageName_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("PageName", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtPageName.Text = frmPickList.SelectedList[0]["PageName"].ToString().Trim();
                    TxtPageName.Tag = frmPickList.SelectedList[0]["PageName"].ToString().Trim();
                    LoadPickListOptionPageWise();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPageName.Focus();
                return;
            }
            TxtPageName.Focus();
        }

        private void TxtPageName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchPageName.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtPageName, BtnSearchPageName, true);
            }
        }

        private void BtnSavePickList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPageName.Text))
            {
                MessageBox.Show("Page is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPageName.Focus();
                return;
            }

            _objPickLst.PickListControl.Clear();
            ModelPickListControl ObjPickListControlOption = null;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                if (ro.Cells["FieldName"].Value != null && ro.Cells["DisplayName"].Value != null)
                {
                    ObjPickListControlOption = new ModelPickListControl();
                    ObjPickListControlOption.FieldName = ro.Cells["FieldName"].Value.ToString();
                    ObjPickListControlOption.DisplayName = ro.Cells["DisplayName"].Value.ToString();
                    if (Convert.ToBoolean(ro.Cells["IsPrimaryColumn"].Value).ToString() == "True")
                        ObjPickListControlOption.IsPrimaryColumn = 1;
                    else
                        ObjPickListControlOption.IsPrimaryColumn = 0;
                    if (Convert.ToBoolean(ro.Cells["IsSearchable"].Value).ToString() == "True")
                        ObjPickListControlOption.IsSearchable = 1;
                    else
                        ObjPickListControlOption.IsSearchable = 0;
                    ObjPickListControlOption.Odr = Convert.ToInt32(ro.Cells["Order"].Value.ToString());
                    if (Convert.ToBoolean(ro.Cells["Visible"].Value).ToString() == "True")
                        ObjPickListControlOption.ShowHide = 1;
                    else
                        ObjPickListControlOption.ShowHide = 0;

                    if (Convert.ToBoolean(ro.Cells["Visible"].Value).ToString() == "True")
                        ObjPickListControlOption.ColumnWidth = string.IsNullOrEmpty(ro.Cells["ColumnWidth"].Value.ToString()) ? 0 : Convert.ToInt32(ro.Cells["ColumnWidth"].Value.ToString());
                    else
                        ObjPickListControlOption.ColumnWidth = 0;
                    ObjPickListControlOption.Module = ro.Cells["Module"].Value.ToString();
                    _objPickLst.PickListControl.Add(ObjPickListControlOption);
                }
            }

            _objPickLst.SavePickListControlOptions(TxtPageName.Tag.ToString());
            MessageBox.Show("Data Update Successfully !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPickListOptionPageWise();
        }

        private void BtnCancelPickList_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridPickListOptions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 6)
            {
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out int i)&& Grid.Rows[Grid.CurrentCell.ColumnIndex].Cells["FieldName"].Value != null && Grid.Rows[Grid.Rows.Count - 1].Cells["DisplayName"].Value != null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter numeric value only.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GridPickListOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = Grid.CurrentCell.ColumnIndex;
                int iRow = Grid.CurrentCell.RowIndex;
                if (iColumn == Grid.ColumnCount - 1)
                {
                    if (Grid.RowCount > (iRow + 1))
                    {
                        Grid.CurrentCell = Grid[1, iRow + 1];
                    }
                }
                else
                    Grid.CurrentCell = Grid[iColumn + 1, iRow];
            }
        }

        private void FrmPickListOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl != Grid)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPageName.Text))
            {
                MessageBox.Show("Page name can not be left blank.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPageName.Focus();
                return;
            }
            ClsUpdateCompany UpdCompany = new ClsUpdateCompany();
            DialogResult Rs = MessageBox.Show("Are you sure to reset data?", "Mr. Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == DialogResult.Yes)
            {
                UpdCompany.UpdateResetPickList(TxtPageName.Text);
                MessageBox.Show("Date reset successfully.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPageName.Focus();
                LoadPickListOptionPageWise();
            }
        }

        public void LoadPickListOptionPageWise()
        {
            Grid.Rows.Clear();
            dtPageNameList = _objPickLst.PageNameWiseFieldList(TxtPageName.Text);
            foreach (DataRow row in dtPageNameList.Rows)
            {
                if (dtPageNameList.Rows.Count > 0)
                {
                    Grid.Rows.Add();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["FieldName"].Value= row["FieldName"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["DisplayName"].Value = row["DisplayName"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["IsPrimaryColumn"].Value = row["PrimaryColumn"];
                    if (row["IsSearchable"].ToString()=="0")
                        Grid.Rows[Grid.Rows.Count - 1].Cells["IsSearchable"].Value = 0;
                    else
                        Grid.Rows[Grid.Rows.Count - 1].Cells["IsSearchable"].Value = 1;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Order"].Value = row["Odr"].ToString();

                    if (row["ShowHide"].ToString() == "0")
                        Grid.Rows[Grid.Rows.Count - 1].Cells["Visible"].Value = 0;
                    else
                        Grid.Rows[Grid.Rows.Count - 1].Cells["Visible"].Value = 1;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ColumnWidth"].Value = row["ColumnWidth"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Module"].Value = row["Module"].ToString();
                }
            }
        }
    }
}
