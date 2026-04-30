using mod11.Views;

namespace mod11
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PetView), typeof(PetView));
        }
    }
}
