using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OptimalWeekApp.Models;
using OptimalWeekApp.Services;
using System.Linq;

namespace OptimalWeekApp.Services
{
    class MockEventStore: IDataStore<WeeklyEvent>
    {
        readonly List<WeeklyEvent> events;
        List<WeeklyEvent> selected_day;
        public MockEventStore()
        {
            events = new List<WeeklyEvent>()
            {
                new WeeklyEvent(Guid.NewGuid().ToString(), "gym", "go to gym", "Monday", new DayTime(18, 20), new DayTime(1,0)),
                new WeeklyEvent(Guid.NewGuid().ToString(), "gym", "go to gym", "Monday", new DayTime(20, 30), new DayTime(1,0)),
                new WeeklyEvent(Guid.NewGuid().ToString(), "school", "go to school", "Friday", new DayTime(8, 30), new DayTime(7,0))
            };
        }

        public async Task<IEnumerable<WeeklyEvent>> GetEventsWeekday(string weekday)
        {
            WeekDay day;
            Enum.TryParse<WeekDay>(weekday, out day);

            List<WeeklyEvent> byDay = new List<WeeklyEvent>();
            
            foreach (WeeklyEvent e in events) 
            {
                if (e.Day == day)
                {
                    byDay.Add(e);
                }
            }

            selected_day = byDay;
            
            return await Task.FromResult(byDay);
        }

        public async Task<bool> AddItemAsync(WeeklyEvent item)
        {
            events.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<WeeklyEvent> GetItemAsync(string id)
        {
            return await Task.FromResult(events.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<WeeklyEvent>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(events);
        }

        public Task<bool> UpdateItemAsync(WeeklyEvent item)
        {
            throw new NotImplementedException();
        }

        Task<WeeklyEvent> IDataStore<WeeklyEvent>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
