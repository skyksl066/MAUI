namespace mod03.Pages;

public partial class ShopDetails : ContentPage
{
	public ShopDetails()
	{
		InitializeComponent();
		Label1.Text = Shell.Current.CurrentState.Location.OriginalString + "/" + nameof(ShopDetails);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}