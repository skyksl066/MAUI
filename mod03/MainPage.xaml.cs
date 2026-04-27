using System.Threading.Tasks;

namespace mod03
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("//SettingPage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("錯誤", $"導覽至設定頁時發生錯誤：{ex.Message}", "確定");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("//Root/ProfilePage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("錯誤", $"導覽至個人資料頁時發生錯誤：{ex.Message}", "確定");
            }

        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("//ShopPage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("錯誤", $"導覽至商店頁時發生錯誤：{ex.Message}", "確定");
            }

        }
    }
}
