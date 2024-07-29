using Library.Models;
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

        // POST : Book/Create page
        [HttpGet]
        public IActionResult UserAddView()
        {
            return View();
        }

        // POST : Book/Create action
        [HttpPost]
        public IActionResult UserAdd([FromForm] User user)
        {
            try
            {
                //we need to check if the user already exists
                User userCheck = _userRepository.GetUserByName(user.Name);

                if (userCheck != null)
                {
                    //if user already exists, show view with no changes made
                    ViewData["Result"] = "Failure: User already exists.";
                    return View();
                }

                _userRepository.AddUser(user);
                ViewData["Result"] = "Success";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Result"] = $"Failure: {ex} ";
                return View();
            }
        }

        [HttpGet]
        public IActionResult UserManage()
        {
            try
            {
                var users = _userRepository.GetAllUsers();

                return View(users);
            }
            catch (Exception ex)
            {
                ViewData["Result"] = "Failure:" + ex;
                return View();
            }
        }

        // Get : User/Delete
        [HttpGet]
        public IActionResult UserDeleteView(string name)
        {
            try
            {
                _userRepository.DeleteUser(name);
                @ViewData["Result"] = "Success";
                return View();
            }
            catch (Exception ex)
            {
                @ViewData["Result"] = $"Failure {ex}";
                return View(ex);
            }
        }

    }
}
