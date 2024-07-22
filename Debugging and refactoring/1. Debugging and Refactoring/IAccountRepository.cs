namespace DebuggingAndRefactoringTask1
{
    public interface IAccountRepository
    {
        public List<Account> GetAllAccounts();
        public void InsertAccount(Account account);
    }
}
