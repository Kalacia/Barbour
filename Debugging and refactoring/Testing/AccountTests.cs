using DebuggingAndRefactoringTask1;

namespace Testing
{
    public class AccountTests : TestsBase
    {

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

        //[Fact]
        //public void GetAllAccountsShouldReturnAListAccouObject()
        //{
        //    //arrange
        //    var repo = CreateSuccessfulRepo();
        //    var account = CreateSuccessfulAccount();
        //    repo.InsertAccount(account);

        //    //act
        //    var result = repo.GetAllAccounts();

        //    //assert
        //    Assert.IsType<List<Account>>(result);
        //}

        private Account CreateSuccessfulAccount()
        {
            var accountName = "UnitTestAccountName";
            var balance = 0;

            var goodAccount = new Account(accountName, balance);

            return goodAccount;
        }

        private IAccountRepository CreateSuccessfulRepo()
        {
            SetupSuccessfulMocks();
            return MockServiceAccountRepository.Object;
        }

    }
}