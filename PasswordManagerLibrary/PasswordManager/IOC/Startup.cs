using CsvPrinter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManagerLibrary;
using PasswordManagerLibrary.password_check;
using System.IO;

namespace PasswordManager.IOC
{
    public class Startup
    {
        public static IHostBuilder CreateHostBuilder() =>
           Host.CreateDefaultBuilder()
          .ConfigureServices((hostContext, services) =>
           {
              string connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
              services.AddSingleton(new DatabaseManager(connectionString));
              services.AddSingleton(new PrintCsv(connectionString));
              services.AddSingleton(new PrintCsvBis(connectionString));

               var passwordValidator = new PasswordValidator();
               var emailValidator = new EmailValidator();
               
               services.AddSingleton(new UserValidator(emailValidator, passwordValidator));
           });


    }
}
