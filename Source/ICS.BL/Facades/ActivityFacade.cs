
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class ActivityFacade : FacadeBase<ActivityEntity, ActivityListModel, ActivityReferenceModel, ActivityEntityMapper>,
    IActivityFacade
{
    public ActivityFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IActivityModelMapper modelMapper) : base(unitOfWorkFactory, modelMapper)
    { }
}
