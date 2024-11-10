namespace MauiApp5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // loads saved theme preference on startup
            bool isDarkMode = Preferences.Get("IsDarkMode", false);
            UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;

            MainPage = new AppShell();
        }
    }
}
