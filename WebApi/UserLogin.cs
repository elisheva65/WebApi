using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    //In C#, public properties are written in PascalCase (Password, Email)
    public class UserLogin
    {
        public int password { get; set; }

        [EmailAddress]

        public string email { get; set; }
    }
}
