using MeasureMyPike.Model;
using System;
using System.Linq;

namespace MeasureMyPike
{
    public class DatabaseConnection
    {
        public bool addUser(User user)
        {
            try {
                using (var conn = new ModelContainer())
                {
                    conn.Users.Add(user);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool deleteUser(string username)
        {
            using (var conn = new ModelContainer())
            {
                User user = getUser(username);
                if (user != null)
                {
                    conn.Users.Remove(user);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }


        public Model.Lures getLures(string lures)
        {
            using (var conn = new ModelContainer())
            {
                Model.Lures o = conn.Lures.FirstOrDefault(it => it.Name == lures);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public string addBrand(Model.Brand brand)
        {
            using (var conn = new ModelContainer()) 
            {
                User user = conn.Users.First(u => u.Username == username);
                return user;
            }
        }

        public string getUserPasswordHash(string username)
        {
            using (var conn = new ModelContainer())
            {
                return conn.Users.First(it => it.Username == username).Security.Password;
            }
        }

        public bool addLure(Lures lure)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Lures.Add(lure);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /*
        public bool deleteLure(string id)
        {
            using (var conn = new ModelContainer())
            {
                Lures lure = getLure(id);
                if (lure != null)
                {
                    conn.Lures.Remove(lure);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public Lure getLure(string id)
        {
            using (var conn = new ModelContainer()) 
            {
                Lures lure = conn.Lures.First(u => u.id == id);
                return lure;
            }
        }
        */

        //Tillfällig metod för att programmet ska bygga
        public string getFirstLure()
        {
            using (var conn = new ModelContainer())
            {
                var test = conn.Entry(conn.Lures.FirstOrDefault()).Reference(i => i.Brand).CurrentValue;

                return test.Name;
            }
        }

        public bool addBrand(Brand brand)
        {
            try {
                using (var conn = new ModelContainer())
                {
                    conn.Brand.Add(brand);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
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

            Model.Lures lure = getLures(lures);
            Model.Brand brnd= lure.Brand;

            using (var conn = new ModelContainer())
            {
                conn.Catch.Add(new Model.Catch {
                    User = conn.Users.First(),
                    Comment = new Model.Comment { Text = comment },
                    Media = mediaList,
                    Lures = new Model.Lures { Name = lures, Brand = brand},
                    //Lures = lure,
                    Fish = new Model.Fish { Length = fishLength, Weight = fishWeight },
                    Location = new Model.Location { Lake = lake, Coordinates = coordinates },
                    WeatherData = new Model.WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
                    Timestamp = DateTime.Now
                } );

                conn.SaveChanges();
                return "Skiten funkar";
        public Brand getBrand(Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                Brand o = conn.Brand.FirstOrDefault(it => it.Id == brand.Id);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }
        
        public bool addCatch(Catch cc)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Catch.Add(cc);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}
