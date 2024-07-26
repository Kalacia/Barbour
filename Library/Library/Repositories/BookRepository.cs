using Library.Models;

namespace Library.Repositories
{
    public class BookRepository
    {

        private List<Book> _books { get; set; }

        public BookRepository()
        {
            _books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
