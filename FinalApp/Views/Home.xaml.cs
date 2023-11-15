using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using FinalApp.ViewModel;

namespace FinalApp.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var viewModel = new HomeViewModel();
            await viewModel.LoadDataFromApiAsync();
            BindingContext = viewModel;
        }
    }
}
