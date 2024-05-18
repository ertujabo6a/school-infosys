using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Factories;

public class DbContextSqLiteFactory : IDbContextFactory<IcsDbContext>
{
    private readonly bool _seedTestingData;
    private readonly DbContextOptionsBuilder<IcsDbContext> _contextOptionsBuilder = new();

    public DbContextSqLiteFactory(string databaseName, bool seedTestingData)
    {
        _seedTestingData = seedTestingData;
        _contextOptionsBuilder.UseSqlite($"Data Source={databaseName};Cache=Shared");
    }

    public IcsDbContext CreateDbContext() => new(_contextOptionsBuilder.Options, _seedTestingData);
}
