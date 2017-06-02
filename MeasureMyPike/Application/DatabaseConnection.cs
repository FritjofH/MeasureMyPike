using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike
{
    public class DatabaseConnection
    {

        public string createUser(string lastName, string firstName, string username, string password)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Users.FirstOrDefault(it => it.Username == username) == null) {

                    conn.Users.Add(new Model.User { FirstName = firstName, LastName = lastName, Username = username, MemberSince = DateTime.Now, Security = new Model.Security { Password = hashAndSaltPassword(password) } } );
                                        
                    conn.SaveChanges();
                    return "Användaren har skapats";
                }
            }
            return "Det finns redan en användare med det angivna användarnamnet, försök igen med ett annat användarnamn";
        }

        private string hashAndSaltPassword(string password)
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

        public string login(string username, string password)
        {
            using (var conn = new ModelContainer())
            {
                /* Fetch the stored value */
                string savedPasswordHash = conn.Users.First(it => it.Username == username).Security.Password;
                /* Extract the bytes */
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        throw new UnauthorizedAccessException();
            }
            return "Rätt lösenord";
        }
    }
}
