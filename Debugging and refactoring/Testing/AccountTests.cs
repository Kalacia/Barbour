using DebuggingAndRefactoringTask1;

namespace Testing
{
    public class AccountTests : TestsBase
    {
        [Fact]
        public void AccountShouldHaveGuidID()
        {
            //arrange
            var accountName = "UnitTestAccountName";
            var balance = 0;

            //act
            var account = new Account(accountName, balance);

            //assert
            Assert.NotEmpty(account.Id);
        }

        [Fact]
        public void GetAllAccountsShouldReturnPopulatedList()
        {
            //arrange
            var accountName = "UnitTestAccountName";
            var balance = 0;
            var repo = CreateSuccessfulRepo();

            //act
            var account = new Account(accountName, balance);
            repo.InsertAccount(account);

            //assert
            Assert.IsType<Account>(repo);
        }

        private IAccountRepository CreateSuccessfulRepo()
        {
            SetupSuccessfulMocks();
            return MockServiceAccountRepository.Object;
        }

    }
}