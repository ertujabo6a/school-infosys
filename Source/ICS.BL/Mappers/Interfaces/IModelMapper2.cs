namespace ICS.BL.Mappers.Interfaces;

public interface IModelMapper2<TEntity, TListModel>
{
    TListModel MapToListModel(TEntity? entity);

    //Maps a collectioon of Entities to a collection of ListModels
    IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    TEntity MapToEntity(TListModel list_model);
}
