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
        Subjects = (await _subjectFacade.GetAsync()).Except(Student.Subjects);
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
        Subjects = (await _subjectFacade.GetAsync()).Except(Student.Subjects);
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await studentFacade.SaveAsync(Student with { Subjects = default! });
        _messengerService.Send(new StudentEditMessage { StudentId = Student.Id });
        navigationService.SendBackButtonPressed();
    }
}


