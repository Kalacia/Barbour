using Library.Models;
using System.Xml.Linq;
using System;

namespace Library.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; set; }

        public UserRepository() 
        {
            Users = new List<User>();
            SetupUsers();
        }
        
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }

        public User GetUserByName(string usersName) 
        {
            User user = Users.Find(x => x.Name == usersName);
            return user;
        }

        private void SetupUsers()
        {
            User user1 = new User("Tony Stark", true);
            User user2 = new User("Hulk Hogan", true);
            User user3 = new User("Rusty Gates", true);
;
            AddUser(user1);
            AddUser(user2);
            AddUser(user3);
        }
    }
}
