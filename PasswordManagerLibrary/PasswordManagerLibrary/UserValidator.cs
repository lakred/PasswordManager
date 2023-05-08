using PasswordManagerLibrary.password_check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public class UserValidator
    {
        private readonly EmailValidator _emailValidator;
        private readonly PasswordValidator _passwordValidator;

        public UserValidator()
        {
        }

        public UserValidator(EmailValidator emailValidator, PasswordValidator passwordValidator)
        {
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
        }

        public bool ValidateUser(string username, string password)
        {
            return _emailValidator.ValidateUsername(username) && _passwordValidator.Validate(password);
        }
    }
}
