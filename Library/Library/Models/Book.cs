namespace Library.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author{ get; set; }
        public bool AvailabilityStatus { get; set; }
        public UserViewModel CheckedOutBy { get; set; }
        public List<History> History { get; set; }

        public Book(string isbn) 
        {
            ISBN = isbn;
        }
    }
}
