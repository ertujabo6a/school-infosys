namespace ICS.BL.Mappers;

public abstract class ModelMapperBase<TEntity, TlistModel, TReferenceModel> : IModelMapper<TEntity, TlistModel, TReferenceModel>
{
    public abstract TlistModel MapToListModel(TEntity? entity);

    public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    public abstract TReferenceModel MapToReferenceModel(TEntity entity);

    public abstract TEntity MapToEntity(TReferenceModel ref_model);

}
