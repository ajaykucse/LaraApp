namespace acmedesktop.Common
{
    partial class DocPrintingOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnToVoucherSearch = new System.Windows.Forms.Button();
            this.BtnFromVoucherSearch = new System.Windows.Forms.Button();
            this.lblToVoucher = new System.Windows.Forms.Label();
            this.lblFromVoucher = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbOption = new System.Windows.Forms.ComboBox();
            this.CmbDesignList = new System.Windows.Forms.ComboBox();
            this.CmbPrinterList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TxtToDate = new acmedesktop.MyInputControls.MyMaskedTextBox();
            this.TxtFromDate = new acmedesktop.MyInputControls.MyMaskedTextBox();
            this.TxtNoOfCopyPrint = new acmedesktop.MyInputControls.MyNumericTextBox();
            this.TxtToVoucher = new acmedesktop.MyInputControls.MyTextBox();
            this.TxtFromVoucher = new acmedesktop.MyInputControls.MyTextBox();
            this.SuspendLayout();
            // 
            // BtnToVoucherSearch
            // 
            this.BtnToVoucherSearch.CausesValidation = false;
            this.BtnToVoucherSearch.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnToVoucherSearch.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnToVoucherSearch.Location = new System.Drawing.Point(496, 48);
            this.BtnToVoucherSearch.Name = "BtnToVoucherSearch";
            this.BtnToVoucherSearch.Size = new System.Drawing.Size(33, 24);
            this.BtnToVoucherSearch.TabIndex = 71;
            this.BtnToVoucherSearch.TabStop = false;
            this.BtnToVoucherSearch.UseVisualStyleBackColor = true;
            this.BtnToVoucherSearch.Click += new System.EventHandler(this.BtnToVoucherSearch_Click);
            // 
            // BtnFromVoucherSearch
            // 
            this.BtnFromVoucherSearch.CausesValidation = false;
            this.BtnFromVoucherSearch.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnFromVoucherSearch.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnFromVoucherSearch.Location = new System.Drawing.Point(497, 12);
            this.BtnFromVoucherSearch.Name = "BtnFromVoucherSearch";
            this.BtnFromVoucherSearch.Size = new System.Drawing.Size(33, 24);
            this.BtnFromVoucherSearch.TabIndex = 70;
            this.BtnFromVoucherSearch.TabStop = false;
            this.BtnFromVoucherSearch.UseVisualStyleBackColor = true;
            this.BtnFromVoucherSearch.Click += new System.EventHandler(this.BtnFromVoucherSearch_Click);
            // 
            // lblToVoucher
            // 
            this.lblToVoucher.AutoSize = true;
            this.lblToVoucher.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToVoucher.Location = new System.Drawing.Point(283, 50);
            this.lblToVoucher.Name = "lblToVoucher";
            this.lblToVoucher.Size = new System.Drawing.Size(67, 15);
            this.lblToVoucher.TabIndex = 68;
            this.lblToVoucher.Text = "To Voucher";
            // 
            // lblFromVoucher
            // 
            this.lblFromVoucher.AutoSize = true;
            this.lblFromVoucher.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromVoucher.Location = new System.Drawing.Point(283, 17);
            this.lblFromVoucher.Name = "lblFromVoucher";
            this.lblFromVoucher.Size = new System.Drawing.Size(83, 15);
            this.lblFromVoucher.TabIndex = 67;
            this.lblFromVoucher.Text = "From Voucher";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(283, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 69;
            this.label4.Text = "No of Copy";
            // 
            // CmbOption
            // 
            this.CmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOption.FormattingEnabled = true;
            this.CmbOption.Items.AddRange(new object[] {
            "Number",
            "Date"});
            this.CmbOption.Location = new System.Drawing.Point(105, 81);
            this.CmbOption.Name = "CmbOption";
            this.CmbOption.Size = new System.Drawing.Size(92, 21);
            this.CmbOption.TabIndex = 2;
            this.CmbOption.SelectionChangeCommitted += new System.EventHandler(this.CmbOption_SelectionChangeCommitted);
            // 
            // CmbDesignList
            // 
            this.CmbDesignList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDesignList.FormattingEnabled = true;
            this.CmbDesignList.Location = new System.Drawing.Point(105, 48);
            this.CmbDesignList.Name = "CmbDesignList";
            this.CmbDesignList.Size = new System.Drawing.Size(161, 21);
            this.CmbDesignList.TabIndex = 1;
            // 
            // CmbPrinterList
            // 
            this.CmbPrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinterList.FormattingEnabled = true;
            this.CmbPrinterList.Location = new System.Drawing.Point(105, 15);
            this.CmbPrinterList.Name = "CmbPrinterList";
            this.CmbPrinterList.Size = new System.Drawing.Size(161, 21);
            this.CmbPrinterList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "Option";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "Printer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 65;
            this.label3.Text = "Design Name";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(462, 125);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(67, 26);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOk.Location = new System.Drawing.Point(410, 125);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(49, 26);
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "&Ok";
            this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(2, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 1);
            this.panel1.TabIndex = 63;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(213, 122);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(150, 33);
            this.crystalReportViewer1.TabIndex = 72;
            this.crystalReportViewer1.Visible = false;
            // 
            // TxtToDate
            // 
            this.TxtToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtToDate.Location = new System.Drawing.Point(131, 126);
            this.TxtToDate.Mask = "99/99/9999";
            this.TxtToDate.Name = "TxtToDate";
            this.TxtToDate.Size = new System.Drawing.Size(71, 20);
            this.TxtToDate.TabIndex = 6;
            this.TxtToDate.Visible = false;
            // 
            // TxtFromDate
            // 
            this.TxtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFromDate.Location = new System.Drawing.Point(54, 126);
            this.TxtFromDate.Mask = "99/99/9999";
            this.TxtFromDate.Name = "TxtFromDate";
            this.TxtFromDate.Size = new System.Drawing.Size(71, 20);
            this.TxtFromDate.TabIndex = 5;
            this.TxtFromDate.Visible = false;
            // 
            // TxtNoOfCopyPrint
            // 
            this.TxtNoOfCopyPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.TxtNoOfCopyPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNoOfCopyPrint.Location = new System.Drawing.Point(379, 83);
            this.TxtNoOfCopyPrint.Name = "TxtNoOfCopyPrint";
            this.TxtNoOfCopyPrint.Size = new System.Drawing.Size(59, 20);
            this.TxtNoOfCopyPrint.TabIndex = 7;
            this.TxtNoOfCopyPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtToVoucher
            // 
            this.TxtToVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtToVoucher.Location = new System.Drawing.Point(379, 49);
            this.TxtToVoucher.Name = "TxtToVoucher";
            this.TxtToVoucher.Size = new System.Drawing.Size(117, 20);
            this.TxtToVoucher.TabIndex = 4;
            this.TxtToVoucher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtToVoucher_KeyDown);
            this.TxtToVoucher.Validating += new System.ComponentModel.CancelEventHandler(this.TxtToVoucher_Validating);
            // 
            // TxtFromVoucher
            // 
            this.TxtFromVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFromVoucher.Location = new System.Drawing.Point(379, 15);
            this.TxtFromVoucher.Name = "TxtFromVoucher";
            this.TxtFromVoucher.Size = new System.Drawing.Size(117, 20);
            this.TxtFromVoucher.TabIndex = 3;
            this.TxtFromVoucher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFromVoucher_KeyDown);
            this.TxtFromVoucher.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFromVoucher_Validating);
            // 
            // DocPrintingOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(536, 162);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.TxtToDate);
            this.Controls.Add(this.TxtFromDate);
            this.Controls.Add(this.BtnToVoucherSearch);
            this.Controls.Add(this.BtnFromVoucherSearch);
            this.Controls.Add(this.TxtNoOfCopyPrint);
            this.Controls.Add(this.TxtToVoucher);
            this.Controls.Add(this.TxtFromVoucher);
            this.Controls.Add(this.lblToVoucher);
            this.Controls.Add(this.lblFromVoucher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbOption);
            this.Controls.Add(this.CmbDesignList);
            this.Controls.Add(this.CmbPrinterList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocPrintingOption";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doc Printing Option";
            this.Load += new System.EventHandler(this.DocPrintingOption_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocPrintingOption_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyInputControls.MyMaskedTextBox TxtToDate;
        private MyInputControls.MyMaskedTextBox TxtFromDate;
        private System.Windows.Forms.Button BtnToVoucherSearch;
        private System.Windows.Forms.Button BtnFromVoucherSearch;
        private MyInputControls.MyNumericTextBox TxtNoOfCopyPrint;
        private MyInputControls.MyTextBox TxtToVoucher;
        private MyInputControls.MyTextBox TxtFromVoucher;
        private System.Windows.Forms.Label lblToVoucher;
        private System.Windows.Forms.Label lblFromVoucher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbOption;
        private System.Windows.Forms.ComboBox CmbDesignList;
        private System.Windows.Forms.ComboBox CmbPrinterList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}