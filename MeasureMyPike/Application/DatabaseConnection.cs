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
                Model.User user = getUser(username);
                if (user != null)
                {
                    conn.Users.Remove(user);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public Model.User getUser(string username)
        {
            using (var conn = new ModelContainer()) 
            {
                Model.User user = conn.Users.First(u => u.Username == username);
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

        public Lures getFirstLure()
        {
            using (var conn = new ModelContainer())
            {
                return conn.Lures.First();
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
