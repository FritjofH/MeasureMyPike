using MeasureMyPike.Models;
using System;
using System.Collections.Generic;
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
                    conn.User.Add(user);
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
                    conn.User.Remove(user);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        private User getUser(string username)
        {
            using (var conn = new ModelContainer())
            {
                Models.User o = conn.User.FirstOrDefault(it => it.FirstName == username);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public Models.Lures getLure(string lure)
        {
            using (var conn = new ModelContainer())
            {
                Models.Lures o = conn.Lures.FirstOrDefault(it => it.Name == lure);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public Models.Lures getLure(int id)
        {
            using (var conn = new ModelContainer())
            {
                Models.Lures o = conn.Lures.FirstOrDefault(it => it.Id == id);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public bool updateLure(int id, string lureName)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    Models.Lures o = conn.Lures.FirstOrDefault(it => it.Id == id);
                    {
                        o.Name = lureName;
                        conn.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    return false;
                    
                }
                
            }
        }



        public Brand getBrand(string name)
        {
            using (var conn = new ModelContainer())
            {
                Brand brand = conn.Brand.First(u => u.Name == name);
                return brand;
            }
        }

        public string getUserPasswordHash(string username)
        {
            using (var conn = new ModelContainer())
            {
                return conn.User.First(it => it.Username == username).Security.Password;
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

        public List<Brand> getAllBrands()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var value = conn.Brand.ToList();
                    return value;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string createCatch(byte[] image, string format, string comment, string lures, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition)
        {
            List<Models.Media> mediaList = new List<Models.Media>();
            mediaList.Add(new Models.Media
            {
                MediaFormat = format,
                Image = new Models.MediaData
                {
                    Length = image.Length,
                    Data = image
                }
            });

            Models.Lures lure = getLure(lures);
            Models.Brand brnd = lure.Brand;

            using (var conn = new ModelContainer())
            {
                conn.Catch.Add(new Models.Catch
                {
                    User = conn.User.First(),
                    Comment = new Models.Comment { Text = comment },
                    Media = mediaList,
                    Lures = new Models.Lures { Name = lures, Brand = brnd },
                    //Lures = lure,
                    Fish = new Models.Fish { Length = fishLength, Weight = fishWeight },
                    Location = new Models.Location { Lake = lake, Coordinates = coordinates },
                    WeatherData = new Models.WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
                    Timestamp = DateTime.Now
                });

                conn.SaveChanges();
                return "Skiten funkar";
            }
        }
        public Brand getBrand(Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                Brand o = conn.Brand.FirstOrDefault(it => it.Name == brand.Name);
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
