using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike.Service
{
    public class UserService
    {
        public User createUser(string lastName, string firstName, string username, string password)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            SecurityService ss = new SecurityService();

            var hashedPassword = ss.hashAndSaltPassword(password);

            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                MemberSince = DateTime.Now,
                Security = new Security { Password = hashedPassword }
            };

            return dbconn.addUser(user);
        }

        public bool deleteUser(string username)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.deleteUser(username);
        }

        public User getUser(string username)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.getUser(username);
        }
    }
}
