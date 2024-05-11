using ICS.App.ViewModels;
namespace ICS.App.Views.Activity;

public partial class ActivityListView
{
    public ActivityListView(ActivityListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}
