using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interfaces;

public interface IActivityModelMapper
    : IModelMapper<ActivityEntity, ActivityListModel, ActivityReferenceModel>
{
}
