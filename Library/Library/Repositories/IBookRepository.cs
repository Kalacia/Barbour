using Library.Models;

namespace Library.Repositories
{
    public interface IBookRepository
    {

        public List<Book> GetAllBooks();
        public void AddBook(Book book);
        public void DeleteBook(Book book);
        public Book GetBookByISBN(string isbn);
        public List<Book> GetBookByTitle(string bookTitle);
        
    }
}
