using DebuggingAndRefactoringTask1;

namespace BankingSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            var accountManager = new AccountManager();//moved code from here to another class, so i can do dependency injection, and not clutter Main.

            accountManager.ShowAccountInterfaceHome();
        }
    }
}
