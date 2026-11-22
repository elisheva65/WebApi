using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;
//This using isn't used in this file: you can remove it
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
