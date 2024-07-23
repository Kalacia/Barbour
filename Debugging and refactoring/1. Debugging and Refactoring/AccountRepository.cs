using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

        public string GetNewAccountId()
        {
            var accountsCount = _accounts.Count(); //used to deduce what the next ID will be

            int id = accountsCount + 1;

            return id.ToString();
        }

        public Account GetAccountById(string id)
        {
            var result = _accounts.Find(x => x.Id == id); //find id in accounts list
            return result;
        }
    }
}
