using OptimalWeekApp.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OptimalWeekApp.Views
{
    public interface INavigationService
    {
        Task NavigateToDayPage(string day);
    }
    public partial class WeekPage : ContentPage, INavigationService
    {
        private WeekPageViewModel _viewModel;
        public WeekPage()
        {
            InitializeComponent();
            _viewModel = new WeekPageViewModel(this);
            BindingContext = _viewModel;
        }

        public async Task NavigateToDayPage(string day)
        {
            await Navigation.PushAsync(new DayPage(day));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.SaveState();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadState();
        }
    }
    public static class ImageResourceHelper
    {
        public static ImageSource MyImageSource => ImageSource.FromResource("OptimalWeekApp.Resources.weekplanningimage.jpg");
    }
}

