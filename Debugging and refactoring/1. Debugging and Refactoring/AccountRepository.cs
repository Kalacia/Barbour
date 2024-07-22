namespace DebuggingAndRefactoringTask1
{
    public class AccountRepository : IAccountRepository
    {
        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public List<Account> GetAllAccounts() 
        {
            return _accounts;
        }

        public void InsertAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}
