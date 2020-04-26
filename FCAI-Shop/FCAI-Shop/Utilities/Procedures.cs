using System.Text;
using System.Text.RegularExpressions;

namespace FCAI_Shop.Utilities
{
    public class Procedures
    {
        public static bool isValidMail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var regex = new Regex(strRegex);

            return regex.IsMatch(email);
        }
        public static bool CompareHashedPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        public static string HashPassword(string password)
        {
            using var crypt = System.Security.Cryptography.SHA256.Create();
            byte[] raw = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] raw_hashed = crypt.ComputeHash(raw);
            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            foreach (byte b in raw_hashed)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}
