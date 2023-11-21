namespace FinalApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ThemeManager.LoadThemePreference();
            MainPage = new AppShell();
        }
    }
}