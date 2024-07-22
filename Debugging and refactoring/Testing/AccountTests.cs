using DebuggingAndRefactoringTask1;

namespace Testing
{
    public class AccountTests
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
            var accounts = new List<Account>();
            var accountName = "UnitTestAccountName";
            var balance = 0;

            //act
            var account = new Account(accountName, balance);

            accounts.Add(account);

            //assert
            Assert.IsType<Account>(accounts[0]);
        }

    }
}