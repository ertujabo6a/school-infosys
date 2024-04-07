using Microsoft.EntityFrameworkCore.Design;

namespace ICS.DAL.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IcsDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new("ICS-2024-xkotvi01.db");

    public IcsDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}
