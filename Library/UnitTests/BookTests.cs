using Library.Models;
using Library.Repositories;

namespace UnitTests
{
    public class BookTests : TestsBase
    {
        private IBookRepository _bookRepository;

        [Fact]
        public void BookShouldBeExistInRepo()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var repo = _bookRepository.GetAllBooks();
            var book = repo[0];

            //assert
            Assert.IsType<Book>(book);
        }

        [Fact]
        public void BookShouldBeRetreiveableFromRepoByISBN()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var book = _bookRepository.GetBookByISBN("9780866118705");

            //assert
            Assert.IsType<Book>(book);
            Assert.Equal("9780866118705",book.ISBN);
        }

        private void CreateSuccessfulMoqs()
        {
            //setup list to be passed into moq service
            List<Book> books = new List<Book>();

            var ISBN = "9780866118705"; //war of the worlds

            var book1 = new Book(ISBN)
            {
                Title = "War of the worlds",
                Author = "H.G Wells",
                AvailabilityStatus = false
            };

            books.Add(book1);

            //create moq services
            SetupSuccessfulBookMocks(books);

            _bookRepository = MockServiceBookRepository.Object;
        }


    }
}
