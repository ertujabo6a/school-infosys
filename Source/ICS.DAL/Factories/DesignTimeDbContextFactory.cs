using Microsoft.EntityFrameworkCore.Design;

namespace ICS.DAL.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IcsDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new("ics.db", true);

    public IcsDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}
