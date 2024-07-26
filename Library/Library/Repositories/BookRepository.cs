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

        public Book GetBookByISBN(string ISBN)
        {
            var book = _books.Find(x => x.ISBN == ISBN);
            return book;
        }

        public void AddBook(Book book) 
        {
            _books.Add(book);
        }
    }
}
