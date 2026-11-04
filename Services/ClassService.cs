using Repository;
using Entity;

namespace Services
{
    public class ClassService : IClassService
    {
        IClassRepository repository;

        public ClassService(IClassRepository repository)
        {
            this.repository = repository;
        }

        public User AddUser(User user)
        {
            return repository.AddUser(user);
        }
        public User login(UserLogin loginUser)
        {
            return repository.login(loginUser);
        }
        public void UpdateUser(int id, User updateUser)
        {
            repository.UpdateUser(id, updateUser);
        }
        public User GetById(int id)
        {
            return repository.GetById(id);
        }


    }
}
