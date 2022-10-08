using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace SDK_Libraries.SDK_Classes
{
    /*
     * 
     * Created by M.Taghadosi
     * 
     */

    public class Securityy
    {

        /// <summary>
        /// this methode checks for connectionstring in the registry
        /// if the specific registrykey found it means that config has been
        /// setted completly and returns true else false 
        /// </summary>
        /// <returns></returns>
        public static bool RequestForConectionStringConfig()
        {
            if (Registry.LocalMachine.OpenSubKey(@"Software\Parking2", true) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// if the program understands that the connectionstring not configured yet
        /// by this methode you can configure the connectionstring- m.taghadosi
        /// </summary>
        /// <param name="_value"></param>
        public static void WriteRegistryConfig_ForConnctionString(string _value)
        {
            string Coded = EncryptAndDecrypt(_value, "encrypt", "a");
            string _name = "SQLConnectionString";
            RegistryKey ADD_ConfigKey = Registry.LocalMachine.CreateSubKey(@"Software\Parking2", RegistryKeyPermissionCheck.ReadWriteSubTree);
            ADD_ConfigKey.SetValue(_name, Coded);
        }

        /// <summary>
        /// this methode is for Encoding and Decoding connectionstring for more Security
        /// have 3 input "first input must be encrypted or decrypted connectionstring"
        /// and 2nd must be "encrypt" for Encrypting and "decrypt" for Decrypting.
        /// this encrypting algorithm works on TDES powerfull string coding algorithem
        /// the 3nd input, is an input key for this algorithm (created by m.taghadosi)
        /// </summary>
        /// <param name="_orginal"></param>
        /// <param name="_str"></param>
        /// <returns></returns>
        public static string EncryptAndDecrypt(string _original, string _str, string _TDESAlgorithem)
        {
            _str = _str.ToLower();
            if (_str == "encrypt")
            {
                byte[] _results;
                UTF8Encoding utf8 = new UTF8Encoding();
                MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
                byte[] TDESKey = md.ComputeHash(utf8.GetBytes(_TDESAlgorithem)); //algorithem's key, m.taghadosi
                byte[] _data = utf8.GetBytes(_original); //algorithem's input array, m.taghadosi

                TripleDESCryptoServiceProvider TDESAlgorithem = new TripleDESCryptoServiceProvider();
                TDESAlgorithem.Key = TDESKey;
                TDESAlgorithem.Mode = CipherMode.ECB;
                TDESAlgorithem.Padding = PaddingMode.PKCS7;

                try
                {
                    ICryptoTransform encryptor = TDESAlgorithem.CreateEncryptor();
                    _results = encryptor.TransformFinalBlock(_data, 0, _data.Length);
                }
                finally
                {
                    TDESAlgorithem.Clear();
                    md.Clear();
                }
                return Convert.ToBase64String(_results);
            }
            if (_str == "decrypt")
            {
                byte[] _result;
                UTF8Encoding utf8 = new UTF8Encoding();
                MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
                byte[] TDESKey = md.ComputeHash(utf8.GetBytes(_TDESAlgorithem)); //algorithem's key, m.taghadosi
                byte[] _data = Convert.FromBase64String(_original);

                TripleDESCryptoServiceProvider decryptor = new TripleDESCryptoServiceProvider();
                decryptor.Key = TDESKey;
                decryptor.Mode = CipherMode.ECB;
                decryptor.Padding = PaddingMode.PKCS7;

                try
                {
                    ICryptoTransform transform = decryptor.CreateDecryptor();
                    _result = transform.TransformFinalBlock(_data, 0, _data.Length);
                }
                finally
                {
                    decryptor.Clear();
                    md.Clear();
                }
                return utf8.GetString(_result);
            }
            return "Error On Decode or Encoding!";
        }

        /// <summary>
        /// creates an access tooke for user login process returns true if success
        /// </summary>
        /// <param name="_password"></param>
        /// <param name="_UserName"></param>
        /// <returns></returns>
        public static bool AccessTooken(string _password, string _UserName)
        {
            SqlConnection connection = new SqlConnection(DataBases.FillConnectionString());
            SqlDataAdapter TookenQuerry = new SqlDataAdapter();
            TookenQuerry.SelectCommand = new SqlCommand();
            TookenQuerry.SelectCommand.Connection = connection;
            TookenQuerry.SelectCommand.CommandText = "select * from Users";
            DataSet DataTables = new DataSet();
            TookenQuerry.Fill(DataTables, "users");  //Gets Data From Data-Base and puts them to the table named users...
            DataView view = new DataView(DataTables.Tables["users"]);
            view.Sort = "username, password";
            object[] obj = new object[2];
            obj[0] = _UserName; obj[1] = _password;
            int UFound = 0;
            UFound = view.Find(obj);  //try to find UserName...
            if (UFound == -1)
                return false;
            else
                return true;
            return false;
        }
        //this codes disables the form's close bottons created by M.Taghadosi...
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);
        /// <summary>
        /// this methode disables the form's close botton
        /// </summary>
        /// <param name="a">please write this.Handle</param>
        /// <param name="b">Please Write False</param>
        /// <param name="SC_CLOSE">Please Write 0xF060</param>
        /// <param name="MF_GRAYED">Please Write 0x1</param>
        public static void DisableCloseBotton(IntPtr a,bool b,int SC_CLOSE, int MF_GRAYED)
        {
            EnableMenuItem(GetSystemMenu(a, b), SC_CLOSE, MF_GRAYED);
        }
    }
}
