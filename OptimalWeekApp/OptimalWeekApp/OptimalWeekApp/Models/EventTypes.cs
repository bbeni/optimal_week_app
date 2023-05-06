using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;
using SQLite;

namespace OptimalWeekApp.Models
{

    public class WeeklyEvent : ITimeSpanEvent
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WeekDay Day { get; set; }
        [Ignore]
        public DayTime Time { get; set; }
        [Ignore]
        public DayTime Duration { get; set; }
        [Ignore]
        public Color Color { get; set; }


        public int ColorArgb
        {
            get => ColorConverter.ToInt(Color);
            set => Color = ColorConverter.FromInt(value);
        }

        public int TimeMinutes
        {
            get => DayTimeConverter.toMinutes(Time);
            set => Time = DayTimeConverter.fromMinutes(value);
        }

        public int DurationMinutes
        {
            get => DayTimeConverter.toMinutes(Duration);
            set => Duration = DayTimeConverter.fromMinutes(value);
        }

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
            var colorList = new List<Color>{ Color.Aquamarine, Color.Bisque, Color.BurlyWood, Color.Gold, Color.MistyRose, Color.Thistle};
            Color = colorList[rng.Next(colorList.Count)];
        }

        public WeeklyEvent() { }

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
