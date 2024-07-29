using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _userRepository = serviceProvider.GetService<IUserRepository>() ??
                throw new ArgumentNullException(nameof(_userRepository));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllusers()
        {
            var users = _userRepository.GetAllUsers();

            return View(users);
        }


    }
}
