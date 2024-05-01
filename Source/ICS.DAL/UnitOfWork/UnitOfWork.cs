using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.UnitOfWork;

public sealed class UnitOfWork(DbContext dbContext) : IUnitOfWork
{

    public IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
        where TEntity : class, IEntity
        where TEntityMapper : IEntityMapper<TEntity>, new()
    {
        return new Repository<TEntity>(dbContext, new TEntityMapper());
    }

    public async Task CommitAsync() => await dbContext.SaveChangesAsync().ConfigureAwait(false);

    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync().ConfigureAwait(false);
}

