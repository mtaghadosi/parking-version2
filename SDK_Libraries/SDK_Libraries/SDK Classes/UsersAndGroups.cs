using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace SDK_Libraries.SDK_Classes
{
    /* This class is designed for Loging-in, creating users, deleting users, and more
     * everything and any function that have relationship with users must write here - By M.Taghadosi
     */
    public class UsersAndGroups
    {
        //indicated the username and ID of the current loged in user - m.taghadosi
        public static string _CurrentLogedInUserName = string.Empty;
        public static string _CurrentlogedInUserID = string.Empty;
        public static string _CurrentlogedInGroupID = string.Empty;
        public static string _CurrentlylogedInGroupName = string.Empty;
        public static string _LastLogedInUser = string.Empty;
        public static string _LastLogedInUserID = string.Empty;
        //====

        //a buffer for group names...
        public static string[] _gourpnames = new string[100];
        //a buffer for users...
        public static string[] _usernamse = new string[100];
        //a buffer for memberof ...
        public static string[] _memberof = new string[100];
        //
        public static string[] _getgroupusers = new string[100];
    }
}
