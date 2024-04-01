using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class EvaluationFacade : FacadeBase<EvaluationEntity, EvaluationListModel, EvaluationListModel, EvaluationEntityMapper>,
    IEvaluationFacade
{
    public EvaluationFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IEvaluationModelMapper modelMapper) : base(unitOfWorkFactory, modelMapper)
    { }
}
