using Library.Models;

namespace Library.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Book GetBookByISBN(string isbn);
        public void CreateBook(Book book);
        public void DeleteBook(Book book);
    }
}
