using mod03.Pages;

namespace mod03
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute($"//ShopPage/{nameof(ShopDetails)}", typeof(ShopDetails));
        }
    }
}
