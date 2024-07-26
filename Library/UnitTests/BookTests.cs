using Library.Models;
using Library.Repositories;

namespace UnitTests
{
    public class BookTests : TestsBase
    {
        private IBookRepository _bookRepository;

        [Fact]
        public void BookShouldBeRetreiveableFromRepo()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var repo = _bookRepository.GetAllBooks();
            var book = repo[0];

            //assert
            Assert.IsType<Book>(book);
        }

        private void CreateSuccessfulMoqs()
        {
            //setup list to be passed into moq service
            List<Book> books = new List<Book>();

            var ISBN = "9780866118705"; //war of the worlds
            var bookTitle = "War of the worlds";
            var author = "H.G Wells";
            var availabilityStatus = false;

            var book1 = new Book();

            book1.SetISBN(ISBN);
            book1.SetTitle(bookTitle);
            book1.SetAuthor(author);
            book1.SetAvailability(availabilityStatus);

            books.Add(book1);

            //create moq services
            SetupSuccessfulBookMocks(books);

            _bookRepository = MockServiceBookRepository.Object;
        }


    }
}
