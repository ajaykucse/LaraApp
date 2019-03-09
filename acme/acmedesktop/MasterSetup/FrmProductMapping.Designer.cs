namespace acmedesktop.MasterSetup
{
    partial class FrmProductMapping
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
            this.tabrestaurantProduct = new System.Windows.Forms.TabControl();
            this.TabProductGroup = new System.Windows.Forms.TabPage();
            this.BtnMapToProductGroupCancel = new System.Windows.Forms.Button();
            this.BtnMapToProductGroup = new System.Windows.Forms.Button();
            this.GridProductGroup = new System.Windows.Forms.DataGridView();
            this.TxtProductGroup = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchProductGroup = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TabProductSubGroup = new System.Windows.Forms.TabPage();
            this.TxtProGroup = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchProGroup = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnMapToProductSubGroupCancel = new System.Windows.Forms.Button();
            this.BtnMapToProductSubGroup = new System.Windows.Forms.Button();
            this.GridProductSubGroup = new System.Windows.Forms.DataGridView();
            this.BtnSearchProductSubGroup = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtProductSubGroup = new acmedesktop.MyInputControls.MyTextBox();
            this.TabBranch = new System.Windows.Forms.TabPage();
            this.BtnMapToBranchCancel = new System.Windows.Forms.Button();
            this.BtnMapToBranchOk = new System.Windows.Forms.Button();
            this.GridBranch = new System.Windows.Forms.DataGridView();
            this.TxtBranch = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchBranch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TabCompanyUnit = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.LblBranch = new System.Windows.Forms.Label();
            this.BtnMapToCompanyUnitCancel = new System.Windows.Forms.Button();
            this.BtnMapToCompanyUnitOk = new System.Windows.Forms.Button();
            this.GridCompanyUnit = new System.Windows.Forms.DataGridView();
            this.TxtCompanyUnit = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchCompanyUnit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabCounterProduct = new System.Windows.Forms.TabPage();
            this.btnCancelCounterMap = new System.Windows.Forms.Button();
            this.btnSaveCounterMap = new System.Windows.Forms.Button();
            this.GridCounterProuctMapping = new System.Windows.Forms.DataGridView();
            this.TxtCounterName = new acmedesktop.MyInputControls.MyTextBox();
            this.BtnSearchCounter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabrestaurantProduct.SuspendLayout();
            this.TabProductGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridProductGroup)).BeginInit();
            this.TabProductSubGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridProductSubGroup)).BeginInit();
            this.TabBranch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridBranch)).BeginInit();
            this.TabCompanyUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCompanyUnit)).BeginInit();
            this.tabCounterProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCounterProuctMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // tabrestaurantProduct
            // 
            this.tabrestaurantProduct.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabrestaurantProduct.CausesValidation = false;
            this.tabrestaurantProduct.Controls.Add(this.TabProductGroup);
            this.tabrestaurantProduct.Controls.Add(this.TabProductSubGroup);
            this.tabrestaurantProduct.Controls.Add(this.TabBranch);
            this.tabrestaurantProduct.Controls.Add(this.TabCompanyUnit);
            this.tabrestaurantProduct.Controls.Add(this.tabCounterProduct);
            this.tabrestaurantProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabrestaurantProduct.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabrestaurantProduct.Location = new System.Drawing.Point(0, 0);
            this.tabrestaurantProduct.Name = "tabrestaurantProduct";
            this.tabrestaurantProduct.SelectedIndex = 0;
            this.tabrestaurantProduct.Size = new System.Drawing.Size(746, 393);
            this.tabrestaurantProduct.TabIndex = 0;
            this.tabrestaurantProduct.TabStop = false;
            // 
            // TabProductGroup
            // 
            this.TabProductGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.TabProductGroup.Controls.Add(this.BtnMapToProductGroupCancel);
            this.TabProductGroup.Controls.Add(this.BtnMapToProductGroup);
            this.TabProductGroup.Controls.Add(this.GridProductGroup);
            this.TabProductGroup.Controls.Add(this.TxtProductGroup);
            this.TabProductGroup.Controls.Add(this.BtnSearchProductGroup);
            this.TabProductGroup.Controls.Add(this.label11);
            this.TabProductGroup.Location = new System.Drawing.Point(4, 28);
            this.TabProductGroup.Name = "TabProductGroup";
            this.TabProductGroup.Padding = new System.Windows.Forms.Padding(3);
            this.TabProductGroup.Size = new System.Drawing.Size(738, 361);
            this.TabProductGroup.TabIndex = 0;
            this.TabProductGroup.Text = "Product Group";
            // 
            // BtnMapToProductGroupCancel
            // 
            this.BtnMapToProductGroupCancel.CausesValidation = false;
            this.BtnMapToProductGroupCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToProductGroupCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnMapToProductGroupCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToProductGroupCancel.Location = new System.Drawing.Point(642, 326);
            this.BtnMapToProductGroupCancel.Name = "BtnMapToProductGroupCancel";
            this.BtnMapToProductGroupCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnMapToProductGroupCancel.TabIndex = 5;
            this.BtnMapToProductGroupCancel.Text = "     &CANCEL";
            this.BtnMapToProductGroupCancel.UseVisualStyleBackColor = true;
            this.BtnMapToProductGroupCancel.Click += new System.EventHandler(this.BtnMapToProductGroupCancel_Click);
            // 
            // BtnMapToProductGroup
            // 
            this.BtnMapToProductGroup.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToProductGroup.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnMapToProductGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToProductGroup.Location = new System.Drawing.Point(584, 327);
            this.BtnMapToProductGroup.Name = "BtnMapToProductGroup";
            this.BtnMapToProductGroup.Size = new System.Drawing.Size(57, 31);
            this.BtnMapToProductGroup.TabIndex = 4;
            this.BtnMapToProductGroup.Text = "     &OK";
            this.BtnMapToProductGroup.UseVisualStyleBackColor = true;
            this.BtnMapToProductGroup.Click += new System.EventHandler(this.BtnMapToProductGroup_Click);
            // 
            // GridProductGroup
            // 
            this.GridProductGroup.AllowUserToAddRows = false;
            this.GridProductGroup.AllowUserToDeleteRows = false;
            this.GridProductGroup.AllowUserToResizeColumns = false;
            this.GridProductGroup.AllowUserToResizeRows = false;
            this.GridProductGroup.BackgroundColor = System.Drawing.Color.White;
            this.GridProductGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProductGroup.Location = new System.Drawing.Point(8, 36);
            this.GridProductGroup.Name = "GridProductGroup";
            this.GridProductGroup.RowHeadersVisible = false;
            this.GridProductGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridProductGroup.Size = new System.Drawing.Size(726, 288);
            this.GridProductGroup.TabIndex = 3;
            // 
            // TxtProductGroup
            // 
            this.TxtProductGroup.BackColor = System.Drawing.Color.White;
            this.TxtProductGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProductGroup.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProductGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtProductGroup.Location = new System.Drawing.Point(107, 7);
            this.TxtProductGroup.Name = "TxtProductGroup";
            this.TxtProductGroup.ReadOnly = true;
            this.TxtProductGroup.Size = new System.Drawing.Size(188, 22);
            this.TxtProductGroup.TabIndex = 1;
            this.TxtProductGroup.Tag = "0";
            this.TxtProductGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductGroup_KeyDown);
            // 
            // BtnSearchProductGroup
            // 
            this.BtnSearchProductGroup.CausesValidation = false;
            this.BtnSearchProductGroup.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchProductGroup.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchProductGroup.Location = new System.Drawing.Point(295, 6);
            this.BtnSearchProductGroup.Name = "BtnSearchProductGroup";
            this.BtnSearchProductGroup.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchProductGroup.TabIndex = 2;
            this.BtnSearchProductGroup.TabStop = false;
            this.BtnSearchProductGroup.UseVisualStyleBackColor = true;
            this.BtnSearchProductGroup.Click += new System.EventHandler(this.BtnSearchProductGroup_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label11.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label11.Location = new System.Drawing.Point(8, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Product Group";
            // 
            // TabProductSubGroup
            // 
            this.TabProductSubGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.TabProductSubGroup.Controls.Add(this.TxtProGroup);
            this.TabProductSubGroup.Controls.Add(this.BtnSearchProGroup);
            this.TabProductSubGroup.Controls.Add(this.label7);
            this.TabProductSubGroup.Controls.Add(this.BtnMapToProductSubGroupCancel);
            this.TabProductSubGroup.Controls.Add(this.BtnMapToProductSubGroup);
            this.TabProductSubGroup.Controls.Add(this.GridProductSubGroup);
            this.TabProductSubGroup.Controls.Add(this.BtnSearchProductSubGroup);
            this.TabProductSubGroup.Controls.Add(this.label12);
            this.TabProductSubGroup.Controls.Add(this.TxtProductSubGroup);
            this.TabProductSubGroup.Location = new System.Drawing.Point(4, 28);
            this.TabProductSubGroup.Name = "TabProductSubGroup";
            this.TabProductSubGroup.Size = new System.Drawing.Size(738, 361);
            this.TabProductSubGroup.TabIndex = 6;
            this.TabProductSubGroup.Text = "Product Sub Group";
            // 
            // TxtProGroup
            // 
            this.TxtProGroup.BackColor = System.Drawing.Color.White;
            this.TxtProGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProGroup.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtProGroup.Location = new System.Drawing.Point(106, 6);
            this.TxtProGroup.Name = "TxtProGroup";
            this.TxtProGroup.ReadOnly = true;
            this.TxtProGroup.Size = new System.Drawing.Size(188, 22);
            this.TxtProGroup.TabIndex = 1;
            this.TxtProGroup.Tag = "0";
            this.TxtProGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProGroup_KeyDown);
            // 
            // BtnSearchProGroup
            // 
            this.BtnSearchProGroup.CausesValidation = false;
            this.BtnSearchProGroup.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchProGroup.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchProGroup.Location = new System.Drawing.Point(294, 5);
            this.BtnSearchProGroup.Name = "BtnSearchProGroup";
            this.BtnSearchProGroup.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchProGroup.TabIndex = 2;
            this.BtnSearchProGroup.TabStop = false;
            this.BtnSearchProGroup.UseVisualStyleBackColor = true;
            this.BtnSearchProGroup.Click += new System.EventHandler(this.BtnSearchProGroup_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Product Group";
            // 
            // BtnMapToProductSubGroupCancel
            // 
            this.BtnMapToProductSubGroupCancel.CausesValidation = false;
            this.BtnMapToProductSubGroupCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToProductSubGroupCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnMapToProductSubGroupCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToProductSubGroupCancel.Location = new System.Drawing.Point(643, 327);
            this.BtnMapToProductSubGroupCancel.Name = "BtnMapToProductSubGroupCancel";
            this.BtnMapToProductSubGroupCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnMapToProductSubGroupCancel.TabIndex = 8;
            this.BtnMapToProductSubGroupCancel.Text = "     &CANCEL";
            this.BtnMapToProductSubGroupCancel.UseVisualStyleBackColor = true;
            this.BtnMapToProductSubGroupCancel.Click += new System.EventHandler(this.BtnMapToProductSubGroupCancel_Click);
            // 
            // BtnMapToProductSubGroup
            // 
            this.BtnMapToProductSubGroup.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToProductSubGroup.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnMapToProductSubGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToProductSubGroup.Location = new System.Drawing.Point(585, 328);
            this.BtnMapToProductSubGroup.Name = "BtnMapToProductSubGroup";
            this.BtnMapToProductSubGroup.Size = new System.Drawing.Size(57, 31);
            this.BtnMapToProductSubGroup.TabIndex = 7;
            this.BtnMapToProductSubGroup.Text = "     &OK";
            this.BtnMapToProductSubGroup.UseVisualStyleBackColor = true;
            this.BtnMapToProductSubGroup.Click += new System.EventHandler(this.BtnMapToProductSubGroup_Click);
            // 
            // GridProductSubGroup
            // 
            this.GridProductSubGroup.AllowUserToAddRows = false;
            this.GridProductSubGroup.AllowUserToDeleteRows = false;
            this.GridProductSubGroup.AllowUserToResizeColumns = false;
            this.GridProductSubGroup.AllowUserToResizeRows = false;
            this.GridProductSubGroup.BackgroundColor = System.Drawing.Color.White;
            this.GridProductSubGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProductSubGroup.Location = new System.Drawing.Point(8, 34);
            this.GridProductSubGroup.Name = "GridProductSubGroup";
            this.GridProductSubGroup.RowHeadersVisible = false;
            this.GridProductSubGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridProductSubGroup.Size = new System.Drawing.Size(726, 288);
            this.GridProductSubGroup.TabIndex = 6;
            // 
            // BtnSearchProductSubGroup
            // 
            this.BtnSearchProductSubGroup.CausesValidation = false;
            this.BtnSearchProductSubGroup.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchProductSubGroup.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchProductSubGroup.Location = new System.Drawing.Point(637, 4);
            this.BtnSearchProductSubGroup.Name = "BtnSearchProductSubGroup";
            this.BtnSearchProductSubGroup.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchProductSubGroup.TabIndex = 5;
            this.BtnSearchProductSubGroup.TabStop = false;
            this.BtnSearchProductSubGroup.UseVisualStyleBackColor = true;
            this.BtnSearchProductSubGroup.Click += new System.EventHandler(this.BtnSearchProductSubGroup_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label12.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label12.Location = new System.Drawing.Point(341, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Product Sub Group";
            // 
            // TxtProductSubGroup
            // 
            this.TxtProductSubGroup.BackColor = System.Drawing.Color.NavajoWhite;
            this.TxtProductSubGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProductSubGroup.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProductSubGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtProductSubGroup.Location = new System.Drawing.Point(468, 5);
            this.TxtProductSubGroup.Name = "TxtProductSubGroup";
            this.TxtProductSubGroup.ReadOnly = true;
            this.TxtProductSubGroup.Size = new System.Drawing.Size(169, 22);
            this.TxtProductSubGroup.TabIndex = 4;
            this.TxtProductSubGroup.Tag = "0";
            this.TxtProductSubGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductSubGroup_KeyDown);
            // 
            // TabBranch
            // 
            this.TabBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.TabBranch.Controls.Add(this.BtnMapToBranchCancel);
            this.TabBranch.Controls.Add(this.BtnMapToBranchOk);
            this.TabBranch.Controls.Add(this.GridBranch);
            this.TabBranch.Controls.Add(this.TxtBranch);
            this.TabBranch.Controls.Add(this.BtnSearchBranch);
            this.TabBranch.Controls.Add(this.label3);
            this.TabBranch.Location = new System.Drawing.Point(4, 28);
            this.TabBranch.Name = "TabBranch";
            this.TabBranch.Padding = new System.Windows.Forms.Padding(3);
            this.TabBranch.Size = new System.Drawing.Size(738, 361);
            this.TabBranch.TabIndex = 4;
            this.TabBranch.Text = "Branch";
            // 
            // BtnMapToBranchCancel
            // 
            this.BtnMapToBranchCancel.CausesValidation = false;
            this.BtnMapToBranchCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToBranchCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnMapToBranchCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToBranchCancel.Location = new System.Drawing.Point(643, 326);
            this.BtnMapToBranchCancel.Name = "BtnMapToBranchCancel";
            this.BtnMapToBranchCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnMapToBranchCancel.TabIndex = 5;
            this.BtnMapToBranchCancel.Text = "     &CANCEL";
            this.BtnMapToBranchCancel.UseVisualStyleBackColor = true;
            this.BtnMapToBranchCancel.Click += new System.EventHandler(this.BtnMapToBranchCancel_Click);
            // 
            // BtnMapToBranchOk
            // 
            this.BtnMapToBranchOk.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToBranchOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnMapToBranchOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToBranchOk.Location = new System.Drawing.Point(585, 327);
            this.BtnMapToBranchOk.Name = "BtnMapToBranchOk";
            this.BtnMapToBranchOk.Size = new System.Drawing.Size(57, 31);
            this.BtnMapToBranchOk.TabIndex = 4;
            this.BtnMapToBranchOk.Text = "     &OK";
            this.BtnMapToBranchOk.UseVisualStyleBackColor = true;
            this.BtnMapToBranchOk.Click += new System.EventHandler(this.BtnMapToBranchOk_Click);
            // 
            // GridBranch
            // 
            this.GridBranch.AllowUserToAddRows = false;
            this.GridBranch.AllowUserToDeleteRows = false;
            this.GridBranch.AllowUserToResizeColumns = false;
            this.GridBranch.AllowUserToResizeRows = false;
            this.GridBranch.BackgroundColor = System.Drawing.Color.White;
            this.GridBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridBranch.Location = new System.Drawing.Point(10, 35);
            this.GridBranch.Name = "GridBranch";
            this.GridBranch.RowHeadersVisible = false;
            this.GridBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridBranch.Size = new System.Drawing.Size(726, 288);
            this.GridBranch.TabIndex = 3;
            // 
            // TxtBranch
            // 
            this.TxtBranch.BackColor = System.Drawing.Color.White;
            this.TxtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBranch.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBranch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtBranch.Location = new System.Drawing.Point(63, 7);
            this.TxtBranch.Name = "TxtBranch";
            this.TxtBranch.ReadOnly = true;
            this.TxtBranch.Size = new System.Drawing.Size(232, 22);
            this.TxtBranch.TabIndex = 1;
            this.TxtBranch.Tag = "0";
            this.TxtBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBranch_KeyDown);
            // 
            // BtnSearchBranch
            // 
            this.BtnSearchBranch.CausesValidation = false;
            this.BtnSearchBranch.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchBranch.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchBranch.Location = new System.Drawing.Point(295, 6);
            this.BtnSearchBranch.Name = "BtnSearchBranch";
            this.BtnSearchBranch.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchBranch.TabIndex = 2;
            this.BtnSearchBranch.TabStop = false;
            this.BtnSearchBranch.UseVisualStyleBackColor = true;
            this.BtnSearchBranch.Click += new System.EventHandler(this.BtnSearchBranch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Branch";
            // 
            // TabCompanyUnit
            // 
            this.TabCompanyUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.TabCompanyUnit.Controls.Add(this.label6);
            this.TabCompanyUnit.Controls.Add(this.LblBranch);
            this.TabCompanyUnit.Controls.Add(this.BtnMapToCompanyUnitCancel);
            this.TabCompanyUnit.Controls.Add(this.BtnMapToCompanyUnitOk);
            this.TabCompanyUnit.Controls.Add(this.GridCompanyUnit);
            this.TabCompanyUnit.Controls.Add(this.TxtCompanyUnit);
            this.TabCompanyUnit.Controls.Add(this.BtnSearchCompanyUnit);
            this.TabCompanyUnit.Controls.Add(this.label4);
            this.TabCompanyUnit.Location = new System.Drawing.Point(4, 28);
            this.TabCompanyUnit.Name = "TabCompanyUnit";
            this.TabCompanyUnit.Size = new System.Drawing.Size(738, 361);
            this.TabCompanyUnit.TabIndex = 5;
            this.TabCompanyUnit.Text = "Company Unit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label6.Location = new System.Drawing.Point(367, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Branch :";
            // 
            // LblBranch
            // 
            this.LblBranch.AutoSize = true;
            this.LblBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.LblBranch.Font = new System.Drawing.Font("Arial", 9.5F);
            this.LblBranch.Location = new System.Drawing.Point(424, 10);
            this.LblBranch.Name = "LblBranch";
            this.LblBranch.Size = new System.Drawing.Size(49, 16);
            this.LblBranch.TabIndex = 4;
            this.LblBranch.Tag = "0";
            this.LblBranch.Text = "Branch";
            // 
            // BtnMapToCompanyUnitCancel
            // 
            this.BtnMapToCompanyUnitCancel.CausesValidation = false;
            this.BtnMapToCompanyUnitCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToCompanyUnitCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnMapToCompanyUnitCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToCompanyUnitCancel.Location = new System.Drawing.Point(642, 329);
            this.BtnMapToCompanyUnitCancel.Name = "BtnMapToCompanyUnitCancel";
            this.BtnMapToCompanyUnitCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnMapToCompanyUnitCancel.TabIndex = 7;
            this.BtnMapToCompanyUnitCancel.Text = "     &CANCEL";
            this.BtnMapToCompanyUnitCancel.UseVisualStyleBackColor = true;
            this.BtnMapToCompanyUnitCancel.Click += new System.EventHandler(this.BtnMapToCompanyUnitCancel_Click);
            // 
            // BtnMapToCompanyUnitOk
            // 
            this.BtnMapToCompanyUnitOk.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnMapToCompanyUnitOk.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnMapToCompanyUnitOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMapToCompanyUnitOk.Location = new System.Drawing.Point(584, 330);
            this.BtnMapToCompanyUnitOk.Name = "BtnMapToCompanyUnitOk";
            this.BtnMapToCompanyUnitOk.Size = new System.Drawing.Size(57, 31);
            this.BtnMapToCompanyUnitOk.TabIndex = 6;
            this.BtnMapToCompanyUnitOk.Text = "     &OK";
            this.BtnMapToCompanyUnitOk.UseVisualStyleBackColor = true;
            this.BtnMapToCompanyUnitOk.Click += new System.EventHandler(this.BtnMapToCompanyUnitOk_Click);
            // 
            // GridCompanyUnit
            // 
            this.GridCompanyUnit.AllowUserToAddRows = false;
            this.GridCompanyUnit.AllowUserToDeleteRows = false;
            this.GridCompanyUnit.AllowUserToResizeColumns = false;
            this.GridCompanyUnit.AllowUserToResizeRows = false;
            this.GridCompanyUnit.BackgroundColor = System.Drawing.Color.White;
            this.GridCompanyUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCompanyUnit.Location = new System.Drawing.Point(9, 35);
            this.GridCompanyUnit.Name = "GridCompanyUnit";
            this.GridCompanyUnit.RowHeadersVisible = false;
            this.GridCompanyUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridCompanyUnit.Size = new System.Drawing.Size(726, 288);
            this.GridCompanyUnit.TabIndex = 5;
            // 
            // TxtCompanyUnit
            // 
            this.TxtCompanyUnit.BackColor = System.Drawing.Color.White;
            this.TxtCompanyUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCompanyUnit.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCompanyUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtCompanyUnit.Location = new System.Drawing.Point(96, 8);
            this.TxtCompanyUnit.Name = "TxtCompanyUnit";
            this.TxtCompanyUnit.ReadOnly = true;
            this.TxtCompanyUnit.Size = new System.Drawing.Size(232, 22);
            this.TxtCompanyUnit.TabIndex = 1;
            this.TxtCompanyUnit.Tag = "0";
            this.TxtCompanyUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCompanyUnit_KeyDown);
            // 
            // BtnSearchCompanyUnit
            // 
            this.BtnSearchCompanyUnit.CausesValidation = false;
            this.BtnSearchCompanyUnit.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchCompanyUnit.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchCompanyUnit.Location = new System.Drawing.Point(328, 7);
            this.BtnSearchCompanyUnit.Name = "BtnSearchCompanyUnit";
            this.BtnSearchCompanyUnit.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchCompanyUnit.TabIndex = 2;
            this.BtnSearchCompanyUnit.TabStop = false;
            this.BtnSearchCompanyUnit.UseVisualStyleBackColor = true;
            this.BtnSearchCompanyUnit.Click += new System.EventHandler(this.BtnSearchCompanyUnit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Company Unit";
            // 
            // tabCounterProduct
            // 
            this.tabCounterProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.tabCounterProduct.Controls.Add(this.btnCancelCounterMap);
            this.tabCounterProduct.Controls.Add(this.btnSaveCounterMap);
            this.tabCounterProduct.Controls.Add(this.GridCounterProuctMapping);
            this.tabCounterProduct.Controls.Add(this.TxtCounterName);
            this.tabCounterProduct.Controls.Add(this.BtnSearchCounter);
            this.tabCounterProduct.Controls.Add(this.label1);
            this.tabCounterProduct.Location = new System.Drawing.Point(4, 28);
            this.tabCounterProduct.Name = "tabCounterProduct";
            this.tabCounterProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabCounterProduct.Size = new System.Drawing.Size(738, 361);
            this.tabCounterProduct.TabIndex = 7;
            this.tabCounterProduct.Text = "Counter Product";
            // 
            // btnCancelCounterMap
            // 
            this.btnCancelCounterMap.CausesValidation = false;
            this.btnCancelCounterMap.Font = new System.Drawing.Font("Arial", 9.5F);
            this.btnCancelCounterMap.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.btnCancelCounterMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelCounterMap.Location = new System.Drawing.Point(641, 327);
            this.btnCancelCounterMap.Name = "btnCancelCounterMap";
            this.btnCancelCounterMap.Size = new System.Drawing.Size(91, 31);
            this.btnCancelCounterMap.TabIndex = 9;
            this.btnCancelCounterMap.Text = "     &CANCEL";
            this.btnCancelCounterMap.UseVisualStyleBackColor = true;
            this.btnCancelCounterMap.Click += new System.EventHandler(this.btnCancelCounterMap_Click);
            // 
            // btnSaveCounterMap
            // 
            this.btnSaveCounterMap.Font = new System.Drawing.Font("Arial", 9.5F);
            this.btnSaveCounterMap.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.btnSaveCounterMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveCounterMap.Location = new System.Drawing.Point(583, 328);
            this.btnSaveCounterMap.Name = "btnSaveCounterMap";
            this.btnSaveCounterMap.Size = new System.Drawing.Size(57, 31);
            this.btnSaveCounterMap.TabIndex = 8;
            this.btnSaveCounterMap.Text = "     &OK";
            this.btnSaveCounterMap.UseVisualStyleBackColor = true;
            this.btnSaveCounterMap.Click += new System.EventHandler(this.btnSaveCounterMap_Click);
            // 
            // GridCounterProuctMapping
            // 
            this.GridCounterProuctMapping.AllowUserToAddRows = false;
            this.GridCounterProuctMapping.AllowUserToDeleteRows = false;
            this.GridCounterProuctMapping.AllowUserToResizeColumns = false;
            this.GridCounterProuctMapping.AllowUserToResizeRows = false;
            this.GridCounterProuctMapping.BackgroundColor = System.Drawing.Color.White;
            this.GridCounterProuctMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCounterProuctMapping.Location = new System.Drawing.Point(6, 41);
            this.GridCounterProuctMapping.Name = "GridCounterProuctMapping";
            this.GridCounterProuctMapping.RowHeadersVisible = false;
            this.GridCounterProuctMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridCounterProuctMapping.Size = new System.Drawing.Size(726, 281);
            this.GridCounterProuctMapping.TabIndex = 7;
            // 
            // TxtCounterName
            // 
            this.TxtCounterName.BackColor = System.Drawing.Color.NavajoWhite;
            this.TxtCounterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCounterName.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCounterName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtCounterName.Location = new System.Drawing.Point(105, 11);
            this.TxtCounterName.Name = "TxtCounterName";
            this.TxtCounterName.ReadOnly = true;
            this.TxtCounterName.Size = new System.Drawing.Size(188, 22);
            this.TxtCounterName.TabIndex = 5;
            this.TxtCounterName.Tag = "0";
            this.TxtCounterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCounterName_KeyDown);
            // 
            // BtnSearchCounter
            // 
            this.BtnSearchCounter.CausesValidation = false;
            this.BtnSearchCounter.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearchCounter.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearchCounter.Location = new System.Drawing.Point(293, 10);
            this.BtnSearchCounter.Name = "BtnSearchCounter";
            this.BtnSearchCounter.Size = new System.Drawing.Size(33, 25);
            this.BtnSearchCounter.TabIndex = 6;
            this.BtnSearchCounter.TabStop = false;
            this.BtnSearchCounter.UseVisualStyleBackColor = true;
            this.BtnSearchCounter.Click += new System.EventHandler(this.BtnSearchCounter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Counter ";
            // 
            // FrmProductMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 393);
            this.Controls.Add(this.tabrestaurantProduct);
            this.KeyPreview = true;
            this.Name = "FrmProductMapping";
            this.ShowIcon = false;
            this.Text = "Product Mapping";
            this.Load += new System.EventHandler(this.FrmProductMapping_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProductMapping_KeyDown);
            this.tabrestaurantProduct.ResumeLayout(false);
            this.TabProductGroup.ResumeLayout(false);
            this.TabProductGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridProductGroup)).EndInit();
            this.TabProductSubGroup.ResumeLayout(false);
            this.TabProductSubGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridProductSubGroup)).EndInit();
            this.TabBranch.ResumeLayout(false);
            this.TabBranch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridBranch)).EndInit();
            this.TabCompanyUnit.ResumeLayout(false);
            this.TabCompanyUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCompanyUnit)).EndInit();
            this.tabCounterProduct.ResumeLayout(false);
            this.tabCounterProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCounterProuctMapping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabrestaurantProduct;
        private System.Windows.Forms.TabPage TabProductGroup;
        private System.Windows.Forms.Button BtnMapToProductGroupCancel;
        private System.Windows.Forms.Button BtnMapToProductGroup;
        private System.Windows.Forms.DataGridView GridProductGroup;
        private MyInputControls.MyTextBox TxtProductGroup;
        private System.Windows.Forms.Button BtnSearchProductGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage TabProductSubGroup;
        private MyInputControls.MyTextBox TxtProGroup;
        private System.Windows.Forms.Button BtnSearchProGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnMapToProductSubGroupCancel;
        private System.Windows.Forms.Button BtnMapToProductSubGroup;
        private System.Windows.Forms.DataGridView GridProductSubGroup;
        private System.Windows.Forms.Button BtnSearchProductSubGroup;
        private System.Windows.Forms.Label label12;
        private MyInputControls.MyTextBox TxtProductSubGroup;
        private System.Windows.Forms.TabPage TabBranch;
        private System.Windows.Forms.Button BtnMapToBranchCancel;
        private System.Windows.Forms.Button BtnMapToBranchOk;
        private System.Windows.Forms.DataGridView GridBranch;
        private MyInputControls.MyTextBox TxtBranch;
        private System.Windows.Forms.Button BtnSearchBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TabCompanyUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblBranch;
        private System.Windows.Forms.Button BtnMapToCompanyUnitCancel;
        private System.Windows.Forms.Button BtnMapToCompanyUnitOk;
        private System.Windows.Forms.DataGridView GridCompanyUnit;
        private MyInputControls.MyTextBox TxtCompanyUnit;
        private System.Windows.Forms.Button BtnSearchCompanyUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabCounterProduct;
        private System.Windows.Forms.DataGridView GridCounterProuctMapping;
        private MyInputControls.MyTextBox TxtCounterName;
        private System.Windows.Forms.Button BtnSearchCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelCounterMap;
        private System.Windows.Forms.Button btnSaveCounterMap;
    }
}