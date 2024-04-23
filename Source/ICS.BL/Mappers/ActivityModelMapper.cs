using System;
using System.Collections.ObjectModel;
using ICS.Common.Tests.Seeds;
using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class ActivityModelMapper
    : ModelMapperBase<ActivityEntity, ActivityDetailModel, ActivityListModel>,
    IActivityModelMapper
{
    public override ActivityDetailModel MapToListModel(ActivityEntity? entity)
        => entity is null
            ? ActivityDetailModel.Empty
            : new ActivityDetailModel
            {
                Id = entity.Id,
                Type = entity.Type,
                ActivityRoom = entity.Room,
                StartDate = entity.StartTime,
                EndDate = entity.EndTime,
                SubjectAbbr = entity.Subject?.Abbr ?? string.Empty
            };

    public override ActivityListModel MapToReferenceModel(ActivityEntity? entity)
        => entity is null
            ? ActivityListModel.Empty
            : new ActivityListModel
            {
                Id = entity.Id,
                Type = entity.Type
            };

    public override ActivityEntity MapToEntity(ActivityDetailModel list_model)
        => new()
        {
            Id = list_model.Id,
            Type = list_model.Type,
            Room = list_model.ActivityRoom,
            StartTime = list_model.StartDate,
            EndTime = list_model.EndDate,
            Subject = null!,
            SubjectId = SubjectSeeds.SubjectEntity.Id
        };
}
