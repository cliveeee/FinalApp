using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using FinalApp.ViewModels;

namespace FinalApp.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand SignOutCommand { get; }

        public ProfileViewModel()
        {
            SignOutCommand = new Command(ExecuteSignOut);
            UserName = LoginPageViewModel.LoggedInUserName;
            userName = Preferences.Get("username", UserName);
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private async void ExecuteSignOut()
        {
           
            
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
