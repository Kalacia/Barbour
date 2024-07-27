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
            Assert.IsType<User>(repo[0]);
        }

        [Fact]
        public void GetUserByNameShouldReturnSingleResult()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var user = _userRepository.GetUserByName("Dave Test");

            //assert
            Assert.IsType<User>(user);
            Assert.Equal("Dave Test", user.Name);
        }

        [Fact]
        public void UserUpdateNameShouldUpdateUsersName()
        {
            //arrange
            CreateSuccessfulMoqs();

            //act
            var user = _userRepository.GetUserByName("Dave Test");
            user.UpdateName("Jane Test");

            //assert
            Assert.Equal("Jane Test", user.Name);
        }

        private void CreateSuccessfulMoqs()
        {
            //setup list to be passed into moq service
            List<User> users = new List<User>();

            var user1 = new User("Dave Test", true);

            users.Add(user1);

            //create moq services
            SetupSuccessfulUserMocks(users);

            _userRepository = MockServiceUserRepository.Object;
        }
    }
}