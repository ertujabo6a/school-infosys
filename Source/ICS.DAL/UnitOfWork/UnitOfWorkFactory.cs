using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.UnitOfWork;

public class UnitOfWorkFactory(IDbContextFactory<IcsDbContext> dbContextFactory) : IUnitOfWorkFactory
{
    public IUnitOfWork Create()
    {
        return new UnitOfWork(dbContextFactory.CreateDbContext());
    }
}
