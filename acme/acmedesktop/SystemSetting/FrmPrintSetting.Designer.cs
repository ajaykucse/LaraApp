namespace acmedesktop.SystemSetting
{
    partial class FrmPrintSetting
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.PrintDesignID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesignName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesignType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Printer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NumberOfCopy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewImageColumn();
            this.BtnSearchModuleName = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnBrowseDesign = new System.Windows.Forms.Button();
            this.fdChooseDesign = new System.Windows.Forms.OpenFileDialog();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.BtnTagBranch = new System.Windows.Forms.Button();
            this.BtnTagUser = new System.Windows.Forms.Button();
            this.CmbDesignType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtModuleName = new acmedesktop.MyInputControls.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.PanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.CausesValidation = false;
            this.BtnExit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnExit.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(1049, 6);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(60, 31);
            this.BtnExit.TabIndex = 18;
            this.BtnExit.Text = "     &Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToResizeColumns = false;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.BackgroundColor = System.Drawing.Color.White;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrintDesignID,
            this.Module,
            this.DesignName,
            this.DesignType,
            this.Path,
            this.Printer,
            this.NumberOfCopy,
            this.DirectPrint,
            this.Active,
            this.Remarks,
            this.Action});
            this.Grid.Location = new System.Drawing.Point(4, 41);
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersVisible = false;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grid.Size = new System.Drawing.Size(1105, 317);
            this.Grid.TabIndex = 3;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.Grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Grid_CellValidating);
            // 
            // PrintDesignID
            // 
            this.PrintDesignID.HeaderText = "PrintDesignID";
            this.PrintDesignID.Name = "PrintDesignID";
            this.PrintDesignID.Visible = false;
            // 
            // Module
            // 
            this.Module.HeaderText = "Module";
            this.Module.Name = "Module";
            this.Module.ReadOnly = true;
            // 
            // DesignName
            // 
            this.DesignName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DesignName.HeaderText = "Design Name";
            this.DesignName.Name = "DesignName";
            // 
            // DesignType
            // 
            this.DesignType.HeaderText = "DesignType";
            this.DesignType.Name = "DesignType";
            this.DesignType.Visible = false;
            // 
            // Path
            // 
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.Width = 150;
            // 
            // Printer
            // 
            this.Printer.HeaderText = "Printer";
            this.Printer.Name = "Printer";
            this.Printer.Width = 200;
            // 
            // NumberOfCopy
            // 
            this.NumberOfCopy.HeaderText = "Copy #";
            this.NumberOfCopy.Name = "NumberOfCopy";
            this.NumberOfCopy.Width = 80;
            // 
            // DirectPrint
            // 
            this.DirectPrint.HeaderText = "Direct Print";
            this.DirectPrint.Name = "DirectPrint";
            this.DirectPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DirectPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Active.Width = 70;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // Action
            // 
            this.Action.HeaderText = "#";
            this.Action.Image = global::acmedesktop.Properties.Resources.Delete_16;
            this.Action.Name = "Action";
            this.Action.Width = 50;
            // 
            // BtnSearchModuleName
            // 
            this.BtnSearchModuleName.CausesValidation = false;
            this.BtnSearchModuleName.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchModuleName.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchModuleName.Location = new System.Drawing.Point(298, 8);
            this.BtnSearchModuleName.Name = "BtnSearchModuleName";
            this.BtnSearchModuleName.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchModuleName.TabIndex = 16;
            this.BtnSearchModuleName.TabStop = false;
            this.BtnSearchModuleName.UseVisualStyleBackColor = true;
            this.BtnSearchModuleName.Click += new System.EventHandler(this.BtnSearchModuleName_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label11.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label11.Location = new System.Drawing.Point(7, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "Module Name";
            // 
            // BtnBrowseDesign
            // 
            this.BtnBrowseDesign.CausesValidation = false;
            this.BtnBrowseDesign.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnBrowseDesign.Image = global::acmedesktop.Properties.Resources.New_24;
            this.BtnBrowseDesign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBrowseDesign.Location = new System.Drawing.Point(544, 6);
            this.BtnBrowseDesign.Name = "BtnBrowseDesign";
            this.BtnBrowseDesign.Size = new System.Drawing.Size(76, 31);
            this.BtnBrowseDesign.TabIndex = 2;
            this.BtnBrowseDesign.Text = "Add";
            this.BtnBrowseDesign.UseVisualStyleBackColor = true;
            this.BtnBrowseDesign.Click += new System.EventHandler(this.BtnBrowseDesign_Click);
            // 
            // fdChooseDesign
            // 
            this.fdChooseDesign.FileName = "Choose Design";
            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.BtnTagBranch);
            this.PanelContainer.Controls.Add(this.BtnTagUser);
            this.PanelContainer.Controls.Add(this.CmbDesignType);
            this.PanelContainer.Controls.Add(this.BtnBrowseDesign);
            this.PanelContainer.Controls.Add(this.label2);
            this.PanelContainer.Controls.Add(this.BtnCancel);
            this.PanelContainer.Controls.Add(this.BtnOk);
            this.PanelContainer.Controls.Add(this.BtnExit);
            this.PanelContainer.Controls.Add(this.BtnSearchModuleName);
            this.PanelContainer.Controls.Add(this.Grid);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(1113, 403);
            this.PanelContainer.TabIndex = 26;
            // 
            // BtnTagBranch
            // 
            this.BtnTagBranch.CausesValidation = false;
            this.BtnTagBranch.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnTagBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTagBranch.Location = new System.Drawing.Point(847, 6);
            this.BtnTagBranch.Name = "BtnTagBranch";
            this.BtnTagBranch.Size = new System.Drawing.Size(94, 31);
            this.BtnTagBranch.TabIndex = 28;
            this.BtnTagBranch.Text = "Tag Branch";
            this.BtnTagBranch.UseVisualStyleBackColor = true;
            this.BtnTagBranch.Click += new System.EventHandler(this.BtnTagBranch_Click);
            // 
            // BtnTagUser
            // 
            this.BtnTagUser.CausesValidation = false;
            this.BtnTagUser.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnTagUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTagUser.Location = new System.Drawing.Point(749, 6);
            this.BtnTagUser.Name = "BtnTagUser";
            this.BtnTagUser.Size = new System.Drawing.Size(94, 31);
            this.BtnTagUser.TabIndex = 27;
            this.BtnTagUser.Text = "Tag User";
            this.BtnTagUser.UseVisualStyleBackColor = true;
            this.BtnTagUser.Click += new System.EventHandler(this.BtnTagUser_Click);
            // 
            // CmbDesignType
            // 
            this.CmbDesignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDesignType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbDesignType.FormattingEnabled = true;
            this.CmbDesignType.Items.AddRange(new object[] {
            "Fixed Design",
            "Crystal Design"});
            this.CmbDesignType.Location = new System.Drawing.Point(418, 9);
            this.CmbDesignType.Name = "CmbDesignType";
            this.CmbDesignType.Size = new System.Drawing.Size(122, 23);
            this.CmbDesignType.TabIndex = 1;
            this.CmbDesignType.SelectedIndexChanged += new System.EventHandler(this.CmbDesignType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label2.Location = new System.Drawing.Point(339, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Design Type";
            // 
            // BtnCancel
            // 
            this.BtnCancel.CausesValidation = false;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(1018, 364);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "     &CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOk.Location = new System.Drawing.Point(951, 364);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(60, 31);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.Text = "     &OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // TxtModuleName
            // 
            this.TxtModuleName.BackColor = System.Drawing.Color.White;
            this.TxtModuleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtModuleName.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtModuleName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtModuleName.Location = new System.Drawing.Point(95, 9);
            this.TxtModuleName.Name = "TxtModuleName";
            this.TxtModuleName.ReadOnly = true;
            this.TxtModuleName.Size = new System.Drawing.Size(203, 22);
            this.TxtModuleName.TabIndex = 0;
            this.TxtModuleName.Tag = "0";
            this.TxtModuleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtModuleName_KeyDown);
            this.TxtModuleName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtModuleName_Validating);
            // 
            // FrmPrintSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1113, 403);
            this.Controls.Add(this.TxtModuleName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PanelContainer);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPrintSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Setting";
            this.Load += new System.EventHandler(this.FrmPrintSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrintSetting_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.PanelContainer.ResumeLayout(false);
            this.PanelContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.DataGridView Grid;
        private MyInputControls.MyTextBox TxtModuleName;
        private System.Windows.Forms.Button BtnSearchModuleName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnBrowseDesign;
        private System.Windows.Forms.OpenFileDialog fdChooseDesign;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDesignType;
		private System.Windows.Forms.DataGridViewTextBoxColumn PrintDesignID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Module;
		private System.Windows.Forms.DataGridViewTextBoxColumn DesignName;
		private System.Windows.Forms.DataGridViewTextBoxColumn DesignType;
		private System.Windows.Forms.DataGridViewTextBoxColumn Path;
		private System.Windows.Forms.DataGridViewComboBoxColumn Printer;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfCopy;
		private System.Windows.Forms.DataGridViewCheckBoxColumn DirectPrint;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
		private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
		private System.Windows.Forms.DataGridViewImageColumn Action;
		private System.Windows.Forms.Button BtnTagBranch;
		private System.Windows.Forms.Button BtnTagUser;
	}
}