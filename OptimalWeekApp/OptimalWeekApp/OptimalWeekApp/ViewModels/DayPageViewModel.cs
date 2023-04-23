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
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

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

            Debug.WriteLine(day);


            Events = new ObservableCollection<WeeklyEvent>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Item>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);

        }


        private void OnAddItem(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnItemSelected(Item obj)
        {
            throw new NotImplementedException();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Events.Clear();
                var events = await WEDataStore.GetItemsAsync(true);

                foreach (var e in events)
                {
                    if (e.Day.ToString() == Day)
                        Events.Add(e);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal void OnAppearing()
        {
            IsBusy = true;
            
        }

        public ICommand clickMe { get; private set; }

        public ObservableCollection<WeeklyEvent> Events { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }



    }

}