using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OptimalWeekApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.youtube.com/@Anar_s"));
        }

        public ICommand OpenWebCommand { get; }
    }
}