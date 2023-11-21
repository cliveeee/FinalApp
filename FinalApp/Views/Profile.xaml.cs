using FinalApp.ViewModel;
using System.Diagnostics;

namespace FinalApp.Views
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
            UpdateLayoutForOrientation();
            ThemeManager.LoadThemePreference(); 
        }

        private void SwitchThemeMode_Toggled(object sender, ToggledEventArgs e)
        {
            ThemeManager.SwitchTheme(e.Value);
            Debug.WriteLine($"Theme preference saved: {e.Value}");
        }

        private void UpdateLayoutForOrientation()
        {
            // Landscape
            if (Width > Height) 
            {
                WidthRequest = 200;
            }
            // Portrait
            else
            {
                WidthRequest = double.NaN;
            }
        }
    }
}