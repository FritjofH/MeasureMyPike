using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeasureMyPike
{
    public class DatabaseConnection
    {
        public User addUser(User user)
        {
            try {
                using (var conn = new ModelContainer())
                {
                    var u = conn.User.Add(user);
                    conn.SaveChanges();
                    return u;
                }
            }
            catch (Exception ex) {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
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

        public User getUser(string username)
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

        public Catch addCatch(Catch cc)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var c = conn.Catch.Add(cc);
                    conn.SaveChanges();
                    return c;
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
