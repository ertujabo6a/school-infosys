using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ICS.BL.Facades;
public class EvaluationFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IEvaluationModelMapper modelMapper)
    : FacadeBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel, EvaluationEntityMapper>(unitOfWorkFactory,
            modelMapper),
        IEvaluationFacade
{
    public async Task<IEnumerable<EvaluationListModel>> GetAsync(string? orderBy)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        List<EvaluationEntity> entities = await uow
            .GetRepository<EvaluationEntity, EvaluationEntityMapper>()
            .Get()
            .ToListAsync().ConfigureAwait(false);

        if (!string.IsNullOrEmpty(orderBy))
            switch (orderBy.ToLower())
            {
                case "name":
                    entities = (List<EvaluationEntity>)entities.OrderBy(i => i.Student.Name);
                    break;
                case "surname":
                    entities = (List<EvaluationEntity>)entities.OrderBy(i => i.Student.Surname);
                    break;
                case "activity":
                    entities = (List<EvaluationEntity>)entities.OrderBy(i => i.Activity.Type);
                    break;
                case "points":
                    entities = (List<EvaluationEntity>)entities.OrderBy(i => i.Points);
                    break;
            }

        return ModelMapper.MapToListModel(entities);
    }

    protected override ICollection<string> IncludesNavigationPathDetail =>
        [$"{nameof(EvaluationEntity.Activity)}.{nameof(ActivityEntity.Subject)}", $"{nameof(EvaluationEntity.Student)}"];
}
