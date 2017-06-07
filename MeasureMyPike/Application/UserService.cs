using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike.Application
{
    public class UserService
    {
        public bool createUser(string lastName, string firstName, string username, string password)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            SecurityService ss = new SecurityService();

            var hashedPassword = ss.hashAndSaltPassword(password);

            Model.User user = new Model.User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                MemberSince = DateTime.Now,
                Security = new Model.Security { Password = hashedPassword }
            };

            return dbconn.addUser(user);
        }

        public bool deleteUser(string username)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.deleteUser(username);
        }

        public Model.User getUser(string username)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.getUser(username);
        }
    }
}
