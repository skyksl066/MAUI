using mod09.Views;

namespace mod09
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
