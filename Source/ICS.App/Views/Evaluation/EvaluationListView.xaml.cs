using ICS.App.ViewModels;

namespace ICS.App.Views.Evaluation;

public partial class EvaluationListView
{
    public EvaluationListView(EvaluationListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}
