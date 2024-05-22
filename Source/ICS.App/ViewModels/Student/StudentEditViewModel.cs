using CommunityToolkit.Mvvm.Input;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Models;

namespace ICS.App.ViewModels;


[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentEditViewModel(
    IStudentFacade studentFacade,
    ISubjectFacade subjectFacade,
    IStudentToSubjectFacade studentToSubjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    private readonly IMessengerService _messengerService = messengerService;
    private readonly ISubjectFacade _subjectFacade = subjectFacade;

    public IEnumerable<SubjectListModel> Subjects { get; private set; } = null!;

    public StudentDetailModel Student { get; init; } = StudentDetailModel.Empty;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        var tmpSubject = await _subjectFacade.GetAsync();
        var freeSubjects = new List<SubjectListModel>();
        foreach (SubjectListModel subjectListModel in tmpSubject)
        {
            bool isInStudentSubjects = false;
            foreach (SubjectListModel studentSubject in Student.Subjects)
                if (studentSubject.Id == subjectListModel.Id)
                {
                    isInStudentSubjects = true;
                    break;
                }
            if (!isInStudentSubjects)
                freeSubjects.Add(subjectListModel);
        }
        Subjects = freeSubjects;
    }

    [RelayCommand]
    private void ChooseSubject(SubjectListModel subject)
    {
        Student.Subjects.Add(subject);
        Subjects = Subjects.Where(s => s.Id != subject.Id);
    }

    [RelayCommand]
    private async Task UnchooseSubject(SubjectListModel subject)
    {
        Student.Subjects.Remove(subject);
        var tmpSubject = await _subjectFacade.GetAsync();
        var freeSubjects = new List<SubjectListModel>();
        foreach (SubjectListModel subjectListModel in tmpSubject)
        {
            bool isInStudentSubjects = false;
            foreach (SubjectListModel studentSubject in Student.Subjects)
                if (studentSubject.Id == subjectListModel.Id)
                {
                    isInStudentSubjects = true;
                    break;
                }
            if (!isInStudentSubjects)
                freeSubjects.Add(subjectListModel);
        }
        Subjects = freeSubjects;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        var savedStudent = await studentFacade.SaveAsync(Student with { Subjects = default! });
        await studentToSubjectFacade.SaveAsync(savedStudent with { Subjects = Student.Subjects });
        _messengerService.Send(new StudentEditMessage { StudentId = Student.Id });
        navigationService.SendBackButtonPressed();
    }
}


