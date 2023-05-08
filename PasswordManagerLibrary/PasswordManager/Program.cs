using System;
using System.Data.SqlClient;
using CsvHelper;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManagerLibrary;
using CsvPrinter;
using DbSettings;
using System.Configuration;
using PasswordManager.IOC;
using PasswordManagerLibrary.password_check;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {

            var host = Startup.CreateHostBuilder().Build();
            var dbManager = host.Services.GetService<DatabaseManager>();
            var printCsvBis = host.Services.GetService<PrintCsvBis>();
           // var connectionString = "Data Source=localhost;Initial Catalog=PasswordManager;Integrated Security=True;TrustServerCertificate=True;";
           // var dbManager = new DatabaseManager(connectionString);
            //var printCsv = new PrintCsv(connectionString);
            //var printCsvBis = new PrintCsvBis(connectionString);
           // var passwordChain = new SetUpChainPassword();
            //var emailValidator = new EmailValidator(passwordChain.GetChain);




            //var passwordValidator = new PasswordValidator();
            //var emailValidator = new EmailValidator();
            //var userValidator = new UserValidator(emailValidator, passwordValidator);
            var userValidator = host.Services.GetService<UserValidator>();
            var userCheck = new UsermailCheck();



            Console.WriteLine("Digita:\n 1 per creare nuove credenziali \n 2 per ristampare una ricevuta  \n");
            int scelta1 = Convert.ToInt32(Console.ReadLine());

            if (scelta1==1)
            {

                Console.Write("Please enter your email: ");
                var email = Console.ReadLine();

                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                var isUserValid= userValidator.ValidateUser(email, password);
                if (isUserValid)
                {
                    Console.WriteLine("Credentials are valid.");
                    dbManager.InsertUser(email, password, userCheck.UserExist(email));
                }
                else
                {
                    Console.WriteLine("Invalid credentials.");
                }
            }
            else if(scelta1==2)
            {
                Console.Write("Please enter your email: ");
                var email = Console.ReadLine();

                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                var isUserValid = userValidator.ValidateUser(email, password);
                if (isUserValid)
                {
                    printCsvBis.PrintFileCsv(email, password);
                }

            }
        }
    }
}
        