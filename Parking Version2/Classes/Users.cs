using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

/* This class is designed for Loging-in, creating users, deleting users, and more
 * everything and any function that have relationship with users must write here - By M.Taghadosi
 */
namespace Parking_Version2.Classes
{
    class Users
    {
        //indicated the username and ID of the current loged in user - m.taghadosi
        public static string _CurrentLogedInUserName = string.Empty;
        public static string _CurrentlogedInUserID = string.Empty;
        //====

    }
}
