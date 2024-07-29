using Library.Models;

namespace Library.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository() 
        {
            _users = new List<User>();
            SetupUsers();
        }
        
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserByName(string usersName) 
        {
            User user = _users.Find(x => x.Name == usersName);
            return user;
        }

        public void DeleteUser(string name)
        {
            var index = _users.FindIndex(x => x.Name == name);
            _users.RemoveAt(index);
        }

        private void SetupUsers()
        {

            User user1 = new User("Tony Stark", true);
            User user2 = new User("Hulk Hogan", true);
            User user3 = new User("Rusty Gates", true);
            User user4 = new User("Admin", true)
;
            AddUser(user1);
            AddUser(user2);
            AddUser(user3);
            AddUser(user4);
        }
    }
}
