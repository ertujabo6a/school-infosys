using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Facades;
public interface IFacade<TEntity, TListModel, TReferenceModel>
    where TEntity : class, IEntity
    where TListModel : IModel
    where TReferenceModel : class, IModel
{
    Task DeleteAsync(Guid id);
    Task<TReferenceModel?> GetAsync(Guid id);
    Task<IEnumerable<TListModel>> GetAsync();
    Task<TListModel> SaveAsync(TListModel model);
}
