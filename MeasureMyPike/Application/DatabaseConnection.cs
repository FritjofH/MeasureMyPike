using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace MeasureMyPike
{
    public class DatabaseConnection
    {

        public string createUser(string lastName, string firstName, string username, string password)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Users.FirstOrDefault(it => it.Username == username) == null) {

                    conn.Users.Add(new Model.User {
                        FirstName = firstName,
                        LastName = lastName,
                        Username = username,
                        MemberSince = DateTime.Now,
                        Security = new Model.Security { Password = hashAndSaltPassword(password) }
                    } );
                                        
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
                        return "Fel lösenord";
                        //throw new UnauthorizedAccessException();
            }
            return "Rätt lösenord";
        }

        public string createCatch(byte[] image, string format, string comment, string lures, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition)
        {
            List<Model.Media> mediaList = new List<Model.Media>();
            mediaList.Add(new Model.Media
            {
                MediaFormat = format,
                Image = new Model.MediaData
                {
                    Length = image.Length,
                    Data = image
                }
            });

            using (var conn = new ModelContainer())
            {
                conn.Catch.Add( new Model.Catch {
                    User = conn.Users.First(),
                    Comment = new Model.Comment { Text = comment },
                    Media = mediaList,
                    Lures = new Model.Lures { Name = lures },
                    Fish = new Model.Fish { Length = fishLength, Weight = fishWeight },
                    Location = new Model.Location { Lake = lake, Coordinates = coordinates },
                    WeatherData = new Model.WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
                    Timestamp = DateTime.Now
                } );

                conn.SaveChanges();
                return "Skiten funkar";
            }
        }
    }
}
