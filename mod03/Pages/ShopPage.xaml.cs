namespace mod03.Pages;

public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(ShopDetails));
        }
        catch (Exception ex)
        {
            // 可根據需求顯示錯誤訊息或記錄日誌
            await DisplayAlert("錯誤", ex.Message, "確定");
        }

    }
}