using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Repositories;
using ICS.DAL.UnitOfWork;
using ICS.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection;

namespace ICS.BL.Facades;

public abstract class
    FacadeBase<TEntity, TListModel, TReferenceModel, TEntityMapper>
    where TEntity : class, IEntity
    where TListModel : IModel
    where TReferenceModel : class, IModel
    where TEntityMapper : IEntityMapper<TEntity>, new()
{
    protected readonly IModelMapper<TEntity, TListModel, TReferenceModel> ModelMapper;
    protected readonly IUnitOfWorkFactory UnitOfWorkFactory;

    protected FacadeBase(IUnitOfWorkFactory unitOfWorkFactory, IModelMapper<TEntity, TListModel, TReferenceModel> modelMapper)
    {
        UnitOfWorkFactory = unitOfWorkFactory;
        ModelMapper = modelMapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        try
        {
           await uow.GetRepository<TEntity, TEntityMapper>().DeleteAsync(id).ConfigureAwait(false);
            await uow.CommitAsync().ConfigureAwait(false);
        }
        catch (DbUpdateException e)
        {
            throw new InvalidOperationException("Entity deletion failed.", e);
        }
    }

    public virtual async Task<TReferenceModel?> GetAsync(Guid id)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<TEntity> querry = uow.GetRepository<TEntity, TEntityMapper>().Get();

        TEntity? entity = await querry.SingleOrDefaultAsync(e => e.Id == id);

        return entity is null? null : ModelMapper.MapToReferenceModel(entity);
    }

    public virtual async Task<IEnumerable<TListModel>> GetAsync()
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        List<TEntity> entities = await uow.GetRepository<TEntity, TEntityMapper>().Get().ToListAsync();

        return ModelMapper.MapToListModel(entities);
    }

    public async Task<TReferenceModel> SaveAsync(TReferenceModel model)
    {
        TReferenceModel result;
        GuardCollectionsAreNotSet(model);
        TEntity entity = ModelMapper.MapToEntity(model);
        IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<TEntity> repository = uow.GetRepository<TEntity, TEntityMapper>();

        if(await repository.ExistsAsync(entity))
        {
            TEntity updateEntity = await repository.UpdateAsync(entity);
            result = ModelMapper.MapToReferenceModel(updateEntity);
        }
        else
        {
            entity.Id = Guid.NewGuid();
            TEntity insertedEntity = await repository.InsertAsync(entity);
            result = ModelMapper.MapToReferenceModel(insertedEntity);
        }

        await uow.CommitAsync();

        return result;

    }

    /// <summary>
    /// This Guard ensures that there is a clear understanding of current infrastructure limitations.
    /// This version of BL/DAL infrastructure does not support insertion or update of adjacent entities.
    /// WARN: Does not guard navigation properties.
    /// </summary>
    /// <param name="model">Model to be inserted or updated</param>
    /// <exception cref="InvalidOperationException"></exception>
    private static void GuardCollectionsAreNotSet(TReferenceModel model)
    {
        IEnumerable<PropertyInfo> collectionProperties = model
            .GetType()
            .GetProperties()
            .Where(i => typeof(ICollection).IsAssignableFrom(i.PropertyType));

        foreach (PropertyInfo collectionProperty in collectionProperties)
        {
            if (collectionProperty.GetValue(model) is ICollection { Count: > 0 })
            {
                throw new InvalidOperationException(
                    "Current BL and DAL infrastructure disallows insert or update of models with adjacent collections.");
            }
        }
    }
}
