using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PassApp.Pages
{	
	public partial class AddPasswordPage : ContentPage
	{	
		public AddPasswordPage ()
		{
			InitializeComponent ();

			var navigationPage = Application.Current.MainPage as NavigationPage;
			navigationPage.BarBackgroundColor = Color.FromHex("#A9CC3D");
		}
	}
}

