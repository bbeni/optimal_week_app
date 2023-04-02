using OptimalWeekApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OptimalWeekApp.Views
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