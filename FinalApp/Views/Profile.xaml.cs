using FinalApp.ViewModel;
using FinalApp.Resources.Styles;
using Xe.AcrylicView;

namespace FinalApp.Views;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
        BindingContext = new ProfileViewModel();
        UpdateLayoutForOrientation();
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

    private void UpdateLayoutForOrientation()
    {
        if (Width > Height) // Landscape
        {
            WidthRequest = 200;
           
        }
        else // Portrait
        {
            WidthRequest = double.NaN; 
                                                   
        }
    }

}
