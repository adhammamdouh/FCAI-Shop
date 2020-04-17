using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI_Shop.Utilities
{
    public class Procedures
    {
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
