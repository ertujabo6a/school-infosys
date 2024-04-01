using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;


public class StudentModelMapper(ISubjectModelMapper subjectModelMapper)
    : ModelMapperBase<StudentEntity, StudentListModel, StudentReferenceModel>,
    IStudentModelMapper
{
    public override StudentListModel MapToListModel(StudentEntity? entity)
        => entity is null
        ? StudentListModel.Empty
        : new StudentListModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            ImageUrl = entity.ImageUrl,
            Subjects = subjectModelMapper.MapToReferenceModel(entity.Subjects).ToObservableCollection()
        };

    public override StudentReferenceModel MapToReferenceModel(StudentEntity? entity)
        => entity is null
        ? StudentReferenceModel.Empty
        : new StudentReferenceModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname
        };

    public override StudentEntity MapToEntity(StudentListModel list_model)
        => new()
        {
            Id = list_model.Id,
            Name = list_model.Name,
            Surname = list_model.Surname
        };
}
