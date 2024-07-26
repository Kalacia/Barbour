namespace Library.Models
{
    public class History
    {
        public DateTime Date;
        public string Description;

        public History(string description) 
        {
            Date = DateTime.Now;
            Description = description;
        }
    }
}
