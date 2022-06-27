using FootallMatchPredictionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FootallMatchPredictionApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}