using FinalApp.Resources.Styles;


namespace FinalApp
{
    public static class ThemeManager
    {
        private const string ThemePreferenceKey = "ThemePreference";

        public static void LoadThemePreference()
        {
            if (Preferences.ContainsKey(ThemePreferenceKey))
            {
                bool isDarkMode = Preferences.Get(ThemePreferenceKey, false);
                ApplyTheme(isDarkMode);
            }
        }

        public static void SwitchTheme(bool isDarkMode)
        {
            ApplyTheme(isDarkMode);

            // Save the theme preference
            Preferences.Set(ThemePreferenceKey, isDarkMode);
        }

        private static void ApplyTheme(bool isDarkMode)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            if (isDarkMode)
            {
                // DarkMode
                Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
            }
            else
            {
                // LightMode
                Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
            }
        }
    }
}
