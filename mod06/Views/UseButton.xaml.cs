namespace mod06.Views;

public partial class UseButton : ContentPage
{
	public UseButton()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e) =>
        Label1.Text = $"Clicked: {DateTime.Now}";    

    private void Button_Pressed(object sender, EventArgs e) =>
        Label2.Text = $"Pressed: {DateTime.Now}";

    private void Button_Released(object sender, EventArgs e) =>
        Label3.Text = $"Released: {DateTime.Now}";

    private async void btnCafe_ClickedAsync(object sender, EventArgs e)
    {
        await DisplayAlert("咖啡機", "你的卡布奇諾", "Thanks!");
    }
}