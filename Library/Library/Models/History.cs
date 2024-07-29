namespace Library.Models
{
    public class History
    {
        public DateTime Date;
        public string Description;
        public User User;

        public History(string description, User user) 
        {
            Date = DateTime.Now;
            Description = description;
            User = user;
        }
    }
}
