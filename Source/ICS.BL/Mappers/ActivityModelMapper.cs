using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers
{
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
                    SubjectAbbr = entity.Subject?.Abbr ?? string.Empty, // Null check for Subject
                    Type = entity.Type,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime
                };

        public override ActivityDetailModel MapToDetailModel(ActivityEntity? entity)
            => entity is null
                ? ActivityDetailModel.Empty
                : new ActivityDetailModel
                {
                    Id = entity.Id,
                    SubjectId = entity.SubjectId,
                    SubjectAbbr = entity.Subject?.Abbr ?? string.Empty, // Null check for Subject
                    Type = entity.Type,
                    ActivityRoom = entity.Room,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    Description = entity.Description
                };

        public override ActivityEntity MapToEntity(ActivityDetailModel detailModel)
            => new()
            {
                Id = detailModel.Id,
                Type = detailModel.Type,
                Room = detailModel.ActivityRoom,
                StartTime = detailModel.StartTime,
                EndTime = detailModel.EndTime,
                Description = detailModel.Description,
                SubjectId = detailModel.SubjectId,
                Subject = null! // Assuming Subject is set elsewhere after mapping
            };
    }
}
