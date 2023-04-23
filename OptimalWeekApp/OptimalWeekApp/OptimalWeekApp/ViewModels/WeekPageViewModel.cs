using OptimalWeekApp.Views;
using OptimalWeekApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OptimalWeekApp.ViewModels
{
    public class WeekPageViewModel : BaseViewModel
    {

        public WeekPageViewModel(INavigationService navigationService)
        {
            Title = "Cool Week Planner";
            _navigationService = navigationService;

            NavigateToDayCommand = new Command<string>(async (day) =>
            {
                await _navigationService.NavigateToDayPage(day);
            });

        }
         
        public ICommand NavigateToDayCommand { get; private set; }
        private readonly INavigationService _navigationService;
    }
}