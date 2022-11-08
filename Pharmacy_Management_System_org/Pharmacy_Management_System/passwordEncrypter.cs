using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pharmacy_Management_System
{
    class passwordEncrypter
    {
        public static string Encrypt(string password)
        {
            char[] pass = password.ToCharArray();
            string[] symb = { "@", "#", "$", "%", "&" };
            Random rnd = new Random();
            string newpass = "";

            for (int i = pass.Length - 1; i >= 0; i--)
            {
                newpass += ((int)pass[i]).ToString() + symb[rnd.Next(0, 5)];
            }
            return newpass;
        }

        public static string Decrypt(string password)
        {
            string[] tokens = password.Split('@', '#', '$', '%', '&');
            string pass = "";

            for (int i = tokens.Length - 2; i >= 0; i--)
            {
                pass += ((char)Convert.ToInt32(tokens[i])).ToString();
            }
            return pass;
        }
    }
}
