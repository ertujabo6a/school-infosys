using CookBook.BL.Facades;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ICS.BL.Facades;
public class SubjectFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    ISubjectModelMapper modelMapper)
    : FacadeBase<SubjectEntity, SubjectListModel, SubjectDetailModel, SubjectEntityMapper>(unitOfWorkFactory,
        modelMapper), ISubjectFacade
{
    public async Task<IEnumerable<SubjectListModel>> GetAsync(string? abbr, bool order)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        List<SubjectEntity> subjects = await uow
                .GetRepository<SubjectEntity, SubjectEntityMapper>()
        .Get()
        .Where(i => i.Abbr == (!string.IsNullOrEmpty(abbr) ? abbr : i.Abbr))
        .ToListAsync().ConfigureAwait(false);

        if (order)
            subjects = (List<SubjectEntity>)subjects.OrderBy(i => i.Abbr);

        return ModelMapper.MapToListModel(subjects);
    }
    protected override ICollection<string> IncludesNavigationPathDetail =>
        [$"{nameof(SubjectEntity.Students)}", $"{nameof(SubjectEntity.Activities)}"];
}
