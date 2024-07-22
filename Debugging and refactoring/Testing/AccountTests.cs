using DebuggingAndRefactoringTask1;

namespace Testing
{
    public class AccountTests
    {
        [Fact]
        public void AccountShouldHaveGuidID()
        {
            //arrange
            var account = new Account();

            //act

            //assert
            Assert.NotEmpty(account.Id);
            
        }
    }
}