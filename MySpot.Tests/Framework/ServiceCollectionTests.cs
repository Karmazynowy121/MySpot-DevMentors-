


using Microsoft.Extensions.DependencyInjection;
using MySpot.Infrastructure.Services;
using Shouldly;
using Xunit;

namespace MySpot.Tests.Unit.Framework
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void test()
        {
            var serviceCollection = new ServiceCollection(); 
            serviceCollection.AddTransient<IMessenger, Messenger>();
            serviceCollection.AddSingleton<IMessenger, Messenger>();
            serviceCollection.AddScoped<Clock>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var messenger = serviceProvider.GetService<IMessenger>();
            messenger.Send();

            var messenger2 = serviceProvider.GetService<IMessenger>();
            messenger2.Send();

            messenger.ShouldNotBeNull();
            messenger2.ShouldNotBeNull();

        }

        public interface IMessenger
        {
            void Send();
        }

        public class Messenger : IMessenger
        {
            private readonly Guid _id = Guid.NewGuid();

            public void Send() => Console.WriteLine($"Sending a message... [{_id}]");

        }
    }
}
