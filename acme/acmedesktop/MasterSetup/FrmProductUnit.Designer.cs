﻿namespace acmedesktop.MasterSetup
{
    partial class FrmProductUnit
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
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.PnlBorderHeaderTop = new System.Windows.Forms.Panel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnLastData = new System.Windows.Forms.Button();
            this.BtnPreviousData = new System.Windows.Forms.Button();
            this.BtnNextData = new System.Windows.Forms.Button();
            this.BtnFirstData = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.PnlBorderHeaderBottom = new System.Windows.Forms.Panel();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PnlBorderFooterBoootm = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PnlBorderFooterTop = new System.Windows.Forms.Panel();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.TxtDescription = new acmedesktop.MyInputControls.MyTextBox();
            this.CbActive = new System.Windows.Forms.CheckBox();
            this.TxtShortName = new acmedesktop.MyInputControls.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSearcAccountDesc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelHeader.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.PanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelHeader.Controls.Add(this.PnlBorderHeaderTop);
            this.PanelHeader.Controls.Add(this.BtnExit);
            this.PanelHeader.Controls.Add(this.BtnLastData);
            this.PanelHeader.Controls.Add(this.BtnPreviousData);
            this.PanelHeader.Controls.Add(this.BtnNextData);
            this.PanelHeader.Controls.Add(this.BtnFirstData);
            this.PanelHeader.Controls.Add(this.BtnDelete);
            this.PanelHeader.Controls.Add(this.BtnEdit);
            this.PanelHeader.Controls.Add(this.BtnNew);
            this.PanelHeader.Controls.Add(this.PnlBorderHeaderBottom);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(462, 36);
            this.PanelHeader.TabIndex = 0;
            // 
            // PnlBorderHeaderTop
            // 
            this.PnlBorderHeaderTop.BackColor = System.Drawing.Color.White;
            this.PnlBorderHeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBorderHeaderTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderHeaderTop.Name = "PnlBorderHeaderTop";
            this.PnlBorderHeaderTop.Size = new System.Drawing.Size(462, 1);
            this.PnlBorderHeaderTop.TabIndex = 8;
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnExit.Image = global::acmedesktop.Properties.Resources.Exit_24;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(393, 5);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(65, 28);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "     E&XIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnLastData
            // 
            this.BtnLastData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnLastData.Location = new System.Drawing.Point(332, 4);
            this.BtnLastData.Name = "BtnLastData";
            this.BtnLastData.Size = new System.Drawing.Size(35, 28);
            this.BtnLastData.TabIndex = 6;
            this.BtnLastData.Text = ">|";
            this.BtnLastData.UseVisualStyleBackColor = true;
            this.BtnLastData.Click += new System.EventHandler(this.BtnLastData_Click);
            // 
            // BtnPreviousData
            // 
            this.BtnPreviousData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnPreviousData.Location = new System.Drawing.Point(297, 4);
            this.BtnPreviousData.Name = "BtnPreviousData";
            this.BtnPreviousData.Size = new System.Drawing.Size(35, 28);
            this.BtnPreviousData.TabIndex = 5;
            this.BtnPreviousData.Text = "<<";
            this.BtnPreviousData.UseVisualStyleBackColor = true;
            this.BtnPreviousData.Click += new System.EventHandler(this.BtnPreviousData_Click);
            // 
            // BtnNextData
            // 
            this.BtnNextData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnNextData.Location = new System.Drawing.Point(262, 4);
            this.BtnNextData.Name = "BtnNextData";
            this.BtnNextData.Size = new System.Drawing.Size(35, 28);
            this.BtnNextData.TabIndex = 4;
            this.BtnNextData.Text = ">>";
            this.BtnNextData.UseVisualStyleBackColor = true;
            this.BtnNextData.Click += new System.EventHandler(this.BtnNextData_Click);
            // 
            // BtnFirstData
            // 
            this.BtnFirstData.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnFirstData.Location = new System.Drawing.Point(227, 4);
            this.BtnFirstData.Name = "BtnFirstData";
            this.BtnFirstData.Size = new System.Drawing.Size(35, 28);
            this.BtnFirstData.TabIndex = 3;
            this.BtnFirstData.Text = "|<";
            this.BtnFirstData.UseVisualStyleBackColor = true;
            this.BtnFirstData.Click += new System.EventHandler(this.BtnFirstData_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnDelete.Image = global::acmedesktop.Properties.Resources.Delete_24;
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.Location = new System.Drawing.Point(137, 4);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(90, 28);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "     &DELETE";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnEdit.Image = global::acmedesktop.Properties.Resources.Edit_24;
            this.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEdit.Location = new System.Drawing.Point(70, 4);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(67, 28);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "     &EDIT";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnNew.Image = global::acmedesktop.Properties.Resources.New_24;
            this.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNew.Location = new System.Drawing.Point(3, 4);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(67, 28);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "     &NEW";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlBorderHeaderBottom
            // 
            this.PnlBorderHeaderBottom.BackColor = System.Drawing.Color.White;
            this.PnlBorderHeaderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderHeaderBottom.Location = new System.Drawing.Point(0, 35);
            this.PnlBorderHeaderBottom.Name = "PnlBorderHeaderBottom";
            this.PnlBorderHeaderBottom.Size = new System.Drawing.Size(462, 1);
            this.PnlBorderHeaderBottom.TabIndex = 0;
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelFooter.CausesValidation = false;
            this.PanelFooter.Controls.Add(this.PnlBorderFooterBoootm);
            this.PanelFooter.Controls.Add(this.BtnCancel);
            this.PanelFooter.Controls.Add(this.BtnSave);
            this.PanelFooter.Controls.Add(this.PnlBorderFooterTop);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 131);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(462, 36);
            this.PanelFooter.TabIndex = 1;
            // 
            // PnlBorderFooterBoootm
            // 
            this.PnlBorderFooterBoootm.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterBoootm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBorderFooterBoootm.Location = new System.Drawing.Point(0, 35);
            this.PnlBorderFooterBoootm.Name = "PnlBorderFooterBoootm";
            this.PnlBorderFooterBoootm.Size = new System.Drawing.Size(462, 1);
            this.PnlBorderFooterBoootm.TabIndex = 3;
            // 
            // BtnCancel
            // 
            this.BtnCancel.CausesValidation = false;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnCancel.Image = global::acmedesktop.Properties.Resources.Cancel_24;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(367, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(91, 31);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "     &CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Arial", 9.5F);
            this.BtnSave.Image = global::acmedesktop.Properties.Resources.Ok_24;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(310, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(57, 31);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "     &OK";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // PnlBorderFooterTop
            // 
            this.PnlBorderFooterTop.BackColor = System.Drawing.Color.White;
            this.PnlBorderFooterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBorderFooterTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderFooterTop.Name = "PnlBorderFooterTop";
            this.PnlBorderFooterTop.Size = new System.Drawing.Size(462, 1);
            this.PnlBorderFooterTop.TabIndex = 0;
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.PanelContainer.Controls.Add(this.TxtDescription);
            this.PanelContainer.Controls.Add(this.CbActive);
            this.PanelContainer.Controls.Add(this.TxtShortName);
            this.PanelContainer.Controls.Add(this.label5);
            this.PanelContainer.Controls.Add(this.BtnSearcAccountDesc);
            this.PanelContainer.Controls.Add(this.label1);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelContainer.Location = new System.Drawing.Point(0, 36);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(462, 95);
            this.PanelContainer.TabIndex = 2;
            // 
            // TxtDescription
            // 
            this.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescription.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtDescription.Location = new System.Drawing.Point(128, 6);
            this.TxtDescription.MaxLength = 200;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(297, 22);
            this.TxtDescription.TabIndex = 1;
            this.TxtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescription_KeyDown);
            this.TxtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDescription_Validating);
            // 
            // CbActive
            // 
            this.CbActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.CbActive.Checked = true;
            this.CbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbActive.Font = new System.Drawing.Font("Arial", 9.5F);
            this.CbActive.Location = new System.Drawing.Point(15, 64);
            this.CbActive.Name = "CbActive";
            this.CbActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CbActive.Size = new System.Drawing.Size(128, 26);
            this.CbActive.TabIndex = 4;
            this.CbActive.Text = "Active";
            this.CbActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbActive.UseVisualStyleBackColor = false;
            // 
            // TxtShortName
            // 
            this.TxtShortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtShortName.Font = new System.Drawing.Font("Arial", 9.5F);
            this.TxtShortName.Location = new System.Drawing.Point(128, 37);
            this.TxtShortName.MaxLength = 50;
            this.TxtShortName.Name = "TxtShortName";
            this.TxtShortName.Size = new System.Drawing.Size(186, 22);
            this.TxtShortName.TabIndex = 2;
            this.TxtShortName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtShortName_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label5.Location = new System.Drawing.Point(15, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Short Name";
            // 
            // BtnSearcAccountDesc
            // 
            this.BtnSearcAccountDesc.CausesValidation = false;
            this.BtnSearcAccountDesc.Font = new System.Drawing.Font("Arial", 9F);
            this.BtnSearcAccountDesc.Image = global::acmedesktop.Properties.Resources.search_16;
            this.BtnSearcAccountDesc.Location = new System.Drawing.Point(427, 5);
            this.BtnSearcAccountDesc.Name = "BtnSearcAccountDesc";
            this.BtnSearcAccountDesc.Size = new System.Drawing.Size(31, 25);
            this.BtnSearcAccountDesc.TabIndex = 35;
            this.BtnSearcAccountDesc.TabStop = false;
            this.BtnSearcAccountDesc.UseVisualStyleBackColor = true;
            this.BtnSearcAccountDesc.Click += new System.EventHandler(this.BtnDescription_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Description";
            // 
            // FrmProductUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(462, 167);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmProductUnit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Unit";
            this.Load += new System.EventHandler(this.FrmProductUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProductUnit_KeyDown);
            this.PanelHeader.ResumeLayout(false);
            this.PanelFooter.ResumeLayout(false);
            this.PanelContainer.ResumeLayout(false);
            this.PanelContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Panel PnlBorderHeaderBottom;
        private System.Windows.Forms.Panel PnlBorderFooterTop;
        private System.Windows.Forms.Button BtnLastData;
        private System.Windows.Forms.Button BtnPreviousData;
        private System.Windows.Forms.Button BtnNextData;
        private System.Windows.Forms.Button BtnFirstData;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearcAccountDesc;
        private MyInputControls.MyTextBox TxtShortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CbActive;
        private System.Windows.Forms.Button BtnExit;
        private MyInputControls.MyTextBox TxtDescription;
        private System.Windows.Forms.Panel PnlBorderHeaderTop;
        private System.Windows.Forms.Panel PnlBorderFooterBoootm;
    }
}