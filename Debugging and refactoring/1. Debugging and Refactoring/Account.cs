using System.Security.Principal;

namespace DebuggingAndRefactoringTask1
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions;

        public Account(string id ,string name, double balance)
        {
            Id = id;
            Name = name;
            Balance = balance;

            Transactions = new List<Transaction>();
        }

        public void MakeDeposit(double amount, string eventType = "Deposit")
        {
            Balance += amount;
            Transaction transaction = new Transaction
            {
                Date = DateTime.Now,
                Value = amount,
                Event = eventType,
                Balance = Balance
            };

            Transactions.Add(transaction);
        }

        public void MakeWithdrawal(double amount, string eventType = "Withdrawal")
        {
            Balance -= amount;
            Transaction transaction = new Transaction
            {
                Date = DateTime.Now,
                Value = amount,
                Event = eventType,
                Balance = Balance
            };

            Transactions.Add(transaction);
        }
    }
}
