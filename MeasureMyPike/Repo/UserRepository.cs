using System;
using System.Linq;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class UserRepository
    {
        public UserDO AddUser(UserDO newUser)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var createdUser = conn.User.Add(newUser);
                    conn.SaveChanges();

                    return createdUser;
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

        public UserDO GetUser(string username)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedUser = conn.User.FirstOrDefault(it => it.FirstName == username);
                    {
                        if (selectedUser != null)
                        {
                            return selectedUser;
                        }
                        else return null;
                    }
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

        public bool DeleteUser(UserDO userToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.User.Remove(userToDelete);
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

        public string GetUserPasswordHash(string username)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var passwordHash = conn.User.First(it => it.Username == username).Security.Password;

                    return passwordHash;
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

    }
}