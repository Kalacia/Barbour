using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Library.Models
{
    public class UserList
    {
        public UserList()
        {
            UsersList = new List<User>();
        }

        [DisplayName("Users")]
        public List<User> UsersList { get; set; }
    }
}
