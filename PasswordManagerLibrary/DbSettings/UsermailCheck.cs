using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSettings
{
    public class UsermailCheck
    {

        public UsermailCheck() { }

        public bool UserExist(string email)
        {
            
            
            bool userNotExist = true;
            var optionsBuilder = new DbContextOptionsBuilder<PasswordManagerContext>();
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=PasswordManager;Integrated Security=True;TrustServerCertificate=True;");
            using (var context = new PasswordManagerContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                var connection = context.Database.GetDbConnection();
                connection.Open();

                var query = $"SELECT TOP 1 [id] FROM [PasswordManager].[dbo].[users] WHERE [usermail] = '{email}'";
                using (var command = new SqlCommand(query, connection as SqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            userNotExist = id == null || id <= 0;

                        }
                    }
                }
            }

            if (userNotExist==true)
            {
                return true;
            }
            else
            {
                return false;
            }
            




        }
    }
    
}
