using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SDK_Libraries.SDK_Classes;

namespace SoftwareMainBase.GUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtCurrentUser.Text = UsersAndGroups._CurrentLogedInUserName.Trim();
            txtcurrentUserID.Text = UsersAndGroups._CurrentlogedInUserID.Trim();
            foreach(string a in UsersAndGroups._gourpnames)
            {
                if (a == null)
                    break;
                listbxGroups.Items.Add(a);
            }
            tabControl1.SelectedIndex = GlobalDef.WhatTabInSettingFrom;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl = new ToolTip();
            tl.IsBalloon = true;
            tl.UseAnimation = true;
            tl.UseFading = true;
            tl.SetToolTip(linkLabel1, "این شماره مشخصه یک شماره منحصربه فرد است که مخصوص پارکینگ شماست در صورت عدم اطلاع لطفا با مدیر سیستم تماس بگیرید");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl1 = new ToolTip();
            tl1.IsBalloon = true;
            tl1.UseAnimation = true;
            tl1.UseFading = true;
            tl1.SetToolTip(linkLabel2, "ظرفیت پارکینگ شما را مشخص می کند، به منظور استفاده بهینه از پارکینگ لطفا این فیلد را دقیق تکمیل فرمایید");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl2 = new ToolTip();
            tl2.IsBalloon = true;
            tl2.UseAnimation = true;
            tl2.UseFading = true;
            tl2.SetToolTip(linkLabel3, "هشدار ظرفیت، قابلیتی است که در صورت تجاوز ظرفیت پارکینگ از این مقدار به کاربر هشدار می دهد این مقدار باید از حداکثر ظزفیت پارکینگ کمتر باشد");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl3 = new ToolTip();
            tl3.IsBalloon = true;
            tl3.UseAnimation = true;
            tl3.UseFading = true;
            tl3.SetToolTip(linkLabel4, "با علامتدار کردن این گزینه در صورتی که تابلوی اعلام ظرفیت موجود باشد ظرفیت باقی مانده پارکینگ روی تابلو نمایش داده خواهد شد");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl3 = new ToolTip();
            tl3.IsBalloon = true;
            tl3.UseAnimation = true;
            tl3.UseFading = true;
            tl3.SetToolTip(linkLabel5, "نوع خودروهای ورودی به پارکینگ و تعرفه ی آنها را در این محل تنظیم نمایید برای این کار روی دکمه کلیک کنید");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            ToolTip tl4 = new ToolTip();
            tl4.IsBalloon = true;
            tl4.UseAnimation = true;
            tl4.UseFading = true;
            tl4.SetToolTip(linkLabel6, "برای نمایش لیست خودرو های مسروقه، اضافه یا حذف خودرویی از این لیست روی دکمه کلیک کنید");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl5 = new ToolTip();
            tl5.IsBalloon = true;
            tl5.UseAnimation = true;
            tl5.UseFading = true;
            tl5.SetToolTip(linkLabel7, "دراین قسمت شما می توانید علاوه بر مشاهده ی لیست کاربران و گروهها به اضافه کردن، حذف کردن و یا ایجاد تغییرات بپردازید");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tl6 = new ToolTip();
            tl6.IsBalloon = true;
            tl6.UseAnimation = true;
            tl6.UseFading = true;
            tl6.SetToolTip(linkLabel8, "کاربری را از لیست کاربران در سمت چپ انتخاب کنید، سپس در این قسمت دسترسی های این کاربر را مشخص نمایید");
        }

        private void listbxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Text = "کاربران این گروه:";
            int j=0;
            for (int i = 0; !(UsersAndGroups._memberof[i] == null); i++)
            {
                if (UsersAndGroups._memberof == null)
                    return;
                if (UsersAndGroups._memberof[i] == listbxGroups.SelectedItem.ToString())
                {
                    UsersAndGroups._getgroupusers[j] = i.ToString();
                    j++;
                }
            }
            listBxUsers.Items.Clear();
            foreach (string a in UsersAndGroups._getgroupusers)
            {
                if (a == null)
                    break;
                listBxUsers.Items.Add(UsersAndGroups._usernamse[int.Parse(a)]);
            }
            for (int i = 0; i < UsersAndGroups._getgroupusers.Length; i++)
                UsersAndGroups._getgroupusers[i] = null;
        }

        private void btnShowAllUsers_Click(object sender, EventArgs e)
        {
            label13.Text = "تمامی کاربران: ";
            listBxUsers.Items.Clear();
            foreach (string a in UsersAndGroups._usernamse)
            {
                if (a == null)
                    return;
                listBxUsers.Items.Add(a);
            }
        }

        private void btnShowAllUsers_MouseEnter(object sender, EventArgs e)
        {
            ToolTip tl = new ToolTip();
            tl.IsBalloon = true;
            tl.UseAnimation = true;
            tl.SetToolTip(btnShowAllUsers, "با فشردن این دکمه لیستی از تمامی کاربران سیستم گزارش خواهد شد");
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalDef.WhatTabInSettingFrom = 0;
        }
    }
}