using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SDK_Libraries.SDK_Classes;

namespace Parking_Version2.GUI
{
    public partial class ConnectingGUI : Form
    {
        public ConnectingGUI()
        {
            InitializeComponent();
        }
        private void ConnectingGUI_Shown(object sender, EventArgs e)
        {
            Securityy.DisableCloseBotton(this.Handle, false, 0xF060, 0x1);
            Application.DoEvents(); 
            Securityy.WriteRegistryConfig_ForConnctionString(GlobalDef._ConnectionString);
            if (DataBases.CanConnect())
            {
                GlobalDef._WhatToDo = 1;
                this.Close();
            }
            else
            {
                GlobalDef._WhatToDo = 0;
                this.Close();
            }
        }
    }
}