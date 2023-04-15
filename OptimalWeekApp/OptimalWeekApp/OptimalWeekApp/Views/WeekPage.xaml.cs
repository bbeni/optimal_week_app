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
        public WeekPage()
        {
            InitializeComponent();
            BindingContext = new WeekPageViewModel(this);
        }

        public async Task NavigateToDayPage(string day)
        {
            await Navigation.PushAsync(new DayPage(day));
        }
    }
}