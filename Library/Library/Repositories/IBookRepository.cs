using Library.Models;

namespace Library.Repositories
{
    public interface IBookRepository
    {

        public List<Book> GetAllBooks();
        public Book GetBookByISBN(string ISBN);
        public void AddBook(Book book);
    }
}
