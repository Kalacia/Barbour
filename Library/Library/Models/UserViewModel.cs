namespace Library.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active {  get; set; }

        public UserViewModel(string name, bool active) 
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
