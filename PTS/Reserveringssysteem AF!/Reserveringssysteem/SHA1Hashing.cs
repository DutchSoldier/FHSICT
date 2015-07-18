using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Reserveringssysteem
{
    public static class SHA1Hashing
    {
        /// <summary>
        /// Maakt een SHA1 hash van een string.
        /// </summary>
        /// <param name="wachtwoord">De string die gehasht moet worden</param>
        /// <returns>Een SHA1 hash</returns>
        public static string MaakSHA1(string wachtwoord)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] inputbytes = Encoding.Default.GetBytes(wachtwoord.ToCharArray());
            byte[] outputbytes = sha1.ComputeHash(inputbytes);

            StringBuilder stringBuilder = new StringBuilder(40);
            for (int i = 0; i < outputbytes.Length; i++)
            {
                stringBuilder.Append(outputbytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
