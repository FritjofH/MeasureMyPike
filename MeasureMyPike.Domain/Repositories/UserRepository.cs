using System;
using System.Linq;
using MeasureMyPike.Domain.Models;
using System.Collections.Generic;

namespace MeasureMyPike.Repo
{
    public class UserRepository : IUserRepository
    {
        public UserDO AddUser(UserDO newUser)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var createdUser = conn.User.Add(newUser);
                    conn.Security.Attach(newUser.Security);
                    conn.Security.Add(newUser.Security);
                    conn.TackleBox.Attach(newUser.TackleBox);
                    conn.TackleBox.Add(newUser.TackleBox);

                    conn.SaveChanges();

                    return createdUser;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public UserDO GetUser(string username)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedUser = conn.User.
                        Include("TackleBox").Include("Security").
                        FirstOrDefault(it => it.Username == username);
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public UserDO GetUser(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedUser = conn.User.
                        Include("TackleBox").Include("Security").
                        FirstOrDefault(it => it.Id == id);
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public UserDO UpdateUser(string firstName, string lastName, string username)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var userToUpdate = conn.User.First(it => it.Username == username);
                    userToUpdate.FirstName = firstName;
                    userToUpdate.LastName = lastName;

                    conn.SaveChanges();

                    return userToUpdate;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public bool DeleteUser(UserDO userToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.User.Attach(userToDelete);
                    conn.Security.Attach(userToDelete.Security);
                    conn.Security.Remove(userToDelete.Security);

                    conn.TackleBox.Attach(userToDelete.TackleBox);
                    conn.TackleBox.Remove(userToDelete.TackleBox);

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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public string GetUserPasswordHash(string username)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var user = conn.User.
                        First(it => it.Username == username);
                    if (user != null)
                    {
                        return user.Security.Password;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public List<LureDO> GetTackleBoxForUser(string username)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var lures = conn.User
                        .First(it => it.Username == username)
                        .TackleBox.Lure.Where(it => it.Brand == it.Brand)
                        .OrderBy(it => it.Brand.Name)
                        .ToList();

                    return lures;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
    }
}