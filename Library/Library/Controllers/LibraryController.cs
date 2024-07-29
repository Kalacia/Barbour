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

        [HttpGet]
        public IActionResult BookAddView() 
        {
            return View();
        }

        // POST : Book/Create and AddBook
        [HttpPost]
        public IActionResult BookAdd([FromForm] Book book)
        {
            _bookRepository.CreateBook(book);

            return View();
        }

        [HttpGet]
        public IActionResult BookDeleteView(string isbn)
        {
            _bookRepository.DeleteBook(isbn);
            return View();
        }

        [HttpGet]
        public IActionResult BookManage()
        {
            var books = _bookRepository.GetAllBooks();

            return View(books);
        }

        [HttpGet]
        public IActionResult BookCheck(string isbn)
        {
            var book = _bookRepository.GetBookByISBN(isbn);

            return View(book);
        }

        [HttpGet]
        public IActionResult BookCheckIn(string isbn)
        {
            var book = _bookRepository.GetBookByISBN(isbn);

            //this is hardcoded, user dropdown TODO
            var user = _userRepository.GetUserByName("Admin");
            book.CheckIn(user);

            return View();
        }

        [HttpGet]
        public IActionResult BookCheckOut(string isbn)
        {
            var book = _bookRepository.GetBookByISBN(isbn);

            //this is hardcoded, user dropdown TODO
            var user = _userRepository.GetUserByName("Admin");
            book.CheckOut(user);

            return View();
        }
    }
}
