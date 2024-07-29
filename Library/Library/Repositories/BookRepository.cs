using Library.Models;

namespace Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;

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
            Book book = _books.Find(x => x.ISBN == ISBN);
            return book;
        }

        public void CreateBook(Book book) 
        {
            _books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _books.Remove(book);
        }
    }
}
