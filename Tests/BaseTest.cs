using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests
{
    public class BaseTest
    {
        protected Logger Logger { get; }

        public BaseTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            Logger = new Logger(factory.CreateLogger<Logger>());
        }
    }
}