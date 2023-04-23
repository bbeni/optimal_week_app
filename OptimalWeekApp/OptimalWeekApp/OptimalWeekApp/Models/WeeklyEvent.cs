using System;
using System.Collections.Generic;
using System.Text;

namespace OptimalWeekApp.Models
{
    public enum WeekDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class DayTime
    {
        public int hours { get; set; }
        public int minutes { get; set; }
        public DayTime(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }
    }

    public class WeeklyEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WeekDay Day { get; set; }
        public DayTime Time { get; set; }
        public DayTime Duration { get; set; }

        public WeeklyEvent(string id, string name, string description, string day, DayTime time, DayTime duration)
        {
            Id = id;
            Name = name;
            Description = description;
            WeekDay d;
            Enum.TryParse<WeekDay>(day, out d);
            Day = d;
            Time = time;
            Duration = duration;
        }
    }
}
