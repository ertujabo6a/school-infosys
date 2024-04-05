using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class ActivityFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IActivityModelMapper modelMapper)
    : FacadeBase<ActivityEntity, ActivityListModel, ActivityReferenceModel, ActivityEntityMapper>(unitOfWorkFactory,
            modelMapper),
        IActivityFacade;
