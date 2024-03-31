using System;
using System.Collections.ObjectModel;
using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class ActivityModelMapper
    : ModelMapperBase<ActivityEntity, ActivityListModel, ActivityReferenceModel>,
    IActivityModelMapper
{
    public override ActivityListModel MapToListModel(ActivityEntity? entity)
        => entity is null
            ? ActivityListModel.Empty
            : new ActivityListModel
            {
                Id = entity.Id,
                Type = entity.Type,
                SubjectAbbr = entity.Subject.Abbr,
                ActivityRoom = entity.Room,
                StartDate = entity.StartTime,
                EndDate = entity.EndTime

            };

    public override ActivityReferenceModel MapToReferenceModel(ActivityEntity? entity)
        => entity is null
            ? ActivityReferenceModel.Empty
            : new ActivityReferenceModel
            {
                Id = entity.Id,
                Type = entity.Type
            };

    public override ActivityEntity MapToEntity(ActivityListModel list_model)
        => new()
        {
            Id = list_model.Id,
            Type = list_model.Type,
            Room = list_model.ActivityRoom,
            StartTime = list_model.StartDate,
            EndTime = list_model.EndDate,
            Subject = null,
            SubjectId = default
        };
}
