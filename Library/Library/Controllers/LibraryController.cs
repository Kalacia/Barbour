using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LibraryController(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _bookRepository = serviceProvider.GetService<IBookRepository>() ??
                throw new ArgumentNullException(nameof(_bookRepository));

            _userRepository = serviceProvider.GetService<IUserRepository>() ??
                throw new ArgumentNullException(nameof(_userRepository));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST : Book/Create page
        [HttpGet]
        public IActionResult BookAddView() 
        {
            return View();
        }

        // POST : Book/Create action
        [HttpPost]
        public IActionResult BookAdd([FromForm] Book book)
        {
            try
            {
                //we need to check if the ISBN already exists
                Book bookCheck = _bookRepository.GetBookByISBN(book.ISBN);

                if (bookCheck != null)
                {
                    //if book already exists, show view with no changes made
                    ViewData["Result"] = "Failure: ISBN already exists.";
                    return View();
                }

                _bookRepository.CreateBook(book);
                ViewData["Result"] = "Success";
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET : Book/Delete
        [HttpGet]
        public IActionResult BookDeleteView(string isbn)
        {
            try
            {
                _bookRepository.DeleteBook(isbn);
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public IActionResult BookManage()
        {

            try
            {
                var books = _bookRepository.GetAllBooks();

                return View(books);
            }
            catch (Exception ex)
            {
                ViewData["Result"] = "Failure:" + ex;
                return View();
            }
        }

        [HttpGet]
        public IActionResult BookCheck(string isbn)
        {
            var book = _bookRepository.GetBookByISBN(isbn);

            if (book == null)
            {
                ViewData["Result"] = "Failure: Book does not exist";
                return View();
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult BookCheckIn(string isbn)
        {
            try
            {
                var book = _bookRepository.GetBookByISBN(isbn);

                if (book.AvailabilityStatus == true)
                {
                    ViewData["Result"] = "Failure: Book is already checked in";
                    return View();
                }

                //this is hardcoded, user dropdown TODO
                var user = _userRepository.GetUserByName("Admin");
                book.CheckIn(user);

                ViewData["Result"] = "Success: Book checked in";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Result"] = ex;
                return View();
            }
        }

        [HttpGet]
        public IActionResult BookCheckOut(string isbn)
        {
            try
            {
                var book = _bookRepository.GetBookByISBN(isbn);

                if (book == null || book.AvailabilityStatus == false)
                {
                    ViewData["Result"] = "Failure: Book isnt available";
                    return View();
                }

                //this is hardcoded, user dropdown TODO
                var user = _userRepository.GetUserByName("Admin");
                book.CheckOut(user);

                ViewData["Result"] = "Success";
                return View();
            }
            catch(Exception ex) 
            {
                ViewData["Result"] = ex;
                return View();
            }

        }
    }
}
