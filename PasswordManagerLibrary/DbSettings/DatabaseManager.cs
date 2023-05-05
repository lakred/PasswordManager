using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace PasswordManagerLibrary
{
    public class DatabaseManager
    {
        private readonly string connectionString;
        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;

        }



        //public DatabaseManager(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");
        //}


        public void InsertUser(string email, string password)
        {
            // Define the SQL statement to insert the new user
            var sql = "INSERT INTO users (usermail, Password) VALUES (@Email, @Password)";

            // Create a new SqlConnection object using the connection string
            using (var connection = new SqlConnection(connectionString))
            {
                // Open the connection to the database
                connection.Open();

                // Create a new SqlCommand object using the SQL statement and the SqlConnection object
                using (var command = new SqlCommand(sql, connection))
                {
                    // Add parameters to the SqlCommand object to set the values of the email and password fields
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    // Execute the SQL command to insert the new user into the Users table
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
