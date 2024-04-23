using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;


public class StudentModelMapper(ISubjectModelMapper subjectModelMapper)
    : ModelMapperBase<StudentEntity, StudentDetailModel, StudentListModel>,
    IStudentModelMapper
{
    public override StudentDetailModel MapToListModel(StudentEntity? entity)
        => entity is null
        ? StudentDetailModel.Empty
        : new StudentDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            ImageUrl = entity.ImageUrl,
            Subjects = subjectModelMapper.MapToReferenceModel(entity.Subjects).ToObservableCollection()
        };

    public override StudentListModel MapToReferenceModel(StudentEntity? entity)
        => entity is null
        ? StudentListModel.Empty
        : new StudentListModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname
        };

    public override StudentEntity MapToEntity(StudentDetailModel list_model)
        => new()
        {
            Id = list_model.Id,
            Name = list_model.Name,
            Surname = list_model.Surname
        };
}
