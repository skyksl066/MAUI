using mod09.ViewModels;

namespace mod09.Views;

public partial class PetView : ContentPage
{
	private readonly PetViewModel _viewModel;
    public PetView(PetViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}