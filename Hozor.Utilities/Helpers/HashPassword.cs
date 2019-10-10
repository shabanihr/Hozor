using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hozor.Utilities.Helpers
{
    public static class HashPassword
    {
        public static string ToHashPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            return new string(new ASCIIEncoding().GetChars(md5data));
        }
    }
}
