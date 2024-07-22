namespace DebuggingAndRefactoringTask1
{
    public interface IAccountRepository
    {
        public IEnumerable<Account> GetAllAccounts();
    }
}
