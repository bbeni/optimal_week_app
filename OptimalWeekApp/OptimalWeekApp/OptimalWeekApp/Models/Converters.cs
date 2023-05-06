using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace OptimalWeekApp.Models
{
    public static class ColorConverter
    {
        public static int ToInt(Xamarin.Forms.Color color)
        {
            int a = (int)(color.A * 255);
            int r = (int)(color.R * 255);
            int g = (int)(color.G * 255);
            int b = (int)(color.B * 255);
            return (a << 24) | (r << 16) | (g << 8) | b;
        }

        public static Xamarin.Forms.Color FromInt(int argb)
        {
            int a = (argb >> 24) & 0xFF;
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = argb & 0xFF;
            return Xamarin.Forms.Color.FromRgba(r, g, b, a);
        }

    }

    public static class DayTimeConverter
    {
        public static int toMinutes(DayTime dt)
        {
            return dt.toMinutes;
        }

        public static DayTime fromMinutes(int minutes)
        {
            return new DayTime(minutes);
        }
    }

}
