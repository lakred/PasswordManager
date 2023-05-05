using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public class PasswordNumberValidator : PasswordCheck
    {
        public override bool Validate(string password)
        {
            if (password.Any(char.IsDigit))
            {
                return true;
            }

            if (_successor != null)
            {
                return _successor.Validate(password);
            }
            return false;

        }
    }
}
