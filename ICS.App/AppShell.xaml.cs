using CommunityToolkit.Mvvm.Input;
using ICS.App.Services;
using ICS.App.ViewModels;

namespace ICS.App;

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

    [RelayCommand]
    private async Task GoToSubjectsAsync()
        => await _navigationService.GoToAsync<SubjectListViewModel>();

    [RelayCommand]
    private async Task GoToActivitiesAsync()
        => await _navigationService.GoToAsync<ActivityListViewModel>();

    [RelayCommand]
    private async Task GoToEvaluationsAsync()
        => await _navigationService.GoToAsync<EvaluationListViewModel>();
}
