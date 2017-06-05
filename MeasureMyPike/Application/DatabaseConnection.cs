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

                    conn.Users.Add(new Model.User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Username = username,
                        MemberSince = DateTime.Now,
                        Security = new Model.Security { Password = hashAndSaltPassword(password) }
                    });

                    conn.SaveChanges();
                    return "Användaren har skapats";
                }
            }
            return "Det finns redan en användare med det angivna användarnamnet, försök igen med ett annat användarnamn";
        }
        public string addLure(string lureName, Model.Brand brand) {
            using (var conn = new ModelContainer())
            {
                if (conn.Lures.FirstOrDefault(it => it.Name == lureName) == null)
                {

                    conn.Lures.Add(new Model.Lures
                    {
                        Name = lureName,
                        Brand = brand,
                        Catch = null
                });
                conn.SaveChanges();
                return "Lure har skapats";
            }
        }
            return "Det finns redan en Lure med det angivna Lurenamnet, försök igen med ett annat Lurenamn";

        }

        public string addBrand(Model.Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Brand.FirstOrDefault(it => it.Name == brand.Name) == null)
                {

                    conn.Brand.Add(new Model.Brand
                    {
                        Name = brand.Name

                    });
                    conn.SaveChanges();
                    return "Brand har skapats";
                }
            }
            return "Det finns redan en Brand med det angivna Brandnamnet, försök igen med ett annat Brandnamn";

        }

        public Model.Brand getBrand(Model.Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                Model.Brand o = conn.Brand.FirstOrDefault(it => it.Id == brand.Id);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
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

        public string createCatch(byte[] image, string format, string comment, string lures, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Model.Brand brand)
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
                    Lures = new Model.Lures { Name = lures, Brand = brand},
                    
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
