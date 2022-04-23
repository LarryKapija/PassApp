using System;
using PassApp.Pages;
using Xamarin.Forms;

namespace PassApp.Utils
{
	public static class Constants
	{
		public static class Pages
        {
			public const string navigationPage = nameof(NavigationPage);

			public const string passwordsPage = nameof(PasswordsPage);
			public const string addPassPage = nameof(AddPasswordPage);
        }

		public static class Firebase
        {
			public const string ApiKey = "https://prueba-24774-default-rtdb.firebaseio.com/";


			public const string passwords = nameof(passwords);

		}

		public static class Api
        {
			public const string apiBase = "https://passwordinator.herokuapp.com";
		}
	}
}

