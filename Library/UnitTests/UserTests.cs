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

        [Fact]
        public void GetUserByNameShouldReturnSingleResult()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var user = _userRepository.GetUserByName("Dave Test");

            //assert
            Assert.IsType<UserViewModel>(user);
            Assert.Equal("Dave Test", user.Name);
        }

        private void CreateSuccessfulMoqs()
        {
            //setup list to be passed into moq service
            List<UserViewModel> users = new List<UserViewModel>();

            var user1 = new UserViewModel("Dave Test", true);

            users.Add(user1);

            //create moq services
            SetupSuccessfulUserMocks(users);

            _userRepository = MockServiceUserRepository.Object;
        }
    }
}