using System;
namespace OptimalWeekApp.ViewModels
{
	public class EventEditorViewModel: BaseViewModel
    {
		public EventEditorViewModel()
		{
			SelectedTimeStart = new TimeSpan(00, 00, 00);
            SelectedTimeEnd = new TimeSpan(00, 00, 00);

        }
		public TimeSpan SelectedTimeStart { get; set; }
        public TimeSpan SelectedTimeEnd { get; set; }
        public string Greeting {
            get
            {
                if (DateTime.Now.Hour < 12)
                    return "Good morning";
                else if (DateTime.Now.Hour < 18)
                    return "Good afternoon";
                else
                    return "Good evening!";
            }
        }
    }
}

