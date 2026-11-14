using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User
    {
        //Tip: C# properties are PascalCase. Keep these names (the data file needs them) and use PropertyNameCaseInsensitive when deserializing.
        [EmailAddress]
        public  string email { get; set; }
        public  string password { get; set; }
        public  string name { get; set; }
        public  string lastName { get; set; }
        
        
        public int id { get; set; }

    }
}
