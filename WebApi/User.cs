using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    //In C#, public properties are written in PascalCase (Email, Password, Name, LastName, Id).
    //If you rename them, file.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
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
