using Library.Models;

namespace UnitTests
{
    public class UserTests
    {
        [Fact]
        public void UserShouldReturnFromUserList()
        {
            //arrange
            var user = new UserViewModel();

            //act


            //assert
            Assert.NotNull(user);

        }
    }
}