using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public class PasswordUppercaseValidator : PasswordCheck
    {


        public override bool Validate(string password)
        {
            if (password.Any(char.IsUpper))
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
