using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public string getUserPasswordHash(string username)
        {
            using (var conn = new ModelContainer())
            {
                return conn.User.First(it => it.Username == username).Security.Password;
            }
        }

        private User getUser(string username)
        {
            using (var conn = new ModelContainer())
            {
                User o = conn.User.FirstOrDefault(it => it.FirstName == username);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public Lures getLure(int id)
        {
            using (var conn = new ModelContainer())
            {
                Lures o = conn.Lures.FirstOrDefault(it => it.Id == id);
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
                    Lures o = conn.Lures.FirstOrDefault(it => it.Id == id);
                    o.Name = lureName;
                    conn.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool addBrand(Brand brand)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Brand.Add(brand);
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

        public List<Models.Application.Brand> getAllBrands()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brands = conn.Brand.ToList();

                    var brandList = new List<Models.Application.Brand>();

                    foreach (var brand in brands)
                    {
                        brandList.Add(new Models.Application.Brand { Id = brand.Id, Name = brand.Name });
                    }

                    return brandList;
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

        public Brand getBrand(int id)
        {
            using (var conn = new ModelContainer())
            {
                Brand brand = conn.Brand.First(u => u.Id == id);
                return brand;
            }
        }        

        public bool updateBrand(int id, string name)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    Brand b = conn.Brand.FirstOrDefault(it => it.Id == id);
                    b.Name = name;
                    conn.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    return false;
                }
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
        public List<Catch> getAllCatch()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var value = conn.Catch.ToList();
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

        public Catch getCatch(int id)
        {
            using (var conn = new ModelContainer())
            {
                Catch cc = conn.Catch.FirstOrDefault(it => it.Id == id);
                {
                    if (cc != null)
                    {
                        return cc;
                    }
                    else return null;
                }
            }
        }

        public bool updateCatch(int id, Catch cc)
        {
            try
            {
                if (!deleteCatch(id))
                {
                    // specified id was probably not found
                    return false;
                }
                using (var conn = new ModelContainer())
                {
                    // add new with same id
                    cc.Id = id;
                    conn.Catch.Add(cc);
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

        public bool deleteCatch(int id)
        {
            using (var conn = new ModelContainer())
            {
                Catch c = getCatch(id);
                if (c != null)
                {
                    conn.Catch.Remove(c);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
