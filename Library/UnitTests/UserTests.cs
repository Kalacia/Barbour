using Library.Models;
using Library.Repositories;

namespace UnitTests
{
    public class UserTests : TestsBase
    {
        private IUserRepository _userRepository;

        [Fact]
        public void UserShouldReturnFromUserList()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var repo = _userRepository.GetAllUsers();

            //assert
            Assert.IsType<UserViewModel>(repo[0]);
        }

        private void CreateSuccessfulMoqs()
        {
            //setup list and accounts to be passed into moq service
            List<UserViewModel> users = new List<UserViewModel>();

            var user1 = new UserViewModel("Dave Test", true);

            users.Add(user1);

            //create moq services
            SetupSuccessfulUserMocks(users);

            _userRepository = MockServiceUserRepository.Object;
        }
    }
}