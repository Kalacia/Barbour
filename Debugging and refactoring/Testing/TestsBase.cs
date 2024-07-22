using DebuggingAndRefactoringTask1;
using Moq;
using System.Security.Principal;
using Xunit.Abstractions;

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
        protected void SetupSuccessfulMocks(List<Account> accounts, Account account)
        {
            MockServiceProvider.Setup(x => x.GetService(typeof(IAccountRepository))).Returns(MockServiceAccountRepository.Object);

            MockServiceAccountRepository.Setup(x => x.GetAllAccounts()).Returns(accounts);

            MockServiceAccountRepository.Setup(x => x.InsertAccount(account));
        }
        protected void SetupSuccessfulMocks(List<Account> accounts)
        {
            MockServiceProvider.Setup(x => x.GetService(typeof(IAccountRepository))).Returns(MockServiceAccountRepository.Object);

            MockServiceAccountRepository.Setup(x => x.GetAllAccounts()).Returns(accounts);
        }
    }
}
