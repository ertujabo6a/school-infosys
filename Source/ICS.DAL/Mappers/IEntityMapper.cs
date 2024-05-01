using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public interface IEntityMapper<in TEntity> where TEntity : IEntity
{
    void Map(TEntity oldEntity, TEntity newEntity);
}
