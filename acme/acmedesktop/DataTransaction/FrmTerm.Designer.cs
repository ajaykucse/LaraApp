namespace acmedesktop.DataTransaction
{
    partial class FrmTerm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Basis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTotalTermAmount = new acmedesktop.MyInputControls.MyTextBox();
            this.TxtBasicAmount = new acmedesktop.MyInputControls.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Basic Amount";
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToResizeColumns = false;
            this.Grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.BackgroundColor = System.Drawing.Color.White;
            this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.TermPosition,
            this.TermId,
            this.Formula,
            this.TermDesc,
            this.Basis,
            this.Sign,
            this.TermRate,
            this.Amount});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle7;
            this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid.Location = new System.Drawing.Point(6, 34);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersVisible = false;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(516, 169);
            this.Grid.StandardTab = true;
            this.Grid.TabIndex = 2;
            this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // SNo
            // 
            this.SNo.FillWeight = 228.4264F;
            this.SNo.Frozen = true;
            this.SNo.HeaderText = "SNo";
            this.SNo.Name = "SNo";
            this.SNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SNo.ToolTipText = "Delete Row";
            this.SNo.Width = 40;
            // 
            // TermPosition
            // 
            this.TermPosition.HeaderText = "TermPosition";
            this.TermPosition.Name = "TermPosition";
            this.TermPosition.Visible = false;
            // 
            // TermId
            // 
            this.TermId.HeaderText = "TermId";
            this.TermId.Name = "TermId";
            this.TermId.Visible = false;
            // 
            // Formula
            // 
            this.Formula.HeaderText = "TermFormula";
            this.Formula.Name = "Formula";
            this.Formula.Visible = false;
            // 
            // TermDesc
            // 
            this.TermDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TermDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.TermDesc.FillWeight = 83.94669F;
            this.TermDesc.HeaderText = "Term";
            this.TermDesc.Name = "TermDesc";
            this.TermDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Basis
            // 
            this.Basis.HeaderText = "Basis";
            this.Basis.Name = "Basis";
            this.Basis.Width = 50;
            // 
            // Sign
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Sign.DefaultCellStyle = dataGridViewCellStyle4;
            this.Sign.HeaderText = "Sign";
            this.Sign.Name = "Sign";
            this.Sign.Width = 50;
            // 
            // TermRate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TermRate.DefaultCellStyle = dataGridViewCellStyle5;
            this.TermRate.HeaderText = "Rate Percent";
            this.TermRate.Name = "TermRate";
            this.TermRate.Width = 90;
            // 
            // Amount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 80;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(266, 208);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(42, 26);
            this.BtnOK.TabIndex = 3;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Term Amt";
            // 
            // TxtTotalTermAmount
            // 
            this.TxtTotalTermAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotalTermAmount.Enabled = false;
            this.TxtTotalTermAmount.Location = new System.Drawing.Point(418, 211);
            this.TxtTotalTermAmount.Name = "TxtTotalTermAmount";
            this.TxtTotalTermAmount.Size = new System.Drawing.Size(104, 21);
            this.TxtTotalTermAmount.TabIndex = 5;
            this.TxtTotalTermAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtBasicAmount
            // 
            this.TxtBasicAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBasicAmount.Enabled = false;
            this.TxtBasicAmount.Location = new System.Drawing.Point(418, 7);
            this.TxtBasicAmount.Name = "TxtBasicAmount";
            this.TxtBasicAmount.Size = new System.Drawing.Size(104, 21);
            this.TxtBasicAmount.TabIndex = 1;
            this.TxtBasicAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(529, 238);
            this.ControlBox = false;
            this.Controls.Add(this.TxtTotalTermAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.TxtBasicAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmTerm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Term";
            this.Load += new System.EventHandler(this.FrmTerm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTerm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyInputControls.MyTextBox TxtBasicAmount;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button BtnOK;
        private MyInputControls.MyTextBox TxtTotalTermAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Basis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}