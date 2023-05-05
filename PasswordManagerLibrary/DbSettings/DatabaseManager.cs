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
            var sql = "INSERT INTO users (usermail, Password) VALUES (@Email, @Password)";

            
            using (var connection = new SqlConnection(connectionString))
            {
               
                connection.Open();

                
                using (var command = new SqlCommand(sql, connection))
                {
                    
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
