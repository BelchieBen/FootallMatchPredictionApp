using FootallMatchPredictionApp.Models;
using FootallMatchPredictionApp.ViewModels;
using FootallMatchPredictionApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootallMatchPredictionApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Database.RefreshFixturesAsync();
            _viewModel.OnAppearing();
        }
    }
}