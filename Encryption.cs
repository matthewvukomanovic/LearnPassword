using System;
using System.Security.Cryptography;
using System.Text;

namespace Learn_Password
{
	public class Hashing
	{
        private static string InternalGetHashSha256(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var hashstring = new SHA256Managed();
            var hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += x.ToString("x2");
            }
            return hashString;
        }

        public static string GetHashSha256(string input)
		{
            if (string.IsNullOrEmpty(input))
			{
                return string.Empty;
			}
		    return InternalGetHashSha256(input);
		}
	}
}
