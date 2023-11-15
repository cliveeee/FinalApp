using System;
using Microsoft.Maui.Controls;
using FinalApp.ViewModels;
using FinalApp.Model;

namespace FinalApp.Views
{
    public partial class Stats : ContentPage
    {
        public Stats()
        {
            InitializeComponent();

            // Initialize and set the binding context
            FootballClubsViewModel viewModel = new FootballClubsViewModel();
            BindingContext = viewModel;

            // Now the ListView in your XAML will automatically populate with data from viewModel.ClubModels
        }
    }
}
