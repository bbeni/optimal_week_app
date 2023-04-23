using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

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
        public int toMinutes
        {
            get { return this.minutes + this.hours * 60; }
        }
        public DayTime(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }

        public DayTime(int totalMinutes)
        {
            this.hours = totalMinutes / 60;
            this.minutes = totalMinutes % 60;
        }
 

        public static bool operator <(DayTime a, DayTime b)
        {
            return a.toMinutes < b.toMinutes ; 
        }

        public static bool operator >(DayTime a, DayTime b)
        {
            return a.toMinutes < b.toMinutes;
        }

        public static DayTime operator +(DayTime dayTime1, DayTime dayTime2)
        {
            int hours = dayTime1.hours + dayTime2.hours;
            int minutes = dayTime1.minutes + dayTime2.minutes;
            hours += minutes / 60;
            minutes = minutes % 60;
            return new DayTime(hours, minutes);
        }
        public static DayTime operator -(DayTime dayTime1, DayTime dayTime2)
        {
            int hours = dayTime1.hours - dayTime2.hours;
            int minutes = dayTime1.minutes - dayTime2.minutes;
            if ( dayTime1 < dayTime2)
            {
                throw new ArgumentOutOfRangeException("second argument bigger than first! ");
            }

            hours += minutes / 60;
            minutes = minutes % 60;
            return new DayTime(hours, minutes);
        }

    }

    public interface ITimeSpanEvent
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        WeekDay Day { get; set; }
        DayTime Time { get; set; }
        DayTime Duration { get; set; }
        Color Color { get; set; }

    }

    public class WeeklyEvent : ITimeSpanEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WeekDay Day { get; set; }
        public DayTime Time { get; set; }
        public DayTime Duration { get; set; }
        public Color Color { get; set; }

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
            var rng = new Random();
            var colorList = new List<Color>{ Color.Aqua, Color.Beige, Color.Brown, Color.Firebrick};
            Color = colorList[rng.Next(colorList.Count)];
        }

    }

    public class FreeTime : WeeklyEvent
    {
        public FreeTime(string day, DayTime time, DayTime duration) : 
            base("0", "", "", day, time, duration)
        {
            Color = Color.Beige;
        }
    }
}
