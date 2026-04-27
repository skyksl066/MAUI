namespace mod04
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

            Application app = App.Current;
            if (app is App app1)
            {
                var window = app.Windows[0];
                app1.WindowToCenter(window);
            }
        }
    }
}
