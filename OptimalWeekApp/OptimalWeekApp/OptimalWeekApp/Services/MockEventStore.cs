using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OptimalWeekApp.Models;
using OptimalWeekApp.Services;
using System.Linq;

namespace OptimalWeekApp.Services
{
    class MockEventStore: IDataStore<ITimeSpanEvent>
    {
        readonly List<ITimeSpanEvent> events;
        public MockEventStore()
        {
            events = new List<ITimeSpanEvent>()
            {
                new WeeklyEvent(Guid.NewGuid().ToString(), "school", "go to school", "Monday", new DayTime(7, 0), new DayTime(4, 45)),
                new WeeklyEvent(Guid.NewGuid().ToString(), 
                    "gym", "go to gym, do a big workout that requires big and heavy lifting. It's really hard but worth it to do because I get stronger and stronger. Like a Bull that eats 500 kg of Grass everyday!",
                    "Monday", new DayTime(16, 30), new DayTime(2, 30)),
                new WeeklyEvent(Guid.NewGuid().ToString(), "dinner", "eat yummy dinner", "Monday", new DayTime(20, 30), new DayTime(1,50)),
                new WeeklyEvent(Guid.NewGuid().ToString(), "school", "go to school", "Friday", new DayTime(8, 30), new DayTime(7,0))
            };
        }

        public async Task<IEnumerable<ITimeSpanEvent>> GetEventsWeekday(string weekday)
        {
            WeekDay day;
            Enum.TryParse<WeekDay>(weekday, out day);

            List<ITimeSpanEvent> byDay = new List<ITimeSpanEvent>();

            foreach (WeeklyEvent e in events) 
            {
                if (e.Day == day)
                {
                    byDay.Add(e);
                }
            }
            
            return await Task.FromResult(byDay);
        }

        public async Task<bool> AddItemAsync(ITimeSpanEvent item)
        {
            events.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ITimeSpanEvent> GetItemAsync(string id)
        {
            return await Task.FromResult(events.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ITimeSpanEvent>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(events);
        }

        public Task<bool> UpdateItemAsync(ITimeSpanEvent item)
        {
            throw new NotImplementedException();
        }

        Task<ITimeSpanEvent> IDataStore<ITimeSpanEvent>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
