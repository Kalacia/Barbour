using Library.Models;

namespace Library.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(UserViewModel user);
        public List<UserViewModel> GetAllUsers();
        public UserViewModel GetUserByName(string usersName);
    }
}
