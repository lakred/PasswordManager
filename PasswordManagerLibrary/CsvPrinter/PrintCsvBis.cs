using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPrinter
{
    public class PrintCsvBis
    {
        private readonly string connectionString;

        public PrintCsvBis(string connectionString)
        {
            this.connectionString = connectionString;

        }

        public void PrintFileCsv(string email, string password)
        {

            string ricevuta;
            string namefile;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query1 = $"SELECT [id], [usermail], [password], [creation_date] FROM [PasswordManager].[dbo].[users] WHERE [usermail] = '{email}'";
                using (var command = new SqlCommand(query1, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var userMail = reader.GetString(1);
                            var password1 = reader.GetString(2);
                            var creationDate = reader.GetDateTime(3).ToString("yyyyMMdd");
                            var creationDaten = reader.GetDateTime(3).ToString("yyyy-MM-dd");

                            if (password1 == password)
                            {
                                ricevuta = "matricola;username;password;data \n" + id + ";" + userMail + ";" + password1 + ";" + creationDate;
                                namefile = $@"C:\Users\Mohamed\Documents\GitHub\PasswordManager\PasswordManagerLibrary\PasswordManager\csv\{id}-{creationDaten}.csv";

                                using (var writer = new StreamWriter(namefile))

                                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                                {

                                    csv.WriteField(ricevuta);


                                }
                                Console.WriteLine("file salvato");
                            }
                            else
                            {
                                Console.WriteLine("password errata");
                            }


                        }
                    }
                }
            }



        }
    }
}
