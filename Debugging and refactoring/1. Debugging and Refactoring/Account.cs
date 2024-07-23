using System.Security.Principal;

namespace DebuggingAndRefactoringTask1
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string id ,string name, double balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

        public void MakeDeposit(double amount)
        {
            Balance += amount;
        }

        public void MakeWithdrawal(double amount)
        {
            Balance -= amount;
        }
    }
}
