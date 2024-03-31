using ICS.BL.Mappers.Interfaces;

namespace ICS.BL.Mappers;

public abstract class ModelMapperBase<TEntity, TListModel, TReferenceModel> : IModelMapper<TEntity, TListModel, TReferenceModel>
{
    public abstract TListModel MapToListModel(TEntity? entity);

    public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    public abstract TReferenceModel MapToReferenceModel(TEntity entity);

    public IEnumerable<TReferenceModel> MapToReferenceModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToReferenceModel);

    public abstract TEntity MapToEntity(TListModel list_model);


}


