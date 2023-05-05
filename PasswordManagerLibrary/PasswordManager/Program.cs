using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManagerLibrary;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Data Source=localhost;Initial Catalog=PasswordManager;Integrated Security=True;TrustServerCertificate=True;";
            var dbManager = new DatabaseManager(connectionString);

            var passwordChain = new SetUpChainPassword();
            var emailValidator = new EmailValidator(passwordChain.GetChain);

            Console.Write("Please enter your email: ");
            var email = Console.ReadLine();

            Console.Write("Please enter your password: ");
            var password = Console.ReadLine();

            var isEmailValid = emailValidator.ValidateUsername(email);
            var isPasswordValid = emailValidator.ValidatePassword(password);

            if (isEmailValid && isPasswordValid)
            {
                Console.WriteLine("Credentials are valid.");

                dbManager.InsertUser(email, password);


            }

            else
            {
                Console.WriteLine("Invalid credentials.");
            }
                }
            }
        }