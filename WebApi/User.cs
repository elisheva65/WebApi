using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class User
    {
        [EmailAddress]
        public  string email { get; set; }
        public  int password { get; set; }
        public  string name { get; set; }
        public  string lastName { get; set; }
        
        
        public int id { get; set; }

    }
}
