namespace DebuggingAndRefactoringTask1
{
    public class AccountRepository : IAccountRepository
    {
        List<Account> accounts = new List<Account>();

        public IEnumerable<Account> GetAllAccounts() 
        {
             return accounts;
        }
    }
}
