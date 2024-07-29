using Library.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
            //used to get initial data into the library. In the real world, this would likely be a database.
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

        public void CreateBook(Book book) 
        {
            _books.Add(book);
        }

        public void DeleteBook(string isbn)
        {
            var index = _books.FindIndex(x => x.ISBN == isbn);
            _books.RemoveAt(index);
        }

        private void SetupBooks()
        {
            Book book1 = new Book("9780866118705") //war of the worlds
            {
                Title = "War of the worlds",
                Author = "H.G Wells",
                AvailabilityStatus = false
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

            CreateBook(book1);
            CreateBook(book2);
            CreateBook(book3);
        }
    }
}
