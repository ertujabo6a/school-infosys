namespace ICS.BL.Mappers.Interfaces;

public interface IModelMapper<TEntity, out TListModel, TReferenceModel>
{
    TListModel MapToListModel(TEntity? entity);

    //Maps a collectioon of Entities to a collection of ListModels
    IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    TReferenceModel MapToReferenceModel(TEntity entity);
    //Maps a collectioon of Entities to a collection of ListModels
    IEnumerable<TReferenceModel> MapToReferenceModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToReferenceModel);

    TEntity MapToEntity(TReferenceModel ref_model);
}
