using System;
using System.Data.SqlClient;
using CsvHelper;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManagerLibrary;
using CsvPrinter;
using DbSettings;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Data Source=localhost;Initial Catalog=PasswordManager;Integrated Security=True;TrustServerCertificate=True;";
            var dbManager = new DatabaseManager(connectionString);
            var printCsv= new PrintCsv(connectionString);
            var printCsvBis = new PrintCsvBis(connectionString);
            var passwordChain = new SetUpChainPassword();
            var emailValidator = new EmailValidator(passwordChain.GetChain);
            var userCheck = new UsermailCheck();



            Console.WriteLine("Digita:\n 1 per creare nuove credenziali \n 2 per ristampare una ricevuta  \n");
            int scelta1 = Convert.ToInt32(Console.ReadLine());
            if (scelta1==1)
            {

                Console.Write("Please enter your email: ");
                var email = Console.ReadLine();

                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                var isEmailValid = emailValidator.ValidateUsername(email);
                var isPasswordValid = emailValidator.ValidatePassword(password);
                if (isEmailValid && isPasswordValid)
                {
                    Console.WriteLine("Credentials are valid.");
                    dbManager.InsertUser(email, password, userCheck.UserExist(email));
                    

                }

                else
                {
                    Console.WriteLine("Invalid credentials.");



                }
                if (userCheck.UserExist(email))
                {
                    Console.WriteLine("Se vuoi stampare una ricevuta digita 1");
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    if (scelta == 1)
                    {
                        printCsv.PrintFileCsv(email);
                    }

                }
                

            }
            else if(scelta1==2)
            {
                Console.Write("Please enter your email: ");
                var email = Console.ReadLine();

                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                var isEmailValid = emailValidator.ValidateUsername(email);
                var isPasswordValid = emailValidator.ValidatePassword(password);

                if (isEmailValid && isPasswordValid)
                {


                    printCsvBis.PrintFileCsv(email, password);

                }

            }
        }
    }
}
        