using DbSettings;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PasswordManagerLibrary
{
    public class DatabaseManager
    {
        private readonly string connectionString;
        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;

        }
        
        public string InsertUser(string email, string password,bool userNotExist)
        {
            


            var sql = "INSERT INTO users (usermail, Password) VALUES (@Email, @Password)";
            var ID=0;
            if (userNotExist==true)
            {
                


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
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = $"SELECT [id], [usermail], [password], [creation_date] FROM [PasswordManager].[dbo].[users] WHERE [usermail] = '{email}'";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetInt32(0);

                                Console.WriteLine($"credenziali create con ID: {id}");
                            }
                        }
                    }
                }
               


            }
            else
            {
                Console.WriteLine( "user exist ");
            }
            

            return "ID = "+ID +" ";
        }

    }
}

