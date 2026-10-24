using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class UserLogin
    {
        public int password { get; set; }

        [EmailAddress]

        public string email { get; set; }
    }
}
