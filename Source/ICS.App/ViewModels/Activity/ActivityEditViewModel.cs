using CommunityToolkit.Mvvm.Input;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Models;

namespace ICS.App.ViewModels.Activity
{
    [QueryProperty(nameof(Ingredient), nameof(Ingredient))]
    public partial class ActivityEditViewModel(
        IActivityFacade activityFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : ViewModelBase(messengerService)
    {
        private readonly IMessengerService _messengerService = messengerService;

        public ActivityDetailModel Ingredient { get; init; } = ActivityDetailModel.Empty;

        [RelayCommand]
        private async Task SaveAsync()
        {
            await activityFacade.SaveAsync(Ingredient);

            _messengerService.Send(new ActivityEditMessage { ActivityId = Ingredient.Id });

            navigationService.SendBackButtonPressed();
        }
    }
}
