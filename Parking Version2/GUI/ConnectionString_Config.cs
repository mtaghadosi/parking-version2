using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Parking_Version2.GUI;
using SDK_Libraries.SDK_Classes;

namespace Parking_Version2.GUI
{
    public partial class ConnectionString_Config : Form
    {
        public ConnectionString_Config()
        {
            InitializeComponent();
        }

        private void txtServername_MouseClick(object sender, MouseEventArgs e)
        {
            txtServername.Text = string.Empty;
        }

        private void txtUname_MouseClick(object sender, MouseEventArgs e)
        {
            txtUname.Text = string.Empty;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalDef._CancelWholeConfigOpration = true;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Application.DoEvents();
            GlobalDef._ConnectionString = string.Empty;
            GlobalDef._ConnectionString += "Server=" + txtServername.Text;
            GlobalDef._ConnectionString += ";DataBase=" + txtDataBaseName.Text;
            GlobalDef._ConnectionString += ";User ID=" + txtUname.Text;
            GlobalDef._ConnectionString += ";Password=" + txtPassword.Text + ";";
            this.Enabled = false;
            ConnectingGUI conecting = new ConnectingGUI();
            conecting.ShowDialog(this);
            if (GlobalDef._WhatToDo == 1)
            {
                this.Close();
                MessageBox.Show("DataBase Testing was successful, Successfully Conected to SQL-Server\n" + "Now you can Login", "Access Guaranteed");
            }
            else
            {
                this.Enabled = true;
                MessageBox.Show("Can not connect to SQL-Server Please Check the Configurations \n" +
                    "or Contact your Software Developer", "Error Connection to DataBase");
            }
        }

        private void ConnectionString_Config_Load(object sender, EventArgs e)
        {
            ToolTip tl = new ToolTip();
            tl.IsBalloon = true;
            tl.SetToolTip(btnOK, "Confim Configurations");
            //disabling close botton
            Securityy.DisableCloseBotton(this.Handle, false, 0xF060, 0x1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto: mohammad.taghadosi@gmail.com?cc=&subject=Parkingver2 Problems &body=Hi,Please...");
        }
    }
}