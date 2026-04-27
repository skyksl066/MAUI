namespace mod04
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            window.Activated += (s, e) =>
            {
                WindowToCenter(window);
            };
            return window;
        }

        public void WindowToCenter(Window window)
        {
#if WINDOWS
            window.Width = 800;
            window.Height = 600;
            var disp = DeviceDisplay.Current.MainDisplayInfo;
            // 將視窗置於螢幕中央
            window.X = (disp.Width / disp.Density - window.Width) / 2;
            window.Y =  (disp.Height / disp.Density - window.Height) / 2;
#endif
        }
    }
}