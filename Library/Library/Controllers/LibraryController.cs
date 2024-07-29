using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public LibraryController(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _bookRepository = serviceProvider.GetService<IBookRepository>() ??
                throw new ArgumentNullException(nameof(_bookRepository));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewAllBooks()
        {
            var books = _bookRepository.GetAllBooks();

            return View(books);
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
    }
}
