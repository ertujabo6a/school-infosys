using ICS.DAL;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Factories;

public class DbContextSqLiteTestingFactory(string databaseName, bool seedTestingData = false)
    : IDbContextFactory<IcsDbContext>
{
    public IcsDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<IcsDbContext> builder = new();
        builder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        return new IcsTestingDbContext(builder.Options, seedTestingData);
    }
}
