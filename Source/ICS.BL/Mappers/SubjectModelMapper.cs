using System;
using System.Collections.ObjectModel;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class SubjectModelMapper
    : ModelMapperBase<SubjectEntity, SubjectDetailModel, SubjectListModel>,
    ISubjectModelMapper
{
    public override SubjectDetailModel MapToListModel(SubjectEntity? entity)
        => entity is null
        ? SubjectDetailModel.Empty
        : new SubjectDetailModel
        {
            Id = entity.Id,
            SubjectName = entity.Name,
            SubjectAbbr = entity.Abbr,
            Credits = entity.Credits
        };

    public override SubjectListModel MapToReferenceModel(SubjectEntity? entity)
        => entity is null
        ? SubjectListModel.Empty
        : new SubjectListModel
        {
            Id = entity.Id,
            SubjectAbbr = entity.Abbr
        };

    public override SubjectEntity MapToEntity(SubjectDetailModel list_model)
        => new()
        {
            Id = list_model.Id,
            Abbr = list_model.SubjectAbbr,
            Name = list_model.SubjectName,
            Credits = list_model.Credits
        };
}
