using ICS.DAL.Entities;

namespace ICS.DAL.Repositories;
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public IQueryable<TEntity> Get();
    public Task DeleteAsync(Guid entityId);
    public ValueTask<bool> ExistsAsync(TEntity entity);
    public ValueTask<TEntity> InsertAsync(TEntity entity);
    public ValueTask<TEntity> UpdateAsync(TEntity entity);
}
