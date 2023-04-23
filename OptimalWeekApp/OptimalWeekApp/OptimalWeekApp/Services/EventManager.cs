using System;
using System.Collections.Generic;
using System.Text;
using OptimalWeekApp.Models;

namespace OptimalWeekApp.Models
{
    public class EventManager
    {
        private static readonly Lazy<EventManager> _instance = new Lazy<EventManager>(() => new EventManager());

        public static EventManager Instance => _instance.Value;

        public List<WeeklyEvent> Events { get; private set; }

        private EventManager()
        {
            Events = new List<WeeklyEvent>();
            // Initialize your list with default events or load events from storage if necessary
        }
    }

}
