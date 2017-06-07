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

            return dbconn.createUser(lastName, firstName, username, hashedPassword);
        }

        public bool deleteUser(string username)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.deleteUser(username);
        }
    }
}
