using System;

namespace OptimalWeekApp.Models
{
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
}
