using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary.password_check
{
    public class PasswordValidator
    {
        public bool Validate(string password)
        {
            var setUpChain = new SetUpChainPassword();
            var passwordCheck = setUpChain.GetChain;

            return passwordCheck.Validate(password);
        }
    }
}
