using System;
using System.Diagnostics;
using System.Threading.Tasks;
using PassApp.Models;
using PassApp.Services.Interfaces;
using PassApp.Utils;
using Prism.Commands;
using Prism.Navigation;
using Refit;
using Xamarin.Forms;

namespace PassApp.ViewModels
{
	public class AddPasswordViewModel : BaseViewModel
	{
        public Password Password { get; set; }
        public string Contra { get; set; }

        public bool Numeric { get; set; }
        public bool Char { get; set; }
        public bool Caps { get; set; }
        public int Len { get; set; }

        private IApiService _apiService;
        private readonly ICloudDBService cloudDBService;

        public DelegateCommand CalculatePasswordComand { get; set; }
        public DelegateCommand SavePasswordCommand { get; set; }

        public AddPasswordViewModel(INavigationService navigationService, ICloudDBService cloudDBService) : base(navigationService)
        {
            Password = new Password();
            this.cloudDBService = cloudDBService;

            try
            {

                _apiService = RestService.For<IApiService>(Constants.Api.apiBase);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            CalculatePasswordComand = new DelegateCommand(async () => await CalculatePassword());
            SavePasswordCommand = new DelegateCommand(async () => await SavePassword());
        }

        private async Task SavePassword()
        {
            if (ThereIsInternetConnection)
            {
                if (string.IsNullOrEmpty(Password.Title) || string.IsNullOrEmpty(Password.Pass))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    await App.Current.MainPage.DisplayAlert("ERROR", "Todos los campos son requeridos", "Aceptar"));

                    return;
                }
                await cloudDBService.PostPassword(Password);
                await navigationService.GoBackAsync();
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                    await App.Current.MainPage.DisplayAlert("ERROR", "Revise su conexion a internet", "Aceptar"));
            }

        }

        private async Task CalculatePassword()
        {
            if (ThereIsInternetConnection)
            {
                var response = await _apiService.GetPassword(Numeric, Char, Caps, Len);

                if (response.IsSuccessStatusCode)
                {
                    Password.Pass = Contra = response.Content.Data;
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                    await App.Current.MainPage.DisplayAlert("ERROR","Revise su conexion a internet", "Aceptar"));
            }

        }
	}
}

