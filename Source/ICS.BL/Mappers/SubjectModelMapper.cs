using System;
using System.Collections.ObjectModel;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class SubjectModelMapper
    : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectReferenceModel>,
    ISubjectModelMapper
{
    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
        ? SubjectListModel.Empty
        : new SubjectListModel
        {
            Id = entity.Id,
            SubjectName = entity.Name,
            SubjectAbbr = entity.Abbr,
            Credits = entity.Credits
        };

    public override SubjectReferenceModel MapToReferenceModel(SubjectEntity? entity)
        => entity is null
        ? SubjectReferenceModel.Empty
        : new SubjectReferenceModel
        {
            Id = entity.Id,
            SubjectAbbr = entity.Abbr
        };

    public override SubjectEntity MapToEntity(SubjectReferenceModel ref_model)
        => new() { Id = ref_model.Id,  Abbr = ref_model.SubjectAbbr };
}
