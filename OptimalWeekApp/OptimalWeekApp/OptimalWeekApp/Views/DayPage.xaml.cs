using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OptimalWeekApp.ViewModels;

namespace OptimalWeekApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayPage : ContentPage
    {
        public DayPage(string day)
        {
            InitializeComponent();
            BindingContext = new DayPageViewModel(day);
        }
    }
}