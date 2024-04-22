using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Migrator;

public class DbMigrator(IDbContextFactory<IcsDbContext> dbContextFactory) : IDbMigrator
{
    public void Migrate() => MigrateAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await using IcsDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
    }
}
