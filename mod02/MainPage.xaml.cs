namespace mod02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_GetOSVersion(object sender, EventArgs e)
        {
            LblOSVersion.Text = $"Platform:{DeviceInfo.Current.Platform}, Version:{DeviceInfo.Current.VersionString}";
        }
    }
}
