using Library.Models;
using Library.Repositories;
using System.Dynamic;

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

        [Fact]
        public void BookShouldbeAddableToRepo()
        {
            //arrange
            CreateSuccessfulMoqs();

            var bookAdd = new Book("9780786965625") //DnD 5th ed, dm guide
            {
                Title = "D&D Dungeon Master’s Guide (Dungeons & Dragons Core Rulebook)",
                Author = "Wizards RPG Team",
                AvailabilityStatus = true
            };

            //act
            _bookRepository.AddBook(bookAdd);

            var book = _bookRepository.GetBookByISBN("9780786965625");

            //assert
            Assert.IsType<Book>(book);            
            Assert.Equal("9780786965625", book.ISBN);
        }

        private void CreateSuccessfulMoqs()
        {
            //setup list to be passed into moq service
            List<Book> books = new List<Book>();

            var book1 = new Book("9780866118705") //war of the worlds
            {
                Title = "War of the worlds",
                Author = "H.G Wells",
                AvailabilityStatus = false
            };

            books.Add(book1);

            var bookAdd = new Book("9780786965625") //DnD 5th ed, dm guide
            {
                Title = "D&D Dungeon Master’s Guide (Dungeons & Dragons Core Rulebook)",
                Author = "Wizards RPG Team",
                AvailabilityStatus = true
            };

            //create moq services
            SetupSuccessfulBookMocks(books, bookAdd);

            _bookRepository = MockServiceBookRepository.Object;
        }


    }
}
