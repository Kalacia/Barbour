using Library.Models;

namespace Library.Repositories
{
    public class UserRepository
    {
        public List<UserViewModel> Users { get; set; }

        public UserRepository() 
        {
            Users = new List<UserViewModel>();
        }
        
        public void AddUser(UserViewModel user)
        {
            Users.Add(user);
        }

        public List<UserViewModel> GetAllUsers()
        {
            return Users;
        }
    }
}
