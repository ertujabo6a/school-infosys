using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;

namespace ICS.App.ViewModels;

[QueryProperty(nameof(Subject), nameof(Subject))]
public partial class SubjectEditViewModel(
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public SubjectDetailModel Subject { get; init; } = SubjectDetailModel.Empty;

    [RelayCommand]

    private async Task SaveAsync()
    {
        await subjectFacade.SaveAsync(Subject with { Activities = default!, Students = default! });
        MessengerService.Send(new SubjectEditMessage { SubjectId = Subject.Id });
        navigationService.SendBackButtonPressed();
    }
}
