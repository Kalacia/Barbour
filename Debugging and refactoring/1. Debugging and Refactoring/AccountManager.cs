using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace DebuggingAndRefactoringTask1
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;
        public bool Exit = false;

        public AccountManager() : this(Startup.BuildContainer())
        {
        }

        public AccountManager(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _accountRepository = serviceProvider.GetService<IAccountRepository>() ?? throw new ArgumentNullException(nameof(_accountRepository));
        }        

        public void ShowAccountInterfaceHome()
        {
            var keyCommands = new Dictionary<string, Action>();

            keyCommands["1"] = () => CreateAccount();
            keyCommands["2"] = () => DepositMoney();
            keyCommands["3"] = () => WithdrawMoney();
            keyCommands["4"] = () => DisplayAccountDetails();
            keyCommands["5"] = () => ViewTransactions();
            keyCommands["6"] = () => AccountTransfer();
            keyCommands["7"] = () => Leave();

            Console.WriteLine("--[ Home ]--");
            Console.WriteLine("1. Add Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Display Account Details");
            Console.WriteLine("5. View Account Transactions");
            Console.WriteLine("6. Account Transfer");
            Console.WriteLine("7. Exit");
            Console.WriteLine("-------------");
            Console.WriteLine();


            string key = Console.ReadKey(true).KeyChar.ToString();

            if (keyCommands.ContainsKey(key))
            {
                keyCommands[key]();//execute function based on valid input
            }

            Console.ReadKey();
        }

        public void CreateAccount()
        {
            string id = _accountRepository.GetNewAccountId();

            Console.WriteLine("Enter Account Holder Name:");
            string name = Console.ReadLine();

            Account account = new Account(id, name, 0);
            _accountRepository.InsertAccount(account);

            Console.WriteLine("Account added successfully.");

            ShowAccountInterfaceHome();
        }

        public void DepositMoney()
        {
            Console.WriteLine("Enter Account ID:");
            string id = Console.ReadLine();

            Account accountResult = _accountRepository.GetAccountById(id);

            if (accountResult is null)
            {
                Console.WriteLine("No Such account found.");
            }
            else
            {
                Console.WriteLine($"-- You are about to deposit into account {accountResult.Id} --");
                Console.WriteLine("Enter Amount to Deposit:");
                double amount = double.Parse(Console.ReadLine());

                if (amount > 0)
                {
                    accountResult.MakeDeposit(amount);
                    Console.WriteLine("Deposit successful.");
                    ShowAccountInterfaceHome();
                }
            }

            ShowAccountInterfaceHome();
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("Enter Account ID:");
            string id = Console.ReadLine();

            Account accountResult = _accountRepository.GetAccountById(id);

            if (accountResult is null)
            {
                Console.WriteLine("No Such account found.");
            }
            else
            {
                Console.WriteLine($"----------");
                Console.WriteLine($"Account ID: {accountResult.Id}");
                Console.WriteLine($"Account Holder: {accountResult.Name}");
                Console.WriteLine($"Balance: {accountResult.Balance}");
                Console.WriteLine($"----------");
            }

            ShowAccountInterfaceHome();
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("Enter Account ID:");
            string id = Console.ReadLine();

            Account accountResult = _accountRepository.GetAccountById(id);

            if (accountResult is null)
            {
                Console.WriteLine("No Such account found.");
            }
            else
            {
                Console.WriteLine("Enter Amount to Withdraw:");
                double amount = double.Parse(Console.ReadLine());

                if (amount <= accountResult.Balance) 
                {
                    accountResult.MakeWithdrawal(amount);
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }

            ShowAccountInterfaceHome();
        }

        public void ViewTransactions()
        {
            Console.WriteLine("Enter Account ID:");
            string id = Console.ReadLine();

            Account accountResult = _accountRepository.GetAccountById(id);

            if (accountResult is null)
            {
                Console.WriteLine("No Such account found.");
            }
            else
            {
                Console.WriteLine($"Row ||        Date         ||   Event   ||   Value   || Balance  ");
                for (var i = 0;i < accountResult.Transactions.Count(); i++)
                {
                    Transaction row = accountResult.Transactions[i];
                    Console.WriteLine($"{i}   || {row.Date} || {row.Event} || {row.Value} || {row.Balance} ");
                }
                Console.WriteLine("---[ End of transactions ] --");
                Console.WriteLine();
            }

            ShowAccountInterfaceHome();
        }

        public void AccountTransfer()
        {
            Console.WriteLine("Enter Origin Account ID:");
            string originId = Console.ReadLine();

            Account originAccount = _accountRepository.GetAccountById(originId);

            if(originAccount == null) 
            {
                Console.WriteLine("Origin account not found.");
                return;
            }

            Console.WriteLine("Enter Destination Account ID:");
            string destinationId = Console.ReadLine();

            Account destinationAccount = _accountRepository.GetAccountById(destinationId);

            if (destinationAccount == null)
            {
                Console.WriteLine("Destination account not found.");
                return;
            }

            Console.WriteLine("Enter Amount to Transfer:");
            double amount = double.Parse(Console.ReadLine());

            if (amount <= originAccount.Balance)
            {
                originAccount.MakeWithdrawal(amount, "Transfer Withdrawal");
                destinationAccount.MakeDeposit(amount, "Transfer Deposit");
                Console.WriteLine("Transfer successful.");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }

            ShowAccountInterfaceHome();

        }

        public void Leave()
        {
            Environment.Exit(0);
        }
    }
}
