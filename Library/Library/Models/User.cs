namespace Library.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active {  get; set; }

        public User(string name, bool active) 
        {
            Id = new Guid();
            Name = name;
            Active = active;
        }

        public void UpdateName(string name)
        {
            Name = name.Trim();
        }
    }
}
