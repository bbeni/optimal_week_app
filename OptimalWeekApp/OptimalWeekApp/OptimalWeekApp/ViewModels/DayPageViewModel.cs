using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using OptimalWeekApp.Models;
using System.Windows.Input;

namespace OptimalWeekApp.ViewModels
{
    public class DayPageViewModel: BaseViewModel
    {
        public DayPageViewModel()
        {
            GoBackCommand = new Command(GoBack);
        }
        private async void GoBack(object back)
        {
            await Shell.Current.GoToAsync("///WeekPage");
        }
        public ICommand GoBackCommand { get; }
    }
}