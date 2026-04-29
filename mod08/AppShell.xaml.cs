using mod08.Views;

namespace mod08
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
