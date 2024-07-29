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

        // POST : Book/Delete
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

        // GET : Book/GetAll
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
                return View(ex);
            }

        }
    }
}
