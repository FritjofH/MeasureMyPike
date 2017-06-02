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

        public void createUser(string lastName, string firstName, string username, string password)
        {
            openConnection();

            cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO MeasureMyPike.dbo.Users (LastName, FirstName, Username, Password, MemberSince) Values (@LastName, @FirstName, @Username, @Password, @MemberSince)";

            var p = new SqlParameter("@LastName", SqlDbType.NVarChar, 50);
            p.Value = lastName;
            cmd.Parameters.Add(p);
            p = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50);
            p.Value = firstName;
            cmd.Parameters.Add(p);
            p = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
            p.Value = username;
            cmd.Parameters.Add(p);
            p = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            p.Value = password;
            cmd.Parameters.Add(p);
            p = new SqlParameter("@MemberSince", SqlDbType.DateTime, 50);
            p.Value = DateTime.Now;
            cmd.Parameters.Add(p);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            closeConnection();
        }
    }
}
