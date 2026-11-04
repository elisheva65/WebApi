using Entity;

namespace Repository
{
    public interface IClassRepository
    {
        User AddUser(User user);
        User GetById(int id);
        User login(UserLogin loginUser);
        void UpdateUser(int id, User updateUser);
    }
}