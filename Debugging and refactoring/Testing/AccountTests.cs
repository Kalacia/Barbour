using DebuggingAndRefactoringTask1;
using Moq;

namespace Testing
{
    public class AccountTests : TestsBase
    {

        private IAccountRepository _accountRepository;

        [Fact]
        public void CreateAccountShouldCreateAFullyFormedAccount()
        {
            //arrange
            var accountName = "UnitTestAccountName";
            var accountBalance = 0;

            //act
            var account = new Account(accountName, accountBalance);

            //assert
            Assert.IsType<Account>(account);
            Assert.NotEmpty(account.Id);
            Assert.Equal(account.Name, accountName);
            Assert.Equal(account.Balance, accountBalance);
        }

        [Fact]
        public void GetAllAccountsShouldReturnAListAccountObject()
        {
            //arrange
            CreateWithSuccessfullMocks();
            var repo = _accountRepository;

            //act
            var result = repo.GetAllAccounts();

            //assert
            Assert.IsType<List<Account>>(result);
        }

        private Account CreateSuccessfulAccount(string name = "UnitTestAccountName")
        {
            var accountName = name;
            var balance = 0;

            var goodAccount = new Account(accountName, balance);

            return goodAccount;
        }

        private void CreateWithSuccessfullMocks()
        {
            //setup list and accounts to be passed into moq service
            List<Account> accounts = new List<Account>();

            var account1 = CreateSuccessfulAccount("UnitTestAccountName1");
            var account2 = CreateSuccessfulAccount("UnitTestAccountName2");
            var account3 = CreateSuccessfulAccount("UnitTestAccountName3");

            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);

            //create moq services
            SetupSuccessfulMocks(accounts);

            _accountRepository = MockServiceAccountRepository.Object;
        }
    }
}