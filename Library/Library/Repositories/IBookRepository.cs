using Library.Models;

namespace Library.Repositories
{
    public interface IBookRepository
    {

        List<Book> GetAllBooks();
    }
}
