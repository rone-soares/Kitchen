using System.Security.Cryptography;
using System.Text;

namespace Library.Service
{
    public static class CryptographyService
    {
        public static string GenetareHashMD5(string text)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(text);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder returnHash = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                returnHash.Append(hash[i].ToString("X2"));
            }

            return returnHash.ToString();
        }
    }
}
