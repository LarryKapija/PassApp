using System;
using Prism.Navigation;
using Xamarin.Essentials;
namespace PassApp.ViewModels
{
	[PropertyChanged.AddINotifyPropertyChangedInterface]
	public abstract class BaseViewModel
	{
		protected readonly INavigationService navigationService;
		protected bool ThereIsInternetConnection { get; set; }

		public BaseViewModel(INavigationService navigationService)
		{
			this.navigationService = navigationService;

			ThereIsInternetConnection = Connectivity.NetworkAccess == NetworkAccess.Internet;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
		}

		~BaseViewModel()
		{
			Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
		}

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
			ThereIsInternetConnection = e.NetworkAccess == NetworkAccess.Internet;
        }
    }
}

