using DebuggingAndRefactoringTask1;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            var accountManager = new AccountManager();

            accountManager.ShowAccountInterface();
        }

        //static void AddAccount()
        //{
        //    Console.WriteLine("Enter Account ID:");
        //    var id = Console.ReadLine();

        //    Console.WriteLine("Enter Account Holder Name:");
        //    var name = Console.Read().ToString();

        //    Account account = new Account (name, 0);
        //    //accounts.InsertAccount(account);

        //    Console.WriteLine("Account added successfully.");
        //}

        //static void DepositMoney()
        //{
        //    Console.WriteLine("Enter Account ID:");
        //    string id = Console.ReadLine();

        //    Console.WriteLine("Enter Amount to Deposit:");
        //    double amount = double.Parse(Console.ReadLine());

        //    foreach (var account in accounts)
        //    {
        //        if (account.Id == id)
        //        {
        //            account.Balance += amount;
        //            Console.WriteLine("Deposit successful.");
        //            return;
        //        }
        //    }

        //    Console.WriteLine("Account not found.");
        //}

        //static void WithdrawMoney()
        //{
        //    Console.WriteLine("Enter Account ID:");
        //    string id = Console.ReadLine();

        //    Console.WriteLine("Enter Amount to Withdraw:");
        //    double amount = double.Parse(Console.ReadLine());

        //    foreach (var account in accounts)
        //    {
        //        if (account.Id == id)
        //        {
        //            if (account.Balance >= amount)
        //            {
        //                account.Balance -= amount;
        //                Console.WriteLine("Withdrawal successful.");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Insufficient balance.");
        //            }
        //            return;
        //        }
        //    }

        //    Console.WriteLine("Account not found.");
        //}

        //static void DisplayAccountDetails()
        //{
        //    Console.WriteLine("Enter Account ID:");
        //    string id = Console.ReadLine();

        //    foreach (var account in accounts)
        //    {
        //        if (account.Id == id)
        //        {
        //            Console.WriteLine($"Account ID: {account.Id}");
        //            Console.WriteLine($"Account Holder: {account.Name}");
        //            Console.WriteLine($"Balance: {account.Balance}");
        //            return;
        //        }
        //    }

        //    Console.WriteLine("Account not found.");
        //}
    }
}
