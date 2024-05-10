using CommunityToolkit.Mvvm.Input;
using ICS.App.Services;
using ICS.App.ViewModels.Student;

namespace ICS.App.Shells;

public partial class AppShell
{
    private readonly INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeComponent();
    }

    [RelayCommand]
    private async Task GoToStudentsAsync()
        => await _navigationService.GoToAsync<StudentListViewModel>();
}
