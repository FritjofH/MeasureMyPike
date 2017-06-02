using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike
{
    public class DatabaseConnection
    {

        public string createUser(string lastName, string firstName, string username, string password)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Users.FirstOrDefault(it => it.Username == username) == null) {
                    conn.Users.Add(new Model.Users { FirstName = firstName, LastName = lastName, Username = username, Password = password, MemberSince = DateTime.Now });
                    conn.SaveChanges();
                    return "Användaren har skapats";
                }
            }
            return "Det finns redan en användare med det angivna användarnamnet, försök igen med ett annat användarnamn";
        }
        
    }
}
