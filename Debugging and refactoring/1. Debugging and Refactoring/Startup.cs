using Microsoft.Extensions.DependencyInjection;

namespace DebuggingAndRefactoringTask1
{
    public class Startup
    {
        public static IServiceProvider BuildContainer()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
