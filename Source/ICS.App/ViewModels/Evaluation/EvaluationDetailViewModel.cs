using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;

namespace ICS.App.ViewModels.Evaluation;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class EvaluationDetailViewModel(
    IEvaluationFacade evaluationFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<EvaluationEditMessage>
{
    public Guid Id { get; set; }
    public EvaluationDetailModel? Evaluation { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Evaluation = await evaluationFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Evaluation != null)
        {
            await evaluationFacade.DeleteAsync(Evaluation.Id);
            MessengerService.Send(new EvaluationDeleteMessage());
            navigationService.SendBackButtonPressed();
        }
    }


    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if (Evaluation is not null)
        {
            await navigationService.GoToAsync("/edit",
                new Dictionary<string, object?> { [nameof(EvaluationEditViewModel.Evaluation)] = Evaluation});
        }
    }

    public async void Receive(EvaluationEditMessage message)
    {
        if (message.EvaluationId == Evaluation?.Id)
        {
            await LoadDataAsync();
        }
    }
}
