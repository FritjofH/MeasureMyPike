using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class UserRepository
    {

        public User AddUser(User user)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var u = conn.User.Add(user);
                    conn.SaveChanges();
                    return u;
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

        public bool DeleteUser(string username)
        {
            using (var conn = new ModelContainer())
            {
                User user = GetUser(username);
                if (user != null)
                {
                    conn.User.Remove(user);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public string GetUserPasswordHash(string username)
        {
            using (var conn = new ModelContainer())
            {
                return conn.User.First(it => it.Username == username).Security.Password;
            }
        }

        public User GetUser(string username)
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



    }
}