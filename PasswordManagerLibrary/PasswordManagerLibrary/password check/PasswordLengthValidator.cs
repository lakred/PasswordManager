using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public class PasswordLengthValidator : PasswordCheck
    {


        public override bool Validate(string password)
        {
            if (password.Length < 7)
            {
                return false;
            }
          
            if (_successor != null)
            {
                return _successor.Validate(password);
            }
            return false;

        }
    }
}
