using Library.Models;
using Library.Repositories;
using Moq;

namespace UnitTests
{
    public class TestsBase
    {
        protected readonly Mock<IServiceProvider> MockServiceProvider;
        protected readonly Mock<IUserRepository> MockServiceUserRepository;

        protected TestsBase()
        {
            MockServiceProvider = new Mock<IServiceProvider>();
            MockServiceUserRepository = new Mock<IUserRepository>();
        }

        protected void SetupSuccessfulUserMocks(List<UserViewModel> users)
        {
            MockServiceProvider.Setup(x => x.GetService(typeof(IUserRepository))).Returns(MockServiceUserRepository.Object);

            MockServiceUserRepository.Setup(x => x.GetAllUsers()).Returns(users);

            MockServiceUserRepository.Setup(x => x.GetUserByName("Dave Test")).Returns(users.Find(x => x.Name == "Dave Test"));

            MockServiceUserRepository.Setup(x => x.GetUserByName("Jane Test")).Returns(users.Find(x => x.Name == "Jane Test"));
        }
    }
}
