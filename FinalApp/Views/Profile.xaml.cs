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

            // Load the switch state from Preferences
            bool switchValue = Preferences.Get("SwitchThemeMode", true);

            // Set the switch state
            SwitchThemeMode.IsToggled = switchValue;

            // Ensure the event handler is wired up
            SwitchThemeMode.Toggled += SwitchThemeMode_Toggled;
        }

        private void SwitchThemeMode_Toggled(object sender, ToggledEventArgs e)
        {
            ThemeManager.SwitchTheme(e.Value);

            // Save the switch state to Preferences
            Preferences.Set("SwitchThemeMode", e.Value);

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
