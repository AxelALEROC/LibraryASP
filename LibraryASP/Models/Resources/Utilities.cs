using System.Security.Cryptography;
using System.Text;

namespace LibraryASP.Models.Resources
{
    public class Utilities
    {
        public static string EncryptPass(string pass)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())//SE UTILIZA UN HASH DE 256 BITS PARA ENCRIPTAR     
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(pass));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));//INDICA QUE LA CADENA DEBE FORMATEARSE EN FORMATO HEX
                }
            }
            return sb.ToString();
        }
    }
}
