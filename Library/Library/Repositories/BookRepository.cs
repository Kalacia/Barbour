using Library.Models;

namespace Library.Repositories
{
    public sealed class BookRepository : IBookRepository
    {

        private List<Book> _books { get; set; }

        public BookRepository()
        {
            _books = new List<Book>();
            SetupBooks();
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

        public List<Book> GetBookByTitle(string bookTitle)
        {
            var books = _books.Where(x => x.Title!.ToUpper().Contains(bookTitle.ToUpper())).ToList();

            return books;
        }

        public void AddBook(Book book) 
        {
            _books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _books.Remove(book);
        }

        private void SetupBooks()
        {
            Book book1 = new Book("9780866118705") //war of the worlds
            {
                Title = "War of the worlds",
                Author = "H.G Wells",
                AvailabilityStatus = true
            };

            Book book2 = new Book("9781785818493") //warhammer 40k rulebook 
            {
                Title = "WARHAMMER 40000 RULEBOOK (ENGLISH)",
                Author = "Games Workshop",
                AvailabilityStatus = true
            };

            Book book3 = new Book("9780786965625") //DnD 5th ed, dm guide
            {
                Title = "D&D Dungeon Master’s Guide (Dungeons & Dragons Core Rulebook)",
                Author = "Wizards RPG Team",
                AvailabilityStatus = true
            };

            AddBook(book1);
            AddBook(book2);
            AddBook(book3);
        }
    }
}
