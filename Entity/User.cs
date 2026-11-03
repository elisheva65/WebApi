using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User
    {
        [EmailAddress]
        public  string email { get; set; }
        public  string password { get; set; }
        public  string name { get; set; }
        public  string lastName { get; set; }
        
        
        public int id { get; set; }

    }
}
