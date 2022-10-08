using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

//created by m.taghadosi
namespace SDK_Libraries.SDK_Classes
{
    public class DataBases
    {
        public static string _str = string.Empty;
        //connectionString Difination for testing connectivity 
        //defined in the overload methode;
        public static string FillConnectionString()
        {
            string _NotExist = "uJEH8TfNZAuktubyv2xVF9vFV8oGCtZLOVZd7nPvWf4my8YQNTwgDB3h1kG7KDsQ7a02Hkb0N5s=";
            RegistryKey iKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Parking2", true);
            _str = iKey.GetValue("SQLConnectionString", _NotExist).ToString();
            _str = Securityy.EncryptAndDecrypt(_str, "decrypt", "a");
            return _str;
        }

        /// <summary>
        /// connectionString Difination and testing connectivity 
        /// to DataBase Returns true in success
        /// </summary>
        /// <returns></returns>
        public static bool CanConnect()
        {
            SqlConnection DataBaseTestig = new SqlConnection(FillConnectionString());
            SqlCommand command = new SqlCommand();
            command.Connection = DataBaseTestig;
            command.CommandText = "select * from dbo.Testing where lname='taghadosi'";
            try
            {

                DataBaseTestig.Open();
                command.ExecuteNonQuery();
                DataBaseTestig.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }
        public static void WriteLoginAttempts(String _querry)
        {
            SqlConnection connection = new SqlConnection(FillConnectionString());
            SqlCommand querry = new SqlCommand();
            querry.Connection = connection;
            querry.CommandText = _querry;

            connection.Open();
            querry.ExecuteNonQuery();
            connection.Close();
        }
    }
}
