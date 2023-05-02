using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MySpots.Tests.Integration
{
    internal sealed class MySpotsTestApp : WebApplicationFactory<Program>
    {
        public HttpClient Client { get; }
        public MySpotsTestApp(Action<IServiceCollection> services)
        {
            Client = WithWebHostBuilder(builder =>
            {
                if (services is not null)
                {
                    builder.ConfigureServices(services);
                }
                builder.UseEnvironment("test");
            }).CreateClient();
        }

    }
}
