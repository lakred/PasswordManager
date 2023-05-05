using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerLibrary
{
    public abstract class PasswordCheck
    {
        protected PasswordCheck _successor;

        public void SetSuccessor(PasswordCheck successor)
        {
            _successor = successor;
        }

        public abstract bool Validate(string password);
    }
}
