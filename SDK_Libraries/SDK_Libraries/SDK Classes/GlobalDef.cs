using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using SDK_Libraries.SDK_Classes;

namespace SDK_Libraries.SDK_Classes
{
    /*defined by m.taghadosi
     * 1- global values for more control on the GUIs 
     * 2- plays an Start-Up Sound
     * 3- Defines IDKey for PRIMARY key in the SQL and unique records in database
     * 4- function that inverts an string - for inverting usernames for using as key.
     * 5- Connection string is here!!!
     */

    public class GlobalDef
    {
        //makes ConnectionString - m.taghadosi;
        public static string _ConnectionString = string.Empty;
        public static byte _WhatToDo = 1; //control the sequence display for the login and Connectionstring_config
        public static bool _CancelWholeConfigOpration = false; //specify that the Cancel button, caceled all opration or not
        private static string _LastID = string.Empty; //last idkey that already used for PRIMARY KEY
        public static bool _AccessGuaranteed = false; //indicated that access guaranteed in the Login Form or not.
        public static bool _IsLogedIn = false; //indicated that a user curently loged in or not 
        public static int WhatTabInSettingFrom = 0; //indicates that when the seting form opens what TAB must shown as default TAB?
        /// <summary>
        /// Plays an StartUp Sound - m.taghadosi
        /// </summary>
        public static void PlaySound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"E:\Working Area\Working\Corporation Files\Parking Version2\Parking Version2\Resources\Startup.wav";
                player.Play();
            }
            catch (System.IO.FileNotFoundException e)
            {
                return;
            }
        }


        //this methode get the last used key and defines the next one,
        //key must be in form of xxxxxxxx0000 (last four chars must be nomeric)
        //m.taghadosi
        /// <summary>
        /// defines an id key for PRIMARY KEY use, or attempt IDs and more - m.taghadosi
        /// </summary>
        /// <returns></returns>
        public static string DefineKeyID()
        {
            string NomericPart = string.Empty;
            string _LastID = string.Empty;
            RegistryKey iKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Parking2", true);
            if (Securityy.RequestForConectionStringConfig())
                _LastID = iKey.GetValue("LastPrimaryKey", "0000").ToString();
            else
                _LastID = "0000";
            int a = int.Parse(_LastID) + 1;
            NomericPart = "PV2CMTL-" + a.ToString();
            iKey.SetValue("LastPrimaryKey", a);
            return NomericPart;
        }

        /// <summary>
        /// this methode Inverts the input string, used for TDE Algorithm Key - m.taghadosi
        /// </summary>
        /// <param name="_str"></param>
        /// <returns></returns>
        public static string InvertString(string _str)
        {
            UTF8Encoding utf = new UTF8Encoding();
            //string Inverted = string.Empty;
            byte[] data = utf.GetBytes(_str);
            byte[] converted = new byte[_str.Length];
            for (int i = data.Length; i > 0; i--)
            {
                converted[data.Length - i] = data[i - 1];
            }
            return utf.GetString(converted);
        }
    }
}
