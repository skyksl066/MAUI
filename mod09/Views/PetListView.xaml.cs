using mod09.ViewModels;

namespace mod09.Views;

public partial class PetListView : ContentPage
{
	private readonly PetListViewModel _viewModel;
    public PetListView(PetListViewModel petListViewModel)
	{
		InitializeComponent();
        _viewModel = petListViewModel;
        BindingContext = _viewModel;
	}

    protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetPetsCommand.Execute(null);
    }
}