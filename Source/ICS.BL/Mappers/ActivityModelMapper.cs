using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class ActivityModelMapper
    : ModelMapperBase<ActivityEntity, ActivityListModel, ActivityDetailModel>,
    IActivityModelMapper
{
    public override ActivityListModel MapToListModel(ActivityEntity? entity)
        => entity is null
            ? ActivityListModel.Empty
            : new ActivityListModel
            {
                Id = entity.Id,
                Type = entity.Type
            };

    public override ActivityDetailModel MapToDetailModel(ActivityEntity? entity)
        => entity is null
            ? ActivityDetailModel.Empty
            : new ActivityDetailModel
            {
                Id = entity.Id,
                SubjectId = entity.SubjectId,
                SubjectAbbr = entity.Subject.Abbr,
                Type = entity.Type,
                ActivityRoom = entity.Room,
                StartDate = entity.StartTime,
                EndDate = entity.EndTime,
                Description = entity.Description
            };


    public override ActivityEntity MapToEntity(ActivityDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            Type = detailModel.Type,
            Room = detailModel.ActivityRoom,
            StartTime = detailModel.StartDate,
            EndTime = detailModel.EndDate,
            Description = detailModel.Description,
            SubjectId = detailModel.SubjectId,
            Subject = null!
        };
}
