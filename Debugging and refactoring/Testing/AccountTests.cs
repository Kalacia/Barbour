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
    }
}