﻿namespace acmedesktop.Common
{
    partial class UserLogin
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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtPassword = new acmedesktop.MyInputControls.MyTextBox();
			this.TxtUserName = new acmedesktop.MyInputControls.MyTextBox();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnLogin = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(41, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 15);
			this.label3.TabIndex = 11;
			this.label3.Text = "Password";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(41, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 9;
			this.label2.Text = "Email/Mobile No.";
			// 
			// TxtPassword
			// 
			this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtPassword.Location = new System.Drawing.Point(143, 77);
			this.TxtPassword.Name = "TxtPassword";
			this.TxtPassword.PasswordChar = '*';
			this.TxtPassword.Size = new System.Drawing.Size(190, 21);
			this.TxtPassword.TabIndex = 10;
			// 
			// TxtUserName
			// 
			this.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TxtUserName.Location = new System.Drawing.Point(143, 43);
			this.TxtUserName.Name = "TxtUserName";
			this.TxtUserName.Size = new System.Drawing.Size(190, 21);
			this.TxtUserName.TabIndex = 8;
			// 
			// BtnCancel
			// 
			this.BtnCancel.Location = new System.Drawing.Point(266, 106);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(67, 34);
			this.BtnCancel.TabIndex = 13;
			this.BtnCancel.Text = "&Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnLogin
			// 
			this.BtnLogin.Location = new System.Drawing.Point(195, 106);
			this.BtnLogin.Name = "BtnLogin";
			this.BtnLogin.Size = new System.Drawing.Size(67, 34);
			this.BtnLogin.TabIndex = 12;
			this.BtnLogin.Text = "&Login";
			this.BtnLogin.UseVisualStyleBackColor = true;
			this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
			// 
			// UserLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(196)))), ((int)(((byte)(197)))));
			this.ClientSize = new System.Drawing.Size(344, 157);
			this.ControlBox = false;
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnLogin);
			this.Controls.Add(this.TxtPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtUserName);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UserLogin";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "User Login";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserLogin_FormClosing);
			this.Load += new System.EventHandler(this.UserLogin_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserLogin_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MyInputControls.MyTextBox TxtPassword;
        private System.Windows.Forms.Label label3;
        private MyInputControls.MyTextBox TxtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnLogin;
    }
}