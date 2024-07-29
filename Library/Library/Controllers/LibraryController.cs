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
        public IActionResult BookAddView() 
        {
            return View();
        }

        // POST : Book/Create and AddBook
        [HttpPost]
        public IActionResult BookAdd([FromForm] Book book)
        {
            //we need to check if the ISBN already exists
            Book bookCheck = _bookRepository.GetBookByISBN(book.ISBN);

            if (!String.IsNullOrEmpty(bookCheck.ISBN))
            {
                //if book already exists, show view with no changes made
                return View();
            }

            _bookRepository.CreateBook(book);
            return View();
        }

        [HttpGet]
        public IActionResult BookDeleteView(string isbn)
        {
            try
            {

            }
            catch (Exception e)
            {

            }
            _bookRepository.DeleteBook(isbn);
            return View();
        }

        [HttpPost]
        public IActionResult BookDelete(Book book)
        {
            _bookRepository.DeleteBook(book.ISBN);
            return View();
        }

        [HttpGet]
        public IActionResult BookManage()
        {
            var books = _bookRepository.GetAllBooks();

            return View(books);
        }
    }
}
