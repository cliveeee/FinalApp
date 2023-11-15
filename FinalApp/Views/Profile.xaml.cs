using FinalApp.ViewModel;
using FinalApp.Resources.Styles;
namespace FinalApp.Views;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
        BindingContext = new ProfileViewModel();
    }

	private void SwitchThemeMode_Toggled(object sender, ToggledEventArgs e)
	{
        Application.Current.Resources.MergedDictionaries.Clear();
        if (e.Value)
		{
			//DarkMode
			Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
		}
		else
		{
            //LightMode
            Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
        }
	}
}
