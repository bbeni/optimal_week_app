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
using OptimalWeekApp.Views;
using Xamarin.CommunityToolkit.Extensions;

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

            EventsAndFreetime = new ObservableCollection<ITimeSpanEvent>();
            Events = new ObservableCollection<ITimeSpanEvent>();
            LoadEventsCommand = new Command(async () => await ExecuteLoadEventsCommand());
            EventTapped = new Command<ITimeSpanEvent>(OnEventSelected);
            AddItemCommand = new Command(OnAddItem);


            Hours = new ObservableCollection<DayTime>();
            for (int i = 1; i <= 24; i++)
            {
                Hours.Add(new DayTime(i, 0));
            }

        }

        async void OnEventSelected(ITimeSpanEvent e)
        {
            Debug.WriteLine(e.ToString());
            if (e.GetType() == typeof(FreeTime))
            {
                var popup = new NewEventPopup();
                await OptimalWeekApp.App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            }
        }

        private void OnAddItem(object obj)
        {
            throw new NotImplementedException();
        }


        async Task ExecuteLoadEventsCommand()
        {
            IsBusy = true;

            try
            {
                Events.Clear();
                EventsAndFreetime.Clear();
                var allEvents = await WeeklyEventsDataStore.GetItemsAsync(true);

                foreach (var e in allEvents)
                {
                    if (e.Day.ToString() == Day)
                        Events.Add(e);
                }


                // add first empty timespan
                var currentTime = new DayTime(0, 0).toMinutes;
                var firstEvent = Events.FirstOrDefault();


                var lastEventEnd = new DayTime(0, 0);

                foreach (var e in Events)
                {
                    if (lastEventEnd < e.Time)
                    {
                        var duration = e.Time - lastEventEnd;
                        EventsAndFreetime.Add(new FreeTime(Day, lastEventEnd, duration));
                    }
                    EventsAndFreetime.Add(e);
                    lastEventEnd = e.Time + e.Duration;
                }

                if (lastEventEnd < new DayTime(24, 0))
                {
                    var lastFreetimeDuration = new DayTime(24, 0) - lastEventEnd;
                    EventsAndFreetime.Add(new FreeTime(Day, lastEventEnd, lastFreetimeDuration));
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

        public ObservableCollection<ITimeSpanEvent> Events { get; }
        public ObservableCollection<ITimeSpanEvent> EventsAndFreetime { get; }
        public ObservableCollection<DayTime> Hours { get; }
        public Command LoadEventsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ITimeSpanEvent> EventTapped { get; }



    }

}