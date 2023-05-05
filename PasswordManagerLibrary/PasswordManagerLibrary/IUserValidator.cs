using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public interface IUserValidator
    {
        bool ValidateUsername(string username);
        bool ValidatePassword(string password);
    }
}
