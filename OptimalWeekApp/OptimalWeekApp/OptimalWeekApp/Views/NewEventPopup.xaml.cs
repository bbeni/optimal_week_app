﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptimalWeekApp.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OptimalWeekApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewEventPopup: Popup
	{
		public NewEventPopup()
		{
			InitializeComponent();
			BindingContext = new EventEditorViewModel();
			
		}
    }
}