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
            _bookRepository.CreateBook(bookAdd);

            var book = _bookRepository.GetBookByISBN("9780786965625");

            //assert
            Assert.IsType<Book>(book);
            Assert.Equal("9780786965625", book.ISBN);
        }

        [Fact]
        public void BookShouldbeRemoveableFromRepo()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var book = _bookRepository.GetBookByISBN("9781785818493");
            _bookRepository.DeleteBook(book);
            var bookResponse = _bookRepository.GetBookByISBN("9781785818493");

            //assert
            Assert.Null(bookResponse);
        }

        [Fact]
        public void BookCheckOutShouldbeReadable()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var book = _bookRepository.GetBookByISBN("9780786965625");//WH40k
            var user = CreateUser();
            book.CheckOut(user);

            //assert
            Assert.IsType<History>(book.History[0]);
            Assert.Equal("CheckOut", book.History[0].Description);
            Assert.False(book.AvailabilityStatus);
            Assert.IsType<User>(book.CheckedOutBy);
        }

        [Fact]
        public void BookCheckInShouldbeReadable()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var book = _bookRepository.GetBookByISBN("9780866118705");//war of the worlds
            var user = CreateUser();
            book.CheckIn();

            //assert
            Assert.IsType<History>(book.History[0]);
            Assert.Equal("CheckIn", book.History[0].Description);
            Assert.True(book.AvailabilityStatus);
            Assert.Null(book.CheckedOutBy);
        }

        private User CreateUser()
        {
            User user = new User("Susan Mc Test", true);
            return user;
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

            var book2 = new Book("9781785818493") //warhammer 40k rulebook 
            {
                Title = "WARHAMMER 40000 RULEBOOK (ENGLISH)",
                Author = "Games Workshop",
                AvailabilityStatus = true
            };

            books.Add(book1);
            books.Add(book2);

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
