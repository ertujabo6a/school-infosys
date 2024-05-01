using ICS.Common.Tests.Seeds;
using ICS.DAL;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests;

public class IcsTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
    : IcsDbContext(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (seedTestingData)
        {
            StudentSeeds.Seed(modelBuilder);
            SubjectSeeds.Seed(modelBuilder);
            ActivitySeeds.Seed(modelBuilder);
            EvaluationSeeds.Seed(modelBuilder);
        }
    }
}
