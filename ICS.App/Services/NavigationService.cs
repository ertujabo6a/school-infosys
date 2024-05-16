using ICS.App.ViewModels;
using ICS.App.Views.Activity;
using ICS.App.Views.Evaluation;
using ICS.App.Views.Student;
using ICS.App.Views.Subject;

namespace ICS.App.Services;

public class NavigationService : INavigationService
{
    public IEnumerable<RouteModel> Routes { get; } = new List<RouteModel>
    {
        new("//students", typeof(StudentListView), typeof(StudentListViewModel)),

        new("//subjects", typeof(SubjectListView), typeof(SubjectListViewModel)),

        new("//activities", typeof(ActivityListView), typeof(ActivityListViewModel)),

        new("//evaluations", typeof(EvaluationListView), typeof(EvaluationListViewModel)),
        new("//evaluations/detail", typeof(EvaluationDetailView), typeof(EvaluationDetailViewModel)),

        new("//evaluations/edit", typeof(EvaluationEditView), typeof(EvaluationEditViewModel)),
        new("//evaluations/detail/edit", typeof(EvaluationEditView), typeof(EvaluationEditViewModel))
    };

    public async Task GoToAsync<TViewModel>()
        where TViewModel : IViewModel
    {
        var route = GetRouteByViewModel<TViewModel>();
        await Shell.Current.GoToAsync(route);
    }
    public async Task GoToAsync<TViewModel>(IDictionary<string, object?> parameters)
        where TViewModel : IViewModel
    {
        var route = GetRouteByViewModel<TViewModel>();
        await Shell.Current.GoToAsync(route, parameters);
    }

    public async Task GoToAsync(string route)
        => await Shell.Current.GoToAsync(route);

    public async Task GoToAsync(string route, IDictionary<string, object?> parameters)
        => await Shell.Current.GoToAsync(route, parameters);

    public bool SendBackButtonPressed()
        => Shell.Current.SendBackButtonPressed();

    private string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel 
        => Routes.First(route => route.ViewModelType == typeof(TViewModel)).Route;
}
