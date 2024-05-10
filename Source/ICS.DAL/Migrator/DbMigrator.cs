using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Migrator;

public class DbMigrator(IDbContextFactory<IcsDbContext> dbContextFactory, DALOptions options) : IDbMigrator
{
    public void Migrate() => MigrateAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await using IcsDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        if (options.RecreateDatabaseEachTime)
        {
            await dbContext.Database.EnsureDeletedAsync(cancellationToken);
        }
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
}
