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
        private SqlConnection conn;
        SqlCommand cmd;

        private void openConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["localHost"].ConnectionString;
            conn = new SqlConnection(connectionString);
            if (conn != null && conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void closeConnection()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public string createUser(string lastName, string firstName, string username, string password)
        {
            openConnection();

            cmd = new SqlCommand();
            cmd.CommandText = "SELECT count(*) FROM MeasureMyPike.dbo.Users where Username = @Username";

            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Prepare();
            var result = (int) cmd.ExecuteScalar();

            if (result == 0) {
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO MeasureMyPike.dbo.Users (LastName, FirstName, Username, Password, MemberSince) Values (@LastName, @FirstName, @Username, @Password, @MemberSince)";

                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;
                cmd.Parameters.Add("@MemberSince", SqlDbType.DateTime, 50).Value = DateTime.Now;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                closeConnection();

                return "Användaren har skapats";
            }
            else
            {
                closeConnection();
                return "Det fanns redan en användare med samma namn, var god använd ett annat";
            }
        }
    }
}
