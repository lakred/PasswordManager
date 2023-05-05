using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public class EmailValidator:IUserValidator
    {
        private readonly PasswordCheck _passwordValidator;
        public EmailValidator(PasswordCheck passwordValidator) 
        {
            _passwordValidator = passwordValidator;
        }
        public bool ValidateUsername(string username)
        {

            int atSign = username.IndexOf("@", 0, username.Length);
            int dotSign = username.IndexOf(".", 0, username.Length);
            int countAt = 0;
            foreach (char c in username)
            {
                if (c.ToString() == "@")
                {
                    countAt++;
                }
            }
            if (atSign > 0 && dotSign > 0 && atSign < dotSign && countAt == 1)
            {

                return true;
            }return false;
        }
        public bool ValidatePassword(string password)
        {
            return _passwordValidator.Validate(password);
        }

    }
}
