using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using OptimalWeekApp.Models;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace OptimalWeekApp.ViewModels
{
    public class DayPageViewModel : BaseViewModel
    {
        private string _day = string.Empty;
        public string Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }
        public DayPageViewModel(string day)
        {
            Day = day;
            clickMe = new Command(async =>
            {
                Day = "Anar test";
                Console.WriteLine(Day);
            });
        }

        public ICommand clickMe { get; private set; }


    }

}