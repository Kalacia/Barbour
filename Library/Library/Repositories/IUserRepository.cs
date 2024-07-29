using Library.Models;

namespace Library.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public List<User> GetAllUsers();
        public User GetUserByName(string usersName);
        public void DeleteUser(string name);
    }
}
