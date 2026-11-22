using Entity;
using System.Text.Json;

namespace Repository
{
    public class ClassRepository : IClassRepository
    {

        public User AddUser(User user)
        {
            //This full path only exists on your computer: use a path relative to the project, so the project runs on another computer. Where should file.txt be?
            string filePath = "M:\\API\\WebApi\\Repository\\file.txt";
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return user;
        }

        public User login(UserLogin loginUser)
        {
            //This full path only exists on your computer: use a path relative to the project, so the project runs on another computer. Where should file.txt be?
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
            //This full path only exists on your computer: use a path relative to the project, so the project runs on another computer. Where should file.txt be?
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
            //This full path only exists on your computer: use a path relative to the project, so the project runs on another computer. Where should file.txt be?
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
