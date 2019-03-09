using acmedesktop.MyInputControls;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
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
    public partial class FrmUDFDetailEntry : Form
    {
        string _UDFEntryModule, _VoucherNo = "";
        private int counter;
        private int locY; //Yaxis
        int _SNo;
        bool _OpenFromAssmbly = false;
        IUdfMaster _objUDF = new ClsUdfMaster();

        public FrmUDFDetailEntry(string UDFEntryModule, string VoucherNo, int SNo, bool OpenFromAssmbly = false)
        {
            InitializeComponent();
            _UDFEntryModule = UDFEntryModule;
            _VoucherNo = VoucherNo;
            _SNo = SNo;
            _OpenFromAssmbly = OpenFromAssmbly;
        }

        private void FrmUDFDetailEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void FrmUDFDetailEntry_Load(object sender, EventArgs e)
        {
            DataTable dt = _objUDF.GetByEntryModule(_UDFEntryModule);
            foreach (DataRow ro in dt.Rows)
            {
                string value = "";
                DataRow[] dr = ClsGlobal.UDFExistingDataTableDetails.Select("SNO ='" + _SNo + "'");
                if (dr.Count() > 0)
                {
                    value = dr[0]["UDFData" + ro["UDFCode"].ToString()].ToString();
                }
                counter += 1;
                locY += 21 + 5;
                if (ro["FieldType"].ToString() != "Yes/No")
                {
                    Label myLabel = new Label();
                    myLabel.Location = new Point(10, locY);
                    myLabel.Text = ro["FieldName"].ToString();
                    this.Controls.Add(myLabel);
                }

                if (ro["FieldType"].ToString() == "String")
                {
                    MyTextBox mytext = new MyTextBox();
                    mytext.Location = new Point(150, locY);
                    mytext.Name = "txt" + counter;
                    mytext.Size = new System.Drawing.Size(350, 18);
                    mytext.TabIndex = counter;
                    mytext.Text = value;
                    this.Controls.Add(mytext);
                }

                if (ro["FieldType"].ToString() == "Memo")
                {
                    MyTextBox mytext = new MyTextBox();
                    mytext.Location = new Point(150, locY);
                    mytext.Name = "txt" + counter;
                    mytext.Size = new System.Drawing.Size(300, 50);
                    mytext.TabIndex = counter;
                    mytext.Text = value;
                    mytext.Multiline = true;
                    this.Controls.Add(mytext);
                    locY += 29;
                }

                if (ro["FieldType"].ToString() == "Date")
                {
                    MyMaskedTextBox myDatetext = new MyMaskedTextBox();
                    myDatetext.Location = new Point(150, locY);
                    myDatetext.Name = "txtdate" + counter;
                    myDatetext.Size = new System.Drawing.Size(200, 18);
                    myDatetext.TabIndex = counter;
                    myDatetext.Text = value;
                    this.Controls.Add(myDatetext);
                }

                if (ro["FieldType"].ToString() == "Number")
                {
                    MyNumericTextBox myNumtext = new MyNumericTextBox();
                    myNumtext.Location = new Point(150, locY);
                    myNumtext.Name = "txtNum" + counter;
                    myNumtext.Size = new System.Drawing.Size(200, 18);
                    myNumtext.TabIndex = counter;
                    myNumtext.Text = value;
                    myNumtext.Tag = ro["FieldDecimal"].ToString();
                    myNumtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                    myNumtext.Leave += new System.EventHandler(this.MyNumericTextBox_Leave);
                    this.Controls.Add(myNumtext);
                }

                if (ro["FieldType"].ToString() == "Yes/No")
                {
                    CheckBox myCheckBox = new CheckBox();
                    myCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                    myCheckBox.Location = new Point(10, locY);
                    myCheckBox.Name = "chk" + counter;
                    myCheckBox.Size = new System.Drawing.Size(154, 18);
                    myCheckBox.TabIndex = counter;
                    myCheckBox.Text = ro["FieldName"].ToString();
                    myCheckBox.UseVisualStyleBackColor = true;

                    if (value == "Y")
                        myCheckBox.Checked = true;
                    else
                        myCheckBox.Checked = false;

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

                    myComboBox.Location = new Point(150, locY);
                    myComboBox.Name = "cmb" + counter;
                    myComboBox.Size = new System.Drawing.Size(350, 23);
                    myComboBox.TabIndex = counter;
                    myComboBox.SelectedIndex = 0;

                    myComboBox.SelectedItem = value;

                    this.Controls.Add(myComboBox);
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is Label)
                {
                    string value = ((Label)ctr).Text;
                    DataTable dt = _objUDF.GetByFieldName(value, _UDFEntryModule);
                    ClsGlobal.UDFCodeArrayDetails.Add(dt.Rows[0]["UDFCode"].ToString());
                }
                if (ctr is CheckBox)
                {
                    string value = ((CheckBox)ctr).Text;
                    DataTable dt = _objUDF.GetByFieldName(value, _UDFEntryModule);
                    ClsGlobal.UDFCodeArrayDetails.Add(dt.Rows[0]["UDFCode"].ToString());
                }


                if (ctr is TextBox)
                {
                    string value = ((TextBox)ctr).Text;
                    ClsGlobal.UDFDataArrayDetails.Add(value);
                }

                if (ctr is MaskedTextBox)
                {
                    string value = ((MaskedTextBox)ctr).Text;
                    ClsGlobal.UDFDataArrayDetails.Add(value);
                }

                if (ctr is CheckBox)
                {
                    string value = "N";
                    if (((CheckBox)ctr).Checked == true)
                        value = "Y";

                    ClsGlobal.UDFDataArrayDetails.Add(value);
                }

                if (ctr is ComboBox)
                {
                    string value = ((ComboBox)ctr).SelectedItem.ToString();
                    ClsGlobal.UDFDataArrayDetails.Add(value);
                }
            }
            
            var rows = ClsGlobal.UDFExistingDataTableDetails.Select("SNO ='" + _SNo + "'");
            foreach (var row in rows)
                row.Delete();

            DataRow dr = ClsGlobal.UDFExistingDataTableDetails.NewRow();
            dr["SNO"] = _SNo;
            for (int i = 0; i < ClsGlobal.UDFCodeArrayDetails.Count(); i++)
            {
                dr["UDFCode" + ClsGlobal.UDFCodeArrayDetails[i]] = ClsGlobal.UDFCodeArrayDetails[i];
                dr["UDFData" + ClsGlobal.UDFCodeArrayDetails[i]] = ClsGlobal.UDFDataArrayDetails[i];
            }
            ClsGlobal.UDFExistingDataTableDetails.Rows.Add(dr);

            this.Close(); this.Dispose();
        }

        private void MyNumericTextBox_Leave(object sender, EventArgs e)
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
    }
}
