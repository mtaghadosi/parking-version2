using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SoftwareMainBase.GUI;
using SDK_Libraries.SDK_Classes;

namespace SoftwareMainBase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuItemSettings_Click(object sender, EventArgs e)
        {
            UpdatingInformations update = new UpdatingInformations();
            update.ShowDialog(this);
            if (GlobalDef._WhatToDo == 1)
            {
                SettingsForm st = new SettingsForm();
                st.ShowDialog(this);
            }
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutfrm = new AboutBox1();
            aboutfrm.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Applying_Permissions frm = new Applying_Permissions();
            //frm.Show(this);
            if (!GlobalDef._IsLogedIn)
            {
                if (MessageBox.Show("Uknown UserID And UserName, It seems that you are not loged in! Please Login For Using Software. \nDo you want to Login?", "Security Erorr", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("Parking Version2");
                    this.Close();
                }
                else
                    this.Close();
            }
            toolStripStatuslblCurrentLogedInUser.Text = UsersAndGroups._CurrentLogedInUserName.Trim();
            toolStripStatuslblCurrentLogedInUserID.Text = UsersAndGroups._CurrentlogedInUserID.Trim();
            toolStripLastLogedInUser.Text = UsersAndGroups._LastLogedInUser.Trim();
            toolStriplastLogedInUserID.Text = UsersAndGroups._LastLogedInUserID.Trim();
        }

        private void MenuItemCalculator_Click(object sender, EventArgs e)
        {
            string address = System.Environment.GetFolderPath(Environment.SpecialFolder.System).ToString();
            System.Diagnostics.Process.Start(address+"\\calc.exe");
        }

        private void CameraSettingsMenuStrip_Click(object sender, EventArgs e)
        {
            GlobalDef.WhatTabInSettingFrom = 3;
            UpdatingInformations stngfrm = new UpdatingInformations();
            stngfrm.ShowDialog(this);
            SettingsForm stnfrmS = new SettingsForm();
            stnfrmS.ShowDialog(this);
        }
    }
}