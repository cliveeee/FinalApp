using Microsoft.Maui.Controls;
using FinalApp.ViewModels; 


namespace FinalApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();

            // Placeholders 
            userEntry.Text = "Testuser";
            passwordEntry.Text = "password";
        }
    }
}
