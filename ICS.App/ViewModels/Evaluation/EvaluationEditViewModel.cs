using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;
using ICS.BL.Facades;


namespace ICS.App.ViewModels;

[QueryProperty(nameof(Evaluation), nameof(Evaluation))]
public partial class EvaluationEditViewModel(
    IEvaluationFacade evaluationFacade,
    IStudentFacade studentFacade,
    IActivityFacade activityFacade,
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public EvaluationDetailModel Evaluation { get; init; } = EvaluationDetailModel.Empty;
    public IList<StudentListModel> Students { get; set; }
    [ObservableProperty]
    private StudentListModel _selectedStudent;
    public IList<ActivityListModel> Activities { get; set; }
    [ObservableProperty]
    private ActivityListModel _selectedActivity;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students = (await studentFacade.GetAsync()).ToList();
        Activities = (await activityFacade.GetAsync()).ToList();
        foreach (ActivityListModel e in Activities)
        {
            SubjectDetailModel? subjectDetailModel = await subjectFacade.GetAsync(e.SubjectId);
            if (subjectDetailModel != null)
            {
                e.SubjectAbbr = subjectDetailModel.SubjectAbbr;
            }
        }
        Activities = Activities.ToList();
    }

    partial void OnSelectedStudentChanged(StudentListModel value)
    {
        if (value == null) return;
        else
        {
            Evaluation.StudentId = value.Id;
        }
    }

    partial void OnSelectedActivityChanged(ActivityListModel value)
    {
        if (value == null) return;
        else
        {
            Evaluation.ActivityId = value.Id;
        }
    }


    [RelayCommand]
    private async Task SaveAsync()
    {
        await evaluationFacade.SaveAsync(Evaluation);
        MessengerService.Send(new EvaluationEditMessage { EvaluationId = Evaluation.Id });
        navigationService.SendBackButtonPressed();
    }
}
