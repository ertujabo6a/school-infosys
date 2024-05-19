using CommunityToolkit.Mvvm.Input;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Models;

namespace ICS.App.ViewModels;


[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentEditViewModel(
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    private readonly IMessengerService _messengerService = messengerService;

    public StudentDetailModel Student { get; init; } = StudentDetailModel.Empty;

    [RelayCommand]
    private async Task SaveAsync()
    {
        await studentFacade.SaveAsync(Student);

        _messengerService.Send(new StudentEditMessage { StudentId = Student.Id });

        navigationService.SendBackButtonPressed();
    }
}


