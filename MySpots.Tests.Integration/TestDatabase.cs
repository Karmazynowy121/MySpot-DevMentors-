using Microsoft.EntityFrameworkCore;
using MySpot.Infrastructure.DAL;

namespace MySpots.Tests.Integration
{
    internal class TestDatabase : IDisposable
    {
        public MySpotDbContext Context { get; }
        public TestDatabase()
        {
            var options = new OptionsProvider().Get<PostgresOptions>("posgres");
            Context = new MySpotDbContext(new DbContextOptionsBuilder<MySpotDbContext>()
                .UseNpgsql(options.ConnectionString).Options);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context?.Dispose();
        }
    }
}
