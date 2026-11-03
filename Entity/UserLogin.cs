using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserLogin
    {
        public string password { get; set; }

        [EmailAddress]

        public string email { get; set; }
    }
}
