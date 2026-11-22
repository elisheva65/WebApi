using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User
    {
        //In C#, properties are written in PascalCase: Email. file.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
        [EmailAddress]
        public  string email { get; set; }
        public  string password { get; set; }
        public  string name { get; set; }
        public  string lastName { get; set; }
        
        
        public int id { get; set; }

    }
}
