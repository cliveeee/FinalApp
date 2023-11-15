using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FinalApp.ViewModels;

namespace FinalApp.Views
{
    public partial class Fixtures : ContentPage
    {
        public Fixtures()
        {
            InitializeComponent();
            BindingContext = new FixturesViewModel();
        }
    }
}
