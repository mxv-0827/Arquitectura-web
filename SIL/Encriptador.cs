using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIL
{
    public class Encriptador
    {
        public static string EncriptarContraseña(string password, string userEmail) //Encripts the password.
        {
            string saltedPassword = String.Concat(password, GenerarSalt(userEmail));

            var sha256 = SHA256.Create();
            var sb = new StringBuilder();

            var stream = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            for (int i = 0; i < stream.Length; i++)
            {
                sb = sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }

        private static string GenerarSalt(string userEmail) //Establishes the structure of the encription using a user prop as reference => 'Email'.
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(userEmail);
            string saltString;
            long xored = 0x00;

            foreach (byte bite in saltBytes)
            {
                xored = xored ^ bite;
            }

            Random random = new Random(Convert.ToInt32(xored));

            saltString = random.Next().ToString();
            saltString += random.Next().ToString();
            saltString += random.Next().ToString();
            saltString += random.Next().ToString();

            return saltString;
        }
    }
}
