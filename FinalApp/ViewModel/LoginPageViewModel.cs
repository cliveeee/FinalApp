using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FinalApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel 
    {
        public static string LoggedInUserName { get; private set; }
        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public ICommand SignInCommand { get; }

        public LoginPageViewModel()
        {
            SignInCommand = new Command(ExecuteSignIn);
        }

        private async void ExecuteSignIn()
        {
           
            string storedUsername = "Testuser";
            string storedPassword = "password";

            if (UserName == storedUsername && Password == storedPassword)
            {
                LoggedInUserName = storedUsername;
                Preferences.Set("username", UserName);
                await AppShell.Current.GoToAsync("//Home");
            }
            else
            {
                
                await Shell.Current.DisplayAlert("Login Error", "Invalid username or password", "OK");
            }
        }
    }
}
