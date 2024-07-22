using DebuggingAndRefactoringTask1;
using Moq;

namespace Testing
{
    public class TestsBase
    {
        protected readonly Mock<IServiceProvider> MockServiceProvider;
        protected readonly Mock<IAccountRepository> MockServiceAccountRepository;

        protected TestsBase()
        {
            MockServiceProvider = new Mock<IServiceProvider>();
            MockServiceAccountRepository = new Mock<IAccountRepository>();
        }
        protected void SetupSuccessfulMocks()
        {
            MockServiceProvider.Setup(x => x.GetService(typeof(IAccountRepository))).Returns(MockServiceAccountRepository.Object);
        }
    }
}
