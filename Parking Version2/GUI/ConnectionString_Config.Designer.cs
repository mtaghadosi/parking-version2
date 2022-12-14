//using Parking_Version2.Classes;
namespace Parking_Version2.GUI
{
    partial class ConnectionString_Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionString_Config));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.Lusername = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Lpassword = new System.Windows.Forms.Label();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.Ldatabase = new System.Windows.Forms.Label();
            this.lserver = new System.Windows.Forms.Label();
            this.txtServername = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Complete the SQL-Server Configuration, if you don\'t understand this, \r\nPle" +
                "ase Contact Your Software Provider:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone2:+98511";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone1:+98511";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(70, 105);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(30, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "If you want to Contact your software provider by E-Mail:\r\nPlease Click:";
            // 
            // Lusername
            // 
            this.Lusername.AutoSize = true;
            this.Lusername.Location = new System.Drawing.Point(230, 22);
            this.Lusername.Name = "Lusername";
            this.Lusername.Size = new System.Drawing.Size(60, 13);
            this.Lusername.TabIndex = 3;
            this.Lusername.Text = "UserName:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.Lusername);
            this.groupBox2.Controls.Add(this.Lpassword);
            this.groupBox2.Controls.Add(this.txtUname);
            this.groupBox2.Controls.Add(this.txtDataBaseName);
            this.groupBox2.Controls.Add(this.Ldatabase);
            this.groupBox2.Controls.Add(this.lserver);
            this.groupBox2.Controls.Add(this.txtServername);
            this.groupBox2.Location = new System.Drawing.Point(6, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 163);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL Configuration:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(9, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(271, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.Location = new System.Drawing.Point(233, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(113, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Password";
            this.txtPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPassword_MouseClick);
            // 
            // Lpassword
            // 
            this.Lpassword.AutoSize = true;
            this.Lpassword.Location = new System.Drawing.Point(230, 76);
            this.Lpassword.Name = "Lpassword";
            this.Lpassword.Size = new System.Drawing.Size(56, 13);
            this.Lpassword.TabIndex = 5;
            this.Lpassword.Text = "Password:";
            // 
            // txtUname
            // 
            this.txtUname.BackColor = System.Drawing.SystemColors.Info;
            this.txtUname.Location = new System.Drawing.Point(233, 38);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(113, 20);
            this.txtUname.TabIndex = 2;
            this.txtUname.Text = "UserName Here...";
            this.txtUname.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUname_MouseClick);
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.BackColor = System.Drawing.SystemColors.Info;
            this.txtDataBaseName.Location = new System.Drawing.Point(9, 92);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(113, 20);
            this.txtDataBaseName.TabIndex = 1;
            this.txtDataBaseName.Text = "Parking2";
            // 
            // Ldatabase
            // 
            this.Ldatabase.AutoSize = true;
            this.Ldatabase.Location = new System.Drawing.Point(6, 76);
            this.Ldatabase.Name = "Ldatabase";
            this.Ldatabase.Size = new System.Drawing.Size(57, 13);
            this.Ldatabase.TabIndex = 2;
            this.Ldatabase.Text = "DataBase:";
            // 
            // lserver
            // 
            this.lserver.AutoSize = true;
            this.lserver.Location = new System.Drawing.Point(6, 22);
            this.lserver.Name = "lserver";
            this.lserver.Size = new System.Drawing.Size(41, 13);
            this.lserver.TabIndex = 1;
            this.lserver.Text = "Server:";
            // 
            // txtServername
            // 
            this.txtServername.AutoCompleteCustomSource.AddRange(new string[] {
            "(local)",
            "(localhost)",
            "127.0.0.1"});
            this.txtServername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtServername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtServername.BackColor = System.Drawing.SystemColors.Info;
            this.txtServername.Location = new System.Drawing.Point(9, 38);
            this.txtServername.Name = "txtServername";
            this.txtServername.Size = new System.Drawing.Size(113, 20);
            this.txtServername.TabIndex = 0;
            this.txtServername.Text = "ServerName Here...";
            this.txtServername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtServername_MouseClick);
            // 
            // ConnectionString_Config
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 311);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionString_Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Configuration";
            this.Load += new System.EventHandler(this.ConnectionString_Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Lusername;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.Label Ldatabase;
        private System.Windows.Forms.Label lserver;
        private System.Windows.Forms.TextBox txtServername;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Label Lpassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}