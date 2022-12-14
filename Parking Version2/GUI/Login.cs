using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Parking_Version2.GUI;
using SoftwareMainBase;
using SDK_Libraries.SDK_Classes;

namespace Parking_Version2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("In the start program will connect to database for Connection testing do you Submit ?", "DataBase Testin", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.No)
                this.Close();

            int _IsRunning = 0;
            System.Diagnostics.Process[] Running_Processes = System.Diagnostics.Process.GetProcesses();
            for (int i = 0; i < Running_Processes.Length; i++)
            {
                if (Running_Processes[i].ProcessName == "Parking Version2")
                {
                    _IsRunning++;
                }
            }
            if (_IsRunning > 1)
                this.Close();
            bool sw = Securityy.RequestForConectionStringConfig(); //checks SQL Configurations in the registry - m.taghadosi
            if (sw == false)
            {
                GlobalDef._WhatToDo = 0;
                ConnectionString_Config box = new ConnectionString_Config();
                box.ShowDialog();
            }
            if (GlobalDef._WhatToDo==0) //indicates that the configuration didn't set - m.taghadosi
                this.Close();
            if (!GlobalDef._CancelWholeConfigOpration) //indicates that the opration canceled or not...
            {
                GlobalDef._ConnectionString = DataBases.FillConnectionString();
                ConnectingGUI CGUI = new ConnectingGUI();
                CGUI.ShowDialog();
                if (GlobalDef._WhatToDo==0)
                {
                    MessageBox.Show("Cannot Connect to DataBase Please check the SQL Config Again or your SQL-Server.\n" + 
                    "if you see this again Please contact your Software Provider.", "Error Connectiong to DataBase");
                    ConnectionString_Config box = new ConnectionString_Config();
                    box.ShowDialog();
                    if (GlobalDef._CancelWholeConfigOpration)
                    {
                        this.Close();
                        return;
                    }
                }
            }
            if (GlobalDef._CancelWholeConfigOpration) //indicates that the opration canceled and the database connection shouldn't check - m.taghadosi
            {
                this.Close();
                return;
            }
            ToolTip tooltip1 = new ToolTip();
            tooltip1.IsBalloon = false;
            tooltip1.SetToolTip(btnLogin, "Login");
            ToolTip tl = new ToolTip();
            tl.IsBalloon = true;
            tl.SetToolTip(txtUsrName, "نام کاربری خود را در این محل بنویسید");
            ToolTip tl2 = new ToolTip();
            tl2.IsBalloon = true;
            tl2.SetToolTip(txtPassword, "کلمه ی عبور خود را در این محل بنویسید");
            ToolTip tlhelp = new ToolTip();
            tlhelp.IsBalloon = true;
            tlhelp.SetToolTip(this, "درصورتی که نام و کلمه عبور خود را نمی دانید لطفا با مدیر خود تماس حاصل فرماید");

            GlobalDef.PlaySound();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = txtUsrName.Text.ToLower();
            string Password = Securityy.EncryptAndDecrypt(txtPassword.Text, "encrypt", GlobalDef.InvertString(uname));           
            DateTime daytime;
            daytime = DateTime.Now;
            string AttemptID = GlobalDef.DefineKeyID();
            string succ = string.Empty;
            if (Securityy.AccessTooken(Password, uname))
            {
                GlobalDef._IsLogedIn = true;
                succ = "T";
                GlobalDef._AccessGuaranteed = true;
                UsersAndGroups._CurrentLogedInUserName = uname;
                //===Get current GroupName And GroupID
                SqlConnection connection1 = new SqlConnection(DataBases.FillConnectionString());
                SqlDataAdapter queryyy = new SqlDataAdapter();
                queryyy.SelectCommand = new SqlCommand();
                queryyy.SelectCommand.CommandType = CommandType.Text;
                queryyy.SelectCommand.CommandText = "select memberof from Users where username='" + uname.Trim() + "'";
                queryyy.SelectCommand.Connection = connection1;
                DataSet buffer = new DataSet("GetGroupNameAndID");
                queryyy.Fill(buffer, "Gname");
                GroupData.AutoGenerateColumns = true;
                GroupData.DataSource = buffer;
                GroupData.DataMember = "Gname";
                UsersAndGroups._CurrentlylogedInGroupName = GroupData.Rows[0].Cells[0].Value.ToString().Trim();
                queryyy.SelectCommand.CommandText = "select memberofid from Users where username='" + uname.Trim() + "'";
                queryyy.Fill(buffer, "GID");
                GroupData.DataSource = buffer;
                GroupData.DataMember = "GID";
                UsersAndGroups._CurrentlogedInGroupID = GroupData.Rows[0].Cells[0].Value.ToString().Trim();
                //===
                SqlConnection connection = new SqlConnection(DataBases.FillConnectionString());
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = "select userid from Users where username='" + uname + "'";
                DataSet buffertables = new DataSet();
                adapter.Fill(buffertables, "usrID");
                viewdata.AutoGenerateColumns = true;
                viewdata.DataSource = buffertables;
                viewdata.DataMember = "usrID";
                UsersAndGroups._CurrentlogedInUserID = viewdata.Rows[0].Cells[0].Value.ToString();
                adapter.SelectCommand.CommandText = "select lastuser,lastuserid from LastUserID";
                adapter.Fill(buffertables, "LastUser");
                viewdata1.AutoGenerateColumns = true;
                viewdata1.DataSource = buffertables;
                viewdata1.DataMember = "LastUser";
                int Last_Row = viewdata1.Rows.Count;
                UsersAndGroups._LastLogedInUser = viewdata1.Rows[Last_Row-2].Cells[0].Value.ToString();
                UsersAndGroups._LastLogedInUserID = viewdata1.Rows[Last_Row-2].Cells[1].Value.ToString();
                MessageBox.Show("Login Seccessful...", "Access Guaranteed");
                
                //writes Login Attempt...
                string querry = "insert into LoginAttempts " +
                "(attemptid,username,password,year,month,day,hour,minute,second,successful) " +
                "values('" + AttemptID + "','" + uname + "','" + Password + "','" + daytime.Year.ToString() +
                "','" + daytime.Month.ToString() + "','" + daytime.Day.ToString() +
                "','" + daytime.Hour.ToString() + "','" + daytime.Minute.ToString() +
                "','" + daytime.Second.ToString() + "','" + succ + "')";
                DataBases.WriteLoginAttempts(querry);
                //write last loged in user for next user
                querry = "insert into LastUserID (lastuser,lastuserid) values ('"+UsersAndGroups._CurrentLogedInUserName+"','"+UsersAndGroups._CurrentlogedInUserID+"')";
                SqlCommand q = new SqlCommand();
                q.CommandText = querry;
                q.Connection = connection;
                connection.Open();
                q.ExecuteNonQuery();
                connection.Close();
                
            }
            else
            {
                succ = "F";
                MessageBox.Show("Invalid Username: "+uname+" And/Or it's Password. "+
                    "Please type your Username and password Carefully", "Login Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtPassword.Focus();
                txtPassword.SelectAll();
                
                //writes Login Attempt...
                string querry = "insert into LoginAttempts " +
                "(attemptid,username,password,year,month,day,hour,minute,second,successful) " +
                "values('" + AttemptID + "','" + uname + "','" + Password + "','" + daytime.Year.ToString() +
                "','" + daytime.Month.ToString() + "','" + daytime.Day.ToString() +
                "','" + daytime.Hour.ToString() + "','" + daytime.Minute.ToString() +
                "','" + daytime.Second.ToString() + "','" + succ + "')";
                DataBases.WriteLoginAttempts(querry);
                return;
            }
            this.Visible = false;
            MainForm mainfrm = new MainForm();
            mainfrm.Show(this);
            mainfrm.FormClosed += new FormClosedEventHandler(mainfrm_FormClosed);
        }

        void mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Visible = true;
                txtPassword.Text = string.Empty;
                txtUsrName.Focus();
                txtUsrName.SelectAll();
                throw new Exception("The method or operation is not implemented.");
            }
            catch
            {
                //Do Nothig!!!
            }
        }
    }
}