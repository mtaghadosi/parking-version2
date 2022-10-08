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
    public partial class UpdatingInformations : Form
    {
        bool IsSuccess = false;
        public UpdatingInformations()
        {
            InitializeComponent();
        }

        private void UpdatingInformations_Shown(object sender, EventArgs e)
        {
            GlobalDef._WhatToDo = 0;
            Securityy.DisableCloseBotton(this.Handle, false, 0xF060, 0x1);
            Application.DoEvents();
            try
            {
                SqlConnection connection = new SqlConnection(DataBases.FillConnectionString());
                SqlDataAdapter querry = new SqlDataAdapter();
                querry.SelectCommand = new SqlCommand();
                querry.SelectCommand.Connection = connection;
                querry.SelectCommand.CommandText = "select groupname from Groups";
                DataSet Buffer = new DataSet();
                querry.Fill(Buffer, "GroupTable");
                querry.SelectCommand.CommandText = "select username,memberof from Users";
                querry.Fill(Buffer, "UsersTable");
                ViewDataGroups.AutoGenerateColumns = true;
                ViewDataUsrs.AutoGenerateColumns = true;
                ViewDataGroups.DataSource = Buffer;
                ViewDataUsrs.DataSource = Buffer;
                ViewDataGroups.DataMember = "GroupTable";
                ViewDataUsrs.DataMember = "UsersTable";
                for (int i = 0; i < (ViewDataGroups.Rows.Count) - 1; i++)
                    UsersAndGroups._gourpnames[i] = ViewDataGroups.Rows[i].Cells[0].Value.ToString();
                for (int i = 0; i < (ViewDataUsrs.Rows.Count) - 1; i++)
                {
                    UsersAndGroups._usernamse[i] = ViewDataUsrs.Rows[i].Cells[0].Value.ToString();
                    UsersAndGroups._memberof[i] = ViewDataUsrs.Rows[i].Cells[1].Value.ToString();
                }
                IsSuccess = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error updating informations from DataBase, Please Check and Try Again\n" + err.Message, "Update Error");
            }
            if (IsSuccess)
            {
                GlobalDef._WhatToDo = 1;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}