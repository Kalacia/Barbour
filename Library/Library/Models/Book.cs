namespace Library.Models
{
    public class Book
    {
        private string _ISBN { get; set; }
        private string _title { get; set; }
        private string _author{ get; set; }
        private bool _availabilityStatus { get; set; }
        private UserViewModel _checkedOutBy { get; set; }
        private List<History> _history { get; set; }

        public void SetISBN(string isbn)
        {
            _ISBN = isbn;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public void SetAuthor(string author)
        {
            _author = author;
        }

        public void SetAvailability(bool availability)
        {
            _availabilityStatus = availability;
        }
    }
}
