using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using acmedesktop.MyInputControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.Common
{
    public partial class FrmUDFMasterEntry : Form
    {
        string _UDFEntryModule, _VoucherNo = "", _UDFType;
        private int counter;
        private int locY;
        DataTable mydt;
        string num;
        DataAccessLayer.Common.ClsDateMiti _objDate = new DataAccessLayer.Common.ClsDateMiti();
        ClsUdfMaster _objUDF = new ClsUdfMaster();

        public FrmUDFMasterEntry(string UDFEntryModule, string VoucherNo, string UDFType)
        {
            InitializeComponent();
            _UDFEntryModule = UDFEntryModule;
            _VoucherNo = VoucherNo;
            _UDFType = UDFType;
        }
        private void FrmUDFMasterEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void FrmUDFMasterEntry_Load(object sender, EventArgs e)
        {
            mydt = _objUDF.GetByEntryModule(_UDFEntryModule);
            foreach (DataRow ro in mydt.Rows)
            {
                string value = "";
                DataTable dt1 = ClsGlobal.UDFExistingDataMaster;
                ////---------------- load edit data bind ----------------
                //if (ClsGlobal.UDFExistingDataMaster.Rows.Count == 0 && !string.IsNullOrEmpty(_VoucherNo) && _VoucherNo!="0")
                //{
                //    ClsGlobal.FieldNameArrMaster.Clear();
                //    ClsGlobal.UDFDataArrMaster.Clear();
                //    DataTable mydatatable = _objUDF.GetUDF(_UDFType,_VoucherNo);
                //    foreach (DataRow dr1 in mydatatable.Rows)
                //    {
                //        ClsGlobal.FieldNameArrMaster.Add(dr1["UDFCode"].ToString());
                //        ClsGlobal.UDFDataArrMaster.Add(dr1["UDFData"].ToString());
                //    }

                //    DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();

                //    dr[0] = 0;
                //    for (int i = 0; i < ClsGlobal.FieldNameArrMaster.Count(); i++)
                //    {
                //        if (i == 0)
                //        {
                //            dr[i + 1] = ClsGlobal.FieldNameArrMaster[i];
                //            dr[i + 2] = ClsGlobal.UDFDataArrMaster[i];
                //        }
                //        else
                //        {
                //            dr[i + 2 + (i - 1)] = ClsGlobal.FieldNameArrMaster[i];
                //            dr[i + 3 + (i - 1)] = ClsGlobal.UDFDataArrMaster[i];
                //        }
                //    }

                //    ClsGlobal.UDFExistingDataMaster.Rows.Add(dr);
                //    dt1 = ClsGlobal.UDFExistingDataMaster;
                //}
                ////---------- end load edit data bind ------------------

                if (dt1.Rows.Count > 0)
                {
                    string UDFCode = ro["UDFCode"].ToString();
                    value = dt1.Rows[0]["UDFData" + UDFCode].ToString();
                }

                counter += 1;
                locY += 21 + 5;
                if (ro["FieldType"].ToString() != "Yes/No")
                {
                    Label myLabel = new Label();
                    myLabel.Location = new Point(10, locY);
                    myLabel.Size = new System.Drawing.Size(200, 18);
                    myLabel.Text = ro["FieldName"].ToString();
                    this.Controls.Add(myLabel);
                }

                if (ro["FieldType"].ToString() == "String")
                {
                    MyTextBox mytext = new MyTextBox();
                    mytext.Location = new Point(210, locY);
                    mytext.Name = "txt" + counter;
                    mytext.Size = new System.Drawing.Size(250, 18);
                    mytext.TabIndex = 0;
                    mytext.MaxLength = Convert.ToInt32(ro["FieldWidth"]);
                    mytext.Tag = ro["FieldType"].ToString();
                    mytext.Text = value;
                    if (ro["MandotaryOpt"].ToString() == "Y")
                    {
                        mytext.Validating += new System.ComponentModel.CancelEventHandler(this.MyTextBox_Validating);
                    }
                    this.Controls.Add(mytext);
                }

                if (ro["FieldType"].ToString() == "Memo")
                {
                    MyTextBox mytext = new MyTextBox();
                    mytext.Location = new Point(210, locY);
                    mytext.Name = "txt" + counter;
                    mytext.Size = new System.Drawing.Size(280, 50);
                    mytext.TabIndex = 0;
                    mytext.Text = value;
                    mytext.MaxLength = Convert.ToInt32(ro["FieldWidth"]);
                    mytext.Tag = ro["FieldType"].ToString();
                    mytext.Multiline = true;
                    if (ro["MandotaryOpt"].ToString() == "Y")
                    {
                        mytext.Validating += new System.ComponentModel.CancelEventHandler(this.MyTextBox_Validating);
                    }
                    this.Controls.Add(mytext);
                    locY += 29;
                }

                if (ro["FieldType"].ToString() == "Date")
                {
                    MyMaskedTextBox myDatetext = new MyMaskedTextBox();
                    myDatetext.Location = new Point(210, locY);
                    myDatetext.Name = "txtdate" + counter;
                    myDatetext.Size = new System.Drawing.Size(200, 18);
                    myDatetext.TabIndex = 0;
                    myDatetext.Text = value;
                    if (ro["DateFormat"].ToString() == "YYYY")
                        myDatetext.Mask = "9999";
                    else if (ro["DateFormat"].ToString() == "MM/YYYY")
                        myDatetext.Mask = "99/9999";
                    if (ro["MandotaryOpt"].ToString() == "Y" && ro["DateFormat"].ToString() == "DD/MM/YYYY")
                    {
                        myDatetext.Validating += new System.ComponentModel.CancelEventHandler(this.MyDateTextBox_Validating);
                    }
                    this.Controls.Add(myDatetext);
                }

                if (ro["FieldType"].ToString() == "Number")
                {
                    MyNumericTextBox myNumtext = new MyNumericTextBox();
                    myNumtext.Location = new Point(210, locY);
                    myNumtext.Name = "txtNum" + counter;
                    myNumtext.Size = new System.Drawing.Size(200, 18);
                    myNumtext.TabIndex = 0;
                    myNumtext.Text = value;
                    myNumtext.MaxLength = Convert.ToInt32(ro["FieldWidth"]);
                    myNumtext.Tag = ro["Field_Decimal"].ToString();
                    myNumtext.Tag = ro["FieldType"].ToString();
                    myNumtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                    if (ro["MandotaryOpt"].ToString() == "Y")
                    {
                        myNumtext.Validating += new System.ComponentModel.CancelEventHandler(this.MyNumericTextBox_Validating);
                    }
                    myNumtext.Leave += new System.EventHandler(this.TextBox1_Leave);
                    this.Controls.Add(myNumtext);
                }

                if (ro["FieldType"].ToString() == "Yes/No")
                {
                    CheckBox myCheckBox = new CheckBox();
                    myCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                    myCheckBox.Location = new Point(10, locY);
                    myCheckBox.Name = "chk" + counter;
                    myCheckBox.Size = new System.Drawing.Size(220, 18);
                    myCheckBox.TabIndex = 0;
                    myCheckBox.Text = ro["FieldName"].ToString();
                    myCheckBox.UseVisualStyleBackColor = true;
                    myCheckBox.Checked = value == "Y" ? true : false;
                    //if (value == "Y")
                    //    myCheckBox.Checked = true;
                    //else
                    //    myCheckBox.Checked = false;

                    this.Controls.Add(myCheckBox);
                }

                if (ro["FieldType"].ToString() == "List")
                {
                    ComboBox myComboBox = new ComboBox();
                    myComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    myComboBox.FormattingEnabled = true;

                    _objUDF.GetSingle(ro["UDFCode"].ToString());
                    foreach (UDFDetailsEntryViewModel Udfdetail in _objUDF.ModelUDFDetailsEntry)
                    {
                        myComboBox.Items.Add(Udfdetail.ListName);
                    }

                    myComboBox.Location = new Point(210, locY);
                    myComboBox.Name = "cmb" + counter;
                    myComboBox.Size = new System.Drawing.Size(350, 23);
                    myComboBox.TabIndex = 0;
                    myComboBox.SelectedIndex = 0;
                    myComboBox.SelectedItem = value;
                    this.Controls.Add(myComboBox);
                }
            }
        }

        private void MyNumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            MyNumericTextBox tb = (MyNumericTextBox)sender;
            if (string.IsNullOrEmpty((tb.Text)))
            {
                MessageBox.Show("Mandatory Field Cannot be Blank !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb.Focus();
                return;
            }
        }
        private void MyTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty((tb.Text)))
            {
                MessageBox.Show("Mandatory Field Cannot be Blank !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb.Focus();
                return;
            }
        }
        private void MyDateTextBox_Validating(object sender, CancelEventArgs e)
        {
            MyMaskedTextBox tb = (MyMaskedTextBox)sender;
            if (string.IsNullOrEmpty((tb.Text)))
            {
                MessageBox.Show("Mandatory Field Cannot be Blank !", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb.Focus();
                return;
            }
            if (tb.Text == "  /  /")
            {
                MessageBox.Show("Please Enter Date.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb.Focus();
                return;
            }

            if (tb.Text != "  /  /")
            {
                try
                {
                    string date = _objDate.GetMiti(Convert.ToDateTime(tb.Text));
                }
                catch
                {
                    ClsGlobal.InvalidDateMsg();
                    tb.Text = "";
                    e.Cancel = true;
                }
            }
        }
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            TextBox txtVal = (TextBox)sender;
            if (!string.IsNullOrEmpty(txtVal.Text))
            {
                int fieldDecimal = 0; string fldDecimal = "";
                int.TryParse(txtVal.Tag.ToString(), out fieldDecimal);

                if (fieldDecimal == 1)
                    fldDecimal = "0";
                else if (fieldDecimal == 2)
                    fldDecimal = "00";
                else if (fieldDecimal == 3)
                    fldDecimal = "000";
                else if (fieldDecimal == 4)
                    fldDecimal = "0000";
                else if (fieldDecimal == 5)
                    fldDecimal = "00000";
                else if (fieldDecimal == 6)
                    fldDecimal = "000000";

                if (fieldDecimal > 0)
                    txtVal.Text = Convert.ToDecimal(txtVal.Text).ToString("0." + fldDecimal);
                else
                    txtVal.Text = txtVal.Text;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            ClsGlobal.FieldNameArrMaster.Clear();
            ClsGlobal.UDFDataArrMaster.Clear();
            ClsGlobal.UDFDuplicateOptArrMaster.Clear();

            foreach (Control ctr in this.Controls)
            {
                if (ctr is Label)
                {
                    string value = ((Label)ctr).Text;
                    DataTable dt = _objUDF.GetByFieldName(value, _UDFEntryModule);
                    ClsGlobal.FieldNameArrMaster.Add(dt.Rows[0]["UDFCode"].ToString());
                    ClsGlobal.UDFDuplicateOptArrMaster.Add(dt.Rows[0]["AllowDuplicate"].ToString());
                }
                if (ctr is CheckBox)
                {
                    string value = ((CheckBox)ctr).Text;
                    DataTable dt = _objUDF.GetByFieldName(value, _UDFEntryModule);
                    ClsGlobal.FieldNameArrMaster.Add(dt.Rows[0]["UDFCode"].ToString());
                    ClsGlobal.UDFDuplicateOptArrMaster.Add(dt.Rows[0]["AllowDuplicate"].ToString());
                }

                if (ctr is TextBox)
                {
                    string value = ((TextBox)ctr).Text;
                    ClsGlobal.UDFDataArrMaster.Add(value);
                }

                if (ctr is MaskedTextBox)
                {
                    string value = ((MaskedTextBox)ctr).Text;
                    ClsGlobal.UDFDataArrMaster.Add(value);
                }

                if (ctr is CheckBox)
                {
                    string value = "N";
                    if (((CheckBox)ctr).Checked == true)
                        value = "Y";

                    ClsGlobal.UDFDataArrMaster.Add(value);
                }

                if (ctr is ComboBox)
                {
                    string value = ((ComboBox)ctr).SelectedItem.ToString();
                    ClsGlobal.UDFDataArrMaster.Add(value);
                }
            }

            string msg = "";
            //for (int i = 0; i < ClsGlobal.FieldNameArrMaster.Count(); i++)
            //{
            //    if (ClsGlobal.UDFDuplicateOptArrMaster[i] == "N")
            //    {
            //        DataTable ddddd = mydt;
            //        DataTable dt = _objUDF.GetUDFDataByCode("SB", ClsGlobal.FieldNameArrMaster[i]);// ClsGlobal.FetchData("select UDF_Data  from Sales_UDf where Source='SB'and UDF_Code='" + clsGlobal.FieldNameArrMaster[i] + "'");
            //        if (dt.Rows.Count > 0)
            //        {
            //            if (!string.IsNullOrEmpty(ClsGlobal.UDFDataArrMaster[i]))
            //            {
            //                DataRow[] dr = dt.Select("UDFData='" + ClsGlobal.UDFDataArrMaster[i] + "'");
            //                if (dr.Count() > 0)
            //                {
            //                    //DataRow[] d = mydt.Select("Udf_Code='" + clsGlobal.FieldNameArrMaster[i] + "'");
            //                    //msg += ">>" + d[0]["Field_Name"].ToString() + " cannot allow duplicate entry  \n\n";
            //                }
            //            }
            //        }
            //    }
            //}

            if (!string.IsNullOrEmpty(msg))
            {
                ClsGlobal.FieldNameArrMaster.Clear();
                ClsGlobal.UDFDataArrMaster.Clear();
                ClsGlobal.UDFDuplicateOptArrMaster.Clear();
                MessageBox.Show(msg);

                foreach (Control ctr in this.Controls)
                {
                    if (ctr is TextBox)
                    {
                        ((TextBox)ctr).Focus();
                        return;
                    }
                    else if (ctr is CheckBox)
                    {
                        ((CheckBox)ctr).Focus();
                        return;
                    }
                    else if (ctr is ComboBox)
                    {
                        ((ComboBox)ctr).Focus();
                        return;
                    }
                    else if (ctr is MaskedTextBox)
                    {
                        ((MaskedTextBox)ctr).Focus();
                        return;
                    }
                }
            }
            else
            {
                //bool flg = false;
                //for (int i = 0; i < ClsGlobal.UDFDataArrMaster.Count; i++)
                //{
                //    if (ClsGlobal.UDFDataArrMaster[i] != "")
                //    {
                //        flg = true;
                //        break;
                //    }
                //}

                //if (flg == false)
                //{
                //    ClsGlobal.UDFDataArrMaster.Clear();
                //    ClsGlobal.FieldNameArrMaster.Clear();
                //}

                ClsGlobal.UDFExistingDataMaster.Rows.Clear();
                DataRow dr = ClsGlobal.UDFExistingDataMaster.NewRow();
                dr[0] = 0;
                for (int i = 0; i < ClsGlobal.FieldNameArrMaster.Count(); i++)
                {
                    if (i == 0)
                    {
                        dr[i + 1] = ClsGlobal.FieldNameArrMaster[i];
                        dr[i + 2] = ClsGlobal.UDFDataArrMaster[i];
                    }
                    else
                    {
                        dr[i + 2 + (i - 1)] = ClsGlobal.FieldNameArrMaster[i];
                        dr[i + 3 + (i - 1)] = ClsGlobal.UDFDataArrMaster[i];
                    }
                }
                ClsGlobal.UDFExistingDataMaster.Rows.Add(dr);
                this.Close(); this.Dispose();
            }
        }
    }
}
