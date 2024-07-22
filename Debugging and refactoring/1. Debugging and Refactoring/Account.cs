namespace DebuggingAndRefactoringTask1
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
