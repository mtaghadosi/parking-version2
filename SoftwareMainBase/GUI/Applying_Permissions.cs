using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SDK_Libraries.SDK_Classes;

namespace SoftwareMainBase.GUI
{
    public partial class Applying_Permissions : Form
    {
        public Applying_Permissions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public void Applying_Permissions_Shown(object sender, EventArgs e)
        {
            string Group_Or_User = UsersAndGroups._CurrentlogedInUserID.Substring(6, 1);
            SqlConnection connection = new SqlConnection(DataBases.FillConnectionString());
            SqlDataAdapter query = new SqlDataAdapter();
            query.SelectCommand = new SqlCommand();
            query.SelectCommand.Connection = connection;
            if (Group_Or_User == "U")
                query.SelectCommand.CommandText = "select * from AccessLevels where userid='" + UsersAndGroups._CurrentlogedInUserID + "'";
            else if (Group_Or_User == "G")
                query.SelectCommand.CommandText = "select * from AccessLevels where groupid='" + UsersAndGroups._CurrentlogedInGroupID + "'";
            DataSet Buffered_Table = new DataSet();
            query.Fill(Buffered_Table, "AccessLevels");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = Buffered_Table;
            dataGridView1.DataMember = "AccessLevels";
            string Have_Access = string.Empty;
            for (int i = 1; i <= 2; i++)
            {
                Have_Access = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                if (Have_Access == "T")
                {
                    if (Group_Or_User == "U")
                    {
                        MainForm mn = new MainForm();
                        mn.Controls["txtCarInBarCode"].Enabled = false;
                    }
                    if (Group_Or_User == "G")
                    {
                        //indicates that the user is a member of this group or not - m.taghadosi
                        query.SelectCommand.CommandText = "select memberofid from Users where userid='" + UsersAndGroups._CurrentlogedInUserID + "'";
                        query.Fill(Buffered_Table, "group");
                        dataGridView1.DataMember = "group";
                        string GroupID = dataGridView1.Rows[0].Cells[0].Value.ToString().Trim();
                        if (GroupID == UsersAndGroups._CurrentlogedInGroupID)
                        {
                            //Allow Access
                        }
                        else
                        {
                            //Deny Access
                        }
                    }
                }
                if (Have_Access == "F")
                {
                    if (Group_Or_User == "U")
                    {
                        //query.SelectCommand.CommandText = "select * from AccessLevels where groupid='" + UsersAndGroups._CurrentlogedInGroupID + "' and functionid='" + FunctionID + "'";
                        query.Fill(Buffered_Table, "GN");
                        dataGridView1.DataMember = "GN";
                        string Have_Access1 = dataGridView1.Rows[0].Cells[3].Value.ToString().Trim();
                        if (Have_Access1 == "T")
                        {
                            //Allow Access
                        }
                        if (Have_Access1 == "F")
                        {
                            //Deny Access
                        }
                    }
                    if (Group_Or_User == "G")
                    {
                        //Deny Access
                    }
                }
            }
        }
    }
}