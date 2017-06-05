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

            return dbconn.createUser(lastName, firstName, username, ss.hashAndSaltPassword(password));
        }
    }
}
