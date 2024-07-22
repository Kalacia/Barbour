namespace DebuggingAndRefactoringTask1
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name, double balance)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Balance = balance;
        }
    }
}
