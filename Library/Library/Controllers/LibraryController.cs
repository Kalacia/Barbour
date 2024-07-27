using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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
        
        public IActionResult Books(string bookTitle)
        {
            var result = _bookRepository.GetAllBooks();

            if (!String.IsNullOrEmpty(bookTitle))
            {
                result = _bookRepository.GetBookByTitle(bookTitle);                
            }

            return View(result);
        }
    }
}
