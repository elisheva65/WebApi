using Entity;
using System.Text.Json;

namespace Repository
{
    public class ClassRepository : IClassRepository
    {

        //A full path on your disk (M:) only works on your computer: use a path relative to the project instead
        public User AddUser(User user)
        {
            string filePath = "M:\\API\\WebApi\\Repository\\file.txt";
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return user;
        }

        //In C#, method names are PascalCase: Login
        public User login(UserLogin loginUser)
        {
            string filePath = "M:\\API\\WebApi\\Repository\\file.txt";

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password ==
                    loginUser.password)
                        return user;
                }
            }
            return null;

        }

        public void UpdateUser(int id, User updateUser)
        {
            string filePath = "M:\\API\\WebApi\\Repository\\file.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

        public User GetById(int id)
        {
            string filePath = "M:\\API\\WebApi\\Repository\\file.txt";


            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        return user;
                }
            }
            return null;
        }
    }
}
