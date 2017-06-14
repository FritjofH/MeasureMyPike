using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike.Service
{
    public class UserService
    {
        public User CreateUser(string lastName, string firstName, string username, string password)
        {
            UserRepository dbconn = new UserRepository();

            SecurityService ss = new SecurityService();

            var hashedPassword = ss.HashAndSaltPassword(password);

            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                MemberSince = DateTime.Now,
                Security = new Security { Password = hashedPassword }
            };

            return dbconn.AddUser(user);
        }

        public bool DeleteUser(string username)
        {
            UserRepository dbconn = new UserRepository();

            return dbconn.DeleteUser(username);
        }

        public User GetUser(string username)
        {
            UserRepository dbconn = new UserRepository();

            return dbconn.GetUser(username);
        }
    }
}
