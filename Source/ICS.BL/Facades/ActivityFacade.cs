using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ICS.BL.Facades;

public class ActivityFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IActivityModelMapper modelMapper)
    : FacadeBase<ActivityEntity, ActivityListModel, ActivityDetailModel, ActivityEntityMapper>(unitOfWorkFactory,
            modelMapper), IActivityFacade
{
    public async Task<IEnumerable<ActivityListModel>> GetAsync(string? subject, DateTime start, DateTime end)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        List<ActivityEntity> activities = await uow
            .GetRepository<ActivityEntity, ActivityEntityMapper>()
            .Get()
            .Where(i => i.Subject.Abbr == (!string.IsNullOrEmpty(subject) ? subject : i.Subject.Abbr) && i.StartTime >= start && i.EndTime <= end)
            .ToListAsync().ConfigureAwait(false);

        return ModelMapper.MapToListModel(activities);
    }

    protected override ICollection<string> IncludesNavigationPathDetail =>
        [$"{nameof(ActivityEntity.Subject)}"];
}
