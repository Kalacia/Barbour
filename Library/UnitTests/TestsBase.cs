using Library.Models;
using Library.Repositories;
using Moq;
using static System.Reflection.Metadata.BlobBuilder;

namespace UnitTests
{
    public class TestsBase
    {
        protected readonly Mock<IServiceProvider> MockServiceProvider;
        protected readonly Mock<IUserRepository> MockServiceUserRepository;
        protected readonly Mock<IBookRepository> MockServiceBookRepository;


        protected TestsBase()
        {
            MockServiceProvider = new Mock<IServiceProvider>();
            MockServiceUserRepository = new Mock<IUserRepository>();
            MockServiceBookRepository = new Mock<IBookRepository>();
        }

        protected void SetupSuccessfulUserMocks(List<UserViewModel> users)
        {
            MockServiceProvider.Setup(x => x.GetService(typeof(IUserRepository))).Returns(MockServiceUserRepository.Object);

            MockServiceUserRepository.Setup(x => x.GetAllUsers()).Returns(users);

            MockServiceUserRepository.Setup(x => x.GetUserByName("Dave Test")).Returns(users.Find(x => x.Name == "Dave Test"));

            MockServiceUserRepository.Setup(x => x.GetUserByName("Jane Test")).Returns(users.Find(x => x.Name == "Jane Test"));
        }

        protected void SetupSuccessfulBookMocks(List<Book> books, Book book)
        {
            MockServiceProvider.Setup(x => x.GetService(typeof(IBookRepository))).Returns(MockServiceBookRepository.Object);

            MockServiceBookRepository.Setup(x => x.GetBookByISBN("9780866118705")).Returns(books.Find(x => x.ISBN == "9780866118705"));

            MockServiceBookRepository.Setup(x => x.AddBook(book));

            MockServiceBookRepository.Setup(x => x.GetBookByISBN("9780786965625")).Returns(book);

            MockServiceBookRepository.Setup(x => x.GetAllBooks()).Returns(books);
        }
    }
}
