using System;
using System.Security.Cryptography;

namespace MeasureMyPike.Service
{
    public class SecurityService
    {
        public string hashAndSaltPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public bool login(string username, string password)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            byte[] hashBytes = Convert.FromBase64String(dbconn.getUserPasswordHash(username));

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    //throw new UnauthorizedAccessException();
                    return false;
            return true;
        }
    }
}
