using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;
using Entity;


namespace Services
{
    public class PasswordService : IPasswordService
    {
        public Result GetStrongPassword(string pass)
        {
            return Zxcvbn.Core.EvaluatePassword(pass);

        }
    }
}
