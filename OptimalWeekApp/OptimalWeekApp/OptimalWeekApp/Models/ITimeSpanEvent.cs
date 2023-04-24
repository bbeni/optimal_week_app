using Xamarin.Forms;

namespace OptimalWeekApp.Models
{
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
}
