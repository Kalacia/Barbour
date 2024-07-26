using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public LibraryController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ViewAllBooks()
        {
            var books = _bookRepository.GetAllBooks();

            return View(books);
        }
    }
}
