using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;


namespace ICS.App.ViewModels;

[QueryProperty(nameof(Evaluation), nameof(Evaluation))]
public partial class EvaluationEditViewModel(
    IEvaluationFacade evaluationFacade,
    IStudentFacade studentFacade,
    IActivityFacade activityFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public EvaluationDetailModel Evaluation { get; init; } = EvaluationDetailModel.Empty;
    public IList<StudentListModel> Students { get; set; }
    public IList<ActivityListModel> Activities { get; set; }
    public StudentListModel? SelectedStudent { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students = (await studentFacade.GetAsync()).ToList();
        Activities = (await activityFacade.GetAsync()).ToList();
        SelectedStudent = Students.Where(e => e.Id == Evaluation.StudentId).FirstOrDefault();
    }


    [RelayCommand]
    private async Task SaveAsync()
    {
        await evaluationFacade.SaveAsync(Evaluation);
        MessengerService.Send(new EvaluationEditMessage { EvaluationId = Evaluation.Id });
        navigationService.SendBackButtonPressed();
    }
}
