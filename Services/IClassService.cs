using Entity;

namespace Services
{
    public interface IClassService
    {
        User AddUser(User user);
        User GetById(int id);
        User login(UserLogin loginUser);
        void UpdateUser(int id, User updateUser);
    }
}