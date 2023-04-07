using OptimalWeekApp.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OptimalWeekApp.ViewModels
{
    public class WeekPageViewModel : BaseViewModel
    {
        private async void GotoMonday(object obj)
        {
            await Shell.Current.GoToAsync("///DayPage");
        }
        public WeekPageViewModel()
        {
            Title = "About";

            async void test()
            {
                Task.Delay(10000).Wait();
                await Browser.OpenAsync("https://www.google.com");
            }

            OpenWebCommand = new Command(test);
            OpenDayViewCommand = new Command(GotoMonday);


        }
         
        public ICommand OpenWebCommand { get; }
        public ICommand OpenDayViewCommand { get; }
    }
}