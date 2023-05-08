using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public class SetUpChainPassword
    {
        private readonly PasswordCheck _chain;

        public SetUpChainPassword()
        {
            var passwordLength = new PasswordLengthValidator();
            var passwordUppercase = new PasswordUppercaseValidator();
            var passwordNumber = new PasswordNumberValidator();
            var passwordSpecialCharacter = new PasswordSpecialCharacterValidator();

            passwordLength.SetSuccessor(passwordUppercase);
            passwordUppercase.SetSuccessor(passwordNumber);
            passwordNumber.SetSuccessor(passwordSpecialCharacter);
            _chain = passwordLength;
        }

        public PasswordCheck GetChain => _chain;
    }
}